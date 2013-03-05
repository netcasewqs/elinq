using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NLite.Data.Schema
{
    /// <summary>
    /// 外键Schema
    /// </summary>
    public interface IForeignKeySchema : IRelationSchema
    {
        /// <summary>
        /// 外键名称
        /// </summary>
        string Name { get; }
       

    }
}
