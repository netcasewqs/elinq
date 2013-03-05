using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using NLite.Reflection;

namespace NLite.Data
{
    class ODPConnectionWrapper:DbConnectionWrapper
    {
        static Setter _bindByNameProperty;

        public ODPConnectionWrapper(DbConfiguration dbConfiguraiton, DbConnection conn)
            : base(dbConfiguraiton, conn)
        {
            if (_bindByNameProperty == null)
                _bindByNameProperty = conn.GetType().Module.GetType("Oracle.DataAccess.Client.OracleCommand").GetProperty("BindByName").GetSetter();
        }

        protected override DbCommand CreateDbCommand()
        {
            var cmd = base.CreateDbCommand();
            _bindByNameProperty(cmd, true);
            return cmd;
        }
    }
}
