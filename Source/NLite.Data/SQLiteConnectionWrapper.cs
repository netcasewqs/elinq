using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;

namespace NLite.Data
{
    class SQLiteConnectionWrapper:DbConnectionWrapper
    {
        public SQLiteConnectionWrapper(DbConfiguration dbConfiguraiton, DbConnection conn) : base(dbConfiguraiton, conn) { }

        public override void Open()
        {
            base.Open();
            BeginDbTransaction(IsolationLevel.Unspecified);
        }

        protected override void DisposeTransaction()
        {
            if (transaction != null && !transaction.WasCommitted && !transaction.WasRolledBack)
            {
                try
                {
                    transaction.Commit();
                }
                catch
                {
                    throw;
                }
                finally
                {
                    //transaction.Dispose();
                    transaction = null;
                }
            }
        }
    }
}
