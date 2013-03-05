using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NLite.Data
{
    /// <summary>
    /// 数据库表标签
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false)]
    public class TableAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        public TableAttribute() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public TableAttribute(string name)
        {
            Name = name;
        }

        /// <summary>
        /// 得到或设置数据库表的Schema
        /// </summary>
        public string Schema { get; set; }
        /// <summary>
        /// 得到或设置表名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 得到或设置表是否是只读的
        /// </summary>
        public bool Readonly { get; set; }
    }
}
