using System;
using System.Linq;
using System.Linq.Expressions;
using NLite.Data.Test.Primitive.Model;
using NUnit.Framework;
using TestMethod = NUnit.Framework.TestAttribute;
namespace NLite.Data.Test.TypeConvert
{
    public class SingleConvertTest : TestBase<NullableTypeInfo>
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
            Execute("Single", 0, p => Convert.ToBoolean(p.Single.Value) == false);
#if !Access
            Execute("Single", 1, p => Convert.ToBoolean(p.Single.Value) == true);
#endif
#if SqlServer
            Execute("Single", -1, p => Convert.ToBoolean(p.Single.Value) == true);
            Execute("Single", 2, p => Convert.ToBoolean(p.Single.Value) == true);
#endif
        }
        [TestMethod]
        public virtual void ToChar()
        {
            Execute("Single", 0.23f, p => Convert.ToChar(p.Single.Value) == 0);
            Execute("Single", 1.78f, p => Convert.ToChar(p.Single.Value) == 2);
            Execute("Single", 2, p => Convert.ToChar(p.Single.Value) == 2);
        }
        [TestMethod]
        public virtual void ToByte()
        {
            Execute("Single", 0.23f, p => Convert.ToByte(p.Single.Value) == 0);
            Execute("Single", 1.78f, p => Convert.ToByte(p.Single.Value) == 2);
            Execute("Single", 2, p => Convert.ToByte(p.Single.Value) == 2);
        }
        [TestMethod]
        public virtual void ToSByte()
        {
            Execute("Single", 0.23f, p => Convert.ToSByte(p.Single.Value) == 0);
            Execute("Single", 1.78f, p => Convert.ToSByte(p.Single.Value) == 2);
            Execute("Single", 2, p => Convert.ToSByte(p.Single.Value) == 2);
        }
        [TestMethod]
        public virtual void ToInt32()
        {
            Execute("Single", 0.23f, p => Convert.ToInt32(p.Single.Value) == 0);
            Execute("Single", 1.78f, p => Convert.ToInt32(p.Single.Value) == 2);
            Execute("Single", 2, p => Convert.ToInt32(p.Single.Value) == 2);
        }
        [TestMethod]
        public virtual void ToInt16()
        {
            Execute("Single", 0.23f, p => Convert.ToInt16(p.Single.Value) == 0);
            Execute("Single", 1.78f, p => Convert.ToInt16(p.Single.Value) == 2);
            Execute("Single", 2, p => Convert.ToInt16(p.Single.Value) == 2);
        }
        [TestMethod]
        public virtual void ToUInt16()
        {
            Execute("Single", 0.23f, p => Convert.ToUInt16(p.Single.Value) == 0);
            Execute("Single", 1.78f, p => Convert.ToUInt16(p.Single.Value) == 2);
            Execute("Single", 2, p => Convert.ToUInt16(p.Single.Value) == 2);
        }
        [TestMethod]
        public virtual void ToUInt32()
        {
            Execute("Single", 0.23f, p => Convert.ToUInt32(p.Single.Value) == 0);
            Execute("Single", 1.78f, p => Convert.ToUInt32(p.Single.Value) == 2);
            Execute("Single", 2, p => Convert.ToUInt32(p.Single.Value) == 2);
        }
        [TestMethod]
        public virtual void ToInt64()
        {
            Execute("Single", 0.23f, p => Convert.ToInt64(p.Single.Value) == 0);
            Execute("Single", 1.78f, p => Convert.ToInt64(p.Single.Value) == 2);
            Execute("Single", 2, p => Convert.ToInt64(p.Single.Value) == 2);
        }
        [TestMethod]
        public virtual void ToUInt64()
        {
            Execute("Single", 0.23f, p => Convert.ToUInt64(p.Single.Value) == 0);
            Execute("Single", 1.78f, p => Convert.ToUInt64(p.Single.Value) == 2);
            Execute("Single", 2, p => Convert.ToUInt64(p.Single.Value) == 2);
        }
        [TestMethod]
        public virtual void ToDouble()
        {
            Execute("Single", 0.23f, p => Convert.ToDouble(p.Single.Value) == 0.23);
            Execute("Single", 1.34f, p => Convert.ToDouble(p.Single.Value) == 1.34);
            Execute("Single", 2.56f, p => Convert.ToDouble(p.Single.Value) == 2.56);
        }
        [TestMethod]
        public virtual void ToDecimal()
        {
            Execute("Single", 0.23f, p => Convert.ToDecimal(p.Single.Value) == 0.23M);
            Execute("Single", 1.34f, p => Convert.ToDecimal(p.Single.Value) == 1.34M);
            Execute("Single", 2.56f, p => Convert.ToDecimal(p.Single.Value) == 2.56M);
        }
        [TestMethod]
        public virtual void ToSString()
        {
#if !Access//Access中，CSTR (t0.[Single]) = p1，---cstr([0.23])=.23
            Execute("Single", 0.23f, p => Convert.ToString(p.Single.Value) == "0.23");
#endif
            Execute("Single", 1.34f, p => Convert.ToString(p.Single.Value) == "1.34");
            Execute("Single", 2.56f, p => Convert.ToString(p.Single.Value) == "2.56");
        }
        [TestMethod]
        public virtual void Parse()
        {
            Execute("Single", 0, p => Single.Parse("0.23") == 0.23f);
        }
    }
}
