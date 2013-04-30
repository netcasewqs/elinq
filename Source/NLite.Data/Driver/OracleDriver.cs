
namespace NLite.Data.Driver
{
    class OracleDriver : AbstractDriver
    {

        public override char NamedPrefix
        {
            get { return ':'; }
        }

    }
}
