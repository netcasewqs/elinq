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
    [TestClass]
    public class BooleanConvertTest: TestBase<NullableTypeInfo>
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
        TypeConverter converter = TypeDescriptor.GetConverter(typeof(Boolean));
        TypeConverter byteConverter = TypeDescriptor.GetConverter(typeof(byte));

        [TestMethod]
        public virtual void ToBoolean()
        {
         
            Execute("SByte", (sbyte)0, p =>! Convert.ToBoolean(p.SByte.Value));
            Execute("SByte", (sbyte)1, p => Convert.ToBoolean(p.SByte.Value));
          
            Execute("SByte", (sbyte)2, p => Convert.ToBoolean(p.SByte.Value));

            Execute("SByte", (sbyte)0, p => !(bool)Convert.ChangeType(p.SByte.Value,typeof(bool)));
            Execute("SByte", (sbyte)1, p => (bool)Convert.ChangeType(p.SByte.Value, typeof(bool)));
         
            Execute("SByte", (sbyte)2, p => (bool)Convert.ChangeType(p.SByte.Value, typeof(bool)));

            Execute("SByte", (sbyte)0, p => !(bool)converter.ConvertFrom(p.SByte.Value));
            Execute("SByte", (sbyte)1, p => (bool)converter.ConvertFrom(p.SByte.Value));
        
            Execute("SByte", (sbyte)2, p => (bool)converter.ConvertFrom(p.SByte.Value));

            var converter2 = TypeDescriptor.GetConverter(typeof(bool));
            Execute("SByte", (sbyte)0, p => !(bool)converter2.ConvertFrom(p.SByte.Value));
            Execute("SByte", (sbyte)1, p => (bool)converter2.ConvertFrom(p.SByte.Value));
          
            Execute("SByte", (sbyte)2, p => (bool)converter2.ConvertFrom(p.SByte.Value));

            var byteConverter2 = TypeDescriptor.GetConverter(typeof(byte));
            Execute("SByte", (sbyte)0, p => !(bool)byteConverter.ConvertTo(p.SByte.Value,typeof(bool)));
            Execute("SByte", (sbyte)1, p => (bool)byteConverter.ConvertTo(p.SByte.Value, typeof(bool)));
        
            Execute("SByte", (sbyte)2, p => (bool)byteConverter2.ConvertTo(p.SByte.Value, typeof(bool)));

            Execute("SByte", (sbyte)0, p => !(bool)Convert.ChangeType(p.SByte, typeof(bool)));
            Execute("SByte", (sbyte)1, p => (bool)Convert.ChangeType(p.SByte, typeof(bool)));
         
            Execute("SByte", (sbyte)2, p => (bool)Convert.ChangeType(p.SByte, typeof(bool)));

            Execute("SByte", (sbyte)0, p => !(bool)converter.ConvertFrom(p.SByte));
            Execute("SByte", (sbyte)1, p => (bool)converter.ConvertFrom(p.SByte));
         
            Execute("SByte", (sbyte)2, p => (bool)converter.ConvertFrom(p.SByte));

        
            Execute("SByte", (sbyte)0, p => !(Convert.ChangeType(p.SByte.Value, typeof(bool?)) as bool?).Value);
            Execute("SByte", (sbyte)1, p => ((bool?)Convert.ChangeType(p.SByte.Value, typeof(bool?))).Value);

#if Oracle || MySQL
            Execute("SByte", (sbyte)-1, p => Convert.ToBoolean(p.SByte.Value));
            Execute("SByte", (sbyte)-1, p => (bool)Convert.ChangeType(p.SByte.Value, typeof(bool)));
            Execute("SByte", (sbyte)-1, p => (bool)converter.ConvertFrom(p.SByte.Value));
            Execute("SByte", (sbyte)-1, p => (bool)converter2.ConvertFrom(p.SByte.Value));
            Execute("SByte", (sbyte)-1, p => (bool)byteConverter.ConvertTo(p.SByte.Value, typeof(bool)));
            Execute("SByte", (sbyte)-1, p => (bool)Convert.ChangeType(p.SByte, typeof(bool)));
            Execute("SByte", (sbyte)-1, p => (bool)converter.ConvertFrom(p.SByte));
#endif
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

            Execute("Boolean", true, p => Convert.ToSByte(p.Boolean.Value) == 1);
            Execute("Boolean", false, p => Convert.ToSByte(p.Boolean.Value) == 0);
           

            //Assert.IsTrue(PrimitiveMapper.Map<bool, sbyte>(true) == 1);
            //Assert.IsTrue(PrimitiveMapper.Map<bool, sbyte>(false) == 0);

            //Assert.IsTrue(PrimitiveMapper.Map<bool?, sbyte>(true) == 1);
            //Assert.IsTrue(PrimitiveMapper.Map<bool?, sbyte>(false) == 0);
            //Assert.IsTrue(PrimitiveMapper.Map<bool?, sbyte>(null) == 0);

            //Assert.IsTrue(PrimitiveMapper.Map<bool, sbyte?>(true) == 1);
            //Assert.IsNotNull(PrimitiveMapper.Map<bool, sbyte?>(false));

            //Assert.IsTrue(PrimitiveMapper.Map<bool?, sbyte?>(true).Value == 1);
            //Assert.IsTrue(PrimitiveMapper.Map<bool?, sbyte?>(false).Value == 0);
            //Assert.IsNull(PrimitiveMapper.Map<bool?, sbyte?>(null));
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
            Execute("Boolean", true, p => Convert.ToSByte(p.Boolean.Value) == 1);
            Execute("Boolean", false, p => Convert.ToSByte(p.Boolean.Value) == 0);
           

            //Assert.IsTrue(PrimitiveMapper.Map<bool, byte>(true) == 1);
            //Assert.IsTrue(PrimitiveMapper.Map<bool, byte>(false) == 0);

            //Assert.IsTrue(PrimitiveMapper.Map<bool?, byte>(true) == 1);
            //Assert.IsTrue(PrimitiveMapper.Map<bool?, byte>(false) == 0);
            //Assert.IsTrue(PrimitiveMapper.Map<bool?, byte>(null) == 0);

            //Assert.IsTrue(PrimitiveMapper.Map<bool, byte?>(true).Value == 1);
            //Assert.IsTrue(PrimitiveMapper.Map<bool, byte?>(false).Value == 0);

            //Assert.IsTrue(PrimitiveMapper.Map<bool?, byte?>(true).Value == 1);
            //Assert.IsTrue(PrimitiveMapper.Map<bool?, byte?>(false).Value == 0);
            //Assert.IsTrue(PrimitiveMapper.Map<bool?, byte?>(null) == null);
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

            Execute("Boolean", true, p =>Convert.ToInt16(p.Boolean.Value) == 1);
            Execute("Boolean", false, p => Convert.ToInt16(p.Boolean.Value) == 0);
           
            //Assert.IsTrue(PrimitiveMapper.Map<bool, Int16>(true) == 1);
            //Assert.IsTrue(PrimitiveMapper.Map<bool, Int16>(false) == 0);

            //Assert.IsTrue(PrimitiveMapper.Map<bool?, Int16>(true) == 1);
            //Assert.IsTrue(PrimitiveMapper.Map<bool?, Int16>(false) == 0);
            //Assert.IsTrue(PrimitiveMapper.Map<bool?, Int16>(null) == 0);

            //Assert.IsTrue(PrimitiveMapper.Map<bool, Int16?>(true).Value == 1);
            //Assert.IsTrue(PrimitiveMapper.Map<bool, Int16?>(false).Value == 0);

            //Assert.IsTrue(PrimitiveMapper.Map<bool?, Int16?>(true).Value == 1);
            //Assert.IsTrue(PrimitiveMapper.Map<bool?, Int16?>(false).Value == 0);
            //Assert.IsNull(PrimitiveMapper.Map<bool?, Int16?>(null));
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
            Execute("Boolean", true, p => Convert.ToUInt16(p.Boolean.Value) == 1);
            Execute("Boolean", false, p => Convert.ToUInt16(p.Boolean.Value) == 0);
            //Assert.IsTrue(PrimitiveMapper.Map<bool, UInt16>(true) == 1);
            //Assert.IsTrue(PrimitiveMapper.Map<bool, UInt16>(false) == 0);

            //Assert.IsTrue(PrimitiveMapper.Map<bool?, UInt16>(true) == 1);
            //Assert.IsTrue(PrimitiveMapper.Map<bool?, UInt16>(false) == 0);
            //Assert.IsTrue(PrimitiveMapper.Map<bool?, UInt16>(null) == 0);

            //Assert.IsTrue(PrimitiveMapper.Map<bool, UInt16?>(true) == 1);
            //Assert.IsTrue(PrimitiveMapper.Map<bool, UInt16?>(false) == 0);

            //Assert.IsTrue(PrimitiveMapper.Map<bool?, UInt16?>(true) == 1);
            //Assert.IsTrue(PrimitiveMapper.Map<bool?, UInt16?>(false) == 0);
            //Assert.IsNull(PrimitiveMapper.Map<bool?, UInt16?>(null));
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

            Execute("Boolean", true, p => Convert.ToInt32(p.Boolean.Value) == 1);
            Execute("Boolean", false, p => Convert.ToInt32(p.Boolean.Value) == 0);
            //Assert.IsTrue(PrimitiveMapper.Map<bool, Int32>(true) == 1);
            //Assert.IsTrue(PrimitiveMapper.Map<bool, Int32>(false) == 0);

            //Assert.IsTrue(PrimitiveMapper.Map<bool?, Int32>(true) == 1);
            //Assert.IsTrue(PrimitiveMapper.Map<bool?, Int32>(false) == 0);
            //Assert.IsTrue(PrimitiveMapper.Map<bool?, Int32>(null) == 0);

            //Assert.IsTrue(PrimitiveMapper.Map<bool, Int32?>(true).Value == 1);
            //Assert.IsTrue(PrimitiveMapper.Map<bool, Int32?>(false).Value == 0);

            //Assert.IsTrue(PrimitiveMapper.Map<bool?, Int32?>(true).Value == 1);
            //Assert.IsTrue(PrimitiveMapper.Map<bool?, Int32?>(false).Value == 0);
            //Assert.IsNull(PrimitiveMapper.Map<bool?, Int32?>(null));
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

            Execute("Boolean", true, p => Convert.ToUInt32(p.Boolean.Value) == 1);
            Execute("Boolean", false, p => Convert.ToUInt32(p.Boolean.Value) == 0);
            //Assert.IsTrue(PrimitiveMapper.Map<bool, UInt32>(true) == 1);
            //Assert.IsTrue(PrimitiveMapper.Map<bool, UInt32>(false) == 0);

            //Assert.IsTrue(PrimitiveMapper.Map<bool?, UInt32>(true) == 1);
            //Assert.IsTrue(PrimitiveMapper.Map<bool?, UInt32>(false) == 0);
            //Assert.IsTrue(PrimitiveMapper.Map<bool?, UInt32>(null) == 0);

            //Assert.IsTrue(PrimitiveMapper.Map<bool, UInt32?>(true) == 1);
            //Assert.IsTrue(PrimitiveMapper.Map<bool, UInt32?>(false) == 0);

            //Assert.IsTrue(PrimitiveMapper.Map<bool?, UInt32?>(true) == 1);
            //Assert.IsTrue(PrimitiveMapper.Map<bool?, UInt32?>(false) == 0);
            //Assert.IsNull(PrimitiveMapper.Map<bool?, UInt32?>(null));
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
            Execute("Boolean", true, p => Convert.ToInt64(p.Boolean.Value) == 1);
            Execute("Boolean", false, p => Convert.ToInt64(p.Boolean.Value) == 0);
            //Assert.IsTrue(PrimitiveMapper.Map<bool, Int64>(true) == 1);
            //Assert.IsTrue(PrimitiveMapper.Map<bool, Int64>(false) == 0);

            //Assert.IsTrue(PrimitiveMapper.Map<bool?, Int64>(true) == 1);
            //Assert.IsTrue(PrimitiveMapper.Map<bool?, Int64>(false) == 0);
            //Assert.IsTrue(PrimitiveMapper.Map<bool?, Int64>(null) == 0);

            //Assert.IsTrue(PrimitiveMapper.Map<bool, Int64?>(true) == 1);
            //Assert.IsTrue(PrimitiveMapper.Map<bool, Int64?>(false) == 0);

            //Assert.IsTrue(PrimitiveMapper.Map<bool?, Int64?>(true) == 1);
            //Assert.IsTrue(PrimitiveMapper.Map<bool?, Int64?>(false) == 0);
            //Assert.IsNull(PrimitiveMapper.Map<bool?, Int64?>(null));
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
            Execute("Boolean", true, p => Convert.ToUInt64(p.Boolean.Value) == 1);
            Execute("Boolean", false, p => Convert.ToUInt64(p.Boolean.Value) == 0);
            //Assert.IsTrue(PrimitiveMapper.Map<bool, UInt64>(true) == 1);
            //Assert.IsTrue(PrimitiveMapper.Map<bool, UInt64>(false) == 0);

            //Assert.IsTrue(PrimitiveMapper.Map<bool?, UInt64>(true) == 1);
            //Assert.IsTrue(PrimitiveMapper.Map<bool?, UInt64>(false) == 0);
            //Assert.IsTrue(PrimitiveMapper.Map<bool?, UInt64>(null) == 0);

            //Assert.IsTrue(PrimitiveMapper.Map<bool, UInt64?>(true) == 1);
            //Assert.IsTrue(PrimitiveMapper.Map<bool, UInt64?>(false) == 0);

            //Assert.IsTrue(PrimitiveMapper.Map<bool?, UInt64?>(true) == 1);
            //Assert.IsTrue(PrimitiveMapper.Map<bool?, UInt64?>(false) == 0);
            //Assert.IsNull(PrimitiveMapper.Map<bool?, UInt64?>(null));
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
            Execute("Boolean", true, p => Convert.ToSingle(p.Boolean.Value) == 1);
            Execute("Boolean", false, p => Convert.ToSingle(p.Boolean.Value) == 0);
            //Assert.IsTrue(PrimitiveMapper.Map<bool, Single>(true) == 1);
            //Assert.IsTrue(PrimitiveMapper.Map<bool, Single>(false) == 0);

            //Assert.IsTrue(PrimitiveMapper.Map<bool?, Single>(true) == 1);
            //Assert.IsTrue(PrimitiveMapper.Map<bool?, Single>(false) == 0);
            //Assert.IsTrue(PrimitiveMapper.Map<bool?, Single>(null) == 0);

            //Assert.IsTrue(PrimitiveMapper.Map<bool, Single?>(true) == 1);
            //Assert.IsTrue(PrimitiveMapper.Map<bool, Single?>(false) == 0);

            //Assert.IsTrue(PrimitiveMapper.Map<bool?, Single?>(true) == 1);
            //Assert.IsTrue(PrimitiveMapper.Map<bool?, Single?>(false) == 0);
            //Assert.IsNull(PrimitiveMapper.Map<bool?, Single?>(null));
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
            Execute("Boolean", true, p => Convert.ToDouble(p.Boolean.Value) == 1);
            Execute("Boolean", false, p => Convert.ToDouble(p.Boolean.Value) == 0);
            //Assert.IsTrue(PrimitiveMapper.Map<bool, Double>(true) == 1);
            //Assert.IsTrue(PrimitiveMapper.Map<bool, Double>(false) == 0);

            //Assert.IsTrue(PrimitiveMapper.Map<bool?, Double>(true) == 1);
            //Assert.IsTrue(PrimitiveMapper.Map<bool?, Double>(false) == 0);
            //Assert.IsTrue(PrimitiveMapper.Map<bool?, Double>(null) == 0);

            //Assert.IsTrue(PrimitiveMapper.Map<bool, Double?>(true) == 1);
            //Assert.IsTrue(PrimitiveMapper.Map<bool, Double?>(false) == 0);

            //Assert.IsTrue(PrimitiveMapper.Map<bool?, Double?>(true) == 1);
            //Assert.IsTrue(PrimitiveMapper.Map<bool?, Double?>(false) == 0);
            //Assert.IsNull(PrimitiveMapper.Map<bool?, Double?>(null));
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
            Execute("Boolean", true, p => Convert.ToDecimal(p.Boolean.Value) == 1);
            Execute("Boolean", false, p => Convert.ToDecimal(p.Boolean.Value) == 0);
            //Assert.IsTrue(PrimitiveMapper.Map<bool, Decimal>(true) == 1);
            //Assert.IsTrue(PrimitiveMapper.Map<bool, Decimal>(false) == 0);

            //Assert.IsTrue(PrimitiveMapper.Map<bool?, Decimal>(true) == 1);
            //Assert.IsTrue(PrimitiveMapper.Map<bool?, Decimal>(false) == 0);
            //Assert.IsTrue(PrimitiveMapper.Map<bool?, Decimal>(null) == 0);

            //Assert.IsTrue(PrimitiveMapper.Map<bool, Decimal?>(true) == 1);
            //Assert.IsTrue(PrimitiveMapper.Map<bool, Decimal?>(false) == 0);

            //Assert.IsTrue(PrimitiveMapper.Map<bool?, Decimal?>(true) == 1);
            //Assert.IsTrue(PrimitiveMapper.Map<bool?, Decimal?>(false) == 0);
            //Assert.IsNull(PrimitiveMapper.Map<bool?, Decimal?>(null));
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
            b = (String)converter.ConvertTo(a, typeof(String));            Console.WriteLine(b);
             */
            Execute("Boolean", true, p => Convert.ToString(p.Boolean.Value) == "1");
            Execute("Boolean", false, p => Convert.ToString(p.Boolean.Value) == "0");
            //Assert.IsTrue(PrimitiveMapper.Map<bool, string>(true) == "True");
            //bool b = true;
            //string s = b.ToString();
            //Console.WriteLine(s);
        }
        [TestMethod]
        public virtual void Parse()
        {
            Execute("Boolean", true, p => bool.Parse(p.Boolean.Value.ToString()));
            Execute("Boolean", false, p => !bool.Parse(p.Boolean.Value.ToString()));

            //Boolean a = true;
            //String b = "false";
            ////b = "1";
            ////b = "0";
            //a = Boolean.Parse(b);
            //Console.WriteLine(a);
        }
    }
}
