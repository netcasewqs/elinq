
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
