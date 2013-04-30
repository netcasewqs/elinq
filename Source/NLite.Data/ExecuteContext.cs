using System;
using System.Collections.Generic;
using NLite.Data.Dialect;

namespace NLite.Data
{
    class ExecuteContext
    {
        [ThreadStatic]
        public static Dictionary<string, object> Items;

        [ThreadStatic]
        public static IDialect Dialect;

        [ThreadStatic]
        public static InternalDbContext DbContext;
    }
}
