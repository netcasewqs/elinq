using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NLite.Data.Mapping.Fluent
{
    /// <summary>
    /// Table 映射表达式
    /// </summary>
    public class TableExpression
    {

        internal TableAttribute Attribute;
        internal TableExpression()
        {
            Attribute = new TableAttribute();
        }

        /// <summary>
        /// 设置Table为只读的
        /// </summary>
        /// <returns></returns>
        public TableExpression Readonly()
        {
            Attribute.Readonly = true;
            return this;
        }

        /// <summary>
        /// 设置Table的Schema
        /// </summary>
        /// <param name="schema"></param>
        /// <returns></returns>
        public TableExpression Schema(string schema)
        {
            Guard.NotNullOrEmpty(schema, "schema");
            Attribute.Schema = schema;
            return this;
        }

    }
}
