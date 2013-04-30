using System;
using System.Linq;
using System.Linq.Expressions;
using NLite.Data.Test.Primitive.Model;
using NUnit.Framework;
using TestMethod = NUnit.Framework.TestAttribute;
namespace NLite.Data.Test.TypeConvert
{
    public class DoubleConvertTest : TestBase<NullableTypeInfo>
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
            Execute("Double", 0, p => Convert.ToBoolean(p.Double.Value) == false);
#if !Access
            Execute("Double", 1, p => Convert.ToBoolean(p.Double.Value) == true);
#endif
#if SqlServer
            Execute("Double", -1, p => Convert.ToBoolean(p.Double.Value) == true);
            Execute("Double", 2, p => Convert.ToBoolean(p.Double.Value) == true);
#endif
        }
        [TestMethod]
        public virtual void ToChar()
        {
            Execute("Double", 0.23d, p => Convert.ToChar(p.Double.Value) == 0);
            Execute("Double", 1.78, p => Convert.ToChar(p.Double.Value) == 2);
            Execute("Double", 2.20, p => Convert.ToChar(p.Double.Value) == 2);
        }
        [TestMethod]
        public virtual void ToByte()
        {
            Execute("Double", 0.23d, p => Convert.ToByte(p.Double.Value) == 0);
            Execute("Double", 1.78, p => Convert.ToByte(p.Double.Value) == 2);
            Execute("Double", 2.20, p => Convert.ToByte(p.Double.Value) == 2);
        }
        [TestMethod]
        public virtual void ToSByte()
        {
            Execute("Double", 0.23, p => Convert.ToSByte(p.Double.Value) == 0);
            Execute("Double", 1.78, p => Convert.ToSByte(p.Double.Value) == 2);
            Execute("Double", 2.20, p => Convert.ToSByte(p.Double.Value) == 2);
        }
        [TestMethod]
        public virtual void ToInt32()
        {
            Execute("Double", 0.23, p => Convert.ToInt32(p.Double.Value) == 0);
            Execute("Double", 1.78, p => Convert.ToInt32(p.Double.Value) == 2);
            Execute("Double", 2, p => Convert.ToInt32(p.Double.Value) == 2);
        }
        [TestMethod]
        public virtual void ToInt16()
        {
            Execute("Double", 0.23, p => Convert.ToInt16(p.Double.Value) == 0);
            Execute("Double", 1.78, p => Convert.ToInt16(p.Double.Value) == 2);
            Execute("Double", 2, p => Convert.ToInt16(p.Double.Value) == 2);
        }
        [TestMethod]
        public virtual void ToUInt16()
        {
            Execute("Double", 0.23, p => Convert.ToUInt16(p.Double.Value) == 0);
            Execute("Double", 1.78, p => Convert.ToUInt16(p.Double.Value) == 2);
            Execute("Double", 2, p => Convert.ToUInt16(p.Double.Value) == 2);
        }
        [TestMethod]
        public virtual void ToUInt32()
        {
            Execute("Double", 0.23, p => Convert.ToUInt32(p.Double.Value) == 0);
            Execute("Double", 1.78, p => Convert.ToUInt32(p.Double.Value) == 2);
            Execute("Double", 2, p => Convert.ToUInt32(p.Double.Value) == 2);
        }
        [TestMethod]
        public virtual void ToInt64()
        {
            Execute("Double", 0.23, p => Convert.ToInt64(p.Double.Value) == 0);
            Execute("Double", 1.78, p => Convert.ToInt64(p.Double.Value) == 2);
            Execute("Double", 2, p => Convert.ToInt64(p.Double.Value) == 2);
        }
        [TestMethod]
        public virtual void ToUInt64()
        {
            Execute("Double", 0.23, p => Convert.ToUInt64(p.Double.Value) == 0);
            Execute("Double", 1.89, p => Convert.ToUInt64(p.Double.Value) == 2);
            Execute("Double", 2, p => Convert.ToUInt64(p.Double.Value) == 2);
        }
        [TestMethod]
        public virtual void ToSingle()
        {
            Execute("Double", 0.23d, p => Convert.ToSingle(p.Double.Value) == 0.23f);
            Execute("Double", 1.34d, p => Convert.ToSingle(p.Double.Value) == 1.34f);
            Execute("Double", 2.45d, p => Convert.ToSingle(p.Double.Value) == 2.45f);
        }
        [TestMethod]
        public virtual void ToDecimal()
        {
            Execute("Double", 0.23d, p => Convert.ToDecimal(p.Double.Value) == 0.23M);
            Execute("Double", 1.34d, p => Convert.ToDecimal(p.Double.Value) == 1.34M);
            Execute("Double", 2.45d, p => Convert.ToDecimal(p.Double.Value) == 2.45M);
        }
        [TestMethod]
        public virtual void ToSString()
        {
#if !Access  //Access中，cstr(0.23)=.23
            Execute("Double", 0.23d, p => Convert.ToString(p.Double.Value) == "0.23");
#endif
            Execute("Double", 1.34d, p => Convert.ToString(p.Double.Value) == "1.34");
            Execute("Double", 2.45d, p => Convert.ToString(p.Double.Value) == "2.45");
        }
        [TestMethod]
        public virtual void Parse()
        {
            Execute("Double", 0, p => int.Parse("0") == 0);
        }
    }
}
