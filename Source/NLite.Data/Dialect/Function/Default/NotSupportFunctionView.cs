using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using NLite.Data.Dialect.SqlBuilder;

namespace NLite.Data.Dialect.Function.Default
{
    class NotSupportFunctionView : IFunctionView
    {
        private string FunctionName;
        public NotSupportFunctionView(string name)
        {
            FunctionName = name;
        }
        public void Render(ISqlBuilder builder, params Expression[] args)
        {
            throw new NotSupportedException(string.Format(Res.NotSupported, FunctionName, "function"));
        }
    }
}
