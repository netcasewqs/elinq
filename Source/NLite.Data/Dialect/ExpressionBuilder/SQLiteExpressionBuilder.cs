using System.Linq.Expressions;
using NLite.Data.Linq.Expressions;
using NLite.Data.Mapping;

namespace NLite.Data.Dialect.ExpressionBuilder
{
    class SQLiteExpressionBuilder : DbExpressionBuilder
    {
        public override Expression Translate(Expression expression)
        {
            expression = OrderByRewriter.Rewrite(expression);
            expression = base.Translate(expression);
            expression = UnusedColumnRemover.Remove(expression);
            return expression;
        }

        public override Expression GetGeneratedIdExpression(IMemberMapping member)
        {
            return new FunctionExpression(member.MemberType, "last_insert_rowid()", null);
        }

        public override Expression GetRowsAffectedExpression(Expression command)
        {
            return new FunctionExpression(typeof(int), "changes()", null);
        }

        public override bool IsRowsAffectedExpressions(Expression expression)
        {
            FunctionExpression fex = expression as FunctionExpression;
            return fex != null && fex.Name == "changes()";
        }
    }
}
