﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NLite.Data.Schema.Script.Executor
{
    class SqlServer2000ScriptExecutor:SqlServerScriptExecutor
    {
        protected override void CreateTables(ISqlLog log, DatabaseScriptEntry script, IDbContext ctx)
        {
            script.SchemaScripts = null;
            base.CreateTables(log, script, ctx);
        }
    }
}
