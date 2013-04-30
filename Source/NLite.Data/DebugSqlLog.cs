using System;
using System.Diagnostics;
using System.Reflection;
using NLite.Data.Common;

namespace NLite.Data
{
    class DebugSqlLog : ISqlLog
    {
        static readonly string Version = "-- ELinq Version:" + Assembly.GetExecutingAssembly().GetName().Version.ToString();

        public void LogMessage(string message)
        {
            Debug.WriteLine(message);
        }

        public void LogCommand(string commandText, NamedParameter[] parameters, object[] paramValues)
        {

            Debug.WriteLine(commandText);
            if (paramValues != null)
                this.LogParameters(parameters, paramValues);
            Debug.WriteLine("");
            Debug.WriteLine(Version);

            var dbContext = ExecuteContext.DbContext;
            if (dbContext != null)
                Debug.WriteLine("-- DbProviderName:" + dbContext.dbConfiguration.DbProviderName);

            var dialect = ExecuteContext.Dialect;
            if (dialect != null)
                Debug.WriteLine("-- Dialect:" + dialect.GetType().Name);
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
                        Debug.WriteLine(string.Format("-- {0}:(DbType = {1}, Length = {2}, Value = NULL)", p.Name, p.sqlType.DbType, p.sqlType.Length));
                    else
                        Debug.WriteLine(string.Format("-- {0}:(DbType = {1}, Length = {2}, Value = {3})", p.Name, p.sqlType.DbType, p.sqlType.Length, v));
                }
            }
        }
    }
}
