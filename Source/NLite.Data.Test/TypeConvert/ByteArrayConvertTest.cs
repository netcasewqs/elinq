using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestInitialize = NUnit.Framework.SetUpAttribute;
using TestMethod = NUnit.Framework.TestAttribute;
using NLite.Data.Test.Primitive.Model;
using System.Linq.Expressions;
using System.ComponentModel;

namespace NLite.Data.Test.TypeConvert
{
    [TestClass]
    public class ByteArrayConvertTest:TestBase<NullableTypeInfo>
    {
        protected override string ConnectionStringName
        {
            get
            {
                return "NumericDB";
            }
        }

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
        byte[] arr = new byte[]{ 1,0,3,4};
        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public virtual void ToSString()
        {
            Execute("Binary", arr, p => BitConverter.ToString(p.Binary) == BitConverter.ToString(arr));
        }
        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public virtual void PartToBoolean()
        {
            Execute("Binary", arr, p =>BitConverter.ToBoolean(p.Binary,1)==false);
        }
        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public virtual void PartToChar()
        {
            Execute("Binary", arr, p => BitConverter.ToChar(p.Binary,0)==1);
        }
        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public virtual void PartToInt32()
        {
            Execute("Binary", arr, p => BitConverter.ToInt32(p.Binary, 3) == 4);
        }
    }
}
