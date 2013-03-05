using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Reflection;
using NLite.Data.Linq.Expressions;
using NLite.Reflection;
using NLite.Data.Mapping;
using NLite.Data.Dialect.ExpressionBuilder;
using NLite.Data.Dialect.SqlBuilder;
using NLite.Data.Dialect.Function;
using NLite.Data.Dialect.Function.Firebird;

namespace NLite.Data.Dialect
{
    partial class FirebirdDialect:Dialect
    {
        public override bool SupportMultipleCommands
        {
            get { return true; }
        }

        public override bool SupportSubqueryInSelectWithoutFrom
        {
            get { return true; }
        }

        public override bool SupportDistinctInAggregates
        {
            get { return true; }
        }

      

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

     
    }
}
