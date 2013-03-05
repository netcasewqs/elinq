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
    public class UInt32ConvertTest : TestBase<NullableTypeInfo>
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
            Execute("UInt32", 0, p => Convert.ToBoolean(p.UInt32.Value) == false);
#if !Access
            Execute("UInt32", 1, p => Convert.ToBoolean(p.UInt32.Value) == true);
#endif
#if SqlServer
            Execute("UInt32", 2, p => Convert.ToBoolean(p.UInt32.Value) == true);
#endif
        }
        [TestMethod]
        public virtual void ToChar()
        {
            Execute("UInt32", 0, p => Convert.ToChar(p.UInt32.Value) == 0);
            Execute("UInt32", 1, p => Convert.ToChar(p.UInt32.Value) == 1);
            Execute("UInt32", 2, p => Convert.ToChar(p.UInt32.Value) == 2);
        }
        [TestMethod]
        public virtual void ToByte()
        {
            Execute("UInt32", 0, p => Convert.ToByte(p.UInt32.Value) == 0);
            Execute("UInt32", 1, p => Convert.ToByte(p.UInt32.Value) == 1);
            Execute("UInt32", 2, p => Convert.ToByte(p.UInt32.Value) == 2);
        }
        [TestMethod]
        public virtual void ToSByte()
        {
            Execute("UInt32", 0, p => Convert.ToSByte(p.UInt32.Value) == 0);
            Execute("UInt32", 1, p => Convert.ToSByte(p.UInt32.Value) == 1);
            Execute("UInt32", 2, p => Convert.ToSByte(p.UInt32.Value) == 2);
        }
        [TestMethod]
        public virtual void ToInt32()
        {
            Execute("UInt32", 0, p => Convert.ToInt32(p.UInt32.Value) == 0);
            Execute("UInt32", 1, p => Convert.ToInt32(p.UInt32.Value) == 1);
            Execute("UInt32", 2, p => Convert.ToInt32(p.UInt32.Value) == 2);
        }
        [TestMethod]
        public virtual void ToInt16()
        {
            Execute("UInt32", 0, p => Convert.ToInt16(p.UInt32.Value) == 0);
            Execute("UInt32", 1, p => Convert.ToInt16(p.UInt32.Value) == 1);
            Execute("UInt32", 2, p => Convert.ToInt16(p.UInt32.Value) == 2);
        }
        [TestMethod]
        public virtual void ToUInt16()
        {
            Execute("UInt32", 0, p => Convert.ToUInt16(p.UInt32.Value) == 0);
            Execute("UInt32", 1, p => Convert.ToUInt16(p.UInt32.Value) == 1);
            Execute("UInt32", 2, p => Convert.ToUInt16(p.UInt32.Value) == 2);
        }
        [TestMethod]
        public virtual void ToInt64()
        {
            Execute("UInt32", 0, p => Convert.ToInt64(p.UInt32.Value) == 0);
            Execute("UInt32", 1, p => Convert.ToInt64(p.UInt32.Value) == 1);
            Execute("UInt32", 2, p => Convert.ToInt64(p.UInt32.Value) == 2);
        }
        [TestMethod]
        public virtual void ToUInt64()
        {
            Execute("UInt32", 0, p => Convert.ToUInt64(p.UInt32.Value) == 0);
            Execute("UInt32", 1, p => Convert.ToUInt64(p.UInt32.Value) == 1);
            Execute("UInt32", 2, p => Convert.ToUInt64(p.UInt32.Value) == 2);
        }
        [TestMethod]
        public virtual void ToSingle()
        {
            Execute("UInt32", 0, p => Convert.ToSingle(p.UInt32.Value) == 0);
            Execute("UInt32", 1, p => Convert.ToSingle(p.UInt32.Value) == 1);
            Execute("UInt32", 2, p => Convert.ToSingle(p.UInt32.Value) == 2);
        }
        [TestMethod]
        public virtual void ToDouble()
        {
            Execute("UInt32", 0, p => Convert.ToDouble(p.UInt32.Value) == 0);
            Execute("UInt32", 1, p => Convert.ToDouble(p.UInt32.Value) == 1);
            Execute("UInt32", 2, p => Convert.ToDouble(p.UInt32.Value) == 2);
        }
        [TestMethod]
        public virtual void ToDecimal()
        {
            Execute("UInt32", 0, p => Convert.ToDecimal(p.UInt32.Value) == 0);
            Execute("UInt32", 1, p => Convert.ToDecimal(p.UInt32.Value) == 1);
            Execute("UInt32", 2, p => Convert.ToDecimal(p.UInt32.Value) == 2);
        }
        [TestMethod]
        public virtual void ToSString()
        {
            Execute("UInt32", 0, p => Convert.ToString(p.UInt32.Value) == "0");
            Execute("UInt32", 1, p => Convert.ToString(p.UInt32.Value) == "1");
            Execute("UInt32", 2, p => Convert.ToString(p.UInt32.Value) == "2");
        }
        [TestMethod]
        public virtual void Parse()
        {
            Execute("UInt32", 0, p => int.Parse("0") == 0);
        }
    }
}
