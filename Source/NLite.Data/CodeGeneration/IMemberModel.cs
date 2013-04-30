using NLite.Data.Schema;

namespace NLite.Data.CodeGeneration
{
    public interface IMemberModel
    {
        string MemberName { get; }
        IColumnSchema Column { get; }
    }
}
