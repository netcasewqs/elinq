using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;

namespace NLite.Data.Schema
{
    /// <summary>
    /// Schema 加载器接口
    /// </summary>
    public interface ISchemaLoader
    {
        /// <summary>
        /// 加载Schema
        /// </summary>
        /// <param name="cfg"></param>
        /// <returns></returns>
        IDatabaseSchema Load(DbConfiguration cfg);
    }
}
