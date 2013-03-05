using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using NLite.Data.Dialect.SqlBuilder;

namespace NLite.Data.Dialect.Function.Access
{
    class CompareFunctionView : IFunctionView
    {
        public static readonly IFunctionView Instance = new CompareFunctionView();
        public void Render(ISqlBuilder builder, params Expression[] args)
        {
            builder.Append("IIF(");
            builder.Visit(args[0]);
            builder.Append(" = ");
            builder.Visit(args[1]);
            builder.Append(", 0, IIF(");
            builder.Visit(args[0]);
            builder.Append(" < ");
            builder.Visit(args[1]);
            builder.Append(", -1, 1))");
        }
    }
}
