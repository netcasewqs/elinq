using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLite.Data.Test.Primitive.Model;
using NUnit.Framework;
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestInitialize = NUnit.Framework.SetUpAttribute;
using TestMethod = NUnit.Framework.TestAttribute;
using NLite.Collections;
using System.Linq.Expressions;
using System.Globalization;
using System.Data.OleDb;
using System.Data.Common;
using System.Data.SqlClient;
using NLite.Data.Mapping;
using System.Collections;

namespace NLite.Data.Test.Where
{
    [TestClass]
    public class LinqTest : TestBase<NullableTypeInfo>
    {
        protected override string ConnectionStringName
        {
            get
            {
                return "NumericDB";
            }
        }
        internal virtual void LinqAdd()
        {
            Table.Insert(new NullableTypeInfo { Int32 = 123, String = "LinqTest" });
            Table.Insert(new NullableTypeInfo { Int32 = 123, String = "OK" });
        }
        internal virtual void LinqDelete()
        {
            Table.Delete(p => true);
        }
        [TestMethod]
        //还有1个重载
        public virtual void ClientAggregate1()
        {
            LinqDelete();
            LinqAdd();
            var actual = Table.Select(p => p.Int32).Aggregate((sum, e) => sum + e);

            LinqDelete();
            Assert.AreEqual(246, actual.Value);
        }

        [TestMethod]
        public virtual void ClientAggregate2()
        {
            LinqAdd();
            var actual = Table.Select(p => p).Aggregate<NullableTypeInfo, int>(0, (sum, e) => sum + e.Int32.Value);
            LinqDelete();
            Assert.AreEqual(246, actual);
        }

