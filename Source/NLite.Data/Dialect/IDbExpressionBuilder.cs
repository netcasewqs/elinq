using System;
using System.Linq.Expressions;
using NLite.Data.Linq.Expressions;
using System.Collections.Generic;
using NLite.Data.Mapping;
using NLite.Data.Linq;
using System.Reflection;
namespace NLite.Data.Dialect
{
    public interface IDbExpressionBuilder
    {
        ProjectionExpression AddOuterJoinTest(ProjectionExpression proj);

        Expression BuildEntityExpression(IEntityMapping mapping, IList<EntityAssignment> assignments);
        IEnumerable<EntityAssignment> GetAssignments(Expression newOrMemberInit);
        Expression GetDeleteExpression(IEntityMapping mapping, Expression instance, LambdaExpression deleteCheck);
        EntityExpression GetEntityExpression(Expression root, IEntityMapping mapping);
        Expression GetGeneratedIdExpression(IMemberMapping member);
        Expression GetInsertExpression(IEntityMapping mapping, Expression instance, LambdaExpression selector);
        Expression GetInsertResult(IEntityMapping mapping, Expression instance, LambdaExpression selector, Dictionary<MemberInfo, Expression> map);
        Expression GetMemberExpression(Expression root, IEntityMapping entity, IMemberMapping mm);
        Expression GetMemberExpression(Expression root, IEntityMapping entity, MemberInfo member);
        Expression GetPrimaryKeyQuery(IEntityMapping mapping, Expression source, Expression[] keys);
        ProjectionExpression GetQueryExpression(IEntityMapping entity);
        Expression GetRowsAffectedExpression(Expression command);
        Expression GetUpdateExpression(IEntityMapping mapping, Expression instance, LambdaExpression updateCheck, LambdaExpression selector, Expression @else);
        bool IsRowsAffectedExpressions(Expression expression);

        Expression Translate(Expression expression);
    }
}
