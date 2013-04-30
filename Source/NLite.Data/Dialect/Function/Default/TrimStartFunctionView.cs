using System.Linq.Expressions;

namespace NLite.Data.Dialect.Function.Default
{
    class TrimStartFunctionView : IFunctionView
    {
        public virtual void Render(ISqlBuilder visitor, params Expression[] args)
        {
            var targetArg = args[0];
            visitor.Append("LTRIM(");
            visitor.Visit(targetArg);
            visitor.Append(")");

        }
    }
}
