using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLite.Data.Dialect.ExpressionBuilder;
using NLite.Data.Dialect.Function;
using NLite.Data.Dialect.Function.Postgres;
using NLite.Data.Dialect.SqlBuilder;
using NLite.Data.Linq.Expressions;

namespace NLite.Data.Dialect
{
    partial class PostgresDialect : Dialect
    {
        public override char OpenQuote
        {
            get
            {
                return '"';
            }
        }
        public override char CloseQuote
        {
            get
            {
                return '"';
            }
        }

        public override bool SupportMultipleCommands
        {
            get { return false; }
        }
        public override bool SupportDistinctInAggregates
        {
            get { return true; }
        }

      
    }
}
