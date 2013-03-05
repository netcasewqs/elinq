using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Linq.Expressions;
using NLite.Data.Linq.Expressions;
using NLite.Data.Dialect.Function;
using NLite.Data.Dialect.SqlBuilder;
using System.Data.SqlClient;

namespace NLite.Data.Dialect
{
    partial class MsSql2005Dialect : MsSql2000Dialect
    {
        public override bool SupportSchema
        {
            get
            {
                return true;
            }
        }
            
    }
}
