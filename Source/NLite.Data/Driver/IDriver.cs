using System.Data.Common;
using NLite.Data.Common;

namespace NLite.Data.Driver
{
    public interface IDriver
    {
        char NamedPrefix { get; }
        bool AllowsMultipleOpenReaders { get; }
        void AddParameter(DbCommand command, NamedParameter parameter, object value);
        void AddParameters(DbCommand cmd, object namedParameters);
        DbCommand CreateCommand(DbConnection conn, string sql, object namedParameters);
    }
}
