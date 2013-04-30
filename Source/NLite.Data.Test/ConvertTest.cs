using System;
using NLite;
using NUnit.Framework;
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestMethod = NUnit.Framework.TestAttribute;
public class PrimitiveMapper
{


    public static TTo Map<TFrom, TTo>(TFrom from)
    {
        return Converter.Convert<TFrom, TTo>(from);
    }

    public static object Map(object from, Type toType)
    {
        return Converter.Convert(from, toType);
    }
}

namespace NLite.Data.Test.ConvertTest
{
    /// <summary>
    /// BooleanTest 的摘要说明
    /// </summary>
    [TestClass]
    public class BooleanConvertTest
    {


        [TestMethod]
        public virtual void ToBoolean()
        {
            //Boolean a = true;
            //Boolean b; 
            // b = (Boolean)a;
            //b = a;
            //Boolean b = Convert.ToBoolean(a);
            //b = (Boolean)Convert.ChangeType(a, typeof(Boolean));
            // var converter = TypeDescriptor.GetConverter(typeof(Boolean));
            //b = (Boolean)converter.ConvertFrom(a);
            //Console.WriteLine(b);

            //Assert.IsTrue(PrimitiveMapper.Map<bool, bool>(true));
            //Assert.IsFalse(PrimitiveMapper.Map<bool, bool>(false));
            //Assert.IsFalse(PrimitiveMapper.Map<char, bool>('a'));
            Assert.IsFalse(PrimitiveMapper.Map<sbyte, bool>(0));
            Assert.IsTrue(PrimitiveMapper.Map<sbyte, bool>(1));
            Assert.IsTrue(PrimitiveMapper.Map<sbyte, bool>(-1));
            Assert.IsTrue(PrimitiveMapper.Map<sbyte, bool>(2));

            Assert.IsFalse(PrimitiveMapper.Map<sbyte?, bool>(null));
            Assert.IsFalse(PrimitiveMapper.Map<sbyte?, bool>(0));
            Assert.IsTrue(PrimitiveMapper.Map<sbyte?, bool>(1));
            Assert.IsTrue(PrimitiveMapper.Map<sbyte?, bool>(-1));
            Assert.IsTrue(PrimitiveMapper.Map<sbyte?, bool>(2));

            Assert.IsFalse(PrimitiveMapper.Map<sbyte, bool?>(0).Value);
            Assert.IsTrue(PrimitiveMapper.Map<sbyte, bool?>(1).Value);
            Assert.IsTrue(PrimitiveMapper.Map<sbyte, bool?>(-1).Value);
            Assert.IsTrue(PrimitiveMapper.Map<sbyte, bool?>(2).Value);

            Assert.IsNull(PrimitiveMapper.Map<sbyte?, bool?>(null));
            Assert.IsFalse(PrimitiveMapper.Map<sbyte?, bool?>(0).Value);
            Assert.IsTrue(PrimitiveMapper.Map<sbyte?, bool?>(1).Value);
            Assert.IsTrue(PrimitiveMapper.Map<sbyte?, bool?>(-1).Value);
            Assert.IsTrue(PrimitiveMapper.Map<sbyte?, bool?>(2).Value);

        }
        [ExpectedException(typeof(InvalidCastException))]
        //[ExpectedException(typeof(NotSupportedException))]
        [TestMethod]
        public virtual void ToChar()
        {
            /*Boolean a = true;
            Char b;
            //b = a;
            //b = (Char)a;
            b = (Char)Convert.ChangeType(a, typeof(Char));
            var converter = TypeDescriptor.GetConverter(typeof(Char));
            b = (Char)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(Boolean));
            b = (Char)converter.ConvertTo(a, typeof(Char));
            b = Convert.ToChar(a);
            Console.WriteLine(b);*/

            Assert.IsNull(PrimitiveMapper.Map<bool, char>(false));
        }
        [TestMethod]
        public virtual void ToSByte()
        {
            /*Boolean a = true;
            SByte b;
            //b = a;
            //b = (SByte)a;
            b = (SByte)Convert.ChangeType(a, typeof(SByte));
            //b = Convert.ToSByte(a);
            //var converter = TypeDescriptor.GetConverter(typeof(SByte));
            //b = (SByte)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(Boolean));
            //b = (SByte)converter.ConvertTo(a, typeof(SByte));
            Console.WriteLine(b);*/
            Assert.IsTrue(PrimitiveMapper.Map<bool, sbyte>(true) == 1);
            Assert.IsTrue(PrimitiveMapper.Map<bool, sbyte>(false) == 0);

            Assert.IsTrue(PrimitiveMapper.Map<bool?, sbyte>(true) == 1);
            Assert.IsTrue(PrimitiveMapper.Map<bool?, sbyte>(false) == 0);
            Assert.IsTrue(PrimitiveMapper.Map<bool?, sbyte>(null) == 0);

            Assert.IsTrue(PrimitiveMapper.Map<bool, sbyte?>(true) == 1);
            Assert.IsNotNull(PrimitiveMapper.Map<bool, sbyte?>(false));

            Assert.IsTrue(PrimitiveMapper.Map<bool?, sbyte?>(true).Value == 1);
            Assert.IsTrue(PrimitiveMapper.Map<bool?, sbyte?>(false).Value == 0);
            Assert.IsNull(PrimitiveMapper.Map<bool?, sbyte?>(null));
        }
        [TestMethod]
        public virtual void ToByte()
        {
            /*Boolean a = true;
            Byte b;
            //b = a;
            //b = (Byte)a;
            //b = (Byte)Convert.ChangeType(a, typeof(Byte));
            b = Convert.ToByte(a);
            //var converter = TypeDescriptor.GetConverter(typeof(Byte));
            //b = (Byte)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(Boolean));
            //b = (Byte)converter.ConvertTo(a, typeof(Byte));
            Console.WriteLine(b);
             */
            Assert.IsTrue(PrimitiveMapper.Map<bool, byte>(true) == 1);
            Assert.IsTrue(PrimitiveMapper.Map<bool, byte>(false) == 0);

            Assert.IsTrue(PrimitiveMapper.Map<bool?, byte>(true) == 1);
            Assert.IsTrue(PrimitiveMapper.Map<bool?, byte>(false) == 0);
            Assert.IsTrue(PrimitiveMapper.Map<bool?, byte>(null) == 0);

            Assert.IsTrue(PrimitiveMapper.Map<bool, byte?>(true).Value == 1);
            Assert.IsTrue(PrimitiveMapper.Map<bool, byte?>(false).Value == 0);

            Assert.IsTrue(PrimitiveMapper.Map<bool?, byte?>(true).Value == 1);
            Assert.IsTrue(PrimitiveMapper.Map<bool?, byte?>(false).Value == 0);
            Assert.IsTrue(PrimitiveMapper.Map<bool?, byte?>(null) == null);
        }
        [TestMethod]
        public virtual void ToInt16()
        {
            /*Boolean a = true;
            Int16 b;
            //b = a;
            //b = (Int16)a;
            //b = (Int16)Convert.ChangeType(a, typeof(Int16));
            b = Convert.ToInt16(a);
            //var converter = TypeDescriptor.GetConverter(typeof(Int16));
            //b = (Int16)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(Boolean));
            //b = (Int16)converter.ConvertTo(a, typeof(Int16));
            Console.WriteLine(b);
            */
            Assert.IsTrue(PrimitiveMapper.Map<bool, Int16>(true) == 1);
            Assert.IsTrue(PrimitiveMapper.Map<bool, Int16>(false) == 0);

            Assert.IsTrue(PrimitiveMapper.Map<bool?, Int16>(true) == 1);
            Assert.IsTrue(PrimitiveMapper.Map<bool?, Int16>(false) == 0);
            Assert.IsTrue(PrimitiveMapper.Map<bool?, Int16>(null) == 0);

            Assert.IsTrue(PrimitiveMapper.Map<bool, Int16?>(true).Value == 1);
            Assert.IsTrue(PrimitiveMapper.Map<bool, Int16?>(false).Value == 0);

            Assert.IsTrue(PrimitiveMapper.Map<bool?, Int16?>(true).Value == 1);
            Assert.IsTrue(PrimitiveMapper.Map<bool?, Int16?>(false).Value == 0);
            Assert.IsNull(PrimitiveMapper.Map<bool?, Int16?>(null));
        }
        [TestMethod]
        public virtual void ToUInt16()
        {
            /*Boolean a = true;
            UInt16 b;
            //b = a;
            //b = (UInt16)a;
            b = (UInt16)Convert.ChangeType(a, typeof(UInt16));
            //b = Convert.ToUInt16(a);
            //var converter = TypeDescriptor.GetConverter(typeof(UInt16));
            //b = (UInt16)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(Boolean));
           // b = (UInt16)converter.ConvertTo(a, typeof(UInt16));
            Console.WriteLine(b);
             */
            Assert.IsTrue(PrimitiveMapper.Map<bool, UInt16>(true) == 1);
            Assert.IsTrue(PrimitiveMapper.Map<bool, UInt16>(false) == 0);

            Assert.IsTrue(PrimitiveMapper.Map<bool?, UInt16>(true) == 1);
            Assert.IsTrue(PrimitiveMapper.Map<bool?, UInt16>(false) == 0);
            Assert.IsTrue(PrimitiveMapper.Map<bool?, UInt16>(null) == 0);

            Assert.IsTrue(PrimitiveMapper.Map<bool, UInt16?>(true) == 1);
            Assert.IsTrue(PrimitiveMapper.Map<bool, UInt16?>(false) == 0);

            Assert.IsTrue(PrimitiveMapper.Map<bool?, UInt16?>(true) == 1);
            Assert.IsTrue(PrimitiveMapper.Map<bool?, UInt16?>(false) == 0);
            Assert.IsNull(PrimitiveMapper.Map<bool?, UInt16?>(null));
        }
        [TestMethod]
        public virtual void ToInt32()
        {
            /*Boolean a = true;
            Int32 b;
            //b = a;
            //b = (Int32)a;
            //b = (Int32)Convert.ChangeType(a, typeof(Int32));
            b = Convert.ToInt32(a);
            //var converter = TypeDescriptor.GetConverter(typeof(Int32));
            ////b = (Int32)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(Boolean));
            //b = (Int32)converter.ConvertTo(a, typeof(Int32));
            Console.WriteLine(b);
             */
            Assert.IsTrue(PrimitiveMapper.Map<bool, Int32>(true) == 1);
            Assert.IsTrue(PrimitiveMapper.Map<bool, Int32>(false) == 0);

            Assert.IsTrue(PrimitiveMapper.Map<bool?, Int32>(true) == 1);
            Assert.IsTrue(PrimitiveMapper.Map<bool?, Int32>(false) == 0);
            Assert.IsTrue(PrimitiveMapper.Map<bool?, Int32>(null) == 0);

            Assert.IsTrue(PrimitiveMapper.Map<bool, Int32?>(true).Value == 1);
            Assert.IsTrue(PrimitiveMapper.Map<bool, Int32?>(false).Value == 0);

            Assert.IsTrue(PrimitiveMapper.Map<bool?, Int32?>(true).Value == 1);
            Assert.IsTrue(PrimitiveMapper.Map<bool?, Int32?>(false).Value == 0);
            Assert.IsNull(PrimitiveMapper.Map<bool?, Int32?>(null));
        }
        [TestMethod]
        public virtual void ToUInt32()
        {
            /*Boolean a = true;
            UInt32 b;
            //b = a;
            //b = (UInt32)a;
            //b = (UInt32)Convert.ChangeType(a, typeof(UInt32));
            b = Convert.ToUInt32(a);
            //var converter = TypeDescriptor.GetConverter(typeof(UInt32));
            ////b = (UInt32)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(Boolean));
            //b = (UInt32)converter.ConvertTo(a, typeof(UInt32));
            Console.WriteLine(b);
             */
            Assert.IsTrue(PrimitiveMapper.Map<bool, UInt32>(true) == 1);
            Assert.IsTrue(PrimitiveMapper.Map<bool, UInt32>(false) == 0);

            Assert.IsTrue(PrimitiveMapper.Map<bool?, UInt32>(true) == 1);
            Assert.IsTrue(PrimitiveMapper.Map<bool?, UInt32>(false) == 0);
            Assert.IsTrue(PrimitiveMapper.Map<bool?, UInt32>(null) == 0);

            Assert.IsTrue(PrimitiveMapper.Map<bool, UInt32?>(true) == 1);
            Assert.IsTrue(PrimitiveMapper.Map<bool, UInt32?>(false) == 0);

            Assert.IsTrue(PrimitiveMapper.Map<bool?, UInt32?>(true) == 1);
            Assert.IsTrue(PrimitiveMapper.Map<bool?, UInt32?>(false) == 0);
            Assert.IsNull(PrimitiveMapper.Map<bool?, UInt32?>(null));
        }
        [TestMethod]
        public virtual void ToInt64()
        {
            /*Boolean a = true;
            Int64 b;
           //b = a;
            //b = (Int64)a;
            //b = (Int64)Convert.ChangeType(a, typeof(Int64));
            b = Convert.ToInt64(a);
            //var converter = TypeDescriptor.GetConverter(typeof(Int64));
            ////b = (Int64)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(Boolean));
            //b = (Int64)converter.ConvertTo(a, typeof(Int64));
            Console.WriteLine(b);
             */
            Assert.IsTrue(PrimitiveMapper.Map<bool, Int64>(true) == 1);
            Assert.IsTrue(PrimitiveMapper.Map<bool, Int64>(false) == 0);

            Assert.IsTrue(PrimitiveMapper.Map<bool?, Int64>(true) == 1);
            Assert.IsTrue(PrimitiveMapper.Map<bool?, Int64>(false) == 0);
            Assert.IsTrue(PrimitiveMapper.Map<bool?, Int64>(null) == 0);

            Assert.IsTrue(PrimitiveMapper.Map<bool, Int64?>(true) == 1);
            Assert.IsTrue(PrimitiveMapper.Map<bool, Int64?>(false) == 0);

            Assert.IsTrue(PrimitiveMapper.Map<bool?, Int64?>(true) == 1);
            Assert.IsTrue(PrimitiveMapper.Map<bool?, Int64?>(false) == 0);
            Assert.IsNull(PrimitiveMapper.Map<bool?, Int64?>(null));
        }
        [TestMethod]
        public virtual void ToUInt64()
        {
            /*Boolean a = true;
            UInt64 b;
            //b = a;
            //b = (UInt64)a;
            b = (UInt64)Convert.ChangeType(a, typeof(UInt64));
            //b = Convert.ToUInt64(a);
           // var converter = TypeDescriptor.GetConverter(typeof(UInt64));
           //// b = (UInt64)converter.ConvertFrom(a);
           // converter = TypeDescriptor.GetConverter(typeof(Boolean));
           // b = (UInt64)converter.ConvertTo(a, typeof(UInt64));
            Console.WriteLine(b);
             */
            Assert.IsTrue(PrimitiveMapper.Map<bool, UInt64>(true) == 1);
            Assert.IsTrue(PrimitiveMapper.Map<bool, UInt64>(false) == 0);

            Assert.IsTrue(PrimitiveMapper.Map<bool?, UInt64>(true) == 1);
            Assert.IsTrue(PrimitiveMapper.Map<bool?, UInt64>(false) == 0);
            Assert.IsTrue(PrimitiveMapper.Map<bool?, UInt64>(null) == 0);

            Assert.IsTrue(PrimitiveMapper.Map<bool, UInt64?>(true) == 1);
            Assert.IsTrue(PrimitiveMapper.Map<bool, UInt64?>(false) == 0);

            Assert.IsTrue(PrimitiveMapper.Map<bool?, UInt64?>(true) == 1);
            Assert.IsTrue(PrimitiveMapper.Map<bool?, UInt64?>(false) == 0);
            Assert.IsNull(PrimitiveMapper.Map<bool?, UInt64?>(null));
        }
        [TestMethod]
        public virtual void ToSingle()
        {
            /*Boolean a = true;
            Single b;
            //b = a;
            //b = (Single)a;
           // b = (Single)Convert.ChangeType(a, typeof(Single));
            b = Convert.ToSingle(a);
            //var converter = TypeDescriptor.GetConverter(typeof(Single));
            ////b = (Single)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(Boolean));
            //b = (Single)converter.ConvertTo(a, typeof(Single));
            Console.WriteLine(b);
             */
            Assert.IsTrue(PrimitiveMapper.Map<bool, Single>(true) == 1);
            Assert.IsTrue(PrimitiveMapper.Map<bool, Single>(false) == 0);

            Assert.IsTrue(PrimitiveMapper.Map<bool?, Single>(true) == 1);
            Assert.IsTrue(PrimitiveMapper.Map<bool?, Single>(false) == 0);
            Assert.IsTrue(PrimitiveMapper.Map<bool?, Single>(null) == 0);

            Assert.IsTrue(PrimitiveMapper.Map<bool, Single?>(true) == 1);
            Assert.IsTrue(PrimitiveMapper.Map<bool, Single?>(false) == 0);

            Assert.IsTrue(PrimitiveMapper.Map<bool?, Single?>(true) == 1);
            Assert.IsTrue(PrimitiveMapper.Map<bool?, Single?>(false) == 0);
            Assert.IsNull(PrimitiveMapper.Map<bool?, Single?>(null));
        }
        [TestMethod]
        public virtual void ToDouble()
        {
            /*Boolean a = true;
            Double b;
            //b = a;
            //b = (Double)a;
           // b = (Double)Convert.ChangeType(a, typeof(Double));
            b = Convert.ToDouble(a);
            //var converter = TypeDescriptor.GetConverter(typeof(Double));
            ////b = (Double)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(Boolean));
            //b = (Double)converter.ConvertTo(a, typeof(Double));
            Console.WriteLine(b);
             */
            Assert.IsTrue(PrimitiveMapper.Map<bool, Double>(true) == 1);
            Assert.IsTrue(PrimitiveMapper.Map<bool, Double>(false) == 0);

            Assert.IsTrue(PrimitiveMapper.Map<bool?, Double>(true) == 1);
            Assert.IsTrue(PrimitiveMapper.Map<bool?, Double>(false) == 0);
            Assert.IsTrue(PrimitiveMapper.Map<bool?, Double>(null) == 0);

            Assert.IsTrue(PrimitiveMapper.Map<bool, Double?>(true) == 1);
            Assert.IsTrue(PrimitiveMapper.Map<bool, Double?>(false) == 0);

            Assert.IsTrue(PrimitiveMapper.Map<bool?, Double?>(true) == 1);
            Assert.IsTrue(PrimitiveMapper.Map<bool?, Double?>(false) == 0);
            Assert.IsNull(PrimitiveMapper.Map<bool?, Double?>(null));
        }
        [TestMethod]
        public virtual void ToDecimal()
        {
            /*Boolean a = true;
            Decimal b;
            //b = a;
            //b = (Decimal)a;
            //b = (Decimal)Convert.ChangeType(a, typeof(Decimal));
            b = Convert.ToDecimal(a);
            //var converter = TypeDescriptor.GetConverter(typeof(Decimal));
            ////b = (Decimal)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(Boolean));
            //b = (Decimal)converter.ConvertTo(a, typeof(Decimal));
            Console.WriteLine(b);
             */
            Assert.IsTrue(PrimitiveMapper.Map<bool, Decimal>(true) == 1);
            Assert.IsTrue(PrimitiveMapper.Map<bool, Decimal>(false) == 0);

            Assert.IsTrue(PrimitiveMapper.Map<bool?, Decimal>(true) == 1);
            Assert.IsTrue(PrimitiveMapper.Map<bool?, Decimal>(false) == 0);
            Assert.IsTrue(PrimitiveMapper.Map<bool?, Decimal>(null) == 0);

            Assert.IsTrue(PrimitiveMapper.Map<bool, Decimal?>(true) == 1);
            Assert.IsTrue(PrimitiveMapper.Map<bool, Decimal?>(false) == 0);

            Assert.IsTrue(PrimitiveMapper.Map<bool?, Decimal?>(true) == 1);
            Assert.IsTrue(PrimitiveMapper.Map<bool?, Decimal?>(false) == 0);
            Assert.IsNull(PrimitiveMapper.Map<bool?, Decimal?>(null));
        }
        [ExpectedException(typeof(InvalidCastException))]
        //[ExpectedException(typeof(NotSupportedException))]
        [TestMethod]
        public virtual void ToDateTime()
        {
            /*Boolean a = true;
            DateTime b;
            //b = a;
            //b = (DateTime)a;
            //b = (DateTime)Convert.ChangeType(a, typeof(DateTime));
            //b = Convert.ToDateTime(a);
            var converter = TypeDescriptor.GetConverter(typeof(DateTime));
            b = (DateTime)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(Boolean));
            //b = (DateTime)converter.ConvertTo(a, typeof(DateTime));
            Console.WriteLine(b);
             */
            Assert.IsFalse(PrimitiveMapper.Map<bool, DateTime>(true) == new DateTime(2012, 7, 9));
        }
        [TestMethod]
        public virtual void ToSString()
        {
            /*Boolean a = true;
            String b;
            //b = a;
            //b = (String)a;
            //b = (String)Convert.ChangeType(a, typeof(String));
            //b = Convert.ToString(a);
            var converter = TypeDescriptor.GetConverter(typeof(String));
            //b = (String)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(Boolean));
            b = (String)converter.ConvertTo(a, typeof(String));
            Console.WriteLine(b);
             */
            Assert.IsTrue(PrimitiveMapper.Map<bool, string>(true) == "True");
            bool b = true;
            string s = b.ToString();
            Console.WriteLine(s);
        }
        [TestMethod]
        public virtual void Parse()
        {
            Boolean a = true;
            String b = "false";
            //b = "1";
            //b = "0";
            a = Boolean.Parse(b);
            Console.WriteLine(a);
        }
    }
    [TestClass]
    public class CharConvertTest
    {
        //[ExpectedException(typeof(NotSupportedException))]
        [ExpectedException(typeof(InvalidCastException))]
        [TestMethod]
        public virtual void ToBoolean()
        {
            /*Char a = 't';
            Boolean b;
            //b = a;
            //b = (Boolean)a;
            //Boolean b = Convert.ToBoolean(a);
            
            //b = (Boolean)Convert.ChangeType(a, typeof(Boolean));
            var converter = TypeDescriptor.GetConverter(typeof(Boolean));
            //b = (Boolean)converter.ConvertFrom(a);
            converter=TypeDescriptor.GetConverter(typeof(Char));
            b = (Boolean)converter.ConvertTo(a,typeof(Boolean));
            Console.WriteLine(b);
            */
            Assert.IsNotNull(PrimitiveMapper.Map<char, bool>(' '));
        }
        [TestMethod]
        public virtual void ToChar()
        {
            /*Char a = 't';
            Char b;
            //b = a;
            b = (Char)a;
            //b = (Char)Convert.ChangeType(a, typeof(Char));
            //var converter = TypeDescriptor.GetConverter(typeof(Char));
            //b = (Char)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(Char));
            //b = (Char)converter.ConvertTo(a, typeof(Char));
            //b = Convert.ToChar(a);
            Console.WriteLine(b);
             */
            Assert.IsNotNull(PrimitiveMapper.Map<char, char>(' '));
        }
        [TestMethod]
        public virtual void ToSByte()
        {
            /*Char a = 't';
            SByte b;
            //b = a;
            //b = (SByte)a;
           // b = (SByte)Convert.ChangeType(a, typeof(SByte));
            b = Convert.ToSByte(a);
            //var converter = TypeDescriptor.GetConverter(typeof(SByte));
            //b = (SByte)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(Char));
            //b = (SByte)converter.ConvertTo(a, typeof(SByte));
            Console.WriteLine(b);
             */
            Assert.IsNotNull(PrimitiveMapper.Map<char, sbyte>('1'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, sbyte>('0'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, sbyte>('a'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, sbyte>('-'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, sbyte>(' '));

            Assert.IsNotNull(PrimitiveMapper.Map<char?, sbyte>('1'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, sbyte>('0'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, sbyte>('a'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, sbyte>('-'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, sbyte>(' '));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, sbyte>(null));

            Assert.IsNotNull(PrimitiveMapper.Map<char, sbyte?>('1'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, sbyte?>('0'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, sbyte?>('a'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, sbyte?>('-'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, sbyte?>(' '));

            Assert.IsNotNull(PrimitiveMapper.Map<char?, sbyte?>('1'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, sbyte?>('0'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, sbyte?>('a'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, sbyte?>('-'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, sbyte?>(' '));
            Assert.IsNull(PrimitiveMapper.Map<char?, sbyte?>(null));

        }
        [TestMethod]
        public virtual void ToByte()
        {
            /*Char a = 't';
            Byte b;
            //b = a;
            //b = (Byte)a;
            //b = (Byte)Convert.ChangeType(a, typeof(Byte));
            b = Convert.ToByte(a);
            //var converter = TypeDescriptor.GetConverter(typeof(Byte));
            //b = (Byte)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(Char));
            //b = (Byte)converter.ConvertTo(a, typeof(Byte));
            Console.WriteLine(b);
             */
            Assert.IsNotNull(PrimitiveMapper.Map<char, byte>('1'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, byte>('0'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, byte>('a'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, byte>('-'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, byte>(' '));

            Assert.IsNotNull(PrimitiveMapper.Map<char?, byte>('1'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, byte>('0'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, byte>('a'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, byte>('-'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, byte>(null));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, byte>(' '));

            Assert.IsNotNull(PrimitiveMapper.Map<char, byte?>('1'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, byte?>('0'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, byte?>('a'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, byte?>('-'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, byte?>(' '));

            Assert.IsNotNull(PrimitiveMapper.Map<char?, byte?>('1'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, byte?>('0'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, byte?>('a'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, byte?>('-'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, byte?>(' '));
            Assert.IsNull(PrimitiveMapper.Map<char?, byte?>(null));
        }
        [TestMethod]
        public virtual void ToInt16()
        {
            /*Char a = 't';
            Int16 b;
            //b = a;
            //b = (Int16)a;
            //b = (Int16)Convert.ChangeType(a, typeof(Int16));
            b = Convert.ToInt16(a);
            //var converter = TypeDescriptor.GetConverter(typeof(Int16));
            //b = (Int16)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(Char));
            //b = (Int16)converter.ConvertTo(a, typeof(Int16));
            Console.WriteLine(b);
             */
            Assert.IsNotNull(PrimitiveMapper.Map<char, Int16>('1'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, Int16>('0'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, Int16>('a'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, Int16>('-'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, Int16>(' '));

            Assert.IsNotNull(PrimitiveMapper.Map<char?, Int16>('1'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, Int16>('0'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, Int16>('a'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, Int16>('-'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, Int16>(' '));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, Int16>(null));

            Assert.IsNotNull(PrimitiveMapper.Map<char, Int16?>('1'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, Int16?>('0'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, Int16?>('a'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, Int16?>('-'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, Int16?>(' '));

            Assert.IsNotNull(PrimitiveMapper.Map<char?, Int16?>('1'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, Int16?>('0'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, Int16?>('a'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, Int16?>('-'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, Int16?>(' '));
            Assert.IsNull(PrimitiveMapper.Map<char?, Int16?>(null));
        }
        [TestMethod]
        public virtual void ToUInt16()
        {
            /*Char a = 't';
            UInt16 b;
            b = a;
            //b = (UInt16)a;
            //b = (UInt16)Convert.ChangeType(a, typeof(UInt16));
            //b = Convert.ToUInt16(a);
            //var converter = TypeDescriptor.GetConverter(typeof(UInt16));
            //b = (UInt16)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(Char));
            //b = (UInt16)converter.ConvertTo(a, typeof(UInt16));
            Console.WriteLine(b);
             */
            Assert.IsNotNull(PrimitiveMapper.Map<char, UInt16>('1'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, UInt16>('0'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, UInt16>('a'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, UInt16>('-'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, UInt16>(' '));

            Assert.IsNotNull(PrimitiveMapper.Map<char?, UInt16>('1'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, UInt16>('0'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, UInt16>('a'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, UInt16>('-'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, UInt16>(' '));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, UInt16>(null));

            Assert.IsNotNull(PrimitiveMapper.Map<char, UInt16?>('1'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, UInt16?>('0'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, UInt16?>('a'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, UInt16?>('-'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, UInt16?>(' '));

            Assert.IsNotNull(PrimitiveMapper.Map<char?, UInt16?>('1'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, UInt16?>('0'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, UInt16?>('a'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, UInt16?>('-'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, UInt16?>(' '));
            Assert.IsNull(PrimitiveMapper.Map<char?, UInt16?>(null));
        }
        [TestMethod]
        public virtual void ToInt32()
        {
            /*Char a = 't';
            Int32 b;
            //b = a;
            //b = (Int32)a;
            //b = (Int32)Convert.ChangeType(a, typeof(Int32));
            b = Convert.ToInt32(a);
            //var converter = TypeDescriptor.GetConverter(typeof(Int32));
            //b = (Int32)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(Char));
            //b = (Int32)converter.ConvertTo(a, typeof(Int32));
            Console.WriteLine(b);
             */
            Assert.IsNotNull(PrimitiveMapper.Map<char, Int32>('1'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, Int32>('0'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, Int32>('a'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, Int32>('-'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, Int32>(' '));

            Assert.IsNotNull(PrimitiveMapper.Map<char?, Int32>('1'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, Int32>('0'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, Int32>('a'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, Int32>('-'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, Int32>(null));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, Int32>(' '));

            Assert.IsNotNull(PrimitiveMapper.Map<char, Int32?>('1'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, Int32?>('0'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, Int32?>('a'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, Int32?>('-'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, Int32?>(' '));

            Assert.IsNotNull(PrimitiveMapper.Map<char?, Int32?>('1'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, Int32?>('0'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, Int32?>('a'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, Int32?>('-'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, Int32?>(' '));
            Assert.IsNull(PrimitiveMapper.Map<char?, Int32?>(null));
        }
        [TestMethod]
        public virtual void ToUInt32()
        {
            /*Char a = 't';
            UInt32 b;
            //b = a;
            //b = (UInt32)a;
            //b = (UInt32)Convert.ChangeType(a, typeof(UInt32));
            b = Convert.ToUInt32(a);
            //var converter = TypeDescriptor.GetConverter(typeof(UInt32));
            ////b = (UInt32)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(Char));
            //b = (UInt32)converter.ConvertTo(a, typeof(UInt32));
            Console.WriteLine(b);
             */
            Assert.IsNotNull(PrimitiveMapper.Map<char, UInt32>('1'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, UInt32>('0'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, UInt32>('a'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, UInt32>('-'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, UInt32>(' '));

            Assert.IsNotNull(PrimitiveMapper.Map<char?, UInt32>('1'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, UInt32>('0'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, UInt32>('a'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, UInt32>('-'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, UInt32>(' '));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, UInt32>(null));

            Assert.IsNotNull(PrimitiveMapper.Map<char, UInt32?>('1'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, UInt32?>('0'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, UInt32?>('a'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, UInt32?>('-'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, UInt32?>(' '));

            Assert.IsNotNull(PrimitiveMapper.Map<char?, UInt32?>('1'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, UInt32?>('0'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, UInt32?>('a'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, UInt32?>('-'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, UInt32?>(' '));
            Assert.IsNull(PrimitiveMapper.Map<char?, UInt32?>(null));
        }
        [TestMethod]
        public virtual void ToInt64()
        {
            /*Char a = 't';
            Int64 b;
            b = a;
            //b = (Int64)a;
            //b = (Int64)Convert.ChangeType(a, typeof(Int64));
            //b = Convert.ToInt64(a);
            //var converter = TypeDescriptor.GetConverter(typeof(Int64));
            ////b = (Int64)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(Char));
            //b = (Int64)converter.ConvertTo(a, typeof(Int64));
            Console.WriteLine(b);
             */
            Assert.IsNotNull(PrimitiveMapper.Map<char, Int64>('1'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, Int64>('0'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, Int64>('a'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, Int64>('-'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, Int64>(' '));

            Assert.IsNotNull(PrimitiveMapper.Map<char?, Int64>('1'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, Int64>('0'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, Int64>('a'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, Int64>('-'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, Int64>(' '));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, Int64>(null));

            Assert.IsNotNull(PrimitiveMapper.Map<char, Int64?>('1'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, Int64?>('0'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, Int64?>('a'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, Int64?>('-'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, Int64?>(' '));

            Assert.IsNotNull(PrimitiveMapper.Map<char?, Int64?>('1'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, Int64?>('0'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, Int64?>('a'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, Int64?>('-'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, Int64?>(' '));
            Assert.IsNull(PrimitiveMapper.Map<char?, Int64?>(null));
        }
        [TestMethod]
        public virtual void ToUInt64()
        {
            /*Char a = 't';
            UInt64 b;
            b = a;
            //b = (UInt64)a;
            //b = (UInt64)Convert.ChangeType(a, typeof(UInt64));
            //b = Convert.ToUInt64(a);
           // var converter = TypeDescriptor.GetConverter(typeof(UInt64));
           //// b = (UInt64)converter.ConvertFrom(a);
           // converter = TypeDescriptor.GetConverter(typeof(Char));
           // b = (UInt64)converter.ConvertTo(a, typeof(UInt64));
            Console.WriteLine(b);
             */
            Assert.IsNotNull(PrimitiveMapper.Map<char, UInt64>('1'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, UInt64>('0'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, UInt64>('a'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, UInt64>('-'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, UInt64>(' '));

            Assert.IsNotNull(PrimitiveMapper.Map<char?, UInt64>('1'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, UInt64>('0'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, UInt64>('a'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, UInt64>('-'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, UInt64>(' '));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, UInt64>(null));

            Assert.IsNotNull(PrimitiveMapper.Map<char, UInt64?>('1'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, UInt64?>('0'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, UInt64?>('a'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, UInt64?>('-'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, UInt64?>(' '));

            Assert.IsNotNull(PrimitiveMapper.Map<char?, UInt64?>('1'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, UInt64?>('0'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, UInt64?>('a'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, UInt64?>('-'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, UInt64?>(' '));
            Assert.IsNull(PrimitiveMapper.Map<char?, UInt64?>(null));
        }
        [ExpectedException(typeof(InvalidCastException))]
        [TestMethod]
        public virtual void ToSingle()
        {
            /*Char a = 't';
            Single b;
            b = a;
            //b = (Single)a;
             //b = (Single)Convert.ChangeType(a, typeof(Single));
            //b = Convert.ToSingle(a);
            //var converter = TypeDescriptor.GetConverter(typeof(Single));
            ////b = (Single)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(Char));
            //b = (Single)converter.ConvertTo(a, typeof(Single));
            Console.WriteLine(b);
             */
            Assert.IsNotNull(PrimitiveMapper.Map<char, Single>('1'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, Single>('0'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, Single>('a'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, Single>('-'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, Single>(' '));

            Assert.IsNotNull(PrimitiveMapper.Map<char?, Single>('1'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, Single>('0'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, Single>('a'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, Single>('-'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, Single>(null));
            // Assert.IsNotNull(PrimitiveMapper.Map<char?, Single>(' '));

            Assert.IsNotNull(PrimitiveMapper.Map<char, Single?>('1'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, Single?>('0'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, Single?>('a'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, Single?>('-'));
            //Assert.IsNotNull(PrimitiveMapper.Map<char, Single?>(' '));

            Assert.IsNotNull(PrimitiveMapper.Map<char?, Single?>('1'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, Single?>('0'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, Single?>('a'));
            Assert.IsNotNull(PrimitiveMapper.Map<char?, Single?>('-'));
            //Assert.IsNotNull(PrimitiveMapper.Map<char?, Single?>(' '));
            Assert.IsNull(PrimitiveMapper.Map<char?, Single?>(null));
        }
        [ExpectedException(typeof(InvalidCastException))]
        [TestMethod]
        public virtual void ToDouble()
        {
            /*Char a = 't';
            Double b;
            b = a;
            //b = (Double)a;
             //b = (Double)Convert.ChangeType(a, typeof(Double));
            //b = Convert.ToDouble(a);
            //var converter = TypeDescriptor.GetConverter(typeof(Double));
            //b = (Double)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(Char));
            //b = (Double)converter.ConvertTo(a, typeof(Double));
            Console.WriteLine(b);
             */
            Assert.IsNotNull(PrimitiveMapper.Map<char, Double>('1'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, Double>('0'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, Double>('a'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, Double>('-'));
            Assert.IsNotNull(PrimitiveMapper.Map<char, Double>(' '));
        }
        [ExpectedException(typeof(InvalidCastException))]
        [TestMethod]
        public virtual void ToDecimal()
        {
            /*Char a = 't';
            Decimal b;
            b = a;
            //b = (Decimal)a;
           // b = (Decimal)Convert.ChangeType(a, typeof(Decimal));
            //b = Convert.ToDecimal(a);
            //var converter = TypeDescriptor.GetConverter(typeof(Decimal));
            //b = (Decimal)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(Char));
            //b = (Decimal)converter.ConvertTo(a, typeof(Decimal));
            Console.WriteLine(b);
             */
            Assert.IsNotNull(PrimitiveMapper.Map<char?, Decimal?>(' '));
        }
        [ExpectedException(typeof(InvalidCastException))]
        [TestMethod]
        public virtual void ToDateTime()
        {
            /*Char a = 't';
            DateTime b;
            //b = a;
            //b = (DateTime)a;
            //b = (DateTime)Convert.ChangeType(a, typeof(DateTime));
            //b = Convert.ToDateTime(a);
            var converter = TypeDescriptor.GetConverter(typeof(DateTime));
            b = (DateTime)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(Char));
            //b = (DateTime)converter.ConvertTo(a, typeof(DateTime));
            Console.WriteLine(b);
             */
            Assert.IsNotNull(PrimitiveMapper.Map<char?, DateTime?>(' '));
        }
        [TestMethod]
        public virtual void ToSString()
        {
            /*Char a = 't';
            String b;
            //b = a;
            //b = (String)a;
            b = (String)Convert.ChangeType(a, typeof(String));
            //b = Convert.ToString(a);
            //var converter = TypeDescriptor.GetConverter(typeof(String));
            //b = (String)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(Char));
            //b = (String)converter.ConvertTo(a, typeof(String));
            Console.WriteLine(b);
             */
            Assert.IsTrue(PrimitiveMapper.Map<char, String>('1') == "1");
            Assert.IsTrue(PrimitiveMapper.Map<char, String>('0') == "0");
            Assert.IsTrue(PrimitiveMapper.Map<char, String>('a') == "a");
            Assert.IsTrue(PrimitiveMapper.Map<char, String>('-') == "-");
            Assert.IsTrue(PrimitiveMapper.Map<char, String>(' ') == " ");

            Assert.IsTrue(PrimitiveMapper.Map<char?, String>('1') == "1");
            Assert.IsTrue(PrimitiveMapper.Map<char?, String>('0') == "0");
            Assert.IsTrue(PrimitiveMapper.Map<char?, String>('a') == "a");
            Assert.IsTrue(PrimitiveMapper.Map<char?, String>('-') == "-");
            Assert.IsTrue(PrimitiveMapper.Map<char?, String>(' ') == " ");
            Assert.IsNull(PrimitiveMapper.Map<char?, String>(null));

            //Assert.IsNotNull(PrimitiveMapper.Map<char, String?>('1'));
            //Assert.IsNotNull(PrimitiveMapper.Map<char, String?>('0'));
            //Assert.IsNotNull(PrimitiveMapper.Map<char, String?>('a'));
            //Assert.IsNotNull(PrimitiveMapper.Map<char, String?>('-'));
            //Assert.IsNotNull(PrimitiveMapper.Map<char, String?>(' '));

            //Assert.IsNotNull(PrimitiveMapper.Map<char?, String?>('1'));
            //Assert.IsNotNull(PrimitiveMapper.Map<char?, String?>('0'));
            //Assert.IsNotNull(PrimitiveMapper.Map<char?, String?>('a'));
            //Assert.IsNotNull(PrimitiveMapper.Map<char?, String?>('-'));
            //Assert.IsNotNull(PrimitiveMapper.Map<char?, String?>(' '));
            //Assert.IsNull(PrimitiveMapper.Map<char?, String?>(null));
        }
        [TestMethod]
        public virtual void Parse()
        {
            Char a = 't';
            String b = " ";
            //b = "1";
            //b = "0";
            a = Char.Parse(b);
            Console.WriteLine(a);
        }
    }
    [TestClass]
    public class SByteConvertTest
    {
        //[ExpectedException(typeof(NotSupportedException))]
        [TestMethod]
        public virtual void ToBoolean()
        {
            /*SByte a = 4;
            Boolean b;
            //b = a;
            //b = (Boolean)a;
            b = Convert.ToBoolean(a);

            //b = (Boolean)Convert.ChangeType(a, typeof(Boolean));
            //var converter = TypeDescriptor.GetConverter(typeof(Boolean));
            //b = (Boolean)converter.ConvertFrom(a);
            
            //converter = TypeDescriptor.GetConverter(typeof(SByte));
            //b = (Boolean)converter.ConvertTo(a, typeof(Boolean));
            Console.WriteLine(b);
             */
            Assert.IsFalse(PrimitiveMapper.Map<sbyte, bool>(0));
            Assert.IsTrue(PrimitiveMapper.Map<sbyte, bool>(1));
            Assert.IsTrue(PrimitiveMapper.Map<sbyte, bool>(-1));
            Assert.IsTrue(PrimitiveMapper.Map<sbyte, bool>(2));

            Assert.IsFalse(PrimitiveMapper.Map<sbyte?, bool>(null));
            Assert.IsFalse(PrimitiveMapper.Map<sbyte?, bool>(0));
            Assert.IsTrue(PrimitiveMapper.Map<sbyte?, bool>(1));
            Assert.IsTrue(PrimitiveMapper.Map<sbyte?, bool>(-1));
            Assert.IsTrue(PrimitiveMapper.Map<sbyte?, bool>(2));

            Assert.IsFalse(PrimitiveMapper.Map<sbyte, bool?>(0).Value);
            Assert.IsTrue(PrimitiveMapper.Map<sbyte, bool?>(1).Value);
            Assert.IsTrue(PrimitiveMapper.Map<sbyte, bool?>(-1).Value);
            Assert.IsTrue(PrimitiveMapper.Map<sbyte, bool?>(2).Value);

            Assert.IsNull(PrimitiveMapper.Map<sbyte?, bool?>(null));
            Assert.IsFalse(PrimitiveMapper.Map<sbyte?, bool?>(0).Value);
            Assert.IsTrue(PrimitiveMapper.Map<sbyte?, bool?>(1).Value);
            Assert.IsTrue(PrimitiveMapper.Map<sbyte?, bool?>(-1).Value);
            Assert.IsTrue(PrimitiveMapper.Map<sbyte?, bool?>(2).Value);
        }
        [TestMethod]
        public virtual void ToChar()
        {
            /*SByte a = 4;
            Char b;
            //b = a;
            //b = (Char)a;
            b = (Char)Convert.ChangeType(a, typeof(Char));
            //b = Convert.ToChar(a);
            //var converter = TypeDescriptor.GetConverter(typeof(Char));
            //b = (Char)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(SByte));
            //b = (Char)converter.ConvertTo(a, typeof(Char));
            
            Console.WriteLine(b);
             */
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, Char>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, Char>(1));
            //Assert.IsNotNull(PrimitiveMapper.Map<sbyte, Char>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, Char>(2));

            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, Char>(null));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, Char>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, Char>(1));
            //Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, Char>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, Char>(2));

            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, Char?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, Char?>(1).Value);
            // Assert.IsNotNull(PrimitiveMapper.Map<sbyte, Char?>(-1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, Char?>(2).Value);

            Assert.IsNull(PrimitiveMapper.Map<sbyte?, Char?>(null));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, Char?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, char?>(1).Value);
            //Assert.IsTrue(PrimitiveMapper.Map<sbyte?, char?>(-1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, char?>(2).Value);
        }
        [TestMethod]
        public virtual void ToSByte()
        {
            /*SByte a = 4;
            SByte b;
            //b = a;
            //b = (SByte)a;
             //b = (SByte)Convert.ChangeType(a, typeof(SByte));
            //b = Convert.ToSByte(a);
            var converter = TypeDescriptor.GetConverter(typeof(SByte));
            //b = (SByte)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(SByte));
            b = (SByte)converter.ConvertTo(a, typeof(SByte));
            Console.WriteLine(b);
             */
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, sbyte>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, sbyte>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, sbyte>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, sbyte>(2));

            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, sbyte>(null));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, sbyte>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, sbyte>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, sbyte>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, sbyte>(2));

            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, sbyte?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, sbyte?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, sbyte?>(-1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, sbyte?>(2).Value);

            Assert.IsNull(PrimitiveMapper.Map<sbyte?, sbyte?>(null));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, sbyte?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, sbyte?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, sbyte?>(-1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, sbyte?>(2).Value);
        }
        [TestMethod]
        public virtual void ToByte()
        {
            /*SByte a = 4;
            Byte b;
            //b = a;
            //b = (Byte)a;
            //b = (Byte)Convert.ChangeType(a, typeof(Byte));
            //b = Convert.ToByte(a);
            var converter = TypeDescriptor.GetConverter(typeof(Byte));
            //b = (Byte)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(SByte));
            b = (Byte)converter.ConvertTo(a, typeof(Byte));
            Console.WriteLine(b);
             */
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, byte>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, byte>(1));
            //Assert.IsNotNull(PrimitiveMapper.Map<sbyte, byte>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, byte>(2));

            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, byte>(null));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, byte>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, byte>(1));
            //Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, byte>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, sbyte>(2));

            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, byte?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, byte?>(1).Value);
            //Assert.IsNotNull(PrimitiveMapper.Map<sbyte, byte?>(-1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, byte?>(2).Value);

            Assert.IsNull(PrimitiveMapper.Map<sbyte?, byte?>(null));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, byte?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, byte?>(1).Value);
            //Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, byte?>(-1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, byte?>(2).Value);
        }
        [TestMethod]
        public virtual void ToInt16()
        {
            /*SByte a = 4;
            Int16 b;
            //b = a;
            //b = (Int16)a;
            //b = (Int16)Convert.ChangeType(a, typeof(Int16));
            //b = Convert.ToInt16(a);
            var converter = TypeDescriptor.GetConverter(typeof(Int16));
            //b = (Int16)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(SByte));
            b = (Int16)converter.ConvertTo(a, typeof(Int16));
            Console.WriteLine(b);
             */
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, Int16>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, Int16>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, Int16>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, Int16>(2));

            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, Int16>(null));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, Int16>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, Int16>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, Int16>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, Int16>(2));

            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, Int16?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, Int16?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, Int16?>(-1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, Int16?>(2).Value);

            Assert.IsNull(PrimitiveMapper.Map<sbyte?, Int16?>(null));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, Int16?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, Int16?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, Int16?>(-1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, Int16?>(2).Value);
        }
        [TestMethod]
        public virtual void ToUInt16()
        {
            /*SByte a = 4;
            UInt16 b;
            //b = a;
            //b = (UInt16)a;
            //b = (UInt16)Convert.ChangeType(a, typeof(UInt16));
            //b = Convert.ToUInt16(a);
            var converter = TypeDescriptor.GetConverter(typeof(UInt16));
            //b = (UInt16)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(SByte));
            b = (UInt16)converter.ConvertTo(a, typeof(UInt16));
            Console.WriteLine(b);
             */
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, UInt16>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, UInt16>(1));
            //Assert.IsNotNull(PrimitiveMapper.Map<sbyte, UInt16>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, UInt16>(2));

            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, UInt16>(null));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, UInt16>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, UInt16>(1));
            //Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, UInt16>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, Int16>(2));

            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, UInt16?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, UInt16?>(1).Value);
            //Assert.IsNotNull(PrimitiveMapper.Map<sbyte, UInt16?>(-1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, UInt16?>(2).Value);

            Assert.IsNull(PrimitiveMapper.Map<sbyte?, UInt16?>(null));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, UInt16?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, UInt16?>(1).Value);
            //Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, UInt16?>(-1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, UInt16?>(2).Value);
        }
        [TestMethod]
        public virtual void ToInt32()
        {
            /*SByte a =4;
            Int32 b;
            //b = a;
            //b = (Int32)a;
            //b = (Int32)Convert.ChangeType(a, typeof(Int32));
            //b = Convert.ToInt32(a);
            var converter = TypeDescriptor.GetConverter(typeof(Int32));
            //b = (Int32)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(SByte));
            b = (Int32)converter.ConvertTo(a, typeof(Int32));
            Console.WriteLine(b);
             */
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, Int32>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, Int32>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, Int32>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, Int32>(2));

            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, Int32>(null));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, Int32>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, Int32>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, Int32>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, Int32>(2));

            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, Int32?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, Int32?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, Int32?>(-1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, Int32?>(2).Value);

            Assert.IsNull(PrimitiveMapper.Map<sbyte?, Int32?>(null));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, Int32?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, Int32?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, Int32?>(-1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, Int32?>(2).Value);
        }
        [TestMethod]
        public virtual void ToUInt32()
        {
            /*SByte a = 4;
            UInt32 b;
            //b = a;
            //b = (UInt32)a;
            //b = (UInt32)Convert.ChangeType(a, typeof(UInt32));
            //b = Convert.ToUInt32(a);
            var converter = TypeDescriptor.GetConverter(typeof(UInt32));
            //b = (UInt32)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(SByte));
            b = (UInt32)converter.ConvertTo(a, typeof(UInt32));
            Console.WriteLine(b);
             */
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, UInt32>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, UInt32>(1));
            //Assert.IsNotNull(PrimitiveMapper.Map<sbyte, UInt32>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, UInt32>(2));

            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, UInt32>(null));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, UInt32>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, UInt32>(1));
            // Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, UInt32>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, UInt32>(2));

            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, UInt32?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, UInt32?>(1).Value);
            //Assert.IsNotNull(PrimitiveMapper.Map<sbyte, UInt32?>(-1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, UInt32?>(2).Value);

            Assert.IsNull(PrimitiveMapper.Map<sbyte?, UInt32?>(null));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, UInt32?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, UInt32?>(1).Value);
            //Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, UInt32?>(-1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, UInt32?>(2).Value);
        }
        [TestMethod]
        public virtual void ToInt64()
        {
            /*SByte a =4;
            Int64 b;
            //b = a;
            //b = (Int64)a;
            //b = (Int64)Convert.ChangeType(a, typeof(Int64));
            //b = Convert.ToInt64(a);
            var converter = TypeDescriptor.GetConverter(typeof(Int64));
            //b = (Int64)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(SByte));
            b = (Int64)converter.ConvertTo(a, typeof(Int64));
            Console.WriteLine(b);
             */
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, Int64>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, Int64>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, Int64>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, Int64>(2));

            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, Int64>(null));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, Int64>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, Int64>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, Int64>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, Int64>(2));

            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, Int64?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, Int64?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, Int64?>(-1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, Int64?>(2).Value);

            Assert.IsNull(PrimitiveMapper.Map<sbyte?, Int64?>(null));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, Int64?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, Int64?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, Int64?>(-1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, Int64?>(2).Value);
        }
        [TestMethod]
        public virtual void ToUInt64()
        {
            /*SByte a = 4;
            UInt64 b;
            //b = a;
            //b = (UInt64)a;
            //b = (UInt64)Convert.ChangeType(a, typeof(UInt64));
            //b = Convert.ToUInt64(a);
            var converter = TypeDescriptor.GetConverter(typeof(UInt64));
            //b = (UInt64)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(SByte));
            b = (UInt64)converter.ConvertTo(a, typeof(UInt64));
            Console.WriteLine(b);
             */
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, UInt64>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, UInt64>(1));
            //Assert.IsNotNull(PrimitiveMapper.Map<sbyte, UInt64>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, UInt64>(2));

            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, UInt64>(null));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, UInt64>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, UInt64>(1));
            //Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, UInt64>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, UInt64>(2));

            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, UInt64?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, UInt64?>(1).Value);
            //Assert.IsNotNull(PrimitiveMapper.Map<sbyte, UInt64?>(-1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, UInt64?>(2).Value);

            Assert.IsNull(PrimitiveMapper.Map<sbyte?, UInt64?>(null));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, UInt64?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, UInt64?>(1).Value);
            //Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, UInt64?>(-1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, UInt64?>(2).Value);
        }
        [TestMethod]
        public virtual void ToSingle()
        {
            /*SByte a = 4;
            Single b;
            //b = a;
            //b = (Single)a;
            //b = (Single)Convert.ChangeType(a, typeof(Single));
            //b = Convert.ToSingle(a);
            var converter = TypeDescriptor.GetConverter(typeof(Single));
            //b = (Single)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(SByte));
            b = (Single)converter.ConvertTo(a, typeof(Single));
            Console.WriteLine(b);
             */
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, Single>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, Single>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, Single>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, Single>(2));

            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, Single>(null));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, Single>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, Single>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, Single>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, Single>(2));

            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, Single?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, Single?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, Single?>(-1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, Single?>(2).Value);

            Assert.IsNull(PrimitiveMapper.Map<sbyte?, Single?>(null));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, Single?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, Single?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, Single?>(-1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, Single?>(2).Value);
        }
        [TestMethod]
        public virtual void ToDouble()
        {
            /*SByte a = 4;
            Double b;
            b = a;
            //b = (Double)a;
            //b = (Double)Convert.ChangeType(a, typeof(Double));
            //b = Convert.ToDouble(a);
            //var converter = TypeDescriptor.GetConverter(typeof(Double));
            //b = (Double)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(SByte));
           // b = (Double)converter.ConvertTo(a, typeof(Double));
            Console.WriteLine(b);
             */
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, Double>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, Double>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, Double>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, Double>(2));

            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, Double>(null));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, Double>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, Double>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, Double>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, Double>(2));

            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, Double?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, Double?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, Double?>(-1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, Double?>(2).Value);

            Assert.IsNull(PrimitiveMapper.Map<sbyte?, Double?>(null));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, Double?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, Double?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, Double?>(-1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, Double?>(2).Value);
        }
        [TestMethod]
        public virtual void ToDecimal()
        {
            /*SByte a = 4;
            Decimal b;
            b = a;
            //b = (Decimal)a;
             //b = (Decimal)Convert.ChangeType(a, typeof(Decimal));
            //b = Convert.ToDecimal(a);
            //var converter = TypeDescriptor.GetConverter(typeof(Decimal));
            ////b = (Decimal)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(SByte));
            //b = (Decimal)converter.ConvertTo(a, typeof(Decimal));
            Console.WriteLine(b);
             */
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, Decimal>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, Decimal>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, Decimal>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, Decimal>(2));

            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, Decimal>(null));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, Decimal>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, Decimal>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, Decimal>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, Decimal>(2));

            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, Decimal?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, Decimal?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, Decimal?>(-1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, Decimal?>(2).Value);

            Assert.IsNull(PrimitiveMapper.Map<sbyte?, Decimal?>(null));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, Decimal?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, Decimal?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, Decimal?>(-1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, Decimal?>(2).Value);
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        //[ExpectedException(typeof(NotSupportedException))]
        public virtual void ToDateTime()
        {
            /*SByte a =4;
            DateTime b;
            //b = a;
            //b = (DateTime)a;
           // b = (DateTime)Convert.ChangeType(a, typeof(DateTime));
            //b = Convert.ToDateTime(a);
            var converter = TypeDescriptor.GetConverter(typeof(DateTime));
            //b = (DateTime)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(SByte));
            b = (DateTime)converter.ConvertTo(a, typeof(DateTime));
            Console.WriteLine(b);
             */
            Assert.IsNull(PrimitiveMapper.Map<sbyte, DateTime>(0));
        }
        [TestMethod]
        public virtual void ToSString()
        {
            /*SByte a =4;
            String b;
            //b = a;
            //b = (String)a;
            //b = (String)Convert.ChangeType(a, typeof(String));
            //b = Convert.ToString(a);
            var converter = TypeDescriptor.GetConverter(typeof(String));
            //b = (String)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(SByte));
            b = (String)converter.ConvertTo(a, typeof(String));
            Console.WriteLine(b);*/
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, String>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, String>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, String>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte, String>(2));

            Assert.IsNull(PrimitiveMapper.Map<sbyte?, String>(null));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, String>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, String>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, String>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, String>(2));
        }
        [TestMethod]
        public virtual void Parse()
        {
            SByte a = 4;
            String b = "012";
            //b = "1";
            //b = "0";
            a = SByte.Parse(b);
            Console.WriteLine(a);
        }
    }
    [TestClass]
    public class ByteConvertTest
    {
        //[ExpectedException(typeof(NotSupportedException))]
        [TestMethod]
        public virtual void ToBoolean()
        {
            /*Byte a = 4;
            Boolean b;
            //b = a;
            //b = (Boolean)a;
            //b = Convert.ToBoolean(a);

            //b = (Boolean)Convert.ChangeType(a, typeof(Boolean));
            var converter = TypeDescriptor.GetConverter(typeof(Boolean));
            //b = (Boolean)converter.ConvertFrom(a);

            converter = TypeDescriptor.GetConverter(typeof(Byte));
            b = (Boolean)converter.ConvertTo(a, typeof(Boolean));
            Console.WriteLine(b);
            */
            Assert.IsFalse(PrimitiveMapper.Map<byte, bool>(0));
            Assert.IsTrue(PrimitiveMapper.Map<byte, bool>(1));
            Assert.IsTrue(PrimitiveMapper.Map<byte, bool>(2));

            Assert.IsFalse(PrimitiveMapper.Map<byte?, bool>(null));
            Assert.IsFalse(PrimitiveMapper.Map<byte?, bool>(0));
            Assert.IsTrue(PrimitiveMapper.Map<byte?, bool>(1));
            Assert.IsTrue(PrimitiveMapper.Map<byte?, bool>(2));

            Assert.IsFalse(PrimitiveMapper.Map<byte, bool?>(0).Value);
            Assert.IsTrue(PrimitiveMapper.Map<byte, bool?>(1).Value);
            Assert.IsTrue(PrimitiveMapper.Map<byte, bool?>(2).Value);

            Assert.IsNull(PrimitiveMapper.Map<byte?, bool?>(null));
            Assert.IsFalse(PrimitiveMapper.Map<byte?, bool?>(0).Value);
            Assert.IsTrue(PrimitiveMapper.Map<byte?, bool?>(1).Value);
            Assert.IsTrue(PrimitiveMapper.Map<byte?, bool?>(2).Value);
        }
        [TestMethod]
        public virtual void ToChar()
        {
            /*Byte a = 4;
            Char b;
            //b = a;
            //b = (Char)a;
            //b = (Char)Convert.ChangeType(a, typeof(Char));
            //b = Convert.ToChar(a);
            var converter = TypeDescriptor.GetConverter(typeof(Char));
            //b = (Char)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(Byte));
            b = (Char)converter.ConvertTo(a, typeof(Char));

            Console.WriteLine(b);
             */
            Assert.IsNotNull(PrimitiveMapper.Map<byte, char>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<byte, char>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<byte, char>(2));

            Assert.IsNotNull(PrimitiveMapper.Map<byte?, char>(null));
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, char>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, char>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, char>(2));

            Assert.IsNotNull(PrimitiveMapper.Map<byte, char?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<byte, char?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<byte, char?>(2).Value);

            Assert.IsNull(PrimitiveMapper.Map<byte?, char?>(null));
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, char?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, char?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, char?>(2).Value);
        }
        [TestMethod]
        public virtual void ToSByte()
        {
            /*Byte a = 4;
            SByte b;
            //b = a;
            b = (SByte)a;
            //b = (SByte)Convert.ChangeType(a, typeof(SByte));
            //b = Convert.ToSByte(a);
            //var converter = TypeDescriptor.GetConverter(typeof(SByte));
            //b = (SByte)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(Byte));
            //b = (SByte)converter.ConvertTo(a, typeof(SByte));
            Console.WriteLine(b);
             */
            Assert.IsNotNull(PrimitiveMapper.Map<byte, SByte>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<byte, SByte>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<byte, SByte>(2));

            Assert.IsNotNull(PrimitiveMapper.Map<byte?, SByte>(null));
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, SByte>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, SByte>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, SByte>(2));

            Assert.IsNotNull(PrimitiveMapper.Map<byte, SByte?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<byte, SByte?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<byte, SByte?>(2).Value);

            Assert.IsNull(PrimitiveMapper.Map<byte?, SByte?>(null));
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, SByte?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, SByte?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, SByte?>(2).Value);
        }
        [TestMethod]
        public virtual void ToByte()
        {
            /*Byte a = 4;
            Byte b;
            b = a;
            //b = (Byte)a;
           //b = (Byte)Convert.ChangeType(a, typeof(Byte));
            //b = Convert.ToByte(a);
            //var converter = TypeDescriptor.GetConverter(typeof(Byte));
            //b = (Byte)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(Byte));
            //b = (Byte)converter.ConvertTo(a, typeof(Byte));
            Console.WriteLine(b);
             */
            Assert.IsNotNull(PrimitiveMapper.Map<byte, Byte>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<byte, Byte>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<byte, Byte>(2));

            Assert.IsNotNull(PrimitiveMapper.Map<byte?, Byte>(null));
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, Byte>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, Byte>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, Byte>(2));

            Assert.IsNotNull(PrimitiveMapper.Map<byte, Byte?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<byte, Byte?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<byte, SByte?>(2).Value);

            Assert.IsNull(PrimitiveMapper.Map<byte?, Byte?>(null));
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, Byte?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, Byte?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, Byte?>(2).Value);
        }
        [TestMethod]
        public virtual void ToInt16()
        {
            /*Byte a = 4;
            Int16 b;
            b = a;
            //b = (Int16)a;
            //b = (Int16)Convert.ChangeType(a, typeof(Int16));
            //b = Convert.ToInt16(a);
            //var converter = TypeDescriptor.GetConverter(typeof(Int16));
            //b = (Int16)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(Byte));
            //b = (Int16)converter.ConvertTo(a, typeof(Int16));
            Console.WriteLine(b);
             */
            Assert.IsNotNull(PrimitiveMapper.Map<byte, Int16>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<byte, Int16>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<byte, Int16>(2));

            Assert.IsNotNull(PrimitiveMapper.Map<byte?, Int16>(null));
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, Int16>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, Int16>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, Int16>(2));

            Assert.IsNotNull(PrimitiveMapper.Map<byte, Int16?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<byte, Int16?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<byte, Int16?>(2).Value);

            Assert.IsNull(PrimitiveMapper.Map<byte?, Int16?>(null));
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, Int16?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, Int16?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, Int16?>(2).Value);
        }
        [TestMethod]
        public virtual void ToUInt16()
        {
            /*Byte a = 4;
            UInt16 b;
            b = a;
            //b = (UInt16)a;
            //b = (UInt16)Convert.ChangeType(a, typeof(UInt16));
            //b = Convert.ToUInt16(a);
            //var converter = TypeDescriptor.GetConverter(typeof(UInt16));
            //b = (UInt16)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(Byte));
            //b = (UInt16)converter.ConvertTo(a, typeof(UInt16));
            Console.WriteLine(b);
             */
            Assert.IsNotNull(PrimitiveMapper.Map<byte, UInt16>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<byte, UInt16>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<byte, UInt16>(2));

            Assert.IsNotNull(PrimitiveMapper.Map<byte?, UInt16>(null));
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, UInt16>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, UInt16>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, UInt16>(2));

            Assert.IsNotNull(PrimitiveMapper.Map<byte, UInt16?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<byte, UInt16?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<byte, UInt16?>(2).Value);

            Assert.IsNull(PrimitiveMapper.Map<byte?, UInt16?>(null));
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, UInt16?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, UInt16?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, UInt16?>(2).Value);
        }
        [TestMethod]
        public virtual void ToInt32()
        {
            /*Byte a = 4;
            Int32 b;
            b = a;
            //b = (Int32)a;
            //b = (Int32)Convert.ChangeType(a, typeof(Int32));
            //b = Convert.ToInt32(a);
            //var converter = TypeDescriptor.GetConverter(typeof(Int32));
            //b = (Int32)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(Byte));
            //b = (Int32)converter.ConvertTo(a, typeof(Int32));
            Console.WriteLine(b);
             */
            Assert.IsNotNull(PrimitiveMapper.Map<byte, Int32>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<byte, Int32>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<byte, Int32>(2));

            Assert.IsNotNull(PrimitiveMapper.Map<byte?, Int32>(null));
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, Int32>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, Int32>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, Int32>(2));

            Assert.IsNotNull(PrimitiveMapper.Map<byte, Int32?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<byte, Int32?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<byte, Int32?>(2).Value);

            Assert.IsNull(PrimitiveMapper.Map<byte?, Int32?>(null));
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, Int32?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, Int32?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, Int32?>(2).Value);
        }
        [TestMethod]
        public virtual void ToUInt32()
        {
            /*Byte a = 4;
            UInt32 b;
            b = a;
            //b = (UInt32)a;
            //b = (UInt32)Convert.ChangeType(a, typeof(UInt32));
            //b = Convert.ToUInt32(a);
            //var converter = TypeDescriptor.GetConverter(typeof(UInt32));
            //b = (UInt32)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(Byte));
            //b = (UInt32)converter.ConvertTo(a, typeof(UInt32));
            Console.WriteLine(b);
             */
            Assert.IsNotNull(PrimitiveMapper.Map<byte, UInt32>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<byte, UInt32>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<byte, UInt32>(2));

            Assert.IsNotNull(PrimitiveMapper.Map<byte?, UInt32>(null));
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, UInt32>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, UInt32>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, UInt32>(2));

            Assert.IsNotNull(PrimitiveMapper.Map<byte, UInt32?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<byte, UInt32?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<byte, UInt32?>(2).Value);

            Assert.IsNull(PrimitiveMapper.Map<byte?, UInt32?>(null));
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, UInt32?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, UInt32?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, UInt32?>(2).Value);
        }
        [TestMethod]
        public virtual void ToInt64()
        {
            /*Byte a = 4;
            Int64 b;
            b = a;
            //b = (Int64)a;
            //b = (Int64)Convert.ChangeType(a, typeof(Int64));
            //b = Convert.ToInt64(a);
            //var converter = TypeDescriptor.GetConverter(typeof(Int64));
            //b = (Int64)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(Byte));
            //b = (Int64)converter.ConvertTo(a, typeof(Int64));
            Console.WriteLine(b);
             */
            Assert.IsNotNull(PrimitiveMapper.Map<byte, Int64>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<byte, Int64>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<byte, Int64>(2));

            Assert.IsNotNull(PrimitiveMapper.Map<byte?, Int64>(null));
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, Int64>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, Int64>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, Int64>(2));

            Assert.IsNotNull(PrimitiveMapper.Map<byte, Int64?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<byte, Int64?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<byte, Int64?>(2).Value);

            Assert.IsNull(PrimitiveMapper.Map<byte?, Int64?>(null));
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, Int64?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, Int64?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, Int64?>(2).Value);
        }
        [TestMethod]
        public virtual void ToUInt64()
        {
            /*Byte a = 4;
            UInt64 b;
            b = a;
            //b = (UInt64)a;
            //b = (UInt64)Convert.ChangeType(a, typeof(UInt64));
            //b = Convert.ToUInt64(a);
            //var converter = TypeDescriptor.GetConverter(typeof(UInt64));
           // b = (UInt64)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(Byte));
            //b = (UInt64)converter.ConvertTo(a, typeof(UInt64));
            Console.WriteLine(b);
             */
            Assert.IsNotNull(PrimitiveMapper.Map<byte, UInt64>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<byte, UInt64>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<byte, UInt64>(2));

            Assert.IsNotNull(PrimitiveMapper.Map<byte?, UInt64>(null));
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, UInt64>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, UInt64>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, UInt64>(2));

            Assert.IsNotNull(PrimitiveMapper.Map<byte, UInt64?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<byte, UInt64?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<byte, UInt64?>(2).Value);

            Assert.IsNull(PrimitiveMapper.Map<byte?, UInt64?>(null));
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, UInt64?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, UInt64?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, UInt64?>(2).Value);
        }
        [TestMethod]
        public virtual void ToSingle()
        {
            /*Byte a = 4;
            Single b;
            b = a;
            //b = (Single)a;
            //b = (Single)Convert.ChangeType(a, typeof(Single));
            //b = Convert.ToSingle(a);
            //var converter = TypeDescriptor.GetConverter(typeof(Single));
           // b = (Single)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(Byte));
            //b = (Single)converter.ConvertTo(a, typeof(Single));
            Console.WriteLine(b);
             */
            Assert.IsNotNull(PrimitiveMapper.Map<byte, Single>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<byte, Single>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<byte, Single>(2));

            Assert.IsNotNull(PrimitiveMapper.Map<byte?, Single>(null));
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, Single>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, Single>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, Single>(2));

            Assert.IsNotNull(PrimitiveMapper.Map<byte, Single?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<byte, Single?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<byte, Single?>(2).Value);

            Assert.IsNull(PrimitiveMapper.Map<byte?, Single?>(null));
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, Single?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, Single?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, Single?>(2).Value);
        }
        [TestMethod]
        public virtual void ToDouble()
        {
            /*Byte a = 4;
            Double b;
            //b = a;
            //b = (Double)a;
            //b = (Double)Convert.ChangeType(a, typeof(Double));
            //b = Convert.ToDouble(a);
            var converter = TypeDescriptor.GetConverter(typeof(Double));
            //b = (Double)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(Byte));
            b = (Double)converter.ConvertTo(a, typeof(Double));
            Console.WriteLine(b);
             */
            Assert.IsNotNull(PrimitiveMapper.Map<byte, Double>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<byte, Double>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<byte, Double>(2));

            Assert.IsNotNull(PrimitiveMapper.Map<byte?, Double>(null));
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, Double>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, Double>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, Double>(2));

            Assert.IsNotNull(PrimitiveMapper.Map<byte, Double?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<byte, Double?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<byte, Double?>(2).Value);

            Assert.IsNull(PrimitiveMapper.Map<byte?, Double?>(null));
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, Double?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, Double?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, Double?>(2).Value);
        }
        [TestMethod]
        public virtual void ToDecimal()
        {
            /*Byte a = 4;
            Decimal b;
            b = a;
           // b = (Decimal)a;
            //b = (Decimal)Convert.ChangeType(a, typeof(Decimal));
            //b = Convert.ToDecimal(a);
            //var converter = TypeDescriptor.GetConverter(typeof(Decimal));
            ////b = (Decimal)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(Byte));
            //b = (Decimal)converter.ConvertTo(a, typeof(Decimal));
            Console.WriteLine(b);
             */
            Assert.IsNotNull(PrimitiveMapper.Map<byte, Decimal>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<byte, Decimal>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<byte, Decimal>(2));

            Assert.IsNotNull(PrimitiveMapper.Map<byte?, Decimal>(null));
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, Decimal>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, Decimal>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, Decimal>(2));

            Assert.IsNotNull(PrimitiveMapper.Map<byte, Decimal?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<byte, Decimal?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<byte, Decimal?>(2).Value);

            Assert.IsNull(PrimitiveMapper.Map<byte?, Decimal?>(null));
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, Decimal?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, Decimal?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, Decimal?>(2).Value);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        //[ExpectedException(typeof(NotSupportedException))]
        public virtual void ToDateTime()
        {
            /*Byte a = 4;
            DateTime b;
           // b = a;
            //b = (DateTime)a;
            //b = (DateTime)Convert.ChangeType(a, typeof(DateTime));
            //b = Convert.ToDateTime(a);
            var converter = TypeDescriptor.GetConverter(typeof(DateTime));
            //b = (DateTime)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(Byte));
            b = (DateTime)converter.ConvertTo(a, typeof(DateTime));
            Console.WriteLine(b);*/
            Assert.IsNull(PrimitiveMapper.Map<byte, DateTime>(0));
        }
        [TestMethod]
        public virtual void ToSString()
        {
            /*Byte a = 4;
            String b;
            //b = a;
           // b = (String)a;
            b = (String)Convert.ChangeType(a, typeof(String));
            //b = Convert.ToString(a);
            //var converter = TypeDescriptor.GetConverter(typeof(String));
            //b = (String)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(Byte));
            //b = (String)converter.ConvertTo(a, typeof(String));
            Console.WriteLine(b);
             */
            Assert.IsTrue(PrimitiveMapper.Map<byte, string>(0) == "0");
            Assert.IsTrue(PrimitiveMapper.Map<byte, string>(1) == "1");
            Assert.IsTrue(PrimitiveMapper.Map<byte, string>(2) == "2");

            Assert.IsTrue(PrimitiveMapper.Map<byte?, string>(null) == null);
            Assert.IsTrue(PrimitiveMapper.Map<byte?, string>(0) == "0");
            Assert.IsTrue(PrimitiveMapper.Map<byte?, string>(1) == "1");
            Assert.IsTrue(PrimitiveMapper.Map<byte?, string>(2) == "2");
        }
        [TestMethod]
        public virtual void Parse()
        {
            Byte a = 4;
            String b = "12";
            //b = "1";
            //b = "0";
            a = Byte.Parse(b);
            Console.WriteLine(a);
        }
    }
    [TestClass]
    public class Int16ConvertTest
    {
        //[ExpectedException(typeof(NotSupportedException))]
        [TestMethod]
        public virtual void ToBoolean()
        {
            /*Int16 a = 4;
            Boolean b;
            //b = a;
            //b = (Boolean)a;
            //b = Convert.ToBoolean(a);

            b = (Boolean)Convert.ChangeType(a, typeof(Boolean));
            //var converter = TypeDescriptor.GetConverter(typeof(Boolean));
            //b = (Boolean)converter.ConvertFrom(a);

            //converter = TypeDescriptor.GetConverter(typeof(Int16));
           // b = (Boolean)converter.ConvertTo(a, typeof(Boolean));
            Console.WriteLine(b);
             */
            Assert.IsTrue(PrimitiveMapper.Map<Int16, bool>(-1));
            Assert.IsFalse(PrimitiveMapper.Map<Int16, bool>(0));
            Assert.IsTrue(PrimitiveMapper.Map<Int16, bool>(1));
            Assert.IsTrue(PrimitiveMapper.Map<Int16, bool>(2));

            Assert.IsTrue(PrimitiveMapper.Map<Int16?, bool>(-1));
            Assert.IsFalse(PrimitiveMapper.Map<Int16?, bool>(0));
            Assert.IsTrue(PrimitiveMapper.Map<Int16?, bool>(1));
            Assert.IsTrue(PrimitiveMapper.Map<Int16?, bool>(2));
            Assert.IsFalse(PrimitiveMapper.Map<Int16?, bool>(null));

            Assert.IsTrue(PrimitiveMapper.Map<Int16, bool?>(-1).Value);
            Assert.IsTrue(PrimitiveMapper.Map<Int16, bool?>(0).Value == false);
            Assert.IsTrue(PrimitiveMapper.Map<Int16, bool?>(1).Value == true);
            Assert.IsTrue(PrimitiveMapper.Map<Int16, bool?>(2).Value == true);

            Assert.IsTrue(PrimitiveMapper.Map<Int16?, bool?>(-1).Value == true);
            Assert.IsTrue(PrimitiveMapper.Map<Int16?, bool?>(0).Value == false);
            Assert.IsTrue(PrimitiveMapper.Map<Int16?, bool?>(1).Value == true);
            Assert.IsTrue(PrimitiveMapper.Map<Int16?, bool?>(2).Value == true);
            Assert.IsNull(PrimitiveMapper.Map<Int16?, bool?>(null));
        }
        [TestMethod]
        public virtual void ToChar()
        {
            /*Int16 a = 4;
            Char b;
            //b = a;
            b = (Char)a;
            //b = (Char)Convert.ChangeType(a, typeof(Char));
            //b = Convert.ToChar(a);
            //var converter = TypeDescriptor.GetConverter(typeof(Char));
            //b = (Char)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(Int16));
            //b = (Char)converter.ConvertTo(a, typeof(Char));

            Console.WriteLine(b);
             */
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, char>(9));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, char>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, char>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, char>(2));

            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, char>(9));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, char>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, char>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, char>(2));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, char>(null));

            Assert.IsNotNull(PrimitiveMapper.Map<Int16, char?>(9).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, char?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, char?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, char?>(2).Value);

            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, char?>(9).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, char?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, char?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, char?>(2).Value);
            Assert.IsNull(PrimitiveMapper.Map<Int16?, char?>(null));

            /*Int16 s = 1;
            char c = (char)s;
            Console.WriteLine(c);*/
        }
        [TestMethod]
        public virtual void ToSByte()
        {
            /*Int16 a = 4;
            SByte b;
            //b = a;
            b = (SByte)a;
            b = (SByte)Convert.ChangeType(a, typeof(SByte));
            b = Convert.ToSByte(a);
           // var converter = TypeDescriptor.GetConverter(typeof(SByte));
            //b = (SByte)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(Int16));
            //b = (SByte)converter.ConvertTo(a, typeof(SByte));
            Console.WriteLine(b);
             */
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, SByte>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, SByte>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, SByte>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, SByte>(127));

            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, SByte>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, SByte>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, SByte>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, SByte>(127));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, SByte>(null));

            Assert.IsNotNull(PrimitiveMapper.Map<Int16, SByte?>(-1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, SByte?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, SByte?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, SByte?>(127).Value);

            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, SByte?>(-1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, SByte?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, SByte?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, SByte?>(127).Value);
            Assert.IsNull(PrimitiveMapper.Map<Int16?, SByte?>(null));
        }
        [TestMethod]
        public virtual void ToByte()
        {
            /*Int16 a = 4;
            Byte b;
            //b = a;
            b = (Byte)a;
            b = (Byte)Convert.ChangeType(a, typeof(Byte));
            b = Convert.ToByte(a);
            //var converter = TypeDescriptor.GetConverter(typeof(Byte));
            //b = (Byte)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(Int16));
            //b = (Byte)converter.ConvertTo(a, typeof(Byte));
            Console.WriteLine(b);
             */
            //Assert.IsNotNull(PrimitiveMapper.Map<Int16, Byte>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, Byte>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, Byte>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, Byte>(127));

            // Assert.IsNotNull(PrimitiveMapper.Map<Int16?, Byte>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, Byte>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, Byte>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, Byte>(127));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, Byte>(null));

            //Assert.IsNotNull(PrimitiveMapper.Map<Int16, Byte?>(-1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, Byte?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, Byte?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, Byte?>(127).Value);

            //Assert.IsNotNull(PrimitiveMapper.Map<Int16?, Byte?>(-1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, Byte?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, Byte?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, Byte?>(127).Value);
            Assert.IsNull(PrimitiveMapper.Map<Int16?, Byte?>(null));
        }
        [TestMethod]
        public virtual void ToInt16()
        {
            /*Int16 a = 4;
            Int16 b;
            b = a;
            b = (Int16)a;
            b = (Int16)Convert.ChangeType(a, typeof(Int16));
            b = Convert.ToInt16(a);
            var converter = TypeDescriptor.GetConverter(typeof(Int16));
            //b = (Int16)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(Int16));
            b = (Int16)converter.ConvertTo(a, typeof(Int16));
            Console.WriteLine(b);
             */
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, Int16>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, Int16>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, Int16>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, Int16>(255));

            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, Int16>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, Int16>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, Int16>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, Int16>(255));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, Int16>(null));

            Assert.IsNotNull(PrimitiveMapper.Map<Int16, Int16?>(-1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, Int16?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, Int16?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, Int16?>(255).Value);

            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, Int16?>(-1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, Int16?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, Int16?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, Int16?>(255).Value);
            Assert.IsNull(PrimitiveMapper.Map<Int16?, Int16?>(null));
        }
        [TestMethod]
        public virtual void ToUInt16()
        {
            /*Int16 a = 4;
            UInt16 b;
            //b = a;
            b = (UInt16)a;
            b = (UInt16)Convert.ChangeType(a, typeof(UInt16));
            b = Convert.ToUInt16(a);
            var converter = TypeDescriptor.GetConverter(typeof(UInt16));
            //b = (UInt16)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(Int16));
            b = (UInt16)converter.ConvertTo(a, typeof(UInt16));
            Console.WriteLine(b);
             */
            //Assert.IsNotNull(PrimitiveMapper.Map<Int16, UInt16>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, UInt16>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, UInt16>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, UInt16>(255));

            //Assert.IsNotNull(PrimitiveMapper.Map<Int16?, UInt16>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, UInt16>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, UInt16>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, UInt16>(255));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, UInt16>(null));

            //Assert.IsNotNull(PrimitiveMapper.Map<Int16, UInt16?>(-1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, UInt16?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, UInt16?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, UInt16?>(255).Value);

            //Assert.IsNotNull(PrimitiveMapper.Map<Int16?, UInt16?>(-1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, UInt16?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, UInt16?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, UInt16?>(255).Value);
            Assert.IsNull(PrimitiveMapper.Map<Int16?, UInt16?>(null));
        }
        [TestMethod]
        public virtual void ToInt32()
        {
            /*Int16 a = 4;
            Int32 b;
            b = a;
            b = (Int32)a;
            b = (Int32)Convert.ChangeType(a, typeof(Int32));
            b = Convert.ToInt32(a);
            var converter = TypeDescriptor.GetConverter(typeof(Int32));
            //b = (Int32)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(Int16));
            b = (Int32)converter.ConvertTo(a, typeof(Int32));
            Console.WriteLine(b);
             */
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, Int32>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, Int32>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, Int32>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, Int32>(511));

            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, Int32>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, Int32>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, Int32>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, Int32>(512));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, Int32>(null));

            Assert.IsNotNull(PrimitiveMapper.Map<Int16, Int32?>(-1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, Int32?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, Int32?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, Int32?>(511).Value);

            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, Int32?>(-1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, Int32?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, Int32?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, Int32?>(511).Value);
            Assert.IsNull(PrimitiveMapper.Map<Int16?, Int32?>(null));
        }
        [TestMethod]
        public virtual void ToUInt32()
        {
            /*Int16 a = 4;
            UInt32 b;
            //b = a;
            b = (UInt32)a;
            b = (UInt32)Convert.ChangeType(a, typeof(UInt32));
            b = Convert.ToUInt32(a);
            var converter = TypeDescriptor.GetConverter(typeof(UInt32));
            //b = (UInt32)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(Int16));
            b = (UInt32)converter.ConvertTo(a, typeof(UInt32));
            Console.WriteLine(b);
             */
            //Assert.IsNotNull(PrimitiveMapper.Map<Int16, UInt32>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, UInt32>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, UInt32>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, UInt32>(511));

            //Assert.IsNotNull(PrimitiveMapper.Map<Int16?, UInt32>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, UInt32>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, UInt32>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, UInt32>(512));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, UInt32>(null));

            //Assert.IsNotNull(PrimitiveMapper.Map<Int16, UInt32?>(-1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, UInt32?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, UInt32?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, UInt32?>(511).Value);

            //Assert.IsNotNull(PrimitiveMapper.Map<Int16?, UInt32?>(-1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, UInt32?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, UInt32?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, UInt32?>(511).Value);
            Assert.IsNull(PrimitiveMapper.Map<Int16?, UInt32?>(null));
        }
        [TestMethod]
        public virtual void ToInt64()
        {
            /*Int16 a = 4;
            Int64 b;
            b = a;
            b = (Int64)a;
            b = (Int64)Convert.ChangeType(a, typeof(Int64));
            b = Convert.ToInt64(a);
            var converter = TypeDescriptor.GetConverter(typeof(Int64));
            //b = (Int64)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(Int16));
            b = (Int64)converter.ConvertTo(a, typeof(Int64));
            Console.WriteLine(b);
             */
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, Int64>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, Int64>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, Int64>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, Int64>(511));

            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, Int64>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, Int64>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, Int64>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, Int64>(512));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, Int64>(null));

            Assert.IsNotNull(PrimitiveMapper.Map<Int16, Int64?>(-1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, Int64?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, Int64?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, Int64?>(511).Value);

            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, Int64?>(-1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, Int64?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, Int64?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, Int64?>(511).Value);
            Assert.IsNull(PrimitiveMapper.Map<Int16?, Int64?>(null));
        }
        [TestMethod]
        public virtual void ToUInt64()
        {
            /*Int16 a = 4;
            UInt64 b;
           // b = a;
            b = (UInt64)a;
            b = (UInt64)Convert.ChangeType(a, typeof(UInt64));
            b = Convert.ToUInt64(a);
            var converter = TypeDescriptor.GetConverter(typeof(UInt64));
             //b = (UInt64)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(Int16));
            b = (UInt64)converter.ConvertTo(a, typeof(UInt64));
            Console.WriteLine(b);
             */
            //Assert.IsNotNull(PrimitiveMapper.Map<Int16, UInt64>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, UInt64>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, UInt64>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, UInt64>(511));

            //Assert.IsNotNull(PrimitiveMapper.Map<Int16?, UInt64>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, UInt64>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, UInt64>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, UInt64>(512));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, UInt64>(null));

            //Assert.IsNotNull(PrimitiveMapper.Map<Int16, UInt64?>(-1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, UInt64?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, UInt64?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, UInt64?>(511).Value);

            //Assert.IsNotNull(PrimitiveMapper.Map<Int16?, UInt64?>(-1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, UInt64?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, UInt64?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, UInt64?>(511).Value);
            Assert.IsNull(PrimitiveMapper.Map<Int16?, UInt64?>(null));
        }
        [TestMethod]
        public virtual void ToSingle()
        {
            /*Int16 a = 4;
            Single b;
            b = a;
            b = (Single)a;
            b = (Single)Convert.ChangeType(a, typeof(Single));
            b = Convert.ToSingle(a);
            var converter = TypeDescriptor.GetConverter(typeof(Single));
             //b = (Single)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(Int16));
            b = (Single)converter.ConvertTo(a, typeof(Single));
            Console.WriteLine(b);
             */
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, Single>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, Single>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, Single>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, Single>(511));

            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, Single>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, Single>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, Single>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, Single>(512));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, Single>(null));

            Assert.IsNotNull(PrimitiveMapper.Map<Int16, Single?>(-1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, Single?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, Single?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, Single?>(511).Value);

            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, Single?>(-1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, Single?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, Single?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, Single?>(511).Value);
            Assert.IsNull(PrimitiveMapper.Map<Int16?, Single?>(null));
        }
        [TestMethod]
        public virtual void ToDouble()
        {
            /*Int16 a = 4;
            Double b;
            b = a;
            b = (Double)a;
            b = (Double)Convert.ChangeType(a, typeof(Double));
            b = Convert.ToDouble(a);
            var converter = TypeDescriptor.GetConverter(typeof(Double));
            //b = (Double)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(Int16));
            b = (Double)converter.ConvertTo(a, typeof(Double));
            Console.WriteLine(b);
             */
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, Double>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, Double>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, Double>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, Double>(511));

            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, Double>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, Double>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, Double>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, Double>(512));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, Double>(null));

            Assert.IsNotNull(PrimitiveMapper.Map<Int16, Double?>(-1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, Double?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, Double?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, Double?>(511).Value);

            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, Double?>(-1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, Double?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, Double?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, Double?>(511).Value);
            Assert.IsNull(PrimitiveMapper.Map<Int16?, Double?>(null));
        }
        [TestMethod]
        public virtual void ToDecimal()
        {
            /*Int16 a = 4;
            Decimal b;
            b = a;
             //b = (Decimal)a;
            //b = (Decimal)Convert.ChangeType(a, typeof(Decimal));
           // b = Convert.ToDecimal(a);
            //var converter = TypeDescriptor.GetConverter(typeof(Decimal));
            //b = (Decimal)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(Int16));
            //b = (Decimal)converter.ConvertTo(a, typeof(Decimal));
            Console.WriteLine(b);
             */
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, decimal>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, decimal>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, decimal>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, decimal>(511));

            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, decimal>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, decimal>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, decimal>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, decimal>(512));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, decimal>(null));

            Assert.IsNotNull(PrimitiveMapper.Map<Int16, decimal?>(-1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, decimal?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, decimal?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, decimal?>(511).Value);

            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, decimal?>(-1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, decimal?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, decimal?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, decimal?>(511).Value);
            Assert.IsNull(PrimitiveMapper.Map<Int16?, decimal?>(null));
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        //[ExpectedException(typeof(NotSupportedException))]
        public virtual void ToDateTime()
        {
            /*Int16 a = 4;
            DateTime b;
            // b = a;
            //b = (DateTime)a;
            //b = (DateTime)Convert.ChangeType(a, typeof(DateTime));
            //b = Convert.ToDateTime(a);
            var converter = TypeDescriptor.GetConverter(typeof(DateTime));
            b = (DateTime)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(Int16));
            //b = (DateTime)converter.ConvertTo(a, typeof(DateTime));
            Console.WriteLine(b);
             */
            Assert.IsNull(PrimitiveMapper.Map<Int16, DateTime>(0));
        }
        [TestMethod]
        public virtual void ToSString()
        {
            /*Int16 a = 4;
            String b;
            //b = a;
             //b = (String)a;
            b = (String)Convert.ChangeType(a, typeof(String));
            b = Convert.ToString(a);
            var converter = TypeDescriptor.GetConverter(typeof(String));
            //b = (String)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(Int16));
            b = (String)converter.ConvertTo(a, typeof(String));
            Console.WriteLine(b);
             */
            Assert.IsTrue(PrimitiveMapper.Map<Int16, string>(-1) == "-1");
            Assert.IsTrue(PrimitiveMapper.Map<Int16, string>(0) == "0");
            Assert.IsNotNull(PrimitiveMapper.Map<Int16, string>(1));
            Assert.IsTrue(PrimitiveMapper.Map<Int16, string>(511) == "511");

            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, string>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, string>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, string>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<Int16?, string>(512));
            Assert.IsNull(PrimitiveMapper.Map<Int16?, string>(null));
        }
        [TestMethod]
        public virtual void Parse()
        {
            Int16 a = 4;
            String b = "-12";
            //b = "1";
            //b = "0";
            a = Int16.Parse(b);
            Console.WriteLine(a);
        }
    }
    [TestClass]
    public class UInt16ConvertTest
    {
        //[ExpectedException(typeof(NotSupportedException))]
        [TestMethod]
        public virtual void ToBoolean()
        {
            /*UInt16 a = 4;
            Boolean b;
            //b = a;
            //b = (Boolean)a;
            b = Convert.ToBoolean(a);

            b = (Boolean)Convert.ChangeType(a, typeof(Boolean));
            var converter = TypeDescriptor.GetConverter(typeof(Boolean));
            //b = (Boolean)converter.ConvertFrom(a);

            converter = TypeDescriptor.GetConverter(typeof(UInt16));
            b = (Boolean)converter.ConvertTo(a, typeof(Boolean));
            Console.WriteLine(b);
             */
            Assert.IsTrue(PrimitiveMapper.Map<UInt16, bool>(0) == false);
            Assert.IsTrue(PrimitiveMapper.Map<UInt16, bool>(1));
            Assert.IsTrue(PrimitiveMapper.Map<UInt16, bool>(2));

            Assert.IsTrue(PrimitiveMapper.Map<UInt16?, bool>(0) == false);
            Assert.IsTrue(PrimitiveMapper.Map<UInt16?, bool>(1));
            Assert.IsTrue(PrimitiveMapper.Map<UInt16?, bool>(2));
            Assert.IsFalse(PrimitiveMapper.Map<UInt16?, bool>(null));

            Assert.IsTrue(PrimitiveMapper.Map<UInt16, bool?>(0).Value == false);
            Assert.IsTrue(PrimitiveMapper.Map<UInt16, bool?>(1).Value);
            Assert.IsTrue(PrimitiveMapper.Map<UInt16, bool?>(2).Value);

            Assert.IsTrue(PrimitiveMapper.Map<UInt16?, bool?>(0).Value == false);
            Assert.IsTrue(PrimitiveMapper.Map<UInt16?, bool?>(1).Value);
            Assert.IsTrue(PrimitiveMapper.Map<UInt16?, bool?>(2).Value);
            Assert.IsNull(PrimitiveMapper.Map<UInt16?, bool?>(null));
        }
        [TestMethod]
        public virtual void ToChar()
        {
            /*UInt16 a = 4;
            Char b;
            //b = a;
            b = (Char)a;
            b = (Char)Convert.ChangeType(a, typeof(Char));
            b = Convert.ToChar(a);
            var converter = TypeDescriptor.GetConverter(typeof(Char));
            //b = (Char)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(UInt16));
            b = (Char)converter.ConvertTo(a, typeof(Char));
            Console.WriteLine(b);
             */
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, char>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, char>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, char>(2));

            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, char>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, char>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, char>(2));
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, char>(null));

            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, char?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, char?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, char?>(2).Value);

            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, char?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, char?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, char?>(2).Value);
            Assert.IsNull(PrimitiveMapper.Map<UInt16?, char?>(null));
        }
        [TestMethod]
        public virtual void ToSByte()
        {
            /*UInt16 a = 4;
            SByte b;
            //b = a;
            b = (SByte)a;
            b = (SByte)Convert.ChangeType(a, typeof(SByte));
            b = Convert.ToSByte(a);
             var converter = TypeDescriptor.GetConverter(typeof(SByte));
            //b = (SByte)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(UInt16));
            b = (SByte)converter.ConvertTo(a, typeof(SByte));
            Console.WriteLine(b);
             */
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, sbyte>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, sbyte>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, sbyte>(2));

            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, sbyte>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, sbyte>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, sbyte>(2));
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, sbyte>(null));

            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, sbyte?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, sbyte?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, sbyte?>(2).Value);

            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, sbyte?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, sbyte?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, sbyte?>(2).Value);
            Assert.IsNull(PrimitiveMapper.Map<UInt16?, sbyte?>(null));
        }
        [TestMethod]
        public virtual void ToByte()
        {
            /*UInt16 a = 252;
            Byte b;
            //b = a;
            b = (Byte)a;
            b = (Byte)Convert.ChangeType(a, typeof(Byte));
            b = Convert.ToByte(a);
            var converter = TypeDescriptor.GetConverter(typeof(Byte));
            //b = (Byte)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(UInt16));
            b = (Byte)converter.ConvertTo(a, typeof(Byte));
            Console.WriteLine(b);
             */
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, byte>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, byte>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, byte>(2));

            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, byte>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, byte>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, byte>(2));
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, byte>(null));

            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, byte?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, byte?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, byte?>(2).Value);

            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, byte?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, byte?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, byte?>(2).Value);
            Assert.IsNull(PrimitiveMapper.Map<UInt16?, byte?>(null));
        }
        [TestMethod]
        public virtual void ToInt16()
        {
            /*UInt16 a = 4;
            Int16 b;
            //b = a;
            b = (Int16)a;
            b = (Int16)Convert.ChangeType(a, typeof(Int16));
            b = Convert.ToInt16(a);
            var converter = TypeDescriptor.GetConverter(typeof(Int16));
            //b = (Int16)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(UInt16));
            b = (Int16)converter.ConvertTo(a, typeof(Int16));
            Console.WriteLine(b);
             */
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, Int16>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, Int16>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, Int16>(2));

            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, Int16>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, Int16>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, Int16>(2));
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, Int16>(null));

            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, Int16?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, Int16?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, Int16?>(2).Value);

            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, Int16?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, Int16?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, Int16?>(2).Value);
            Assert.IsNull(PrimitiveMapper.Map<UInt16?, Int16?>(null));
        }
        [TestMethod]
        public virtual void ToUInt16()
        {
            /*UInt16 a = 4;
            UInt16 b;
            b = a;
            b = (UInt16)a;
            b = (UInt16)Convert.ChangeType(a, typeof(UInt16));
            b = Convert.ToUInt16(a);
            var converter = TypeDescriptor.GetConverter(typeof(UInt16));
            //b = (UInt16)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(UInt16));
            b = (UInt16)converter.ConvertTo(a, typeof(UInt16));
            Console.WriteLine(b);*/
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, UInt16>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, UInt16>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, UInt16>(2));

            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, UInt16>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, UInt16>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, UInt16>(2));
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, UInt16>(null));

            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, UInt16?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, UInt16?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, UInt16?>(2).Value);

            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, UInt16?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, UInt16?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, UInt16?>(2).Value);
            Assert.IsNull(PrimitiveMapper.Map<UInt16?, UInt16?>(null));
        }
        [TestMethod]
        public virtual void ToInt32()
        {
            /*UInt16 a = 4;
            Int32 b;
            b = a;
            b = (Int32)a;
            b = (Int32)Convert.ChangeType(a, typeof(Int32));
            b = Convert.ToInt32(a);
            var converter = TypeDescriptor.GetConverter(typeof(Int32));
            //b = (Int32)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(UInt16));
            b = (Int32)converter.ConvertTo(a, typeof(Int32));
            Console.WriteLine(b);
             */
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, Int32>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, Int32>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, Int32>(2));

            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, Int32>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, Int32>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, Int32>(2));
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, Int32>(null));

            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, Int32?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, Int32?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, Int32?>(2).Value);

            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, Int32?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, Int32?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, Int32?>(2).Value);
            Assert.IsNull(PrimitiveMapper.Map<UInt16?, Int32?>(null));
        }
        [TestMethod]
        public virtual void ToUInt32()
        {
            /*UInt16 a = 4;
            UInt32 b;
            b = a;
            b = (UInt32)a;
            b = (UInt32)Convert.ChangeType(a, typeof(UInt32));
            b = Convert.ToUInt32(a);
            var converter = TypeDescriptor.GetConverter(typeof(UInt32));
            //b = (UInt32)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(UInt16));
            b = (UInt32)converter.ConvertTo(a, typeof(UInt32));
            Console.WriteLine(b);
             */
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, UInt32>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, UInt32>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, UInt32>(2));

            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, UInt32>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, UInt32>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, UInt32>(2));
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, UInt32>(null));

            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, UInt32?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, UInt32?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, UInt32?>(2).Value);

            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, UInt32?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, UInt32?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, UInt32?>(2).Value);
            Assert.IsNull(PrimitiveMapper.Map<UInt16?, UInt32?>(null));
        }
        [TestMethod]
        public virtual void ToInt64()
        {
            /*UInt16 a = 4;
            Int64 b;
            b = a;
            b = (Int64)a;
            b = (Int64)Convert.ChangeType(a, typeof(Int64));
            b = Convert.ToInt64(a);
            var converter = TypeDescriptor.GetConverter(typeof(Int64));
            //b = (Int64)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(UInt16));
            b = (Int64)converter.ConvertTo(a, typeof(Int64));
            Console.WriteLine(b);
             */
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, Int64>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, Int64>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, Int64>(2));

            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, Int64>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, Int64>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, Int64>(2));
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, Int64>(null));

            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, Int64?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, Int64?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, Int64?>(2).Value);

            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, Int64?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, Int64?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, Int64?>(2).Value);
            Assert.IsNull(PrimitiveMapper.Map<UInt16?, Int64?>(null));
        }
        [TestMethod]
        public virtual void ToUInt64()
        {
            /*UInt16 a = 4;
            UInt64 b;
             b = a;
            b = (UInt64)a;
            b = (UInt64)Convert.ChangeType(a, typeof(UInt64));
            b = Convert.ToUInt64(a);
            var converter = TypeDescriptor.GetConverter(typeof(UInt64));
            //b = (UInt64)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(UInt16));
            b = (UInt64)converter.ConvertTo(a, typeof(UInt64));
            Console.WriteLine(b);
             */
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, UInt64>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, UInt64>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, UInt64>(2));

            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, UInt64>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, UInt64>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, UInt64>(2));
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, UInt64>(null));

            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, UInt64?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, UInt64?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, UInt64?>(2).Value);

            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, UInt64?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, UInt64?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, UInt64?>(2).Value);
            Assert.IsNull(PrimitiveMapper.Map<UInt16?, UInt64?>(null));
        }
        [TestMethod]
        public virtual void ToSingle()
        {
            /*UInt16 a = 4;
            Single b;
            b = a;
            b = (Single)a;
            b = (Single)Convert.ChangeType(a, typeof(Single));
            b = Convert.ToSingle(a);
            var converter = TypeDescriptor.GetConverter(typeof(Single));
            //b = (Single)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(UInt16));
            b = (Single)converter.ConvertTo(a, typeof(Single));
            Console.WriteLine(b);
             */
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, Single>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, Single>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, Single>(2));

            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, Single>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, Single>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, Single>(2));
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, Single>(null));

            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, Single?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, Single?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, Single?>(2).Value);

            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, Single?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, Single?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, Single?>(2).Value);
            Assert.IsNull(PrimitiveMapper.Map<UInt16?, Single?>(null));
        }
        [TestMethod]
        public virtual void ToDouble()
        {
            /*UInt16 a = 4;
            Double b;
            b = a;
            b = (Double)a;
            b = (Double)Convert.ChangeType(a, typeof(Double));
            b = Convert.ToDouble(a);
            var converter = TypeDescriptor.GetConverter(typeof(Double));
            //b = (Double)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(UInt16));
            b = (Double)converter.ConvertTo(a, typeof(Double));
            Console.WriteLine(b);*/
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, Double>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, Double>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, Double>(2));

            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, Double>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, Double>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, Double>(2));
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, Double>(null));

            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, Double?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, Double?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, Double?>(2).Value);

            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, Double?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, Double?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, Double?>(2).Value);
            Assert.IsNull(PrimitiveMapper.Map<UInt16?, Double?>(null));
        }
        [TestMethod]
        public virtual void ToDecimal()
        {
            /*UInt16 a = 4;
            Decimal b;
            b = a;
            b = (Decimal)a;
            b = (Decimal)Convert.ChangeType(a, typeof(Decimal));
            b = Convert.ToDecimal(a);
            //var converter = TypeDescriptor.GetConverter(typeof(Decimal));
            //b = (Decimal)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(UInt16));
            //b = (Decimal)converter.ConvertTo(a, typeof(Decimal));
            Console.WriteLine(b);*/
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, decimal>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, decimal>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, decimal>(2));

            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, decimal>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, decimal>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, decimal>(2));
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, decimal>(null));

            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, decimal?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, decimal?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, decimal?>(2).Value);

            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, decimal?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, decimal?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, decimal?>(2).Value);
            Assert.IsNull(PrimitiveMapper.Map<UInt16?, decimal?>(null));
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        //[ExpectedException(typeof(NotSupportedException))]
        public virtual void ToDateTime()
        {
            /*UInt16 a = 4;
            DateTime b;
             //b = a;
            //b = (DateTime)a;
            //b = (DateTime)Convert.ChangeType(a, typeof(DateTime));
            //b = Convert.ToDateTime(a);
            var converter = TypeDescriptor.GetConverter(typeof(DateTime));
            b = (DateTime)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(UInt16));
            //b = (DateTime)converter.ConvertTo(a, typeof(DateTime));
            Console.WriteLine(b);*/
            Assert.IsNull(PrimitiveMapper.Map<UInt16, DateTime>(0));
        }
        [TestMethod]
        public virtual void ToSString()
        {
            /*UInt16 a = 4;
            String b;
            //b = a;
            //b = (String)a;
            b = (String)Convert.ChangeType(a, typeof(String));
            b = Convert.ToString(a);
            var converter = TypeDescriptor.GetConverter(typeof(String));
            //b = (String)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(UInt16));
            b = (String)converter.ConvertTo(a, typeof(String));
            Console.WriteLine(b);*/
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, string>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, string>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16, string>(2));

            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, string>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, string>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<UInt16?, string>(2));
            Assert.IsNull(PrimitiveMapper.Map<UInt16?, string>(null));
        }
        [TestMethod]
        public virtual void Parse()
        {
            UInt16 a = 4;
            String b = "12";
            //b = "1";
            //b = "0";
            a = UInt16.Parse(b);
            Console.WriteLine(a);
        }
    }
    [TestClass]
    public class SingleConvertTest
    {
        //[ExpectedException(typeof(NotSupportedException))]
        [TestMethod]
        public virtual void ToBoolean()
        {
            /*Single a = 4;
            Boolean b;
            //b = a;
            //b = (Boolean)a;
            b = Convert.ToBoolean(a);

            b = (Boolean)Convert.ChangeType(a, typeof(Boolean));
            var converter = TypeDescriptor.GetConverter(typeof(Boolean));
            //b = (Boolean)converter.ConvertFrom(a);

            converter = TypeDescriptor.GetConverter(typeof(Single));
            b = (Boolean)converter.ConvertTo(a, typeof(Boolean));
            Console.WriteLine(b);*/
            Assert.IsTrue(PrimitiveMapper.Map<Single, bool>(-1F));
            Assert.IsFalse(PrimitiveMapper.Map<Single, bool>(0F));
            Assert.IsTrue(PrimitiveMapper.Map<Single, bool>(1F));
            Assert.IsTrue(PrimitiveMapper.Map<Single, bool>(2.6F));

            Assert.IsTrue(PrimitiveMapper.Map<Single?, bool>(-1F));
            Assert.IsFalse(PrimitiveMapper.Map<Single?, bool>(0F));
            Assert.IsTrue(PrimitiveMapper.Map<Single?, bool>(1F));
            Assert.IsTrue(PrimitiveMapper.Map<Single?, bool>(2.789F));
            Assert.IsFalse(PrimitiveMapper.Map<Single?, bool>(null));

            Assert.IsTrue(PrimitiveMapper.Map<Single, bool?>(-1F).Value);
            Assert.IsTrue(PrimitiveMapper.Map<Single, bool?>(0F).Value == false);
            Assert.IsTrue(PrimitiveMapper.Map<Single, bool?>(1F).Value == true);
            Assert.IsTrue(PrimitiveMapper.Map<Single, bool?>(2.789F).Value == true);

            Assert.IsTrue(PrimitiveMapper.Map<Single?, bool?>(-1F).Value == true);
            Assert.IsTrue(PrimitiveMapper.Map<Single?, bool?>(0F).Value == false);
            Assert.IsTrue(PrimitiveMapper.Map<Single?, bool?>(1F).Value == true);
            Assert.IsTrue(PrimitiveMapper.Map<Single?, bool?>(2.789F).Value == true);

            Assert.IsNull(PrimitiveMapper.Map<Single?, bool?>(null));
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        public virtual void ToChar()
        {
            /*Single a = 4;
            Char b;
            //b = a;
            b = (Char)a;
            //b = (Char)Convert.ChangeType(a, typeof(Char));
            //b = Convert.ToChar(a);
            //var converter = TypeDescriptor.GetConverter(typeof(Char));
            //b = (Char)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(Single));
            //b = (Char)converter.ConvertTo(a, typeof(Char));
            Console.WriteLine(b);*/
            Assert.IsNull(PrimitiveMapper.Map<Single, char>(1F));
        }
        [TestMethod]
        public virtual void ToSByte()
        {
            /*Single a = 4;
            SByte b;
            //b = a;
            b = (SByte)a;
            b = (SByte)Convert.ChangeType(a, typeof(SByte));
            b = Convert.ToSByte(a);
            var converter = TypeDescriptor.GetConverter(typeof(SByte));
            //b = (SByte)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(Single));
            b = (SByte)converter.ConvertTo(a, typeof(SByte));
            Console.WriteLine(b);*/
            Assert.IsNotNull(PrimitiveMapper.Map<Single, sbyte>(-1F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single, sbyte>(0F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single, sbyte>(1F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single, sbyte>(2.6F));

            Assert.IsNotNull(PrimitiveMapper.Map<Single?, sbyte>(-1F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, sbyte>(0F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, sbyte>(1F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, sbyte>(2.789F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, sbyte>(null));

            Assert.IsNotNull(PrimitiveMapper.Map<Single, sbyte?>(-1F).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Single, sbyte?>(0F).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Single, sbyte?>(1F).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Single, sbyte?>(2.789F).Value);

            Assert.IsNotNull(PrimitiveMapper.Map<Single?, sbyte?>(-1F).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, sbyte?>(0F).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, sbyte?>(1F).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, sbyte?>(2.789F).Value);
            Assert.IsNull(PrimitiveMapper.Map<Single?, sbyte?>(null));
        }
        [TestMethod]
        public virtual void ToByte()
        {
            /*Single a = 252;
            Byte b;
            //b = a;
            b = (Byte)a;
            b = (Byte)Convert.ChangeType(a, typeof(Byte));
            b = Convert.ToByte(a);
            var converter = TypeDescriptor.GetConverter(typeof(Byte));
            //b = (Byte)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(Single));
            b = (Byte)converter.ConvertTo(a, typeof(Byte));
            Console.WriteLine(b);*/
            //Assert.IsNotNull(PrimitiveMapper.Map<Single, byte>(-1F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single, byte>(0F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single, byte>(1F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single, byte>(2.6F));

            //Assert.IsNotNull(PrimitiveMapper.Map<Single?, byte>(-1F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, byte>(0F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, byte>(1F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, byte>(2.789F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, byte>(null));

            //Assert.IsNotNull(PrimitiveMapper.Map<Single, byte?>(-1F).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Single, byte?>(0F).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Single, byte?>(1F).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Single, byte?>(2.789F).Value);

            //Assert.IsNotNull(PrimitiveMapper.Map<Single?, byte?>(-1F).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, byte?>(0F).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, byte?>(1F).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, byte?>(2.789F).Value);
            Assert.IsNull(PrimitiveMapper.Map<Single?, byte?>(null));
        }
        [TestMethod]
        public virtual void ToInt16()
        {
            /*Single a = 4;
            Int16 b;
            //b = a;
            b = (Int16)a;
            b = (Int16)Convert.ChangeType(a, typeof(Int16));
            b = Convert.ToInt16(a);
            var converter = TypeDescriptor.GetConverter(typeof(Int16));
            //b = (Int16)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(Single));
            b = (Int16)converter.ConvertTo(a, typeof(Int16));
            Console.WriteLine(b);*/
            Assert.IsNotNull(PrimitiveMapper.Map<Single, Int16>(-1F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single, Int16>(0F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single, Int16>(1F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single, Int16>(2.6F));

            Assert.IsNotNull(PrimitiveMapper.Map<Single?, Int16>(-1F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, Int16>(0F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, Int16>(1F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, Int16>(2.789F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, Int16>(null));

            Assert.IsNotNull(PrimitiveMapper.Map<Single, Int16?>(-1F).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Single, Int16?>(0F).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Single, Int16?>(1F).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Single, Int16?>(2.789F).Value);

            Assert.IsNotNull(PrimitiveMapper.Map<Single?, Int16?>(-1F).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, Int16?>(0F).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, Int16?>(1F).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, Int16?>(2.789F).Value);
            Assert.IsNull(PrimitiveMapper.Map<Single?, Int16?>(null));
        }
        [TestMethod]
        public virtual void ToUInt16()
        {
            /*Single a = 4;
            UInt16 b;
           // b = a;
            b = (UInt16)a;
            b = (UInt16)Convert.ChangeType(a, typeof(UInt16));
            b = Convert.ToUInt16(a);
            var converter = TypeDescriptor.GetConverter(typeof(UInt16));
           // b = (UInt16)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(Single));
            b = (UInt16)converter.ConvertTo(a, typeof(UInt16));
            Console.WriteLine(b);*/
            //Assert.IsNotNull(PrimitiveMapper.Map<Single, UInt16>(-1F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single, UInt16>(0F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single, UInt16>(1F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single, UInt16>(2.6F));

            //Assert.IsNotNull(PrimitiveMapper.Map<Single?, UInt16>(-1F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, UInt16>(0F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, UInt16>(1F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, UInt16>(2.789F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, UInt16>(null));

            //Assert.IsNotNull(PrimitiveMapper.Map<Single, UInt16?>(-1F).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Single, UInt16?>(0F).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Single, UInt16?>(1F).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Single, UInt16?>(2.789F).Value);

            // Assert.IsNotNull(PrimitiveMapper.Map<Single?, UInt16?>(-1F).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, UInt16?>(0F).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, UInt16?>(1F).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, UInt16?>(2.789F).Value);
            Assert.IsNull(PrimitiveMapper.Map<Single?, UInt16?>(null));
        }
        [TestMethod]
        public virtual void ToInt32()
        {
            /*Single a = 4;
            Int32 b;
            //b = a;
            b = (Int32)a;
            b = (Int32)Convert.ChangeType(a, typeof(Int32));
            b = Convert.ToInt32(a);
            var converter = TypeDescriptor.GetConverter(typeof(Int32));
            //b = (Int32)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(Single));
            b = (Int32)converter.ConvertTo(a, typeof(Int32));
            Console.WriteLine(b);
             */
            Assert.IsNotNull(PrimitiveMapper.Map<Single, Int32>(-1F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single, Int32>(0F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single, Int32>(1F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single, Int32>(2.6F));

            Assert.IsNotNull(PrimitiveMapper.Map<Single?, Int32>(-1F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, Int32>(0F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, Int32>(1F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, Int32>(2.789F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, Int32>(null));

            Assert.IsNotNull(PrimitiveMapper.Map<Single, Int32?>(-1F).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Single, Int32?>(0F).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Single, Int32?>(1F).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Single, Int32?>(2.789F).Value);

            Assert.IsNotNull(PrimitiveMapper.Map<Single?, Int32?>(-1F).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, Int32?>(0F).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, Int32?>(1F).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, Int32?>(2.789F).Value);
            Assert.IsNull(PrimitiveMapper.Map<Single?, Int32?>(null));
        }
        [TestMethod]
        public virtual void ToUInt32()
        {
            /*Single a = 4;
            UInt32 b;
            //b = a;
            b = (UInt32)a;
            b = (UInt32)Convert.ChangeType(a, typeof(UInt32));
            b = Convert.ToUInt32(a);
            var converter = TypeDescriptor.GetConverter(typeof(UInt32));
            //b = (UInt32)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(Single));
            b = (UInt32)converter.ConvertTo(a, typeof(UInt32));
            Console.WriteLine(b);*/
            //Assert.IsNotNull(PrimitiveMapper.Map<Single, UInt32>(-1F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single, UInt32>(0F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single, UInt32>(1F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single, UInt32>(2.6F));

            //Assert.IsNotNull(PrimitiveMapper.Map<Single?, UInt32>(-1F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, UInt32>(0F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, UInt32>(1F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, UInt32>(2.789F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, UInt32>(null));

            //Assert.IsNotNull(PrimitiveMapper.Map<Single, UInt32?>(-1F).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Single, UInt32?>(0F).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Single, UInt32?>(1F).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Single, UInt32?>(2.789F).Value);

            //Assert.IsNotNull(PrimitiveMapper.Map<Single?, UInt32?>(-1F).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, UInt32?>(0F).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, UInt32?>(1F).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, UInt32?>(2.789F).Value);
            Assert.IsNull(PrimitiveMapper.Map<Single?, UInt32?>(null));
        }
        [TestMethod]
        public virtual void ToInt64()
        {
            /*Single a = 4;
            Int64 b;
           // b = a;
            b = (Int64)a;
            b = (Int64)Convert.ChangeType(a, typeof(Int64));
            b = Convert.ToInt64(a);
            var converter = TypeDescriptor.GetConverter(typeof(Int64));
            //b = (Int64)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(Single));
            b = (Int64)converter.ConvertTo(a, typeof(Int64));
            Console.WriteLine(b);*/
            Assert.IsNotNull(PrimitiveMapper.Map<Single, Int64>(-1F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single, Int64>(0F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single, Int64>(1F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single, Int64>(2.6F));

            Assert.IsNotNull(PrimitiveMapper.Map<Single?, Int64>(-1F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, Int64>(0F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, Int64>(1F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, Int64>(2.789F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, Int64>(null));

            Assert.IsNotNull(PrimitiveMapper.Map<Single, Int64?>(-1F).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Single, Int64?>(0F).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Single, Int64?>(1F).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Single, Int64?>(2.789F).Value);

            Assert.IsNotNull(PrimitiveMapper.Map<Single?, Int64?>(-1F).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, Int64?>(0F).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, Int64?>(1F).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, Int64?>(2.789F).Value);
            Assert.IsNull(PrimitiveMapper.Map<Single?, Int64?>(null));
        }
        [TestMethod]
        public virtual void ToUInt64()
        {
            /*Single a = 4;
            UInt64 b;
            //b = a;
            b = (UInt64)a;
            b = (UInt64)Convert.ChangeType(a, typeof(UInt64));
            b = Convert.ToUInt64(a);
            var converter = TypeDescriptor.GetConverter(typeof(UInt64));
            //b = (UInt64)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(Single));
            b = (UInt64)converter.ConvertTo(a, typeof(UInt64));
            Console.WriteLine(b);*/
            //Assert.IsNotNull(PrimitiveMapper.Map<Single, UInt64>(-0.6F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single, UInt64>(0F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single, UInt64>(1F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single, UInt64>(2.6F));

            //Assert.IsNotNull(PrimitiveMapper.Map<Single?, UInt64>(-1F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, UInt64>(0F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, UInt64>(1F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, UInt64>(2.789F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, UInt64>(null));

            //Assert.IsNotNull(PrimitiveMapper.Map<Single, UInt64?>(-1F).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Single, UInt64?>(0F).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Single, UInt64?>(1F).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Single, UInt64?>(2.789F).Value);

            //Assert.IsNotNull(PrimitiveMapper.Map<Single?, UInt64?>(-1F).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, UInt64?>(0.4F).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, UInt64?>(1F).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, UInt64?>(2.789F).Value);
            Assert.IsNull(PrimitiveMapper.Map<Single?, UInt64?>(null));
            Single s = -1;
            UInt64 u = (UInt64)s;
            Console.WriteLine(u);//18446744073709551615
        }
        [TestMethod]
        public virtual void ToSingle()
        {
            /*Single a = 4;
            Single b;
            b = a;
            b = (Single)a;
            b = (Single)Convert.ChangeType(a, typeof(Single));
            b = Convert.ToSingle(a);
            var converter = TypeDescriptor.GetConverter(typeof(Single));
           // b = (Single)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(Single));
            b = (Single)converter.ConvertTo(a, typeof(Single));
            Console.WriteLine(b);*/
            Assert.IsNotNull(PrimitiveMapper.Map<Single, Single>(-1F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single, Single>(0F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single, Single>(1F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single, Single>(2.6F));

            Assert.IsNotNull(PrimitiveMapper.Map<Single?, Single>(-1F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, Single>(0F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, Single>(1F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, Single>(2.789F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, Single>(null));

            Assert.IsNotNull(PrimitiveMapper.Map<Single, Single?>(-1F).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Single, Single?>(0F).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Single, Single?>(1F).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Single, Single?>(2.789F).Value);

            Assert.IsNotNull(PrimitiveMapper.Map<Single?, Single?>(-1F).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, Single?>(0F).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, Single?>(1F).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, Single?>(2.789F).Value);
            Assert.IsNull(PrimitiveMapper.Map<Single?, Single?>(null));
        }
        [TestMethod]
        public virtual void ToDouble()
        {
            /*Single a = 4;
            Double b;
            b = a;
            b = (Double)a;
            b = (Double)Convert.ChangeType(a, typeof(Double));
            b = Convert.ToDouble(a);
            var converter = TypeDescriptor.GetConverter(typeof(Double));
            //b = (Double)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(Single));
            b = (Double)converter.ConvertTo(a, typeof(Double));
            Console.WriteLine(b);*/
            Assert.IsNotNull(PrimitiveMapper.Map<Single, double>(-1F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single, double>(0F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single, double>(1F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single, double>(2.6F));

            Assert.IsNotNull(PrimitiveMapper.Map<Single?, double>(-1F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, double>(0F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, double>(1F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, double>(2.789F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, double>(null));

            Assert.IsNotNull(PrimitiveMapper.Map<Single, double?>(-1F).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Single, double?>(0F).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Single, double?>(1F).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Single, double?>(2.789F).Value);

            Assert.IsNotNull(PrimitiveMapper.Map<Single?, double?>(-1F).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, double?>(0F).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, double?>(1F).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, double?>(2.789F).Value);
            Assert.IsNull(PrimitiveMapper.Map<Single?, double?>(null));
        }
        [TestMethod]
        public virtual void ToDecimal()
        {
            /*Single a = 4;
            Decimal b;
            //b = a;
            b = (Decimal)a;
            b = (Decimal)Convert.ChangeType(a, typeof(Decimal));
            b = Convert.ToDecimal(a);
            //var converter = TypeDescriptor.GetConverter(typeof(Decimal));
            //b = (Decimal)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(Single));
            //b = (Decimal)converter.ConvertTo(a, typeof(Decimal));
            Console.WriteLine(b);*/
            Assert.IsNotNull(PrimitiveMapper.Map<Single, decimal>(-1F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single, decimal>(0F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single, decimal>(1F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single, decimal>(2.6F));

            Assert.IsNotNull(PrimitiveMapper.Map<Single?, decimal>(-1F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, decimal>(0F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, decimal>(1F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, decimal>(2.789F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, decimal>(null));

            Assert.IsNotNull(PrimitiveMapper.Map<Single, decimal?>(-1F).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Single, decimal?>(0F).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Single, decimal?>(1F).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Single, decimal?>(2.789F).Value);

            Assert.IsNotNull(PrimitiveMapper.Map<Single?, decimal?>(-1F).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, decimal?>(0F).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, decimal?>(1F).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, decimal?>(2.789F).Value);
            Assert.IsNull(PrimitiveMapper.Map<Single?, decimal?>(null));
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        //[ExpectedException(typeof(NotSupportedException))]
        public virtual void ToDateTime()
        {
            /*Single a = 4;
            DateTime b;
            //b = a;
            //b = (DateTime)a;
            //b = (DateTime)Convert.ChangeType(a, typeof(DateTime));
            //b = Convert.ToDateTime(a);
            var converter = TypeDescriptor.GetConverter(typeof(DateTime));
            b = (DateTime)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(Single));
            //b = (DateTime)converter.ConvertTo(a, typeof(DateTime));
            Console.WriteLine(b);*/
            Assert.IsNull(PrimitiveMapper.Map<Single, DateTime>(0));
        }
        [TestMethod]
        public virtual void ToSString()
        {
            /*Single a = 4;
            String b;
            //b = a;
            //b = (String)a;
            b = (String)Convert.ChangeType(a, typeof(String));
            b = Convert.ToString(a);
            var converter = TypeDescriptor.GetConverter(typeof(String));
            //b = (String)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(Single));
            b = (String)converter.ConvertTo(a, typeof(String));
            Console.WriteLine(b);*/
            Assert.IsNotNull(PrimitiveMapper.Map<Single, string>(-1F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single, string>(0F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single, string>(1F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single, string>(2.6F));

            Assert.IsNotNull(PrimitiveMapper.Map<Single?, string>(-1F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, string>(0F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, string>(1F));
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, string>(2.789F));
            Assert.IsNull(PrimitiveMapper.Map<Single?, string>(null));
            Single si = -1F;
            string st = si.ToString();
            Console.WriteLine(st);
        }
        [TestMethod]
        public virtual void Parse()
        {
            Single a = 4;
            String b = "-12";
            //b = "1";
            //b = "0";
            a = Single.Parse(b);
            Console.WriteLine(a);
        }
    }
    [TestClass]
    public class DoubleConvertTest
    {
        //[ExpectedException(typeof(NotSupportedException))]
        [TestMethod]
        public virtual void ToBoolean()
        {
            /*Double a = 4;
            Boolean b;
           // b = a;
            //b = (Boolean)a;
            b = Convert.ToBoolean(a);

            b = (Boolean)Convert.ChangeType(a, typeof(Boolean));
            var converter = TypeDescriptor.GetConverter(typeof(Boolean));
           // b = (Boolean)converter.ConvertFrom(a);

            converter = TypeDescriptor.GetConverter(typeof(Double));
            b = (Boolean)converter.ConvertTo(a, typeof(Boolean));
            Console.WriteLine(b);*/
            Assert.IsTrue(PrimitiveMapper.Map<double, bool>(-1));
            Assert.IsFalse(PrimitiveMapper.Map<double, bool>(0));
            Assert.IsTrue(PrimitiveMapper.Map<double, bool>(1));
            Assert.IsTrue(PrimitiveMapper.Map<double, bool>(2.6));

            Assert.IsTrue(PrimitiveMapper.Map<double?, bool>(-1));
            Assert.IsFalse(PrimitiveMapper.Map<double?, bool>(0));
            Assert.IsTrue(PrimitiveMapper.Map<double?, bool>(1));
            Assert.IsTrue(PrimitiveMapper.Map<double?, bool>(2.789));
            Assert.IsFalse(PrimitiveMapper.Map<double?, bool>(null));

            Assert.IsTrue(PrimitiveMapper.Map<double, bool?>(-1).Value);
            Assert.IsTrue(PrimitiveMapper.Map<double, bool?>(0).Value == false);
            Assert.IsTrue(PrimitiveMapper.Map<double, bool?>(1).Value == true);
            Assert.IsTrue(PrimitiveMapper.Map<double, bool?>(2.789).Value == true);

            Assert.IsTrue(PrimitiveMapper.Map<double?, bool?>(-1).Value == true);
            Assert.IsTrue(PrimitiveMapper.Map<double?, bool?>(0).Value == false);
            Assert.IsTrue(PrimitiveMapper.Map<double?, bool?>(1).Value == true);
            Assert.IsTrue(PrimitiveMapper.Map<double?, bool?>(2.789).Value == true);
            Assert.IsNull(PrimitiveMapper.Map<double?, bool?>(null));
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        public virtual void ToChar()
        {
            /*Double a = 4.0;
            Char b;
            //b = a;
            b = (Char)a;
            //b = (Char)Convert.ChangeType(a, typeof(Char));
            //b = Convert.ToChar(a);
            //var converter = TypeDescriptor.GetConverter(typeof(Char));
            //b = (Char)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(Double));
            //b = (Char)converter.ConvertTo(a, typeof(Char));
            Console.WriteLine(b);*/
            Assert.IsNull(PrimitiveMapper.Map<double, char>(0));
        }
        [TestMethod]
        public virtual void ToSByte()
        {
            /*Double a = 4.0;
            SByte b;
            //b = a;
            b = (SByte)a;
            b = (SByte)Convert.ChangeType(a, typeof(SByte));
            b = Convert.ToSByte(a);
            var converter = TypeDescriptor.GetConverter(typeof(SByte));
            //b = (SByte)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(Double));
            b = (SByte)converter.ConvertTo(a, typeof(SByte));
            Console.WriteLine(b);*/
            Assert.IsNotNull(PrimitiveMapper.Map<double, sbyte>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<double, sbyte>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<double, sbyte>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<double, sbyte>(2.6));

            Assert.IsNotNull(PrimitiveMapper.Map<double?, sbyte>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<double?, sbyte>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<double?, sbyte>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<double?, sbyte>(2.789));
            Assert.IsNotNull(PrimitiveMapper.Map<double?, sbyte>(null));

            Assert.IsNotNull(PrimitiveMapper.Map<double, sbyte?>(-1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<double, sbyte?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<double, sbyte?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<double, sbyte?>(2.789).Value);

            Assert.IsNotNull(PrimitiveMapper.Map<double?, sbyte?>(-1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<double?, sbyte?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<double?, sbyte?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<double?, sbyte?>(2.789).Value);
            Assert.IsNull(PrimitiveMapper.Map<double?, sbyte?>(null));
        }
        [TestMethod]
        public virtual void ToByte()
        {
            /*Double a = 25.2;
            Byte b;
            //b = a;
            b = (Byte)a;
            b = (Byte)Convert.ChangeType(a, typeof(Byte));
            b = Convert.ToByte(a);
            var converter = TypeDescriptor.GetConverter(typeof(Byte));
           // b = (Byte)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(Double));
            b = (Byte)converter.ConvertTo(a, typeof(Byte));
            Console.WriteLine(b);*/
            //Assert.IsNotNull(PrimitiveMapper.Map<double, byte>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<double, byte>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<double, byte>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<double, byte>(2.6));

            //Assert.IsNotNull(PrimitiveMapper.Map<double?, byte>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<double?, byte>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<double?, byte>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<double?, byte>(2.789));
            Assert.IsNotNull(PrimitiveMapper.Map<double?, byte>(null));

            //Assert.IsNotNull(PrimitiveMapper.Map<double, byte?>(-1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<double, byte?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<double, byte?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<double, byte?>(2.789).Value);

            //Assert.IsNotNull(PrimitiveMapper.Map<double?, byte?>(-1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<double?, byte?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<double?, byte?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<double?, byte?>(2.789).Value);
            Assert.IsNull(PrimitiveMapper.Map<double?, byte?>(null));
        }
        [TestMethod]
        public virtual void ToInt16()
        {
            /*Double a = 4.6;
            Int16 b;
            //b = a;
            b = (Int16)a;
            b = (Int16)Convert.ChangeType(a, typeof(Int16));
            b = Convert.ToInt16(a);
            var converter = TypeDescriptor.GetConverter(typeof(Int16));
            //b = (Int16)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(Double));
            b = (Int16)converter.ConvertTo(a, typeof(Int16));
            Console.WriteLine(b);*/
            Assert.IsNotNull(PrimitiveMapper.Map<double, Int16>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<double, Int16>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<double, Int16>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<double, Int16>(2.6));

            Assert.IsNotNull(PrimitiveMapper.Map<double?, Int16>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<double?, Int16>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<double?, Int16>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<double?, Int16>(2.789));
            Assert.IsNotNull(PrimitiveMapper.Map<double?, Int16>(null));

            Assert.IsNotNull(PrimitiveMapper.Map<double, Int16?>(-1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<double, Int16?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<double, Int16?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<double, Int16?>(2.789).Value);

            Assert.IsNotNull(PrimitiveMapper.Map<double?, Int16?>(-1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<double?, Int16?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<double?, Int16?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<double?, Int16?>(2.789).Value);
            Assert.IsNull(PrimitiveMapper.Map<double?, Int16?>(null));
        }
        [TestMethod]
        public virtual void ToUInt16()
        {
            /*Double a = 4.2;
            UInt16 b;
             //b = a;
            b = (UInt16)a;
            b = (UInt16)Convert.ChangeType(a, typeof(UInt16));
            b = Convert.ToUInt16(a);
            var converter = TypeDescriptor.GetConverter(typeof(UInt16));
             //b = (UInt16)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(Double));
            b = (UInt16)converter.ConvertTo(a, typeof(UInt16));
            Console.WriteLine(b);*/
            //Assert.IsNotNull(PrimitiveMapper.Map<double, UInt16>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<double, UInt16>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<double, UInt16>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<double, UInt16>(2.6));

            //Assert.IsNotNull(PrimitiveMapper.Map<double?, UInt16>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<double?, UInt16>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<double?, UInt16>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<double?, UInt16>(2.789));
            Assert.IsNotNull(PrimitiveMapper.Map<double?, UInt16>(null));

            //Assert.IsNotNull(PrimitiveMapper.Map<double, UInt16?>(-1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<double, UInt16?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<double, UInt16?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<double, UInt16?>(2.789).Value);

            //Assert.IsNotNull(PrimitiveMapper.Map<double?, UInt16?>(-1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<double?, UInt16?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<double?, UInt16?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<double?, UInt16?>(2.789).Value);
            Assert.IsNull(PrimitiveMapper.Map<double?, UInt16?>(null));
        }
        [TestMethod]
        public virtual void ToInt32()
        {
            /*Double a = 4.5;
            Int32 b;
            //b = a;
            b = (Int32)a;
            b = (Int32)Convert.ChangeType(a, typeof(Int32));
            b = Convert.ToInt32(a);
            var converter = TypeDescriptor.GetConverter(typeof(Int32));
            //b = (Int32)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(Double));
            b = (Int32)converter.ConvertTo(a, typeof(Int32));
            Console.WriteLine(b);*/
            Assert.IsNotNull(PrimitiveMapper.Map<double, Int32>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<double, Int32>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<double, Int32>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<double, Int32>(2.6));

            Assert.IsNotNull(PrimitiveMapper.Map<double?, Int32>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<double?, Int32>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<double?, Int32>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<double?, Int32>(2.789));
            Assert.IsNotNull(PrimitiveMapper.Map<double?, Int32>(null));

            Assert.IsNotNull(PrimitiveMapper.Map<double, Int32?>(-1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<double, Int32?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<double, Int32?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<double, Int32?>(2.789).Value);

            Assert.IsNotNull(PrimitiveMapper.Map<double?, Int32?>(-1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<double?, Int32?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<double?, Int32?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<double?, Int32?>(2.789).Value);
            Assert.IsNull(PrimitiveMapper.Map<double?, Int32?>(null));
        }
        [TestMethod]
        public virtual void ToUInt32()
        {
            /*Double a = 4.6;
            UInt32 b;
            //b = a;
            b = (UInt32)a;
            b = (UInt32)Convert.ChangeType(a, typeof(UInt32));
            b = Convert.ToUInt32(a);
            var converter = TypeDescriptor.GetConverter(typeof(UInt32));
            //b = (UInt32)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(Double));
            b = (UInt32)converter.ConvertTo(a, typeof(UInt32));
            Console.WriteLine(b);*/
            //Assert.IsNotNull(PrimitiveMapper.Map<double, UInt32>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<double, UInt32>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<double, UInt32>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<double, UInt32>(2.6));

            //Assert.IsNotNull(PrimitiveMapper.Map<double?, UInt32>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<double?, UInt32>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<double?, UInt32>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<double?, UInt32>(2.789));
            Assert.IsNotNull(PrimitiveMapper.Map<double?, UInt32>(null));

            //Assert.IsNotNull(PrimitiveMapper.Map<double, UInt32?>(-0.22).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<double, UInt32?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<double, UInt32?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<double, UInt32?>(2.789).Value);

            //Assert.IsNotNull(PrimitiveMapper.Map<double?, UInt32?>(-1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<double?, UInt32?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<double?, UInt32?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<double?, UInt32?>(2.789).Value);
            Assert.IsNull(PrimitiveMapper.Map<double?, UInt32?>(null));
        }
        [TestMethod]
        public virtual void ToInt64()
        {
            /*Double a = 4.33;
            Int64 b;
            //b = a;
            b = (Int64)a;
            b = (Int64)Convert.ChangeType(a, typeof(Int64));
            b = Convert.ToInt64(a);
            var converter = TypeDescriptor.GetConverter(typeof(Int64));
           // b = (Int64)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(Double));
            b = (Int64)converter.ConvertTo(a, typeof(Int64));
            Console.WriteLine(b);*/
            Assert.IsNotNull(PrimitiveMapper.Map<double, Int64>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<double, Int64>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<double, Int64>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<double, Int64>(2.6));

            Assert.IsNotNull(PrimitiveMapper.Map<double?, Int64>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<double?, Int64>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<double?, Int64>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<double?, Int64>(2.789));
            Assert.IsNotNull(PrimitiveMapper.Map<double?, Int64>(null));

            Assert.IsNotNull(PrimitiveMapper.Map<double, Int64?>(-1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<double, Int64?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<double, Int64?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<double, Int64?>(2.789).Value);

            Assert.IsNotNull(PrimitiveMapper.Map<double?, Int64?>(-1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<double?, Int64?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<double?, Int64?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<double?, Int64?>(2.789).Value);
            Assert.IsNull(PrimitiveMapper.Map<double?, Int64?>(null));
        }
        [TestMethod]
        public virtual void ToUInt64()
        {
            /*Double a = 4.89;
            UInt64 b;
            //b = a;
            b = (UInt64)a;
            b = (UInt64)Convert.ChangeType(a, typeof(UInt64));
            b = Convert.ToUInt64(a);
            var converter = TypeDescriptor.GetConverter(typeof(UInt64));
            //b = (UInt64)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(Double));
            b = (UInt64)converter.ConvertTo(a, typeof(UInt64));
            Console.WriteLine(b);*/
            //Assert.IsNotNull(PrimitiveMapper.Map<double, UInt64>(-0.22));
            Assert.IsNotNull(PrimitiveMapper.Map<double, UInt64>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<double, UInt64>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<double, UInt64>(2.6));

            //Assert.IsNotNull(PrimitiveMapper.Map<double?, UInt64>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<double?, UInt64>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<double?, UInt64>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<double?, UInt64>(2.789));
            Assert.IsNotNull(PrimitiveMapper.Map<double?, UInt64>(null));

            //Assert.IsNotNull(PrimitiveMapper.Map<double, UInt64?>(-1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<double, UInt64?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<double, UInt64?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<double, UInt64?>(2.789).Value);

            //Assert.IsNotNull(PrimitiveMapper.Map<double?, UInt64?>(-1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<double?, UInt64?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<double?, UInt64?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<double?, UInt64?>(2.789).Value);
            Assert.IsNull(PrimitiveMapper.Map<double?, UInt64?>(null));
        }
        [TestMethod]
        public virtual void ToSingle()
        {
            /*Double a = 4.49;
            Single b;
            //b = a;
            b = (Single)a;
            b = (Single)Convert.ChangeType(a, typeof(Single));
            b = Convert.ToSingle(a);
            var converter = TypeDescriptor.GetConverter(typeof(Single));
             //b = (Single)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(Double));
            b = (Single)converter.ConvertTo(a, typeof(Single));
            Console.WriteLine(b);*/
            Assert.IsNotNull(PrimitiveMapper.Map<double, Single>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<double, Single>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<double, Single>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<double, Single>(2.6));

            Assert.IsNotNull(PrimitiveMapper.Map<double?, Single>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<double?, Single>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<double?, Single>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<double?, Single>(2.789));
            Assert.IsNotNull(PrimitiveMapper.Map<double?, Single>(null));

            Assert.IsNotNull(PrimitiveMapper.Map<double, Single?>(-1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<double, Single?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<double, Single?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<double, Single?>(2.789).Value);

            Assert.IsNotNull(PrimitiveMapper.Map<double?, Single?>(-1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<double?, Single?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<double?, Single?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<double?, Single?>(2.789).Value);
            Assert.IsNull(PrimitiveMapper.Map<double?, Single?>(null));
        }
        [TestMethod]
        public virtual void ToDouble()
        {
            /*Double a = 4.99;
            Double b;
            b = a;
            b = (Double)a;
            b = (Double)Convert.ChangeType(a, typeof(Double));
            b = Convert.ToDouble(a);
            var converter = TypeDescriptor.GetConverter(typeof(Double));
            //b = (Double)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(Double));
            b = (Double)converter.ConvertTo(a, typeof(Double));
            Console.WriteLine(b);*/
            Assert.IsNotNull(PrimitiveMapper.Map<double, double>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<double, double>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<double, double>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<double, double>(2.6));

            Assert.IsNotNull(PrimitiveMapper.Map<double?, double>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<double?, double>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<double?, double>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<double?, double>(2.789));
            Assert.IsNotNull(PrimitiveMapper.Map<double?, double>(null));

            Assert.IsNotNull(PrimitiveMapper.Map<double, double?>(-1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<double, double?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<double, double?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<double, double?>(2.789).Value);

            Assert.IsNotNull(PrimitiveMapper.Map<double?, double?>(-1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<double?, double?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<double?, double?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<double?, double?>(2.789).Value);
            Assert.IsNull(PrimitiveMapper.Map<double?, double?>(null));
        }
        [TestMethod]
        public virtual void ToDecimal()
        {
            /*Double a = 4.72;
            Decimal b;
            //b = a;
            b = (Decimal)a;
            b = (Decimal)Convert.ChangeType(a, typeof(Decimal));
            b = Convert.ToDecimal(a);
            //var converter = TypeDescriptor.GetConverter(typeof(Decimal));
           //b = (Decimal)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(Double));
            //b = (Decimal)converter.ConvertTo(a, typeof(Decimal));
            Console.WriteLine(b);*/
            Assert.IsNotNull(PrimitiveMapper.Map<double, decimal>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<double, decimal>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<double, decimal>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<double, decimal>(2.6));

            Assert.IsNotNull(PrimitiveMapper.Map<double?, decimal>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<double?, decimal>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<double?, decimal>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<double?, decimal>(2.789));
            Assert.IsNotNull(PrimitiveMapper.Map<double?, decimal>(null));

            Assert.IsNotNull(PrimitiveMapper.Map<double, decimal?>(-1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<double, decimal?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<double, decimal?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<double, decimal?>(2.789).Value);

            Assert.IsNotNull(PrimitiveMapper.Map<double?, decimal?>(-1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<double?, decimal?>(0).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<double?, decimal?>(1).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<double?, decimal?>(2.789).Value);
            Assert.IsNull(PrimitiveMapper.Map<double?, decimal?>(null));
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        //[ExpectedException(typeof(NotSupportedException))]
        public virtual void ToDateTime()
        {
            /*Double a = 4.39;
            DateTime b;
            //b = a;
            //b = (DateTime)a;
            //b = (DateTime)Convert.ChangeType(a, typeof(DateTime));
            //b = Convert.ToDateTime(a);
            var converter = TypeDescriptor.GetConverter(typeof(DateTime));
            b = (DateTime)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(Double));
            //b = (DateTime)converter.ConvertTo(a, typeof(DateTime));
            Console.WriteLine(b);*/
            Assert.IsNull(PrimitiveMapper.Map<double, DateTime>(0));
        }
        [TestMethod]
        public virtual void ToSString()
        {
            /*Double a = 4.8;
            String b;
            //b = a;
            //b = (String)a;
            b = (String)Convert.ChangeType(a, typeof(String));
            b = Convert.ToString(a);
            var converter = TypeDescriptor.GetConverter(typeof(String));
            //b = (String)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(Double));
            b = (String)converter.ConvertTo(a, typeof(String));
            Console.WriteLine(b);*/
            Assert.IsNotNull(PrimitiveMapper.Map<double, string>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<double, string>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<double, string>(1));
            Assert.IsTrue(PrimitiveMapper.Map<double, string>(2.6) == "2.6");

            Assert.IsNotNull(PrimitiveMapper.Map<double?, string>(-1));
            Assert.IsNotNull(PrimitiveMapper.Map<double?, string>(0));
            Assert.IsNotNull(PrimitiveMapper.Map<double?, string>(1));
            Assert.IsNotNull(PrimitiveMapper.Map<double?, string>(2.789));
            Assert.IsNull(PrimitiveMapper.Map<double?, string>(null));
        }
        [TestMethod]
        public virtual void Parse()
        {
            Double a = 4.8;
            String b = "-12.7";
            //b = "1";
            //b = "0";
            a = Double.Parse(b);
            Console.WriteLine(a);
        }
    }
    [TestClass]
    public class DecimalConvertTest
    {
        //[ExpectedException(typeof(NotSupportedException))]
        [TestMethod]
        public virtual void ToBoolean()
        {
            /*Decimal a = 0M;
            Boolean b;
            //b = a;
            //b = (Boolean)a;
            b = Convert.ToBoolean(a);

            b = (Boolean)Convert.ChangeType(a, typeof(Boolean));
            var converter = TypeDescriptor.GetConverter(typeof(Boolean));
             //b = (Boolean)converter.ConvertFrom(a);

            converter = TypeDescriptor.GetConverter(typeof(Decimal));
            b = (Boolean)converter.ConvertTo(a, typeof(Boolean));
            Console.WriteLine(b);*/
            Assert.IsTrue(PrimitiveMapper.Map<decimal, bool>(-1M));
            Assert.IsFalse(PrimitiveMapper.Map<decimal, bool>(0M));
            Assert.IsTrue(PrimitiveMapper.Map<decimal, bool>(1M));
            Assert.IsTrue(PrimitiveMapper.Map<decimal, bool>(2.6M));

            Assert.IsTrue(PrimitiveMapper.Map<decimal?, bool>(-1M));
            Assert.IsFalse(PrimitiveMapper.Map<decimal?, bool>(0M));
            Assert.IsTrue(PrimitiveMapper.Map<decimal?, bool>(1M));
            Assert.IsTrue(PrimitiveMapper.Map<decimal?, bool>(2.789M));
            Assert.IsFalse(PrimitiveMapper.Map<decimal?, bool>(null));

            Assert.IsTrue(PrimitiveMapper.Map<decimal, bool?>(-1M).Value);
            Assert.IsTrue(PrimitiveMapper.Map<decimal, bool?>(0M).Value == false);
            Assert.IsTrue(PrimitiveMapper.Map<decimal, bool?>(1M).Value == true);
            Assert.IsTrue(PrimitiveMapper.Map<decimal, bool?>(2.789M).Value == true);

            Assert.IsTrue(PrimitiveMapper.Map<decimal?, bool?>(-1M).Value == true);
            Assert.IsTrue(PrimitiveMapper.Map<decimal?, bool?>(0M).Value == false);
            Assert.IsTrue(PrimitiveMapper.Map<decimal?, bool?>(1M).Value == true);
            Assert.IsTrue(PrimitiveMapper.Map<decimal?, bool?>(2.789M).Value == true);
            Assert.IsNull(PrimitiveMapper.Map<decimal?, bool?>(null));
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        public virtual void ToChar()
        {
            /*Decimal a = 4.0M;
            Char b;
            //b = a;
            b = (Char)a;
            //b = (Char)Convert.ChangeType(a, typeof(Char));
            //b = Convert.ToChar(a);
            //var converter = TypeDescriptor.GetConverter(typeof(Char));
            //b = (Char)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(Decimal));
            //b = (Char)converter.ConvertTo(a, typeof(Char));
            Console.WriteLine(b);*/
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, char>(-1M));
        }
        [TestMethod]
        public virtual void ToSByte()
        {
            /*Decimal a = 4.21M;
            SByte b;
            //b = a;
            b = (SByte)a;
            b = (SByte)Convert.ChangeType(a, typeof(SByte));
            b = Convert.ToSByte(a);
            var converter = TypeDescriptor.GetConverter(typeof(SByte));
            //b = (SByte)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(Decimal));
            b = (SByte)converter.ConvertTo(a, typeof(SByte));
            Console.WriteLine(b);*/
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, sbyte>(-1M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, sbyte>(0M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, sbyte>(1M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, sbyte>(2.6M));

            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, sbyte>(-1M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, sbyte>(0M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, sbyte>(1M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, sbyte>(2.789M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, sbyte>(null));

            Assert.IsNotNull(PrimitiveMapper.Map<decimal, sbyte?>(-1M).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, sbyte?>(0M).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, sbyte?>(1M).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, sbyte?>(2.789M).Value);

            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, sbyte?>(-1M).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, sbyte?>(0M).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, sbyte?>(1M).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, sbyte?>(2.789M).Value);
            Assert.IsNull(PrimitiveMapper.Map<decimal?, sbyte?>(null));
        }
        [TestMethod]
        public virtual void ToByte()
        {
            /*Decimal a = 25.2M;
            Byte b;
            //b = a;
            b = (Byte)a;
            b = (Byte)Convert.ChangeType(a, typeof(Byte));
            b = Convert.ToByte(a);
            var converter = TypeDescriptor.GetConverter(typeof(Byte));
            //b = (Byte)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(Decimal));
            b = (Byte)converter.ConvertTo(a, typeof(Byte));
            Console.WriteLine(b);*/
            //Assert.IsNotNull(PrimitiveMapper.Map<decimal, byte>(-1M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, byte>(0M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, byte>(1M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, byte>(2.6M));

            //Assert.IsNotNull(PrimitiveMapper.Map<decimal?, byte>(-1M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, byte>(0M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, byte>(1M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, byte>(2.789M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, byte>(null));

            //Assert.IsNotNull(PrimitiveMapper.Map<decimal, byte?>(-1M).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, byte?>(0M).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, byte?>(1M).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, byte?>(2.789M).Value);

            //Assert.IsNotNull(PrimitiveMapper.Map<decimal?, byte?>(-1M).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, byte?>(0M).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, byte?>(1M).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, byte?>(2.789M).Value);
            Assert.IsNull(PrimitiveMapper.Map<decimal?, byte?>(null));
        }
        [TestMethod]
        public virtual void ToInt16()
        {
            /*Decimal a = 4.6M;
            Int16 b;
            //b = a;
            b = (Int16)a;
            b = (Int16)Convert.ChangeType(a, typeof(Int16));
            b = Convert.ToInt16(a);
            var converter = TypeDescriptor.GetConverter(typeof(Int16));
            //b = (Int16)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(Decimal));
            b = (Int16)converter.ConvertTo(a, typeof(Int16));
            Console.WriteLine(b);*/
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, Int16>(-1M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, Int16>(0M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, Int16>(1M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, Int16>(2.6M));

            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, Int16>(-1M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, Int16>(0M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, Int16>(1M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, Int16>(2.789M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, Int16>(null));

            Assert.IsNotNull(PrimitiveMapper.Map<decimal, Int16?>(-1M).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, Int16?>(0M).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, Int16?>(1M).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, Int16?>(2.789M).Value);

            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, Int16?>(-1M).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, Int16?>(0M).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, Int16?>(1M).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, Int16?>(2.789M).Value);
            Assert.IsNull(PrimitiveMapper.Map<decimal?, Int16?>(null));
        }
        [TestMethod]
        public virtual void ToUInt16()
        {
            /*Decimal a = 4.2M;
            UInt16 b;
            //b = a;
            b = (UInt16)a;
            b = (UInt16)Convert.ChangeType(a, typeof(UInt16));
            b = Convert.ToUInt16(a);
            var converter = TypeDescriptor.GetConverter(typeof(UInt16));
            //b = (UInt16)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(Decimal));
            b = (UInt16)converter.ConvertTo(a, typeof(UInt16));
            Console.WriteLine(b);*/
            //Assert.IsNotNull(PrimitiveMapper.Map<decimal, UInt16>(-1M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, UInt16>(0M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, UInt16>(1M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, UInt16>(2.6M));

            //Assert.IsNotNull(PrimitiveMapper.Map<decimal?, UInt16>(-1M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, UInt16>(0M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, UInt16>(1M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, UInt16>(2.789M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, UInt16>(null));

            //Assert.IsNotNull(PrimitiveMapper.Map<decimal, UInt16?>(-1M).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, UInt16?>(0M).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, UInt16?>(1M).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, UInt16?>(2.789M).Value);

            //Assert.IsNotNull(PrimitiveMapper.Map<decimal?, UInt16?>(-1M).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, UInt16?>(0M).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, UInt16?>(1M).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, UInt16?>(2.789M).Value);
            Assert.IsNull(PrimitiveMapper.Map<decimal?, UInt16?>(null));
        }
        [TestMethod]
        public virtual void ToInt32()
        {
            /*Decimal a = 4.51M;
            Int32 b;
            //b = a;
            b = (Int32)a;
            b = (Int32)Convert.ChangeType(a, typeof(Int32));
            b = Convert.ToInt32(a);
            var converter = TypeDescriptor.GetConverter(typeof(Int32));
            //b = (Int32)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(Decimal));
            b = (Int32)converter.ConvertTo(a, typeof(Int32));
            Console.WriteLine(b);*/
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, Int32>(-1M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, Int32>(0M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, Int32>(1M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, Int32>(2.6M));

            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, Int32>(-1M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, Int32>(0M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, Int32>(1M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, Int32>(2.789M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, Int32>(null));

            Assert.IsNotNull(PrimitiveMapper.Map<decimal, Int32?>(-1M).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, Int32?>(0M).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, Int32?>(1M).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, Int32?>(2.789M).Value);

            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, Int32?>(-1M).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, Int32?>(0M).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, Int32?>(1M).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, Int32?>(2.789M).Value);
            Assert.IsNull(PrimitiveMapper.Map<decimal?, Int32?>(null));
        }
        [TestMethod]
        public virtual void ToUInt32()
        {
            /*Decimal a = 4.6M;
            UInt32 b;
            //b = a;
            b = (UInt32)a;
            b = (UInt32)Convert.ChangeType(a, typeof(UInt32));
            b = Convert.ToUInt32(a);
            var converter = TypeDescriptor.GetConverter(typeof(UInt32));
            //b = (UInt32)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(Decimal));
            b = (UInt32)converter.ConvertTo(a, typeof(UInt32));
            Console.WriteLine(b);*/
            //Assert.IsNotNull(PrimitiveMapper.Map<decimal, UInt32>(-1M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, UInt32>(0M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, UInt32>(1M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, UInt32>(2.6M));

            //Assert.IsNotNull(PrimitiveMapper.Map<decimal?, UInt32>(-1M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, UInt32>(0M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, UInt32>(1M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, UInt32>(2.789M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, UInt32>(null));

            //Assert.IsNotNull(PrimitiveMapper.Map<decimal, UInt32?>(-1M).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, UInt32?>(0M).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, UInt32?>(1M).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, UInt32?>(2.789M).Value);

            //Assert.IsNotNull(PrimitiveMapper.Map<decimal?, UInt32?>(-1M).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, UInt32?>(0M).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, UInt32?>(1M).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, UInt32?>(2.789M).Value);
            Assert.IsNull(PrimitiveMapper.Map<decimal?, UInt32?>(null));
        }
        [TestMethod]
        public virtual void ToInt64()
        {
            /*Decimal a = 4.33M;
            Int64 b;
            //b = a;
            b = (Int64)a;
            b = (Int64)Convert.ChangeType(a, typeof(Int64));
            b = Convert.ToInt64(a);
            var converter = TypeDescriptor.GetConverter(typeof(Int64));
            //b = (Int64)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(Decimal));
            b = (Int64)converter.ConvertTo(a, typeof(Int64));
            Console.WriteLine(b);*/
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, Int64>(-1M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, Int64>(0M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, Int64>(1M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, Int64>(2.6M));

            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, Int64>(-1M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, Int64>(0M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, Int64>(1M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, Int64>(2.789M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, Int64>(null));

            Assert.IsNotNull(PrimitiveMapper.Map<decimal, Int64?>(-1M).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, Int64?>(0M).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, Int64?>(1M).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, Int64?>(2.789M).Value);

            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, Int64?>(-1M).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, Int64?>(0M).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, Int64?>(1M).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, Int64?>(2.789M).Value);
            Assert.IsNull(PrimitiveMapper.Map<decimal?, Int64?>(null));
        }
        [TestMethod]
        public virtual void ToUInt64()
        {
            /*Decimal a = 4.89M;
            UInt64 b;
            //b = a;
            b = (UInt64)a;
            b = (UInt64)Convert.ChangeType(a, typeof(UInt64));
            b = Convert.ToUInt64(a);
            var converter = TypeDescriptor.GetConverter(typeof(UInt64));
           // b = (UInt64)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(Decimal));
            b = (UInt64)converter.ConvertTo(a, typeof(UInt64));
            Console.WriteLine(b);*/
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, UInt64>(-0.2M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, UInt64>(0M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, UInt64>(1M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, UInt64>(2.6M));

            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, UInt64>(-0.1M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, UInt64>(0M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, UInt64>(1M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, UInt64>(2.789M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, UInt64>(null));

            Assert.IsNotNull(PrimitiveMapper.Map<decimal, UInt64?>(-0.3M).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, UInt64?>(0M).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, UInt64?>(1M).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, UInt64?>(2.789M).Value);

            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, UInt64?>(-0.4M).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, UInt64?>(0M).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, UInt64?>(1M).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, UInt64?>(2.789M).Value);
            Assert.IsNull(PrimitiveMapper.Map<decimal?, UInt64?>(null));
            decimal d = -0.4M;
            UInt64 u = (UInt64)d;
            Console.WriteLine(u);
        }
        [TestMethod]
        public virtual void ToSingle()
        {
            /*Decimal a = 4.49M;
            Single b;
            //b = a;
            b = (Single)a;
            b = (Single)Convert.ChangeType(a, typeof(Single));
            b = Convert.ToSingle(a);
            var converter = TypeDescriptor.GetConverter(typeof(Single));
            //b = (Single)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(Decimal));
            b = (Single)converter.ConvertTo(a, typeof(Single));
            Console.WriteLine(b);*/
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, Single>(-1M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, Single>(0M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, Single>(1M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, Single>(2.6M));

            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, Single>(-1M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, Single>(0M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, Single>(1M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, Single>(2.789M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, Single>(null));

            Assert.IsNotNull(PrimitiveMapper.Map<decimal, Single?>(-1M).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, Single?>(0M).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, Single?>(1M).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, Single?>(2.789M).Value);

            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, Single?>(-1M).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, Single?>(0M).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, Single?>(1M).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, Single?>(2.789M).Value);
            Assert.IsNull(PrimitiveMapper.Map<decimal?, Single?>(null));
        }
        [TestMethod]
        public virtual void ToDouble()
        {
            /*Decimal a = 4.99M;
            Double b;
            //b = a;
            b = (Double)a;
            b = (Double)Convert.ChangeType(a, typeof(Double));
            b = Convert.ToDouble(a);
            var converter = TypeDescriptor.GetConverter(typeof(Double));
            //b = (Double)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(Decimal));
            b = (Double)converter.ConvertTo(a, typeof(Double));
            Console.WriteLine(b);*/
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, double>(-0.2M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, double>(0M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, double>(1M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, double>(2.6M));

            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, double>(-0.1M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, double>(0M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, double>(1M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, double>(2.789M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, double>(null));

            Assert.IsNotNull(PrimitiveMapper.Map<decimal, double?>(-0.3M).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, double?>(0M).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, double?>(1M).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, double?>(2.789M).Value);

            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, double?>(-0.4M).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, double?>(0M).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, double?>(1M).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, double?>(2.789M).Value);
            Assert.IsNull(PrimitiveMapper.Map<decimal?, double?>(null));
        }
        [TestMethod]
        public virtual void ToDecimal()
        {
            /*Decimal a = 4.72M;
            Decimal b;
            b = a;
            b = (Decimal)a;
            b = (Decimal)Convert.ChangeType(a, typeof(Decimal));
            b = Convert.ToDecimal(a);
            //var converter = TypeDescriptor.GetConverter(typeof(Decimal));
           // b = (Decimal)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(Decimal));
            //b = (Decimal)converter.ConvertTo(a, typeof(Decimal));
            Console.WriteLine(b);*/
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, decimal>(-0.2M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, decimal>(0M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, decimal>(1M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, decimal>(2.6M));

            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, decimal>(-0.1M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, decimal>(0M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, decimal>(1M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, decimal>(2.789M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, decimal>(null));

            Assert.IsNotNull(PrimitiveMapper.Map<decimal, decimal?>(-0.3M).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, decimal?>(0M).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, decimal?>(1M).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, decimal?>(2.789M).Value);

            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, decimal?>(-0.4M).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, decimal?>(0M).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, decimal?>(1M).Value);
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, decimal?>(2.789M).Value);
            Assert.IsNull(PrimitiveMapper.Map<decimal?, decimal?>(null));
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        //[ExpectedException(typeof(NotSupportedException))]
        public virtual void ToDateTime()
        {
            /*Decimal a = 4.39M;
            DateTime b;
            //b = a;
            //b = (DateTime)a;
            //b = (DateTime)Convert.ChangeType(a, typeof(DateTime));
            //b = Convert.ToDateTime(a);
           var converter = TypeDescriptor.GetConverter(typeof(DateTime));
            b = (DateTime)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(Decimal));
            //b = (DateTime)converter.ConvertTo(a, typeof(DateTime));
            Console.WriteLine(b);*/
            Assert.IsNull(PrimitiveMapper.Map<decimal, DateTime>(0));
        }
        [TestMethod]
        public virtual void ToSString()
        {
            /*Decimal a = 4.8M;
            String b;
            //b = a;
            //b = (String)a;
            b = (String)Convert.ChangeType(a, typeof(String));
            b = Convert.ToString(a);
            var converter = TypeDescriptor.GetConverter(typeof(String));
            //b = (String)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(Decimal));
            b = (String)converter.ConvertTo(a, typeof(String));
            Console.WriteLine(b);*/
            Assert.IsTrue(PrimitiveMapper.Map<decimal, string>(-0.2M) == "-0.2");
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, string>(0M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, string>(1M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal, string>(2.6M));

            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, string>(-0.1M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, string>(0M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, string>(1M));
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, string>(2.789M));
            Assert.IsNull(PrimitiveMapper.Map<decimal?, string>(null));
        }
        [TestMethod]
        public virtual void Parse()
        {
            Decimal a = 4.8M;
            String b = "+12.7";
            //b = "1";
            //b = "0";
            a = Decimal.Parse(b);
            Console.WriteLine(a);
        }
    }
    [TestClass]
    public class DateTimeConvertTest
    {
        [ExpectedException(typeof(InvalidCastException))]
        //[ExpectedException(typeof(NotSupportedException))]
        [TestMethod]
        public virtual void ToBoolean()
        {
            /*DateTime a = new DateTime(2012,07,16);
            Boolean b;
            //b = a;
            //b = (Boolean)a;
            //b = Convert.ToBoolean(a);

            //b = (Boolean)Convert.ChangeType(a, typeof(Boolean));
            var converter = TypeDescriptor.GetConverter(typeof(Boolean));
            //b = (Boolean)converter.ConvertFrom(a);

            converter = TypeDescriptor.GetConverter(typeof(DateTime));
            b = (Boolean)converter.ConvertTo(a, typeof(Boolean));
            Console.WriteLine(b);*/
            Assert.IsNull(PrimitiveMapper.Map<DateTime, bool>(new DateTime(2012, 7, 12)));
        }
        [ExpectedException(typeof(InvalidCastException))]
        //[ExpectedException(typeof(NotSupportedException))]
        [TestMethod]
        public virtual void ToChar()
        {
            /*DateTime a = new DateTime(2012, 07, 16);
            Char b;
            //b = a;
            //b = (Char)a;
            //b = (Char)Convert.ChangeType(a, typeof(Char));
            //b = Convert.ToChar(a);
            var converter = TypeDescriptor.GetConverter(typeof(Char));
            //b = (Char)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(DateTime));
            b = (Char)converter.ConvertTo(a, typeof(Char));

            Console.WriteLine(b);*/
            Assert.IsNull(PrimitiveMapper.Map<DateTime, char>(new DateTime(2012, 7, 12)));
        }
        [ExpectedException(typeof(InvalidCastException))]
        //[ExpectedException(typeof(NotSupportedException))]
        [TestMethod]
        public virtual void ToSByte()
        {
            /*DateTime a = new DateTime(2012, 07, 16);
            SByte b;
            //b = a;
            //b = (SByte)a;
           // b = (SByte)Convert.ChangeType(a, typeof(SByte));
            //b = Convert.ToSByte(a);
             var converter = TypeDescriptor.GetConverter(typeof(SByte));
            //b = (SByte)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(DateTime));
            b = (SByte)converter.ConvertTo(a, typeof(SByte));
            Console.WriteLine(b);*/
            Assert.IsNull(PrimitiveMapper.Map<DateTime, sbyte>(new DateTime(2012, 7, 14)));
        }
        [ExpectedException(typeof(InvalidCastException))]
        //[ExpectedException(typeof(NotSupportedException))]
        [TestMethod]
        public virtual void ToByte()
        {
            /*DateTime a = new DateTime(2012, 07, 16);
            Byte b;
            //b = a;
            //b = (Byte)a;
            //b = (Byte)Convert.ChangeType(a, typeof(Byte));
            //b = Convert.ToByte(a);
            var converter = TypeDescriptor.GetConverter(typeof(Byte));
            //b = (Byte)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(DateTime));
            b = (Byte)converter.ConvertTo(a, typeof(Byte));
            Console.WriteLine(b);*/
            Assert.IsNull(PrimitiveMapper.Map<DateTime, byte>(new DateTime(2012, 7, 14)));
        }
        [ExpectedException(typeof(InvalidCastException))]
        //[ExpectedException(typeof(NotSupportedException))]
        [TestMethod]
        public virtual void ToInt16()
        {
            /*DateTime a = new DateTime(2012, 07, 16);
            Int16 b;
            //b = a;
            //b = (Int16)a;
            //b = (Int16)Convert.ChangeType(a, typeof(Int16));
            //b = Convert.ToInt16(a);
            var converter = TypeDescriptor.GetConverter(typeof(Int16));
            //b = (Int16)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(DateTime));
            b = (Int16)converter.ConvertTo(a, typeof(Int16));
            Console.WriteLine(b);*/
            Assert.IsNull(PrimitiveMapper.Map<DateTime, Int16>(new DateTime(2012, 7, 14)));
        }
        [ExpectedException(typeof(InvalidCastException))]
        //[ExpectedException(typeof(NotSupportedException))]
        [TestMethod]
        public virtual void ToUInt16()
        {
            /*DateTime a = new DateTime(2012, 07, 16);
            UInt16 b;
            //b = a;
            //b = (UInt16)a;
            //b = (UInt16)Convert.ChangeType(a, typeof(UInt16));
            //b = Convert.ToUInt16(a);
            var converter = TypeDescriptor.GetConverter(typeof(UInt16));
            //b = (UInt16)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(DateTime));
            b = (UInt16)converter.ConvertTo(a, typeof(UInt16));
            Console.WriteLine(b);*/
            Assert.IsNull(PrimitiveMapper.Map<DateTime, UInt16>(new DateTime(2012, 7, 14)));
        }
        [ExpectedException(typeof(InvalidCastException))]
        //[ExpectedException(typeof(NotSupportedException))]
        [TestMethod]
        public virtual void ToInt32()
        {
            /*DateTime a = new DateTime(2012, 07, 16);
            Int32 b;
            //b = a;
            //b = (Int32)a;
            //b = (Int32)Convert.ChangeType(a, typeof(Int32));
            //b = Convert.ToInt32(a);
            var converter = TypeDescriptor.GetConverter(typeof(Int32));
            //b = (Int32)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(DateTime));
            b = (Int32)converter.ConvertTo(a, typeof(Int32));
            Console.WriteLine(b);*/
            Assert.IsNull(PrimitiveMapper.Map<DateTime, Int32>(new DateTime(2012, 7, 14)));
        }
        [ExpectedException(typeof(InvalidCastException))]
        //[ExpectedException(typeof(NotSupportedException))]
        [TestMethod]
        public virtual void ToUInt32()
        {
            /*DateTime a = new DateTime(2012, 07, 16);
            UInt32 b;
            //b = a;
            //b = (UInt32)a;
           // b = (UInt32)Convert.ChangeType(a, typeof(UInt32));
            //b = Convert.ToUInt32(a);
            var converter = TypeDescriptor.GetConverter(typeof(UInt32));
            //b = (UInt32)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(DateTime));
            b = (UInt32)converter.ConvertTo(a, typeof(UInt32));
            Console.WriteLine(b);*/
            Assert.IsNull(PrimitiveMapper.Map<DateTime, UInt32>(new DateTime(2012, 7, 14)));
        }
        [ExpectedException(typeof(InvalidCastException))]
        //[ExpectedException(typeof(NotSupportedException))]
        [TestMethod]
        public virtual void ToInt64()
        {
            /*DateTime a = new DateTime(2012, 07, 16);
            Int64 b;
            //b = a;
            //b = (Int64)a;
            //b = (Int64)Convert.ChangeType(a, typeof(Int64));
            //b = Convert.ToInt64(a);
            var converter = TypeDescriptor.GetConverter(typeof(Int64));
            //b = (Int64)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(DateTime));
            b = (Int64)converter.ConvertTo(a, typeof(Int64));
            Console.WriteLine(b);*/
            Assert.IsNull(PrimitiveMapper.Map<DateTime, Int64>(new DateTime(2012, 7, 14)));
        }
        [ExpectedException(typeof(InvalidCastException))]
        //[ExpectedException(typeof(NotSupportedException))]
        [TestMethod]
        public virtual void ToUInt64()
        {
            /*DateTime a = new DateTime(2012, 07, 16);
            UInt64 b;
            // b = a;
            //b = (UInt64)a;
            //b = (UInt64)Convert.ChangeType(a, typeof(UInt64));
            //b = Convert.ToUInt64(a);
            var converter = TypeDescriptor.GetConverter(typeof(UInt64));
            //b = (UInt64)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(DateTime));
            b = (UInt64)converter.ConvertTo(a, typeof(UInt64));
            Console.WriteLine(b);*/
            Assert.IsNull(PrimitiveMapper.Map<DateTime, UInt64>(new DateTime(2012, 7, 14)));
        }
        [ExpectedException(typeof(InvalidCastException))]
        //[ExpectedException(typeof(NotSupportedException))]
        [TestMethod]
        public virtual void ToSingle()
        {
            /*DateTime a = new DateTime(2012, 07, 16);
            Single b;
            //b = a;
            //b = (Single)a;
            //b = (Single)Convert.ChangeType(a, typeof(Single));
            //b = Convert.ToSingle(a);
            var converter = TypeDescriptor.GetConverter(typeof(Single));
            //b = (Single)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(DateTime));
            b = (Single)converter.ConvertTo(a, typeof(Single));
            Console.WriteLine(b);*/
            Assert.IsNull(PrimitiveMapper.Map<DateTime, Single>(new DateTime(2012, 7, 14)));
        }
        [ExpectedException(typeof(InvalidCastException))]
        //[ExpectedException(typeof(NotSupportedException))]
        [TestMethod]
        public virtual void ToDouble()
        {
            /*DateTime a = new DateTime(2012, 07, 16);
            Double b;
            //b = a;
            //b = (Double)a;
            //b = (Double)Convert.ChangeType(a, typeof(Double));
            //b = Convert.ToDouble(a);
            var converter = TypeDescriptor.GetConverter(typeof(Double));
            //b = (Double)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(DateTime));
            b = (Double)converter.ConvertTo(a, typeof(Double));
            Console.WriteLine(b);*/
            Assert.IsNull(PrimitiveMapper.Map<DateTime, double>(new DateTime(2012, 7, 14)));
        }
        [ExpectedException(typeof(InvalidCastException))]
        //[ExpectedException(typeof(NotSupportedException))]
        [TestMethod]
        public virtual void ToDecimal()
        {
            /*DateTime a = new DateTime(2012, 07, 16);
            Decimal b;
            //b = a;
            //b = (Decimal)a;
            //b = (Decimal)Convert.ChangeType(a, typeof(Decimal));
            //b = Convert.ToDecimal(a);
            var converter = TypeDescriptor.GetConverter(typeof(Decimal));
            //b = (Decimal)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(DateTime));
            b = (Decimal)converter.ConvertTo(a, typeof(Decimal));
            Console.WriteLine(b);*/
            Assert.IsNull(PrimitiveMapper.Map<DateTime, decimal>(new DateTime(2012, 7, 14)));
        }
        [TestMethod]
        //[ExpectedException(typeof(NotSupportedException))]
        public virtual void ToDateTime()
        {
            /*DateTime a = new DateTime(2012, 07, 16);
            DateTime b;
            b = a;
            b = (DateTime)a;
            b = (DateTime)Convert.ChangeType(a, typeof(DateTime));
            b = Convert.ToDateTime(a);
            //var converter = TypeDescriptor.GetConverter(typeof(DateTime));
            //b = (DateTime)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(DateTime));
            //b = (DateTime)converter.ConvertTo(a, typeof(DateTime));
            Console.WriteLine(b);*/
            Assert.IsNotNull(PrimitiveMapper.Map<DateTime, DateTime>(new DateTime(2012, 7, 14)));
        }
        [TestMethod]
        public virtual void ToSString()
        {
            /*DateTime a = new DateTime(2012, 07, 16);
            String b;
            //b = a;
            //b = (String)a;
            b = (String)Convert.ChangeType(a, typeof(String));
            b = Convert.ToString(a);
            var converter = TypeDescriptor.GetConverter(typeof(String));
            //b = (String)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(DateTime));
            b = (String)converter.ConvertTo(a, typeof(String));
            Console.WriteLine(b);*/
            Assert.IsTrue(PrimitiveMapper.Map<DateTime, string>(new DateTime(2012, 7, 14)) == "2012/7/14 0:00:00");
            Assert.IsNotNull(PrimitiveMapper.Map<DateTime?, DateTime>(new DateTime(2012, 7, 14)));
            DateTime dt = new DateTime(2012, 7, 14);
            string ds = dt.ToString();
            Console.WriteLine(ds);
        }
        [TestMethod]
        public virtual void Parse()
        {
            DateTime a = new DateTime(2012, 07, 16);
            String b = "2012/7/16";
            //b = "1";
            //b = "0";
            a = DateTime.Parse(b);
            Console.WriteLine(a);
        }
    }
    [TestClass]
    public class StringConvertTest
    {
        //[ExpectedException(typeof(NotSupportedException))]
        [TestMethod]
        public virtual void ToBoolean()
        {
            /*String a ="true";
            Boolean b;
            //b = a;
            //b = (Boolean)a;
            b = Convert.ToBoolean(a);

            b = (Boolean)Convert.ChangeType(a, typeof(Boolean));
            var converter = TypeDescriptor.GetConverter(typeof(Boolean));
            b = (Boolean)converter.ConvertFrom(a);

            //converter = TypeDescriptor.GetConverter(typeof(String));
            //b = (Boolean)converter.ConvertTo(a, typeof(Boolean));
            Console.WriteLine(b);*/
            Assert.IsFalse(PrimitiveMapper.Map<string, bool>("false"));
            //Assert.IsFalse(PrimitiveMapper.Map<string, bool>("0"));
            //Assert.IsTrue(PrimitiveMapper.Map<string, bool>("1"));
            //Assert.IsTrue(PrimitiveMapper.Map<string, bool>("-1"));
            //Assert.IsTrue(PrimitiveMapper.Map<string, bool>("zxm"));
            Assert.IsTrue(PrimitiveMapper.Map<string, bool>("true"));

            Assert.IsFalse(PrimitiveMapper.Map<string, bool?>("false").Value);
            //Assert.IsFalse(PrimitiveMapper.Map<string, bool?>("0").Value);
            //Assert.IsTrue(PrimitiveMapper.Map<string, bool?>("1").Value);
            //Assert.IsTrue(PrimitiveMapper.Map<string, bool?>("-1").Value);
            //Assert.IsTrue(PrimitiveMapper.Map<string, bool?>("zxm").Value);
            Assert.IsTrue(PrimitiveMapper.Map<string, bool?>("true").Value);
        }
        [TestMethod]
        public virtual void ToChar()
        {
            /*String a = "2";
            Char b;
            //b = a;
            //b = (Char)a;
            //b = (Char)Convert.ChangeType(a, typeof(Char));
            //b = Convert.ToChar(a);
            var converter = TypeDescriptor.GetConverter(typeof(Char));
            b = (Char)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(String));
            //b = (Char)converter.ConvertTo(a, typeof(Char));
            Console.WriteLine(b);*/
            Assert.IsTrue(PrimitiveMapper.Map<string, char>("false") == 'f');
            Assert.IsTrue(PrimitiveMapper.Map<string, char>("0") == '0');
            Assert.IsTrue(PrimitiveMapper.Map<string, char>("1") == '1');
            Assert.IsTrue(PrimitiveMapper.Map<string, char>("-1") == '-');
            Assert.IsTrue(PrimitiveMapper.Map<string, char>("zxm") == 'z');
            Assert.IsTrue(PrimitiveMapper.Map<string, char>("true") == 't');

            Assert.IsTrue(PrimitiveMapper.Map<string, char?>("false").Value == 'f');
            Assert.IsTrue(PrimitiveMapper.Map<string, char?>("0").Value == '0');
            Assert.IsTrue(PrimitiveMapper.Map<string, char?>("1").Value == '1');
            Assert.IsTrue(PrimitiveMapper.Map<string, char?>("-1").Value == '-');
            Assert.IsTrue(PrimitiveMapper.Map<string, char?>("zxm").Value == 'z');
            Assert.IsTrue(PrimitiveMapper.Map<string, char?>("true").Value == 't');
            //string s = "false";//s长度必须为1
            //char c = Convert.toChar(s);
            //char c = (char)Convert.ChangeType(s,typeof(char));
            //Console.WriteLine(c);
        }
        [TestMethod]
        public virtual void ToSByte()
        {
            /*String a = "41";
            SByte b;
            //b = a;
            //b = (SByte)a;
            b = (SByte)Convert.ChangeType(a, typeof(SByte));
            b = Convert.ToSByte(a);
            var converter = TypeDescriptor.GetConverter(typeof(SByte));
            b = (SByte)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(String));
            //b = (SByte)converter.ConvertTo(a, typeof(SByte));
            Console.WriteLine(b);
             */
            //Assert.IsTrue(PrimitiveMapper.Map<string, sbyte>("false") == 'f');
            Assert.IsTrue(PrimitiveMapper.Map<string, sbyte>("0") == 0);
            Assert.IsTrue(PrimitiveMapper.Map<string, sbyte>("1") == 1);
            Assert.IsTrue(PrimitiveMapper.Map<string, sbyte>("-1") == -1);
            Assert.IsTrue(PrimitiveMapper.Map<string, sbyte>("127") == 127);
            //Assert.IsTrue(PrimitiveMapper.Map<string, sbyte>("true") == 1);

            //Assert.IsTrue(PrimitiveMapper.Map<string, sbyte?>("false").Value == 'f');
            Assert.IsTrue(PrimitiveMapper.Map<string, sbyte?>("0").Value == 0);
            Assert.IsTrue(PrimitiveMapper.Map<string, sbyte?>("1").Value == 1);
            Assert.IsTrue(PrimitiveMapper.Map<string, sbyte?>("-1").Value == -1);
            Assert.IsTrue(PrimitiveMapper.Map<string, sbyte?>("127").Value == 127);
            Assert.IsTrue(PrimitiveMapper.Map<string, sbyte?>("-127").Value == -127);
        }
        [TestMethod]
        public virtual void ToByte()
        {
            /*String a = "43";
            Byte b;
            //b = a;
            //b = (Byte)a;
            b = (Byte)Convert.ChangeType(a, typeof(Byte));
            b = Convert.ToByte(a);
            var converter = TypeDescriptor.GetConverter(typeof(Byte));
            b = (Byte)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(String));
            //b = (Byte)converter.ConvertTo(a, typeof(Byte));
            Console.WriteLine(b);*/
            //Assert.IsTrue(PrimitiveMapper.Map<string, sbyte>("false") == 'f');
            Assert.IsTrue(PrimitiveMapper.Map<string, byte>("0") == 0);
            Assert.IsTrue(PrimitiveMapper.Map<string, byte>("1") == 1);
            //Assert.IsTrue(PrimitiveMapper.Map<string, byte>("-1") == -1);
            Assert.IsTrue(PrimitiveMapper.Map<string, byte>("255") == 255);
            //Assert.IsTrue(PrimitiveMapper.Map<string, sbyte>("true") == 1);

            //Assert.IsTrue(PrimitiveMapper.Map<string, sbyte?>("false").Value == 'f');
            Assert.IsTrue(PrimitiveMapper.Map<string, byte?>("0").Value == 0);
            Assert.IsTrue(PrimitiveMapper.Map<string, byte?>("1").Value == 1);
            //Assert.IsTrue(PrimitiveMapper.Map<string, byte?>("-1").Value == -1);
            Assert.IsTrue(PrimitiveMapper.Map<string, byte?>("127").Value == 127);
            //Assert.IsTrue(PrimitiveMapper.Map<string, byte?>("-127").Value == -127);
        }
        [TestMethod]
        public virtual void ToInt16()
        {
            /*String a = "256";
            Int16 b;
            //b = a;
            //b = (Int16)a;
            b = (Int16)Convert.ChangeType(a, typeof(Int16));
            b = Convert.ToInt16(a);
            var converter = TypeDescriptor.GetConverter(typeof(Int16));
            b = (Int16)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(String));
            //b = (Int16)converter.ConvertTo(a, typeof(Int16));
            Console.WriteLine(b);*/
            //Assert.IsTrue(PrimitiveMapper.Map<string, sbyte>("false") == 'f');
            Assert.IsTrue(PrimitiveMapper.Map<string, Int16>("0") == 0);
            Assert.IsTrue(PrimitiveMapper.Map<string, Int16>("1") == 1);
            Assert.IsTrue(PrimitiveMapper.Map<string, Int16>("-1") == -1);
            Assert.IsTrue(PrimitiveMapper.Map<string, Int16>("-1024") == -1024);
            //Assert.IsTrue(PrimitiveMapper.Map<string, sbyte>("true") == 1);

            //Assert.IsTrue(PrimitiveMapper.Map<string, sbyte?>("false").Value == 'f');
            Assert.IsTrue(PrimitiveMapper.Map<string, Int16?>("0").Value == 0);
            Assert.IsTrue(PrimitiveMapper.Map<string, Int16?>("1").Value == 1);
            Assert.IsTrue(PrimitiveMapper.Map<string, Int16?>("-1").Value == -1);
            Assert.IsTrue(PrimitiveMapper.Map<string, Int16?>("127").Value == 127);
            Assert.IsTrue(PrimitiveMapper.Map<string, Int16?>("-127").Value == -127);
        }
        [TestMethod]
        public virtual void ToUInt16()
        {
            /*String a = "256";
            UInt16 b;
            //b = a;
            //b = (UInt16)a;
            b = (UInt16)Convert.ChangeType(a, typeof(UInt16));
            b = Convert.ToUInt16(a);
            var converter = TypeDescriptor.GetConverter(typeof(UInt16));
            b = (UInt16)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(String));
            //b = (UInt16)converter.ConvertTo(a, typeof(UInt16));
            Console.WriteLine(b);*/
            Assert.IsTrue(PrimitiveMapper.Map<string, UInt16>("0") == 0);
            Assert.IsTrue(PrimitiveMapper.Map<string, UInt16>("1") == 1);
            //Assert.IsTrue(PrimitiveMapper.Map<string, UInt16>("-1") == -1);
            //Assert.IsTrue(PrimitiveMapper.Map<string, UInt16>("-1024") == -1024);
            //Assert.IsTrue(PrimitiveMapper.Map<string, sbyte>("true") == 1);

            //Assert.IsTrue(PrimitiveMapper.Map<string, sbyte?>("false").Value == 'f');
            Assert.IsTrue(PrimitiveMapper.Map<string, UInt16?>("0").Value == 0);
            Assert.IsTrue(PrimitiveMapper.Map<string, UInt16?>("1").Value == 1);
            //Assert.IsTrue(PrimitiveMapper.Map<string, UInt16?>("-1").Value == -1);
            Assert.IsTrue(PrimitiveMapper.Map<string, UInt16?>("127").Value == 127);
            //Assert.IsTrue(PrimitiveMapper.Map<string, UInt16?>("-127").Value == -127);
        }
        [TestMethod]
        public virtual void ToInt32()
        {
            /*String a = "128";
            Int32 b;
            //b = a;
            //b = (Int32)a;
            b = (Int32)Convert.ChangeType(a, typeof(Int32));
            b = Convert.ToInt32(a);
            var converter = TypeDescriptor.GetConverter(typeof(Int32));
            b = (Int32)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(String));
            //b = (Int32)converter.ConvertTo(a, typeof(Int32));
            Console.WriteLine(b);*/
            Assert.IsTrue(PrimitiveMapper.Map<string, Int32>("0") == 0);
            Assert.IsTrue(PrimitiveMapper.Map<string, Int32>("1") == 1);
            Assert.IsTrue(PrimitiveMapper.Map<string, Int32>("-1") == -1);
            Assert.IsTrue(PrimitiveMapper.Map<string, Int32>("-1024") == -1024);
            //Assert.IsTrue(PrimitiveMapper.Map<string, sbyte>("true") == 1);

            //Assert.IsTrue(PrimitiveMapper.Map<string, sbyte?>("false").Value == 'f');
            Assert.IsTrue(PrimitiveMapper.Map<string, Int32?>("0").Value == 0);
            Assert.IsTrue(PrimitiveMapper.Map<string, Int32?>("1").Value == 1);
            Assert.IsTrue(PrimitiveMapper.Map<string, Int32?>("-1").Value == -1);
            Assert.IsTrue(PrimitiveMapper.Map<string, Int32?>("127").Value == 127);
            Assert.IsTrue(PrimitiveMapper.Map<string, Int32?>("-127").Value == -127);
        }
        [TestMethod]
        public virtual void ToUInt32()
        {
            /*String a = "123";
            UInt32 b;
            //b = a;
            //b = (UInt32)a;
            b = (UInt32)Convert.ChangeType(a, typeof(UInt32));
            b = Convert.ToUInt32(a);
            var converter = TypeDescriptor.GetConverter(typeof(UInt32));
            b = (UInt32)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(String));
            //b = (UInt32)converter.ConvertTo(a, typeof(UInt32));
            Console.WriteLine(b);*/
            Assert.IsTrue(PrimitiveMapper.Map<string, UInt32>("0") == 0);
            Assert.IsTrue(PrimitiveMapper.Map<string, UInt32>("1") == 1);
            //Assert.IsTrue(PrimitiveMapper.Map<string, UInt32>("-1") == -1);
            //Assert.IsTrue(PrimitiveMapper.Map<string, UInt32>("-1024") == -1024);

            Assert.IsTrue(PrimitiveMapper.Map<string, UInt32?>("0").Value == 0);
            Assert.IsTrue(PrimitiveMapper.Map<string, UInt32?>("1").Value == 1);
            //Assert.IsTrue(PrimitiveMapper.Map<string, UInt32?>("-1").Value == -1);
            Assert.IsTrue(PrimitiveMapper.Map<string, UInt32?>("127").Value == 127);
            //Assert.IsTrue(PrimitiveMapper.Map<string, UInt32?>("-127").Value == -127);
        }
        [TestMethod]
        public virtual void ToInt64()
        {
            /*String a = "4322";
            Int64 b;
            //b = a;
            //b = (Int64)a;
            b = (Int64)Convert.ChangeType(a, typeof(Int64));
            b = Convert.ToInt64(a);
            var converter = TypeDescriptor.GetConverter(typeof(Int64));
            b = (Int64)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(String));
            //b = (Int64)converter.ConvertTo(a, typeof(Int64));
            Console.WriteLine(b);*/
            Assert.IsTrue(PrimitiveMapper.Map<string, Int64>("0") == 0);
            Assert.IsTrue(PrimitiveMapper.Map<string, Int64>("1") == 1);
            Assert.IsTrue(PrimitiveMapper.Map<string, Int64>("-1") == -1);
            Assert.IsTrue(PrimitiveMapper.Map<string, Int64>("-1024") == -1024);

            Assert.IsTrue(PrimitiveMapper.Map<string, Int64?>("0").Value == 0);
            Assert.IsTrue(PrimitiveMapper.Map<string, Int64?>("1").Value == 1);
            Assert.IsTrue(PrimitiveMapper.Map<string, Int64?>("-1").Value == -1);
            Assert.IsTrue(PrimitiveMapper.Map<string, Int64?>("127").Value == 127);
            Assert.IsTrue(PrimitiveMapper.Map<string, Int64?>("-127").Value == -127);
        }
        [TestMethod]
        public virtual void ToUInt64()
        {
            /*String a = "432344";
            UInt64 b;
            //b = a;
            //b = (UInt64)a;
            b = (UInt64)Convert.ChangeType(a, typeof(UInt64));
            b = Convert.ToUInt64(a);
            var converter = TypeDescriptor.GetConverter(typeof(UInt64));
            b = (UInt64)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(String));
            //b = (UInt64)converter.ConvertTo(a, typeof(UInt64));
            Console.WriteLine(b);*/
            Assert.IsTrue(PrimitiveMapper.Map<string, UInt64>("0") == 0);
            Assert.IsTrue(PrimitiveMapper.Map<string, UInt64>("1") == 1);
            //Assert.IsTrue(PrimitiveMapper.Map<string, UInt64>("-1") == -1);
            //Assert.IsTrue(PrimitiveMapper.Map<string, UInt64>("-1024") == -1024);

            Assert.IsTrue(PrimitiveMapper.Map<string, UInt64?>("0").Value == 0);
            Assert.IsTrue(PrimitiveMapper.Map<string, UInt64?>("1").Value == 1);
            //Assert.IsTrue(PrimitiveMapper.Map<string, UInt64?>("-1").Value == -1);
            Assert.IsTrue(PrimitiveMapper.Map<string, UInt64?>("127").Value == 127);
            //Assert.IsTrue(PrimitiveMapper.Map<string, UInt64?>("-127").Value == -127);
        }
        [TestMethod]
        public virtual void ToSingle()
        {
            /*String a = "48.33";
            Single b;
            //b = a;
            //b = (Single)a;
            //b = (Single)Convert.ChangeType(a, typeof(Single));
            //b = Convert.ToSingle(a);
            var converter = TypeDescriptor.GetConverter(typeof(Single));
            b = (Single)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(String));
            //b = (Single)converter.ConvertTo(a, typeof(Single));
            Console.WriteLine(b);*/
            Assert.IsTrue(PrimitiveMapper.Map<string, Single>("0") == 0F);
            Assert.IsTrue(PrimitiveMapper.Map<string, Single>("1") == 1F);
            Assert.IsTrue(PrimitiveMapper.Map<string, Single>("-1") == -1F);
            Assert.IsTrue(PrimitiveMapper.Map<string, Single>("-1024.3") == -1024.3F);

            Assert.IsTrue(PrimitiveMapper.Map<string, Single?>("0.987").Value == 0.987F);
            Assert.IsTrue(PrimitiveMapper.Map<string, Single?>("1").Value == 1F);
            Assert.IsTrue(PrimitiveMapper.Map<string, Single?>("-1").Value == -1F);
            Assert.IsTrue(PrimitiveMapper.Map<string, Single?>("127").Value == 127F);
            Assert.IsTrue(PrimitiveMapper.Map<string, Single?>("-127").Value == -127F);
        }
        [TestMethod]
        public virtual void ToDouble()
        {
            /*String a = "493.22";
            Double b;
            //b = a;
            //b = (Double)a;
            //b = (Double)Convert.ChangeType(a, typeof(Double));
            //b = Convert.ToDouble(a);
            var converter = TypeDescriptor.GetConverter(typeof(Double));
            b = (Double)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(String));
            //b = (Double)converter.ConvertTo(a, typeof(Double));
            Console.WriteLine(b);*/
            Assert.IsTrue(PrimitiveMapper.Map<string, double>("0") == 0);
            Assert.IsTrue(PrimitiveMapper.Map<string, double>("1.88") == 1.88);
            Assert.IsTrue(PrimitiveMapper.Map<string, double>("-1") == -1);
            Assert.IsTrue(PrimitiveMapper.Map<string, double>("-1024") == -1024);

            Assert.IsTrue(PrimitiveMapper.Map<string, double?>("0").Value == 0);
            Assert.IsTrue(PrimitiveMapper.Map<string, double?>("1").Value == 1);
            Assert.IsTrue(PrimitiveMapper.Map<string, double?>("-1.789").Value == -1.789);
            Assert.IsTrue(PrimitiveMapper.Map<string, double?>("127.534").Value == 127.534);
            Assert.IsTrue(PrimitiveMapper.Map<string, double?>("-127").Value == -127);
        }
        [TestMethod]
        public virtual void ToDecimal()
        {
            /*String a = "4893.22";
            Decimal b;
            //b = a;
            //b = (Decimal)a;
            //b = (Decimal)Convert.ChangeType(a, typeof(Decimal));
            //b = Convert.ToDecimal(a);
            var converter = TypeDescriptor.GetConverter(typeof(Decimal));
            b = (Decimal)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(String));
            //b = (Decimal)converter.ConvertTo(a, typeof(Decimal));
            Console.WriteLine(b);*/
            Assert.IsTrue(PrimitiveMapper.Map<string, decimal>("0") == 0M);
            Assert.IsTrue(PrimitiveMapper.Map<string, decimal>("1.88") == 1.88M);
            Assert.IsTrue(PrimitiveMapper.Map<string, decimal>("-1") == -1M);
            Assert.IsTrue(PrimitiveMapper.Map<string, decimal>("-1024") == -1024M);

            Assert.IsTrue(PrimitiveMapper.Map<string, decimal?>("0").Value == 0M);
            Assert.IsTrue(PrimitiveMapper.Map<string, decimal?>("1").Value == 1M);
            Assert.IsTrue(PrimitiveMapper.Map<string, decimal?>("-1.789").Value == -1.789M);
            Assert.IsTrue(PrimitiveMapper.Map<string, decimal?>("127.534").Value == 127.534M);
            Assert.IsTrue(PrimitiveMapper.Map<string, decimal?>("-127").Value == -127);
        }
        [TestMethod]
        //[ExpectedException(typeof(NotSupportedException))]
        public virtual void ToDateTime()
        {
            /*String a = "1992/7/16";
            DateTime b;
            //b = a;
            //b = (DateTime)a;
            //b = (DateTime)Convert.ChangeType(a, typeof(DateTime));
            //b = Convert.ToDateTime(a);
            var converter = TypeDescriptor.GetConverter(typeof(DateTime));
            b = (DateTime)converter.ConvertFrom(a);
            //converter = TypeDescriptor.GetConverter(typeof(String));
            //b = (DateTime)converter.ConvertTo(a, typeof(DateTime));
            Console.WriteLine(b);
             */
            DateTime d = new DateTime(1922, 7, 16);
            Assert.IsTrue(PrimitiveMapper.Map<string, DateTime>("1922/7/16") == d);
            Assert.IsNotNull(PrimitiveMapper.Map<string, DateTime>("2002-7-16"));
            d = Convert.ToDateTime("2002-7-16");
            Console.WriteLine(d);
        }
        [TestMethod]
        public virtual void ToSString()
        {
            /*String a = "4s";
            String b;
            b = a;
            b = (String)a;
            b = (String)Convert.ChangeType(a, typeof(String));
            b = Convert.ToString(a);
            var converter = TypeDescriptor.GetConverter(typeof(String));
            b = (String)converter.ConvertFrom(a);
            converter = TypeDescriptor.GetConverter(typeof(String));
            b = (String)converter.ConvertTo(a, typeof(String));
            Console.WriteLine(b);*/
            Assert.IsTrue(PrimitiveMapper.Map<string, string>("0") == "0");
            Assert.IsTrue(PrimitiveMapper.Map<string, string>("1.88") == "1.88");
            Assert.IsTrue(PrimitiveMapper.Map<string, string>("-1") == "-1");
            Assert.IsTrue(PrimitiveMapper.Map<string, string>("-1024") == "-1024");
            Assert.IsTrue(PrimitiveMapper.Map<string, string>("zxml") == "zxml");
        }
    }
}
