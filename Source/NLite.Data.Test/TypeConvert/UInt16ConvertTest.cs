using System;
using System.Linq;
using System.Linq.Expressions;
using NLite.Data.Test.Primitive.Model;
using NUnit.Framework;
using TestMethod = NUnit.Framework.TestAttribute;

namespace NLite.Data.Test.TypeConvert
{
    public class UInt16ConvertTest : TestBase<NullableTypeInfo>
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
            Execute("UInt16", 0, p => Convert.ToBoolean(p.UInt16.Value) == false);
#if !Access
            Execute("UInt16", 1, p => Convert.ToBoolean(p.UInt16.Value) == true);
#endif
#if SqlServer
            Execute("UInt16", 2, p => Convert.ToBoolean(p.UInt16.Value) == true);
#endif
        }
        [TestMethod]
        public virtual void ToChar()
        {
            Execute("UInt16", 0, p => Convert.ToChar(p.UInt16.Value) == 0);
            Execute("UInt16", 1, p => Convert.ToChar(p.UInt16.Value) == 1);
            Execute("UInt16", 2, p => Convert.ToChar(p.UInt16.Value) == 2);
        }
        [TestMethod]
        public virtual void ToByte()
        {
            Execute("UInt16", 0, p => Convert.ToByte(p.UInt16.Value) == 0);
            Execute("UInt16", 1, p => Convert.ToByte(p.UInt16.Value) == 1);
            Execute("UInt16", 2, p => Convert.ToByte(p.UInt16.Value) == 2);
        }
        [TestMethod]
        public virtual void ToSByte()
        {
            Execute("UInt16", 0, p => Convert.ToSByte(p.UInt16.Value) == 0);
            Execute("UInt16", 1, p => Convert.ToSByte(p.UInt16.Value) == 1);
            Execute("UInt16", 2, p => Convert.ToSByte(p.UInt16.Value) == 2);
        }
        [TestMethod]
        public virtual void ToInt32()
        {
            Execute("UInt16", 0, p => Convert.ToInt32(p.UInt16.Value) == 0);
            Execute("UInt16", 1, p => Convert.ToInt32(p.UInt16.Value) == 1);
            Execute("UInt16", 2, p => Convert.ToInt32(p.UInt16.Value) == 2);
        }
        [TestMethod]
        public virtual void ToInt16()
        {
            Execute("UInt16", 0, p => Convert.ToInt16(p.UInt16.Value) == 0);
            Execute("UInt16", 1, p => Convert.ToInt16(p.UInt16.Value) == 1);
            Execute("UInt16", 2, p => Convert.ToInt16(p.UInt16.Value) == 2);
        }
        [TestMethod]
        public virtual void ToUInt32()
        {
            Execute("UInt16", 0, p => Convert.ToUInt32(p.UInt16.Value) == 0);
            Execute("UInt16", 1, p => Convert.ToUInt32(p.UInt16.Value) == 1);
            Execute("UInt16", 2, p => Convert.ToUInt32(p.UInt16.Value) == 2);
        }
        [TestMethod]
        public virtual void ToInt64()
        {
            Execute("UInt16", 0, p => Convert.ToInt64(p.UInt16.Value) == 0);
            Execute("UInt16", 1, p => Convert.ToInt64(p.UInt16.Value) == 1);
            Execute("UInt16", 2, p => Convert.ToInt64(p.UInt16.Value) == 2);
        }
        [TestMethod]
        public virtual void ToUInt64()
        {
            Execute("UInt16", 0, p => Convert.ToUInt64(p.UInt16.Value) == 0);
            Execute("UInt16", 1, p => Convert.ToUInt64(p.UInt16.Value) == 1);
            Execute("UInt16", 2, p => Convert.ToUInt64(p.UInt16.Value) == 2);
        }
        [TestMethod]
        public virtual void ToSingle()
        {
            Execute("UInt16", 0, p => Convert.ToSingle(p.UInt16.Value) == 0);
            Execute("UInt16", 1, p => Convert.ToSingle(p.UInt16.Value) == 1);
            Execute("UInt16", 2, p => Convert.ToSingle(p.UInt16.Value) == 2);
        }
        [TestMethod]
        public virtual void ToDouble()
        {
            Execute("UInt16", 0, p => Convert.ToDouble(p.UInt16.Value) == 0);
            Execute("UInt16", 1, p => Convert.ToDouble(p.UInt16.Value) == 1);
            Execute("UInt16", 2, p => Convert.ToDouble(p.UInt16.Value) == 2);
        }
        [TestMethod]
        public virtual void ToDecimal()
        {
            Execute("UInt16", 0, p => Convert.ToDecimal(p.UInt16.Value) == 0);
            Execute("UInt16", 1, p => Convert.ToDecimal(p.UInt16.Value) == 1);
            Execute("UInt16", 2, p => Convert.ToDecimal(p.UInt16.Value) == 2);
        }
        [TestMethod]
        public virtual void ToSString()
        {
            Execute("UInt16", 0, p => Convert.ToString(p.UInt16.Value) == "0");
            Execute("UInt16", 1, p => Convert.ToString(p.UInt16.Value) == "1");
            Execute("UInt16", 2, p => Convert.ToString(p.UInt16.Value) == "2");
        }
        [TestMethod]
        public virtual void Parse()
        {
            Execute("UInt16", 0, p => int.Parse("0") == 0);
        }
    }
}
