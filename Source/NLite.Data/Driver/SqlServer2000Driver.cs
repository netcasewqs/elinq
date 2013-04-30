
namespace NLite.Data.Driver
{
    class SqlServer2000Driver : SqlServerDriver
    {
        public override bool AllowsMultipleOpenReaders
        {
            get
            {
                return false;
            }
        }

    }
}
