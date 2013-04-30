using System.Linq.Expressions;

namespace NLite.Data.Dialect
{
    public interface IFunctionView
    {
        void Render(ISqlBuilder builder, params Expression[] args);
    }
}
