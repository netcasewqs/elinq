﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using NLite.Data.Dialect.SqlBuilder;

namespace NLite.Data.Dialect.Function.Access
{
    class ToDate3FunctionView : IFunctionView
    {
        public void Render(ISqlBuilder builder, params Expression[] args)
        {
            if (args.Length == 1)
            {
                builder.Append("Format(");
                builder.Visit(args[0]);
                builder.Append(",'yyyy/m/d')");
            }
            else
            {
                builder.Append("CDate(");
                builder.Visit(args[0]);
                builder.Append(" & '/' & ");
                builder.Visit(args[1]);
                builder.Append(" & '/' & ");
                builder.Visit(args[2]);
                builder.Append(")");
            }
        }
    }
}
