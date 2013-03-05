using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Linq.Expressions;
using System.Data;
using System.Reflection;
using NLite.Data.Linq.Expressions;
using NLite.Reflection;
using NLite.Data.Mapping;
using NLite.Data.Common;
using NLite.Data.Dialect.ExpressionBuilder;
using NLite.Data.Dialect.Function;
using NLite.Data.Dialect.Function.MySQL;
using NLite.Data.Dialect.SqlBuilder;

namespace NLite.Data.Dialect
{
    partial class MySqlDialect : Dialect
    {
        public override char CloseQuote
        {
            get
            {
                return '`';
            }
        }

        public override char OpenQuote
        {
            get
            {
                return '`';
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
