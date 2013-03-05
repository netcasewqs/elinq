using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using NLite.Data.Dialect.SqlBuilder;
using NLite.Data.Common;

namespace NLite.Data.Dialect.Function.Oracle
{
    class OracleFunctionRegistry : FunctionRegistry
    {
        public OracleFunctionRegistry()
        {
            SqlFunctions.Add(FunctionType.Case, FunctionView.Case);
            //SqlFunctions.Add(FunctionType.ToString, FunctionViews.VarArgs("CONVERT(NVARCHAR,", ",", ")"));
            SqlFunctions.Add(FunctionType.Compare, FunctionView.Compare);
            SqlFunctions.Add(FunctionType.ToChar, FunctionView.Standard("to_char"));
            SqlFunctions.Add(FunctionType.NewGuid, FunctionView.Standard("Sys_Guid"));
            SqlFunctions.Add(FunctionType.Length, FunctionView.Standard("Length"));

        }
        private IDateTimeFunctions dateTimeFunctions = new OracleDateTimeFunctions();
        protected override IDateTimeFunctions DateTime
        {
            get { return dateTimeFunctions; }
        }

        private IDecimalFunctions decimalFunctions = new OracleDecimalFunctions();
        protected override IDecimalFunctions Decimal
        {
            get { return decimalFunctions; }
        }

        private IMathFunctions mathFunctions = new OracleMathFunctions();
        protected override IMathFunctions Math
        {
            get { return mathFunctions; }
        }

        private IStringFunctions stringFunctions = new OracleStringFunctions();
        protected override IStringFunctions String
        {
            get { return stringFunctions; }
        }
    }
    
    class ToTimeFunctionView : IFunctionView
    {
        public void Render(ISqlBuilder builder, params Expression[] args)
        {

        }
    }
}
