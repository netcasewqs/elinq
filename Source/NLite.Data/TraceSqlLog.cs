using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Reflection;
using NLite.Data.Common;

namespace NLite.Data
{
    class TraceSqlLog : ISqlLog
    {
        static readonly string Version = "-- ELinq Version:" + Assembly.GetExecutingAssembly().GetName().Version.ToString();

        public void LogMessage(string message)
        {
            Trace.WriteLine(message, "ELinq");
        }

        public void LogCommand(string commandText, NamedParameter[] parameters, object[] paramValues)
        {

            Trace.WriteLine(commandText, "ELinq");
            if (paramValues != null)
                this.LogParameters(parameters, paramValues);
            Trace.WriteLine("", "ELinq");
            Trace.WriteLine(Version, "ELinq");

            var dbContext = ExecuteContext.DbContext;
            if (dbContext != null)
                Trace.WriteLine("-- DbProviderName:" + dbContext.dbConfiguration.DbProviderName, "ELinq");

            var dialect = ExecuteContext.Dialect;
            if (dialect != null)
                Trace.WriteLine("-- Dialect:" + dialect.GetType().Name, "ELinq");
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
                        Trace.WriteLine(string.Format("-- {0}:(DbType = {1}, Length = {2}, Value = NULL)", p.Name, p.sqlType.DbType, p.sqlType.Length),"ELinq");
                    else
                        Trace.WriteLine(string.Format("-- {0}:(DbType = {1}, Length = {2}, Value = {3})", p.Name, p.sqlType.DbType, p.sqlType.Length, v),"ELinq");
                }
            }
        }
    }
}
