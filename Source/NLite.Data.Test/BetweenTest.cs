using System;
using System.Linq;
using System.Linq.Expressions;
using NLite.Data.Common;
using NLite.Data.Test.Primitive.Model;
using NUnit.Framework;
using TestMethod = NUnit.Framework.TestAttribute;

namespace NLite.Data.Test
{
    class BetweenTest : TestBase<NullableTypeInfo>
    {
        protected override string ConnectionStringName
        {
            get
            {
                return "NumericDB";
            }
        }

        internal virtual void Insert()
        {
            Db.Set<NullableTypeInfo>().Insert(new NullableTypeInfo { Int32 = 123, String = "aa", Int16 = 12, Int64 = 33 });
        }
        internal virtual void Delete()
        {
            Db.Set<NullableTypeInfo>().Delete(p => true);
        }
        protected void Excute(Expression<Func<NullableTypeInfo, bool>> where)
        {
            Table.Delete(p => true);
            var expected = new NullableTypeInfo { Int32 = 123, String = "abcd", Int16 = 12, Int64 = 33, Double = 23.21, Decimal = 10, UInt16 = 12, UInt32 = 123, UInt64 = 33, DateTime = new DateTime(2013, 1, 15, 10, 26, 40) };
            Table.Insert(expected);

            var item = Table.Select(where).FirstOrDefault();
            Assert.AreEqual(item, true);

            var item1 = Table.Where(where).FirstOrDefault();
            Assert.IsNotNull(item1);

            Table.Delete(p => true);
        }



        protected void ExcuteNull(Expression<Func<NullableTypeInfo, bool>> where)
        {
            Table.Delete(p => true);
            var expected = new NullableTypeInfo { Int32 = 123, String = "abcd", Int16 = 12, Int64 = 33, Double = 23.21, Decimal = 10, UInt16 = 12, UInt32 = 123, UInt64 = 33, DateTime = new DateTime(2013, 1, 15, 10, 26, 40) };
            Table.Insert(expected);

            var item = Table.Select(where).FirstOrDefault();
            Assert.AreNotEqual(item, true);

            var item1 = Table.Where(where).FirstOrDefault();
            Assert.IsNull(item1);

            Table.Delete(p => true);
        }

        [TestMethod]
        public virtual void Int16a()
        {
            Excute(p => SqlFunctions.Between(p.Int16, 12, 13).Value);
            Excute(p => SqlFunctions.Between(p.Int16, 11, 12).Value);
            Excute(p => SqlFunctions.Between(p.Int16, 11, 13).Value);
            Excute(p => SqlFunctions.Between(p.Int16, 12, 12).Value);
            ExcuteNull(p => SqlFunctions.Between(p.Int16, 10, 11).Value);
            ExcuteNull(p => SqlFunctions.Between(p.Int16, 13, 14).Value);
        }

        [TestMethod]
        public virtual void Int16b()
        {
            Excute(p => SqlFunctions.Between(p.Int16, 12, 13) == true);
            Excute(p => SqlFunctions.Between(p.Int16, 11, 12) == true);
            Excute(p => SqlFunctions.Between(p.Int16, 11, 13) == true);
            Excute(p => SqlFunctions.Between(p.Int16, 12, 12) == true);
            Excute(p => SqlFunctions.Between(p.Int16, 10, 11) == false);
            Excute(p => SqlFunctions.Between(p.Int16, 13, 14) == false);
            ExcuteNull(p => SqlFunctions.Between(p.Int16, 10, 11) == true);
            ExcuteNull(p => SqlFunctions.Between(p.Int16, 13, 14) == true);
        }

        [TestMethod]
        public virtual void Int16c()
        {
            Excute(p => SqlFunctions.Between(p.Int16, 12, 13).Value == true);
            Excute(p => SqlFunctions.Between(p.Int16, 11, 12).Value == true);
            Excute(p => SqlFunctions.Between(p.Int16, 11, 13).Value == true);
            Excute(p => SqlFunctions.Between(p.Int16, 12, 12).Value == true);
            Excute(p => SqlFunctions.Between(p.Int16, 10, 11).Value == false);
            Excute(p => SqlFunctions.Between(p.Int16, 13, 14).Value == false);
            ExcuteNull(p => SqlFunctions.Between(p.Int16, 10, 11).Value == true);
            ExcuteNull(p => SqlFunctions.Between(p.Int16, 13, 14).Value == true);
        }

