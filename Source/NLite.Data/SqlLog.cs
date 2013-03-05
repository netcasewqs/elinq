using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLite.Data.Common;
using System.IO;
using System.Reflection;

namespace NLite.Data
{
    public class SqlLog : ISqlLog
    {
        public static readonly ISqlLog Empty = new EmptyDbLog();
        public static readonly ISqlLog Console = new SqlLog(System.Console.Out);
        public static readonly ISqlLog Debug = new DebugSqlLog();
        public static readonly ISqlLog Trace = new TraceSqlLog();

        static readonly string Version = "-- ELinq Version:" + Assembly.GetExecutingAssembly().GetName().Version.ToString();

        private TextWriter log;
        public SqlLog(TextWriter log)
        {
            Guard.NotNull(log, "log");
            this.log = log;
        }

        public void LogMessage(string message)
        {
            log.WriteLine(message);
        }

        public void LogCommand(string commandText, NamedParameter[] parameters, object[] paramValues)
        {

            this.log.WriteLine(commandText);
            if (paramValues != null)
                this.LogParameters(parameters, paramValues);
            this.log.WriteLine();
            this.log.WriteLine(Version);

            var dbContext = ExecuteContext.DbContext;
            if (dbContext != null)
                log.WriteLine("-- DbProviderName:" + dbContext.dbConfiguration.DbProviderName);


            var dialect = ExecuteContext.Dialect;
            if (dialect != null)
                this.log.WriteLine("-- Dialect:" + dialect.GetType().Name);
        }

        public void LogParameters(NamedParameter[] parameters, object[] paramValues)
        {
            if (paramValues != null)
            {
                for (int i = 0, n = parameters.Length; i < n; i++)
                {
                    var p = parameters[i];
                    var v = paramValues[i];

                    if (v == null || v == DBNull.Value)
                        this.log.WriteLine("-- {0}:(DbType = {1}, Length = {2}, Value = NULL)", p.Name, p.sqlType.DbType, p.sqlType.Length);
                    else
                        this.log.WriteLine("-- {0}:(DbType = {1}, Length = {2}, Value = {3})", p.Name, p.sqlType.DbType, p.sqlType.Length, v);
                }
            }
        }
    }

}
