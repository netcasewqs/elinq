using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace NLite.Data.Dialect.Function.SQLite
{
    class LeftFunctionView : IFunctionView
    {

        public void Render(ISqlBuilder ctx, params Expression[] args)
        {
            if (args == null)
                throw new NotSupportedException("args");
            if (args.Length != 2)
                throw new NotSupportedException(string.Format(Res.ArgumentCountError, "left", "", "2"));

            ctx.Append("SUBSTR(");
            ctx.Visit(args[0]);
            ctx.Append(",1,(CHARINDEX(");
            ctx.Visit(args[1]);
            ctx.Append(",");
            ctx.Visit(args[0]);
            ctx.Append(")-1))");
        }
    }
}