        [TestMethod]
        public virtual void Int32a()
        {
            Excute(p => SqlFunctions.Between(p.Int32, 122, 132).Value);
            Excute(p => SqlFunctions.Between(p.Int32, 123, 132).Value);
            Excute(p => SqlFunctions.Between(p.Int32, 122, 123).Value);
            Excute(p => SqlFunctions.Between(p.Int32, 123, 123).Value);
            ExcuteNull(p => SqlFunctions.Between(p.Int32, 10, 11).Value);
            ExcuteNull(p => SqlFunctions.Between(p.Int32, 133, 143).Value);
        }

        [TestMethod]
        public virtual void Int32b()
        {
            Excute(p => SqlFunctions.Between(p.Int32, 122, 132) == true);
            Excute(p => SqlFunctions.Between(p.Int32, 123, 132) == true);
            Excute(p => SqlFunctions.Between(p.Int32, 122, 123) == true);
            Excute(p => SqlFunctions.Between(p.Int32, 123, 123) == true);
            Excute(p => SqlFunctions.Between(p.Int32, 10, 11) == false);
            Excute(p => SqlFunctions.Between(p.Int32, 133, 143) == false);
            ExcuteNull(p => SqlFunctions.Between(p.Int32, 10, 11) == true);
            ExcuteNull(p => SqlFunctions.Between(p.Int32, 133, 143) == true);
        }

        [TestMethod]
        public virtual void Int32c()
        {
            Excute(p => SqlFunctions.Between(p.Int32, 122, 132).Value == true);
            Excute(p => SqlFunctions.Between(p.Int32, 123, 132).Value == true);
            Excute(p => SqlFunctions.Between(p.Int32, 122, 123).Value == true);
            Excute(p => SqlFunctions.Between(p.Int32, 123, 123).Value == true);
            Excute(p => SqlFunctions.Between(p.Int32, 10, 11).Value == false);
            Excute(p => SqlFunctions.Between(p.Int32, 133, 143).Value == false);
            ExcuteNull(p => SqlFunctions.Between(p.Int32, 10, 11).Value == true);
            ExcuteNull(p => SqlFunctions.Between(p.Int32, 133, 143).Value == true);
        }

        [TestMethod]
        public virtual void Int64a()
        {
            Excute(p => SqlFunctions.Between(p.Int64, 22, 132).Value);
            Excute(p => SqlFunctions.Between(p.Int64, 33, 132).Value);
            Excute(p => SqlFunctions.Between(p.Int64, 22, 33).Value);
            Excute(p => SqlFunctions.Between(p.Int64, 33, 33).Value);
            ExcuteNull(p => SqlFunctions.Between(p.Int64, 10, 32).Value);
            ExcuteNull(p => SqlFunctions.Between(p.Int64, 34, 143).Value);
        }

        [TestMethod]
        public virtual void Int64b()
        {
            Excute(p => SqlFunctions.Between(p.Int64, 22, 132) == true);
            Excute(p => SqlFunctions.Between(p.Int64, 33, 132) == true);
            Excute(p => SqlFunctions.Between(p.Int64, 22, 33) == true);
            Excute(p => SqlFunctions.Between(p.Int64, 33, 33) == true);
            Excute(p => SqlFunctions.Between(p.Int64, 10, 32) == false);
            Excute(p => SqlFunctions.Between(p.Int64, 34, 143) == false);
            ExcuteNull(p => SqlFunctions.Between(p.Int64, 10, 32) == true);
            ExcuteNull(p => SqlFunctions.Between(p.Int64, 34, 143) == true);
        }

        [TestMethod]
        public virtual void Int64c()
        {
            Excute(p => SqlFunctions.Between(p.Int64, 22, 132).Value == true);
            Excute(p => SqlFunctions.Between(p.Int64, 33, 132).Value == true);
            Excute(p => SqlFunctions.Between(p.Int64, 22, 33).Value == true);
            Excute(p => SqlFunctions.Between(p.Int64, 33, 33).Value == true);
            Excute(p => SqlFunctions.Between(p.Int64, 10, 32).Value == false);
            Excute(p => SqlFunctions.Between(p.Int64, 34, 143).Value == false);
            ExcuteNull(p => SqlFunctions.Between(p.Int64, 10, 32).Value == true);
            ExcuteNull(p => SqlFunctions.Between(p.Int64, 34, 143).Value == true);
        }

