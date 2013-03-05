using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using NLite.Data.Dialect.SqlBuilder;

namespace NLite.Data.Dialect.Function.Access
{
    class ToDate6FunctionView : IFunctionView
    {
        public void Render(ISqlBuilder builder, params Expression[] args)
        {
            builder.Append("CDate(");
            builder.Visit(args[0]);
            builder.Append(" & '/' & ");
            builder.Visit(args[1]);
            builder.Append(" & '/' & ");
            builder.Visit(args[2]);
            builder.Append(" & ' ' & ");
            builder.Visit(args[3]);
            builder.Append(" & ':' & ");
            builder.Visit(args[4]);
            builder.Append(" & + ':' & ");
            builder.Visit(args[5]);
            builder.Append(")");

        }
    }
}
