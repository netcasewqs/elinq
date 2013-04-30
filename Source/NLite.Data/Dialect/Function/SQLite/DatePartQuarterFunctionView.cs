using System.Linq.Expressions;

namespace NLite.Data.Dialect.Function.SQLite
{
    class DatePartQuarterFunctionView : IFunctionView
    {

        public void Render(ISqlBuilder builder, params Expression[] args)
        {
            builder.Append("((CAST(strftime('%m', orderdate) AS INT) - 1)/3 + 1)");
        }
    }
}
