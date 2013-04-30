using System;
using System.Linq.Expressions;
using NLite.Collections;
using NLite.Data.Test.Primitive.Model;
using NUnit.Framework;
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestMethod = NUnit.Framework.TestAttribute;


namespace NLite.Data.Test.Where
{

    [TestClass]
    public class Int32Test : NumbericTest
    {
#if Firebird
        protected override void CreateDbContext()
        {
            CreateFirebirdContext();
        }
#endif

        protected override string ConnectionStringName
        {
            get
            {
                return "NumericDB";
            }
        }
        public virtual void Execute(object value, Expression<Func<NullableTypeInfo, bool>> filter)
        {
            base.Execute("Int32", value, filter);
        }
        public virtual void ExecuteNull(object value, Expression<Func<NullableTypeInfo, bool>> filter)
        {
            base.ExecuteNull("Int32", value, filter);
        }


        [TestMethod]
        public virtual void A_Equal_B()
        {
            new int?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19, null }.ForEach(i => Execute(i, p => p.Int32 == i));
            new short?[] { short.MinValue, short.MaxValue, 1, 0, -1, 19, null }.ForEach(i => Execute(i, p => p.Int32 == i));
            new ushort?[] { ushort.MinValue, ushort.MaxValue, 1, 0, 19, null }.ForEach(i => Execute(i, p => p.Int32 == i));
            new sbyte?[] { sbyte.MinValue, sbyte.MaxValue, 1, 0, -1, 19, null }.ForEach(i => Execute(i, p => p.Int32 == i));
            new byte?[] { byte.MinValue, byte.MaxValue, 1, 0, 19, null }.ForEach(i => Execute(i, p => p.Int32 == i));
            new uint?[] { uint.MinValue, 1, 0, 19, null }.ForEach(i => Execute(i, p => p.Int32 == i));
            new float?[] { int.MinValue,/*2147483646, */1, 0, -1, 19 }.ForEach(i => Execute(i, p => p.Int32 == (int?)i));
            new double?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19, null }.ForEach(i => Execute(i, p => p.Int32 == i));
            new long?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19, null }.ForEach(i => Execute(i, p => p.Int32 == i));
            new ulong?[] { int.MaxValue, 1, 0, 19 }.ForEach(i => Execute(i, p => p.Int32 == (int?)i));
            new decimal?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19, null }.ForEach(i => Execute(i, p => p.Int32 == i));
        }
        [TestMethod]
        public virtual void B_Equal_A()
        {
            new int?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19, null }.ForEach(i => Execute(i, p => i == p.Int32));
            new short?[] { short.MinValue, short.MaxValue, 1, 0, -1, 19, null }.ForEach(i => Execute(i, p => i == p.Int32));
            new ushort?[] { ushort.MinValue, ushort.MaxValue, 1, 0, 19, null }.ForEach(i => Execute(i, p => i == p.Int32));
            new sbyte?[] { sbyte.MinValue, sbyte.MaxValue, 1, 0, -1, 19, null }.ForEach(i => Execute(i, p => i == p.Int32));
            new byte?[] { byte.MinValue, byte.MaxValue, 1, 0, 19, null }.ForEach(i => Execute(i, p => i == p.Int32));
            new float?[] { int.MinValue, 1F, 0F, -1F, 19F, 198F, null }.ForEach(i => Execute(i, p => (int?)i == p.Int32));
            new double?[] { int.MinValue, int.MaxValue, 1,/*22.2,*/ 0, 19, 198, null }.ForEach(i => Execute(i, p => i == p.Int32));
            new uint?[] { uint.MinValue, /*uint.MaxValue,*/ 1, 0, 19, null }.ForEach(i => Execute(i, p => i == p.Int32));
            new long?[] { int.MinValue, int.MaxValue, -1, 1, 0, 19, null }.ForEach(i => Execute(i, p => i == p.Int32));
            new ulong?[] { int.MaxValue, 1L, 0L, 19L, null }.ForEach(i => Execute(i, p => (int?)i == p.Int32));
            new decimal?[] { int.MinValue, int.MaxValue, -1M, 234M, 1M, 0M, 19M, null }.ForEach(i => Execute(i, p => i == p.Int32));
        }
        [TestMethod]
        public virtual void A_Equals_B()
        {
            new int?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19, null }.ForEach(i => Execute(i, p => p.Int32.Equals(i)));
            new short?[] { short.MinValue, short.MaxValue, 1, 0, -1, 19, null }.ForEach(i => Execute(i, p => p.Int32.Equals(i)));
            new ushort?[] { ushort.MinValue, ushort.MaxValue, 1, 0, 19, null }.ForEach(i => Execute(i, p => p.Int32.Equals(i)));
            new sbyte?[] { sbyte.MinValue, sbyte.MaxValue, 1, 0, -1, 19, null }.ForEach(i => Execute(i, p => p.Int32.Equals(i)));
            new byte?[] { byte.MinValue, byte.MaxValue, 1, 0, 19, null }.ForEach(i => Execute(i, p => p.Int32.Equals(i)));
            new float?[] { int.MinValue, 1F, 0F, 19F, -1f /*19.9F,*/}.ForEach(i => Execute(i, p => ((int?)i).Equals(p.Int32)));
            new double?[] { int.MinValue, int.MaxValue, 1d, 0d, 19d, /*19.9d,*/ null }.ForEach(i => Execute(i, p => i.Equals(p.Int32)));
            new uint?[] { uint.MinValue,/* uint.MaxValue,*/ 1, 0, 19, null }.ForEach(i => Execute(i, p => i.Equals(p.Int32)));
            new long?[] { int.MinValue, int.MaxValue, -1, 1, 0, 19, null }.ForEach(i => Execute(i, p => i.Equals(p.Int32)));
            new ulong?[] { int.MaxValue, 1L, 0L, 19L, null }.ForEach(i => Execute(i, p => ((Int32?)i).Equals(p.Int32)));
            new decimal?[] { int.MinValue, int.MaxValue, -1M, /*19.9M,*/ 1M, 0M, 19M, null }.ForEach(i => Execute(i, p => i.Equals(p.Int32)));
        }
        [TestMethod]
        public virtual void B_Equals_A()
        {
            new int?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19, null }.ForEach(i => Execute(i, p => i.Equals(p.Int32)));
            new short?[] { short.MinValue, short.MaxValue, 1, 0, -1, 19, null }.ForEach(i => Execute(i, p => i.Equals(p.Int32)));
            new ushort?[] { ushort.MinValue, ushort.MaxValue, 1, 0, 19, null }.ForEach(i => Execute(i, p => i.Equals(p.Int32)));
            new sbyte?[] { sbyte.MinValue, sbyte.MaxValue, 1, 0, -1, 19, null }.ForEach(i => Execute(i, p => i.Equals(p.Int32)));
            new byte?[] { byte.MinValue, byte.MaxValue, 1, 0, 19, null }.ForEach(i => Execute(i, p => i.Equals(p.Int32)));
            new float?[] { int.MinValue, 1F, 0F, 19F, -1f /*19.9F,*/}.ForEach(i => Execute(i, p => ((int?)i).Equals(p.Int32)));
            new double?[] { int.MinValue, int.MaxValue, 1d, 0d, 19d, /*19.9d,*/ null }.ForEach(i => Execute(i, p => i.Equals(p.Int32)));
            new uint?[] { uint.MinValue,/* uint.MaxValue,*/ 1, 0, 19, null }.ForEach(i => Execute(i, p => i.Equals(p.Int32)));
            new long?[] { int.MinValue, int.MaxValue, -1, 1, 0, 19, null }.ForEach(i => Execute(i, p => i.Equals(p.Int32)));
            new ulong?[] { int.MaxValue, 1L, 0L, 19L, null }.ForEach(i => Execute(i, p => ((Int32?)i).Equals(p.Int32)));
            new decimal?[] { int.MinValue, int.MaxValue, -1M, /*19.9M,*/ 1M, 0M, 19M, null }.ForEach(i => Execute(i, p => i.Equals(p.Int32)));
        }
        [TestMethod]
        public virtual void Equals_A_And_B()
        {
            new int?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19, null }.ForEach(i => Execute(i, p => object.Equals(i, p.Int32)));
            new short?[] { short.MinValue, short.MaxValue, 1, 0, -1, 19, null }.ForEach(i => Execute(i, p => object.Equals(i, p.Int32)));
            new ushort?[] { ushort.MinValue, ushort.MaxValue, 1, 0, 19, null }.ForEach(i => Execute(i, p => object.Equals(i, p.Int32)));
            new sbyte?[] { sbyte.MinValue, sbyte.MaxValue, 1, 0, -1, 19, null }.ForEach(i => Execute(i, p => object.Equals(i, p.Int32)));
            new byte?[] { byte.MinValue, byte.MaxValue, 1, 0, 19, null }.ForEach(i => Execute(i, p => object.Equals(i, p.Int32)));
            new uint?[] { uint.MinValue, 1, 0, 19, null }.ForEach(i => Execute(i, p => object.Equals(i, p.Int32)));
            new float?[] { int.MinValue,/*2147483647,*/ 1, 0, -1, 19, null }.ForEach(i => Execute(i, p => object.Equals((int?)i, p.Int32)));
            new double?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19, null }.ForEach(i => Execute(i, p => object.Equals(i, p.Int32)));
            new long?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19, null }.ForEach(i => Execute(i, p => object.Equals(i, p.Int32)));
            new ulong?[] { int.MaxValue, 1, 0, 19, null }.ForEach(i => Execute(i, p => object.Equals(i, p.Int32)));
            new decimal?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19, null }.ForEach(i => Execute(i, p => object.Equals(i, p.Int32)));
        }
        [TestMethod]
        public virtual void A_Equal_Null()
        {
            new int?[] { null }.ForEach(i => Execute(i, p => p.Int32 == i));
            new short?[] { null }.ForEach(i => Execute(i, p => p.Int32 == i));
            new ushort?[] { null }.ForEach(i => Execute(i, p => p.Int32 == i));
            new sbyte?[] { null }.ForEach(i => Execute(i, p => p.Int32 == i));
            new byte?[] { null }.ForEach(i => Execute(i, p => p.Int32 == i));
            float? a = null;
            Execute(a, p => p.Int32 == a);
            double? b = null;
            Execute(b, p => p.Int32 == b);
            long? c = null;
            Execute(c, p => p.Int32 == c);
            ulong? d = null;
            Execute(d, p => p.Int32 == (int?)d);
            decimal? e = null;
            Execute(e, p => p.Int32 == e);
        }
        [TestMethod]
        public virtual void A_Equals_Null()
        {
            new int?[] { null }.ForEach(i => Execute(i, p => p.Int32.Equals(i)));
            new short?[] { null }.ForEach(i => Execute(i, p => p.Int32.Equals(i)));
            new ushort?[] { null }.ForEach(i => Execute(i, p => p.Int32.Equals(i)));
            new sbyte?[] { null }.ForEach(i => Execute(i, p => p.Int32.Equals(i)));
            new byte?[] { null }.ForEach(i => Execute(i, p => p.Int32.Equals(i)));
            float? a = null;
            Execute(a, p => p.Int32.Equals(a));
            double? b = null;
            Execute(b, p => p.Int32.Equals(b));
            long? c = null;
            Execute(c, p => p.Int32.Equals(c));
            ulong? d = null;
            Execute(d, p => p.Int32.Equals((int?)d));
            decimal? e = null;
            Execute(e, p => p.Int32.Equals(e));
        }
        [TestMethod]
        public virtual void A_Not_Equal_B()
        {
            new int?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19, null }.ForEach(i => ExecuteNull(i, p => p.Int32 != i));
            new short?[] { short.MinValue, short.MaxValue, 1, 0, -1, 19, null }.ForEach(i => ExecuteNull(i, p => p.Int32 != i));
            new ushort?[] { ushort.MinValue, ushort.MaxValue, 1, 0, 19, null }.ForEach(i => ExecuteNull(i, p => p.Int32 != i));
            new sbyte?[] { sbyte.MinValue, sbyte.MaxValue, 1, 0, -1, 19, null }.ForEach(i => ExecuteNull(i, p => p.Int32 != i));
            new byte?[] { byte.MinValue, byte.MaxValue, 1, 0, 19, null }.ForEach(i => ExecuteNull(i, p => p.Int32 != i));
            new uint?[] { uint.MinValue, 1, 0, 19, null }.ForEach(i => ExecuteNull(i, p => p.Int32 != i));
            new float?[] { int.MinValue,/*2147483646, */1, 0, -1, 19 }.ForEach(i => ExecuteNull(i, p => p.Int32 != (int?)i));
            new double?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19, null }.ForEach(i => ExecuteNull(i, p => p.Int32 != i));
            new long?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19, null }.ForEach(i => ExecuteNull(i, p => p.Int32 != i));
            new ulong?[] { int.MaxValue, 1, 0, 19 }.ForEach(i => ExecuteNull(i, p => p.Int32 != (int?)i));
            new decimal?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19, null }.ForEach(i => ExecuteNull(i, p => p.Int32 != i));
        }
        [TestMethod]
        public virtual void B_Not_Equal_A()
        {
            new int?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19, null }.ForEach(i => ExecuteNull(i, p => i != p.Int32));
            new short?[] { short.MinValue, short.MaxValue, 1, 0, -1, 19, null }.ForEach(i => ExecuteNull(i, p => i != p.Int32));
            new ushort?[] { ushort.MinValue, ushort.MaxValue, 1, 0, 19, null }.ForEach(i => ExecuteNull(i, p => i != p.Int32));
            new sbyte?[] { sbyte.MinValue, sbyte.MaxValue, 1, 0, -1, 19, null }.ForEach(i => ExecuteNull(i, p => i != p.Int32));
            new byte?[] { byte.MinValue, byte.MaxValue, 1, 0, 19, null }.ForEach(i => ExecuteNull(i, p => i != p.Int32));
            new float?[] { int.MinValue, 1F, 0F, -1F, 19F, 198F, null }.ForEach(i => ExecuteNull(i, p => (int?)i != p.Int32));
            new double?[] { int.MinValue, int.MaxValue, 1,/*22.2,*/ 0, 19, 198, null }.ForEach(i => ExecuteNull(i, p => i != p.Int32));
            new uint?[] { uint.MinValue, /*uint.MaxValue,*/ 1, 0, 19, null }.ForEach(i => ExecuteNull(i, p => i != p.Int32));
            new long?[] { int.MinValue, int.MaxValue, -1, 1, 0, 19, null }.ForEach(i => ExecuteNull(i, p => i != p.Int32));
            new ulong?[] { int.MaxValue, 1L, 0L, 19L, null }.ForEach(i => ExecuteNull(i, p => (int?)i != p.Int32));
            new decimal?[] { int.MinValue, int.MaxValue, -1M, 234M, 1M, 0M, 19M, null }.ForEach(i => ExecuteNull(i, p => i != p.Int32));
        }
        [TestMethod]
        public virtual void A_Not_Equals_B()
        {
            new int?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19, null }.ForEach(i => ExecuteNull(i, p => !p.Int32.Equals(i)));
            new short?[] { short.MinValue, short.MaxValue, 1, 0, -1, 19, null }.ForEach(i => ExecuteNull(i, p => !p.Int32.Equals(i)));
            new ushort?[] { ushort.MinValue, ushort.MaxValue, 1, 0, 19, null }.ForEach(i => ExecuteNull(i, p => !p.Int32.Equals(i)));
            new sbyte?[] { sbyte.MinValue, sbyte.MaxValue, 1, 0, -1, 19, null }.ForEach(i => ExecuteNull(i, p => !p.Int32.Equals(i)));
            new byte?[] { byte.MinValue, byte.MaxValue, 1, 0, 19, null }.ForEach(i => ExecuteNull(i, p => !p.Int32.Equals(i)));
            new float?[] { int.MinValue, 1F, 0F, 19F, -1f /*19.9F,*/}.ForEach(i => ExecuteNull(i, p => !((int?)i).Equals(p.Int32)));
            new double?[] { int.MinValue, int.MaxValue, 1d, 0d, 19d, /*19.9d,*/ null }.ForEach(i => ExecuteNull(i, p => !i.Equals(p.Int32)));
            new uint?[] { uint.MinValue,/* uint.MaxValue,*/ 1, 0, 19, null }.ForEach(i => ExecuteNull(i, p => !i.Equals(p.Int32)));
            new long?[] { int.MinValue, int.MaxValue, -1, 1, 0, 19, null }.ForEach(i => ExecuteNull(i, p => !i.Equals(p.Int32)));
            new ulong?[] { int.MaxValue, 1L, 0L, 19L, null }.ForEach(i => ExecuteNull(i, p => !((Int32?)i).Equals(p.Int32)));
            new decimal?[] { int.MinValue, int.MaxValue, -1M, /*19.9M,*/ 1M, 0M, 19M, null }.ForEach(i => ExecuteNull(i, p => !i.Equals(p.Int32)));
        }
        [TestMethod]
        public virtual void B_Not_Equals_A()
        {
            new int?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19, null }.ForEach(i => ExecuteNull(i, p => !i.Equals(p.Int32)));
            new short?[] { short.MinValue, short.MaxValue, 1, 0, -1, 19, null }.ForEach(i => ExecuteNull(i, p => !i.Equals(p.Int32)));
            new ushort?[] { ushort.MinValue, ushort.MaxValue, 1, 0, 19, null }.ForEach(i => ExecuteNull(i, p => !i.Equals(p.Int32)));
            new sbyte?[] { sbyte.MinValue, sbyte.MaxValue, 1, 0, -1, 19, null }.ForEach(i => ExecuteNull(i, p => !i.Equals(p.Int32)));
            new byte?[] { byte.MinValue, byte.MaxValue, 1, 0, 19, null }.ForEach(i => ExecuteNull(i, p => !i.Equals(p.Int32)));
            new float?[] { int.MinValue, 1F, 0F, 19F, -1f /*19.9F,*/}.ForEach(i => ExecuteNull(i, p => !((int?)i).Equals(p.Int32)));
            new double?[] { int.MinValue, int.MaxValue, 1d, 0d, 19d, /*19.9d,*/ null }.ForEach(i => ExecuteNull(i, p => !i.Equals(p.Int32)));
            new uint?[] { uint.MinValue,/* uint.MaxValue,*/ 1, 0, 19, null }.ForEach(i => ExecuteNull(i, p => !i.Equals(p.Int32)));
            new long?[] { int.MinValue, int.MaxValue, -1, 1, 0, 19, null }.ForEach(i => ExecuteNull(i, p => !i.Equals(p.Int32)));
            new ulong?[] { int.MaxValue, 1L, 0L, 19L, null }.ForEach(i => ExecuteNull(i, p => !((Int32?)i).Equals(p.Int32)));
            new decimal?[] { int.MinValue, int.MaxValue, -1M, /*19.9M,*/ 1M, 0M, 19M, null }.ForEach(i => ExecuteNull(i, p => !i.Equals(p.Int32)));
        }
        [TestMethod]
        public virtual void A_Not_Equal_Null()
        {
            new int?[] { null }.ForEach(i => ExecuteNull(i, p => p.Int32 != i));
            new short?[] { null }.ForEach(i => ExecuteNull(i, p => p.Int32 != i));
            new ushort?[] { null }.ForEach(i => ExecuteNull(i, p => p.Int32 != i));
            new sbyte?[] { null }.ForEach(i => ExecuteNull(i, p => p.Int32 != i));
            new byte?[] { null }.ForEach(i => ExecuteNull(i, p => p.Int32 != i));
            float? a = null;
            ExecuteNull(a, p => p.Int32 != a);
            double? b = null;
            ExecuteNull(b, p => p.Int32 != b);
            long? c = null;
            ExecuteNull(c, p => p.Int32 != c);
            ulong? d = null;
            ExecuteNull(d, p => p.Int32 != (int?)d);
            decimal? e = null;
            ExecuteNull(e, p => p.Int32 != e);
        }
        [TestMethod]
        public virtual void A_Not_Equals_Null()
        {
            new int?[] { null }.ForEach(i => ExecuteNull(i, p => !p.Int32.Equals(i)));
            new short?[] { null }.ForEach(i => ExecuteNull(i, p => !p.Int32.Equals(i)));
            new ushort?[] { null }.ForEach(i => ExecuteNull(i, p => !p.Int32.Equals(i)));
            new sbyte?[] { null }.ForEach(i => ExecuteNull(i, p => !p.Int32.Equals(i)));
            new byte?[] { null }.ForEach(i => ExecuteNull(i, p => !p.Int32.Equals(i)));
            float? a = null;
            ExecuteNull(a, p => !p.Int32.Equals(a));
            double? b = null;
            ExecuteNull(b, p => !p.Int32.Equals(b));
            long? c = null;
            ExecuteNull(c, p => !p.Int32.Equals(c));
            ulong? d = null;
            ExecuteNull(d, p => !p.Int32.Equals((int?)d));
            decimal? e = null;
            ExecuteNull(e, p => !p.Int32.Equals(e));
        }
        [TestMethod]
        public virtual void A_GreaterThanOrEqual_B()
        {
            new int?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19 }.ForEach(i => Execute(i, p => p.Int32 >= i));
            new short?[] { short.MinValue, short.MaxValue, 1, 0, -1, 19 }.ForEach(i => Execute(i, p => p.Int32 >= i - 1));
            new ushort?[] { ushort.MinValue, ushort.MaxValue, 1, 0, 19 }.ForEach(i => Execute(i, p => p.Int32 >= i - 1));
            new sbyte?[] { sbyte.MinValue, sbyte.MaxValue, 1, 0, -1, 19 }.ForEach(i => Execute(i, p => p.Int32 >= i - 1));
            new byte?[] { byte.MinValue, byte.MaxValue, 1, 0, 19 }.ForEach(i => Execute(i, p => p.Int32 >= i - 1));
            new uint?[] { uint.MinValue, 0, 1, 19 }.ForEach(i => Execute(i, p => p.Int32 >= i));
            new float?[] { int.MinValue,/*2147483646, */1, 0, -1, 19 }.ForEach(i => Execute(i, p => p.Int32 >= (int?)i));
            new double?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19 }.ForEach(i => Execute(i, p => p.Int32 >= i));
            new long?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19 }.ForEach(i => Execute(i, p => p.Int32 >= i));
            new ulong?[] { int.MaxValue, 1, 0, 19 }.ForEach(i => Execute(i, p => p.Int32 >= (int?)i - 1));
            new decimal?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19 }.ForEach(i => Execute(i, p => p.Int32 >= i));
            new int?[] { null, 19 }.ForEach(i => ExecuteNull(i, p => p.Int32 >= null));
            new int?[] { null }.ForEach(i => ExecuteNull(i, p => p.Int32 >= -1));
        }
        [TestMethod]
        public virtual void B_GreaterThanOrEqual_A()
        {
            new int?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19 }.ForEach(i => Execute(i, p => i >= p.Int32));
            new short?[] { short.MinValue, short.MaxValue, 1, 0, -1, 19 }.ForEach(i => Execute(i, p => i >= p.Int32));
            new ushort?[] { ushort.MinValue, ushort.MaxValue, 1, 0, 19 }.ForEach(i => Execute(i, p => i >= p.Int32));
            new sbyte?[] { sbyte.MinValue, sbyte.MaxValue, 1, 0, -1, 19 }.ForEach(i => Execute(i, p => i >= p.Int32));
            new byte?[] { byte.MinValue, byte.MaxValue, 1, 0, 19 }.ForEach(i => Execute(i, p => i >= p.Int32));
            new uint?[] { uint.MinValue, 0, 1, 19 }.ForEach(i => Execute(i, p => p.Int32 >= i));
            new float?[] { int.MinValue,/*2147483646, */1, 0, -1, 19 }.ForEach(i => Execute(i, p => (int?)i >= p.Int32));
            new double?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19 }.ForEach(i => Execute(i, p => i >= p.Int32));
            new long?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19 }.ForEach(i => Execute(i, p => i >= p.Int32));
            new ulong?[] { int.MaxValue, 1, 0, 19 }.ForEach(i => Execute(i, p => (int?)i >= p.Int32 - 1));
            new decimal?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19 }.ForEach(i => Execute(i, p => i >= p.Int32));
            new int?[] { null, 19 }.ForEach(i => ExecuteNull(i, p => null >= p.Int32));
            new int?[] { null }.ForEach(i => ExecuteNull(i, p => -1 >= p.Int32));
        }
        [TestMethod]
        public virtual void A_GreaterThan_B()
        {
            new int?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19 }.ForEach(i => ExecuteNull(i, p => p.Int32 > i));
            new short?[] { short.MinValue, short.MaxValue, 1, 0, -1, 19 }.ForEach(i => ExecuteNull(i, p => p.Int32 > i));
            new ushort?[] { ushort.MinValue, ushort.MaxValue, 1, 0, 19 }.ForEach(i => ExecuteNull(i, p => p.Int32 > i));
            new sbyte?[] { sbyte.MinValue, sbyte.MaxValue, 1, 0, -1, 19 }.ForEach(i => ExecuteNull(i, p => p.Int32 > i));
            new byte?[] { byte.MinValue, byte.MaxValue, 1, 0, 19 }.ForEach(i => ExecuteNull(i, p => p.Int32 > i));
            new uint?[] { uint.MinValue, 0, 1, 19 }.ForEach(i => ExecuteNull(i, p => p.Int32 > i));
            new float?[] { int.MinValue,/*2147483646, */1, 0, -1, 19 }.ForEach(i => ExecuteNull(i, p => p.Int32 > (int?)i));
            new double?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19 }.ForEach(i => ExecuteNull(i, p => p.Int32 > i));
            new long?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19 }.ForEach(i => ExecuteNull(i, p => p.Int32 > i));
            new ulong?[] { int.MaxValue, 1, 0, 19 }.ForEach(i => Execute(i, p => p.Int32 > (int?)i - 1));
            new decimal?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19 }.ForEach(i => ExecuteNull(i, p => p.Int32 > i));
            ExecuteNull(null, p => p.Int32 > null);
            ExecuteNull(null, p => p.Int32 > Int32.MinValue);
            ExecuteNull(int.MaxValue, p => p.Int32 > null);
        }
        [TestMethod]
        public virtual void B_GreaterThan_A()
        {
            new int?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19 }.ForEach(i => ExecuteNull(i, p => i > p.Int32));
            new short?[] { short.MinValue, short.MaxValue, 1, 0, -1, 19 }.ForEach(i => ExecuteNull(i, p => i > p.Int32));
            new ushort?[] { ushort.MinValue, ushort.MaxValue, 1, 0, 19 }.ForEach(i => ExecuteNull(i, p => i > p.Int32));
            new sbyte?[] { sbyte.MinValue, sbyte.MaxValue, 1, 0, -1, 19 }.ForEach(i => ExecuteNull(i, p => i > p.Int32));
            new byte?[] { byte.MinValue, byte.MaxValue, 1, 0, 19 }.ForEach(i => ExecuteNull(i, p => i > p.Int32));
            new uint?[] { uint.MinValue, 0, 1, 19 }.ForEach(i => ExecuteNull(i, p => p.Int32 > i));
            new float?[] { int.MinValue,/*2147483646, */1, 0, -1, 19 }.ForEach(i => ExecuteNull(i, p => (int?)i > p.Int32));
            new double?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19 }.ForEach(i => ExecuteNull(i, p => i > p.Int32));
            new long?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19 }.ForEach(i => ExecuteNull(i, p => i > p.Int32));
            new ulong?[] { int.MaxValue, 1, 0, 19 }.ForEach(i => Execute(i, p => (int?)i > p.Int32 - 1));
            new decimal?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19 }.ForEach(i => ExecuteNull(i, p => i > p.Int32));
            ExecuteNull(null, p => null > p.Int32);
            ExecuteNull(null, p => Int32.MaxValue > p.Int32);
            ExecuteNull(int.MinValue, p => null > p.Int32);
        }
        [TestMethod]
        public virtual void A_LessThanOrEqual_B()
        {
            new int?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19 }.ForEach(i => Execute(i, p => p.Int32 <= i));
            new short?[] { short.MinValue, short.MaxValue, 1, 0, -1, 19 }.ForEach(i => Execute(i, p => p.Int32 <= i + 1));
            new ushort?[] { ushort.MinValue, ushort.MaxValue, 1, 0, 19 }.ForEach(i => Execute(i, p => p.Int32 <= i + 1));
            new sbyte?[] { sbyte.MinValue, sbyte.MaxValue, 1, 0, -1, 19 }.ForEach(i => Execute(i, p => p.Int32 <= i + 1));
            new byte?[] { byte.MinValue, byte.MaxValue, 1, 0, 19 }.ForEach(i => Execute(i, p => p.Int32 <= i + 1));
            new uint?[] { uint.MinValue, 0, 1, 19 }.ForEach(i => Execute(i, p => p.Int32 <= i));
            new float?[] { int.MinValue,/*2147483646, */1, 0, -1, 19 }.ForEach(i => Execute(i, p => p.Int32 <= (int?)i));
            new double?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19 }.ForEach(i => Execute(i, p => p.Int32 <= i));
            new long?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19 }.ForEach(i => Execute(i, p => p.Int32 <= i));
            new ulong?[] { int.MaxValue, 1, 0, 19 }.ForEach(i => Execute(i, p => p.Int32 <= (int?)i));
            new decimal?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19 }.ForEach(i => Execute(i, p => p.Int32 <= i));
            new int?[] { null, 19 }.ForEach(i => ExecuteNull(i, p => p.Int32 <= null));
            new int?[] { null }.ForEach(i => ExecuteNull(i, p => p.Int32 <= int.MaxValue));
        }
        [TestMethod]
        public virtual void B_LessThanOrEqual_A()
        {
            new int?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19 }.ForEach(i => Execute(i, p => i <= p.Int32));
            new short?[] { short.MinValue, short.MaxValue, 1, 0, -1, 19 }.ForEach(i => Execute(i, p => i <= p.Int32 + 1));
            new ushort?[] { ushort.MinValue, ushort.MaxValue, 1, 0, 19 }.ForEach(i => Execute(i, p => i <= p.Int32 + 1));
            new sbyte?[] { sbyte.MinValue, sbyte.MaxValue, 1, 0, -1, 19 }.ForEach(i => Execute(i, p => i <= p.Int32 + 1));
            new byte?[] { byte.MinValue, byte.MaxValue, 1, 0, 19 }.ForEach(i => Execute(i, p => i <= p.Int32 + 1));
            new uint?[] { uint.MinValue, 0, 1, 19 }.ForEach(i => Execute(i, p => p.Int32 <= i));
            new float?[] { int.MinValue,/*2147483646, */1, 0, -1, 19 }.ForEach(i => Execute(i, p => (int?)i <= p.Int32));
            new double?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19 }.ForEach(i => Execute(i, p => i <= p.Int32));
            new long?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19 }.ForEach(i => Execute(i, p => i <= p.Int32));
            new ulong?[] { int.MaxValue, 1, 0, 19 }.ForEach(i => Execute(i, p => (int?)i <= p.Int32));
            new decimal?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19 }.ForEach(i => Execute(i, p => i <= p.Int32));
            new int?[] { null, 19 }.ForEach(i => ExecuteNull(i, p => null <= p.Int32));
            new int?[] { null }.ForEach(i => ExecuteNull(i, p => int.MaxValue <= null));
        }
        [TestMethod]
        public virtual void A_LessThan_B()
        {
            new int?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19 }.ForEach(i => ExecuteNull(i, p => p.Int32 < i));
            new short?[] { short.MinValue, short.MaxValue, 1, 0, -1, 19 }.ForEach(i => ExecuteNull(i, p => p.Int32 < i));
            new ushort?[] { ushort.MinValue, ushort.MaxValue, 1, 0, 19 }.ForEach(i => ExecuteNull(i, p => p.Int32 < i));
            new sbyte?[] { sbyte.MinValue, sbyte.MaxValue, 1, 0, -1, 19 }.ForEach(i => ExecuteNull(i, p => p.Int32 < i));
            new byte?[] { byte.MinValue, byte.MaxValue, 1, 0, 19 }.ForEach(i => ExecuteNull(i, p => p.Int32 < i));
            new uint?[] { uint.MinValue, 0, 1, 19 }.ForEach(i => Execute(i, p => p.Int32 < i + 1));
            new float?[] { int.MinValue,/*2147483646, */1, 0, -1, 19 }.ForEach(i => Execute(i, p => p.Int32 < (int?)i + 1));
            new double?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19 }.ForEach(i => ExecuteNull(i, p => p.Int32 < i));
            new long?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19 }.ForEach(i => ExecuteNull(i, p => p.Int32 < i));
            new ulong?[] { int.MaxValue, 1, 0, 19 }.ForEach(i => ExecuteNull(i, p => p.Int32 < (int?)i));
            new decimal?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19 }.ForEach(i => ExecuteNull(i, p => p.Int32 < i));
            ExecuteNull(null, p => p.Int32 < null);
            ExecuteNull(null, p => p.Int32 < Int32.MaxValue);
            ExecuteNull(int.MinValue, p => p.Int32 < null);
        }
        [TestMethod]
        public virtual void B_LessThan_A()
        {
            new int?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19 }.ForEach(i => ExecuteNull(i, p => i < p.Int32));
            new short?[] { short.MinValue, short.MaxValue, 1, 0, -1, 19 }.ForEach(i => ExecuteNull(i, p => i < p.Int32));
            new ushort?[] { ushort.MinValue, ushort.MaxValue, 1, 0, 19 }.ForEach(i => ExecuteNull(i, p => i < p.Int32));
            new sbyte?[] { sbyte.MinValue, sbyte.MaxValue, 1, 0, -1, 19 }.ForEach(i => ExecuteNull(i, p => i < p.Int32));
            new byte?[] { byte.MinValue, byte.MaxValue, 1, 0, 19 }.ForEach(i => ExecuteNull(i, p => i < p.Int32));
            new uint?[] { uint.MinValue, 0, 1, 19 }.ForEach(i => ExecuteNull(i, p => p.Int32 < i));
            new float?[] { int.MinValue,/*2147483646, */1, 0, -1, 19 }.ForEach(i => ExecuteNull(i, p => (int?)i < p.Int32));
            new double?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19 }.ForEach(i => ExecuteNull(i, p => i < p.Int32));
            new long?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19 }.ForEach(i => ExecuteNull(i, p => i < p.Int32));
            new ulong?[] { int.MaxValue, 1, 0, 19 }.ForEach(i => ExecuteNull(i, p => (int?)i < p.Int32));
            new decimal?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19 }.ForEach(i => ExecuteNull(i, p => i < p.Int32));
            ExecuteNull(null, p => null < p.Int32);
            ExecuteNull(null, p => Int32.MinValue < p.Int32);
            ExecuteNull(int.MaxValue, p => null < p.Int32);
        }
        [TestMethod]
        public virtual void A_Plus_B()
        {
            new int?[] { 1, 0, -1, 19 }.ForEach(i => Execute(i, p => p.Int32 + i > int.MinValue));
            new short?[] { short.MaxValue, short.MinValue, 1, 0, -1, 19 }.ForEach(i => Execute(i, p => p.Int32 + i > int.MinValue));
            new ushort?[] { ushort.MaxValue, ushort.MinValue, 1, 0, 19 }.ForEach(i => Execute(i, p => p.Int32 + i > int.MinValue));
            new sbyte?[] { sbyte.MaxValue, sbyte.MinValue, 1, 0, -1, 19 }.ForEach(i => Execute(i, p => p.Int32 + i > int.MinValue));
            new byte?[] { byte.MaxValue, byte.MinValue, 1, 0, 19 }.ForEach(i => Execute(i, p => p.Int32 + i > int.MinValue));
            new uint?[] { uint.MinValue, 0, 1, 19 }.ForEach(i => Execute(i, p => p.Int32 + i > int.MinValue));
            new float?[] { int.MinValue, 1, 0, -1, 19 }.ForEach(i => Execute(i, p => p.Int32 + 19 > int.MinValue));
            new double?[] { int.MinValue, 1, 0, -1, 19 }.ForEach(i => Execute(i, p => p.Int32 + 19 > int.MinValue));
            new long?[] { int.MinValue, 1, 0, -1, 19 }.ForEach(i => Execute(i, p => p.Int32 + 19 > int.MinValue));
            new ulong?[] { ulong.MinValue, 1, 0, 19 }.ForEach(i => Execute(i, p => p.Int32 + 19 > int.MinValue));
            new decimal?[] { int.MinValue, 1, 0, -1, 19 }.ForEach(i => Execute(i, p => p.Int32 + 19 > int.MinValue));
            Execute(int.MaxValue, p => p.Int32 + int.MinValue == -1);
            Execute(null, p => p.Int32 + null == null);
            int? a = null;
            Execute(a, p => p.Int32 + 18 == null);
        }
        [TestMethod]
        public virtual void B_Plus_A()
        {
            new int?[] { 1, 0, -1, 19 }.ForEach(i => Execute(i, p => i + p.Int32 > int.MinValue));
            new short?[] { short.MaxValue, short.MinValue, 1, 0, -1, 19 }.ForEach(i => Execute(i, p => i + p.Int32 > int.MinValue));
            new ushort?[] { ushort.MaxValue, ushort.MinValue, 1, 0, 19 }.ForEach(i => Execute(i, p => i + p.Int32 > int.MinValue));
            new sbyte?[] { sbyte.MaxValue, sbyte.MinValue, 1, 0, -1, 19 }.ForEach(i => Execute(i, p => i + p.Int32 > int.MinValue));
            new byte?[] { byte.MaxValue, byte.MinValue, 1, 0, 19 }.ForEach(i => Execute(i, p => i + p.Int32 > int.MinValue));
            new uint?[] { uint.MinValue, 0, 1, 19 }.ForEach(i => Execute(i, p => i + p.Int32 > int.MinValue));
            new float?[] { int.MinValue, 1, 0, -1, 19 }.ForEach(i => Execute(i, p => 19 + p.Int32 > int.MinValue));
            new double?[] { int.MinValue, 1, 0, -1, 19 }.ForEach(i => Execute(i, p => 19 + p.Int32 > int.MinValue));
            new long?[] { int.MinValue, 1, 0, -1, 19 }.ForEach(i => Execute(i, p => 19 + p.Int32 > int.MinValue));
            new ulong?[] { ulong.MinValue, 1, 0, 19 }.ForEach(i => Execute(i, p => 19 + p.Int32 > int.MinValue));
            new decimal?[] { int.MinValue, 1, 0, -1, 19 }.ForEach(i => Execute(i, p => 19 + p.Int32 > int.MinValue));
            Execute(int.MaxValue, p => p.Int32 + int.MinValue == -1);
            Execute(null, p => null + p.Int32 == null);
            int? a = null;
            Execute(a, p => p.Int32 + 18 == null);
        }
        [TestMethod]
        public virtual void A_Subtract_B()
        {
            new int?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19 }.ForEach(i => Execute(i, p => p.Int32 - i == 0));
            new short?[] { short.MaxValue, short.MinValue, 1, 0, -1, 19 }.ForEach(i => Execute(i, p => p.Int32 - i == 0));
            new ushort?[] { ushort.MaxValue, ushort.MinValue, 1, 0, 19 }.ForEach(i => Execute(i, p => p.Int32 - i == 0));
            new sbyte?[] { sbyte.MaxValue, sbyte.MinValue, 1, 0, -1, 19 }.ForEach(i => Execute(i, p => p.Int32 - i == 0));
            new byte?[] { byte.MaxValue, byte.MinValue, 1, 0, 19 }.ForEach(i => Execute(i, p => p.Int32 - i == 0));
            new uint?[] { uint.MinValue, 0, 1, 19 }.ForEach(i => Execute(i, p => p.Int32 - i == 0));
            new float?[] { int.MinValue,/* int.MaxValue,*/1, 0, -1, 19 }.ForEach(i => Execute(i, p => p.Int32 - (int?)i == 0));
            new double?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19 }.ForEach(i => Execute(i, p => p.Int32 - i == 0));
            new long?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19 }.ForEach(i => Execute(i, p => p.Int32 - i == 0));
            new ulong?[] { ulong.MinValue, int.MaxValue, 1, 0, 19 }.ForEach(i => Execute(i, p => p.Int32 - (int?)i == 0));
            new decimal?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19 }.ForEach(i => Execute(i, p => p.Int32 - i == 0));
            Execute(null, p => p.Int32 - null == null);
            int? a = null;
            Execute(a, p => p.Int32 - 18 == null);
            Execute(18, p => p.Int32 - null == null);
        }
        [TestMethod]
        public virtual void B_Subtract_A()
        {
            new int?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19 }.ForEach(i => Execute(i, p => i - p.Int32 == 0));
            new short?[] { short.MaxValue, short.MinValue, 1, 0, -1, 19 }.ForEach(i => Execute(i, p => i - p.Int32 == 0));
            new ushort?[] { ushort.MaxValue, ushort.MinValue, 1, 0, 19 }.ForEach(i => Execute(i, p => i - p.Int32 == 0));
            new sbyte?[] { sbyte.MaxValue, sbyte.MinValue, 1, 0, -1, 19 }.ForEach(i => Execute(i, p => i - p.Int32 == 0));
            new byte?[] { byte.MaxValue, byte.MinValue, 1, 0, 19 }.ForEach(i => Execute(i, p => i - p.Int32 == 0));
            new uint?[] { uint.MinValue, 0, 1, 19 }.ForEach(i => Execute(i, p => i - p.Int32 == 0));
            new float?[] { int.MinValue,/* int.MaxValue,*/1, 0, -1, 19 }.ForEach(i => Execute(i, p => (int?)i - p.Int32 == 0));
            new double?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19 }.ForEach(i => Execute(i, p => i - p.Int32 == 0));
            new long?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19 }.ForEach(i => Execute(i, p => i - p.Int32 == 0));
            new ulong?[] { ulong.MinValue, int.MaxValue, 1, 0, 19 }.ForEach(i => Execute(i, p => (int?)i - p.Int32 == 0));
            new decimal?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19 }.ForEach(i => Execute(i, p => i - p.Int32 == 0));
            Execute(null, p => null - p.Int32 == null);
            int? a = null;
            Execute(a, p => 18 - p.Int32 == null);
            Execute(18, p => null - p.Int32 == null);
        }
        [TestMethod]
        public virtual void A_Multiply_B()
        {
            new int?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19 }.ForEach(i => Execute(i, p => p.Int32 * 1 == i));
            new short?[] { short.MaxValue, short.MinValue, 1, 0, -1, 19 }.ForEach(i => Execute(i, p => p.Int32 * 1 == i));
            new ushort?[] { ushort.MaxValue, ushort.MinValue, 1, 0, 19 }.ForEach(i => Execute(i, p => p.Int32 * 1 == i));
            new sbyte?[] { sbyte.MaxValue, sbyte.MinValue, 1, 0, -1, 19 }.ForEach(i => Execute(i, p => p.Int32 * 1 == i));
            new byte?[] { byte.MaxValue, byte.MinValue, 1, 0, 19 }.ForEach(i => Execute(i, p => p.Int32 * 1 == i));
            new uint?[] { uint.MinValue, 0, 1, 19 }.ForEach(i => Execute(i, p => p.Int32 * 1 == i));
            new float?[] { int.MinValue,/*int.MaxValue,*/1, 0, -1, 19 }.ForEach(i => Execute(i, p => p.Int32 * 1 == (int?)i));
            new double?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19 }.ForEach(i => Execute(i, p => p.Int32 * 1 == i));
            new long?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19 }.ForEach(i => Execute(i, p => p.Int32 * 1 == i));
            new ulong?[] { ulong.MinValue, int.MaxValue, 1, 0, 19 }.ForEach(i => Execute(i, p => p.Int32 * 1 == (int?)i));
            new decimal?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19 }.ForEach(i => Execute(i, p => p.Int32 * 1 == i));
            Execute(null, p => p.Int32 * null == null);
            int? a = null;
            Execute(a, p => p.Int32 * 18 == null);
            Execute(18, p => p.Int32 * null == null);
        }
        [TestMethod]
        public virtual void B_Multiply_A()
        {
            new int?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19 }.ForEach(i => Execute(i, p => 1 * p.Int32 == i));
            new short?[] { short.MaxValue, short.MinValue, 1, 0, -1, 19 }.ForEach(i => Execute(i, p => 1 * p.Int32 == i));
            new ushort?[] { ushort.MaxValue, ushort.MinValue, 1, 0, 19 }.ForEach(i => Execute(i, p => 1 * p.Int32 == i));
            new sbyte?[] { sbyte.MaxValue, sbyte.MinValue, 1, 0, -1, 19 }.ForEach(i => Execute(i, p => 1 * p.Int32 == i));
            new byte?[] { byte.MaxValue, byte.MinValue, 1, 0, 19 }.ForEach(i => Execute(i, p => 1 * p.Int32 == i));
            new uint?[] { uint.MinValue, 0, 1, 19 }.ForEach(i => Execute(i, p => 1 * p.Int32 == i));
            new float?[] { int.MinValue, /*int.MaxValue,*/1, 0, -1, 19 }.ForEach(i => Execute(i, p => 1 * p.Int32 == (int?)i));
            new double?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19 }.ForEach(i => Execute(i, p => 1 * p.Int32 == i));
            new long?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19 }.ForEach(i => Execute(i, p => 1 * p.Int32 == i));
            new ulong?[] { ulong.MinValue, int.MaxValue, 1, 0, 19 }.ForEach(i => Execute(i, p => 1 * p.Int32 == (int?)i));
            new decimal?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19 }.ForEach(i => Execute(i, p => 1 * p.Int32 == i));
            Execute(null, p => null * p.Int32 == null);
            int? a = null;
            Execute(a, p => 18 * p.Int32 == null);
            Execute(18, p => null * p.Int32 == null);
        }
        [TestMethod]
        [ExpectedException(typeof(QueryException))]
        public virtual void A_Divide_B()
        {
            new int?[] { int.MaxValue, int.MinValue, 1, -1, 19 }.ForEach(i => Execute(i, p => p.Int32 / i == 1));
            new short?[] { short.MaxValue, short.MinValue, 1, -1, 19 }.ForEach(i => Execute(i, p => p.Int32 / i == 1));
            new ushort?[] { ushort.MaxValue, 1, 19 }.ForEach(i => Execute(i, p => p.Int32 / i == 1));
            new sbyte?[] { sbyte.MaxValue, sbyte.MinValue, 1, -1, 19 }.ForEach(i => Execute(i, p => p.Int32 / i == 1));
            new byte?[] { byte.MaxValue, 1, 19 }.ForEach(i => Execute(i, p => p.Int32 / i == 1));
            new uint?[] { /*uint.MinValue,*/ 1, 19 }.ForEach(i => Execute(i, p => p.Int32 / i == 1));
            new float?[] { int.MinValue,/*int.MaxValue,*/1, -1, 19 }.ForEach(i => Execute(i, p => p.Int32 / (int?)i == 1));
            new double?[] { int.MinValue, int.MaxValue, 1, -1, 19 }.ForEach(i => Execute(i, p => p.Int32 / i == 1));
            new long?[] { int.MinValue, int.MaxValue, 1, -1, 19 }.ForEach(i => Execute(i, p => p.Int32 / i == 1));
            new ulong?[] { /*ulong.MinValue,*/ int.MaxValue, 1, 19 }.ForEach(i => Execute(i, p => p.Int32 / (int?)i == 1));
            new decimal?[] { int.MinValue, int.MaxValue, 1, -1, 19 }.ForEach(i => Execute(i, p => p.Int32 / i == 1));
            Execute(null, p => p.Int32 / null == null);
            int? a = null;
            Execute(a, p => p.Int32 / 18 == null);
            Execute(0, p => p.Int32 / null == null);
            //int.MinValue在sqlserverCe数据库中0/int.MinValue=0.00000000000
            new int?[] { int.MaxValue /*, int.MinValue*/, 1, -1, 19 }.ForEach(i => Execute(0, p => p.Int32 / i == 0));
#if !MySQL && !SQLite&& !MySQL_SDK3_5
            int? b = 0;
            Execute(0, p => p.Int32 / b == 0);//遇到以零作除数错误,引发异常
#endif
        }
        [TestMethod]
        [ExpectedException(typeof(QueryException))]
        public virtual void B_Divide_A()
        {
            new int?[] { int.MinValue, int.MaxValue, 1, -1, 19 }.ForEach(i => Execute(i, p => i / p.Int32 == 1));
            new short?[] { short.MaxValue, short.MinValue, 1, -1, 19 }.ForEach(i => Execute(i, p => i / p.Int32 == 1));
            new ushort?[] { ushort.MaxValue, 1, 19 }.ForEach(i => Execute(i, p => i / p.Int32 == 1));
            new sbyte?[] { sbyte.MaxValue, sbyte.MinValue, 1, -1, 19 }.ForEach(i => Execute(i, p => i / p.Int32 == 1));
            new byte?[] { byte.MaxValue, 1, 19 }.ForEach(i => Execute(i, p => i / p.Int32 == 1));
            new uint?[] { /*uint.MinValue,*/ 1, 19 }.ForEach(i => Execute(i, p => i / p.Int32 == 1));
            new float?[] { int.MinValue,/*int.MaxValue,*/1, -1, 19 }.ForEach(i => Execute(i, p => (int?)i / p.Int32 == 1));
            new double?[] { int.MinValue, int.MaxValue, 1, -1, 19 }.ForEach(i => Execute(i, p => i / p.Int32 == 1));
            new long?[] { int.MinValue, int.MaxValue, 1, -1, 19 }.ForEach(i => Execute(i, p => i / p.Int32 == 1));
            new ulong?[] { /*ulong.MinValue,*/ int.MaxValue, 1, 19 }.ForEach(i => Execute(i, p => (int?)i / p.Int32 == 1));
            new decimal?[] { int.MinValue, int.MaxValue, 1, -1, 19 }.ForEach(i => Execute(i, p => i / p.Int32 == 1));
            Execute(null, p => null / p.Int32 == null);
            int? a = null;
            Execute(a, p => 45 / p.Int32 == null);
            Execute(2, p => null / p.Int32 == null);
            Execute(0, p => null / p.Int32 == null);
            new int?[] { int.MaxValue, int.MinValue, 1, -1, 19 }.ForEach(i => Execute(i, p => 0 / p.Int32 == 0));//遇到以零作除数错误,引发异常

#if !MySQL && !SQLite&& !MySQL_SDK3_5
            int? b = 0;
            Execute(0, p => p.Int32 / b == 0);//遇到以零作除数错误,引发异常
#endif
        }
        [TestMethod]
        [ExpectedException(typeof(QueryException))]
        public virtual void A_Modulo_B()
        {
            new int?[] { int.MinValue, int.MaxValue, 1, -1, 19 }.ForEach(i => Execute(i, p => p.Int32 % i == 0));
            new short?[] { short.MaxValue, short.MinValue, 1, -1, 19 }.ForEach(i => Execute(i, p => p.Int32 % i == 0));
            new ushort?[] { ushort.MaxValue, 1, 19 }.ForEach(i => Execute(i, p => p.Int32 % i == 0));
            new sbyte?[] { sbyte.MaxValue, sbyte.MinValue, 1, -1, 19 }.ForEach(i => Execute(i, p => p.Int32 % i == 0));
            new byte?[] { byte.MaxValue, 1, 19 }.ForEach(i => Execute(i, p => p.Int32 % i == 0));
            new uint?[] { /*uint.MinValue,*/ 1, 19 }.ForEach(i => Execute(i, p => p.Int32 % i == 0));
            new float?[] { int.MinValue,/*int.MaxValue,*/1, -1, 19 }.ForEach(i => Execute((int?)i, p => p.Int32 % (int?)i == 0));
            new double?[] { int.MinValue, int.MaxValue, 1, -1, 19 }.ForEach(i => Execute(i, p => p.Int32 % i == 0));
            new long?[] { int.MinValue, int.MaxValue, 1, -1, 19 }.ForEach(i => Execute(i, p => p.Int32 % i == 0));
            new ulong?[] { /*ulong.MinValue,*/ int.MaxValue, 1, 19 }.ForEach(i => Execute(i, p => p.Int32 % (int?)i == 0));
            new decimal?[] { int.MinValue, int.MaxValue, 1, -1, 19 }.ForEach(i => Execute(i, p => p.Int32 % (int?)i == 0));
            Execute(null, p => p.Int32 % null == null);
            int? a = null;
            Execute(a, p => p.Int32 % 18 == null);
            Execute(0, p => p.Int32 % null == null);
            new int?[] { int.MaxValue, int.MinValue, 1, -1, 19 }.ForEach(i => Execute(0, p => p.Int32 % i == 0));//遇到以零作除数错误,引发异常
#if !MySQL && !SQLite&& !MySQL_SDK3_5
            int? b = 0;
            Execute(0, p => p.Int32 / b == 0);//遇到以零作除数错误,引发异常
#endif
        }
        [TestMethod]
        [ExpectedException(typeof(QueryException))]
        public virtual void B_Modulo_A()
        {
#if !SqlCE
            new int?[] { int.MinValue, int.MaxValue, -1, 1, 19 }.ForEach(i => Execute(i, p => i % p.Int32 == 0));
            new short?[] { short.MaxValue, short.MinValue, 1, -1, 19 }.ForEach(i => Execute(i, p => i % p.Int32 == 0));
            new sbyte?[] { sbyte.MaxValue, sbyte.MinValue, 1, -1, 19 }.ForEach(i => Execute(i, p => i % p.Int32 == 0));
            new float?[] { int.MinValue,/*int.MaxValue,*/1, -1, 19 }.ForEach(i => Execute(i, p => (int?)i % p.Int32 == 0));
            new double?[] { int.MinValue, int.MaxValue, 1, -1, 19 }.ForEach(i => Execute(i, p => i % p.Int32 == 0));
            new long?[] { int.MinValue, int.MaxValue, 1, -1, 19 }.ForEach(i => Execute(i, p => i % p.Int32 == 0));
            new decimal?[] { int.MinValue, int.MaxValue, 1, -1, 19 }.ForEach(i => Execute(i, p => i % p.Int32 == 0));
#endif
            new ushort?[] { ushort.MaxValue, 1, 19 }.ForEach(i => Execute(i, p => i % p.Int32 == 0));
            new byte?[] { byte.MaxValue, 1, 19 }.ForEach(i => Execute(i, p => i % p.Int32 == 0));
            new uint?[] { /*uint.MinValue,*/ 1, 19 }.ForEach(i => Execute(i, p => i % p.Int32 == 0));
            new ulong?[] { /*ulong.MinValue,*/ int.MaxValue, 1, 19 }.ForEach(i => Execute(i, p => (int?)i % p.Int32 == 0));
            Execute(null, p => null % p.Int32 == null);
            int? a = null;
            Execute(a, p => 45 % p.Int32 == null);
            Execute(a, p => 0 % p.Int32 == null);
            Execute(2, p => null % p.Int32 == null);
            Execute(0, p => null % p.Int32 == null);
            new int?[] { int.MaxValue, int.MinValue, 1, -1, 19 }.ForEach(i => Execute(i, p => 0 % p.Int32 == 0));//遇到以零作除数错误,引发异常
#if !MySQL &&!SQLite&& !MySQL_SDK3_5
            int? b = 0;
            Execute(0, p => p.Int32 / b == 0);//遇到以零作除数错误,引发异常
#endif
        }
        [TestMethod]
        [ExpectedException(typeof(QueryException))]
        public virtual void Zero_Modulo_A()
        {
            new int?[] { int.MinValue, int.MaxValue, 1, -1, 19 }.ForEach(i => Execute(i, p => 0 % p.Int32 == 0));
            Execute(null, p => 0 % p.Int32 == null);
#if !MySQL && !SQLite&& !MySQL_SDK3_5
            int? b = 0;
            Execute(0, p => p.Int32 / b == 0);//遇到以零作除数错误,引发异常
#endif
        }
        [TestMethod]
        public virtual void Null_Plus_A()
        {
            new int?[] { int.MinValue, int.MaxValue, 1, -1, 19, null, 0 }.ForEach(i => Execute(i, p => null + p.Int32 == null));
        }
        [TestMethod]
        public virtual void Null_Subtract_A()
        {
            new int?[] { int.MinValue, int.MaxValue, 1, -1, 19, null, 0 }.ForEach(i => Execute(i, p => null - p.Int32 == null));
        }
        [TestMethod]
        public virtual void Null_Miltiply_A()
        {
            new int?[] { int.MinValue, int.MaxValue, 1, -1, 19, null, 0 }.ForEach(i => Execute(i, p => null * p.Int32 == null));
        }
        [TestMethod]
        public virtual void Null_Divide_A()
        {
            new int?[] { int.MinValue, int.MaxValue, 1, -1, 19, null, 0 }.ForEach(i => Execute(i, p => null / p.Int32 == null));
        }
        [TestMethod]
        public virtual void Null_Modulo_A()
        {
            new int?[] { int.MinValue, int.MaxValue, 1, -1, 19, null, 0 }.ForEach(i => Execute(i, p => null % p.Int32 == null));
        }
        [TestMethod]
        public virtual void B_Plus_Plus()
        {
            //Expression entity = Expression.Parameter(typeof(NullableTypeInfo),"p");
            //Expression field = Expression.PropertyOrField(entity, "Int32");
            //Expression i = Expression.Parameter(typeof(Int32?), "i");

            //var e = Expression.Increment(field);

            ////new int?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19, null }.ForEach(i => Execute(i, p => p.Int32 == i++));
            ////new short?[] { short.MinValue, short.MaxValue, 1, 0, -1, 19, null }.ForEach(i => Execute(i, p => p.Int32 == i++));
            ////new ushort?[] { ushort.MinValue, ushort.MaxValue, 1, 0, 19, null }.ForEach(i => Execute(i, p => p.Int32 == i++));
            ////new sbyte?[] { sbyte.MinValue, sbyte.MaxValue, 1, 0, -1, 19, null }.ForEach(i => Execute(i, p => p.Int32 == i++));
            ////new byte?[] { byte.MinValue, byte.MaxValue, 1, 0, 19, null }.ForEach(i => Execute(i, p => p.Int32 == i++));
        }
        [TestMethod]
        public virtual void Plus_Plus_B()
        {
            //new int?[] { int.MinValue, 1, -1, 19 }.ForEach(i => Execute(i, p => null % p.Int32 == ++i));
            //new short?[] {short.MinValue, 1, -1, 19 }.ForEach(i => Execute(i, p => null % p.Int32 == ++i));
            //new ushort?[] {1, 19 }.ForEach(i => Execute(i, p => null % p.Int32 == ++i));
            //new sbyte?[] {sbyte.MinValue, 1, -1, 19 }.ForEach(i => Execute(i, p => null % p.Int32 == ++i));
            //new byte?[] {1, 19 }.ForEach(i => Execute(i, p => null % p.Int32 == ++i));
        }
        [TestMethod]
        public virtual void B_Minus_Minus()
        {
            //new int?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19, null }.ForEach(i => Execute(i, p => p.Int32 == i--));
            //new short?[] { short.MinValue, short.MaxValue, 1, 0, -1, 19, null }.ForEach(i => Execute(i, p => p.Int32 == i--));
            //new ushort?[] { ushort.MinValue, ushort.MaxValue, 1, 0, 19, null }.ForEach(i => Execute(i, p => p.Int32 == i--));
            //new sbyte?[] { sbyte.MinValue, sbyte.MaxValue, 1, 0, -1, 19, null }.ForEach(i => Execute(i, p => p.Int32 == i--));
            //new byte?[] { byte.MinValue, byte.MaxValue, 1, 0, 19, null }.ForEach(i => Execute(i, p => p.Int32 == i--));
        }
        [TestMethod]
        public virtual void Minus_Minus_B()
        {
            //new int?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19, null }.ForEach(i => Execute(i, p => p.Int32 == (--i)));
            //new short?[] { short.MinValue, short.MaxValue, 1, 0, -1, 19, null }.ForEach(i => Execute(i, p => p.Int32 == (--i)));
            //new ushort?[] { ushort.MinValue, ushort.MaxValue, 1, 0, 19, null }.ForEach(i => Execute(i, p => p.Int32 == (--i)));
            //new sbyte?[] { sbyte.MinValue, sbyte.MaxValue, 1, 0, -1, 19, null }.ForEach(i => Execute(i, p => p.Int32 == (--i)));
            //new byte?[] { byte.MinValue, byte.MaxValue, 1, 0, 19, null }.ForEach(i => Execute(i, p => p.Int32 == (--i)));
        }
        [TestMethod]
        public virtual void A_Equal_Opposite_B()
        {
            new int?[] {/*int.MinValu,*/ int.MaxValue, 1, -1, 19, 0, null }.ForEach(i => Execute(-i, p => p.Int32 == -i));
            new short?[] { short.MinValue, short.MaxValue, 1, -1, 19, 0, null }.ForEach(i => Execute(-i, p => p.Int32 == -i));
            new ushort?[] { ushort.MaxValue, 1, 19, null, 0 }.ForEach(i => Execute(-i, p => p.Int32 == -i));
            new sbyte?[] { sbyte.MinValue, sbyte.MaxValue, 1, -1, 19, 0, null }.ForEach(i => Execute(-i, p => p.Int32 == -i));
            new byte?[] { byte.MaxValue, 1, 19, 0, null }.ForEach(i => Execute(-i, p => p.Int32 == -i));
            new uint?[] { uint.MinValue, 1, 0, 19, null }.ForEach(i => Execute(-i, p => p.Int32 == -i));
            new float?[] { /*int.MinValue,int.MaxValue,*/1, 0, -1, 19, null }.ForEach(i => Execute(-i, p => p.Int32 == -(int?)i));
            new double?[] { /*int.MinValue,*/ int.MaxValue, 1, 0, -1, 19, null }.ForEach(i => Execute(-i, p => p.Int32 == -i));
            new long?[] { /*int.MinValue, */int.MaxValue, 1, 0, -1, 19, null }.ForEach(i => Execute(-i, p => p.Int32 == -i));
            new ulong?[] { int.MaxValue, 1, 0, 19 }.ForEach(i => Execute(-(int?)i, p => p.Int32 == -(int?)i));
            new decimal?[] {/*int.MinValue,*/ int.MaxValue, 1, 0, -1, 19, null }.ForEach(i => Execute(-i, p => -p.Int32 == i));
        }
        //a+=b
        [TestMethod]
        public virtual void A_And_Equal_B()
        { }
        public virtual void A_Divide_Equal_B()
        { }
        //a%=b
        [TestMethod]
        public virtual void A_Model_Equal_B()
        { }
        //a^=b
        [TestMethod]
        public virtual void A_qufan_Equal_B()
        { }
        //a&=b
        [TestMethod]
        public virtual void A_weiyu_Equal_B()
        { }
        //a|=b
        [TestMethod]
        public virtual void A_weihuo_Equal_B()
        { }
        //a=~b
        [TestMethod]
        public virtual void A_Equal_Not_B()
        {
#if !Access && !MySQL &&!Access_SDK3_5&&!MySQL_SDK3_5
            new int?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19 }.ForEach(i => Execute(~i, p => ~p.Int32 == i));
            new short?[] { short.MinValue, short.MaxValue, 1, 0, -1, 19 }.ForEach(i => Execute(~i, p => ~p.Int32 == i));
            new sbyte?[] { sbyte.MinValue, sbyte.MaxValue, 1, 0, -1, 19 }.ForEach(i => Execute(~i, p => ~p.Int32 == i));
            new float?[] { int.MinValue, 1F, 0F, -1F, 19F, 198F }.ForEach(i => Execute(~(int?)i, p => ~p.Int32 == (int?)i));
            new double?[] { int.MinValue, int.MaxValue, 1,/*22.2,*/ 0, 19, 198 }.ForEach(i => Execute(~(int?)i, p => ~p.Int32 == (int?)i));
            new long?[] { int.MinValue, int.MaxValue, -1, 1, 0, 19 }.ForEach(i => Execute(~i, p => ~p.Int32 == i));
            new decimal?[] { int.MinValue, int.MaxValue, -1M, 234M, 1M, 0M, 19M }.ForEach(i => Execute(~(int?)i, p => ~p.Int32 == (int?)i));

            Execute(null, p => ~p.Int32 == null);
