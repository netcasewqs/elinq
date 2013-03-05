using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.IO;
using System.Reflection;

namespace NLite.Data.Schema.Script.Executor
{
    class SqlCeScriptExecutor:FileDatabaseScriptExecutor
    {
        protected override void OnCreateDatabase(DbConfiguration dbConfiguration, string dbName)
        {
            var type = dbConfiguration.DbProviderFactory.GetType().Module.GetType("System.Data.SqlServerCe.SqlCeEngine");

            var engine = Activator.CreateInstance(type, dbConfiguration.ConnectionString);
            var flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.InvokeMethod;
            try
            {
                type.InvokeMember("CreateDatabase", flags, null, engine, new object[0]);
            }
            catch (TargetInvocationException ex)
            {
                throw ex.InnerException;
            }
        }
       
    }
}
