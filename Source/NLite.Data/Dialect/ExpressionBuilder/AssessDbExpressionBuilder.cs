using System.Linq.Expressions;
using NLite.Data.Linq.Expressions;
using NLite.Data.Mapping;

namespace NLite.Data.Dialect.ExpressionBuilder
{
    class AssessDbExpressionBuilder : DbExpressionBuilder
    {
        public override Expression Translate(Expression expression)
        {
            // fix up any order-by's
            expression = OrderByRewriter.Rewrite(expression);

            expression = base.Translate(expression);

            expression = CrossJoinIsolator.Isolate(expression);
            expression = ThreeTopPagerRewriter.Rewrite(expression);
            expression = OrderByRewriter.Rewrite(expression);
            expression = UnusedColumnRemover.Remove(expression);

            return expression;
        }

        public override Expression GetGeneratedIdExpression(IMemberMapping member)
        {
            return new FunctionExpression(member.MemberType, "@@IDENTITY", null);
        }
    }
}
