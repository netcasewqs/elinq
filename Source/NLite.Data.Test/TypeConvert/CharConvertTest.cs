using System;
using System.Linq;
using System.Linq.Expressions;
using NLite.Data.Test.Primitive.Model;
using NUnit.Framework;
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestMethod = NUnit.Framework.TestAttribute;

namespace NLite.Data.Test.TypeConvert
{
    [TestClass]
    public class CharConvertTest : TestBase<NullableTypeInfo>
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
            Execute("Char", '0', p => Convert.ToBoolean(p.Char.Value) == false);
#if !Access
            Execute("Char", '1', p => Convert.ToBoolean(p.Char.Value) == true);
#if !MySQL//CAST(t0.`Char` AS UNSIGNED)
#if !Oracle//(CAST(t0."CHAR" AS NUMBER(1,0))=1)
#if !SQLite//(CAST(t0.[Char] AS NUMBER)=1)
            Execute("Char", '2', p => Convert.ToBoolean(p.Char.Value) == true);
#endif
#endif
#endif
#endif
        }
        [TestMethod]
        public virtual void ToSByte()
        {
            Execute("Char", '0', p => Convert.ToSByte(p.Char.Value) == 0);
            Execute("Char", '1', p => Convert.ToSByte(p.Char.Value) == 1);
            Execute("Char", '2', p => Convert.ToSByte(p.Char.Value) == 2);
        }
        [TestMethod]
        public virtual void ToByte()
        {
            Execute("Char", '0', p => Convert.ToByte(p.Char.Value) == 0);
            Execute("Char", '1', p => Convert.ToByte(p.Char.Value) == 1);
            Execute("Char", '2', p => Convert.ToByte(p.Char.Value) == 2);
        }
        [TestMethod]
        public virtual void ToInt16()
        {
            Execute("Char", '0', p => Convert.ToInt16(p.Char.Value) == 0);
            Execute("Char", '1', p => Convert.ToInt16(p.Char.Value) == 1);
            Execute("Char", '2', p => Convert.ToInt16(p.Char.Value) == 2);
        }
        [TestMethod]
        public virtual void ToUInt16()
        {
            Execute("Char", '0', p => Convert.ToUInt16(p.Char.Value) == 0);
            Execute("Char", '1', p => Convert.ToUInt16(p.Char.Value) == 1);
            Execute("Char", '2', p => Convert.ToUInt16(p.Char.Value) == 2);
        }
        [TestMethod]
        public virtual void ToInt32()
        {
            Execute("Char", '0', p => Convert.ToInt32(p.Char.Value) == 0);
            Execute("Char", '1', p => Convert.ToInt32(p.Char.Value) == 1);
            Execute("Char", '2', p => Convert.ToInt32(p.Char.Value) == 2);
        }
        [TestMethod]
        public virtual void ToUInt32()
        {
            Execute("Char", '0', p => Convert.ToUInt32(p.Char.Value) == 0);
            Execute("Char", '1', p => Convert.ToUInt32(p.Char.Value) == 1);
            Execute("Char", '2', p => Convert.ToUInt32(p.Char.Value) == 2);
        }
        [TestMethod]
        public virtual void ToInt64()
        {
            Execute("Char", '0', p => Convert.ToInt64(p.Char.Value) == 0);
            Execute("Char", '1', p => Convert.ToInt64(p.Char.Value) == 1);
            Execute("Char", '2', p => Convert.ToInt64(p.Char.Value) == 2);
        }
        [TestMethod]
        public virtual void ToUInt64()
        {
            Execute("Char", '0', p => Convert.ToUInt64(p.Char.Value) == 0);
            Execute("Char", '1', p => Convert.ToUInt64(p.Char.Value) == 1);
            Execute("Char", '2', p => Convert.ToUInt64(p.Char.Value) == 2);
        }
        [TestMethod]
        public virtual void ToSingle()
        {
            Execute("Char", '0', p => Convert.ToSingle(p.Char.Value) == 0);
            Execute("Char", '1', p => Convert.ToSingle(p.Char.Value) == 1);
            Execute("Char", '2', p => Convert.ToSingle(p.Char.Value) == 2);
        }
        [TestMethod]
#if Oracle//缺失关键字
       // [ExpectedException(typeof(QueryException))]
#endif
        public virtual void ToDouble()
        {
            Execute("Char", '0', p => Convert.ToDouble(p.Char.Value) == 0);
            Execute("Char", '1', p => Convert.ToDouble(p.Char.Value) == 1);
            Execute("Char", '2', p => Convert.ToDouble(p.Char.Value) == 2);
        }
        [TestMethod]
        public virtual void ToDecimal()
        {
            Execute("Char", '0', p => Convert.ToDecimal(p.Char.Value) == 0);
            Execute("Char", '1', p => Convert.ToDecimal(p.Char.Value) == 1);
            Execute("Char", '2', p => Convert.ToDecimal(p.Char.Value) == 2);
        }
        [TestMethod]
        public virtual void ToString()
        {
            Execute("Char", '0', p => Convert.ToString(p.Char.Value) == "0");
            Execute("Char", '1', p => Convert.ToString(p.Char.Value) == "1");
            Execute("Char", '2', p => Convert.ToString(p.Char.Value) == "2");
        }
        [TestMethod]
        public virtual void Parse()
        {
            Execute("Char", '0', p => char.Parse("0") == '0');
        }
    }
}