#endif
            new ushort?[] { ushort.MinValue, ushort.MaxValue, 1, 0, 19 }.ForEach(i => Execute(~i, p => ~p.Int32 == i));
            new byte?[] { byte.MinValue, byte.MaxValue, 1, 0, 19 }.ForEach(i => Execute(~i, p => ~p.Int32 == i));
            new uint?[] { uint.MinValue, int.MaxValue, 1, 0, 19 }.ForEach(i => Execute(~(int?)i, p => ~p.Int32 == i));
            new ulong?[] { int.MaxValue, 1L, 0L, 19L }.ForEach(i => Execute(~(int?)i, p => ~p.Int32 == (int?)i));

#if Access
            Execute(null, p => ~p.Int32 != null);
#endif

            int? a = null;
            Assert.IsTrue(~a == null);
        }
        //a&b
        [TestMethod]
        public virtual void A_And_B()
        {
#if !SqlCE && !MySQL&& !MySQL_SDK3_5&&!SQLite_SDK3_5&&!SqlCE_SDK3_5
            new int?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19, null }.ForEach(i => Execute(i, p => (p.Int32 & i) == i));
            new short?[] { short.MinValue, short.MaxValue, 1, 0, -1, 19, null }.ForEach(i => Execute(i, p => (p.Int32 & i) == i));
            new sbyte?[] { sbyte.MinValue, sbyte.MaxValue, 1, 0, -1, 19, null }.ForEach(i => Execute(i, p => (p.Int32 & i) == i));
            new float?[] { int.MinValue,/*int.MaxValue, */1F, 0F, -1F, 19F, 198F, null }.ForEach(i => Execute(i, p => (p.Int32 & (int?)i) == (int?)i));
            new double?[] { int.MinValue, int.MaxValue, 1,/*22.2,*/ 0, 19, 198, null }.ForEach(i => Execute(i, p => (p.Int32 & (int?)i) == i));
            new long?[] { int.MinValue, int.MaxValue, -1, 1, 0, 19, null }.ForEach(i => Execute(i, p => (p.Int32 & i) == i));
            new decimal?[] { int.MinValue, int.MaxValue, -1M, 234M, 1M, 0M, 19M, null }.ForEach(i => Execute(i, p => (p.Int32 & (int?)i) == i));
