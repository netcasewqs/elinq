using System;
using System.Linq;
using System.Linq.Expressions;
using NLite.Data.Test.Primitive.Model;
using NUnit.Framework;
using TestMethod = NUnit.Framework.TestAttribute;

namespace NLite.Data.Test.TypeConvert
{
    public class SByteConvertTest : TestBase<NullableTypeInfo>
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
            Execute("SByte", 0, p => Convert.ToBoolean(p.SByte.Value) == false);
#if !Access
            Execute("SByte", 1, p => Convert.ToBoolean(p.SByte.Value) == true);
#endif
#if SqlServer
            Execute("SByte", 2, p => Convert.ToBoolean(p.SByte.Value) == true);
#endif
        }
        [TestMethod]
        public virtual void ToChar()
        {
            Execute("SByte", 0, p => Convert.ToChar(p.SByte.Value) == 0);
            Execute("SByte", 1, p => Convert.ToChar(p.SByte.Value) == 1);
            Execute("SByte", 2, p => Convert.ToChar(p.SByte.Value) == 2);
        }
        [TestMethod]
        public virtual void ToByte()
        {
            Execute("SByte", 0, p => Convert.ToByte(p.SByte.Value) == 0);
            Execute("SByte", 1, p => Convert.ToByte(p.SByte.Value) == 1);
            Execute("SByte", 2, p => Convert.ToByte(p.SByte.Value) == 2);
        }
        [TestMethod]
        public virtual void ToInt32()
        {
            Execute("SByte", 0, p => Convert.ToInt32(p.SByte.Value) == 0);
            Execute("SByte", 1, p => Convert.ToInt32(p.SByte.Value) == 1);
            Execute("SByte", 2, p => Convert.ToInt32(p.SByte.Value) == 2);
        }
        [TestMethod]
        public virtual void ToInt16()
        {
            Execute("SByte", 0, p => Convert.ToInt16(p.SByte.Value) == 0);
            Execute("SByte", 1, p => Convert.ToInt16(p.SByte.Value) == 1);
            Execute("SByte", 2, p => Convert.ToInt16(p.SByte.Value) == 2);
        }
        [TestMethod]
        public virtual void ToUInt16()
        {
            Execute("SByte", 0, p => Convert.ToUInt16(p.SByte.Value) == 0);
            Execute("SByte", 1, p => Convert.ToUInt16(p.SByte.Value) == 1);
            Execute("SByte", 2, p => Convert.ToUInt16(p.SByte.Value) == 2);
        }
        [TestMethod]
        public virtual void ToUInt32()
        {
            Execute("SByte", 0, p => Convert.ToUInt32(p.SByte.Value) == 0);
            Execute("SByte", 1, p => Convert.ToUInt32(p.SByte.Value) == 1);
            Execute("SByte", 2, p => Convert.ToUInt32(p.SByte.Value) == 2);
        }
        [TestMethod]
        public virtual void ToInt64()
        {
            Execute("SByte", 0, p => Convert.ToInt64(p.SByte.Value) == 0);
            Execute("SByte", 1, p => Convert.ToInt64(p.SByte.Value) == 1);
            Execute("SByte", 2, p => Convert.ToInt64(p.SByte.Value) == 2);
        }
        [TestMethod]
        public virtual void ToUInt64()
        {
            Execute("SByte", 0, p => Convert.ToUInt64(p.SByte.Value) == 0);
            Execute("SByte", 1, p => Convert.ToUInt64(p.SByte.Value) == 1);
            Execute("SByte", 2, p => Convert.ToUInt64(p.SByte.Value) == 2);
        }
        [TestMethod]
        public virtual void ToSingle()
        {
            Execute("SByte", 0, p => Convert.ToSingle(p.SByte.Value) == 0);
            Execute("SByte", 1, p => Convert.ToSingle(p.SByte.Value) == 1);
            Execute("SByte", 2, p => Convert.ToSingle(p.SByte.Value) == 2);
        }
        [TestMethod]
        public virtual void ToDouble()
        {
            Execute("SByte", 0, p => Convert.ToDouble(p.SByte.Value) == 0);
            Execute("SByte", 1, p => Convert.ToDouble(p.SByte.Value) == 1);
            Execute("SByte", 2, p => Convert.ToDouble(p.SByte.Value) == 2);
        }
        [TestMethod]
        public virtual void ToDecimal()
        {
            Execute("SByte", 0, p => Convert.ToDecimal(p.SByte.Value) == 0);
            Execute("SByte", 1, p => Convert.ToDecimal(p.SByte.Value) == 1);
            Execute("SByte", 2, p => Convert.ToDecimal(p.SByte.Value) == 2);
        }
        [TestMethod]
        public virtual void ToSString()
        {
            Execute("SByte", 0, p => Convert.ToString(p.SByte.Value) == "0");
            Execute("SByte", 1, p => Convert.ToString(p.SByte.Value) == "1");
            Execute("SByte", 2, p => Convert.ToString(p.SByte.Value) == "2");
        }
        [TestMethod]
        public virtual void Parse()
        {
            Execute("SByte", 0, p => int.Parse("0") == 0);
        }
    }
}
