using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using NLite.Data.Dialect.SqlBuilder;

namespace NLite.Data.Dialect.Function.Default
{
    class StandardFunctionView : IFunctionView
    {
        protected readonly string name;
        public StandardFunctionView(string name)
        {
            this.name = name.ToUpper();
        }

        public virtual void Render(ISqlBuilder builder, params Expression[] args)
        {
            builder.Append(name);
            builder.Append("(");
            builder.VisitEnumerable(args);
            builder.Append(")");
        }

        public override string ToString()
        {
            return name;
        }
    }
}
