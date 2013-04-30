using System.Linq.Expressions;
using NLite.Data.Linq.Expressions;
using NLite.Data.Mapping;

namespace NLite.Data.Dialect.ExpressionBuilder
{
    class FirebirdExpressionBuilder : DbExpressionBuilder
    {
        public override Expression Translate(Expression expression)
        {
            expression = OrderByRewriter.Rewrite(expression);
            expression = base.Translate(expression);
            expression = SkipToRowNumberRewriter.Rewrite(expression);
            expression = OrderByRewriter.Rewrite(expression);
            return expression;
        }

        public override Expression GetGeneratedIdExpression(IMemberMapping member)
        {
            return new FunctionExpression(member.MemberType, "SCOPE_IDENTITY()", null);
        }
    }
}
