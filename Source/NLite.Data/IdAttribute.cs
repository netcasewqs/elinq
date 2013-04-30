using System;

namespace NLite.Data
{
    /// <summary>
    /// 主键标签
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class IdAttribute : ColumnAttribute
    {
        public IdAttribute() { }

        public IdAttribute(string name) : base(name) { }
        /// <summary>
        /// 得到或设置数据表的主键是否为自增的
        /// </summary>
        public bool IsDbGenerated { get; set; }
        /// <summary>
        /// 得到或设置序列名称
        /// </summary>
        public string SequenceName { get; set; }
    }
}
