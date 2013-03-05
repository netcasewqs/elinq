using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLite.Reflection;
using NLite.Collections;
using System.Linq.Expressions;

using NLite.Data.Mapping;
using System.Data.Common;
using System.Data;
using System.Runtime.Remoting.Messaging;
using NLite.Data.Common;
using NLite.Data.Dialect.Function;
using NLite.Data.Dialect.ExpressionBuilder;
using NLite.Data.Dialect.SqlBuilder;
using System.Collections.Specialized;
using System.Collections;
using System.Reflection;

namespace NLite.Data.Dialect
{
    /// <summary>
    /// 数据库方言
    /// </summary>
    abstract partial class Dialect : NLite.Data.Dialect.IDialect
    {
        public virtual bool SupportInsert { get { return true; } }
        public virtual bool SupportDelete { get { return true; } }
        public virtual bool SupportUpdate { get { return true; } }
        public virtual bool SupportSelect { get { return true; } }

        public virtual bool SupportSchema { get { return false; } }

        public virtual bool SupportMultipleCommands { get { return false; } }
        public virtual bool SupportSubqueryInSelectWithoutFrom { get { return false; } }
        public virtual bool SupportDistinctInAggregates { get { return false; } }

        public virtual char CloseQuote { get { return ']'; } }
        public virtual char OpenQuote { get { return '['; } }

        public virtual string Quote(string name)
        {
            return OpenQuote + name + CloseQuote;
        }

    }
}
