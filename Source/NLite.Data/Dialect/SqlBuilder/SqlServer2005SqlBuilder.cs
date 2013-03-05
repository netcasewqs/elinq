using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using NLite.Data.Linq.Expressions;

namespace NLite.Data.Dialect.SqlBuilder
{
    class SqlServer2005SqlBuilder : MsSql2000SqlBuilder
    {
        protected override Expression VisitRowNumber(RowNumberExpression rowNumber)
        {
            this.Append("ROW_NUMBER() OVER(");
            if (rowNumber.OrderBy != null && rowNumber.OrderBy.Count > 0)
            {
                this.Append("ORDER BY ");
                for (int i = 0, n = rowNumber.OrderBy.Count; i < n; i++)
                {
                    OrderExpression exp = rowNumber.OrderBy[i];
                    if (i > 0)
                    {
                        this.Append(", ");
                    }
                    this.VisitValue(exp.Expression);
                    if (exp.OrderType != OrderType.Ascending)
                    {
                        this.Append(" DESC");
                    }
                }
            }
            this.Append(")");
            return rowNumber;
        }

    }

     
}
