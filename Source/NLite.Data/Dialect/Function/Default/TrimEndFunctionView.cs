using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using NLite.Data.Dialect.SqlBuilder;

namespace NLite.Data.Dialect.Function.Default
{
    class TrimEndFunctionView : IFunctionView
    {
        public virtual void Render(ISqlBuilder visitor, params Expression[] args)
        {
            var targetArg = args[0];
            visitor.Append("RTRIM(");
            visitor.Visit(targetArg);
            visitor.Append(")");

        }
    }
}
