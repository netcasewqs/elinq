using NLite.Data.Linq.Expressions;

namespace NLite.Data.Common
{
    /// <summary>
    /// 操作类型
    /// </summary>
    public enum OperationType
    {
        Insert = DbExpressionType.Insert,
        Delete = DbExpressionType.Delete,
        Update = DbExpressionType.Update,
        Select = DbExpressionType.Select,
    }
}
