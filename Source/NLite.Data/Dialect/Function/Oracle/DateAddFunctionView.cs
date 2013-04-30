using System;
using System.Linq.Expressions;
using NLite.Data.Common;

namespace NLite.Data.Dialect.Function.Oracle
{
    class DateAddFunctionView : IFunctionView
    {
        readonly DateParts Type;
        public DateAddFunctionView(DateParts type)
        {
            Type = type;
        }

        public void Render(ISqlBuilder visitor, params Expression[] args)
        {
            if (args.Length != 2)
                throw new ArgumentException("function ' dateadd takes 2 arguments.");

            visitor.Append("(");
            visitor.Visit(args[0]);
            visitor.Append(" + interval '");
            ExecuteContext.Items.Add(OracleDateTimeFunctions.IgonreIntDoubleConvert, null);
            visitor.Visit(args[1]);
            ExecuteContext.Items.Remove(OracleDateTimeFunctions.IgonreIntDoubleConvert);

            visitor.Append("' " + Type.ToString() + ")");
        }
    }
}
