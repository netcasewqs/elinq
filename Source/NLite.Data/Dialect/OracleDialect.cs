using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLite.Data.Dialect.ExpressionBuilder;
using System.Data;
using NLite.Data.Dialect.Function;
using NLite.Data.Dialect.Function.Oracle;
using System.Linq.Expressions;
using NLite.Data.Dialect.SqlBuilder;
using NLite.Data.Linq.Expressions;

namespace NLite.Data.Dialect
{
    partial class OracleDialect:Dialect
    {
       
        public override bool SupportMultipleCommands
        {
            get { return false; }
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
                return '\"';
            }
        }

        public override char CloseQuote
        {
            get
            {
                return '\"';
            }
        }



        public override string Quote(string name)
        {
            return OpenQuote + name.ToUpper()+CloseQuote;
        }
    }
}
