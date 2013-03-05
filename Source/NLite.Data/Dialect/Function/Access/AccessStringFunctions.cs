using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NLite.Data.Dialect.Function.Access
{
    class AccessStringFunctions : IStringFunctions
    {
        public IFunctionView Like
        {
            get { return FunctionView.Like; }
        }
        public IFunctionView Concat
        {
            get { return FunctionView.VarArgs("(", "+", ")"); }
        }

        public IFunctionView IndexOf
        {
            get { return new IndexOfFunctionView(); }
        }

        public IFunctionView Insert
        {
            get { return new InsertFunctionView(); }
        }

        public IFunctionView LastIndexOf
        {
            get { return new LastIndexOfFunction(); }
        }

        public IFunctionView LeftOf
        {
            get { return new LeftFunctionView(); }
        }

        public IFunctionView Length
        {
            get { return FunctionView.Standard("len"); }
        }

        public IFunctionView PadLeft
        {
            get { return new PadLeftFunctionView(); }
        }

        public IFunctionView PadRight
        {
            get { return new PadRightFunctionView(); }
        }

        public IFunctionView Remove
        {
            get { return new RemoveFunctionView(); }
        }

        public IFunctionView Replace
        {
            get { return FunctionView.StandardSafe("replace", 3); }
        }

        public IFunctionView Reverse
        {
            get { return FunctionView.Standard("strReverse"); }
        }

        public IFunctionView RightOf
        {
            get { return new RightFunctionView(); }
        }

        public IFunctionView Substring
        {
            get { return FunctionView.Standard("mid"); }
        }

        public IFunctionView ToLower
        {
            get { return FunctionView.Standard("lcase"); }
        }

        public IFunctionView ToUpper
        {
            get { return FunctionView.Standard("ucase"); }
        }

        public IFunctionView Trim
        {
            get { return FunctionView.LRTrim; }
        }

        public IFunctionView TrimEnd
        {
            get { return FunctionView.TrimEnd; }
        }

        public IFunctionView TrimStart
        {
            get { return FunctionView.TrimStart; }
        }

        public IFunctionView IsNullOrWhiteSpace
        {
            get { return FunctionView.IsNullOrWhiteSpace; }
        }

        public IFunctionView IsNullOrEmpty
        {
            get { return FunctionView.IsNullOrEmpty; }
        }
    }
}