        [TestMethod]
        public virtual void Doublea()
        {
            Excute(p => SqlFunctions.Between(p.Double, 23.0, 24.0).Value);
            Excute(p => SqlFunctions.Between(p.Double, 23.21, 132.0).Value);
            Excute(p => SqlFunctions.Between(p.Double, 22.0, 23.21).Value);
            Excute(p => SqlFunctions.Between(p.Double, 23.21, 23.21).Value);
            ExcuteNull(p => SqlFunctions.Between(p.Double, 10.0, 23.0).Value);
            ExcuteNull(p => SqlFunctions.Between(p.Double, 24.0, 143.0).Value);
        }

        [TestMethod]
        public virtual void Doubleb()
        {
            Excute(p => SqlFunctions.Between(p.Double, 23.0, 24.0) == true);
            Excute(p => SqlFunctions.Between(p.Double, 23.21, 132.0) == true);
            Excute(p => SqlFunctions.Between(p.Double, 22.0, 23.21) == true);
            Excute(p => SqlFunctions.Between(p.Double, 23.21, 23.21) == true);
            Excute(p => SqlFunctions.Between(p.Double, 10.0, 23.0) == false);
            Excute(p => SqlFunctions.Between(p.Double, 24.0, 143.0) == false);
            ExcuteNull(p => SqlFunctions.Between(p.Double, 10.0, 23.0) == true);
            ExcuteNull(p => SqlFunctions.Between(p.Double, 24.0, 143.0) == true);
        }

        [TestMethod]
        public virtual void Doublec()
        {
            //Excute(p => SqlFunctions.Between(p.Double, 23.0, 24.0).Value == true);
            Excute(p => SqlFunctions.Between(p.Double, 23.21, 132.0).Value == true);
            Excute(p => SqlFunctions.Between(p.Double, 22.0, 23.21).Value == true);
            Excute(p => SqlFunctions.Between(p.Double, 23.21, 23.21).Value == true);
            Excute(p => SqlFunctions.Between(p.Double, 10.0, 23.0).Value == false);
            Excute(p => SqlFunctions.Between(p.Double, 24.0, 143.0).Value == false);
            ExcuteNull(p => SqlFunctions.Between(p.Double, 10.0, 23.0).Value == true);
            ExcuteNull(p => SqlFunctions.Between(p.Double, 24.0, 143.0).Value == true);
        }

        [TestMethod]
        public virtual void Decimala()
        {
            Excute(p => SqlFunctions.Between(p.Decimal, 9, 11).Value);
            Excute(p => SqlFunctions.Between(p.Decimal, 10, 11).Value);
            Excute(p => SqlFunctions.Between(p.Decimal, 9, 10).Value);
            Excute(p => SqlFunctions.Between(p.Decimal, 10, 10).Value);
            ExcuteNull(p => SqlFunctions.Between(p.Decimal, 8, 9).Value);
            ExcuteNull(p => SqlFunctions.Between(p.Decimal, 11, 12).Value);
        }

        [TestMethod]
        public virtual void Decimalb()
        {
            Excute(p => SqlFunctions.Between(p.Decimal, 9, 11) == true);
            Excute(p => SqlFunctions.Between(p.Decimal, 10, 11) == true);
            Excute(p => SqlFunctions.Between(p.Decimal, 9, 10) == true);
            Excute(p => SqlFunctions.Between(p.Decimal, 10, 10) == true);
            Excute(p => SqlFunctions.Between(p.Decimal, 8, 9) == false);
            Excute(p => SqlFunctions.Between(p.Decimal, 11, 12) == false);
            ExcuteNull(p => SqlFunctions.Between(p.Decimal, 8, 9) == true);
            ExcuteNull(p => SqlFunctions.Between(p.Decimal, 11, 12) == true);
        }

