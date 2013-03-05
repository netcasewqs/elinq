using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLite.Data.Schema;

namespace NLite.Data.CodeGeneration
{
    /// <summary>
    /// 创建实体的元数据类
    /// </summary>
    public interface IEntityModel
    {
        /// <summary>
        /// 类名
        /// </summary>
        string ClassName { get; }

        /// <summary>
        /// 
        /// </summary>
        string QueryableName { get; }
        /// <summary>
        /// Table元数据
        /// </summary>
        ITableSchema Table { get; }
        /// <summary>
        /// 主键成员集合
        /// </summary>
        IMemberModel[] PrimaryKeys { get; }
        /// <summary>
        /// 成员集合
        /// </summary>
        IMemberModel[] Members { get; }

        /// <summary>
        /// ManyToOne 成员集合
        /// </summary>
        INavigationMemberModel[] ManyToOnes { get; }

        /// <summary>
        /// OneToMany 成员集合
        /// </summary>
        INavigationMemberModel[] OneToMany { get; }
    }
}
