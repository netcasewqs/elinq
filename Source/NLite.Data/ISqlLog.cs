using NLite.Data.Common;

namespace NLite.Data
{
    public interface ISqlLog
    {
        void LogMessage(string message);
        void LogCommand(string commandText, NamedParameter[] parameters, object[] paramValues);
        void LogParameters(NamedParameter[] parameters, object[] paramValues);
    }
}
