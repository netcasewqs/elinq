
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