        [TestMethod]
        public virtual void ClientAggregate3()
        {
            LinqAdd();
            var actual = Table.Select(p => p.Int32).Aggregate(0, (sum, e) => sum + (int)e);
            LinqDelete();
            Assert.AreEqual(246, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public virtual void ServerAggregate2()
        {
            LinqDelete();
            LinqAdd();
            var actual = Table.Aggregate<NullableTypeInfo, int>(0, (sum, e) => sum + e.Int32.Value);
            LinqDelete();
            Assert.AreEqual(246, actual);
        }
        [TestMethod]
        public virtual void ServerAll()
        {
            LinqDelete();
            LinqAdd();
            var item = Table.All(p => p.Boolean == null);
            Assert.IsTrue(item);
            LinqDelete();
        }
        [TestMethod]
        public virtual void ServerAny1()
        {
            LinqDelete();
            LinqAdd();
            var item = Table.Any();
            Assert.IsTrue(item);
            LinqDelete();
        }
        [TestMethod]
        public virtual void ServerAny2()
        {
            LinqDelete();
            LinqAdd();
            var item = Table.Any(p => p.Boolean == null);
            Assert.IsTrue(item);
            LinqDelete();
        }
        [TestMethod]
        public virtual void AsQueryable()
        {
        }
        [TestMethod]
        public virtual void ServerAverage1()
        {
            LinqDelete();
            LinqAdd();
            var item = Table.Average(p => p.Decimal);
            Assert.IsNull(item);
            LinqDelete();
        }
        [TestMethod]
        public virtual void ServerAverage2()
        {
            LinqDelete();
            LinqAdd();
            var item = Table.Average(p => p.Double);
            Assert.IsNull(item);
            LinqDelete();
        }
        [TestMethod]
        public virtual void ServerAverage3()
        {
            LinqDelete();
            LinqAdd();
            var item = Table.Average(p => p.Single);
            Assert.IsNull(item);
            LinqDelete();
        }
        [TestMethod]
        public virtual void ServerAverage4()
        {
            LinqDelete();
            LinqAdd();
            var item = Table.Average(p => p.Int32);
            Assert.IsNotNull(item);
            LinqDelete();
        }
        [TestMethod]
        public virtual void ServerAverage5()
        {
            LinqDelete();
            LinqAdd();
            var item = Table.Average(p => p.Int64);
            Assert.IsNull(item);
            LinqDelete();
        }
        [TestMethod]
        public virtual void ServerCast()
        {
            LinqDelete();
            LinqAdd();
            var item = Table.Select(p => p.Int32).Cast<string>();
            Assert.IsNotNull(item);
            LinqDelete();
        }
        [TestMethod]
        public virtual void ServerConcat()
        {
            //LinqDelete();
            //LinqAdd();
            //var itemInt = "zxm".AsEnumerable();
            //var item = Table.Select(p => p.String).Concat<string>(itemInt);
            //Assert.IsNotNull(item);
            //LinqDelete();
        }
        [TestMethod]
        public virtual void ServerContains1()
        {
            LinqDelete();
            LinqAdd();
            var item = Table.Select(p => p.String).Contains("zxm");
            Assert.IsFalse(item);
            LinqDelete();
        }
        [TestMethod]
        public virtual void ServerCount1()
        {
            LinqDelete();
            LinqAdd();
            var item = Table.Count();
            Assert.IsNotNull(item);
            LinqDelete();
        }
        [TestMethod]
        public virtual void ServerCount2()
        {
            LinqDelete();
            LinqAdd();
            var item = Table.Count(p => p.String == "OK");
            Assert.IsNotNull(item);
            LinqDelete();
        }
        [TestMethod]
        public virtual void DefaultIfEmpty1()
        {
            LinqDelete();
            LinqAdd();
            var item = Table.DefaultIfEmpty();
            Assert.IsNotNull(item);
            LinqDelete();
        }
        [TestMethod]
        public virtual void DefaultIfEmpty2()
        {
            NullableTypeInfo flag = new NullableTypeInfo();
            flag.String = "OK";
            LinqDelete();
            LinqAdd();
            var item = Table.DefaultIfEmpty(flag);
            Assert.IsNotNull(item);
            LinqDelete();
        }
        [TestMethod]
        public virtual void ServerDistinct1()
        {
            LinqDelete();
            LinqAdd();
            var item = Table.Distinct().Count();
            Assert.IsNotNull(item);
            LinqDelete();
        }
        [TestMethod]
        public virtual void ClientElementAt1()
        {
            LinqDelete();
            LinqAdd();
            var item = Table.Select(p => p).ElementAt(0);
            Assert.IsNotNull(item);
            Console.WriteLine(item.String);
            LinqDelete();
        }
        [TestMethod]
        public virtual void ClientElementAtOrDefault()
        {
            LinqDelete();
            LinqAdd();
            var item = Table.Select(p => p).ElementAtOrDefault(0);
            Assert.IsNotNull(item);
            Console.WriteLine(item.String);
            LinqDelete();
        }
        [TestMethod]
        public virtual void Except()
        {
            //List<int> flag = new List<int> { 1,2,3,123};
            //LinqDelete();
            //LinqAdd();
            //var item = Table.Select(p=>p.Int32).Except(;
            //Assert.IsNotNull(item);
            //Console.WriteLine(item.String);
            //LinqDelete();
        }
        [TestMethod]
        public virtual void ServerFirst1()
        {
            LinqDelete();
            LinqAdd();
            var item = Table.First();
            Assert.IsNotNull(item);
            Console.WriteLine(item.String);
            LinqDelete();
        }
        [TestMethod]
        public virtual void ServerFirst2()
        {
            LinqDelete();
            LinqAdd();
            var item = Table.First(p => p.String == "OK");
            Assert.IsNotNull(item);
            Console.WriteLine(item.String);
            LinqDelete();
        }
        [TestMethod]
        public virtual void ServerFirstOrDefault1()
        {
            LinqDelete();
            LinqAdd();
            var item = Table.FirstOrDefault();
            Assert.IsNotNull(item);
            Console.WriteLine(item.String);
            LinqDelete();
        }
        [TestMethod]
        public virtual void ServerFirstOrDefault2()
        {
            LinqDelete();
            LinqAdd();
            var item = Table.FirstOrDefault(p => p.String == "OK");
            Assert.IsNotNull(item);
            Console.WriteLine(item.String);
            LinqDelete();
        }
        [TestMethod]
        public virtual void GetSourceExpression()
        {
            //LinqDelete();
            //LinqAdd();
            //var item = ;
            //Assert.IsNotNull(item);
            //Console.WriteLine(item.String);
            //LinqDelete();
        }
        [TestMethod]
        public virtual void GroupBy1()
        {
            LinqDelete();
            LinqAdd();
            LinqAdd();
            var item = Table.Select(p => p).GroupBy(p => p.String);
            Assert.IsNotNull(item);
            Console.WriteLine(item.Count());
            LinqDelete();
        }
        [TestMethod]
        public virtual void GroupJoin()
        {
            //LinqDelete();
            //LinqAdd();
            //LinqAdd();
            //var item = Table.Select(p => p).GroupJoin(
            //Assert.IsNotNull(item);
            //Console.WriteLine(item.Count());
            //LinqDelete();
        }
        [TestMethod]
        public virtual void ServerIntersect1()
        {
            LinqDelete();
            LinqAdd();
            var item1 = Table.Select(p => p.Int32).Where(a => a > 122);
            var item2 = Table.Select(p => p.Int32).Intersect(item1);
            Assert.IsNotNull(item2);
            Console.WriteLine(item2.Count());
            LinqDelete();
        }
        [TestMethod]
        public virtual void ServerIntersect2()
        {
            //LinqDelete();
            //LinqAdd();
            //var item1 = Table.Select(p => p.Int32).Where(a => a > 122);
            //var item2 = Table.Select(p => p.Int32).Intersect(item1,);
            //Assert.IsNotNull(item2);
            //Console.WriteLine(item2.Count());
            //LinqDelete();
        }
        [TestMethod]
        public virtual void Join()
        {
            LinqDelete();
            LinqAdd();
            var t = Table.Select(p=>p);
            var item = Table.Select(p =>p).Join<NullableTypeInfo,NullableTypeInfo, bool, int?>(t, p => p.String == "OK", c => c.String=="LinqTest",(a,b)=>a.Int32+b.Int32);
            Assert.IsNotNull(item);
            Console.WriteLine(item.FirstOrDefault());
            LinqDelete();
        }
        [TestMethod]
        public virtual void ServerLast1()
        {
            LinqDelete();
            LinqAdd();
            var q = Table.OrderBy(p => p.String);
            var last = q.Reverse().First();
            var first = q.First();
            Assert.IsNotNull(last);
            Console.WriteLine(last.String);
            LinqDelete();
        }
        [TestMethod]
        public virtual void ServerLast2()
        {
            LinqDelete();
            LinqAdd();
            var item = Table.Last(p => p.Int32 > 122);
            Assert.IsNotNull(item);
            Console.WriteLine(item.String);
            LinqDelete();
        }
        [TestMethod]
        public virtual void ServerLastOrDefault1()
        {
            LinqDelete();
            LinqAdd();
            var item = Table.LastOrDefault();
            Assert.IsNotNull(item);
            Console.WriteLine(item.String);
            LinqDelete();
        }
        [TestMethod]
        public virtual void ServerLastOrDefault2()
        {
            LinqDelete();
            LinqAdd();
            var item = Table.LastOrDefault(p => p.Int32 >= 122);
            Assert.IsNotNull(item);
            Console.WriteLine(item.String);
            LinqDelete();
        }
        [TestMethod]
        //SELECT COUNT(*)
        public virtual void ServerLongCount1()
        {
            LinqDelete();
            LinqAdd();
            var item = Table.LongCount();
            Assert.IsNotNull(item);
            Console.WriteLine(item);
            LinqDelete();
        }
        [TestMethod]
        //SELECT COUNT(*)
        public virtual void ServerLongCount2()
        {
            LinqDelete();
            LinqAdd();
            var item = Table.LongCount(p => p.Int32 >= 122);
            Assert.IsNotNull(item);
            Console.WriteLine(item);
            LinqDelete();
        }
        [TestMethod]
        //SELECT MAX(t0.Int32)
        public virtual void ServerMax1()
        {
            LinqDelete();
            LinqAdd();
            var item = Table.Select(p => p.Int32).Max();
            Assert.IsNotNull(item);
            Console.WriteLine(item);
            LinqDelete();
        }
        [TestMethod]
        //MAX(CASE WHEN ((t0.Int32 <= 123)) THEN 1 ELSE 0 END)
        public virtual void ServerMax2()
        {
            LinqDelete();
            LinqAdd();
            var item = Table.Max(p => p.Int32 <= 123);
            Assert.IsNotNull(item);
            Console.WriteLine(item);
            LinqDelete();
        }
        [TestMethod]
        //SELECT MAX((t0.Int32 + 123))
        public virtual void ServerMax3()
        {
            LinqDelete();
            LinqAdd();
            var item = Table.Max(p => p.Int32 + 123);
            Assert.IsNotNull(item);
            Console.WriteLine(item);
            LinqDelete();
        }
        [TestMethod]//还有3个重载


        public virtual void ServerMax4()
        {
            LinqDelete();
            LinqAdd();
            var item = Table.Max(p => Convert.ToInt64(p.Int32));
            Assert.IsNotNull(item);
            Console.WriteLine(item);
            LinqDelete();
        }
        [TestMethod]
        //SELECT MIN(t0.Int32)
        public virtual void ServerMin1()
        {
            LinqDelete();
            LinqAdd();
            var item = Table.Select(p => p.Int32).Min();
            Assert.IsNotNull(item);
            Console.WriteLine(item);
            LinqDelete();
        }
        [TestMethod]
        //SELECT MIN(CASE WHEN ((t0.Int32 >= 122)) THEN 1 ELSE 0 END)
        public virtual void ServerMin2()
        {
            LinqDelete();
            LinqAdd();
            var item = Table.Min(p => p.Int32 >= 122);
            Assert.IsNotNull(item);
            Console.WriteLine(item);
            LinqDelete();
        }
        [TestMethod]//还有4个重载
        //SELECT MIN((t0.Int32 - 12))
        public virtual void ServerMin3()
        {
            LinqDelete();
            LinqAdd();
            var item = Table.Min(p => p.Int32 - 12);
            Assert.IsNotNull(item);
            Console.WriteLine(item);
            LinqDelete();
        }
        [TestMethod]
        //Query(NLite.Data.Test.Primitive.Model.NullableTypeInfo).OfType()
        public virtual void ServerOfType()
        {
            LinqDelete();
            LinqAdd();
            var item = Table.OfType<int>();
            Assert.IsNotNull(item);
            Console.WriteLine(item);
            LinqDelete();
        }
        [TestMethod]//orderby 默认升序
        //ORDER BY t0.[String]
        public virtual void ServerOrderBy1()
        {
            LinqDelete();
            LinqAdd();
            var item = Table.OrderBy(p => p.String).First();
            Assert.IsNotNull(item);
            Console.WriteLine(item.String);
            LinqDelete();
        }
        [TestMethod]
        //ORDER BY t0.[String] DESC
        public virtual void ServerOrderBy2()
        {
            LinqDelete();
            LinqAdd();
            var item = Table.OrderBy("String", SortOrder.Descending).First();
            Assert.IsNotNull(item);
            Console.WriteLine(item.String);
            LinqDelete();
        }
        [TestMethod]
        //还有2个重载
        public virtual void ServerOrderBy3()
        {
            //LinqDelete();
            //LinqAdd();
            //var item = Table.OrderBy(
            //Assert.IsNotNull(item);
            //Console.WriteLine(item.String);
            //LinqDelete();
        }
        [TestMethod]
        //ORDER BY t0.[String] DESC
        public virtual void ServerOrderByDescending1()
        {
            LinqDelete();
            LinqAdd();
            var item = Table.OrderByDescending(p => p.String).First();
            Assert.IsNotNull(item);
            Console.WriteLine(item.String);
            LinqDelete();
        }
        [TestMethod]
        public virtual void ServerOrderByDescending2()
        {
            //LinqDelete();
            //LinqAdd();
            //var item = Table.OrderByDescending(p => p.String, CompareOptions.Ordinal);
            //Assert.IsNotNull(item);
            //Console.WriteLine(item.String);
            //LinqDelete();
        }
        [TestMethod]
        public virtual void ClientReverse()
        {
            LinqDelete();
            LinqAdd();
            var item = Table.Select(p => p.String).Reverse();
            Assert.IsNotNull(item);
            //Console.WriteLine(item.First());
            LinqDelete();
        }
        [TestMethod]
        public virtual void Select1()
        {
            LinqDelete();
            LinqAdd();
            var item = Table.Select((p, a) => p.Int32 + 2);
            Assert.IsNotNull(item);
            //Console.WriteLine(item.First());
            LinqDelete();
        }
        [TestMethod]
        public virtual void Select2()
        {
            LinqDelete();
            LinqAdd();
            var item = Table.Select(p => p.String);
            Assert.IsNotNull(item);
            //Console.WriteLine(item.First());
            LinqDelete();
        }
        [TestMethod]
        public virtual void SelectConcat()
        {
            LinqDelete();
            LinqAdd();
            var str = "LinqTest";
            var expected = string.Concat(str, "zxm");
            var actual = Table.Select(p => string.Concat(p.String, "zxm")).FirstOrDefault();
            Assert.AreEqual(expected, actual);

            var item = Table.Where(p => string.Concat(p.String, "zxm") == expected).FirstOrDefault();
            Assert.IsNotNull(item);
            LinqDelete();
        }
        [TestMethod]
        public virtual void SelectLength()
        {
            LinqDelete();
            LinqAdd();
            var str = "LinqTest";
            var expected = str.Length;
            var actual = Table.Select(p => p.String.Length).FirstOrDefault();
            Assert.AreEqual(expected, actual);

            var item = Table.Where(p => p.String.Length == expected).FirstOrDefault();
            Assert.IsNotNull(item);
            LinqDelete();
        }
        //sql.cs修改
        [TestMethod]
        public virtual void SelectLengthIndex()
        {
            LinqDelete();
            LinqAdd();
            string str = "LinqTest";
            var expected = str[7];
            var actual = Table.Select(p => p.String[7]).FirstOrDefault();
            Assert.AreEqual(expected, actual);
            //var item = Table.Where(p =>p.String[7] == expected).FirstOrDefault();
            //Assert.IsNotNull(item);
            LinqDelete();
        }
        //changed
        [TestMethod]
        public virtual void SelectInsert()
        {
            LinqDelete();
            LinqAdd();
            string str = "LinqTest";
            var expected = str.Insert(0,"zxm");
            var actual = Table.Select(p => p.String.Insert(0, "zxm")).FirstOrDefault();
            Assert.AreEqual(expected, actual);
            
            var item = Table.Where(p => p.String.Insert(0, "zxm") == expected).FirstOrDefault();
            Assert.IsNotNull(item);
            LinqDelete();
        }
        //sql.cs修改
        [TestMethod]
        public virtual void SelectRemove1()
        {
            string str = "LinqTest";
            var expected = str.Remove(2);
            LinqDelete();
            LinqAdd();
            var actual = Table.Select(p => p.String.Remove(2)).FirstOrDefault();
            Assert.AreEqual(expected, actual);
            var item = Table.Where(p => p.String.Remove(2) == expected).FirstOrDefault();
            Assert.IsNotNull(item);
            LinqDelete();
        }
        //sql.cs修改
        [TestMethod]
        public virtual void SelectRemove2()
        {
            LinqDelete();
            LinqAdd();
            string str = "LinqTest";
            var expected = str.Remove(2, 3);
            var actual = Table.Select(p => p.String.Remove(2, 3)).FirstOrDefault();
            Assert.AreEqual(expected, actual);
            var item = Table.Where(p => p.String.Remove(2, 3) == expected).FirstOrDefault();
            Assert.IsNotNull(item);
            LinqDelete();
        }
        [TestMethod]
        public virtual void SelectPadLeft1()
        {
            LinqDelete();
            LinqAdd();
            string str = "LinqTest";
            var expected = str.PadLeft(9);
            var actual = Table.Select(p => p.String.PadLeft(9)).FirstOrDefault();
            Assert.AreEqual(expected, actual);
            var item = Table.Where(p => p.String.PadLeft(9) ==expected);
            Assert.IsNotNull(item);
            LinqDelete();
        }
        [TestMethod]
        public virtual void SelectPadLeft2()
        {
            LinqDelete();
            LinqAdd();
            string str = "LinqTest";
            var expected = str.PadLeft(9, 'z');
            var actual = Table.Select(p =>p.String.PadLeft(9, 'z')).FirstOrDefault();
            Assert.AreEqual(expected, actual);
            var item = Table.Where(p => p.String.PadLeft(9) == expected);
            Assert.IsNotNull(item);
            LinqDelete();
        }
        [TestMethod]
        public virtual void SelectPadRight1()
        {
            LinqDelete();
            LinqAdd();
            string str = "LinqTest";
            var expected = str.PadRight(9);
            var actual = Table.Select(p =>  p.String.PadRight(9)).FirstOrDefault();
            Assert.AreEqual(expected, actual);
            var item = Table.Where(p => p.String.PadLeft(9) == expected);
            Assert.IsNotNull(item);
            LinqDelete();
        }
        [TestMethod]
        public virtual void SelectPadRight2()
        {
            LinqDelete();
            LinqAdd();
            string str = "LinqTest";
            var expected = str.PadRight(9,'z');
            var actual = Table.Select(p =>p.String.PadRight(9,'z')).FirstOrDefault();
            Assert.AreEqual(expected, actual);
            var item = Table.Where(p => p.String.PadLeft(9) ==expected);
            Assert.IsNotNull(item);
            LinqDelete();
        }
        [TestMethod]
        public virtual void SelectReplace1()
        {
            LinqDelete();
            LinqAdd();
            string str = "LinqTest";
            var expected = str.Replace("Linq","ELinq");
            var actual = Table.Select(p => p.String.Replace("Linq", "ELinq")).FirstOrDefault();
            Assert.AreEqual(expected, actual);
            var item = Table.Where(p => p.String.Replace("Linq","ELinq") == expected);
            Assert.IsNotNull(item);
            LinqDelete();
        }
        [TestMethod]
        public virtual void SelectReplace2()
        {
            LinqDelete();
            LinqAdd();
            string str = "LinqTest";
            var expected = str.Replace('T','B');
            var actual = Table.Select(p => p.String.Replace('T', 'B')).FirstOrDefault();
            Assert.AreEqual(expected, actual);
            var item = Table.Where(p => p.String.Replace('T', 'B') == expected);
            Assert.IsNotNull(item);
            LinqDelete();
        }
        [TestMethod]
        public virtual void SelectTrim()
        {
            LinqDelete();      
            string str = " Linq Test ";
            Table.Insert(new NullableTypeInfo{String=str});
            var expected = str.Trim();
            var actual = Table.Select(p => p.String.Trim()).FirstOrDefault();
            Assert.AreEqual(expected, actual);
            var item = Table.Where(p => p.String.Trim() == expected);
            Assert.IsNotNull(item);
            LinqDelete();
        }
        [TestMethod]
        public virtual void SelectTrimEnd()
        {
            LinqDelete();
            string str = " Linq Test ";
            Table.Insert(new NullableTypeInfo { String = str });
            var expected = str.TrimEnd();
            var actual = Table.Select(p => p.String.TrimEnd()).FirstOrDefault();
            Assert.AreEqual(expected, actual);
            var item = Table.Where(p => p.String.TrimEnd() == expected);
            Assert.IsNotNull(item);
            LinqDelete();
        }
        [TestMethod]
        public virtual void SelectTrimStart()
        {
            LinqDelete();
            string str = " Linq Test ";
            Table.Insert(new NullableTypeInfo { String = str });
            var expected = str.TrimStart();
            var actual = Table.Select(p => p.String.TrimStart()).FirstOrDefault();
            Assert.AreEqual(expected, actual);
            var item = Table.Where(p => p.String.TrimStart() == expected);
            Assert.IsNotNull(item);
            LinqDelete();
        }
        [TestMethod]
        public virtual void SelectToLower()
        {
            LinqDelete();
            LinqAdd();
            string str = "LinqTest";
            var expected = str.ToLower();
            var actual = Table.Select(p => p.String.ToLower()).FirstOrDefault();
            Assert.AreEqual(expected, actual);
            var item = Table.Where(p => p.String.ToLower() == expected);
            Assert.IsNotNull(item);
            LinqDelete();
        }
        [TestMethod]
        public virtual void SelectToUpper()
        {
            LinqDelete();
            LinqAdd();
            string str = "LinqTest";
            var expected = str.ToUpper();
            var actual = Table.Select(p => p.String.ToUpper()).FirstOrDefault();
            Assert.AreEqual(expected, actual);
            var item = Table.Where(p => p.String.ToUpper() == expected);
            Assert.IsNotNull(item);
            LinqDelete();
        }
        [TestMethod]
        public virtual void SelectReverse()
        {
            LinqDelete();
            LinqAdd();
            string str = "LinqTest";
            var expected = str.Reverse();
            var actual = Table.Select(p => p.String.Reverse()).FirstOrDefault();
            Assert.AreEqual(expected, actual);
            var item = Table.Where(p => p.String.Reverse() == expected);
            Assert.IsNotNull(item);
            LinqDelete();
        }
        [TestMethod]
        public virtual void SelectIsNullOrEmpty()
        {
            LinqDelete();
            LinqAdd();
            string str = "LinqTest";
            var expected = string.IsNullOrEmpty(str);
            var actual = Table.Select(p => string.IsNullOrEmpty(p.String)).FirstOrDefault();
            Assert.AreEqual(expected, actual);
            var item = Table.Where(p => string.IsNullOrEmpty(p.String) == expected);
            Assert.IsNotNull(item);
            LinqDelete();
        }
        [TestMethod]
        public virtual void SelectCompareOrdinal1()
        {
            LinqDelete();
            LinqAdd();
            string str = "LinqTest";
            var expected = string.CompareOrdinal(str, "TestLinq")<0?true:false;//-8
            //-1
            var actual = Table.Select(p =>string.CompareOrdinal(p.String, "TestLinq")<0?true:false).FirstOrDefault();
            Assert.AreEqual(expected, actual);
            var item= Table.Where(p => (string.CompareOrdinal(p.String, "TestLinq")<0?true:false) == expected);
            Assert.IsNotNull(item);
            LinqDelete();
        }
        [TestMethod]
        public virtual void SelectCompareOrdinal2()
        {
            LinqDelete();
            LinqAdd();
            string str = "LinqTest";
            var expected = string.CompareOrdinal(str, "TestLinq") < 0 ? true : false;//-8
            var actual = Table.Select(p => string.CompareOrdinal(p.String, 2, "TestLinq", 2, 1) < 0 ? true : false).FirstOrDefault();
            Assert.AreEqual(expected, actual);
            var item = Table.Where(p => (string.CompareOrdinal(p.String, 2, "TestLinq", 2, 2) < 0 ? true : false) == expected);
            Assert.IsNotNull(item);
            LinqDelete();
        }
        [TestMethod]
        public virtual void SelectCompare1()
        {
            LinqDelete();
            LinqAdd();
            string str = "LinqTest";
            var expected = string.Compare(str, 2, "TestLinq", 2, 1) < 0 ? true : false;
            var actual = Table.Select(p => string.Compare(p.String, 2, "TestLinq", 2, 1) < 0 ? true : false).FirstOrDefault();
            Assert.AreEqual(expected,actual);
            var item = Table.Where(p => (string.Compare(p.String, 2, "TestLinq", 2, 1)<0?true:false) ==expected);
            Assert.IsNotNull(item);
            LinqDelete();
        }
        [TestMethod]
        public virtual void SelectCompare2()
        {
            LinqDelete();
            LinqAdd();
            string str = "LinqTest";
            var expected = string.Compare(str, 7, "TestLinq", 4, 1,false) < 0 ? true : false;
            var actual = Table.Select(p => string.Compare(p.String, 7, "TestLinq", 4, 1, false) < 0 ? true : false).First();
            Assert.AreEqual(expected, actual);
            var item = Table.Where(p => (string.Compare(p.String, 7, "TestLinq", 4, 1, false) < 0 ? true : false) == expected);
            Assert.IsNotNull(item);
            LinqDelete();
        }
        [TestMethod]
        public virtual void SelectCompare3()
        {
            LinqDelete();
            LinqAdd();
            string str = "LinqTest";
            var expected = string.Compare(str,"TestLinq") < 0 ? true : false;
            var actual = Table.Select(p =>string.Compare(p.String, "TestLinq")<0?true:false).FirstOrDefault();
            Assert.AreEqual(expected, actual);
            var item = Table.Where(p => string.Compare(p.String, "TestLinq")<0?true:false == expected);
            Assert.IsNotNull(item);
            LinqDelete();
        }
        [TestMethod]
        public virtual void SelectCompare4()
        {
            LinqDelete();
            LinqAdd();
            string str = "LinqTest";
            var expected = string.Compare(str, "TestLinq",false) < 0 ? true : false;
            var actual = Table.Select(p => string.Compare(p.String, "TestLinq", false) < 0 ? true : false).FirstOrDefault();
            Assert.AreEqual(expected, actual);
            var item = Table.Where(p => string.Compare(p.String, "TestLinq", false)<0?true:false == expected);
            Assert.IsNotNull(item);
            LinqDelete();
        }
        [TestMethod]
        public virtual void SelectCompareTo()
        {
            LinqDelete();
            LinqAdd();
            string str = "LinqTest";
            var expected = str.CompareTo("TestLinq")<0?true:false;
            var actual = Table.Select(p =>p.String.CompareTo("TestLinq")<0?true:false).FirstOrDefault();
            Assert.AreEqual(expected, actual);
            var item = Table.Select(p => p.String.CompareTo("TestLinq")<0?true:false ==expected);
            Assert.IsNotNull(item);
            LinqDelete();
        }
        [TestMethod]
        public virtual void SelectEquals1()
        {
            LinqDelete();
            LinqAdd();
            string str = "LinqTest";
            var expected = str.Equals("linqtest",StringComparison.CurrentCultureIgnoreCase);
            var actual = Table.Select(p => p.String.Equals("linqtest", StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            Assert.AreEqual(expected, actual);
            var item = Table.Select(p => p.String.Equals("linqtest", StringComparison.CurrentCultureIgnoreCase));
            Assert.IsNotNull(item);
            LinqDelete();
        }
        [TestMethod]
        public virtual void SelectEquals2()
        {
            LinqDelete();
            LinqAdd();
            string str = "LinqTest";
            var expected =string.Equals(str,"linqtest", StringComparison.CurrentCultureIgnoreCase);
            var actual = Table.Select(p => string.Equals(p.String,"linqtest", StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            Assert.AreEqual(expected, actual);
            var item = Table.Select(p =>string.Equals(p.String,"linqtest", StringComparison.CurrentCultureIgnoreCase));
            Assert.IsNotNull(item);
            LinqDelete();
        }
        //Like --changed by Qingsong
        [TestMethod]
        public virtual void SelectContains1()
        {
            LinqDelete();
            LinqAdd();
            var str = "LinqTest";
            var expected = str.Contains('q');
            var actual = Table.Select(p => p.String .Contains('q')).FirstOrDefault();
            Assert.AreEqual(expected, actual);

           // var item = Table.Where(p => p.String.Contains('q') == expected).FirstOrDefault();
           // Assert.IsNotNull(item);
            LinqDelete();
        }
        [TestMethod]
        public virtual void SelectContains2()
        {
            LinqDelete();
            LinqAdd();
            var str = "LinqTest";
            var expected = str.Contains("q");
            var actual = Table.Select(p => p.String.Contains("q")).FirstOrDefault();
            Assert.AreEqual(expected, actual);

            // var item = Table.Where(p => p.String.Contains("q") == expected).FirstOrDefault();
            // Assert.IsNotNull(item);
            LinqDelete();
        }
        [TestMethod]
        public virtual void SelectStartsWith1()
        {
            LinqDelete();
            LinqAdd();
            var str = "LinqTest";
            var expected = str.StartsWith("L");
            var actual = Table.Select(p => p.String.StartsWith("L")).FirstOrDefault();
            Assert.AreEqual(expected, actual);

            // var item = Table.Where(p => p.String.StartsWith("L") == expected).FirstOrDefault();
            // Assert.IsNotNull(item);
            LinqDelete();
        }
        [TestMethod]
        public virtual void SelectStartsWith2()
        {
            LinqDelete();
            LinqAdd();
            var str = "LinqTest";
            var expected = str.StartsWith("L",true,null);
            var actual = Table.Select(p => p.String.StartsWith("L",true,null)).FirstOrDefault();
            Assert.AreEqual(expected, actual);

            // var item = Table.Where(p => p.String.StartsWith("L") == expected).FirstOrDefault();
            // Assert.IsNotNull(item);
            LinqDelete();
        }
        [TestMethod]
        public virtual void SelectStartsWith3()
        {
            LinqDelete();
            LinqAdd();
            var str = "LinqTest";
            var expected = str.StartsWith("L",StringComparison.Ordinal);
            var actual = Table.Select(p => p.String.StartsWith("L", true, null)).FirstOrDefault();
            Assert.AreEqual(expected, actual);

            // var item = Table.Where(p => p.String.StartsWith("L") == expected).FirstOrDefault();
            // Assert.IsNotNull(item);
            LinqDelete();
        }
        [TestMethod]
        public virtual void SelectEndsWith1()
        {
            LinqDelete();
            LinqAdd();
            var str = "LinqTest";
            var expected = str.EndsWith("t");
            var actual = Table.Select(p => p.String.EndsWith("t")).FirstOrDefault();
            Assert.AreEqual(expected, actual);

            // var item = Table.Where(p => p.String.EndsWith("t") == expected).FirstOrDefault();
            // Assert.IsNotNull(item);
            LinqDelete();
        }
        [TestMethod]
        public virtual void SelectEndsWith2()
        {
            LinqDelete();
            LinqAdd();
            var str = "LinqTest";
            var expected = str.EndsWith("t",true,null);
            var actual = Table.Select(p => p.String.EndsWith("t",true,null)).FirstOrDefault();
            Assert.AreEqual(expected, actual);

            // var item = Table.Where(p => EndsWith("t",true,null) == expected).FirstOrDefault();
            // Assert.IsNotNull(item);
            LinqDelete();
        }
        [TestMethod]
        public virtual void SelectEndsWith3()
        {
            LinqDelete();
            LinqAdd();
            var str = "LinqTest";
            var expected = str.EndsWith("t");
            var actual = Table.Select(p => p.String.EndsWith("t",StringComparison.Ordinal)).FirstOrDefault();
            Assert.AreEqual(expected, actual);

            // var item = Table.Where(p => p.String.EndsWith("t",StringComparison.Ordinal) == expected).FirstOrDefault();
            // Assert.IsNotNull(item);
            LinqDelete();
        }
        //changed
        [TestMethod]
        public virtual void SelectSubstring1()
        {
            LinqDelete();
            LinqAdd();
            var str = "LinqTest";
            var expected = str.Substring(2);
            var actual = Table.Select(p => p.String.Substring(2)).FirstOrDefault();
            Assert.AreEqual(expected, actual);
            var item = Table.Where(p => p.String.Substring(2) == expected).FirstOrDefault();
            Assert.IsNotNull(item);
            LinqDelete();
        }
        //changed(model)
        [TestMethod]
        public virtual void SelectSubstring2()
        {
            LinqDelete();
            LinqAdd();
            var str = "LinqTest";
            var expected = str.Substring(2, 3);
            var actual = Table.Select(p => p.String.Substring(2, 3)).FirstOrDefault();
            Assert.AreEqual(expected, actual);

            var item = Table.Where(p => p.String.Substring(2, 3) == expected).FirstOrDefault();
            Assert.IsNotNull(item);
            LinqDelete();
        }
        [TestMethod]
        public virtual void SelectIndexOf1()
        {
            string str = "LinqTest";
            LinqDelete();
            LinqAdd();
            var expected = str.IndexOf("nq");
            var actual = Table.Select(p => p.String.IndexOf("nq")).First();
            Assert.AreEqual(expected, actual);

            var item = Table.Where(p => p.String.IndexOf("nq") == expected);
            Assert.IsNotNull(item);
            LinqDelete();
        }
        //changed
        [TestMethod]
        public virtual void SelectIndexOf2()
        {
            string str = "LinqTest";
            LinqDelete();
            LinqAdd();
            var expected = str.IndexOf("nq", 2);
            var actual = Table.Select(p => p.String.IndexOf("nq",2)).First();
            Assert.AreEqual(expected, actual);

            var item = Table.Where(p => p.String.IndexOf("nq",2) == expected);
            Assert.IsNotNull(item);
            LinqDelete();
        }
        //changed
        [TestMethod]
        public virtual void SelectIndexOf3()
        {
            string str = "LinqTest";
            var expected = str.IndexOf("Te", 1, 5);
            LinqDelete();
            LinqAdd();
            var actual = Table.Select(p =>p.String.IndexOf("Te", 1,5)).First();
            Assert.AreEqual(expected, actual);

            var item = Table.Where(p => p.String.IndexOf("Te", 1, 5) == expected);
            Assert.IsNotNull(item);
            LinqDelete();
        }
        [TestMethod]
        public virtual void SelectIndexOf4()
        {
            string str = "LinqTest";
            var expected = str.IndexOf("Te", 1, 5, StringComparison.Ordinal);
            LinqDelete();
            LinqAdd();
            var actual = Table.Select(p =>p.String.IndexOf("Te", 1, 5, StringComparison.Ordinal)).First();
            Assert.AreEqual(expected,actual);
            var item = Table.Where(p => p.String.IndexOf("Te", 1, 5, StringComparison.Ordinal) == expected);
            Assert.IsNotNull(item);
            LinqDelete();
        }
        [TestMethod]
        public virtual void SelectIndexOf5()
        {
            string str = "LinqTest";
            var expected = str.IndexOf("Te", StringComparison.Ordinal);
            LinqDelete();
            LinqAdd();
            var actual = Table.Select(p => p.String.IndexOf("Te",StringComparison.Ordinal)).First();
            Assert.AreEqual(expected, actual);
            var item = Table.Where(p => p.String.IndexOf("Te",StringComparison.Ordinal) == expected);
            Assert.IsNotNull(item);
            LinqDelete();
        }
        [TestMethod]
        public virtual void SelectIndexOf6()
        {
            string str = "LinqTest";
            var expected = str.IndexOf("st", 6,StringComparison.Ordinal);
            LinqDelete();
            LinqAdd();
            var actual = Table.Select(p => p.String.IndexOf("st", 6, StringComparison.Ordinal)).First();
            Assert.AreEqual(expected, actual);
            var item = Table.Where(p => p.String.IndexOf("st", 6, StringComparison.Ordinal) == expected);
            Assert.IsNotNull(item);
            LinqDelete();
        }
        [TestMethod]
        public virtual void SelectIndexOf7()
        {
            string str = "LinqTest";
            var expected = str.IndexOf('T');
            LinqDelete();
            LinqAdd();
            var actual = Table.Select(p => p.String.IndexOf('T')).First();
            Assert.AreEqual(expected, actual);
            var item = Table.Where(p => p.String.IndexOf('T') == expected);
            Assert.IsNotNull(item);
            LinqDelete();
        }
        [TestMethod]
        public virtual void SelectIndexOf8()
        {
            string str = "LinqTest";
            var expected = str.IndexOf('t',7);
            LinqDelete();
            LinqAdd();
            var actual = Table.Select(p => p.String.IndexOf('t', 7)).First();
            Assert.AreEqual(expected, actual);
            var item = Table.Where(p => p.String.IndexOf('t', 7) == expected);
            Assert.IsNotNull(item);
            LinqDelete();
        }
        [TestMethod]
        public virtual void SelectIndexOf9()
        {
            string str = "LinqTest";
            var expected = str.IndexOf('s', 6,1);
            LinqDelete();
            LinqAdd();
            var actual = Table.Select(p => p.String.IndexOf('s', 6, 1)).First();
            Assert.AreEqual(expected, actual);
            var item = Table.Where(p => p.String.IndexOf('s', 6, 1) == expected);
            Assert.IsNotNull(item);
            LinqDelete();
        }
        [TestMethod]
        public virtual void SelectLastIndexOf1()
        {
            string str = "LinqTest";
            LinqDelete();
            LinqAdd();
            var expected = str.LastIndexOf('t');
            var actual = Table.Select(p => p.String.LastIndexOf('t')).FirstOrDefault();
            Assert.AreEqual(expected, actual);
            var item = Table.Where(p => p.String.LastIndexOf('t') == expected);
            Assert.IsNotNull(item);
            LinqDelete();
        }
        [TestMethod]
        public virtual void SelectLastIndexOf2()
        {
            string str = "LinqTest";
            LinqDelete();
            LinqAdd();
            var expected = str.LastIndexOf('i', 1);
            var actual = Table.Select(p => p.String.LastIndexOf('i', 1)).FirstOrDefault();
            Assert.AreEqual(expected, actual);
            var item = Table.Where(p => p.String.LastIndexOf('i', 1) == expected);
            Assert.IsNotNull(item);
            LinqDelete();
        }
        [TestMethod]
        public virtual void SelectLastIndexOf3()//从4开始，往前<-查4个
        {
            string str = "LinqTest";
            var expected = str.LastIndexOf('T', 4, 4);

            LinqDelete();
            LinqAdd();
        
            var actual = Table.Select(p => p.String.LastIndexOf('T', 4, 4)).FirstOrDefault();
            Assert.AreEqual(expected, actual);
            var item = Table.Where(p => p.String.LastIndexOf('T', 4, 4) == expected);
            Assert.IsNotNull(item);
            LinqDelete();
        }
        [TestMethod]
        public virtual void SelectLastIndexOf4()
        {
            string str = "LinqTest";
            LinqDelete();
            LinqAdd();
            var expected = str.LastIndexOf("t");
            var actual = Table.Select(p => p.String.LastIndexOf("t")).First();
            Assert.AreEqual(expected, actual);
            var item = Table.Where(p => p.String.LastIndexOf("t") == expected);
            Assert.IsNotNull(item);
            LinqDelete();
        }
        //changed
        [TestMethod]
        public virtual void SelectLastIndexOf5()
        {
            string str = "LinqTest";
            LinqDelete();
            LinqAdd();
            var expected = str.LastIndexOf("t", 7);
            var actual = Table.Select(p =>p.String.LastIndexOf("t",7) ).First();
            Assert.AreEqual(expected, actual);
            var item = Table.Where(p => p.String.LastIndexOf("t", 7) == expected);
            Assert.IsNotNull(item);
            LinqDelete();
        }
        //changed
        [TestMethod]
        public virtual void SelectLastIndexOf6()
        {
            string str = "LinqTest";
            LinqDelete();
            LinqAdd();
            var expected = str.LastIndexOf("in",3,3);
            var actual = Table.Select(p =>  p.String.LastIndexOf("in", 3, 3)).First();
            Assert.AreEqual(expected, actual);
            var item = Table.Where(p => p.String.LastIndexOf("in", 3, 3) == expected);
            Assert.IsNotNull(item);
            LinqDelete();
        }
        //sql.cs修改,测试待定！！！！
        [TestMethod]
        public virtual void SelectStuff()
        {
        }
        
        [TestMethod]
        //还有3个重载
        public virtual void SelectMany1()
        {
            LinqDelete();
            LinqAdd();
            var item = Table.SelectMany(p => p.String);
            Assert.IsNotNull(item);
            //Console.WriteLine(item.First());
            LinqDelete();
        }
        [TestMethod]
        //还有1个重载
        public virtual void SequenceEqual1()
        {
            LinqDelete();
            LinqAdd();
            var item = Table.Select(p => p.String);
            var item2 = Table.Select(p => p.String).SequenceEqual(item);
            Assert.IsNotNull(item2);
            Console.WriteLine(item2);
            LinqDelete();
        }
        [TestMethod]
        //另一个重载.Single()也OK
        public virtual void ServerSingle2()
        {
            LinqDelete();
            LinqAdd();
            var item = Table.Single(p => p.String == "OK");
            Assert.IsNotNull(item);
            LinqDelete();
        }
        [TestMethod]
        //另一个重载.SingleOrDefault()也OK
        public virtual void ServerSingleOrDefault2()
        {
            LinqDelete();
            LinqAdd();
            var item = Table.SingleOrDefault(p => p.String == "OK");
            Assert.IsNotNull(item);
            LinqDelete();
        }
        [TestMethod]
        public virtual void Skip()
        {
            //LinqDelete();
            //LinqAdd();
            //var item = Table.Skip(1).FirstOrDefault();
            //Assert.IsNotNull(item);
            //Console.WriteLine(item.String);
            //LinqDelete();
        }
    }
}
