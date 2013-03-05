using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Collections.ObjectModel;

namespace NLite.Data.Linq
{
    public class ConstructorBindResult
    {
        public NewExpression Expression { get; private set; }
        public EntityAssignment[] Remaining { get; private set; }
        public ConstructorBindResult(NewExpression expression, IEnumerable<EntityAssignment> remaining)
        {
            this.Expression = expression;
            this.Remaining = remaining.ToArray();
        }
    }
}
