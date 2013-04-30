using System;
using System.Linq;
using System.Linq.Expressions;
using NLite.Data.Test.Primitive.Model;
using NUnit.Framework;
using TestClass = NUnit.Framework.TestFixtureAttribute;

namespace NLite.Data.Test.Where
{
    [TestClass]
    public class NumbericTest : TestBase<NullableTypeInfo>
    {
        public virtual void Execute(string fieldName, object value, Expression<Func<NullableTypeInfo, bool>> filter)
        {
            var identityFieldValue = "zxmlx";
            var expected = new NullableTypeInfo { String = identityFieldValue };
            var field = typeof(NullableTypeInfo).GetField(fieldName);
            Assert.IsNotNull(field);
            field
                .SetValue(expected, PrimitiveMapper.Map(value, field.FieldType));

            //if (base.Db.Dialect is NLite.Data.Dialect.SQLiteDialect)
            //{
            //    base.Db.Connection.BeginTransaction();
            //}
            Table.Delete(p => true);
            Table.Insert(expected);

            var actual = Table
                .Where(p => p.String == expected.String)
                .Where(filter)
                .Select(p => new { Id = p.Id, p.String })
                .FirstOrDefault();

            Assert.IsNotNull(actual);

            Table.Delete(p => true);
        }
        public virtual void ExecuteNull(string fieldName, object value, Expression<Func<NullableTypeInfo, bool>> filter)
        {
            var identityFieldValue = "zxmlx";
            var expected = new NullableTypeInfo { String = identityFieldValue };
            var field = typeof(NullableTypeInfo).GetField(fieldName);
            Assert.IsNotNull(field);
            field
                .SetValue(expected, PrimitiveMapper.Map(value, field.FieldType));

            Table.Delete(p => true);
            Table.Insert(expected);

            var actual = Table
                .Where(p => p.String == expected.String)
                .Where(filter)
                .Select(p => new { Id = p.Id, p.String })
                .FirstOrDefault();

            Assert.IsNull(actual);
            Table.Delete(p => true);
        }

    }
}