        [TestMethod]
        public virtual void Decimalc()
        {
            Excute(p => SqlFunctions.Between(p.Decimal, 9, 11).Value == true);
            Excute(p => SqlFunctions.Between(p.Decimal, 10, 11).Value == true);
            Excute(p => SqlFunctions.Between(p.Decimal, 9, 10).Value == true);
            Excute(p => SqlFunctions.Between(p.Decimal, 10, 10).Value == true);
            Excute(p => SqlFunctions.Between(p.Decimal, 8, 9).Value == false);
            Excute(p => SqlFunctions.Between(p.Decimal, 11, 12).Value == false);
            ExcuteNull(p => SqlFunctions.Between(p.Decimal, 8, 9).Value == true);
            ExcuteNull(p => SqlFunctions.Between(p.Decimal, 11, 12).Value == true);
        }


        [TestMethod]
        public virtual void UInt16a()
        {
            Excute(p => SqlFunctions.Between(p.UInt16, 12, 13).Value);
            Excute(p => SqlFunctions.Between(p.UInt16, 11, 12).Value);
            Excute(p => SqlFunctions.Between(p.UInt16, 11, 13).Value);
            ExcuteNull(p => SqlFunctions.Between(p.UInt16, 10, 11).Value);
            ExcuteNull(p => SqlFunctions.Between(p.UInt16, 13, 14).Value);
        }

        [TestMethod]
        public virtual void UInt16b()
        {
            Excute(p => SqlFunctions.Between(p.UInt16, 12, 13) == true);
            Excute(p => SqlFunctions.Between(p.UInt16, 11, 12) == true);
            Excute(p => SqlFunctions.Between(p.UInt16, 11, 13) == true);
            Excute(p => SqlFunctions.Between(p.UInt16, 10, 11) == false);
            Excute(p => SqlFunctions.Between(p.UInt16, 13, 14) == false);
            ExcuteNull(p => SqlFunctions.Between(p.UInt16, 10, 11) == true);
            ExcuteNull(p => SqlFunctions.Between(p.UInt16, 13, 14) == true);
        }

        [TestMethod]
        public virtual void UInt16c()
        {
            Excute(p => SqlFunctions.Between(p.UInt16, 12, 13).Value == true);
            Excute(p => SqlFunctions.Between(p.UInt16, 11, 12).Value == true);
            Excute(p => SqlFunctions.Between(p.UInt16, 11, 13).Value == true);
            Excute(p => SqlFunctions.Between(p.UInt16, 10, 11).Value == false);
            Excute(p => SqlFunctions.Between(p.UInt16, 13, 14).Value == false);
            ExcuteNull(p => SqlFunctions.Between(p.UInt16, 10, 11).Value == true);
            ExcuteNull(p => SqlFunctions.Between(p.UInt16, 13, 14).Value == true);
        }

        [TestMethod]
        public virtual void UInt32a()
        {
            Excute(p => SqlFunctions.Between(p.UInt32, 122, 132).Value);
            Excute(p => SqlFunctions.Between(p.UInt32, 123, 132).Value);
            Excute(p => SqlFunctions.Between(p.UInt32, 122, 123).Value);
            ExcuteNull(p => SqlFunctions.Between(p.UInt32, 10, 11).Value);
            ExcuteNull(p => SqlFunctions.Between(p.UInt32, 133, 143).Value);
        }

        [TestMethod]
        public virtual void UInt32b()
        {
            Excute(p => SqlFunctions.Between(p.UInt32, 122, 132) == true);
            Excute(p => SqlFunctions.Between(p.UInt32, 123, 132) == true);
            Excute(p => SqlFunctions.Between(p.UInt32, 122, 123) == true);
            Excute(p => SqlFunctions.Between(p.UInt32, 10, 11) == false);
            Excute(p => SqlFunctions.Between(p.UInt32, 133, 143) == false);
            ExcuteNull(p => SqlFunctions.Between(p.UInt32, 10, 11) == true);
            ExcuteNull(p => SqlFunctions.Between(p.UInt32, 133, 143) == true);
        }

