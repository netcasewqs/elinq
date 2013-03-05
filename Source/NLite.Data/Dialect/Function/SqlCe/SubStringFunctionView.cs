﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace NLite.Data.Dialect.Function.SqlCe
{
    class SubStringFunctionView : IFunctionView
    {
        public void Render(ISqlBuilder builder, params Expression[] args)
        {
            if (args.Length != 3 && args.Length != 2)
                throw new NotSupportedException(string.Format(Res.ArgumentCountError, "substring", "", "2 or 3"));

            builder.Append("SUBSTRING(");
            builder.Visit(args[0]);
            builder.Append(",");
            builder.Visit(args[1]);
            if (args.Length == 2)
            {
                builder.Append(",LEN(");
                builder.Visit(args[0]);
                builder.Append("))");
            }
            else
            {
                builder.Append(",");
                builder.Visit(args[2]);
                builder.Append(")");
            }

        }
    }
}
