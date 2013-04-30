using System;
using System.Linq;
using System.Linq.Expressions;
using NLite.Data.Test.Primitive.Model;
using NUnit.Framework;
using TestMethod = NUnit.Framework.TestAttribute;

namespace NLite.Data.Test.TypeConvert
{
    public class Int16ConvertTest : TestBase<NullableTypeInfo>
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
            Execute("Int16", 0, p => Convert.ToBoolean(p.Int16.Value) == false);
#if !Access
            Execute("Int16", 1, p => Convert.ToBoolean(p.Int16.Value) == true);
#endif
#if SqlServer
            Execute("Int16", -1, p => Convert.ToBoolean(p.Int16.Value) == true);
            Execute("Int16", 2, p => Convert.ToBoolean(p.Int16.Value) == true);
#endif
        }
        [TestMethod]
        public virtual void ToChar()
        {
            Execute("Int16", 0, p => Convert.ToChar(p.Int16.Value) == 0);
            Execute("Int16", 1, p => Convert.ToChar(p.Int16.Value) == 1);
            Execute("Int16", 2, p => Convert.ToChar(p.Int16.Value) == 2);
        }
        [TestMethod]
        public virtual void ToByte()
        {
            Execute("Int16", 0, p => Convert.ToByte(p.Int16.Value) == 0);
            Execute("Int16", 1, p => Convert.ToByte(p.Int16.Value) == 1);
            Execute("Int16", 2, p => Convert.ToByte(p.Int16.Value) == 2);
        }
        [TestMethod]
        public virtual void ToInt32()
        {
            Execute("Int16", 0, p => Convert.ToInt32(p.Int16.Value) == 0);
            Execute("Int16", 1, p => Convert.ToInt32(p.Int16.Value) == 1);
            Execute("Int16", 2, p => Convert.ToInt32(p.Int16.Value) == 2);
        }
        [TestMethod]
        public virtual void ToSByte()
        {
            Execute("Int16", 0, p => Convert.ToSByte(p.Int16.Value) == 0);
            Execute("Int16", 1, p => Convert.ToSByte(p.Int16.Value) == 1);
            Execute("Int16", 2, p => Convert.ToSByte(p.Int16.Value) == 2);
        }
        [TestMethod]
        public virtual void ToUInt16()
        {
            Execute("Int16", 0, p => Convert.ToUInt16(p.Int16.Value) == 0);
            Execute("Int16", 1, p => Convert.ToUInt16(p.Int16.Value) == 1);
            Execute("Int16", 2, p => Convert.ToUInt16(p.Int16.Value) == 2);
        }
        [TestMethod]
        public virtual void ToUInt32()
        {
            Execute("Int16", 0, p => Convert.ToUInt32(p.Int16.Value) == 0);
            Execute("Int16", 1, p => Convert.ToUInt32(p.Int16.Value) == 1);
            Execute("Int16", 2, p => Convert.ToUInt32(p.Int16.Value) == 2);
        }
        [TestMethod]
        public virtual void ToInt64()
        {
            Execute("Int16", 0, p => Convert.ToInt64(p.Int16.Value) == 0);
            Execute("Int16", 1, p => Convert.ToInt64(p.Int16.Value) == 1);
            Execute("Int16", 2, p => Convert.ToInt64(p.Int16.Value) == 2);
        }
        [TestMethod]
        public virtual void ToUInt64()
        {
            Execute("Int16", 0, p => Convert.ToUInt64(p.Int16.Value) == 0);
            Execute("Int16", 1, p => Convert.ToUInt64(p.Int16.Value) == 1);
            Execute("Int16", 2, p => Convert.ToUInt64(p.Int16.Value) == 2);
        }
        [TestMethod]
        public virtual void ToSingle()
        {
            Execute("Int16", 0, p => Convert.ToSingle(p.Int16.Value) == 0);
            Execute("Int16", 1, p => Convert.ToSingle(p.Int16.Value) == 1);
            Execute("Int16", 2, p => Convert.ToSingle(p.Int16.Value) == 2);
        }
        [TestMethod]
        public virtual void ToDouble()
        {
            Execute("Int16", 0, p => Convert.ToDouble(p.Int16.Value) == 0);
            Execute("Int16", 1, p => Convert.ToDouble(p.Int16.Value) == 1);
            Execute("Int16", 2, p => Convert.ToDouble(p.Int16.Value) == 2);
        }
        [TestMethod]
        public virtual void ToDecimal()
        {
            Execute("Int16", 0, p => Convert.ToDecimal(p.Int16.Value) == 0);
            Execute("Int16", 1, p => Convert.ToDecimal(p.Int16.Value) == 1);
            Execute("Int16", 2, p => Convert.ToDecimal(p.Int16.Value) == 2);
        }
        [TestMethod]
        public virtual void ToSString()
        {
            Execute("Int16", 0, p => Convert.ToString(p.Int16.Value) == "0");
            Execute("Int16", 1, p => Convert.ToString(p.Int16.Value) == "1");
            Execute("Int16", 2, p => Convert.ToString(p.Int16.Value) == "2");
        }
        [TestMethod]
        public virtual void Parse()
        {
            Execute("Int16", 0, p => int.Parse("0") == 0);
        }
    }
}
