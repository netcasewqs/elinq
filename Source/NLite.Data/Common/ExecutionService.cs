using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Runtime.CompilerServices;
using NLite.Data.Exceptions;

namespace NLite.Data.Common
{
    internal class ExecutionService
    {
        InternalDbContext dbContext;
        int rowsAffected;
        ISqlLog log;
        ISQLExceptionConverter exceptionConverter;

        static long counter;

        public ExecutionService(InternalDbContext dbContext)
        {
            this.dbContext = dbContext;
            log = dbContext.Log;
            if (log == null)
                log = SqlLog.Debug;

            if (exceptionConverter == null)
            {
                exceptionConverter = new SqlExceptionConverter();
            }
        }

        public IDbContext DbContext
        {
            get { return this.dbContext; }
        }

        public int RowsAffected
        {
            get { return this.rowsAffected; }
        }

        IDataReader ExecuteReader(DbCommand command)
        {
            DbDataReader reader = null;

            try
            {
                reader = command.ExecuteReader();
            }
            catch (DbException ex)
            {
                var exceptionContext = new DbExceptionContextInfo
                {
                    SqlException = new QueryException(ex.Message,ex),
                    Message = "unable to select data.",
                    Sql = command.CommandText,
                    
                };
                throw ExceptionHelper.Convert(log,exceptionConverter, exceptionContext);
            }

            if (!this.dbContext.Driver.AllowsMultipleOpenReaders)
            {
                var table = reader.ToDataTable();
                reader = table.CreateDataReader();
            }

            return reader;
        }


        public IEnumerable<T> Query<T>(QueryContext<T> q)
        {
            log.LogCommand(q.CommandText, q.Parameters, q.ParameterValues);

            try
            {
                using (var cmd = this.GetCommand(q.CommandText, q.Parameters, q.ParameterValues))
                {
                    var reader = ExecuteReader(cmd);

                    return Project(reader, q.FnProjector);
                }
            }
            catch (ConnectionException)
            {
                throw;
            }
            catch (QueryException)
            {
                throw;
            }
            catch (ProjectionException)
            {
                throw;
            }

            catch (Exception ex)
            {
                throw new QueryException(ex.Message, ex);
            }
            finally
            {
               
            }
        }

        IEnumerable<T> Project<T>(IDataReader reader, Func<FieldReader, T> fnProjector)
        {
            var items = new List<T>();
            var freader = new FieldReader(reader);
            while (reader.Read())
            {
                T item = default(T);
                try
                {
                    item = fnProjector(freader);
                    items.Add(item);
                }
                catch (Exception ex)
                {

                    var exceptionContext = new DbExceptionContextInfo
                    {
                        SqlException = new ProjectionException(ex.Message, ex),
                        Message = "data bind exception.",
                    };
                    throw ExceptionHelper.Convert(log, exceptionConverter, exceptionContext);
                }
               
            }
            return items;
        }

        public int ExecuteNonQuery(CommandContext ctx)
        {
            this.log.LogCommand(ctx.CommandText, ctx.Parameters, ctx.ParameterValues);

            using (var cmd = this.GetCommand(ctx.CommandText, ctx.Parameters, ctx.ParameterValues))
            {
                try
                {
                    this.rowsAffected = cmd.ExecuteNonQuery();

                    if (ctx.SupportsVersionCheck && rowsAffected == 0)
                        throw new ConcurrencyException(ctx.Instance, ctx.OperationType);
                }
                catch (Exception ex)
                {
                    var exceptionContext = new DbExceptionContextInfo
                    {
                        EntityName = ctx.EntityType.FullName,
                        //Message = "unable to select data.",
                        Entity = ctx.Instance,
                        Sql = cmd.CommandText,
                    };

                    switch (ctx.OperationType)
                    {
                        case OperationType.Insert:
                            exceptionContext.SqlException = new InsertException(ex.Message, ex);
                            break;
                        case OperationType.Update:
                            exceptionContext.SqlException = new UpdateException(ex.Message, ex);
                            break;
                        case OperationType.Delete:
                            exceptionContext.SqlException = new DeleteException(ex.Message, ex);
                            break;
                    }
                    throw ExceptionHelper.Convert(log, exceptionConverter, exceptionContext,ctx.ParameterValues,ctx.Parameters);
                }
            }

          
            return this.rowsAffected;
        }

        public IEnumerable<int> Batch(BatchContext q)
        {
            return this.ExecuteBatch(q.CommandText, q.Parameters, q.ParameterSets);
        }

