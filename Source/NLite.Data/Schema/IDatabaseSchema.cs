
namespace NLite.Data.Schema
{
    public interface IDatabaseSchema
    {
        ITableSchema[] Tables { get; }
        ITableSchema[] Views { get; }
    }
}
