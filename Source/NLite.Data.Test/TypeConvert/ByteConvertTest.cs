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
    public class ByteConvertTest:TestBase<NullableTypeInfo>
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
        [TestMethod]
        public virtual void ToBoolean()
        {
            Execute("Byte", 0, p => Convert.ToBoolean(p.Byte.Value) == false);
#if !Access
            Execute("Byte", 1, p => Convert.ToBoolean(p.Byte.Value) == true);
#if !MySQL//CAST(t0.`Char` AS UNSIGNED)
#if !Oracle//(CAST(t0."CHAR" AS NUMBER(1,0))=1)
#if !SQLite//(CAST(t0.[Char] AS NUMBER)=1)
            Execute("Byte", 2, p => Convert.ToBoolean(p.Byte.Value) == true);
#endif
#endif
#endif
#endif
        }
        [TestMethod]
        public virtual void ToChar()
        {
            Execute("Byte", 0, p => Convert.ToChar(p.Byte.Value) == 0);
            Execute("Byte", 1, p => Convert.ToChar(p.Byte.Value) == 1);
            Execute("Byte", 2, p => Convert.ToChar(p.Byte.Value) == 2);
        }
        [TestMethod]
        public virtual void ToSByte()
        {
            Execute("Byte", 0, p => Convert.ToSByte(p.Byte.Value) == 0);
            Execute("Byte", 1, p => Convert.ToSByte(p.Byte.Value) == 1);
            Execute("Byte", 2, p => Convert.ToSByte(p.Byte.Value) == 2);
        }
        [TestMethod]
        public virtual void ToInt16()
        {
            Execute("Byte", 0, p => Convert.ToInt16(p.Byte.Value) == 0);
            Execute("Byte", 1, p => Convert.ToInt16(p.Byte.Value) == 1);
            Execute("Byte", 2, p => Convert.ToInt16(p.Byte.Value) == 2);
        }
        [TestMethod]
        public virtual void ToUInt16()
        {
            Execute("Byte", 0, p => Convert.ToUInt16(p.Byte.Value) == 0);
            Execute("Byte", 1, p => Convert.ToUInt16(p.Byte.Value) == 1);
            Execute("Byte", 2, p => Convert.ToUInt16(p.Byte.Value) == 2);
        }
        [TestMethod]
        public virtual void ToInt32()
        {
            Execute("Byte", 0, p => Convert.ToInt32(p.Byte.Value) == 0);
            Execute("Byte", 1, p => Convert.ToInt32(p.Byte.Value) == 1);
            Execute("Byte", 2, p => Convert.ToInt32(p.Byte.Value) == 2);
        }
        [TestMethod]
        public virtual void ToUInt32()
        {
            Execute("Byte", 0, p => Convert.ToUInt32(p.Byte.Value) == 0);
            Execute("Byte", 1, p => Convert.ToUInt32(p.Byte.Value) == 1);
            Execute("Byte", 2, p => Convert.ToUInt32(p.Byte.Value) == 2);
        }
        [TestMethod]
        public virtual void ToInt64()
        {
            Execute("Byte", 0, p => Convert.ToInt64(p.Byte.Value) == 0);
            Execute("Byte", 1, p => Convert.ToInt64(p.Byte.Value) == 1);
            Execute("Byte", 2, p => Convert.ToInt64(p.Byte.Value) == 2);
        }
        [TestMethod]
        public virtual void ToUInt64()
        {
            Execute("Byte", 0, p => Convert.ToUInt64(p.Byte.Value) == 0);
            Execute("Byte", 1, p => Convert.ToUInt64(p.Byte.Value) == 1);
            Execute("Byte", 2, p => Convert.ToUInt64(p.Byte.Value) == 2);
        }
        [TestMethod]
        public virtual void ToSingle()
        {
            Execute("Byte", 0, p => Convert.ToSingle(p.Byte.Value) == 0);
            Execute("Byte", 1, p => Convert.ToSingle(p.Byte.Value) == 1);
            Execute("Byte", 2, p => Convert.ToSingle(p.Byte.Value) == 2);
        }
        [TestMethod]
        public virtual void ToDouble()
        {
            Execute("Byte", 0, p => Convert.ToDouble(p.Byte.Value) == 0);
            Execute("Byte", 1, p => Convert.ToDouble(p.Byte.Value) == 1);
            Execute("Byte", 2, p => Convert.ToDouble(p.Byte.Value) == 2);
        }
        [TestMethod]
        public virtual void ToDecimal()
        {
            Execute("Byte", 0, p => Convert.ToDecimal(p.Byte.Value) == 0);
            Execute("Byte", 1, p => Convert.ToDecimal(p.Byte.Value) == 1);
            Execute("Byte", 2, p => Convert.ToDecimal(p.Byte.Value) == 2);
        }
        [TestMethod]
        public virtual void ToSString()
        {
            Execute("Byte", 0, p => Convert.ToString(p.Byte.Value) == "0");
            Execute("Byte", 1, p => Convert.ToString(p.Byte.Value) == "1");
            Execute("Byte", 2, p => Convert.ToString(p.Byte.Value) == "2");
        }
        [TestMethod]
        public virtual void Parse()
        {
            Execute("Byte", 0, p => Byte.Parse("0") == 0);
        }
    }
}
