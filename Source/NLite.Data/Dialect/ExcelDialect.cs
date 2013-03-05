using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using NLite.Data.Dialect.SqlBuilder;

namespace NLite.Data.Dialect
{
    class ExcelDialect:AccessDialect
    {
        public override bool SupportDelete
        {
            get
            {
                return false;
            }
        }
        //public override string QuoteTableName(string name)
        //{
        //    return "["+name+"$]";
        //}

        
    }
}
