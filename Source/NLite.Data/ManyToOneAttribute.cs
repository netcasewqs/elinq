using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NLite.Data
{
    /// <summary>
    /// 多对一
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class ManyToOneAttribute : AbstractAssociationAttribute
    {
        public ManyToOneAttribute()
        {
            isForeignKey = true;
        }
    }
}
