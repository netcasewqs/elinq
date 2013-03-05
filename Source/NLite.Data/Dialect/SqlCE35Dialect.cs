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
using NLite.Data.Dialect.ExpressionBuilder;
using NLite.Data.Dialect.Function;
using NLite.Data.Dialect.Function.SqlCe;
using NLite.Data.Dialect.SqlBuilder;
using NLite.Data.Common;
using System.Data.Common;

namespace NLite.Data.Dialect
{
    //SQLCE:官方文档 http://technet.microsoft.com/zh-cn/library/ms174450.aspx
    partial class SqlCe35Dialect : Dialect
    {
      
        public override bool SupportMultipleCommands
        {
            get { return false; }
        }

        public override bool SupportDistinctInAggregates
        {
            get { return false; }
        }
    
    }
}
