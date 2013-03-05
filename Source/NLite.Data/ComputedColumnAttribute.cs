using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NLite.Data
{
    /// <summary>
    /// 计算列标签，计算列不允许更新
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    class ComputedColumnAttribute : ColumnAttribute
    {
    }
}