        IEnumerable<int> ExecuteBatch(string commandText, NamedParameter[] parameters, IEnumerable<object[]> paramSets)
        {

            DataTable dataTable = new DataTable();
            for (int i = 0, n = parameters.Length; i < n; i++)
            {
                var qp = parameters[i];
                dataTable.Columns.Add(qp.Name, NLite.Reflection.TypeHelper.GetNonNullableType(qp.Type));
            }

            log.LogMessage("-- Start SQL Batching --");
            log.LogMessage("");
            log.LogCommand(commandText, parameters, null);

            foreach (var paramValues in paramSets)
            {
                dataTable.Rows.Add(paramValues);
                log.LogParameters(parameters, paramValues);
                log.LogMessage("");
            }

            var count = dataTable.Rows.Count;
            var result = new int[count];
            if (count > 0)
            {
                int n;



                try
                {
                    var dataAdapter = this.dbContext.dbConfiguration.DbProviderFactory.CreateDataAdapter();
                    //dataAdapter.UpdateBatchSize = batchSize;

                    var cmd = this.GetCommand(commandText, parameters, null);
                    for (int i = 0, m = parameters.Length; i < m; i++)
                        cmd.Parameters[i].SourceColumn = parameters[i].Name;
                    dataAdapter.InsertCommand = cmd;//系统会根据InsertCommand自动生成相关的DeleteCommand等
                    dataAdapter.InsertCommand.UpdatedRowSource = UpdateRowSource.None;
                    n = dataAdapter.Update(dataTable);
                }
                catch (ConnectionException)
                {
                    throw;
                }
                catch (DBConcurrencyException)
                {
                    throw;
                }
                catch (Exception ex)
                {
                    var exceptionContext = new DbExceptionContextInfo
                    {
                        Sql = commandText,
                        SqlException = new PersistenceException(ex.Message,ex),
                    };

                    throw ExceptionHelper.Convert(log, exceptionConverter, exceptionContext);
                }

                for (int i = 0; i < count; i++)
                    result[i] = i < n ? 1 : 0;
                dataTable.Rows.Clear();
            }


            log.LogMessage("-- End SQL Batching --");
            log.LogMessage("");

            return result;
        }

        public IEnumerable<T> Batch<T>(BatchContext<T> q)
        {
            return this.ExecuteBatch(q.CommandText, q.Parameters, q.ParameterSets, q.FnProjector);
        }

        IEnumerable<T> ExecuteBatch<T>(string commandText, NamedParameter[] parameters, IEnumerable<object[]> paramSets, Func<FieldReader, T> fnProjector)
        {
            log.LogCommand(commandText, parameters, null);
          
            var items = new List<T>();

            try
            {
                using (DbCommand cmd = this.GetCommand(commandText, parameters, null))
                {

                    //if (dialect.SupportPreparingCommands)
                    //    cmd.Prepare();

                    foreach (var paramValues in paramSets)
                    {
                        log.LogParameters(parameters, paramValues);
                        log.LogMessage("");

                        cmd.Parameters.Clear();
                        SetParameterValues(parameters, cmd, paramValues);

                        using (var reader = cmd.ExecuteReader())
                        {
                            var freader = new FieldReader(reader);
                            if (reader.Read())
                                items.Add(fnProjector(freader));
                            else
                                items.Add(default(T));
                        }
                    }
                }
            }
            catch (ConnectionException)
            {
                throw;
            }
            catch (DBConcurrencyException)
            {
                throw;
            }
            catch (Exception ex)
            {
                var exceptionContext = new DbExceptionContextInfo
                {
                    Sql = commandText,
                    SqlException = new PersistenceException(ex.Message, ex),
                };

                throw ExceptionHelper.Convert(log, exceptionConverter, exceptionContext);
            }

            return items;
        }

        static bool hasCreatingDatabase;
        protected void CreateDatabase()
        {
            hasCreatingDatabase = true;
            try
            {
                dbContext.dbConfiguration.CreateDatabase();
            }
            catch
            {
                throw;
            }
            finally
            {
                hasCreatingDatabase = false;
            }
            switch (dbContext.dbConfiguration.DbProviderName)
            {
                case DbProviderNames.SqlServer:
                    System.Threading.Thread.Sleep(6000);
                    break;
            }

        }

        static long Counter
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return counter += 1;
            }
        }

        DbCommand GetCommand(string commandText, NamedParameter[] parameters, object[] paramValues)
        {
            if (Counter == 1)
            {
                var dbExists = dbContext.dbConfiguration.DatabaseExists();
                if (dbExists)
                    dbContext.dbConfiguration.ValidateSchema();
                else if (!hasCreatingDatabase)
                    CreateDatabase();
            }


            var cmd = this.dbContext.Connection.CreateCommand();
            cmd.CommandText = commandText;
            SetParameterValues(parameters, cmd, paramValues);
            if (cmd.Connection.State != ConnectionState.Open)
            {
                try
                {
                    this.dbContext.Connection.Open();
                }
                catch (Exception ex)
                {
                    throw new ConnectionException(ex.Message, ex);
                }
            }

            return cmd;
        }

        void SetParameterValues(NamedParameter[] parameters, DbCommand command, object[] paramValues)
        {
            if (parameters.Length > 0 && command.Parameters.Count == 0)
            {
                for (int i = 0, n = parameters.Length; i < n; i++)
                {
                    dbContext.Driver.AddParameter(command, parameters[i], paramValues != null ? paramValues[i] : null);
                }
            }
            else if (paramValues != null)
            {
                for (int i = 0, n = command.Parameters.Count; i < n; i++)
                {
                    DbParameter p = command.Parameters[i];
                    if (p.Direction == System.Data.ParameterDirection.Input
                     || p.Direction == System.Data.ParameterDirection.InputOutput)
                    {
                        p.Value = paramValues[i] ?? DBNull.Value;
                    }
                }
            }
        }
    }
}
