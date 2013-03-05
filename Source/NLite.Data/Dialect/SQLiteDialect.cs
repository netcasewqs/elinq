using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Linq.Expressions;
using NLite.Data.Linq.Expressions;
using System.Reflection;
using NLite.Reflection;
using System.Data;
using NLite.Data.Common;
using NLite.Data.Mapping;
using NLite.Data.Dialect.ExpressionBuilder;
using NLite.Data.Dialect.Function;
using NLite.Data.Dialect.Function.SQLite;
using NLite.Data.Dialect.SqlBuilder;

namespace NLite.Data.Dialect
{
    partial class SQLiteDialect : Dialect
    {
       
        public override char OpenQuote
        {
            get { return '['; }
        }

        public override char CloseQuote
        {
            get { return ']'; }
        }

      

     
   

      
        
    }
}
