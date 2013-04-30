using System;

namespace NLite.Data
{
    /// <summary>
    /// 一对一
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class OneToOneAttribute : AbstractAssociationAttribute
    {

    }
}