        [TestMethod]
        public virtual void UInt32c()
        {
            Excute(p => SqlFunctions.Between(p.UInt32, 122, 132).Value == true);
            Excute(p => SqlFunctions.Between(p.UInt32, 123, 132).Value == true);
            Excute(p => SqlFunctions.Between(p.UInt32, 122, 123).Value == true);
            Excute(p => SqlFunctions.Between(p.UInt32, 10, 11).Value == false);
            Excute(p => SqlFunctions.Between(p.UInt32, 133, 143).Value == false);
            ExcuteNull(p => SqlFunctions.Between(p.UInt32, 10, 11).Value == true);
            ExcuteNull(p => SqlFunctions.Between(p.UInt32, 133, 143).Value == true);
        }


        [TestMethod]
        public virtual void UInt64a()
        {
            Excute(p => SqlFunctions.Between(p.UInt64, 22, 132).Value);
            Excute(p => SqlFunctions.Between(p.UInt64, 33, 132).Value);
            Excute(p => SqlFunctions.Between(p.UInt64, 22, 33).Value);
            ExcuteNull(p => SqlFunctions.Between(p.UInt64, 10, 32).Value);
            ExcuteNull(p => SqlFunctions.Between(p.UInt64, 34, 143).Value);
        }

        [TestMethod]
        public virtual void UInt64b()
        {
            Excute(p => SqlFunctions.Between(p.UInt64, 22, 132) == true);
            Excute(p => SqlFunctions.Between(p.UInt64, 33, 132) == true);
            Excute(p => SqlFunctions.Between(p.UInt64, 22, 33) == true);
            Excute(p => SqlFunctions.Between(p.UInt64, 10, 32) == false);
            Excute(p => SqlFunctions.Between(p.UInt64, 34, 143) == false);
            ExcuteNull(p => SqlFunctions.Between(p.UInt64, 10, 32) == true);
            ExcuteNull(p => SqlFunctions.Between(p.UInt64, 34, 143) == true);
        }

        [TestMethod]
        public virtual void UInt64c()
        {
            Excute(p => SqlFunctions.Between(p.UInt64, 22, 132).Value == true);
            Excute(p => SqlFunctions.Between(p.UInt64, 33, 132).Value == true);
            Excute(p => SqlFunctions.Between(p.UInt64, 22, 33).Value == true);
            Excute(p => SqlFunctions.Between(p.UInt64, 10, 32).Value == false);
            Excute(p => SqlFunctions.Between(p.UInt64, 34, 143).Value == false);
            ExcuteNull(p => SqlFunctions.Between(p.UInt64, 10, 32).Value == true);
            ExcuteNull(p => SqlFunctions.Between(p.UInt64, 34, 143).Value == true);
        }


        [TestMethod]
        public virtual void Stringa()
        {
            Excute(p => SqlFunctions.Between(p.String, "abc", "abcde"));
            Excute(p => SqlFunctions.Between(p.String, "abcd", "abcde"));
            Excute(p => SqlFunctions.Between(p.String, "abc", "abcd"));
            Excute(p => SqlFunctions.Between(p.String, "abcd", "abcd"));
            ExcuteNull(p => SqlFunctions.Between(p.String, "ab", "abc"));
            ExcuteNull(p => SqlFunctions.Between(p.String, "abcde", "abcdf"));
        }

        [TestMethod]
        public virtual void Stringb()
        {
            Excute(p => SqlFunctions.Between(p.String, "abc", "abcde") == true);
            Excute(p => SqlFunctions.Between(p.String, "abcd", "abcde") == true);
            Excute(p => SqlFunctions.Between(p.String, "abc", "abcd") == true);
            Excute(p => SqlFunctions.Between(p.String, "abcd", "abcd") == true);
            Excute(p => SqlFunctions.Between(p.String, "ab", "abc") == false);
            Excute(p => SqlFunctions.Between(p.String, "abcde", "abcdf") == false);
            ExcuteNull(p => SqlFunctions.Between(p.String, "ab", "abc") == true);
            ExcuteNull(p => SqlFunctions.Between(p.String, "abcde", "abcdf") == true);
        }