#endif
            new ushort?[] { ushort.MinValue, ushort.MaxValue, 1, 0, 19, null }.ForEach(i => Execute(i, p => (p.Int32 & i) == i));
            new byte?[] { byte.MinValue, byte.MaxValue, 1, 0, 19, null }.ForEach(i => Execute(i, p => (p.Int32 & i) == i));
            new uint?[] { uint.MinValue, 1, 0, 19, null }.ForEach(i => Execute(i, p => (p.Int32 & i) == i));
            new ulong?[] { int.MaxValue, 1L, 0L, 19L, null }.ForEach(i => Execute(i, p => (p.Int32 & (int?)i) == (int?)i));

            int? a = null;
            Execute(3, p => (p.Int32 & a) == null);
        }
        //a|b
        [TestMethod]
        public virtual void A_Or_B()
        {
#if !SqlCE && !MySQL&& !MySQL_SDK3_5&&!SQLite_SDK3_5&&!SqlCE_SDK3_5
            new int?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19, null }.ForEach(i => Execute(i, p => (p.Int32 | i) == i));
            new short?[] { short.MinValue, short.MaxValue, 1, 0, -1, 19, null }.ForEach(i => Execute(i, p => (p.Int32 | i) == i));
            new long?[] { int.MinValue, int.MaxValue, -1, 1, 0, 19, null }.ForEach(i => Execute(i, p => (p.Int32 | i) == i));
            new double?[] { int.MinValue, int.MaxValue, 1,/*22.2,*/ 0, 19, 198, null }.ForEach(i => Execute(i, p => (p.Int32 | (int?)i) == i));
            new float?[] { int.MinValue,/*int.MaxValue, */1F, 0F, -1F, 19F, 198F, null }.ForEach(i => Execute(i, p => (p.Int32 | (int?)i) == (int?)i));
            new sbyte?[] { sbyte.MinValue, sbyte.MaxValue, 1, 0, -1, 19, null }.ForEach(i => Execute(i, p => (p.Int32 | i) == i));
            new decimal?[] { int.MinValue, int.MaxValue, -1M, 234M, 1M, 0M, 19M, null }.ForEach(i => Execute(i, p => (p.Int32 | (int?)i) == i));
