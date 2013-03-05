using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Linq.Expressions;
using NLite.Data.Linq.Expressions;
using System.Reflection;
using NLite.Reflection;
using System.Data;
using NLite.Data.Mapping;
using NLite.Data.Dialect.ExpressionBuilder;
using NLite.Data.Dialect.Function;
using NLite.Data.Dialect.Function.MsSql;
using NLite.Data.Dialect.SqlBuilder;
using System.Data.SqlClient;

namespace NLite.Data.Dialect
{
    partial class MsSql2000Dialect : Dialect
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

      
      

     

      
    }
}
