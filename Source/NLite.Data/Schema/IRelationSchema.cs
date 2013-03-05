using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NLite.Data.Schema
{
    /// <summary>
    /// 关系Scheam,比如外键关系
    /// </summary>
    public interface IRelationSchema
    {
        /// <summary>
        /// This Table
        /// </summary>
        ITableSchema ThisTable { get; }
        /// <summary>
        /// ThisKey
        /// </summary>
        IColumnSchema ThisKey { get; }

        /// <summary>
        /// OtherTable
        /// </summary>
        ITableSchema OtherTable { get; }

        /// <summary>
        /// OtherKey
        /// </summary>
        IColumnSchema OtherKey { get; }
    }
}
