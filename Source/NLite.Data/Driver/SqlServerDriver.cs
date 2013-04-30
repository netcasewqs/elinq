using System.Data;
using System.Data.SqlClient;

namespace NLite.Data.Driver
{
    class SqlServerDriver : AbstractDriver
    {
        protected override void ConvertDBTypeToNativeType(IDbDataParameter p, DBType dbType)
        {
            (p as SqlParameter).SqlDbType = (SqlDbType)(int)dbType;
        }

    }
}
