using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLite.Data.Test.Primitive.Model;
using NUnit.Framework;
using TestMethod = NUnit.Framework.TestAttribute;
using System.Linq.Expressions;
using NLite.Collections;

namespace NLite.Data.Test.TypeConvert
{
    [TestFixture]
    [Category("类型转换")]
    [Category("字符串")]
    public class StringConvertTest : TestBase<NullableTypeInfo>
    {
        protected override string ConnectionStringName
        {
            get
            {
                return "NumericDB";
            }
        }

        public virtual void Execute(string value, Expression<Func<NullableTypeInfo, bool>> filter)
        {
            var identityFieldValue =100;
            var expected = new NullableTypeInfo { Int32 = identityFieldValue, String = value };
            
            Table.Delete(p => true);
            Table.Insert(expected);

            var actual = Table
                .Where(p => p.Int32 == expected.Int32)
                .Where(filter)
                .Select(p => new { Id = p.Id, p.String })
                .FirstOrDefault();

            Assert.IsNotNull(actual);

            Table.Delete(p => true);
        }

        [TestMethod]
        public virtual void ToBoolean()
        {
            Execute("0", p => !Convert.ToBoolean(p.String));
            Execute("1", p => Convert.ToBoolean(p.String));
            Execute("-1", p => Convert.ToBoolean(p.String));
            Execute("2", p => Convert.ToBoolean(p.String));
            Execute("-2", p => Convert.ToBoolean(p.String));

            //Execute("false", p => !Convert.ToBoolean(p.String));
            //Execute("true", p => Convert.ToBoolean(p.String));

            //Execute("FALSE", p => !Convert.ToBoolean(p.String));
            //Execute("TRUE", p => Convert.ToBoolean(p.String));

            //Execute("F", p => !Convert.ToBoolean(p.String));
            //Execute("T", p => Convert.ToBoolean(p.String));

            //Execute("N", p => !Convert.ToBoolean(p.String));
            //Execute("Y", p => Convert.ToBoolean(p.String));

            Execute("0", p => !bool.Parse(p.String));
            Execute("1", p => bool.Parse(p.String));
            Execute("-1", p => bool.Parse(p.String));
            Execute("2", p => bool.Parse(p.String));
            Execute("-2", p => bool.Parse(p.String));

            //Execute("false", p => !bool.Parse(p.String));
            //Execute("true", p => bool.Parse(p.String));

            //Execute("FALSE", p => !bool.Parse(p.String));
            //Execute("TRUE", p => bool.Parse(p.String));
        }
        //[TestMethod]
        //public virtual void ToChar()
        //{
        //    char expected = '0';
        //    Execute("0", p => Convert.ToChar(p.String) == expected);
        //    Execute("0", p => char.Parse(p.String) == expected);
        //}
        [TestMethod]
        public virtual void ToSByte()
        {
            new string[] { "0", "1", "2", "127" }.ForEach(s => Execute(s, p => Convert.ToSByte(p.String) == Convert.ToSByte(s)));
            new string[] { "0", "1", "2", "127" }.ForEach(s => Execute(s, p => sbyte.Parse(p.String) == sbyte.Parse(s)));

        }
        [TestMethod]
        public virtual void ToByte()
        {
            new string[] { "0", "1", "2", "127" }.ForEach(s => Execute(s, p => Convert.ToByte(p.String) == Convert.ToByte(s)));
            new string[] { "0", "1", "2", "127" }.ForEach(s => Execute(s, p => byte.Parse(p.String) == byte.Parse(s)));
        }
        [TestMethod]
        public virtual void ToInt16()
        {
            new string[] { "0", "1", "2", "127" }.ForEach(s => Execute(s, p => Convert.ToInt16(p.String) == Convert.ToInt16(s)));
            new string[] { "0", "1", "2", "127" }.ForEach(s => Execute(s, p => short.Parse(p.String) == short.Parse(s)));
        }
        [TestMethod]
        public virtual void ToUInt16()
        {

            new string[] { "0", "1", "2", "127" }.ForEach(s => Execute(s, p => Convert.ToUInt16(p.String) == Convert.ToInt16(s)));
            new string[] { "0", "1", "2", "127" }.ForEach(s => Execute(s, p => ushort.Parse(p.String) == ushort.Parse(s)));
        }
        [TestMethod]
        public virtual void ToInt32()
        {
            new string[] { "0", "1", "2", "127" }.ForEach(s => Execute(s, p => Convert.ToInt32(p.String) == Convert.ToInt16(s)));
            new string[] { "0", "1", "2", "127" }.ForEach(s => Execute(s, p => int.Parse(p.String) == short.Parse(s)));
        }

        [TestMethod]
        public virtual void ToUInt32()
        {
            new string[] { "0", "1", "2", "127" }.ForEach(s => Execute(s, p => Convert.ToUInt32(p.String) == Convert.ToInt16(s)));
            new string[] { "0", "1", "2", "127" }.ForEach(s => Execute(s, p => uint.Parse(p.String) == short.Parse(s)));
        }
        [TestMethod]
        public virtual void ToInt64()
        {
            new string[] { "0", "1", "2", "127" }.ForEach(s => Execute(s, p => Convert.ToInt64(p.String) == Convert.ToInt16(s)));
            new string[] { "0", "1", "2", "127" }.ForEach(s => Execute(s, p => long.Parse(p.String) == short.Parse(s)));
        }
        [TestMethod]
        public virtual void ToUInt64()
        {
            new string[] { "0", "1", "2", "127" }.ForEach(s => Execute(s, p => Convert.ToUInt64(p.String) == Convert.ToUInt64(s)));
            new string[] { "0", "1", "2", "127" }.ForEach(s => Execute(s, p => ulong.Parse(p.String) == ulong.Parse(s)));
        }
        [TestMethod]
        public virtual void ToSingle()
        {
            new string[] { "0", "1", "-1", "-1024.3","0.987" }.ForEach(s => Execute(s, p => Convert.ToSingle(p.String) == Convert.ToSingle(s)));
            new string[] { "0", "1", "-1", "-1024.3", "0.987" }.ForEach(s => Execute(s, p => Single.Parse(p.String) == Single.Parse(s)));
        }
        [TestMethod]
        public virtual void ToDouble()
        {
            new string[] { "0", "1", "-1", "-1024.3", "0.987" }.ForEach(s => Execute(s, p => Convert.ToDouble(p.String) == Convert.ToDouble(s)));
            new string[] { "0", "1", "-1", "-1024.3", "0.987" }.ForEach(s => Execute(s, p => double.Parse(p.String) == double.Parse(s)));
        }
        [TestMethod]
        public virtual void ToDecimal()
        {
            new string[] { "0", "1", "-1", "-1024.3", "0.987" }.ForEach(s => Execute(s, p => Convert.ToDecimal(p.String) == Convert.ToDecimal(s)));
            new string[] { "0", "1", "-1", "-1024.3", "0.987" }.ForEach(s => Execute(s, p => decimal.Parse(p.String) == decimal.Parse(s)));
        }
        [TestMethod]
        //[ExpectedException(typeof(NotSupportedException))]
        public virtual void ToDateTime()
        {
            new string[] { "2002-07-16 00:00:00", "1922/07/16 00:00:00" }.ForEach(s => Execute(s, p => Convert.ToDateTime(p.String) == Convert.ToDateTime(s)));
            new string[] { "2002-07-16 00:00:00", "1922/07/16 00:00:00" }.ForEach(s => Execute(s, p => DateTime.Parse(p.String) == DateTime.Parse(s)));
        }
       
    }
}
