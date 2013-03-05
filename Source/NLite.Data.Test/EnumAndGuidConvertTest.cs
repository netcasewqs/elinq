using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestInitialize = NUnit.Framework.SetUpAttribute;
using TestMethod = NUnit.Framework.TestAttribute;
using NLite.Data.Mapping;
using System.ComponentModel;
using System.Linq.Expressions;

namespace NLite.Data.Test
{
    
    /// <summary>
    /// EnumAndGuidConvertTest 的摘要说明
    /// </summary>
    ///
    [TestClass]
    public class EnumConvertTest
    {
       

        [TestMethod]
        public virtual void ToInt16()
        {
            short i = 5;
            short k = 1;
            short j = 0;
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, short>(DayOfWeek.Friday) == i);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, short>(DayOfWeek.Monday) == k);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, short>(DayOfWeek.Sunday) == j);

            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, short>(DayOfWeek.Friday) == i);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, short>(DayOfWeek.Monday) == k);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, short>(DayOfWeek.Sunday) == j);
            Assert.IsNotNull(PrimitiveMapper.Map<DayOfWeek?, short>(null));

            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, short?>(DayOfWeek.Friday) == i);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, short?>(DayOfWeek.Monday) == k);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, short?>(DayOfWeek.Sunday) == j);

            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, short?>(DayOfWeek.Friday) == i);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, short?>(DayOfWeek.Monday) == k);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, short?>(DayOfWeek.Sunday) == j);
            Assert.IsNull(PrimitiveMapper.Map<DayOfWeek?, short?>(null));
        }
        [TestMethod]
        public virtual void ToUInt16()
        {
            ushort i = 5;
            ushort k = 1;
            ushort j = 0;
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, ushort>(DayOfWeek.Friday) == i);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, ushort>(DayOfWeek.Monday) == k);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, ushort>(DayOfWeek.Sunday) == j);

            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, ushort>(DayOfWeek.Friday) == i);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, ushort>(DayOfWeek.Monday) == k);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, ushort>(DayOfWeek.Sunday) == j);
            Assert.IsNotNull(PrimitiveMapper.Map<DayOfWeek?, ushort>(null));

            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, ushort?>(DayOfWeek.Friday) == i);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, ushort?>(DayOfWeek.Monday) == k);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, ushort?>(DayOfWeek.Sunday) == j);

            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, ushort?>(DayOfWeek.Friday) == i);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, ushort?>(DayOfWeek.Monday) == k);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, ushort?>(DayOfWeek.Sunday) == j);
            Assert.IsNull(PrimitiveMapper.Map<DayOfWeek?, ushort?>(null));
        }
        [TestMethod]
        public virtual void ToInt32()
        {
            int i = 5;
            int k = 1;
            int j = 0;
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, Int32>(DayOfWeek.Friday) == i);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, Int32>(DayOfWeek.Monday) == k);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, Int32>(DayOfWeek.Sunday) == j);

            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?,Int32>(DayOfWeek.Friday)==i);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, Int32>(DayOfWeek.Monday) == k);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, Int32>(DayOfWeek.Sunday) == j);
            Assert.IsNotNull(PrimitiveMapper.Map<DayOfWeek?, Int32>(null));

            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, Int32?>(DayOfWeek.Friday) == i);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, Int32?>(DayOfWeek.Monday) == k);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, Int32?>(DayOfWeek.Sunday) == j);

            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, Int32?>(DayOfWeek.Friday) == i);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, Int32?>(DayOfWeek.Monday) == k);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, Int32?>(DayOfWeek.Sunday) == j);
            Assert.IsNull(PrimitiveMapper.Map<DayOfWeek?, Int32?>(null));
        }
        [TestMethod]
        public virtual void ToUInt32()
        {
            /*DayOfWeek d;
            d = DayOfWeek.Saturday;
            DayOfWeek? dd;
            DayOfWeek? ddy = DayOfWeek.Saturday;
            dd = null;
            uint s;
            uint? ss;

            s = Convert.ToUInt32(d);
            Assert.IsTrue(s == 6);
            s = Convert.ToUInt32(dd);
            Assert.IsTrue(s == 0);
            s = Convert.ToUInt32(ddy);
            Assert.IsTrue(s == 6);
            ss = Convert.ToUInt32(d);
            Assert.IsTrue(ss == 6);
            ss = Convert.ToUInt32(dd);
            Assert.IsTrue(ss == 0);
            ss = Convert.ToUInt32(ddy);
            Assert.IsTrue(ss == 6);*/
            uint i = 5;
            uint k = 1;
            uint j = 0;
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, uint>(DayOfWeek.Friday) == i);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, uint>(DayOfWeek.Monday) == k);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, uint>(DayOfWeek.Sunday) == j);

            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, uint>(DayOfWeek.Friday) == i);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, uint>(DayOfWeek.Monday) == k);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, uint>(DayOfWeek.Sunday) == j);
            Assert.IsNotNull(PrimitiveMapper.Map<DayOfWeek?, uint>(null));

            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, uint?>(DayOfWeek.Friday) == i);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, uint?>(DayOfWeek.Monday) == k);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, uint?>(DayOfWeek.Sunday) == j);

            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, uint?>(DayOfWeek.Friday) == i);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, uint?>(DayOfWeek.Monday) == k);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, uint?>(DayOfWeek.Sunday) == j);
            Assert.IsNull(PrimitiveMapper.Map<DayOfWeek?, uint?>(null));
        }
        [TestMethod]
        public virtual void ToInt64()
        {
            long i = 5;
            long k = 1;
            long j = 0;
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, long>(DayOfWeek.Friday) == i);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, long>(DayOfWeek.Monday) == k);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, long>(DayOfWeek.Sunday) == j);

            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, long>(DayOfWeek.Friday) == i);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, long>(DayOfWeek.Monday) == k);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, long>(DayOfWeek.Sunday) == j);
            Assert.IsNotNull(PrimitiveMapper.Map<DayOfWeek?, long>(null));

            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, long?>(DayOfWeek.Friday) == i);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, long?>(DayOfWeek.Monday) == k);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, long?>(DayOfWeek.Sunday) == j);

            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, long?>(DayOfWeek.Friday) == i);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, long?>(DayOfWeek.Monday) == k);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, long?>(DayOfWeek.Sunday) == j);
            Assert.IsNull(PrimitiveMapper.Map<DayOfWeek?, long?>(null));           
        }
        [TestMethod]
        public virtual void ToUInt64()
        {
            ulong i = 5;
            ulong k = 1;
            ulong j = 0;
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, ulong>(DayOfWeek.Friday) == i);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, ulong>(DayOfWeek.Monday) == k);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, ulong>(DayOfWeek.Sunday) == j);

            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, ulong>(DayOfWeek.Friday) == i);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, ulong>(DayOfWeek.Monday) == k);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, ulong>(DayOfWeek.Sunday) == j);
            Assert.IsNotNull(PrimitiveMapper.Map<DayOfWeek?, ulong>(null));

            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, ulong?>(DayOfWeek.Friday) == i);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, ulong?>(DayOfWeek.Monday) == k);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, ulong?>(DayOfWeek.Sunday) == j);

            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, ulong?>(DayOfWeek.Friday) == i);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, ulong?>(DayOfWeek.Monday) == k);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, ulong?>(DayOfWeek.Sunday) == j);
            Assert.IsNull(PrimitiveMapper.Map<DayOfWeek?, ulong?>(null));
        }
        [TestMethod]
        public virtual void ToSingle()
        {
            Single i = 5;
            Single k = 1;
            Single j = 0;
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, Single>(DayOfWeek.Friday) == i);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, Single>(DayOfWeek.Monday) == k);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, Single>(DayOfWeek.Sunday) == j);

            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, Single>(DayOfWeek.Friday) == i);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, Single>(DayOfWeek.Monday) == k);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, Single>(DayOfWeek.Sunday) == j);
            Assert.IsNotNull(PrimitiveMapper.Map<DayOfWeek?, Single>(null));

            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, Single?>(DayOfWeek.Friday) == i);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, Single?>(DayOfWeek.Monday) == k);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, Single?>(DayOfWeek.Sunday) == j);

            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, Single?>(DayOfWeek.Friday) == i);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, Single?>(DayOfWeek.Monday) == k);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, Single?>(DayOfWeek.Sunday) == j);
            Assert.IsNull(PrimitiveMapper.Map<DayOfWeek?, Single?>(null));
        }
        [TestMethod]
        public virtual void ToDouble()
        {
            double i = 5;
            double k = 1;
            double j = 0;
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, double>(DayOfWeek.Friday) == i);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, double>(DayOfWeek.Monday) == k);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, double>(DayOfWeek.Sunday) == j);

            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, double>(DayOfWeek.Friday) == i);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, double>(DayOfWeek.Monday) == k);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, double>(DayOfWeek.Sunday) == j);
            Assert.IsNotNull(PrimitiveMapper.Map<DayOfWeek?, double>(null));

            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, double?>(DayOfWeek.Friday) == i);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, double?>(DayOfWeek.Monday) == k);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, double?>(DayOfWeek.Sunday) == j);

            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, double?>(DayOfWeek.Friday) == i);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, double?>(DayOfWeek.Monday) == k);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, double?>(DayOfWeek.Sunday) == j);
            Assert.IsNull(PrimitiveMapper.Map<DayOfWeek?, double?>(null));
        }
        [TestMethod]
        public virtual void ToDecimal()
        {
            decimal i = 5M;
            decimal k = 1M;
            decimal j = 0M;
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, decimal>(DayOfWeek.Friday) == i);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, decimal>(DayOfWeek.Monday) == k);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, decimal>(DayOfWeek.Sunday) == j);

            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, decimal>(DayOfWeek.Friday) == i);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, decimal>(DayOfWeek.Monday) == k);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, decimal>(DayOfWeek.Sunday) == j);
            Assert.IsNotNull(PrimitiveMapper.Map<DayOfWeek?, decimal>(null));

            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, decimal?>(DayOfWeek.Friday) == i);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, decimal?>(DayOfWeek.Monday) == k);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, decimal?>(DayOfWeek.Sunday) == j);

            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, decimal?>(DayOfWeek.Friday) == i);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, decimal?>(DayOfWeek.Monday) == k);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, decimal?>(DayOfWeek.Sunday) == j);
            Assert.IsNull(PrimitiveMapper.Map<DayOfWeek?, decimal?>(null));
        }
        [TestMethod]
        public virtual void ToByte()
        {
            byte i = 5;
            byte k = 1;
            byte j = 0;
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, byte>(DayOfWeek.Friday) == i);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, byte>(DayOfWeek.Monday) == k);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, byte>(DayOfWeek.Sunday) == j);

            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, byte>(DayOfWeek.Friday) == i);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, byte>(DayOfWeek.Monday) == k);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, byte>(DayOfWeek.Sunday) == j);
            Assert.IsNotNull(PrimitiveMapper.Map<DayOfWeek?, byte>(null));

            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, byte?>(DayOfWeek.Friday) == i);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, byte?>(DayOfWeek.Monday) == k);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, byte?>(DayOfWeek.Sunday) == j);

            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, byte?>(DayOfWeek.Friday) == i);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, byte?>(DayOfWeek.Monday) == k);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, byte?>(DayOfWeek.Sunday) == j);
            Assert.IsNull(PrimitiveMapper.Map<DayOfWeek?, byte?>(null));
        }
        [TestMethod]
        public virtual void ToSByte()
        {
            sbyte i = 5;
            sbyte k = 1;
            sbyte j = 0;
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, sbyte>(DayOfWeek.Friday) == i);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, sbyte>(DayOfWeek.Monday) == k);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, sbyte>(DayOfWeek.Sunday) == j);

            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, sbyte>(DayOfWeek.Friday) == i);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, sbyte>(DayOfWeek.Monday) == k);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, sbyte>(DayOfWeek.Sunday) == j);
            Assert.IsNotNull(PrimitiveMapper.Map<DayOfWeek?, sbyte>(null));

            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, sbyte?>(DayOfWeek.Friday) == i);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, sbyte?>(DayOfWeek.Monday) == k);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, sbyte?>(DayOfWeek.Sunday) == j);

            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, sbyte?>(DayOfWeek.Friday) == i);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, sbyte?>(DayOfWeek.Monday) == k);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, sbyte?>(DayOfWeek.Sunday) == j);
            Assert.IsNull(PrimitiveMapper.Map<DayOfWeek?, sbyte?>(null));
        }
        [TestMethod]
        public virtual void ToSString()
        {
            string i = "Friday";
            string k = "Monday";
            string j = "Sunday";
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, string>(DayOfWeek.Friday) == i);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, string>(DayOfWeek.Monday) == k);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek, string>(DayOfWeek.Sunday) == j);
             
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, string>(DayOfWeek.Friday) == i);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, string>(DayOfWeek.Monday) == k);
            Assert.IsTrue(PrimitiveMapper.Map<DayOfWeek?, string>(DayOfWeek.Sunday) == j);
            Assert.IsNull(PrimitiveMapper.Map<DayOfWeek?, string>(null));
        }
        [TestMethod]
        public virtual void StringToEnum()
        {
            DayOfWeek i = DayOfWeek.Friday;
            DayOfWeek j = DayOfWeek.Monday;
            DayOfWeek k = DayOfWeek.Sunday;
            Assert.IsTrue(PrimitiveMapper.Map<string, DayOfWeek>("Friday") == i);
            Assert.IsTrue(PrimitiveMapper.Map<string, DayOfWeek>("Monday") == j);
            Assert.IsTrue(PrimitiveMapper.Map<string, DayOfWeek>("Sunday") == k);

            Assert.IsTrue(PrimitiveMapper.Map<string, DayOfWeek?>("Friday") == i);
            Assert.IsTrue(PrimitiveMapper.Map<string, DayOfWeek?>("Monday") == j);
            Assert.IsTrue(PrimitiveMapper.Map<string, DayOfWeek?>("Sunday") == k);
        }
    }
    [TestClass]
    public class NumericConvertEnum
    {
        [TestMethod]
        public virtual void Int16ToEnum()
        {
            /*short i = 4;
            short? ii = 4;
            //int? iiy =null;
            DayOfWeek d;
            DayOfWeek? dd;

            d = (DayOfWeek)i;
            Assert.IsTrue(d == DayOfWeek.Thursday);
            d = (DayOfWeek)ii;
            Assert.IsTrue(d == DayOfWeek.Thursday);
            //d = (DayOfWeek)iiy;
            //Assert.IsNull(d);

            dd = (DayOfWeek)i;
            Assert.IsTrue(dd == DayOfWeek.Thursday);
            dd = (DayOfWeek)ii;
            Assert.IsTrue(dd == DayOfWeek.Thursday);
            //dd = (DayOfWeek)iiy;
            //Assert.IsNull(dd);*/
            short i = 6;
            short j = 1;
            short k = 0;
            Assert.IsTrue(PrimitiveMapper.Map<short,DayOfWeek>(i)==DayOfWeek.Saturday);
            Assert.IsTrue(PrimitiveMapper.Map<short, DayOfWeek>(j) == DayOfWeek.Monday);
            Assert.IsTrue(PrimitiveMapper.Map<short, DayOfWeek>(k) == DayOfWeek.Sunday);

            Assert.IsTrue(PrimitiveMapper.Map<short?, DayOfWeek>(i) == DayOfWeek.Saturday);
            Assert.IsTrue(PrimitiveMapper.Map<short?, DayOfWeek>(j) == DayOfWeek.Monday);
            Assert.IsTrue(PrimitiveMapper.Map<short?, DayOfWeek>(k) == DayOfWeek.Sunday);
            Assert.IsNotNull(PrimitiveMapper.Map<short?, DayOfWeek>(null));

            Assert.IsTrue(PrimitiveMapper.Map<short, DayOfWeek?>(i) == DayOfWeek.Saturday);
            Assert.IsTrue(PrimitiveMapper.Map<short, DayOfWeek?>(j) == DayOfWeek.Monday);
            Assert.IsTrue(PrimitiveMapper.Map<short, DayOfWeek?>(k) == DayOfWeek.Sunday);

            Assert.IsTrue(PrimitiveMapper.Map<short?, DayOfWeek?>(i) == DayOfWeek.Saturday);
            Assert.IsTrue(PrimitiveMapper.Map<short?, DayOfWeek?>(j) == DayOfWeek.Monday);
            Assert.IsTrue(PrimitiveMapper.Map<short?, DayOfWeek?>(k) == DayOfWeek.Sunday);
            Assert.IsNull(PrimitiveMapper.Map<short?, DayOfWeek?>(null));
        }
        [TestMethod]
        public virtual void UInt16ToEnum()
        {
            ushort i = 6;
            ushort j = 1;
            ushort k = 0;
            Assert.IsTrue(PrimitiveMapper.Map<ushort, DayOfWeek>(i) == DayOfWeek.Saturday);
            Assert.IsTrue(PrimitiveMapper.Map<ushort, DayOfWeek>(j) == DayOfWeek.Monday);
            Assert.IsTrue(PrimitiveMapper.Map<ushort, DayOfWeek>(k) == DayOfWeek.Sunday);

            Assert.IsTrue(PrimitiveMapper.Map<ushort?, DayOfWeek>(i) == DayOfWeek.Saturday);
            Assert.IsTrue(PrimitiveMapper.Map<ushort?, DayOfWeek>(j) == DayOfWeek.Monday);
            Assert.IsTrue(PrimitiveMapper.Map<ushort?, DayOfWeek>(k) == DayOfWeek.Sunday);
            Assert.IsNotNull(PrimitiveMapper.Map<ushort?, DayOfWeek>(null));

            Assert.IsTrue(PrimitiveMapper.Map<ushort, DayOfWeek?>(i) == DayOfWeek.Saturday);
            Assert.IsTrue(PrimitiveMapper.Map<ushort, DayOfWeek?>(j) == DayOfWeek.Monday);
            Assert.IsTrue(PrimitiveMapper.Map<ushort, DayOfWeek?>(k) == DayOfWeek.Sunday);

            Assert.IsTrue(PrimitiveMapper.Map<ushort?, DayOfWeek?>(i) == DayOfWeek.Saturday);
            Assert.IsTrue(PrimitiveMapper.Map<ushort?, DayOfWeek?>(j) == DayOfWeek.Monday);
            Assert.IsTrue(PrimitiveMapper.Map<ushort?, DayOfWeek?>(k) == DayOfWeek.Sunday);
            Assert.IsNull(PrimitiveMapper.Map<ushort?, DayOfWeek?>(null));
        }
        [TestMethod]
        public virtual void Int32ToEnum()
        {
            int i = 6;
            int j = 1;
            int k = 0;
            Assert.IsTrue(PrimitiveMapper.Map<int, DayOfWeek>(i) == DayOfWeek.Saturday);
            Assert.IsTrue(PrimitiveMapper.Map<int, DayOfWeek>(j) == DayOfWeek.Monday);
            Assert.IsTrue(PrimitiveMapper.Map<int, DayOfWeek>(k) == DayOfWeek.Sunday);

            Assert.IsTrue(PrimitiveMapper.Map<int?, DayOfWeek>(i) == DayOfWeek.Saturday);
            Assert.IsTrue(PrimitiveMapper.Map<int?, DayOfWeek>(j) == DayOfWeek.Monday);
            Assert.IsTrue(PrimitiveMapper.Map<int?, DayOfWeek>(k) == DayOfWeek.Sunday);
            Assert.IsNotNull(PrimitiveMapper.Map<int?, DayOfWeek>(null));

            Assert.IsTrue(PrimitiveMapper.Map<int, DayOfWeek?>(i) == DayOfWeek.Saturday);
            Assert.IsTrue(PrimitiveMapper.Map<int, DayOfWeek?>(j) == DayOfWeek.Monday);
            Assert.IsTrue(PrimitiveMapper.Map<int, DayOfWeek?>(k) == DayOfWeek.Sunday);

            Assert.IsTrue(PrimitiveMapper.Map<int?, DayOfWeek?>(i) == DayOfWeek.Saturday);
            Assert.IsTrue(PrimitiveMapper.Map<int?, DayOfWeek?>(j) == DayOfWeek.Monday);
            Assert.IsTrue(PrimitiveMapper.Map<int?, DayOfWeek?>(k) == DayOfWeek.Sunday);
            Assert.IsNull(PrimitiveMapper.Map<int?, DayOfWeek?>(null));
        }
        [TestMethod]
        public virtual void UInt32ToEnum()
        {
            uint i = 6;
            uint j = 1;
            uint k = 0;
            Assert.IsTrue(PrimitiveMapper.Map<uint, DayOfWeek>(i) == DayOfWeek.Saturday);
            Assert.IsTrue(PrimitiveMapper.Map<uint, DayOfWeek>(j) == DayOfWeek.Monday);
            Assert.IsTrue(PrimitiveMapper.Map<uint, DayOfWeek>(k) == DayOfWeek.Sunday);

            Assert.IsTrue(PrimitiveMapper.Map<uint?, DayOfWeek>(i) == DayOfWeek.Saturday);
            Assert.IsTrue(PrimitiveMapper.Map<uint?, DayOfWeek>(j) == DayOfWeek.Monday);
            Assert.IsTrue(PrimitiveMapper.Map<uint?, DayOfWeek>(k) == DayOfWeek.Sunday);
            Assert.IsNotNull(PrimitiveMapper.Map<uint?, DayOfWeek>(null));

            Assert.IsTrue(PrimitiveMapper.Map<uint, DayOfWeek?>(i) == DayOfWeek.Saturday);
            Assert.IsTrue(PrimitiveMapper.Map<uint, DayOfWeek?>(j) == DayOfWeek.Monday);
            Assert.IsTrue(PrimitiveMapper.Map<uint, DayOfWeek?>(k) == DayOfWeek.Sunday);

            Assert.IsTrue(PrimitiveMapper.Map<uint?, DayOfWeek?>(i) == DayOfWeek.Saturday);
            Assert.IsTrue(PrimitiveMapper.Map<uint?, DayOfWeek?>(j) == DayOfWeek.Monday);
            Assert.IsTrue(PrimitiveMapper.Map<uint?, DayOfWeek?>(k) == DayOfWeek.Sunday);
            Assert.IsNull(PrimitiveMapper.Map<uint?, DayOfWeek?>(null));
        }
        [TestMethod]
        public virtual void Int64ToEnum()
        {
            long i = 6;
            long j = 1;
            long k = 0;
            Assert.IsTrue(PrimitiveMapper.Map<long, DayOfWeek>(i) == DayOfWeek.Saturday);
            Assert.IsTrue(PrimitiveMapper.Map<long, DayOfWeek>(j) == DayOfWeek.Monday);
            Assert.IsTrue(PrimitiveMapper.Map<long, DayOfWeek>(k) == DayOfWeek.Sunday);

            Assert.IsTrue(PrimitiveMapper.Map<long?, DayOfWeek>(i) == DayOfWeek.Saturday);
            Assert.IsTrue(PrimitiveMapper.Map<long?, DayOfWeek>(j) == DayOfWeek.Monday);
            Assert.IsTrue(PrimitiveMapper.Map<long?, DayOfWeek>(k) == DayOfWeek.Sunday);
            Assert.IsNotNull(PrimitiveMapper.Map<long?, DayOfWeek>(null));

            Assert.IsTrue(PrimitiveMapper.Map<long, DayOfWeek?>(i) == DayOfWeek.Saturday);
            Assert.IsTrue(PrimitiveMapper.Map<long, DayOfWeek?>(j) == DayOfWeek.Monday);
            Assert.IsTrue(PrimitiveMapper.Map<long, DayOfWeek?>(k) == DayOfWeek.Sunday);

            Assert.IsTrue(PrimitiveMapper.Map<long?, DayOfWeek?>(i) == DayOfWeek.Saturday);
            Assert.IsTrue(PrimitiveMapper.Map<long?, DayOfWeek?>(j) == DayOfWeek.Monday);
            Assert.IsTrue(PrimitiveMapper.Map<long?, DayOfWeek?>(k) == DayOfWeek.Sunday);
            Assert.IsNull(PrimitiveMapper.Map<long?, DayOfWeek?>(null));
        }
        [TestMethod]
        public virtual void UInt64ToEnum()
        {
            ulong i = 6;
            ulong j = 1;
            ulong k = 0;
            Assert.IsTrue(PrimitiveMapper.Map<ulong, DayOfWeek>(i) == DayOfWeek.Saturday);
            Assert.IsTrue(PrimitiveMapper.Map<ulong, DayOfWeek>(j) == DayOfWeek.Monday);
            Assert.IsTrue(PrimitiveMapper.Map<ulong, DayOfWeek>(k) == DayOfWeek.Sunday);

            Assert.IsTrue(PrimitiveMapper.Map<ulong?, DayOfWeek>(i) == DayOfWeek.Saturday);
            Assert.IsTrue(PrimitiveMapper.Map<ulong?, DayOfWeek>(j) == DayOfWeek.Monday);
            Assert.IsTrue(PrimitiveMapper.Map<ulong?, DayOfWeek>(k) == DayOfWeek.Sunday);
            Assert.IsNotNull(PrimitiveMapper.Map<ulong?, DayOfWeek>(null));

            Assert.IsTrue(PrimitiveMapper.Map<ulong, DayOfWeek?>(i) == DayOfWeek.Saturday);
            Assert.IsTrue(PrimitiveMapper.Map<ulong, DayOfWeek?>(j) == DayOfWeek.Monday);
            Assert.IsTrue(PrimitiveMapper.Map<ulong, DayOfWeek?>(k) == DayOfWeek.Sunday);

            Assert.IsTrue(PrimitiveMapper.Map<ulong?, DayOfWeek?>(i) == DayOfWeek.Saturday);
            Assert.IsTrue(PrimitiveMapper.Map<ulong?, DayOfWeek?>(j) == DayOfWeek.Monday);
            Assert.IsTrue(PrimitiveMapper.Map<ulong?, DayOfWeek?>(k) == DayOfWeek.Sunday);
            Assert.IsNull(PrimitiveMapper.Map<ulong?, DayOfWeek?>(null));
        }
        [TestMethod]
        public virtual void SingleToEnum()
        {
            Single i = 6;
            Single j = 1;
            Single k = 0;
            Assert.IsTrue(PrimitiveMapper.Map<Single, DayOfWeek>(i) == DayOfWeek.Saturday);
            Assert.IsTrue(PrimitiveMapper.Map<Single, DayOfWeek>(j) == DayOfWeek.Monday);
            Assert.IsTrue(PrimitiveMapper.Map<Single, DayOfWeek>(k) == DayOfWeek.Sunday);

            Assert.IsTrue(PrimitiveMapper.Map<Single?, DayOfWeek>(i) == DayOfWeek.Saturday);
            Assert.IsTrue(PrimitiveMapper.Map<Single?, DayOfWeek>(j) == DayOfWeek.Monday);
            Assert.IsTrue(PrimitiveMapper.Map<Single?, DayOfWeek>(k) == DayOfWeek.Sunday);
            Assert.IsNotNull(PrimitiveMapper.Map<Single?, DayOfWeek>(null));

            Assert.IsTrue(PrimitiveMapper.Map<Single, DayOfWeek?>(i) == DayOfWeek.Saturday);
            Assert.IsTrue(PrimitiveMapper.Map<Single, DayOfWeek?>(j) == DayOfWeek.Monday);
            Assert.IsTrue(PrimitiveMapper.Map<Single, DayOfWeek?>(k) == DayOfWeek.Sunday);

            Assert.IsTrue(PrimitiveMapper.Map<Single?, DayOfWeek?>(i) == DayOfWeek.Saturday);
            Assert.IsTrue(PrimitiveMapper.Map<Single?, DayOfWeek?>(j) == DayOfWeek.Monday);
            Assert.IsTrue(PrimitiveMapper.Map<Single?, DayOfWeek?>(k) == DayOfWeek.Sunday);
            Assert.IsNull(PrimitiveMapper.Map<Single?, DayOfWeek?>(null));
        }
        [TestMethod]
        public virtual void DoubleToEnum()
        {
            double i = 6;
            double j = 1;
            double k = 0;
            Assert.IsTrue(PrimitiveMapper.Map<double, DayOfWeek>(i) == DayOfWeek.Saturday);
            Assert.IsTrue(PrimitiveMapper.Map<double, DayOfWeek>(j) == DayOfWeek.Monday);
            Assert.IsTrue(PrimitiveMapper.Map<double, DayOfWeek>(k) == DayOfWeek.Sunday);

            Assert.IsTrue(PrimitiveMapper.Map<double?, DayOfWeek>(i) == DayOfWeek.Saturday);
            Assert.IsTrue(PrimitiveMapper.Map<double?, DayOfWeek>(j) == DayOfWeek.Monday);
            Assert.IsTrue(PrimitiveMapper.Map<double?, DayOfWeek>(k) == DayOfWeek.Sunday);
            Assert.IsNotNull(PrimitiveMapper.Map<double?, DayOfWeek>(null));

            Assert.IsTrue(PrimitiveMapper.Map<double, DayOfWeek?>(i) == DayOfWeek.Saturday);
            Assert.IsTrue(PrimitiveMapper.Map<double, DayOfWeek?>(j) == DayOfWeek.Monday);
            Assert.IsTrue(PrimitiveMapper.Map<double, DayOfWeek?>(k) == DayOfWeek.Sunday);

            Assert.IsTrue(PrimitiveMapper.Map<double?, DayOfWeek?>(i) == DayOfWeek.Saturday);
            Assert.IsTrue(PrimitiveMapper.Map<double?, DayOfWeek?>(j) == DayOfWeek.Monday);
            Assert.IsTrue(PrimitiveMapper.Map<double?, DayOfWeek?>(k) == DayOfWeek.Sunday);
            Assert.IsNull(PrimitiveMapper.Map<double?, DayOfWeek?>(null));
        }
        [TestMethod]
        //[ExpectedException(typeof(ArgumentException))]
        public virtual void DecimalToEnum()
        {
            decimal i = 6;
            decimal j = 1;
            decimal k = 0;
            Assert.IsTrue(PrimitiveMapper.Map<decimal, DayOfWeek>(i) == DayOfWeek.Saturday);
            Assert.IsTrue(PrimitiveMapper.Map<decimal, DayOfWeek>(j) == DayOfWeek.Monday);
            Assert.IsTrue(PrimitiveMapper.Map<decimal, DayOfWeek>(k) == DayOfWeek.Sunday);

            Assert.IsTrue(PrimitiveMapper.Map<decimal?, DayOfWeek>(i) == DayOfWeek.Saturday);
            Assert.IsTrue(PrimitiveMapper.Map<decimal?, DayOfWeek>(j) == DayOfWeek.Monday);
            Assert.IsTrue(PrimitiveMapper.Map<decimal?, DayOfWeek>(k) == DayOfWeek.Sunday);
            Assert.IsNotNull(PrimitiveMapper.Map<decimal?, DayOfWeek>(null));

            Assert.IsTrue(PrimitiveMapper.Map<decimal, DayOfWeek?>(i) == DayOfWeek.Saturday);
            Assert.IsTrue(PrimitiveMapper.Map<decimal, DayOfWeek?>(j) == DayOfWeek.Monday);
            Assert.IsTrue(PrimitiveMapper.Map<decimal, DayOfWeek?>(k) == DayOfWeek.Sunday);

            Assert.IsTrue(PrimitiveMapper.Map<decimal?, DayOfWeek?>(i) == DayOfWeek.Saturday);
            Assert.IsTrue(PrimitiveMapper.Map<decimal?, DayOfWeek?>(j) == DayOfWeek.Monday);
            Assert.IsTrue(PrimitiveMapper.Map<decimal?, DayOfWeek?>(k) == DayOfWeek.Sunday);
            Assert.IsNull(PrimitiveMapper.Map<decimal?, DayOfWeek?>(null));
        }
        [TestMethod]
        public virtual void ByteToEnum()
        {
            byte i = 6;
            byte j = 1;
            byte k = 0;
            Assert.IsTrue(PrimitiveMapper.Map<byte, DayOfWeek>(i) == DayOfWeek.Saturday);
            Assert.IsTrue(PrimitiveMapper.Map<byte, DayOfWeek>(j) == DayOfWeek.Monday);
            Assert.IsTrue(PrimitiveMapper.Map<byte, DayOfWeek>(k) == DayOfWeek.Sunday);

            Assert.IsTrue(PrimitiveMapper.Map<byte?, DayOfWeek>(i) == DayOfWeek.Saturday);
            Assert.IsTrue(PrimitiveMapper.Map<byte?, DayOfWeek>(j) == DayOfWeek.Monday);
            Assert.IsTrue(PrimitiveMapper.Map<byte?, DayOfWeek>(k) == DayOfWeek.Sunday);
            Assert.IsNotNull(PrimitiveMapper.Map<byte?, DayOfWeek>(null));

            Assert.IsTrue(PrimitiveMapper.Map<byte, DayOfWeek?>(i) == DayOfWeek.Saturday);
            Assert.IsTrue(PrimitiveMapper.Map<byte, DayOfWeek?>(j) == DayOfWeek.Monday);
            Assert.IsTrue(PrimitiveMapper.Map<byte, DayOfWeek?>(k) == DayOfWeek.Sunday);

            Assert.IsTrue(PrimitiveMapper.Map<byte?, DayOfWeek?>(i) == DayOfWeek.Saturday);
            Assert.IsTrue(PrimitiveMapper.Map<byte?, DayOfWeek?>(j) == DayOfWeek.Monday);
            Assert.IsTrue(PrimitiveMapper.Map<byte?, DayOfWeek?>(k) == DayOfWeek.Sunday);
            Assert.IsNull(PrimitiveMapper.Map<byte?, DayOfWeek?>(null));
        }
        [TestMethod]
        public virtual void SByteToEnum()
        {
            sbyte i = 6;
            sbyte j = 1;
            sbyte k = 0;
            Assert.IsTrue(PrimitiveMapper.Map<sbyte, DayOfWeek>(i) == DayOfWeek.Saturday);
            Assert.IsTrue(PrimitiveMapper.Map<sbyte, DayOfWeek>(j) == DayOfWeek.Monday);
            Assert.IsTrue(PrimitiveMapper.Map<sbyte, DayOfWeek>(k) == DayOfWeek.Sunday);

            Assert.IsTrue(PrimitiveMapper.Map<sbyte?, DayOfWeek>(i) == DayOfWeek.Saturday);
            Assert.IsTrue(PrimitiveMapper.Map<sbyte?, DayOfWeek>(j) == DayOfWeek.Monday);
            Assert.IsTrue(PrimitiveMapper.Map<sbyte?, DayOfWeek>(k) == DayOfWeek.Sunday);
            Assert.IsNotNull(PrimitiveMapper.Map<sbyte?, DayOfWeek>(null));

            Assert.IsTrue(PrimitiveMapper.Map<sbyte, DayOfWeek?>(i) == DayOfWeek.Saturday);
            Assert.IsTrue(PrimitiveMapper.Map<sbyte, DayOfWeek?>(j) == DayOfWeek.Monday);
            Assert.IsTrue(PrimitiveMapper.Map<sbyte, DayOfWeek?>(k) == DayOfWeek.Sunday);

            Assert.IsTrue(PrimitiveMapper.Map<sbyte?, DayOfWeek?>(i) == DayOfWeek.Saturday);
            Assert.IsTrue(PrimitiveMapper.Map<sbyte?, DayOfWeek?>(j) == DayOfWeek.Monday);
            Assert.IsTrue(PrimitiveMapper.Map<sbyte?, DayOfWeek?>(k) == DayOfWeek.Sunday);
            Assert.IsNull(PrimitiveMapper.Map<sbyte?, DayOfWeek?>(null));
        }
    }
    [TestClass]
    public class GuidConvertTest
    {
        [TestMethod]
        public virtual void StringToGuid()
        {
            string i = "df793523-e09a-49d9-bf43-54ad35ffde4a";
            string j = "df793523-e09a-49d9-bf43-54ad35ffde41";

            Guid g = new Guid("df793523-e09a-49d9-bf43-54ad35ffde4a");
            Guid gg = new Guid("df793523-e09a-49d9-bf43-54ad35ffde41");

            Assert.IsTrue(PrimitiveMapper.Map<string, Guid>(i) == g );
            Assert.IsTrue(PrimitiveMapper.Map<string, Guid>(j) ==gg );

            Assert.IsTrue(PrimitiveMapper.Map<string, Guid?>(i) == g );
            Assert.IsTrue(PrimitiveMapper.Map<string, Guid?>(j) == gg );
        }
        [TestMethod]
        public virtual void ByteToGuid()
        {
            byte[] i = { 35, 53, 121, 223, 154, 224, 217, 73, 191, 67, 84, 173, 53, 255, 222, 74 };
            byte[] j = { 35, 53, 121, 223, 154, 224, 217, 73, 191, 67, 84, 173, 53, 255, 222, 65 };
            Guid g = new Guid("df793523-e09a-49d9-bf43-54ad35ffde4a");
            Guid gg = new Guid("df793523-e09a-49d9-bf43-54ad35ffde41");

            Assert.IsTrue(PrimitiveMapper.Map<byte[], Guid>(i) == g);
            Assert.IsTrue(PrimitiveMapper.Map<byte[], Guid>(j) == gg);

            //Assert.IsTrue(PrimitiveMapper.Map<byte[], Guid?>(i) == g);
            //Assert.IsTrue(PrimitiveMapper.Map<byte[], Guid?>(j) == gg);


        }
        [TestMethod]
        public virtual void GuidToString()
        {
            Guid g = new Guid("df793523-e09a-49d9-bf43-54ad35ffde4a");
            Guid gg = new Guid("df793523-e09a-49d9-bf43-54ad35ffde41");
            string s = "df793523-e09a-49d9-bf43-54ad35ffde4a";
            string ss = "df793523-e09a-49d9-bf43-54ad35ffde41";

            Console.WriteLine(g);//df793523-e09a-49d9-bf43-54ad35ffde4a
            Assert.AreEqual(PrimitiveMapper.Map<Guid, string>(g),s);
            Assert.IsTrue(PrimitiveMapper.Map<Guid, string>(gg) == ss);

            Assert.IsTrue(PrimitiveMapper.Map<Guid?, string>(g) == s);
            Assert.IsTrue(PrimitiveMapper.Map<Guid?, string>(gg) == ss);
            Assert.IsNull(PrimitiveMapper.Map<Guid?,string>(null));
        }
        [TestMethod]
        //[ExpectedException(typeof(ArgumentException))]
        public virtual void GuidToByteArr()
        {
            /*Guid guid = new Guid("df793523-e09a-49d9-bf43-54ad35ffde4a");
            Guid? guidd = new Guid("df793523-e09a-49d9-bf43-54ad35ffde41");
            //Guid? guidn = null;

            byte[] b;
            b = guid.ToByteArray();
            for (int i = 0; i < b.Length; i++)
            {
                Console.Write(b[i]+",");
            }//35,53,121,223,154,224,217,73,191,67,84,173,53,255,222,74
            Console.WriteLine("------");
            b = guidd.Value.ToByteArray();
            for (int i = 0; i < b.Length; i++)
            {
                Console.Write(b[i]+",");
            }//35,53,121,223,154,224,217,73,191,67,84,173,53,255,222,65
            //b = guidn.Value.ToByteArray();
            //Console.WriteLine(b);*/
            Guid g = new Guid("df793523-e09a-49d9-bf43-54ad35ffde4a");
            Guid gg = new Guid("df793523-e09a-49d9-bf43-54ad35ffde41");
            byte[] s = { 35, 53, 121, 223, 154, 224, 217, 73, 191, 67, 84, 173, 53, 255, 222, 74 };
            byte[] ss = { 35, 53, 121, 223, 154, 224, 217, 73, 191, 67, 84, 173, 53, 255, 222, 65 };

            s.AreEqual(PrimitiveMapper.Map<Guid, byte[]>(g));
            ss.AreEqual(PrimitiveMapper.Map<Guid, byte[]>(gg));

            s.AreEqual(PrimitiveMapper.Map<Guid?, byte[]>(g));
            ss.AreEqual(PrimitiveMapper.Map<Guid?, byte[]>(gg));
            PrimitiveMapper.Map<Guid?, byte[]>(null).AreEqual(null);
        }

      
    }

    public static class CollectionAssert
    {
        public static bool AreEqual<T>(this IEnumerable<T> l, IEnumerable<T> r)
        {
            if (l == r)
                return true;
            if (l == null || r == null)
                return false;

            var items = l.ToArray();
            var items2 = r.ToArray();

            if (items.Length != items2.Length)
                return false;

            for (int i = 0; i < items.Length; i++)
            {
                if (Equals(items[i], items2[i]))
                    return false;
            }

            return true;
        }
    }
}