        [TestMethod]
        public virtual void DateTimea()
        {
            Excute(p => SqlFunctions.Between(p.DateTime, new DateTime(2012, 1, 1, 10, 10, 20), new DateTime(2013, 2, 15, 1, 1, 1)).Value);
            Excute(p => SqlFunctions.Between(p.DateTime, new DateTime(2013, 1, 15, 10, 26, 40), new DateTime(2013, 2, 15, 1, 1, 1)).Value);
            Excute(p => SqlFunctions.Between(p.DateTime, new DateTime(2012, 1, 1, 10, 10, 20), new DateTime(2013, 1, 15, 10, 26, 40)).Value);
            Excute(p => SqlFunctions.Between(p.DateTime, new DateTime(2013, 1, 15, 10, 26, 40), new DateTime(2013, 1, 15, 10, 26, 40)).Value);
            ExcuteNull(p => SqlFunctions.Between(p.DateTime, new DateTime(2012, 1, 1, 10, 10, 20), new DateTime(2012, 2, 15, 1, 1, 1)).Value);
            ExcuteNull(p => SqlFunctions.Between(p.DateTime, new DateTime(2013, 2, 1, 10, 10, 20), new DateTime(2013, 2, 15, 1, 1, 1)).Value);
        }

        [TestMethod]
        public virtual void DateTimeb()
        {
            Excute(p => SqlFunctions.Between(p.DateTime, new DateTime(2012, 1, 1, 10, 10, 20), new DateTime(2013, 2, 15, 1, 1, 1)) == true);
            Excute(p => SqlFunctions.Between(p.DateTime, new DateTime(2013, 1, 15, 10, 26, 40), new DateTime(2013, 2, 15, 1, 1, 1)) == true);
            Excute(p => SqlFunctions.Between(p.DateTime, new DateTime(2012, 1, 1, 10, 10, 20), new DateTime(2013, 1, 15, 10, 26, 40)) == true);
            Excute(p => SqlFunctions.Between(p.DateTime, new DateTime(2013, 1, 15, 10, 26, 40), new DateTime(2013, 1, 15, 10, 26, 40)) == true);
            Excute(p => SqlFunctions.Between(p.DateTime, new DateTime(2012, 1, 1, 10, 10, 20), new DateTime(2012, 2, 15, 1, 1, 1)) == false);
            Excute(p => SqlFunctions.Between(p.DateTime, new DateTime(2013, 2, 1, 10, 10, 20), new DateTime(2013, 2, 15, 1, 1, 1)) == false);
            ExcuteNull(p => SqlFunctions.Between(p.DateTime, new DateTime(2012, 1, 1, 10, 10, 20), new DateTime(2012, 2, 15, 1, 1, 1)) == true);
            ExcuteNull(p => SqlFunctions.Between(p.DateTime, new DateTime(2013, 2, 1, 10, 10, 20), new DateTime(2013, 2, 15, 1, 1, 1)) == true);
        }

        [TestMethod]
        public virtual void DateTimec()
        {
            Excute(p => SqlFunctions.Between(p.DateTime, new DateTime(2012, 1, 1, 10, 10, 20), new DateTime(2013, 2, 15, 1, 1, 1)).Value == true);
            Excute(p => SqlFunctions.Between(p.DateTime, new DateTime(2013, 1, 15, 10, 26, 40), new DateTime(2013, 2, 15, 1, 1, 1)).Value == true);
            Excute(p => SqlFunctions.Between(p.DateTime, new DateTime(2012, 1, 1, 10, 10, 20), new DateTime(2013, 1, 15, 10, 26, 40)).Value == true);
            Excute(p => SqlFunctions.Between(p.DateTime, new DateTime(2013, 1, 15, 10, 26, 40), new DateTime(2013, 1, 15, 10, 26, 40)).Value == true);
            Excute(p => SqlFunctions.Between(p.DateTime, new DateTime(2012, 1, 1, 10, 10, 20), new DateTime(2012, 2, 15, 1, 1, 1)).Value == false);
            Excute(p => SqlFunctions.Between(p.DateTime, new DateTime(2013, 2, 1, 10, 10, 20), new DateTime(2013, 2, 15, 1, 1, 1)).Value == false);
            ExcuteNull(p => SqlFunctions.Between(p.DateTime, new DateTime(2012, 1, 1, 10, 10, 20), new DateTime(2012, 2, 15, 1, 1, 1)).Value == true);
            ExcuteNull(p => SqlFunctions.Between(p.DateTime, new DateTime(2013, 2, 1, 10, 10, 20), new DateTime(2013, 2, 15, 1, 1, 1)).Value == true);
        }
    }
}