#endif
            new ushort?[] { ushort.MinValue, ushort.MaxValue, 1, 0, 19, null }.ForEach(i => Execute(i, p => (p.Int32 | i) == i));
            new byte?[] { byte.MinValue, byte.MaxValue, 1, 0, 19, null }.ForEach(i => Execute(i, p => (p.Int32 | i) == i));
            new uint?[] { uint.MinValue, 1, 0, 19, null }.ForEach(i => Execute(i, p => (p.Int32 | i) == i));
            new ulong?[] { int.MaxValue, 1L, 0L, 19L, null }.ForEach(i => Execute(i, p => (p.Int32 | (int?)i) == (int?)i));

            int? a = null;
            Execute(3, p => (p.Int32 | a) == null);
        }
        //a^b
        [TestMethod]
        public virtual void A_ExclusiveOr_B()
        {
#if !SqlCE&&!SqlCE_SDK3_5
            new int?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19 }.ForEach(i => Execute(i, p => (p.Int32 ^ i) == 0));
            new short?[] { short.MinValue, short.MaxValue, 1, 0, -1, 19 }.ForEach(i => Execute(i, p => (p.Int32 ^ i) == 0));
            new double?[] { int.MinValue, int.MaxValue, 1,/*22.2,*/ 0, 19, 198 }.ForEach(i => Execute(i, p => (p.Int32 ^ (int?)i) == 0));
            new sbyte?[] { sbyte.MinValue, sbyte.MaxValue, 1, 0, -1, 19 }.ForEach(i => Execute(i, p => (p.Int32 ^ i) == 0));
            new float?[] { int.MinValue,/*int.MaxValue, */1F, 0F, -1F, 19F, 198F }.ForEach(i => Execute(i, p => (p.Int32 ^ (int?)i) == 0));
            new long?[] { int.MinValue, int.MaxValue, -1, 1, 0, 19 }.ForEach(i => Execute(i, p => (p.Int32 ^ i) == 0));
            new decimal?[] { int.MinValue, int.MaxValue, -1M, 234M, 1M, 0M, 19M }.ForEach(i => Execute(i, p => (p.Int32 ^ (int?)i) == 0));
