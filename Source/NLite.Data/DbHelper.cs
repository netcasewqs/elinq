using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using NLite.Data.Driver;

namespace NLite.Data
{
    class DbHelper : ConnectionHost, IDbHelper
    {

        internal DbConfiguration dbConfiguration;
        public IDriver Driver { get; set; }

        public DbConnection Connection { get { return connection; } }

        public DbConfiguration DbConfiguration { get { return dbConfiguration; } }

        public CommandType CommandType;

        public DbParameter Parameter(string name, object value)
        {
            var p = dbConfiguration.DbProviderFactory.CreateParameter();
            p.ParameterName = name;
            p.Value = value;
            return p;
        }

#if SDK35
        public int ExecuteNonQuery(string sql, object namedParameters)
        {
            Guard.NotNullOrEmpty(sql, "sql");
            try
            {
                using (var cmd = Driver.CreateCommand(connection, sql, namedParameters))
                {
                    cmd.CommandType = CommandType;
                    if (connection.State != ConnectionState.Open)
                        connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new PersistenceException(ex.Message, ex);
            }
           
        }

        public DbDataReader ExecuteReader(string sql, object namedParameters)
        {
            Guard.NotNullOrEmpty(sql, "sql");

            try
            {
                using (var cmd = Driver.CreateCommand(connection, sql, namedParameters))
                {
                     cmd.CommandType = CommandType;
                    if (connection.State != ConnectionState.Open)
                        connection.Open();
                    return cmd.ExecuteReader();
                }
            }
            catch (Exception ex)
            {
                throw new QueryException(ex.Message, ex);
            }
        }

        public DataTable ExecuteDataTable(string sql, object namedParameters)
        {

            Guard.NotNullOrEmpty(sql, "sql");

            try
            {
                using (var cmd = Driver.CreateCommand(connection, sql, namedParameters))
                {
                    cmd.CommandType = CommandType;
                    var adp = this.dbConfiguration.DbProviderFactory.CreateDataAdapter();
                    adp.SelectCommand = cmd;
                    var tb = new DataTable("Table1");
                    adp.Fill(tb);
                    return tb;
                }
            }
            catch (Exception ex)
            {
                throw new QueryException(ex.Message, ex);
            }
        }

        public DataSet ExecuteDataSet(string sql, object namedParameters)
        {

            Guard.NotNullOrEmpty(sql, "sql");

            try
            {
                using (var cmd = Driver.CreateCommand(connection, sql, namedParameters))
                {
                    cmd.CommandType = CommandType;
                    var adp = this.dbConfiguration.DbProviderFactory.CreateDataAdapter();
                    adp.SelectCommand = cmd;
                    var ds = new DataSet();
                    adp.Fill(ds);
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw new QueryException(ex.Message, ex);
            }
        }


        public object ExecuteScalar(string sql, object namedParameters)
        {

            Guard.NotNullOrEmpty(sql, "sql");

            try
            {
                using (var cmd = Driver.CreateCommand(connection, sql, namedParameters))
                {
                    cmd.CommandType = CommandType;
                    if (connection.State != ConnectionState.Open)
                        connection.Open();
                    return cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                throw new QueryException(ex.Message, ex);
            }
        }
#else
        public int ExecuteNonQuery(string sql, dynamic namedParameters)
        {
            Guard.NotNullOrEmpty(sql, "sql");
            try
            {
                using (DbCommand cmd = Driver.CreateCommand(connection, sql, namedParameters))
                {
                    cmd.CommandType = CommandType;
                    if (connection.State != ConnectionState.Open)
                        connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new PersistenceException(ex.Message, ex);
            }

        }

        public DbDataReader ExecuteReader(string sql, dynamic namedParameters)
        {
            Guard.NotNullOrEmpty(sql, "sql");

            try
            {
                using (var cmd = Driver.CreateCommand(connection, sql, namedParameters))
                {
                    cmd.CommandType = CommandType;
                    if (connection.State != ConnectionState.Open)
                        connection.Open();
                    return cmd.ExecuteReader();
                }
            }
            catch (Exception ex)
            {
                throw new QueryException(ex.Message, ex);
            }
        }

        public DataTable ExecuteDataTable(string sql, dynamic namedParameters)
        {

            Guard.NotNullOrEmpty(sql, "sql");

            try
            {
                using (var cmd = Driver.CreateCommand(connection, sql, namedParameters))
                {
                    cmd.CommandType = CommandType;
                    var adp = this.dbConfiguration.DbProviderFactory.CreateDataAdapter();
                    adp.SelectCommand = cmd;
                    var tb = new DataTable("Table1");
                    adp.Fill(tb);
                    return tb;
                }
            }
            catch (Exception ex)
            {
                throw new QueryException(ex.Message, ex);
            }
        }

        public DataSet ExecuteDataSet(string sql, dynamic namedParameters)
        {

            Guard.NotNullOrEmpty(sql, "sql");

            try
            {
                using (var cmd = Driver.CreateCommand(connection, sql, namedParameters))
                {
                    cmd.CommandType = CommandType;
                    var adp = this.dbConfiguration.DbProviderFactory.CreateDataAdapter();
                    adp.SelectCommand = cmd;
                    var ds = new DataSet();
                    adp.Fill(ds);
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw new QueryException(ex.Message, ex);
            }
        }


        public object ExecuteScalar(string sql, dynamic namedParameters)
        {

            Guard.NotNullOrEmpty(sql, "sql");

            try
            {
                using (var cmd = Driver.CreateCommand(connection, sql, namedParameters))
                {
                    cmd.CommandType = CommandType;
                    if (connection.State != ConnectionState.Open)
                        connection.Open();
                    return cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                throw new QueryException(ex.Message, ex);
            }
        }
#endif



    }
}
