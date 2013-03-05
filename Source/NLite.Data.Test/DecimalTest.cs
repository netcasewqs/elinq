using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLite.Data.Test.Primitive;
using NLite.Data.Test.Primitive.Model;
using NUnit.Framework;
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestInitialize = NUnit.Framework.SetUpAttribute;
using TestMethod = NUnit.Framework.TestAttribute;
using NLite.Collections;
using System.Linq.Expressions;
using System.Globalization;

namespace NLite.Data.Test.Where
{
    [TestClass]
    public class DecimalTest:NumbericTest
    {
        protected override string ConnectionStringName
        {
            get
            {
                return "NumericDB";
            }
        }
        public virtual void Execute(object value, Expression<Func<NullableTypeInfo, bool>> filter)
        {
            base.Execute("Decimal", value, filter);
        }
        public virtual void ExecuteNull(object value, Expression<Func<NullableTypeInfo, bool>> filter)
        {
            base.ExecuteNull("Decimal", value, filter);
        }
        [TestMethod]
        public virtual void A_Equal_B()//t0.[Decimal]=0 | t0.[Decimal] IS NULL
        {
            new decimal?[]{ null, 123, 12.3M, 1.23M, -123M, -12.3M,-1,1, 0/*,decimal.MaxValue,decimal.MinValue*/}.ForEach(i=>Execute(i,p=>p.Decimal ==i));
            new int?[] {null,123,-123,-1,1,0, int.MinValue, int.MaxValue}.ForEach(i => Execute(i, p => p.Decimal == i));
            new short?[] { null, 123, -123, -1, 1, 0, short.MinValue, short.MaxValue }.ForEach(i => Execute(i, p => p.Decimal == i));
            new ushort?[] { null, 123, 1, 0, ushort.MinValue, ushort.MaxValue }.ForEach(i => Execute(i, p => p.Decimal == i));
            new sbyte?[] { null, 123, -123, -1, 1, 0, sbyte.MinValue, sbyte.MaxValue}.ForEach(i => Execute(i, p => p.Decimal == i));
            new byte?[] { null, 123, 1, 0, byte.MinValue, byte.MaxValue }.ForEach(i => Execute(i, p => p.Decimal == i));
            new uint?[] { null, 123, 1, 0, uint.MinValue,uint.MaxValue}.ForEach(i => Execute(i, p => p.Decimal == i));
            new float?[] {null,123,12.3F,1.23F,-123F,-12.3F,-1,1,0/*,float.MaxValue,float.MinValue*/}.ForEach(i => Execute(i, p => p.Decimal == (decimal?)i));
            new double?[] { null, 123, 12.3, 1.23, -123, -12.3, -1, 1, 0/*, double.MaxValue, double.MinValue*/ }.ForEach(i => Execute(i, p => p.Decimal == (decimal?)i));
            new long?[] { null, 123,-123,-1, 1, 0/*,long.MaxValue,long.MinValue*/}.ForEach(i => Execute(i, p => p.Decimal == i));
            new ulong?[] {null,123,1,0/*,ulong.MaxValue*/,ulong.MinValue}.ForEach(i => Execute(i, p => p.Decimal == i));
        }
        [TestMethod]
        public virtual void B_Equal_A()//t0.[Decimal]=0 | t0.[Decimal] IS NULL
        {
            new decimal?[] { null, 123, 12.3M, 1.23M, -123M, -12.3M, -1, 1, 0/*,decimal.MaxValue,decimal.MinValue*/}.ForEach(i => Execute(i, p =>i== p.Decimal));
            new int?[] { null, 123, -123, -1, 1, 0, int.MinValue, int.MaxValue }.ForEach(i => Execute(i, p => i == p.Decimal));
            new short?[] { null, 123, -123, -1, 1, 0, short.MinValue, short.MaxValue }.ForEach(i => Execute(i, p => i == p.Decimal));
            new ushort?[] { null, 123, 1, 0, ushort.MinValue, ushort.MaxValue }.ForEach(i => Execute(i, p => i == p.Decimal));
            new sbyte?[] { null, 123, -123, -1, 1, 0, sbyte.MinValue, sbyte.MaxValue }.ForEach(i => Execute(i, p => i == p.Decimal));
            new byte?[] { null, 123, 1, 0, byte.MinValue, byte.MaxValue }.ForEach(i => Execute(i, p => i == p.Decimal));
            new uint?[] { null, 123, 1, 0, uint.MinValue, uint.MaxValue }.ForEach(i => Execute(i, p => i == p.Decimal));
            new float?[] { null, 123, 12.3F, 1.23F, -123F, -12.3F, -1, 1, 0/*,float.MaxValue,float.MinValue*/}.ForEach(i => Execute(i, p => (decimal?)i==p.Decimal));
            new double?[] { null, 123, 12.3, 1.23, -123, -12.3, -1, 1, 0/*, double.MaxValue, double.MinValue*/ }.ForEach(i => Execute(i, p =>(decimal?)i==p.Decimal));
            new long?[] { null, 123, -123, -1, 1, 0/*,long.MaxValue,long.MinValue*/}.ForEach(i => Execute(i, p => i == p.Decimal));
            new ulong?[] { null, 123, 1, 0/*,ulong.MaxValue*/, ulong.MinValue }.ForEach(i => Execute(i, p => i == p.Decimal));

        }
        [TestMethod]
        public virtual void A_Equals_B()//t0.[Decimal]=0 | t0.[Decimal] IS NULL
        {
            new decimal?[] { null, 123, 12.3M, 1.23M, -123M, -12.3M, -1, 1, 0/*,decimal.MaxValue,decimal.MinValue*/}.ForEach(i => Execute(i, p => p.Decimal.Equals(i)));
            new int?[] { null, 123, -123, -1, 1, 0, int.MinValue, int.MaxValue }.ForEach(i => Execute(i, p => p.Decimal.Equals(i)));
            new short?[] { null, 123, -123, -1, 1, 0, short.MinValue, short.MaxValue }.ForEach(i => Execute(i, p => p.Decimal.Equals(i)));
            new ushort?[] { null, 123, 1, 0, ushort.MinValue, ushort.MaxValue }.ForEach(i => Execute(i, p => p.Decimal.Equals(i)));
            new sbyte?[] { null, 123, -123, -1, 1, 0, sbyte.MinValue, sbyte.MaxValue }.ForEach(i => Execute(i, p => p.Decimal.Equals(i)));
            new byte?[] { null, 123, 1, 0, byte.MinValue, byte.MaxValue }.ForEach(i => Execute(i, p => p.Decimal.Equals(i)));
            new uint?[] { null, 123, 1, 0, uint.MinValue, uint.MaxValue }.ForEach(i => Execute(i, p => p.Decimal.Equals(i)));
            new float?[] { null, 123, 12.3F, 1.23F, -123F, -12.3F, -1, 1, 0/*,float.MaxValue,float.MinValue*/}.ForEach(i => Execute(i, p => p.Decimal.Equals(i)));
            new double?[] { null, 123, 12.3, 1.23, -123, -12.3, -1, 1, 0/*, double.MaxValue, double.MinValue*/ }.ForEach(i => Execute(i, p => p.Decimal.Equals(i)));
            new long?[] { null, 123, -123, -1, 1, 0/*,long.MaxValue,long.MinValue*/}.ForEach(i => Execute(i, p => p.Decimal.Equals(i)));
            new ulong?[] { null, 123, 1, 0/*,ulong.MaxValue*/, ulong.MinValue }.ForEach(i => Execute(i, p => p.Decimal.Equals(i)));
        }
        [TestMethod]
        public virtual void B_Equals_A()//t0.[Decimal]=0 | t0.[Decimal] IS NULL
        {
            new decimal?[] { null, 123, 12.3M, 1.23M, -123M, -12.3M, -1, 1, 0/*,decimal.MaxValue,decimal.MinValue*/}.ForEach(i => Execute(i, p =>i.Equals(p.Decimal)));
            new int?[] { null, 123, -123, -1, 1, 0, int.MinValue, int.MaxValue }.ForEach(i => Execute(i, p => i.Equals(p.Decimal)));
            new short?[] { null, 123, -123, -1, 1, 0, short.MinValue, short.MaxValue }.ForEach(i => Execute(i, p => i.Equals(p.Decimal)));
            new ushort?[] { null, 123, 1, 0, ushort.MinValue, ushort.MaxValue }.ForEach(i => Execute(i, p => i.Equals(p.Decimal)));
            new sbyte?[] { null, 123, -123, -1, 1, 0, sbyte.MinValue, sbyte.MaxValue }.ForEach(i => Execute(i, p => i.Equals(p.Decimal)));
            new byte?[] { null, 123, 1, 0, byte.MinValue, byte.MaxValue }.ForEach(i => Execute(i, p => i.Equals(p.Decimal)));
            new uint?[] { null, 123, 1, 0, uint.MinValue, uint.MaxValue }.ForEach(i => Execute(i, p => i.Equals(p.Decimal)));
            new float?[] { null, 123, 12.3F, 1.23F, -123F, -12.3F, -1, 1, 0/*,float.MaxValue,float.MinValue*/}.ForEach(i => Execute(i, p => i.Equals(p.Decimal)));
            new double?[] { null, 123, 12.3, 1.23, -123, -12.3, -1, 1, 0/*, double.MaxValue, double.MinValue*/ }.ForEach(i => Execute(i, p => i.Equals(p.Decimal)));
            new long?[] { null, 123, -123, -1, 1, 0/*,long.MaxValue,long.MinValue*/}.ForEach(i => Execute(i, p => i.Equals(p.Decimal)));
            new ulong?[] { null, 123, 1, 0/*,ulong.MaxValue*/, ulong.MinValue }.ForEach(i => Execute(i, p => i.Equals(p.Decimal)));
        }
        [TestMethod]
        public virtual void Equals_A_And_B()//t0.[Decimal]=0 | t0.[Decimal] IS NULL
        {
            new decimal?[] { null, 123, 12.3M, 1.23M, -123M, -12.3M, -1, 1, 0/*,decimal.MaxValue,decimal.MinValue*/}.ForEach(i => Execute(i, p =>object.Equals(p.Decimal,i)));
            new int?[] { null, 123, -123, -1, 1, 0, int.MinValue, int.MaxValue }.ForEach(i => Execute(i, p => object.Equals(p.Decimal, i)));
            new short?[] { null, 123, -123, -1, 1, 0, short.MinValue, short.MaxValue }.ForEach(i => Execute(i, p => object.Equals(p.Decimal, i)));
            new ushort?[] { null, 123, 1, 0, ushort.MinValue, ushort.MaxValue }.ForEach(i => Execute(i, p => object.Equals(p.Decimal, i)));
            new sbyte?[] { null, 123, -123, -1, 1, 0, sbyte.MinValue, sbyte.MaxValue }.ForEach(i => Execute(i, p => object.Equals(p.Decimal, i)));
            new byte?[] { null, 123, 1, 0, byte.MinValue, byte.MaxValue }.ForEach(i => Execute(i, p => object.Equals(p.Decimal, i)));
            new uint?[] { null, 123, 1, 0, uint.MinValue, uint.MaxValue }.ForEach(i => Execute(i, p => object.Equals(p.Decimal, i)));
            new float?[] { null, 123, 12.3F, 1.23F, -123F, -12.3F, -1, 1, 0/*,float.MaxValue,float.MinValue*/}.ForEach(i => Execute(i, p => object.Equals(p.Decimal, i)));
            new double?[] { null, 123, 12.3, 1.23, -123, -12.3, -1, 1, 0/*, double.MaxValue, double.MinValue*/ }.ForEach(i => Execute(i, p => object.Equals(p.Decimal, i)));
            new long?[] { null, 123, -123, -1, 1, 0/*,long.MaxValue,long.MinValue*/}.ForEach(i => Execute(i, p => object.Equals(p.Decimal, i)));
            new ulong?[] { null, 123, 1, 0/*,ulong.MaxValue*/, ulong.MinValue }.ForEach(i => Execute(i, p => object.Equals(p.Decimal, i)));
        }
        [TestMethod]
        public virtual void A_Equal_Null()//t0.[Decimal] IS NULL)
        {
            new int?[] { null }.ForEach(i => Execute(i, p => p.Decimal == i));
            new short?[] { null }.ForEach(i => Execute(i, p => p.Decimal == i));
            new ushort?[] { null }.ForEach(i => Execute(i, p => p.Decimal == i));
            new sbyte?[] { null }.ForEach(i => Execute(i, p => p.Decimal == i));
            new byte?[] { null }.ForEach(i => Execute(i, p => p.Decimal == i));
            float? a = null;
            Execute(a, p => p.Decimal ==(decimal?)a);
            double? b = null;
            Execute(b, p => p.Decimal == (decimal?)b);
            long? c = null;
            Execute(c, p => p.Decimal == c);
            ulong? d = null;
            Execute(d, p => p.Decimal == (int?)d);
            decimal? e = null;
            Execute(e, p => p.Decimal == e);
        }
        [TestMethod]
        public virtual void A_Equals_Null()//t0.[Decimal] IS NULL
        {
            new int?[] { null }.ForEach(i => Execute(i, p => p.Decimal.Equals(i)));
            new short?[] { null }.ForEach(i => Execute(i, p => p.Decimal.Equals(i)));
            new ushort?[] { null }.ForEach(i => Execute(i, p => p.Decimal.Equals(i)));
            new sbyte?[] { null }.ForEach(i => Execute(i, p => p.Decimal.Equals(i)));
            new byte?[] { null }.ForEach(i => Execute(i, p => p.Decimal.Equals(i)));
            float? a = null;
            Execute(a, p => p.Decimal.Equals(a));
            double? b = null;
            Execute(b, p => p.Decimal.Equals(b));
            long? c = null;
            Execute(c, p => p.Decimal.Equals(c));
            ulong? d = null;
            Execute(d, p => p.Decimal.Equals((decimal?)d));
            decimal? e = null;
            Execute(e, p => p.Decimal.Equals(e));
        }
        [TestMethod]
        public virtual void A_Not_Equal_B()//NOT (t0.[Decimal]=0) | NOT (t0.[Decimal] IS NULL)
        {
            new decimal?[] { null, 123, 12.3M, 1.23M, -123M, -12.3M, -1, 1, 0/*,decimal.MaxValue,decimal.MinValue*/}.ForEach(i => ExecuteNull(i, p => p.Decimal != i));
            new int?[] { null, 123, -123, -1, 1, 0, int.MinValue, int.MaxValue }.ForEach(i => ExecuteNull(i, p => p.Decimal != i));
            new short?[] { null, 123, -123, -1, 1, 0, short.MinValue, short.MaxValue }.ForEach(i => ExecuteNull(i, p => p.Decimal != i));
            new ushort?[] { null, 123, 1, 0, ushort.MinValue, ushort.MaxValue }.ForEach(i => ExecuteNull(i, p => p.Decimal != i));
            new sbyte?[] { null, 123, -123, -1, 1, 0, sbyte.MinValue, sbyte.MaxValue }.ForEach(i => ExecuteNull(i, p => p.Decimal != i));
            new byte?[] { null, 123, 1, 0, byte.MinValue, byte.MaxValue }.ForEach(i => ExecuteNull(i, p => p.Decimal != i));
            new uint?[] { null, 123, 1, 0, uint.MinValue, uint.MaxValue }.ForEach(i => ExecuteNull(i, p => p.Decimal != i));
            new float?[] { null, 123, 12.3F, 1.23F, -123F, -12.3F, -1, 1, 0/*,float.MaxValue,float.MinValue*/}.ForEach(i => ExecuteNull(i, p => p.Decimal != (decimal?)i));
            new double?[] { null, 123, 12.3, 1.23, -123, -12.3, -1, 1, 0/*, double.MaxValue, double.MinValue*/ }.ForEach(i => ExecuteNull(i, p => p.Decimal != (decimal?)i));
            new long?[] { null, 123, -123, -1, 1, 0/*,long.MaxValue,long.MinValue*/}.ForEach(i => ExecuteNull(i, p => p.Decimal != i));
            new ulong?[] { null, 123, 1, 0/*,ulong.MaxValue*/, ulong.MinValue }.ForEach(i => ExecuteNull(i, p => p.Decimal != i));
        }
        [TestMethod]
        public virtual void B_Not_Equal_A()//NOT (t0.[Decimal]=0) | NOT (t0.[Decimal] IS NULL)
        {
            new decimal?[] { null, 123, 12.3M, 1.23M, -123M, -12.3M, -1, 1, 0/*,decimal.MaxValue,decimal.MinValue*/}.ForEach(i => ExecuteNull(i, p => i!=p.Decimal));
            new int?[] { null, 123, -123, -1, 1, 0, int.MinValue, int.MaxValue }.ForEach(i => ExecuteNull(i, p => i != p.Decimal));
            new short?[] { null, 123, -123, -1, 1, 0, short.MinValue, short.MaxValue }.ForEach(i => ExecuteNull(i, p => i != p.Decimal));
            new ushort?[] { null, 123, 1, 0, ushort.MinValue, ushort.MaxValue }.ForEach(i => ExecuteNull(i, p => i != p.Decimal));
            new sbyte?[] { null, 123, -123, -1, 1, 0, sbyte.MinValue, sbyte.MaxValue }.ForEach(i => ExecuteNull(i, p => i != p.Decimal));
            new byte?[] { null, 123, 1, 0, byte.MinValue, byte.MaxValue }.ForEach(i => ExecuteNull(i, p => i != p.Decimal));
            new uint?[] { null, 123, 1, 0, uint.MinValue, uint.MaxValue }.ForEach(i => ExecuteNull(i, p => i != p.Decimal));
            new float?[] { null, 123, 12.3F, 1.23F, -123F, -12.3F, -1, 1, 0/*,float.MaxValue,float.MinValue*/}.ForEach(i => ExecuteNull(i, p =>(decimal?)i!=p.Decimal));
            new double?[] { null, 123, 12.3, 1.23, -123, -12.3, -1, 1, 0/*, double.MaxValue, double.MinValue*/ }.ForEach(i => ExecuteNull(i, p =>(decimal?)i!=p.Decimal));
            new long?[] { null, 123, -123, -1, 1, 0/*,long.MaxValue,long.MinValue*/}.ForEach(i => ExecuteNull(i, p => i != p.Decimal));
            new ulong?[] { null, 123, 1, 0/*,ulong.MaxValue*/, ulong.MinValue }.ForEach(i => ExecuteNull(i, p => i != p.Decimal));
        }
        [TestMethod]
        public virtual void A_Not_Equals_B()//NOT (t0.[Decimal]=0) | NOT (t0.[Decimal] IS NULL)
        {
            new decimal?[] { null, 123, 12.3M, 1.23M, -123M, -12.3M, -1, 1, 0/*,decimal.MaxValue,decimal.MinValue*/}.ForEach(i => ExecuteNull(i, p => !p.Decimal.Equals(i)));
            new int?[] { null, 123, -123, -1, 1, 0, int.MinValue, int.MaxValue }.ForEach(i => ExecuteNull(i, p => !p.Decimal.Equals(i)));
            new short?[] { null, 123, -123, -1, 1, 0, short.MinValue, short.MaxValue }.ForEach(i => ExecuteNull(i, p => !p.Decimal.Equals(i)));
            new ushort?[] { null, 123, 1, 0, ushort.MinValue, ushort.MaxValue }.ForEach(i => ExecuteNull(i, p => !p.Decimal.Equals(i)));
            new sbyte?[] { null, 123, -123, -1, 1, 0, sbyte.MinValue, sbyte.MaxValue }.ForEach(i => ExecuteNull(i, p => !p.Decimal.Equals(i)));
            new byte?[] { null, 123, 1, 0, byte.MinValue, byte.MaxValue }.ForEach(i => ExecuteNull(i, p => !p.Decimal.Equals(i)));
            new uint?[] { null, 123, 1, 0, uint.MinValue, uint.MaxValue }.ForEach(i => ExecuteNull(i, p => !p.Decimal.Equals(i)));
            new float?[] { null, 123, 12.3F, 1.23F, -123F, -12.3F, -1, 1, 0/*,float.MaxValue,float.MinValue*/}.ForEach(i => ExecuteNull(i, p => !p.Decimal.Equals(i)));
            new double?[] { null, 123, 12.3, 1.23, -123, -12.3, -1, 1, 0/*, double.MaxValue, double.MinValue*/ }.ForEach(i => ExecuteNull(i, p => !p.Decimal.Equals(i)));
            new long?[] { null, 123, -123, -1, 1, 0/*,long.MaxValue,long.MinValue*/}.ForEach(i => ExecuteNull(i, p => !p.Decimal.Equals(i)));
            new ulong?[] { null, 123, 1, 0/*,ulong.MaxValue*/, ulong.MinValue }.ForEach(i => ExecuteNull(i, p => !p.Decimal.Equals(i)));
        }
        [TestMethod]
        public virtual void B_Not_Equals_A()//NOT (t0.[Decimal]=0) | NOT (t0.[Decimal] IS NULL)
        {
            new decimal?[] { null, 123, 12.3M, 1.23M, -123M, -12.3M, -1, 1, 0/*,decimal.MaxValue,decimal.MinValue*/}.ForEach(i => ExecuteNull(i, p =>!i.Equals(p.Decimal)));
            new int?[] { null, 123, -123, -1, 1, 0, int.MinValue, int.MaxValue }.ForEach(i => ExecuteNull(i, p => !i.Equals(p.Decimal)));
            new short?[] { null, 123, -123, -1, 1, 0, short.MinValue, short.MaxValue }.ForEach(i => ExecuteNull(i, p => !i.Equals(p.Decimal)));
            new ushort?[] { null, 123, 1, 0, ushort.MinValue, ushort.MaxValue }.ForEach(i => ExecuteNull(i, p => !i.Equals(p.Decimal)));
            new sbyte?[] { null, 123, -123, -1, 1, 0, sbyte.MinValue, sbyte.MaxValue }.ForEach(i => ExecuteNull(i, p => !i.Equals(p.Decimal)));
            new byte?[] { null, 123, 1, 0, byte.MinValue, byte.MaxValue }.ForEach(i => ExecuteNull(i, p => !i.Equals(p.Decimal)));
            new uint?[] { null, 123, 1, 0, uint.MinValue, uint.MaxValue }.ForEach(i => ExecuteNull(i, p => !i.Equals(p.Decimal)));
            new float?[] { null, 123, 12.3F, 1.23F, -123F, -12.3F, -1, 1, 0/*,float.MaxValue,float.MinValue*/}.ForEach(i => ExecuteNull(i, p => !i.Equals(p.Decimal)));
            new double?[] { null, 123, 12.3, 1.23, -123, -12.3, -1, 1, 0/*, double.MaxValue, double.MinValue*/ }.ForEach(i => ExecuteNull(i, p => !i.Equals(p.Decimal)));
            new long?[] { null, 123, -123, -1, 1, 0/*,long.MaxValue,long.MinValue*/}.ForEach(i => ExecuteNull(i, p => !i.Equals(p.Decimal)));
            new ulong?[] { null, 123, 1, 0/*,ulong.MaxValue*/, ulong.MinValue }.ForEach(i => ExecuteNull(i, p => !i.Equals(p.Decimal)));
        }
        [TestMethod]
        public virtual void A_Not_Equal_Null()//NOT (t0.[Decimal] IS NULL)
        {
            new int?[] { null }.ForEach(i => ExecuteNull(i, p => p.Decimal != i));
            new short?[] { null }.ForEach(i => ExecuteNull(i, p => p.Decimal != i));
            new ushort?[] { null }.ForEach(i => ExecuteNull(i, p => p.Decimal != i));
            new sbyte?[] { null }.ForEach(i => ExecuteNull(i, p => p.Decimal != i));
            new byte?[] { null }.ForEach(i => ExecuteNull(i, p => p.Decimal != i));
            float? a = null;
            ExecuteNull(a, p => p.Decimal != (decimal?)a);
            double? b = null;
            ExecuteNull(b, p => p.Decimal != (decimal?)b);
            long? c = null;
            ExecuteNull(c, p => p.Decimal != c);
            ulong? d = null;
            ExecuteNull(d, p => p.Decimal != (int?)d);
            decimal? e = null;
            ExecuteNull(e, p => p.Decimal != e);
        }
        [TestMethod]
        public virtual void A_Not_Equals_Null()//NOT (t0.[Decimal] IS NULL)
        {
            new int?[] { null }.ForEach(i => ExecuteNull(i, p => !p.Decimal.Equals(i)));
            new short?[] { null }.ForEach(i => ExecuteNull(i, p => !p.Decimal.Equals(i)));
            new ushort?[] { null }.ForEach(i => ExecuteNull(i, p => !p.Decimal.Equals(i)));
            new sbyte?[] { null }.ForEach(i => ExecuteNull(i, p => !p.Decimal.Equals(i)));
            new byte?[] { null }.ForEach(i => ExecuteNull(i, p => !p.Decimal.Equals(i)));
            float? a = null;
            ExecuteNull(a, p => !p.Decimal.Equals(a));
            double? b = null;
            ExecuteNull(b, p => !p.Decimal.Equals(b));
            long? c = null;
            ExecuteNull(c, p => !p.Decimal.Equals(c));
            ulong? d = null;
            ExecuteNull(d, p => !p.Decimal.Equals((decimal?)d));
            decimal? e = null;
            ExecuteNull(e, p => !p.Decimal.Equals(e));
        }
        [TestMethod]
        public virtual void A_GreaterThanOrEqual_B()//t0.[Decimal] >= 0 | t0.[Decimal] >= NULL
        {
            new decimal?[] {123, 12.3M, 1.23M, -123M, -12.3M, -1, 1, 0/*,decimal.MaxValue,decimal.MinValue*/}.ForEach(i => Execute(i, p => p.Decimal >= i));
            new int?[] {123, -123, -1, 1, 0, int.MinValue, int.MaxValue }.ForEach(i => Execute(i, p => p.Decimal >= i));
            new short?[] {123, -123, -1, 1, 0, short.MinValue, short.MaxValue }.ForEach(i => Execute(i, p => p.Decimal >= i));
            new ushort?[] {123, 1, 0, ushort.MinValue, ushort.MaxValue }.ForEach(i => Execute(i, p => p.Decimal >= i));
            new sbyte?[] {123, -123, -1, 1, 0, sbyte.MinValue, sbyte.MaxValue }.ForEach(i => Execute(i, p => p.Decimal >= i));
            new byte?[] { 123, 1, 0, byte.MinValue, byte.MaxValue }.ForEach(i => Execute(i, p => p.Decimal >= i));
            new uint?[] {123, 1, 0, uint.MinValue, uint.MaxValue }.ForEach(i => Execute(i, p => p.Decimal >= i));
            new float?[] {123, 12.3F, 1.23F, -123F, -12.3F, -1, 1, 0/*,float.MaxValue,float.MinValue*/}.ForEach(i => Execute(i, p => p.Decimal >= (decimal?)i));
            new double?[] {123, 12.3, 1.23, -123, -12.3, -1, 1, 0/*, double.MaxValue, double.MinValue*/ }.ForEach(i => Execute(i, p => p.Decimal >= (decimal?)i));
            new long?[] {123, -123, -1, 1, 0/*,long.MaxValue,long.MinValue*/}.ForEach(i => Execute(i, p => p.Decimal >= i));
            new ulong?[] {123, 1, 0/*,ulong.MaxValue*/, ulong.MinValue }.ForEach(i => Execute(i, p => p.Decimal >= i));
            decimal? a = null;
            ExecuteNull(a, p => p.Decimal >= null);
        }
        [TestMethod]
        public virtual void B_GreaterThanOrEqual_A()//0 >= t0.[Decimal] | NULL >= t0.[Decimal]
        {
            new decimal?[] {123, 12.3M, 1.23M, -123M, -12.3M, -1, 1, 0/*,decimal.MaxValue,decimal.MinValue*/}.ForEach(i => Execute(i, p => i >= p.Decimal));
            new int?[] {123, -123, -1, 1, 0, int.MinValue, int.MaxValue }.ForEach(i => Execute(i, p => i >= p.Decimal));
            new short?[] {123, -123, -1, 1, 0, short.MinValue, short.MaxValue }.ForEach(i => Execute(i, p => i >= p.Decimal));
            new ushort?[] {123, 1, 0, ushort.MinValue, ushort.MaxValue }.ForEach(i => Execute(i, p => i >= p.Decimal));
            new sbyte?[] {123, -123, -1, 1, 0, sbyte.MinValue, sbyte.MaxValue }.ForEach(i => Execute(i, p => i >= p.Decimal));
            new byte?[] {123, 1, 0, byte.MinValue, byte.MaxValue }.ForEach(i => Execute(i, p => i >= p.Decimal));
            new uint?[] {123, 1, 0, uint.MinValue, uint.MaxValue }.ForEach(i => Execute(i, p => i >= p.Decimal));
            new float?[] {123, 12.3F, 1.23F, -123F, -12.3F, -1, 1, 0/*,float.MaxValue,float.MinValue*/}.ForEach(i => Execute(i, p => (decimal?)i >= p.Decimal));
            new double?[] {123, 12.3, 1.23, -123, -12.3, -1, 1, 0/*, double.MaxValue, double.MinValue*/ }.ForEach(i => Execute(i, p => (decimal?)i >= p.Decimal));
            new long?[] {123, -123, -1, 1, 0/*,long.MaxValue,long.MinValue*/}.ForEach(i => Execute(i, p => i >= p.Decimal));
            new ulong?[] {123, 1, 0/*,ulong.MaxValue*/, ulong.MinValue }.ForEach(i => Execute(i, p => i >= p.Decimal));
            ExecuteNull(null, p => null >= p.Decimal);
        }
        [TestMethod]
        public virtual void A_GreaterThan_B()//t0.[Decimal] > 0 | t0.[Decimal] > NULL
        {
            new decimal?[] { null, 123, 12.3M, 1.23M, -123M, -12.3M, -1, 1, 0/*,decimal.MaxValue,decimal.MinValue*/}.ForEach(i => ExecuteNull(i, p => p.Decimal > i));
            new int?[] { null, 123, -123, -1, 1, 0, int.MinValue, int.MaxValue }.ForEach(i => ExecuteNull(i, p => p.Decimal > i));
            new short?[] { null, 123, -123, -1, 1, 0, short.MinValue, short.MaxValue }.ForEach(i => ExecuteNull(i, p => p.Decimal > i));
            new ushort?[] { null, 123, 1, 0, ushort.MinValue, ushort.MaxValue }.ForEach(i => ExecuteNull(i, p => p.Decimal > i));
            new sbyte?[] { null, 123, -123, -1, 1, 0, sbyte.MinValue, sbyte.MaxValue }.ForEach(i => ExecuteNull(i, p => p.Decimal > i));
            new byte?[] { null, 123, 1, 0, byte.MinValue, byte.MaxValue }.ForEach(i => ExecuteNull(i, p => p.Decimal > i));
            new uint?[] { null, 123, 1, 0, uint.MinValue, uint.MaxValue }.ForEach(i => ExecuteNull(i, p => p.Decimal > i));
            new float?[] { null, 123, 12.3F, 1.23F, -123F, -12.3F, -1, 1, 0/*,float.MaxValue,float.MinValue*/}.ForEach(i => ExecuteNull(i, p => p.Decimal > (decimal?)i));
            new double?[] { null, 123, 12.3, 1.23, -123, -12.3, -1, 1, 0/*, double.MaxValue, double.MinValue*/ }.ForEach(i => ExecuteNull(i, p => p.Decimal > (decimal?)i));
            new long?[] { null, 123, -123, -1, 1, 0/*,long.MaxValue,long.MinValue*/}.ForEach(i => ExecuteNull(i, p => p.Decimal > i));
            new ulong?[] { null, 123, 1, 0/*,ulong.MaxValue*/, ulong.MinValue }.ForEach(i => ExecuteNull(i, p => p.Decimal > i));
        }
        [TestMethod]
        public virtual void B_GreaterThan_A()//0 > t0.[Decimal] | NULL > t0.[Decimal]
        {
            new decimal?[] {null, 123, 12.3M, 1.23M, -123M, -12.3M, -1, 1, 0/*,decimal.MaxValue,decimal.MinValue*/}.ForEach(i => ExecuteNull(i, p => i > p.Decimal));
            new int?[] { null, 123, -123, -1, 1, 0, int.MinValue, int.MaxValue }.ForEach(i => ExecuteNull(i, p => i > p.Decimal));
            new short?[] { null, 123, -123, -1, 1, 0, short.MinValue, short.MaxValue }.ForEach(i => ExecuteNull(i, p => i > p.Decimal));
            new ushort?[] { null, 123, 1, 0, ushort.MinValue, ushort.MaxValue }.ForEach(i => ExecuteNull(i, p => i > p.Decimal));
            new sbyte?[] { null, 123, -123, -1, 1, 0, sbyte.MinValue, sbyte.MaxValue }.ForEach(i => ExecuteNull(i, p => i > p.Decimal));
            new byte?[] { null, 123, 1, 0, byte.MinValue, byte.MaxValue }.ForEach(i => ExecuteNull(i, p => i > p.Decimal));
            new uint?[] { null, 123, 1, 0, uint.MinValue, uint.MaxValue }.ForEach(i => ExecuteNull(i, p => i > p.Decimal));
            new float?[] { null, 123, 12.3F, 1.23F, -123F, -12.3F, -1, 1, 0/*,float.MaxValue,float.MinValue*/}.ForEach(i => ExecuteNull(i, p => (decimal?)i > p.Decimal));
            new double?[] { null, 123, 12.3, 1.23, -123, -12.3, -1, 1, 0/*, double.MaxValue, double.MinValue*/ }.ForEach(i => ExecuteNull(i, p => (decimal?)i > p.Decimal));
            new long?[] { null, 123, -123, -1, 1, 0/*,long.MaxValue,long.MinValue*/}.ForEach(i => ExecuteNull(i, p => i > p.Decimal));
            new ulong?[] { null, 123, 1, 0/*,ulong.MaxValue*/, ulong.MinValue }.ForEach(i => ExecuteNull(i, p => i > p.Decimal));
        }
        [TestMethod]
        public virtual void A_LessThanOrEqual_B()//t0.[Decimal] <= 0 | t0.[Decimal] <= NULL
        {
            new decimal?[] { 123, 12.3M, 1.23M, -123M, -12.3M, -1, 1, 0/*,decimal.MaxValue,decimal.MinValue*/}.ForEach(i => Execute(i, p => p.Decimal <= i));
            new int?[] { 123, -123, -1, 1, 0, int.MinValue, int.MaxValue }.ForEach(i => Execute(i, p => p.Decimal <= i));
            new short?[] { 123, -123, -1, 1, 0, short.MinValue, short.MaxValue }.ForEach(i => Execute(i, p => p.Decimal <= i));
            new ushort?[] { 123, 1, 0, ushort.MinValue, ushort.MaxValue }.ForEach(i => Execute(i, p => p.Decimal <= i));
            new sbyte?[] { 123, -123, -1, 1, 0, sbyte.MinValue, sbyte.MaxValue }.ForEach(i => Execute(i, p => p.Decimal <= i));
            new byte?[] { 123, 1, 0, byte.MinValue, byte.MaxValue }.ForEach(i => Execute(i, p => p.Decimal <= i));
            new uint?[] { 123, 1, 0, uint.MinValue, uint.MaxValue }.ForEach(i => Execute(i, p => p.Decimal <= i));
            new float?[] { 123, 12.3F, 1.23F, -123F, -12.3F, -1, 1, 0/*,float.MaxValue,float.MinValue*/}.ForEach(i => Execute(i, p => p.Decimal <= (decimal?)i));
            new double?[] { 123, 12.3, 1.23, -123, -12.3, -1, 1, 0/*, double.MaxValue, double.MinValue*/ }.ForEach(i => Execute(i, p => p.Decimal <= (decimal?)i));
            new long?[] { 123, -123, -1, 1, 0/*,long.MaxValue,long.MinValue*/}.ForEach(i => Execute(i, p => p.Decimal <= i));
            new ulong?[] { 123, 1, 0/*,ulong.MaxValue*/, ulong.MinValue }.ForEach(i => Execute(i, p => p.Decimal <= i));
            decimal? a = null;
            ExecuteNull(a, p => p.Decimal <= null);
        }
        [TestMethod]
        public virtual void B_LessThanOrEqual_A()//0 <= t0.[Decimal] | NULL <= t0.[Decimal]
        {
            new decimal?[] { 123, 12.3M, 1.23M, -123M, -12.3M, -1, 1, 0/*,decimal.MaxValue,decimal.MinValue*/}.ForEach(i => Execute(i, p => i <= p.Decimal));
            new int?[] { 123, -123, -1, 1, 0, int.MinValue, int.MaxValue }.ForEach(i => Execute(i, p => i <= p.Decimal));
            new short?[] { 123, -123, -1, 1, 0, short.MinValue, short.MaxValue }.ForEach(i => Execute(i, p => i <= p.Decimal));
            new ushort?[] { 123, 1, 0, ushort.MinValue, ushort.MaxValue }.ForEach(i => Execute(i, p => i <= p.Decimal));
            new sbyte?[] { 123, -123, -1, 1, 0, sbyte.MinValue, sbyte.MaxValue }.ForEach(i => Execute(i, p => i <= p.Decimal));
            new byte?[] { 123, 1, 0, byte.MinValue, byte.MaxValue }.ForEach(i => Execute(i, p => i <= p.Decimal));
            new uint?[] { 123, 1, 0, uint.MinValue, uint.MaxValue }.ForEach(i => Execute(i, p => i <= p.Decimal));
            new float?[] { 123, 12.3F, 1.23F, -123F, -12.3F, -1, 1, 0/*,float.MaxValue,float.MinValue*/}.ForEach(i => Execute(i, p => (decimal?)i <= p.Decimal));
            new double?[] { 123, 12.3, 1.23, -123, -12.3, -1, 1, 0/*, double.MaxValue, double.MinValue*/ }.ForEach(i => Execute(i, p => (decimal?)i <= p.Decimal));
            new long?[] { 123, -123, -1, 1, 0/*,long.MaxValue,long.MinValue*/}.ForEach(i => Execute(i, p => i <= p.Decimal));
            new ulong?[] { 123, 1, 0/*,ulong.MaxValue*/, ulong.MinValue }.ForEach(i => Execute(i, p => i <= p.Decimal));
            ExecuteNull(null, p => null <= p.Decimal);
        }
        [TestMethod]
        public virtual void A_LessThan_B()//t0.[Decimal] < 0 | t0.[Decimal] < NULL
        {
            new decimal?[] { null, 123, 12.3M, 1.23M, -123M, -12.3M, -1, 1, 0/*,decimal.MaxValue,decimal.MinValue*/}.ForEach(i => ExecuteNull(i, p => p.Decimal < i));
            new int?[] { null, 123, -123, -1, 1, 0, int.MinValue, int.MaxValue }.ForEach(i => ExecuteNull(i, p => p.Decimal < i));
            new short?[] { null, 123, -123, -1, 1, 0, short.MinValue, short.MaxValue }.ForEach(i => ExecuteNull(i, p => p.Decimal < i));
            new ushort?[] { null, 123, 1, 0, ushort.MinValue, ushort.MaxValue }.ForEach(i => ExecuteNull(i, p => p.Decimal < i));
            new sbyte?[] { null, 123, -123, -1, 1, 0, sbyte.MinValue, sbyte.MaxValue }.ForEach(i => ExecuteNull(i, p => p.Decimal < i));
            new byte?[] { null, 123, 1, 0, byte.MinValue, byte.MaxValue }.ForEach(i => ExecuteNull(i, p => p.Decimal < i));
            new uint?[] { null, 123, 1, 0, uint.MinValue, uint.MaxValue }.ForEach(i => ExecuteNull(i, p => p.Decimal < i));
            new float?[] { null, 123, 12.3F, 1.23F, -123F, -12.3F, -1, 1, 0/*,float.MaxValue,float.MinValue*/}.ForEach(i => ExecuteNull(i, p => p.Decimal < (decimal?)i));
            new double?[] { null, 123, 12.3, 1.23, -123, -12.3, -1, 1, 0/*, double.MaxValue, double.MinValue*/ }.ForEach(i => ExecuteNull(i, p => p.Decimal < (decimal?)i));
            new long?[] { null, 123, -123, -1, 1, 0/*,long.MaxValue,long.MinValue*/}.ForEach(i => ExecuteNull(i, p => p.Decimal < i));
            new ulong?[] { null, 123, 1, 0/*,ulong.MaxValue*/, ulong.MinValue }.ForEach(i => ExecuteNull(i, p => p.Decimal < i));
        }
        [TestMethod]
        public virtual void B_LessThan_A()//0 < t0.[Decimal] | NULL < t0.[Decimal]
        {
            new decimal?[] { null, 123, 12.3M, 1.23M, -123M, -12.3M, -1, 1, 0/*,decimal.MaxValue,decimal.MinValue*/}.ForEach(i => ExecuteNull(i, p => i < p.Decimal));
            new int?[] { null, 123, -123, -1, 1, 0, int.MinValue, int.MaxValue }.ForEach(i => ExecuteNull(i, p => i < p.Decimal));
            new short?[] { null, 123, -123, -1, 1, 0, short.MinValue, short.MaxValue }.ForEach(i => ExecuteNull(i, p => i < p.Decimal));
            new ushort?[] { null, 123, 1, 0, ushort.MinValue, ushort.MaxValue }.ForEach(i => ExecuteNull(i, p => i < p.Decimal));
            new sbyte?[] { null, 123, -123, -1, 1, 0, sbyte.MinValue, sbyte.MaxValue }.ForEach(i => ExecuteNull(i, p => i < p.Decimal));
            new byte?[] { null, 123, 1, 0, byte.MinValue, byte.MaxValue }.ForEach(i => ExecuteNull(i, p => i < p.Decimal));
            new uint?[] { null, 123, 1, 0, uint.MinValue, uint.MaxValue }.ForEach(i => ExecuteNull(i, p => i < p.Decimal));
            new float?[] { null, 123, 12.3F, 1.23F, -123F, -12.3F, -1, 1, 0/*,float.MaxValue,float.MinValue*/}.ForEach(i => ExecuteNull(i, p => (decimal?)i < p.Decimal));
            new double?[] { null, 123, 12.3, 1.23, -123, -12.3, -1, 1, 0/*, double.MaxValue, double.MinValue*/ }.ForEach(i => ExecuteNull(i, p => (decimal?)i < p.Decimal));
            new long?[] { null, 123, -123, -1, 1, 0/*,long.MaxValue,long.MinValue*/}.ForEach(i => ExecuteNull(i, p => i < p.Decimal));
            new ulong?[] { null, 123, 1, 0/*,ulong.MaxValue*/, ulong.MinValue }.ForEach(i => ExecuteNull(i, p => i < p.Decimal));
        }
        [TestMethod]
        public virtual void A_Plus_B()//(t0.[Decimal] + 0) >= 0 |(t0.[Decimal] + NULL) IS NULL
        {
            new decimal?[] {123, 12.3M, 1.23M, -123M, -12.3M, -1, 1, 0/*,decimal.MaxValue,decimal.MinValue*/}.ForEach(i => Execute(i, p => p.Decimal+0 >= i));
            new int?[] {123, -123, -1, 1, 0, int.MinValue, int.MaxValue }.ForEach(i => Execute(i, p => p.Decimal + 0 >= i));
            new short?[] {123, -123, -1, 1, 0, short.MinValue, short.MaxValue }.ForEach(i => Execute(i, p => p.Decimal + 0 >= i));
            new ushort?[] {123, 1, 0, ushort.MinValue, ushort.MaxValue }.ForEach(i => Execute(i, p => p.Decimal + 0 >= i));
            new sbyte?[] {123, -123, -1, 1, 0, sbyte.MinValue, sbyte.MaxValue }.ForEach(i => Execute(i, p => p.Decimal + 0 >= i));
            new byte?[] { 123, 1, 0, byte.MinValue, byte.MaxValue }.ForEach(i => Execute(i, p => p.Decimal + 0 >= i));
            new uint?[] { 123, 1, 0, uint.MinValue, uint.MaxValue }.ForEach(i => Execute(i, p => p.Decimal + 0 >= i));
            new float?[] { 123, 12.3F, 1.23F, -123F, -12.3F, -1, 1, 0/*,float.MaxValue,float.MinValue*/}.ForEach(i => Execute(i, p => p.Decimal+0>= (decimal?)i));
            new double?[] {123, 12.3, 1.23, -123, -12.3, -1, 1, 0/*, double.MaxValue, double.MinValue*/ }.ForEach(i => Execute(i, p => p.Decimal+0>= (decimal?)i));
            new long?[] { 123, -123, -1, 1, 0/*,long.MaxValue,long.MinValue*/}.ForEach(i => Execute(i, p => p.Decimal + 0 >= i));
            new ulong?[] { 123, 1, 0/*,ulong.MaxValue*/, ulong.MinValue }.ForEach(i => Execute(i, p => p.Decimal + 0 >= i));
            new decimal?[] {null,123, 12.3M, 1.23M, -123M, -12.3M, -1, 1, 0}.ForEach(i=>Execute(i,p=>p.Decimal+null ==null));
        }
        [TestMethod]
        public virtual void B_Plus_A()//(0 + t0.[Decimal]) >= 0) | (NULL + t0.[Decimal]) IS NULL
        {
            new decimal?[] { 123, 12.3M, 1.23M, -123M, -12.3M, -1, 1, 0/*,decimal.MaxValue,decimal.MinValue*/}.ForEach(i => Execute(i, p => 0+p.Decimal >= i));
            new int?[] { 123, -123, -1, 1, 0, int.MinValue, int.MaxValue }.ForEach(i => Execute(i, p => 0 + p.Decimal >= i));
            new short?[] { 123, -123, -1, 1, 0, short.MinValue, short.MaxValue }.ForEach(i => Execute(i, p => 0 + p.Decimal >= i));
            new ushort?[] { 123, 1, 0, ushort.MinValue, ushort.MaxValue }.ForEach(i => Execute(i, p => 0 + p.Decimal >= i));
            new sbyte?[] { 123, -123, -1, 1, 0, sbyte.MinValue, sbyte.MaxValue }.ForEach(i => Execute(i, p => 0 + p.Decimal >= i));
            new byte?[] { 123, 1, 0, byte.MinValue, byte.MaxValue }.ForEach(i => Execute(i, p => 0 + p.Decimal >= i));
            new uint?[] { 123, 1, 0, uint.MinValue, uint.MaxValue }.ForEach(i => Execute(i, p => 0 + p.Decimal >= i));
            new float?[] { 123, 12.3F, 1.23F, -123F, -12.3F, -1, 1, 0/*,float.MaxValue,float.MinValue*/}.ForEach(i => Execute(i, p => 0 + p.Decimal >= (decimal?)i));
            new double?[] { 123, 12.3, 1.23, -123, -12.3, -1, 1, 0/*, double.MaxValue, double.MinValue*/ }.ForEach(i => Execute(i, p => 0 + p.Decimal >= (decimal?)i));
            new long?[] { 123, -123, -1, 1, 0/*,long.MaxValue,long.MinValue*/}.ForEach(i => Execute(i, p => 0 + p.Decimal >= i));
            new ulong?[] { 123, 1, 0/*,ulong.MaxValue*/, ulong.MinValue }.ForEach(i => Execute(i, p => 0 + p.Decimal >= i));
            new decimal?[] { null, 123, 12.3M, 1.23M, -123M, -12.3M, -1, 1, 0 }.ForEach(i => Execute(i, p => null+p.Decimal == null));
        }
        [TestMethod]
        public virtual void A_Subtract_B()//(t0.[Decimal] - 0) >= 1 | (t0.[Decimal] - NULL) IS NULL
        {
            new decimal?[] { 123, 12.3M, 1.23M, -123M, -12.3M, -1, 1, 0/*,decimal.MaxValue,decimal.MinValue*/}.ForEach(i => Execute(i, p => p.Decimal - 0 == i));
            new int?[] { 123, -123, -1, 1, 0, int.MinValue, int.MaxValue }.ForEach(i => Execute(i, p => p.Decimal - 0 == i));
            new short?[] { 123, -123, -1, 1, 0, short.MinValue, short.MaxValue }.ForEach(i => Execute(i, p => p.Decimal - 0 == i));
            new ushort?[] { 123, 1, 0, ushort.MinValue, ushort.MaxValue }.ForEach(i => Execute(i, p => p.Decimal - 0== i));
            new sbyte?[] { 123, -123, -1, 1, 0, sbyte.MinValue, sbyte.MaxValue }.ForEach(i => Execute(i, p => p.Decimal - 0== i));
            new byte?[] { 123, 1, 0, byte.MinValue, byte.MaxValue }.ForEach(i => Execute(i, p => p.Decimal - 0 == i));
            new uint?[] { 123, 1, 0, uint.MinValue, uint.MaxValue }.ForEach(i => Execute(i, p => p.Decimal - 0 == i));
            new float?[] { 123, 12.3F, 1.23F, -123F, -12.3F, -1, 1, 0/*,float.MaxValue,float.MinValue*/}.ForEach(i => Execute(i, p => p.Decimal - 0 == (decimal?)i));
            new double?[] { 123, 12.3, 1.23, -123, -12.3, -1, 1, 0/*, double.MaxValue, double.MinValue*/ }.ForEach(i => Execute(i, p => p.Decimal - 0 == (decimal?)i));
            new long?[] { 123, -123, -1, 1, 0/*,long.MaxValue,long.MinValue*/}.ForEach(i => Execute(i, p => p.Decimal - 0 == i));
            new ulong?[] { 123, 1, 0/*,ulong.MaxValue*/, ulong.MinValue }.ForEach(i => Execute(i, p => p.Decimal - 0 == i));
            new decimal?[] { null, 123, 12.3M, 1.23M, -123M, -12.3M, -1, 1, 0 }.ForEach(i => Execute(i, p => p.Decimal - null == null));
        }
        [TestMethod]
        public virtual void B_Subtract_A()//(1 - t0.[Decimal])=0 | (NULL - t0.[Decimal]) IS NULL
        {
            new decimal?[] { 123, 12.3M, 1.23M, -123M, -12.3M, -1, 1, 0/*,decimal.MaxValue,decimal.MinValue*/}.ForEach(i => Execute(i, p => i-p.Decimal == 0M));
            new float?[] { 123, 12.3F, 1.23F, -123F, -12.3F, -1, 1, 0/*,float.MaxValue,float.MinValue*/}.ForEach(i => Execute(i, p => (decimal?)i-p.Decimal==0));
            new double?[] { 123, 12.3, 1.23, -123, -12.3, -1, 1, 0/*, double.MaxValue, double.MinValue*/ }.ForEach(i => Execute(i, p =>(decimal?)i-p.Decimal==0));
            new decimal?[] { null, 123, 12.3M, 1.23M, -123M, -12.3M, -1, 1, 0 }.ForEach(i => Execute(i, p => null-p.Decimal== null));
            new int?[] { 123, -123, -1, 1, 0, int.MinValue, int.MaxValue }.ForEach(i => Execute(i, p => i - p.Decimal == 0));
            new short?[] { 123, -123, -1, 1, 0, short.MinValue, short.MaxValue }.ForEach(i => Execute(i, p => i - p.Decimal == 0));
            new ushort?[] { 123, 1, 0, ushort.MinValue, ushort.MaxValue }.ForEach(i => Execute(i, p => i - p.Decimal == 0));
            new sbyte?[] { 123, -123, -1, 1, 0, sbyte.MinValue, sbyte.MaxValue }.ForEach(i => Execute(i, p => i - p.Decimal == 0));
            new byte?[] { 123, 1, 0, byte.MinValue, byte.MaxValue }.ForEach(i => Execute(i, p => i - p.Decimal == 0));
            new uint?[] { 123, 1, 0, uint.MinValue, uint.MaxValue }.ForEach(i => Execute(i, p => i - p.Decimal == 0));
            new long?[] { 123, -123, -1, 1, 0/*,long.MaxValue,long.MinValue*/}.ForEach(i => Execute(i, p => i - p.Decimal == 0));
            new ulong?[] { 123, 1, 0/*,ulong.MaxValue*/, ulong.MinValue }.ForEach(i => Execute(i, p => i - p.Decimal == 0));
        }
        [TestMethod]
        public virtual void A_Multiply_B()//(t0.[Decimal] * 1)=0 | (t0.[Decimal] * NULL) IS NULL
        {
            new decimal?[] { 123, 12.3M, 1.23M, -123M, -12.3M, -1, 1, 0/*,decimal.MaxValue,decimal.MinValue*/}.ForEach(i => Execute(i, p => p.Decimal * 1 == i));
            new int?[] { 123, -123, -1, 1, 0, int.MinValue, int.MaxValue }.ForEach(i => Execute(i, p => p.Decimal * 1 == i));
            new short?[] { 123, -123, -1, 1, 0, short.MinValue, short.MaxValue }.ForEach(i => Execute(i, p => p.Decimal * 1 == i));
            new ushort?[] { 123, 1, 0, ushort.MinValue, ushort.MaxValue }.ForEach(i => Execute(i, p => p.Decimal * 1 == i));
            new sbyte?[] { 123, -123, -1, 1, 0, sbyte.MinValue, sbyte.MaxValue }.ForEach(i => Execute(i, p => p.Decimal * 1 == i));
            new byte?[] { 123, 1, 0, byte.MinValue, byte.MaxValue }.ForEach(i => Execute(i, p => p.Decimal * 1 == i));
            new uint?[] { 123, 1, 0, uint.MinValue, uint.MaxValue }.ForEach(i => Execute(i, p => p.Decimal * 1 == i));
            new float?[] { 123, 12.3F, 1.23F, -123F, -12.3F, -1, 1, 0/*,float.MaxValue,float.MinValue*/}.ForEach(i => Execute(i, p => p.Decimal * 1 == (decimal?)i));
            new double?[] { 123, 12.3, 1.23, -123, -12.3, -1, 1, 0/*, double.MaxValue, double.MinValue*/ }.ForEach(i => Execute(i, p => p.Decimal * 1 == (decimal?)i));
            new long?[] { 123, -123, -1, 1, 0/*,long.MaxValue,long.MinValue*/}.ForEach(i => Execute(i, p => p.Decimal * 1 == i));
            new ulong?[] { 123, 1, 0/*,ulong.MaxValue*/, ulong.MinValue }.ForEach(i => Execute(i, p => p.Decimal * 1 == i));
            new decimal?[] { null, 123, 12.3M, 1.23M, -123M, -12.3M, -1, 1, 0 }.ForEach(i => Execute(i, p => p.Decimal * null == null));
        }
        [TestMethod]
        public virtual void B_Multiply_A()//(1 * t0.[Decimal])=0 | (NULL * t0.[Decimal]) IS NULL
        {
            new decimal?[] { 123, 12.3M, 1.23M, -123M, -12.3M, -1, 1, 0/*,decimal.MaxValue,decimal.MinValue*/}.ForEach(i => Execute(i, p => 1* p.Decimal == i));
            new int?[] { 123, -123, -1, 1, 0, int.MinValue, int.MaxValue }.ForEach(i => Execute(i, p => 1 * p.Decimal == i));
            new short?[] { 123, -123, -1, 1, 0, short.MinValue, short.MaxValue }.ForEach(i => Execute(i, p => 1 * p.Decimal == i));
            new ushort?[] { 123, 1, 0, ushort.MinValue, ushort.MaxValue }.ForEach(i => Execute(i, p => 1 * p.Decimal == i));
            new sbyte?[] { 123, -123, -1, 1, 0, sbyte.MinValue, sbyte.MaxValue }.ForEach(i => Execute(i, p => 1 * p.Decimal == i));
            new byte?[] { 123, 1, 0, byte.MinValue, byte.MaxValue }.ForEach(i => Execute(i, p => 1 * p.Decimal == i));
            new uint?[] { 123, 1, 0, uint.MinValue, uint.MaxValue }.ForEach(i => Execute(i, p => 1 * p.Decimal == i));
            new float?[] { 123, 12.3F, 1.23F, -123F, -12.3F, -1, 1, 0/*,float.MaxValue,float.MinValue*/}.ForEach(i => Execute(i, p => 1 * p.Decimal == (decimal?)i));
            new double?[] { 123, 12.3, 1.23, -123, -12.3, -1, 1, 0/*, double.MaxValue, double.MinValue*/ }.ForEach(i => Execute(i, p => 1 * p.Decimal == (decimal?)i));
            new long?[] { 123, -123, -1, 1, 0/*,long.MaxValue,long.MinValue*/}.ForEach(i => Execute(i, p => 1 * p.Decimal == i));
            new ulong?[] { 123, 1, 0/*,ulong.MaxValue*/, ulong.MinValue }.ForEach(i => Execute(i, p => 1 * p.Decimal == i));
            new decimal?[] { null, 123, 12.3M, 1.23M, -123M, -12.3M, -1, 1, 0 }.ForEach(i => Execute(i, p => null * p.Decimal == null));
        }
        [TestMethod]
        public virtual void A_Divide_B()//(t0.[Decimal] / 1)=0 | (t0.[Decimal] / NULL) IS NULL
        {
            new decimal?[] { 123, 12.3M, 1.23M, -123M, -12.3M, -1, 1, 0/*,decimal.MaxValue,decimal.MinValue*/}.ForEach(i => Execute(i, p => p.Decimal / 1 == i));
            new int?[] { 123, -123, -1, 1, 0, int.MinValue, int.MaxValue }.ForEach(i => Execute(i, p => p.Decimal / 1 == i));
            new short?[] { 123, -123, -1, 1, 0, short.MinValue, short.MaxValue }.ForEach(i => Execute(i, p => p.Decimal / 1 == i));
            new ushort?[] { 123, 1, 0, ushort.MinValue, ushort.MaxValue }.ForEach(i => Execute(i, p => p.Decimal / 1 == i));
            new sbyte?[] { 123, -123, -1, 1, 0, sbyte.MinValue, sbyte.MaxValue }.ForEach(i => Execute(i, p => p.Decimal / 1 == i));
            new byte?[] { 123, 1, 0, byte.MinValue, byte.MaxValue }.ForEach(i => Execute(i, p => p.Decimal / 1 == i));
            new uint?[] { 123, 1, 0, uint.MinValue, uint.MaxValue }.ForEach(i => Execute(i, p => p.Decimal / 1 == i));
            new float?[] { 123, 12.3F, 1.23F, -123F, -12.3F, -1, 1, 0/*,float.MaxValue,float.MinValue*/}.ForEach(i => Execute(i, p => p.Decimal / 1 == (decimal?)i));
            new double?[] { 123, 12.3, 1.23, -123, -12.3, -1, 1, 0/*, double.MaxValue, double.MinValue*/ }.ForEach(i => Execute(i, p => p.Decimal / 1 == (decimal?)i));
            new long?[] { 123, -123, -1, 1, 0/*,long.MaxValue,long.MinValue*/}.ForEach(i => Execute(i, p => p.Decimal / 1 == i));
            new ulong?[] { 123, 1, 0/*,ulong.MaxValue*/, ulong.MinValue }.ForEach(i => Execute(i, p => p.Decimal / 1 == i));
            new decimal?[] { null, 123, 12.3M, 1.23M, -123M, -12.3M, -1, 1, 0 }.ForEach(i => Execute(i, p => p.Decimal / null == null));
        }
        [TestMethod]
        public virtual void B_Divide_A()//(1 / t0.[Decimal])=1 | (NULL / t0.[Decimal]) IS NULL | (0 / t0.[Decimal])=0
        {
            new decimal?[] { 123, 12.3M, 1.23M, -123M, -12.3M, -1, 1/*,decimal.MaxValue,decimal.MinValue*/}.ForEach(i => Execute(i, p => i / p.Decimal == 1));
            new int?[] { 123, -123, -1, 1,int.MinValue, int.MaxValue }.ForEach(i => Execute(i, p => i / p.Decimal == 1));
            new short?[] { 123, -123, -1, 1,short.MinValue, short.MaxValue }.ForEach(i => Execute(i, p => i / p.Decimal == 1));
            new ushort?[] { 123, 1, ushort.MaxValue }.ForEach(i => Execute(i, p => i / p.Decimal == 1));
            new sbyte?[] { 123, -123, -1, 1,sbyte.MinValue, sbyte.MaxValue }.ForEach(i => Execute(i, p => i / p.Decimal == 1));
            new byte?[] { 123, 1, byte.MaxValue }.ForEach(i => Execute(i, p => i / p.Decimal == 1));
            new uint?[] { 123, 1,uint.MaxValue }.ForEach(i => Execute(i, p => i / p.Decimal == 1));
            new float?[] { 123, 12.3F, 1.23F, -123F, -12.3F, -1, 1/*,float.MaxValue,float.MinValue*/}.ForEach(i => Execute(i, p => (decimal?)i/ p.Decimal ==1 ));
            new double?[] { 123, 12.3, 1.23, -123, -12.3, -1, 1/*, double.MaxValue, double.MinValue*/ }.ForEach(i => Execute(i, p => (decimal?)i/p.Decimal==1));
            new long?[] { 123, -123, -1, 1/*,long.MaxValue,long.MinValue*/}.ForEach(i => Execute(i, p => i/p.Decimal==1));
            new ulong?[] { 123, 1 }.ForEach(i => Execute(i, p => i / p.Decimal == 1));
            new decimal?[] { null, 123, 12.3M, 1.23M, -123M, -12.3M, -1, 1}.ForEach(i => Execute(i, p => null / p.Decimal == null));
            Execute(null, p => 0 / p.Decimal == null);
            new decimal?[] { 123, 12.3M, 1.23M,1 }.ForEach(i => Execute(i, p => 0M / p.Decimal == 0M));
#if !SqlCE&&!SqlCE_SDK3_5
            new decimal?[] { -123, -12.3M, -1.23M, -1 }.ForEach(i => Execute(i, p => 0M / p.Decimal == 0M));
#endif
        }
        [TestMethod]
        public virtual void A_Modulo_B()
        { 
        }
        [TestMethod]
        public virtual void B_Modulo_A()
        {
        }
        [TestMethod]
        public virtual void Zero_Modulo_A()
        {
        }
        [TestMethod]
        public virtual void Null_Plus_A()//(NULL + t0.[Decimal]) IS NULL
        {
            new decimal?[] { null,123,12.3M,1.23M,-123M,-12.3M,-1,1,0}.ForEach(i=>Execute(i,p=>null+p.Decimal==null));
        }
        [TestMethod]
        public virtual void Null_Subtract_A()//(NULL - t0.[Decimal]) IS NULL
        {
            new decimal?[] { null, 123, 12.3M, 1.23M, -123M, -12.3M, -1, 1, 0 }.ForEach(i => Execute(i, p => null - p.Decimal == null));
        }
        [TestMethod]
        public virtual void Null_Miltiply_A()//(NULL * t0.[Decimal]) IS NULL
        {
            new decimal?[] { null, 123, 12.3M, 1.23M, -123M, -12.3M, -1, 1, 0 }.ForEach(i => Execute(i, p => null * p.Decimal == null));
        }
        [TestMethod]
        public virtual void Null_Divide_A()//(NULL / t0.[Decimal]) IS NULL
        {
            new decimal?[] { null, 123, 12.3M, 1.23M, -123M, -12.3M, -1, 1,0}.ForEach(i => Execute(i, p => null / p.Decimal == null));
        }
        [TestMethod]
        public virtual void Null_Modulo_A()
        {
        }
        [TestMethod]
        public virtual void B_Plus_Plus()
        { }
        [TestMethod]
        public virtual void Plus_Plus_B()
        { }
        [TestMethod]
        public virtual void B_Minus_Minus()
        { }
        [TestMethod]
        public virtual void Minus_Minus_B()
        {
            Console.WriteLine(int.MinValue);
        }
        [TestMethod]
        public virtual void A_Equal_Opposite_B()//-t0.[Decimal]=0 | -t0.[Decimal] IS NULL
        {
            new decimal?[] { null, 123, 12.3M, 1.23M, -123M, -12.3M, -1, 1, 0 }.ForEach(i => Execute(-i, p => -p.Decimal == i));
            new int?[] { null, 123, -123, -1, 1, 0, int.MinValue, int.MaxValue }.ForEach(i => Execute(-(decimal?)i, p => -p.Decimal == i));
            new short?[] { null, 123, -123, -1, 1, 0, short.MinValue, short.MaxValue }.ForEach(i => Execute(-i, p => -p.Decimal == i));
            new ushort?[] { null, 123, 1, 0, ushort.MinValue, ushort.MaxValue }.ForEach(i => Execute(-i, p => -p.Decimal == i));
            new sbyte?[] { null, 123, -123, -1, 1, 0, sbyte.MinValue, sbyte.MaxValue }.ForEach(i => Execute(-i, p => -p.Decimal == i));
            new byte?[] { null, 123, 1, 0, byte.MinValue, byte.MaxValue }.ForEach(i => Execute(-i, p => -p.Decimal == i));
            new uint?[] { null, 123, 1, 0, uint.MinValue, uint.MaxValue }.ForEach(i => Execute(-i, p => -p.Decimal == i));
            new float?[] { null, 123, 12.3F, 1.23F, -123F, -12.3F, -1, 1, 0/*,float.MaxValue,float.MinValue*/}.ForEach(i => Execute(-i, p => -p.Decimal == (decimal?)i));
            new double?[] { null, 123, 12.3, 1.23, -123, -12.3, -1, 1, 0/*, double.MaxValue, double.MinValue*/ }.ForEach(i => Execute(-i, p => -p.Decimal == (decimal?)i));
            new long?[] { null, 123, -123, -1, 1, 0/*,long.MaxValue,long.MinValue*/}.ForEach(i => Execute(-i, p => -p.Decimal == i));
            new ulong?[] { null, 123, 1, 0/*,ulong.MaxValue*/, ulong.MinValue }.ForEach(i => Execute(i, p => -p.Decimal == -(decimal?)i));
        }
        [TestMethod]
        public virtual void A_And_Equal_B()
        { }
        [TestMethod]
        public virtual void A_Divide_Equal_B()
        { }
        [TestMethod]
        public virtual void A_Model_Equal_B()
        { }
        [TestMethod]
        public virtual void A_qufan_Equal_B()
        { }
        [TestMethod]
        public virtual void A_weiyu_Equal_B()
        { }
        [TestMethod]
        public virtual void A_weihuo_Equal_B()
        { }
        [TestMethod]
        public virtual void A_Equal_Not_B()
        {
            //new decimal?[] { null, 123, 12.3M, 1.23M, -123M, -12.3M, -1, 1, 0 }.ForEach(i => Execute(~(int?)i, p => ~(int?)p.Decimal == i));
        }
        [TestMethod]
        public virtual void A_And_B()
        {
            //new decimal?[] { null, 123, 12.3M, 1.23M, -123M, -12.3M, -1, 1, 0 }.ForEach(i => Execute(i, p => p.Decimal & i == (int?)i));
        }
        [TestMethod]
        public virtual void A_Or_B()
        { }
        [TestMethod]
        public virtual void A_ExclusiveOr_B()
        { }
        [TestMethod]
        public virtual void A_Right_Shift_B()
        { }
        [TestMethod]
        public virtual void A_Left_Shift_B()
        { }
        [TestMethod]
        public virtual void A_And_And_B()//(t0.[Decimal] <= 0) AND NOT (t0.String IS NULL)
        {
            new decimal?[] { null, 123, 12.3M, 1.23M, -123M, -12.3M, -1, 1, 0 }.ForEach(i=>Execute(i,p=>p.Decimal==i&&p.String!=null));
            new decimal?[] { 123, 12.3M, 1.23M, -123M, -12.3M, -1, 1, 0 }.ForEach(i => Execute(i, p => p.Decimal >= i && p.String != null));
            new decimal?[] {123, 12.3M, 1.23M, -123M, -12.3M, -1, 1, 0 }.ForEach(i => Execute(i, p => p.Decimal <= i && p.String != null));
        }
        [TestMethod]
        public virtual void A_Or_Or_B()//(t0.[Decimal] < 0) OR (t0.String IS NULL)
        {
            new decimal?[] { null, 123, 12.3M, 1.23M, -123M, -12.3M, -1, 1, 0 }.ForEach(i => Execute(i, p => p.Decimal == i || p.String != null));
            new decimal?[] { 123, 12.3M, 1.23M, -123M, -12.3M, -1, 1, 0 }.ForEach(i => Execute(i, p => p.Decimal >= i || p.String == null));
            new decimal?[] { 123, 12.3M, 1.23M, -123M, -12.3M, -1, 1, 0 }.ForEach(i => ExecuteNull(i, p => p.Decimal < i || p.String == null));
        }
        [TestMethod]
        public virtual void A_Between_C_And_D()
        { }
        [TestMethod]
        public virtual void List_Contains_A()
        { }

    }
}
