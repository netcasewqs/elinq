using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using NLite.Data.Dialect.SqlBuilder;

namespace NLite.Data.Dialect.Function.Access
{
    class ToTimeFunctionView : IFunctionView
    {
        public void Render(ISqlBuilder builder, params Expression[] args)
        {

        }
    }
}