#endif
            new byte?[] { byte.MinValue, byte.MaxValue, 1, 0, 19 }.ForEach(i => Execute(i, p => (p.Int32 ^ i) == 0));
            new ushort?[] { ushort.MinValue, ushort.MaxValue, 1, 0, 19 }.ForEach(i => Execute(i, p => (p.Int32 ^ i) == 0));
            new uint?[] { uint.MinValue, 1, 0, 19 }.ForEach(i => Execute(i, p => (p.Int32 ^ i) == 0));
            new ulong?[] { int.MaxValue, 1L, 0L, 19L }.ForEach(i => Execute(i, p => (p.Int32 ^ (int?)i) == 0));
            int? a = null;
            Execute(null, p => (p.Int32 ^ a) == null);
            Execute(0, p => (p.Int32 ^ a) == null);
        }
        //a>>b
        [TestMethod]
        public virtual void A_Right_Shift_B()
        {
            new int?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19 }.ForEach(i => Execute(i >> 2, p => p.Int32 == i >> 2));
            new short?[] { short.MinValue, short.MaxValue, 1, 0, -1, 19 }.ForEach(i => Execute(i >> 2, p => p.Int32 == i >> 2));
            new ushort?[] { ushort.MinValue, ushort.MaxValue, 1, 0, 19 }.ForEach(i => Execute(i >> 2, p => p.Int32 == i >> 2));
            new sbyte?[] { sbyte.MinValue, sbyte.MaxValue, 1, 0, -1, 19 }.ForEach(i => Execute(i >> 2, p => p.Int32 == i >> 2));
            new byte?[] { byte.MinValue, byte.MaxValue, 1, 0, 19 }.ForEach(i => Execute(i >> 2, p => p.Int32 == i >> 2));
            new float?[] { int.MinValue,/*int.MaxValue, */1F, 0F, -1F, 19F, 198F }.ForEach(i => Execute((int?)i >> 2, p => p.Int32 == (int?)i >> 2));
            new double?[] { int.MinValue, int.MaxValue, 1,/*22.2,*/ 0, 19, 198 }.ForEach(i => Execute((int?)i >> 2, p => p.Int32 == (int?)i >> 2));
            new uint?[] { uint.MinValue, 1, 0, 19 }.ForEach(i => Execute(i >> 2, p => p.Int32 == i >> 2));
            new long?[] { int.MinValue, int.MaxValue, -1, 1, 0, 19 }.ForEach(i => Execute(i >> 2, p => p.Int32 == i >> 2));
            new ulong?[] { int.MaxValue, 1L, 0L, 19L }.ForEach(i => Execute(i >> 2, p => p.Int32 == (int?)i >> 2));
            new decimal?[] { int.MinValue, int.MaxValue, -1M, 234M, 1M, 0M, 19M }.ForEach(i => Execute((int?)i >> 2, p => p.Int32 == (int?)i >> 2));
            int? a = null;
            Execute(a, p => p.Int32 >> 2 == null);
            Execute(2, p => p.Int32 >> a == null);
            Execute(a, p => p.Int32 >> a == null);
            Execute(2, p => p.Int32 >> 0 == 2);
        }
        //a<<b
        [TestMethod]
        public virtual void A_Left_Shift_B()
        {
            new int?[] { int.MinValue, int.MaxValue, 1, 0, -1, 19 }.ForEach(i => Execute(i << 2, p => p.Int32 == i << 2));
            new short?[] { short.MinValue, short.MaxValue, 1, 0, -1, 19 }.ForEach(i => Execute(i << 2, p => p.Int32 == i << 2));
            new ushort?[] { ushort.MinValue, ushort.MaxValue, 1, 0, 19 }.ForEach(i => Execute(i << 2, p => p.Int32 == i << 2));
            new sbyte?[] { sbyte.MinValue, sbyte.MaxValue, 1, 0, -1, 19 }.ForEach(i => Execute(i << 2, p => p.Int32 == i << 2));
            new byte?[] { byte.MinValue, byte.MaxValue, 1, 0, 19 }.ForEach(i => Execute(i << 2, p => p.Int32 == i << 2));
            new float?[] { int.MinValue/*, int.MaxValue*/, 1F, 0F, -1F, 19F, 198F }.ForEach(i => Execute((int?)i << 2, p => p.Int32 == (int?)i << 2));
            new double?[] { int.MinValue, int.MaxValue, 1,/*22.2,*/ 0, 19, 198 }.ForEach(i => Execute((int?)i << 2, p => p.Int32 == (int?)i << 2));
            new uint?[] { uint.MinValue, 1, 0, 19 }.ForEach(i => Execute(i << 2, p => p.Int32 == i << 2));
            new long?[] { int.MinValue, int.MaxValue, -1, 1, 0, 19 }.ForEach(i => Execute((int?)i << 2, p => p.Int32 == (int?)i << 2));
            new ulong?[] { int.MaxValue, 1L, 0L, 19L }.ForEach(i => Execute((int?)i << 2, p => p.Int32 == (int?)i << 2));
            new decimal?[] { int.MinValue, int.MaxValue, -1M, 234M, 1M, 0M, 19M }.ForEach(i => Execute((int?)i << 2, p => p.Int32 == (int?)i << 2));
            int? a = null;
            Execute(a, p => p.Int32 << 2 == null);
            Execute(2, p => p.Int32 << a == null);
            Execute(a, p => p.Int32 << a == null);
            Execute(2, p => p.Int32 << 0 == 2);
        }
        //a&&b
        [TestMethod]
        public virtual void A_And_And_B()
        {
            new int?[] { int.MinValue, int.MaxValue, -8, -1, 0, 1, 25 }.ForEach(i => Execute(i, p => p.Int32 >= int.MinValue && p.String != null));
            new int?[] { int.MinValue, int.MaxValue, -8, -1, 0, 1, 25 }.ForEach(i => ExecuteNull(i, p => p.Int32 >= int.MinValue && p.String == null));
        }
        //a||b
        [TestMethod]
        public virtual void A_Or_Or_B()
        {
            new int?[] { int.MinValue, int.MaxValue, -8, -1, 0, 1, 25 }.ForEach(i => Execute(i, p => p.Int32 >= int.MinValue || p.String == null));
            new int?[] { int.MinValue, int.MaxValue, -8, -1, 0, 1, 25 }.ForEach(i => ExecuteNull(i, p => p.Int32 < int.MinValue || p.String == null));
            new int?[] { int.MinValue, int.MaxValue, -8, -1, 0, 1, 25 }.ForEach(i => Execute(i, p => p.Int32 >= int.MinValue || p.String != null));
        }
        //!a
        [TestMethod]
        public virtual void Logic_Not_A()
        {
            new int?[] { int.MinValue, int.MaxValue, -8, -1, 0, 1, 25 }.ForEach(i => Execute(i, p => !(p.Int32 < int.MinValue)));
            new int?[] { int.MinValue, int.MaxValue, -8, -1, 0, 1, 25 }.ForEach(i => Execute(i, p => !(p.Int32 < int.MinValue)));
        }
        //a.between(c,d)
        [TestMethod]
        public virtual void A_Between_C_And_D()
        { }
        //list.contains(a)
        [TestMethod]
        public virtual void List_Contains_A()
        { }
    }
}
