using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using NLite.Data.Mapping;
using NLite.Data.Linq.Expressions;

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
