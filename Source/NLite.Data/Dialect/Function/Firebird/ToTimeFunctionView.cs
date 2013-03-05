using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLite.Data.Dialect.SqlBuilder;
using System.Linq.Expressions;

namespace NLite.Data.Dialect.Function.Firebird
{
    class ToTimeFunctionView : IFunctionView
    {

        public void Render(ISqlBuilder builder, params Expression[] args)
        {

        }
    }
}
