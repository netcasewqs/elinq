using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLite.Data.Dialect.SqlBuilder;
using System.Linq.Expressions;

namespace NLite.Data.Dialect.Function.MySQL
{
    class PadLeftFunctionView : IFunctionView
    {
        public void Render(ISqlBuilder builder, params Expression[] args)
        {
            if (args == null)
                throw new NotSupportedException("args");
            if (args.Length != 2 && args.Length != 3)
                throw new NotSupportedException(string.Format(Res.ArgumentCountError, "PadLeft", "", "2 or 3"));
            builder.Append("LPAD(");
            builder.Visit(args[0]);
            builder.Append(",");
            builder.Visit(args[1]);
            builder.Append(",");
            if (args.Length == 2)
                builder.Append("' ')");
            else
            {
                builder.Visit(args[2]);
                builder.Append(")");
            }
        }
    }
}
