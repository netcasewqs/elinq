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
    public class DecimalConvertTest : TestBase<NullableTypeInfo>
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
            Execute("Decimal", 0, p => Convert.ToBoolean(p.Decimal.Value) == false);
#if !Access
            Execute("Decimal", 1, p => Convert.ToBoolean(p.Decimal.Value) == true);
#endif
#if SqlServer
            Execute("Decimal", -1, p => Convert.ToBoolean(p.Decimal.Value) == true);
            Execute("Decimal", 2, p => Convert.ToBoolean(p.Decimal.Value) == true);
#endif
        }
        [TestMethod]
        public virtual void ToChar()
        {
            Execute("Decimal", 0.23M, p => Convert.ToChar(p.Decimal.Value) == 0);
            Execute("Decimal", 1.78M, p => Convert.ToChar(p.Decimal.Value) == 2);
            Execute("Decimal", 2M, p => Convert.ToChar(p.Decimal.Value) == 2);
        }
        [TestMethod]
        public virtual void ToByte()
        {
            Execute("Decimal", 0.23M, p => Convert.ToByte(p.Decimal.Value) == 0);
            Execute("Decimal", 1.78M, p => Convert.ToByte(p.Decimal.Value) == 2);
            Execute("Decimal", 2M, p => Convert.ToByte(p.Decimal.Value) == 2);
        }
        [TestMethod]
        public virtual void ToSByte()
        {
            Execute("Decimal", 0.23M, p => Convert.ToSByte(p.Decimal.Value) == 0);
            Execute("Decimal", 1.78M, p => Convert.ToSByte(p.Decimal.Value) == 2);
            Execute("Decimal", 2M, p => Convert.ToSByte(p.Decimal.Value) == 2);
        }
        [TestMethod]
        public virtual void ToInt32()
        {
            Execute("Decimal", 0.23M, p => Convert.ToInt32(p.Decimal.Value) == 0);
            Execute("Decimal", 1.78M, p => Convert.ToInt32(p.Decimal.Value) == 2);
            Execute("Decimal", 2M, p => Convert.ToInt32(p.Decimal.Value) == 2);
        }
        [TestMethod]
        public virtual void ToInt16()
        {
            Execute("Decimal", 0.23M, p => Convert.ToInt16(p.Decimal.Value) == 0);
            Execute("Decimal", 1.78M, p => Convert.ToInt16(p.Decimal.Value) == 2);
            Execute("Decimal", 2M, p => Convert.ToInt16(p.Decimal.Value) == 2);
        }
        [TestMethod]
        public virtual void ToUInt16()
        {
            Execute("Decimal", 0.23M, p => Convert.ToUInt16(p.Decimal.Value) == 0);
            Execute("Decimal", 1.78M, p => Convert.ToUInt16(p.Decimal.Value) == 2);
            Execute("Decimal", 2M, p => Convert.ToUInt16(p.Decimal.Value) == 2);
        }
        [TestMethod]
        public virtual void ToUInt32()
        {
            Execute("Decimal", 0.23M, p => Convert.ToUInt32(p.Decimal.Value) == 0);
            Execute("Decimal", 1.78M, p => Convert.ToUInt32(p.Decimal.Value) == 2);
            Execute("Decimal", 2M, p => Convert.ToUInt32(p.Decimal.Value) == 2);
        }
        [TestMethod]
        public virtual void ToInt64()
        {
            Execute("Decimal", 0.23M, p => Convert.ToInt64(p.Decimal.Value) == 0);
            Execute("Decimal", 1.78M, p => Convert.ToInt64(p.Decimal.Value) == 2);
            Execute("Decimal", 2M, p => Convert.ToInt64(p.Decimal.Value) == 2);
        }
        [TestMethod]
        public virtual void ToUInt64()
        {
            Execute("Decimal", 0.23M, p => Convert.ToUInt64(p.Decimal.Value) == 0);
            Execute("Decimal", 1.78M, p => Convert.ToUInt64(p.Decimal.Value) == 2);
            Execute("Decimal", 2M, p => Convert.ToUInt64(p.Decimal.Value) == 2);
        }
        [TestMethod]
        public virtual void ToSingle()
        {
            Execute("Decimal", 0.23M, p => Convert.ToSingle(p.Decimal.Value) == 0.23f);
            Execute("Decimal", 1.78M, p => Convert.ToSingle(p.Decimal.Value) == 1.78f);
            Execute("Decimal", 2M, p => Convert.ToSingle(p.Decimal.Value) == 2f);
        }
        [TestMethod]
        public virtual void ToDouble()
        {
            Execute("Decimal", 0.23M, p => Convert.ToDouble(p.Decimal.Value) == 0.23);
            Execute("Decimal", 1.78M, p => Convert.ToDouble(p.Decimal.Value) == 1.78d);
            Execute("Decimal", 2M, p => Convert.ToDouble(p.Decimal.Value) == 2d);
        }
        [TestMethod]
        public virtual void ToSString()
        {
            Execute("Decimal", 0.23M, p => Convert.ToString(p.Decimal.Value) == "0.23");
            Execute("Decimal", 1.78M, p => Convert.ToString(p.Decimal.Value) == "1.78");
            Execute("Decimal", 2M, p => Convert.ToString(p.Decimal.Value) == "2");
        }
        [TestMethod]
        public virtual void Parse()
        {
            Execute("Decimal", 0.23M, p => Decimal.Parse("0.23") == 0.23M);
        }
    }
}
