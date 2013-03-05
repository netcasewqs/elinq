using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLite.Data.Mapping;
using NLite.Data.Dialect;

namespace NLite.Data.Schema.Script
{
    /// <summary>
    /// 数据库脚本生成器接口，提供数据库、表、主键约束、外键约束、检查约束、Uniqule约束等脚本的创建工作
    /// </summary>
    public interface IDatabaseScriptGenerator
    {
        /// <summary>
        /// 生成数据库脚本
        /// </summary>
        /// <param name="dialect">数据库方言</param>
        /// <param name="mappings">映射元数据</param>
        /// <param name="dbName">数据库名称</param>
        /// <returns>返回数据库脚本</returns>
        DatabaseScriptEntry Build(IDialect dialect, IEntityMapping[] mappings,string dbName);

    }
}
