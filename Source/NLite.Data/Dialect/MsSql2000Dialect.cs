

namespace NLite.Data.Dialect
{
    partial class MsSql2000Dialect : Dialect
    {
        public override bool SupportMultipleCommands
        {
            get { return true; }
        }

        public override bool SupportSubqueryInSelectWithoutFrom
        {
            get { return true; }
        }

        public override bool SupportDistinctInAggregates
        {
            get { return true; }
        }







    }
}
