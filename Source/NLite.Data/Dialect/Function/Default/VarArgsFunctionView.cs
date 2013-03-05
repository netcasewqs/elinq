using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using NLite.Data.Dialect.SqlBuilder;

namespace NLite.Data.Dialect.Function.Default
{
    class VarArgsFunctionView : IFunctionView
    {
        private readonly string begin;
        private readonly string sep;
        private readonly string end;

        public VarArgsFunctionView(string begin, string sep, string end)
        {
            this.begin = begin;
            this.sep = sep;
            this.end = end;
        }

        public void Render(ISqlBuilder builder, params Expression[] args)
        {
            builder.Append(begin);
            builder.VisitEnumerable(args, sep);
            builder.Append(end);
        }

    }
}
