using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using NLite.Data.Dialect.SqlBuilder;

namespace NLite.Data.Dialect.Function.Default
{
    class ProxyFunctionView : IFunctionView
    {
        Action<ISqlBuilder, Expression[]> proxy;

        public ProxyFunctionView(Action<ISqlBuilder, Expression[]> proxy)
        {
            if (proxy == null)
                throw new ArgumentNullException("proxy");
            this.proxy = proxy;
        }

        public void Render(ISqlBuilder builder, params Expression[] args)
        {
            proxy(builder, args);
        }
    }
}
