using System;
using NLite.Data.Linq.Expressions;
using System.Data.Common;
using NLite.Data.Common;
using System.Linq.Expressions;
using NLite.Data.Dialect.ExpressionBuilder;
using NLite.Data.Dialect.Function;
namespace NLite.Data.Dialect
{
    public interface IDialect
    {
        bool SupportMultipleCommands { get; }
        bool SupportDistinctInAggregates { get; }
        bool SupportSubqueryInSelectWithoutFrom { get; }
        char OpenQuote { get; }
        char CloseQuote { get; }
        string Quote(string name);
        bool SupportDelete { get; }
        bool SupportInsert { get; }
        bool SupportSchema { get; }
        bool SupportSelect { get; }
        bool SupportUpdate { get; }
    }
}
