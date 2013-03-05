using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NLite.Data.Dialect.Function.Oracle
{
    class OracleDecimalFunctions : IDecimalFunctions
    {
        public IFunctionView Remainder
        {
            get { return FunctionView.Standard("MOD"); }
        }

       
    }
}
