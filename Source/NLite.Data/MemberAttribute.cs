using System;

namespace NLite.Data
{
    public abstract class MemberAttribute : Attribute
    {
        /// <summary>
        /// Gets or sets a private storage field to hold the value from a column.
        /// </summary>
        internal string Storage { get; set; }
    }
}
