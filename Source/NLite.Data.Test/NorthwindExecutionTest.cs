using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestInitialize = NUnit.Framework.SetUpAttribute;
using TestMethod = NUnit.Framework.TestAttribute;
using NLite.Data.Test.Model.Northwind;
using NLite.Linq;
using NLite.Data.Linq;
using System.Data;
using System.Reflection;

namespace NLite.Data.Test
{
    [TestClass]
    public class NorthwindExecutionTest:TestBase
    {
        protected Northwind db;

        protected virtual string ConnectionStringName
        {
            get { return "Northwind"; }
        }

        System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
        public NorthwindExecutionTest()
        {
            stopwatch.Start();
        }

        [TestInitialize]
        public  void Initialize()
        {
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();
            stopwatch.Start();
            db = new Northwind();
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);

            var connType = db.DbConfiguration.DbProviderName;

            Console.WriteLine(connType);
        }

        [TearDown]
        public void TearDown()
        {
            db.Dispose();
        }
        
        [TestMethod]
        public void TestToDataTable()
        {
            var tb = new DataTable();
            Mapper.Map(db.Customers, ref tb);

            Assert.AreEqual(db.Customers.Count(), tb.Rows.Count);
            Console.WriteLine(tb.Rows.Count);
        }

        [TestMethod]
        public void TestCompiledQuery()
        {
            var fn = QueryCompiler.Compile((string id) => db.Customers.Where(c => c.CustomerID == id));
            var items = fn("ALKFI").ToList();
        }

        [TestMethod]
        public void TestCompiledQuerySingleton()
        {
            var fn = QueryCompiler.Compile((string id) => db.Customers.SingleOrDefault(c => c.CustomerID == id));
            Customer cust = fn("ALKFI");
        }

        [TestMethod]
        public void TestCompiledQueryCount()
        {
            var fn = QueryCompiler.Compile((string id) => db.Customers.Count(c => c.CustomerID == id));
            int n = fn("ALKFI");
        }

        [TestMethod]
        public void TestCompiledQueryIsolated()
        {
            var fn = QueryCompiler.Compile((Northwind n, string id) => n.Customers.Where(c => c.CustomerID == id));
            var items = fn(db, "ALFKI").ToList();
        }


        [TestMethod]
        public void TestCompiledQueryIsolatedWithHeirarchy()
        {
            var fn = QueryCompiler.Compile((Northwind n, string id) =>
                n.Customers.Where(c => c.CustomerID == id)
                .Select(c => n.Orders.Where(o => o.CustomerID == c.CustomerID)));
            var items = fn(db, "ALFKI").ToList();

            var list = db.Customers.Select(c => new { City = (c.City == "London" ? null : c.City), Country = (c.CustomerID == "EASTC" ? null : c.Country) })
                        .Where(x => (x.City ?? "NoCity") == "NoCity").ToList();
            AssertValue(6, list.Count);
            AssertValue(null, list[0].City);

            var fn2 = QueryCompiler.Compile((Northwind n, string city, string customerId) => n.Customers.Select(c => new { City = (c.City == city ? null : c.City), Country = (c.CustomerID == customerId ? null : c.Country) })
                        .Where(x => (x.City ?? "NoCity") == "NoCity"));

            list = fn2(db, "London", "EASTC").ToList();
            AssertValue(6, list.Count);
            AssertValue(null, list[0].City);
           
        }
      

        [TestMethod]
        public virtual void TestCount()
        {
            var count = db.Customers.Count();
            AssertValue(91, count);
        }

        [TestMethod]
        public virtual void TestCountPredicate()
        {
            var count = db.Customers.Count(c => c.City == "London");
            AssertValue(6, count);
        }

       
        [TestMethod]
        public virtual void TestWhere()
        {
            var q = db.Customers.OrderBy(p => Guid.NewGuid());

            var c1 = q.FirstOrDefault();
            var c2 = q.FirstOrDefault();

            Assert.AreNotEqual(c1, c2);
        }


        [TestMethod]
        public virtual void TestAnyContains()
        {
            var citys = new string[] { "B", "U" };
            var q = db.Customers.Where(p=>citys.Any(c=>p.City.Contains(c)));
            var items = q.ToArray();
            Assert.IsTrue(items.Length >= 2);
        }

        [TestMethod]
        public virtual void TestWhereTrue()
        {
            var list = db.Customers.Where(c => true);
            AssertValue(91, list.Count());
        }

        [TestMethod]
        public virtual void TestCompareEntityEqual()
        {
            Customer alfki = new Customer { CustomerID = "ALFKI" };
            var list = db.Customers.Where(c => c == alfki).ToList();
            AssertValue(1, list.Count);
            AssertValue("ALFKI", list[0].CustomerID);
        }

        [TestMethod]
        public virtual void TestCompareEntityNotEqual()
        {
            Customer alfki = new Customer { CustomerID = "ALFKI" };
            var list = db.Customers.Where(c => c != alfki);
            AssertValue(90, list.Count());
        }

        [TestMethod]
        public virtual void TestCompareConstructedEqual()
        {
            var list = db.Customers.Where(c => new { x = c.City } == new { x = "London" }).ToList();
            AssertValue(6, list.Count);
        }

        [TestMethod]
        public virtual void TestCompareConstructedMultiValueEqual()
        {
            var list = db.Customers.Where(c => new { x = c.City, y = c.Country } == new { x = "London", y = "UK" }).ToList();
            AssertValue(6, list.Count);
        }

        [TestMethod]
        public virtual void TestCompareConstructedMultiValueNotEqual()
        {
            var list = db.Customers.Where(c => new { x = c.City, y = c.Country } != new { x = "London", y = "UK" }).ToList();
            AssertValue(85, list.Count);
        }

        [TestMethod]
        public virtual void TestCompareEntityEntityEqualRelationship()
        {
            Customer alfki = new Customer { CustomerID = "ALFKI" };
            var testQuery = from o in db.Orders
                            from c in db.Customers
                            where o.Customer == c &&
                                  c.CustomerID == alfki.CustomerID
                            select o;

            var test = testQuery.ToList();

            AssertValue(6, test.Count);
            AssertValue("ALFKI", test[0].CustomerID);
        }

        [TestMethod]
        public virtual void TestCompareEntityConstantEqualRelationship()
        {
            Customer alfki = new Customer { CustomerID = "ALFKI" };
            var testQuery = from o in db.Orders
                            where o.Customer == alfki
                            select o;

            var test = testQuery.ToList();

            AssertValue(6, test.Count);
            AssertValue("ALFKI", test[0].CustomerID);
        }

        [TestMethod]
        public virtual void TestCompareEntityConstantDirectEqualRelationship()
        {
            Customer alfki = new Customer { CustomerID = "ALFKI" };
            var testQuery = from c in db.Customers
                            where c == alfki
                            select c;

            var test = testQuery.ToList();

            AssertValue(1, test.Count);
            AssertValue("ALFKI", test[0].CustomerID);
        }

        [TestMethod]
        public virtual void TestCompareConstantEntityNestedRelationshipNegation()
        {
            var exclude = new Order() { OrderID = 10702 };

            var testQuery = from c in db.Customers
                            from o in c.Orders
                            from d in o.Details
                            where o != exclude
                            select d;

            var test = testQuery.ToList();

            AssertValue(2153, test.Count);
        }

        [TestMethod]
        public virtual void TestCompareTwoConstantEntityNestedRelationshipNegation()
        {
            Order exclude = new Order() { OrderID = 10702 };
            Customer alfki = new Customer() { CustomerID = "ALFKI" };

            var testQuery = from o in db.Orders
                            where o.Customer == alfki &&
                                  o != exclude
                            select o;

            var test = testQuery.ToList();
            AssertValue(5, test.Count);
            AssertValue("ALFKI", test[0].CustomerID);
        }

        [TestMethod]
        public virtual void TestSelectScalar()
        {
            var list = db.Customers.Where(c => c.City == "London").Select(c => c.City).ToList();
            AssertValue(6, list.Count);
            AssertValue("London", list[0]);
            Assert.IsTrue(list.All(x => x == "London"));
        }

        [TestMethod]
        public virtual void TestSelectAnonymousOne()
        {
            var q = db.Customers.Where(c => c.City == "London").Select(c => new { c.City });
            var list = q.ToList();
            AssertValue(6, list.Count);
            AssertValue("London", list[0].City);
            Assert.IsTrue(list.All(x => x.City == "London"));
        }

        [TestMethod]
        public virtual void TestSelectAnonymousTwo()
        {
            var list = db.Customers.Where(c => c.City == "London").Select(c => new { c.City, c.Phone }).ToList();
            AssertValue(6, list.Count);
            AssertValue("London", list[0].City);
            Assert.IsTrue(list.All(x => x.City == "London"));
            Assert.IsTrue(list.All(x => x.Phone != null));
        }

        [TestMethod]
        public virtual void TestSelectCustomerTable()
        {
            var list = db.Customers.ToList();
            AssertValue(91, list.Count);
        }

        [TestMethod]
        public virtual void TestSelectAnonymousWithObject()
        {
            var list = db.Customers.Where(c => c.City == "London").Select(c => new { c.City, c }).ToList();
            AssertValue(6, list.Count);
            AssertValue("London", list[0].City);
            Assert.IsTrue(list.All(x => x.City == "London"));
            Assert.IsTrue(list.All(x => x.c.City == x.City));
        }

        [TestMethod]
        public virtual void TestSelectAnonymousLiteral()
        {
            var list = db.Customers.Where(c => c.City == "London").Select(c => new { X = 10 }).ToList();
            AssertValue(6, list.Count);
            Assert.IsTrue(list.All(x => x.X == 10));
        }

        [TestMethod]
        public virtual void TestSelectConstantInt()
        {
            var list = db.Customers.Select(c => 10).ToList();
            AssertValue(91, list.Count);
            Assert.IsTrue(list.All(x => x == 10));
        }

        [TestMethod]
        public virtual void TestSelectConstantNullString()
        {
            var list = db.Customers.Select(c => (string)null).ToList();
            AssertValue(91, list.Count);
            Assert.IsTrue(list.All(x => x == null));
        }

        [TestMethod]
        public virtual void TestSelectLocal()
        {
            int x = 10;
            var list = db.Customers.Select(c => x).ToList();
            AssertValue(91, list.Count);
            Assert.IsTrue(list.All(y => y == 10));
        }

        [TestMethod]
        public virtual void TestSelectNestedCollection()
        {
            var list = (
                from c in db.Customers
                where c.CustomerID == "ALFKI"
                select db.Orders.Where(o => o.CustomerID == c.CustomerID).Select(o => o.OrderID)
                ).ToList();
            AssertValue(1, list.Count);
            AssertValue(6, list[0].Count());
        }

        [TestMethod]
        public virtual void TestSelectNestedCollectionInAnonymousType()
        {
            var list = (
                from c in db.Customers
                where c.CustomerID == "ALFKI"
                select new { Foos = db.Orders.Where(o => o.CustomerID == c.CustomerID).Select(o => o.OrderID).ToList() }
                ).ToList();
            AssertValue(1, list.Count);
            AssertValue(6, list[0].Foos.Count);
        }

        [TestMethod]
        public virtual void TestJoinCustomerOrders()
        {
            var list = (
                from c in db.Customers
                where c.CustomerID == "ALFKI"
                join o in db.Orders on c.CustomerID equals o.CustomerID
                select new { c.ContactName, o.OrderID }
                ).ToList();
            AssertValue(6, list.Count);
        }

        [TestMethod]
        public virtual void TestJoinMultiKey()
        {
            var list = (
                from c in db.Customers
                where c.CustomerID == "ALFKI"
                join o in db.Orders on new { a = c.CustomerID, b = c.CustomerID } equals new { a = o.CustomerID, b = o.CustomerID }
                select new { c, o }
                ).ToList();
            AssertValue(6, list.Count);
        }

        [TestMethod]
        public virtual void TestJoinIntoCustomersOrdersCount()
        {
            var list = (
                from c in db.Customers
                where c.CustomerID == "ALFKI"
                join o in db.Orders on c.CustomerID equals o.CustomerID into ords
                select new { cust = c, ords = ords.Count() }
                ).ToList();
            AssertValue(1, list.Count);
            AssertValue(6, list[0].ords);
        }

        [TestMethod]
        public virtual void TestJoinIntoDefaultIfEmpty()
        {
            var list = (
                from c in db.Customers
                where c.CustomerID == "PARIS"
                join o in db.Orders on c.CustomerID equals o.CustomerID into ords
                from o in ords.DefaultIfEmpty()
                select new { c, o }
                ).ToList();

            AssertValue(1, list.Count);
            //AssertValue(null, list[0].o);
        }

        [TestMethod]
        public virtual void TestMultipleJoinsWithJoinConditionsInWhere()
        {
            // this should reduce to inner joins
            var list = (
                from c in db.Customers
                from o in db.Orders
                from d in db.OrderDetails
                where o.CustomerID == c.CustomerID && o.OrderID == d.OrderID
                where c.CustomerID == "ALFKI"
                select d
                ).ToList();

            AssertValue(12, list.Count);
        }

        [TestMethod]
#if MySql
           [Microsoft.VisualStudio.TestTools.UnitTesting.Ignore] 
#endif
        public virtual void TestMultipleJoinsWithMissingJoinCondition()
        {
            // this should force a naked cross join
            var list = (
                from c in db.Customers
                from o in db.Orders
                from d in db.OrderDetails
                where o.CustomerID == c.CustomerID /*&& o.OrderID == d.OrderID*/
                where c.CustomerID == "ALFKI"
                select d
                ).ToList();
            
            AssertValue(12930, list.Count);
        }

        [TestMethod]
        public virtual void TestOrderBy()
        {
            var list = db.Customers.OrderBy(c => c.CustomerID).Select(c => c.CustomerID).ToList();
            var sorted = list.OrderBy(c => c).ToList();
            AssertValue(91, list.Count);
            Assert.IsTrue(Enumerable.SequenceEqual(list, sorted));
        }

        [TestMethod]
        public virtual void TestOrderByOrderBy()
        {
            var list = db.Customers.OrderBy(c => c.Phone).OrderBy(c => c.CustomerID).ToList();
            var sorted = list.OrderBy(c => c.CustomerID).ToList();
            AssertValue(91, list.Count);
            Assert.IsTrue(Enumerable.SequenceEqual(list, sorted));
        }

        [TestMethod]
        public virtual void TestOrderByThenBy()
        {
            var list = db.Customers.OrderBy(c => c.CustomerID).ThenBy(c => c.Phone).ToList();
            var sorted = list.OrderBy(c => c.CustomerID).ThenBy(c => c.Phone).ToList();
            AssertValue(91, list.Count);
            Assert.IsTrue(Enumerable.SequenceEqual(list, sorted));
        }

        [TestMethod]
        public virtual void TestOrderByDescending()
        {
            var list = db.Customers.OrderByDescending(c => c.CustomerID).ToList();
            var sorted = list.OrderByDescending(c => c.CustomerID).ToList();
            AssertValue(91, list.Count);
            Assert.IsTrue(Enumerable.SequenceEqual(list, sorted));
        }

        [TestMethod]
        public virtual void TestOrderByDescendingThenBy()
        {
            var list = db.Customers.OrderByDescending(c => c.CustomerID).ThenBy(c => c.Country).ToList();
            var sorted = list.OrderByDescending(c => c.CustomerID).ThenBy(c => c.Country).ToList();
            AssertValue(91, list.Count);
            Assert.IsTrue(Enumerable.SequenceEqual(list, sorted));
        }

        [TestMethod]
        public virtual void TestOrderByDescendingThenByDescending()
        {
            var list = db.Customers.OrderByDescending(c => c.CustomerID).ThenByDescending(c => c.Country).ToList();
            var sorted = list.OrderByDescending(c => c.CustomerID).ThenByDescending(c => c.Country).ToList();
            AssertValue(91, list.Count);
            Assert.IsTrue(Enumerable.SequenceEqual(list, sorted));
        }

        [TestMethod]
        public virtual void TestOrderByJoin()
        {
            var list = (
                from c in db.Customers.OrderBy(c => c.CustomerID)
                join o in db.Orders.OrderBy(o => o.OrderID) on c.CustomerID equals o.CustomerID
                select new { CustomerID = c.CustomerID, o.OrderID }
                ).ToList();

            var sorted = list.OrderBy(x => x.CustomerID).ThenBy(x => x.OrderID);
            Assert.IsTrue(Enumerable.SequenceEqual(list, sorted));
        }

        [TestMethod]
        public virtual void TestOrderBySelectMany()
        {
            var list = (
                from c in db.Customers.OrderBy(c => c.CustomerID)
                from o in db.Orders.OrderBy(o => o.OrderID)
                where c.CustomerID == o.CustomerID
                select new { CustomerID = c.CustomerID, o.OrderID }
                ).ToList();
            var sorted = list.OrderBy(x => x.CustomerID).ThenBy(x => x.OrderID).ToList();
            Assert.IsTrue(Enumerable.SequenceEqual(list, sorted));
        }

        [TestMethod]
        public virtual void TestCountProperty()
        {
            var list = db.Customers.Where(c => c.Orders.Count > 0).ToList();
            AssertValue(89, list.Count);
        }

        [TestMethod]
        public virtual void TestGroupBy()
        {
            var list = db.Customers.GroupBy(c => c.City).ToList();
            AssertValue(69, list.Count);
        }

        [TestMethod]
        public virtual void TestGroupByOne()
        {
            var list = db.Customers.Where(c => c.City == "London").GroupBy(c => c.City).ToList();
            AssertValue(1, list.Count);
            AssertValue(6, list[0].Count());
        }

        [TestMethod]
        public virtual void TestGroupBySelectMany()
        {
            var list = db.Customers.GroupBy(c => c.City).SelectMany(g => g).ToList();
            AssertValue(91, list.Count);
        }

        [TestMethod]
        public virtual void TestGroupBySum()
        {
            var list = db.Orders.Where(o => o.CustomerID == "ALFKI").GroupBy(o => o.CustomerID).Select(g => g.Sum(o => (o.CustomerID == "ALFKI" ? 1 : 1))).ToList();
            AssertValue(1, list.Count);
            AssertValue(6, list[0]);
        }

        [TestMethod]
        public virtual void TestGroupByCount()
        {
            var list = db.Orders.Where(o => o.CustomerID == "ALFKI").GroupBy(o => o.CustomerID).Select(g => g.Count()).ToList();
            AssertValue(1, list.Count);
            AssertValue(6, list[0]);
        }

        [TestMethod]
        public virtual void TestGroupByLongCount()
        {
            var list = db.Orders.Where(o => o.CustomerID == "ALFKI").GroupBy(o => o.CustomerID).Select(g => g.LongCount()).ToList();
            AssertValue(1, list.Count);
            AssertValue(6L, list[0]);
        }

        [TestMethod]
        public virtual void TestGroupBySumMinMaxAvg()
        {
            var list =
                db.Orders.Where(o => o.CustomerID == "ALFKI").GroupBy(o => o.CustomerID).Select(g =>
                    new
                    {
                        Sum = g.Sum(o => (o.CustomerID == "ALFKI" ? 1 : 1)),
                        Min = g.Min(o => o.OrderID),
                        Max = g.Max(o => o.OrderID),
                        Avg = g.Average(o => o.OrderID)
                    }).ToList();
            AssertValue(1, list.Count);
            AssertValue(6, list[0].Sum);
        }

        [TestMethod]
        public virtual void TestGroupByWithResultSelector()
        {
            var list =
                db.Orders.Where(o => o.CustomerID == "ALFKI").GroupBy(o => o.CustomerID, (k, g) =>
                    new
                    {
                        Sum = g.Sum(o => (o.CustomerID == "ALFKI" ? 1 : 1)),
                        Min = g.Min(o => o.OrderID),
                        Max = g.Max(o => o.OrderID),
                        Avg = g.Average(o => o.OrderID)
                    }).ToList();
            AssertValue(1, list.Count);
            AssertValue(6, list[0].Sum);
        }

        [TestMethod]
        public virtual void TestGroupByWithElementSelectorSum()
        {
            var list = db.Orders.Where(o => o.CustomerID == "ALFKI").GroupBy(o => o.CustomerID, o => (o.CustomerID == "ALFKI" ? 1 : 1)).Select(g => g.Sum()).ToList();
            AssertValue(1, list.Count);
            AssertValue(6, list[0]);
        }

        [TestMethod]
        public virtual void TestGroupByWithElementSelector()
        {
            // note: groups are retrieved through a separately execute subquery per row
            var list = db.Orders.Where(o => o.CustomerID == "ALFKI").GroupBy(o => o.CustomerID, o => (o.CustomerID == "ALFKI" ? 1 : 1)).ToList();
            AssertValue(1, list.Count);
            AssertValue(6, list[0].Count());
            AssertValue(6, list[0].Sum());
        }

        [TestMethod]
        public virtual void TestGroupByWithElementSelectorSumMax()
        {
            var list = db.Orders.Where(o => o.CustomerID == "ALFKI").GroupBy(o => o.CustomerID, o => (o.CustomerID == "ALFKI" ? 1 : 1)).Select(g => new { Sum = g.Sum(), Max = g.Max() }).ToList();
            AssertValue(1, list.Count);
            AssertValue(6, list[0].Sum);
            AssertValue(1, list[0].Max);
        }

        [TestMethod]
        public virtual void TestGroupByWithAnonymousElement()
        {
            var list = db.Orders.Where(o => o.CustomerID == "ALFKI").GroupBy(o => o.CustomerID, o => new { X = (o.CustomerID == "ALFKI" ? 1 : 1) }).Select(g => g.Sum(x => x.X)).ToList();
            AssertValue(1, list.Count);
            AssertValue(6, list[0]);
        }

        [TestMethod]
        public virtual void TestGroupByWithTwoPartKey()
        {
            var list = db.Orders.Where(o => o.CustomerID == "ALFKI").GroupBy(o => new { o.CustomerID, o.OrderDate }).Select(g => g.Sum(o => (o.CustomerID == "ALFKI" ? 1 : 1))).ToList();
            AssertValue(6, list.Count);
        }

        [TestMethod]
        public virtual void TestGroupByWithCountInWhere()
        {
            var list = db.Customers.Where(a => a.Orders.Count() > 15).GroupBy(a => a.City).ToList();
            AssertValue(9, list.Count);
        }

        [TestMethod]
        public virtual void TestOrderByGroupBy()
        {
            // note: order-by is lost when group-by is applied (the sequence of groups is not ordered)
            var list = db.Orders.Where(o => o.CustomerID == "ALFKI").OrderBy(o => o.OrderID).GroupBy(o => o.CustomerID).ToList();
            AssertValue(1, list.Count);
            var grp = list[0].ToList();
            var sorted = grp.OrderBy(o => o.OrderID);
            Assert.IsTrue(Enumerable.SequenceEqual(grp, sorted));
        }

        [TestMethod]
        public virtual void TestOrderByGroupBySelectMany()
        {
            var list = db.Orders.Where(o => o.CustomerID == "ALFKI").OrderBy(o => o.OrderID).GroupBy(o => o.CustomerID).SelectMany(g => g).ToList();
            AssertValue(6, list.Count);
            var sorted = list.OrderBy(o => o.OrderID).ToList();
            Assert.IsTrue(Enumerable.SequenceEqual(list, sorted));
        }

        [TestMethod]
        public virtual void TestSumWithNoArg()
        {
            var sum = db.Orders.Where(o => o.CustomerID == "ALFKI").Select(o => (o.CustomerID == "ALFKI" ? 1 : 1)).Sum();
            AssertValue(6, sum);
        }

        [TestMethod]
        public virtual void TestSumWithArg()
        {
            var sum = db.Orders.Where(o => o.CustomerID == "ALFKI").Sum(o => (o.CustomerID == "ALFKI" ? 1 : 1));
            AssertValue(6, sum);
        }

        [TestMethod]
        public virtual void TestCountWithNoPredicate()
        {
            var cnt = db.Orders.Count();
            AssertValue(830, cnt);
        }

        [TestMethod]
        public virtual void TestCountWithPredicate()
        {
            var cnt = db.Orders.Count(o => o.CustomerID == "ALFKI");
            AssertValue(6, cnt);
        }

        [TestMethod]
        public virtual void TestDistinctNoDupes()
        {
            var list = db.Customers.Distinct().ToList();
            AssertValue(91, list.Count);
        }

        [TestMethod]
        public virtual void TestDistinctScalar()
        {
            var list = db.Customers.Select(c => c.City).Distinct().ToList();
            AssertValue(69, list.Count);
        }

        [TestMethod]
        public virtual void TestOrderByDistinct()
        {
            // these are un-ordered, because using distinct negates any existing ordering.
            var list = db.Customers.Where(c => c.City.StartsWith("P")).OrderBy(c => c.City).Select(c => c.City).Distinct().ToList();
            AssertValue(2, list.Count);
            var sorted = list.OrderBy(x => x).ToList();
            AssertValue(2, list.Count);
            AssertValue(sorted[0], "Paris");
            AssertValue(sorted[1], "Portland");
        }

        [TestMethod]
        public virtual void TestDistinctOrderBy()
        {
            var list = db.Customers.Where(c => c.City.StartsWith("P")).Select(c => c.City).Distinct().OrderBy(c => c).ToList();
            var sorted = list.OrderBy(x => x).ToList();
            AssertValue(list[0], sorted[0]);
            AssertValue(list[list.Count - 1], sorted[list.Count - 1]);
        }

        [TestMethod]
        public virtual void TestDistinctGroupBy()
        {
            var list = db.Orders.Where(o => o.CustomerID == "ALFKI").Distinct().GroupBy(o => o.CustomerID).ToList();
            AssertValue(1, list.Count);
        }

        [TestMethod]
        public virtual void TestGroupByDistinct()
        {
            // distinct after group-by should not do anything
            var list = db.Orders.Where(o => o.CustomerID == "ALFKI").GroupBy(o => o.CustomerID).Distinct().ToList();
            AssertValue(1, list.Count);
        }

        [TestMethod]
        public virtual void TestDistinctCount()
        {
            var cnt = db.Customers.Distinct().Count();
            AssertValue(91, cnt);
        }

        [TestMethod]
        public virtual void TestSelectDistinctCount()
        {
            // cannot do: SELECT COUNT(DISTINCT some-colum) FROM some-table
            // because COUNT(DISTINCT some-column) does not count nulls
            var cnt = db.Customers.Select(c => c.City).Distinct().Count();
            AssertValue(69, cnt);
        }

        [TestMethod]
        public virtual void TestSelectSelectDistinctCount()
        {
            var cnt = db.Customers.Select(c => c.City).Select(c => c).Distinct().Count();
            AssertValue(69, cnt);
        }

        [TestMethod]
        public virtual void TestDistinctCountPredicate()
        {
            var cnt = db.Customers.Select(c => new { c.City, c.Country }).Distinct().Count(c => c.City == "London");
            AssertValue(1, cnt);
        }

        [TestMethod]
        public virtual void TestDistinctSumWithArg()
        {
            var sum = db.Orders.Where(o => o.CustomerID == "ALFKI").Distinct().Sum(o => (o.CustomerID == "ALFKI" ? 1 : 1));
            AssertValue(6, sum);
        }

        [TestMethod]
        public virtual void TestSelectDistinctSum()
        {
            var sum = db.Orders.Where(o => o.CustomerID == "ALFKI").Select(o => o.OrderID).Distinct().Sum();
            AssertValue(64835, sum);
        }

        [TestMethod]
        public virtual void TestTake()
        {
            var list = db.Orders.Take(5).ToList();
            AssertValue(5, list.Count);
        }

        [TestMethod]
        public virtual void TestTakeDistinct()
        {
            // distinct must be forced to apply after top has been computed
            var list = db.Orders.OrderBy(o => o.CustomerID).Select(o => o.CustomerID).Take(5).Distinct().ToList();
            AssertValue(1, list.Count);
        }

        [TestMethod]
        public virtual void TestDistinctTake()
        {
            // top must be forced to apply after distinct has been computed
            var list = db.Orders.OrderBy(o => o.CustomerID).Select(o => o.CustomerID).Distinct().Take(5).ToList();
            AssertValue(5, list.Count);
        }

        [TestMethod]
#if Access
        [NUnit.Framework.Ignore]  // ??? this produces a count of 6 ???
#endif
        public virtual void TestDistinctTakeCount()
        {
            var cnt = db.Orders.Distinct().OrderBy(o => o.CustomerID).Select(o => o.CustomerID).Take(5).Count();
            AssertValue(5, cnt);
        }

        [TestMethod]
        public virtual void TestTakeDistinctCount()
        {
            var cnt = db.Orders.OrderBy(o => o.CustomerID).Select(o => o.CustomerID).Take(5).Distinct().Count();
            AssertValue(1, cnt);
        }

        [TestMethod]
        public virtual void TestFirst()
        {
            var first = db.Customers.OrderBy(c => c.ContactName).First();
            Assert.AreNotEqual(null, first);
            AssertValue("ROMEY", first.CustomerID);
        }

        [TestMethod]
        public virtual void TestFirstPredicate()
        {
            var first = db.Customers.OrderBy(c => c.ContactName).First(c => c.City == "London");
            Assert.AreNotEqual(null, first);
            AssertValue("EASTC", first.CustomerID);
        }

        [TestMethod]
        public virtual void TestWhereFirst()
        {
            var first = db.Customers.OrderBy(c => c.ContactName).Where(c => c.City == "London").First();
            Assert.AreNotEqual(null, first);
            AssertValue("EASTC", first.CustomerID);
        }

        [TestMethod]
        public virtual void TestFirstOrDefault()
        {
            var first = db.Customers.OrderBy(c => c.ContactName).FirstOrDefault();
            Assert.AreNotEqual(null, first);
            AssertValue("ROMEY", first.CustomerID);
        }

        [TestMethod]
        public virtual void TestFirstOrDefaultPredicate()
        {
            var first = db.Customers.OrderBy(c => c.ContactName).FirstOrDefault(c => c.City == "London");
            Assert.AreNotEqual(null, first);
            AssertValue("EASTC", first.CustomerID);
        }

        [TestMethod]
        public virtual void TestWhereFirstOrDefault()
        {
            var first = db.Customers.OrderBy(c => c.ContactName).Where(c => c.City == "London").FirstOrDefault();
            Assert.AreNotEqual(null, first);
            AssertValue("EASTC", first.CustomerID);
        }

        [TestMethod]
        public virtual void TestFirstOrDefaultPredicateNoMatch()
        {
            var first = db.Customers.OrderBy(c => c.ContactName).FirstOrDefault(c => c.City == "SpongeBob");
            AssertValue(null, first);
        }

        [TestMethod]
        public virtual void TestReverse()
        {
            var list = db.Customers.OrderBy(c => c.ContactName).Reverse().ToList();
            AssertValue(91, list.Count);
            AssertValue("WOLZA", list[0].CustomerID);
            AssertValue("ROMEY", list[90].CustomerID);
        }

        [TestMethod]
        public virtual void TestReverseReverse()
        {
            var list = db.Customers.OrderBy(c => c.ContactName).Reverse().Reverse().ToList();
            AssertValue(91, list.Count);
            AssertValue("ROMEY", list[0].CustomerID);
            AssertValue("WOLZA", list[90].CustomerID);
        }

        [TestMethod]
        public virtual void TestReverseWhereReverse()
        {
            var list = db.Customers.OrderBy(c => c.ContactName).Reverse().Where(c => c.City == "London").Reverse().ToList();
            AssertValue(6, list.Count);
            AssertValue("EASTC", list[0].CustomerID);
            AssertValue("BSBEV", list[5].CustomerID);
        }

        [TestMethod]
        public virtual void TestReverseTakeReverse()
        {
            var list = db.Customers.OrderBy(c => c.ContactName).Reverse().Take(5).Reverse().ToList();
            AssertValue(5, list.Count);
            AssertValue("CHOPS", list[0].CustomerID);
            AssertValue("WOLZA", list[4].CustomerID);
        }

        [TestMethod]
        public virtual void TestReverseWhereTakeReverse()
        {
            var list = db.Customers.OrderBy(c => c.ContactName).Reverse().Where(c => c.City == "London").Take(5).Reverse().ToList();
            AssertValue(5, list.Count);
            AssertValue("CONSH", list[0].CustomerID);
            AssertValue("BSBEV", list[4].CustomerID);
        }

        [TestMethod]
        public virtual void TestLast()
        {
            var last = db.Customers.OrderBy(c => c.ContactName).Last();
            Assert.AreNotEqual(null, last);
            AssertValue("WOLZA", last.CustomerID);
        }

        [TestMethod]
        public virtual void TestLastPredicate()
        {
            var last = db.Customers.OrderBy(c => c.ContactName).Last(c => c.City == "London");
            Assert.AreNotEqual(null, last);
            AssertValue("BSBEV", last.CustomerID);
        }

        [TestMethod]
        public virtual void TestWhereLast()
        {
            var last = db.Customers.OrderBy(c => c.ContactName).Where(c => c.City == "London").Last();
            Assert.AreNotEqual(null, last);
            AssertValue("BSBEV", last.CustomerID);
        }

        [TestMethod]
        public virtual void TestLastOrDefault()
        {
            var last = db.Customers.OrderBy(c => c.ContactName).LastOrDefault();
            Assert.AreNotEqual(null, last);
            AssertValue("WOLZA", last.CustomerID);
        }

        [TestMethod]
        public virtual void TestLastOrDefaultPredicate()
        {
            var last = db.Customers.OrderBy(c => c.ContactName).LastOrDefault(c => c.City == "London");
            Assert.AreNotEqual(null, last);
            AssertValue("BSBEV", last.CustomerID);
        }

        [TestMethod]
        public virtual void TestWhereLastOrDefault()
        {
            var last = db.Customers.OrderBy(c => c.ContactName).Where(c => c.City == "London").LastOrDefault();
            Assert.AreNotEqual(null, last);
            AssertValue("BSBEV", last.CustomerID);
        }

        [TestMethod]
        public virtual void TestLastOrDefaultNoMatches()
        {
            var last = db.Customers.OrderBy(c => c.ContactName).LastOrDefault(c => c.City == "SpongeBob");
            AssertValue(null, last);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public virtual void TestSingleFails()
        {
            var single = db.Customers.Single();
        }

        [TestMethod]
        public virtual void TestSinglePredicate()
        {
            var single = db.Customers.Single(c => c.CustomerID == "ALFKI");
            Assert.AreNotEqual(null, single);
            AssertValue("ALFKI", single.CustomerID);
        }

        [TestMethod]
        public virtual void TestWhereSingle()
        {
            var single = db.Customers.Where(c => c.CustomerID == "ALFKI").Single();
            Assert.AreNotEqual(null, single);
            AssertValue("ALFKI", single.CustomerID);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public virtual void TestSingleOrDefaultFails()
        {
            var single = db.Customers.SingleOrDefault();
        }

        [TestMethod]
        public virtual void TestSingleOrDefaultPredicate()
        {
            var single = db.Customers.SingleOrDefault(c => c.CustomerID == "ALFKI");
            Assert.AreNotEqual(null, single);
            AssertValue("ALFKI", single.CustomerID);
        }

        [TestMethod]
        public virtual void TestWhereSingleOrDefault()
        {
            var single = db.Customers.Where(c => c.CustomerID == "ALFKI").SingleOrDefault();
            Assert.AreNotEqual(null, single);
            AssertValue("ALFKI", single.CustomerID);
        }

        [TestMethod]
        public virtual void TestSingleOrDefaultNoMatches()
        {
            var single = db.Customers.SingleOrDefault(c => c.CustomerID == "SpongeBob");
            AssertValue(null, single);
        }

        [TestMethod]
        public virtual void TestAnyTopLevel()
        {
            var any = db.Customers.Any();
            Assert.IsTrue(any);
        }

        [TestMethod]
        public virtual void TestAnyWithSubquery()
        {
            var list = db.Customers.Where(c => c.Orders.Any(o => o.CustomerID == "ALFKI")).ToList();
            AssertValue(1, list.Count);
        }

        [TestMethod]
        public virtual void TestAnyWithSubqueryNoPredicate()
        {
            // customers with at least one order
            var list = db.Customers.Where(c => db.Orders.Where(o => o.CustomerID == c.CustomerID).Any()).ToList();
            AssertValue(89, list.Count);
        }

        [TestMethod]
        public virtual void TestAnyWithLocalCollection()
        {
            // get customers for any one of these IDs
            string[] ids = new[] { "ALFKI", "WOLZA", "NOONE" };
            var list = db.Customers.Where(c => ids.Any(id => c.CustomerID == id)).ToList();
            AssertValue(2, list.Count);
        }

        [TestMethod]
        public virtual void TestAllWithSubquery()
        {
            var list = db.Customers.Where(c => c.Orders.All(o => o.CustomerID == "ALFKI")).ToList();
            // includes customers w/ no orders
            AssertValue(3, list.Count);
        }

        [TestMethod]
        public virtual void TestAllWithLocalCollection()
        {
            // get all customers with a name that contains both 'm' and 'd'  (don't use vowels since these often depend on collation)
            string[] patterns = new[] { "m", "d" };

            var list = db.Customers.Where(c => patterns.All(p => c.ContactName.ToLower().Contains(p))).Select(c => c.ContactName);
            var local = db.Customers.AsEnumerable().Where(c => patterns.All(p => c.ContactName.ToLower().Contains(p))).Select(c => c.ContactName).ToList();

            AssertValue(local.Count, list.Count());
        }

        [TestMethod]
        public virtual void TestAllTopLevel()
        {
            // all customers have name length > 0?
            var all = db.Customers.All(c => c.ContactName.Length > 0);
            Assert.IsTrue(all);
        }

        [TestMethod]
        public virtual void TestAllTopLevelNoMatches()
        {
            // all customers have name with 'a'
            var all = db.Customers.All(c => c.ContactName.Contains("a"));
            Assert.IsFalse(all);
        }

        [TestMethod]
        public virtual void TestContainsWithSubquery()
        {
            // this is the long-way to determine all customers that have at least one order
            var list = db.Customers.Where(c => db.Orders.Select(o => o.CustomerID).Contains(c.CustomerID)).ToList();
            AssertValue(89, list.Count);
        }

        [TestMethod]
        public virtual void TestContainsWithLocalCollection()
        {
            string[] ids = new[] { "ALFKI", "WOLZA", "NOONE" };
            var list = db.Customers.Where(c => ids.Contains(c.CustomerID)).ToList();
            AssertValue(2, list.Count);
        }

        [TestMethod]
        public virtual void TestContainsTopLevel()
        {
            var contains = db.Customers.Select(c => c.CustomerID).Contains("ALFKI");
            Assert.IsTrue(contains);
        }

        [TestMethod]
        public virtual void TestSkipTake()
        {
            var list = db.Customers.OrderBy(c => c.CustomerID).Skip(5).Take(10).ToList();
            AssertValue(10, list.Count);
            AssertValue("BLAUS", list[0].CustomerID);
            AssertValue("COMMI", list[9].CustomerID);
        }

        [TestMethod]
        public virtual void TestDistinctSkipTake()
        {
            var list = db.Customers.Select(c => c.City).Distinct().OrderBy(c => c).Skip(5).Take(10).ToList();
            AssertValue(10, list.Count);
            var hs = new HashSet<string>(list);
            AssertValue(10, hs.Count);
        }

        [TestMethod]
        public virtual void TestCoalesce()
        {

            var list = db.Customers.Select(c => new { City = (c.City == "London" ? null : c.City), Country = (c.CustomerID == "EASTC" ? null : c.Country) })
                         .Where(x => (x.City ?? "NoCity") == "NoCity").ToList();
            AssertValue(6, list.Count);
            AssertValue(null, list[0].City);
        }

        [TestMethod]
        public virtual void TestCoalesce2()
        {
            var list = db.Customers.Select(c => new { City = (c.City == "London" ? null : c.City), Country = (c.CustomerID == "EASTC" ? null : c.Country) })
                         .Where(x => (x.City ?? x.Country ?? "NoCityOrCountry") == "NoCityOrCountry").ToList();
            AssertValue(1, list.Count);
            AssertValue(null, list[0].City);
            AssertValue(null, list[0].Country);
        }

        // framework function tests

        [TestMethod]
        public virtual void TestStringLength()
        {
            var list = db.Customers.Where(c => c.City.Length == 7).ToList();
            AssertValue(9, list.Count);
        }

        [TestMethod]
        public virtual void TestStringStartsWithLiteral()
        {
            var list = db.Customers.Where(c => c.ContactName.StartsWith("M")).ToList();
            AssertValue(12, list.Count);
        }

        [TestMethod]
        public virtual void TestStringStartsWithColumn()
        {
            var list = db.Customers.Where(c => c.ContactName.StartsWith(c.ContactName)).ToList();
            AssertValue(91, list.Count);
        }

        [TestMethod]
        public virtual void TestStringEndsWithLiteral()
        {
            var list = db.Customers.Where(c => c.ContactName.EndsWith("s")).ToList();
            AssertValue(9, list.Count);
        }

        [TestMethod]
        public virtual void TestStringEndsWithColumn()
        {
            var list = db.Customers.Where(c => c.ContactName.EndsWith(c.ContactName)).ToList();
            AssertValue(91, list.Count);
        }

        [TestMethod]
        public virtual void TestStringContainsLiteral()
        {
            var list = db.Customers.Where(c => c.ContactName.Contains("nd")).Select(c => c.ContactName).ToList();
            var local = db.Customers.AsEnumerable().Where(c => c.ContactName.ToLower().Contains("nd")).Select(c => c.ContactName).ToList();
            AssertValue(local.Count, list.Count);
        }

        [TestMethod]
        public virtual void TestStringContainsColumn()
        {
            var list = db.Customers.Where(c => c.ContactName.Contains(c.ContactName)).ToList();
            AssertValue(91, list.Count);
        }

        [TestMethod]
        public virtual void TestStringConcatImplicit2Args()
        {
            var list = db.Customers.Where(c => c.ContactName + "X" == "Maria AndersX").ToList();
            AssertValue(1, list.Count);
        }

        [TestMethod]
        public virtual void TestStringConcatExplicit2Args()
        {
            var list = db.Customers.Where(c => string.Concat(c.ContactName, "X") == "Maria AndersX").ToList();
            AssertValue(1, list.Count);
        }

        [TestMethod]
        public virtual void TestStringConcatExplicit3Args()
        {
            var list = db.Customers.Where(c => string.Concat(c.ContactName, "X", c.Country) == "Maria AndersXGermany").ToList();
            AssertValue(1, list.Count);
        }

        [TestMethod]
        public virtual void TestStringConcatExplicitNArgs()
        {
            var list = db.Customers.Where(c => string.Concat(new string[] { c.ContactName, "X", c.Country }) == "Maria AndersXGermany").ToList();
            AssertValue(1, list.Count);
        }

        [TestMethod]
        public virtual void TestStringIsNullOrEmpty()
        {
            var list = db.Customers.Select(c => c.City == "London" ? null : c.CustomerID).Where(x => string.IsNullOrEmpty(x)).ToList();
            AssertValue(6, list.Count);
        }

        [TestMethod]
        public virtual void TestStringToUpper()
        {
            var str = db.Customers.Where(c => c.CustomerID == "ALFKI").Max(c => (c.CustomerID == "ALFKI" ? "abc" : "abc").ToUpper());
            AssertValue("ABC", str);
        }

        [TestMethod]
        public virtual void TestStringToLower()
        {
            var str = db.Customers.Where(c => c.CustomerID == "ALFKI").Max(c => (c.CustomerID == "ALFKI" ? "ABC" : "ABC").ToLower());
            AssertValue("abc", str);
        }

        [TestMethod]
        public virtual void TestStringSubstring()
        {
            var list = db.Customers.Where(c => c.City.Substring(0, 4) == "Seat").ToList();
            AssertValue(1, list.Count);
            AssertValue("Seattle", list[0].City);
        }

        [TestMethod]
        public virtual void TestStringSubstringNoLength()
        {
            var list = db.Customers.Where(c => c.City.Substring(4) == "tle").ToList();
            AssertValue(1, list.Count);
            AssertValue("Seattle", list[0].City);
        }

        [TestMethod]
        public virtual void TestStringIndexOf()
        {
            var n = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => c.ContactName.IndexOf("ar"));
            AssertValue(1, n);
        }

        [TestMethod]
        public virtual void TestStringIndexOfChar()
        {
            var n = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => c.ContactName.IndexOf('r'));
            AssertValue(2, n);
        }

        [TestMethod]
        public virtual void TestStringIndexOfWithStart()
        {
            var n = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => c.ContactName.IndexOf("a", 3));
            AssertValue(4, n);
        }

        [TestMethod]
        public virtual void TestStringTrim()
        {
            var notrim = db.Customers.Where(c => c.CustomerID == "ALFKI").Max(c => ("  " + c.City + " "));
            var trim = db.Customers.Where(c => c.CustomerID == "ALFKI").Max(c => ("  " + c.City + " ").Trim());
            Assert.AreNotEqual(notrim, trim);
            AssertValue(notrim.Trim(), trim);
        }

    

        [TestMethod]
        public virtual void TestMathAbs()
        {
            var neg1 = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => Math.Abs((c.CustomerID == "ALFKI") ? -1 : 0));
            var pos1 = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => Math.Abs((c.CustomerID == "ALFKI") ? 1 : 0));
            AssertValue(Math.Abs(-1), neg1);
            AssertValue(Math.Abs(1), pos1);
        }

        [TestMethod]
        public virtual void TestMathAtan()
        {
            var zero = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => Math.Atan((c.CustomerID == "ALFKI") ? 0.0 : 0.0));
            var one = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => Math.Atan((c.CustomerID == "ALFKI") ? 1.0 : 1.0));
            AssertValue(Math.Atan(0.0), zero, 0.0001);
            AssertValue(Math.Atan(1.0), one, 0.0001);
        }

        [TestMethod]
        public virtual void TestMathCos()
        {
            var zero = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => Math.Cos((c.CustomerID == "ALFKI") ? 0.0 : 0.0));
            var pi = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => Math.Cos((c.CustomerID == "ALFKI") ? Math.PI : Math.PI));
            AssertValue(Math.Cos(0.0), zero, 0.0001);
            AssertValue(Math.Cos(Math.PI), pi, 0.0001);
        }

        [TestMethod]
        public virtual void TestMathSin()
        {
            var zero = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => Math.Sin((c.CustomerID == "ALFKI") ? 0.0 : 0.0));
            var pi = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => Math.Sin((c.CustomerID == "ALFKI") ? Math.PI : Math.PI));
            var pi2 = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => Math.Sin(((c.CustomerID == "ALFKI") ? Math.PI : Math.PI) / 2.0));
            AssertValue(Math.Sin(0.0), zero);
            AssertValue(Math.Sin(Math.PI), pi, 0.0001);
            AssertValue(Math.Sin(Math.PI / 2.0), pi2, 0.0001);
        }

        [TestMethod]
        public virtual void TestMathTan()
        {
            var zero = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => Math.Tan((c.CustomerID == "ALFKI") ? 0.0 : 0.0));
            var pi = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => Math.Tan((c.CustomerID == "ALFKI") ? Math.PI : Math.PI));
            AssertValue(Math.Tan(0.0), zero, 0.0001);
            AssertValue(Math.Tan(Math.PI), pi, 0.0001);
        }

        [TestMethod]
        public virtual void TestMathExp()
        {
            var zero = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => Math.Exp((c.CustomerID == "ALFKI") ? 0.0 : 0.0));
            var one = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => Math.Exp((c.CustomerID == "ALFKI") ? 1.0 : 1.0));
            var two = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => Math.Exp((c.CustomerID == "ALFKI") ? 2.0 : 2.0));
            AssertValue(Math.Exp(0.0), zero, 0.0001);
            AssertValue(Math.Exp(1.0), one, 0.0001);
            AssertValue(Math.Exp(2.0), two, 0.0001);
        }

        [TestMethod]
        public virtual void TestMathLog()
        {
            var one = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => Math.Log((c.CustomerID == "ALFKI") ? 1.0 : 1.0));
            var e = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => Math.Log((c.CustomerID == "ALFKI") ? Math.E : Math.E));
            AssertValue(Math.Log(1.0), one, 0.0001);
            AssertValue(Math.Log(Math.E), e, 0.0001);
        }

        [TestMethod]
        public virtual void TestMathSqrt()
        {
            var one = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => Math.Sqrt((c.CustomerID == "ALFKI") ? 1.0 : 1.0));
            var four = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => Math.Sqrt((c.CustomerID == "ALFKI") ? 4.0 : 4.0));
            var nine = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => Math.Sqrt((c.CustomerID == "ALFKI") ? 9.0 : 9.0));
            AssertValue(1.0, one);
            AssertValue(2.0, four);
            AssertValue(3.0, nine);
        }

        [TestMethod]
        public virtual void TestMathPow()
        {
            // 2^n
            var zero = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => Math.Pow((c.CustomerID == "ALFKI") ? 2.0 : 2.0, 0.0));
            var one = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => Math.Pow((c.CustomerID == "ALFKI") ? 2.0 : 2.0, 1.0));
            var two = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => Math.Pow((c.CustomerID == "ALFKI") ? 2.0 : 2.0, 2.0));
            var three = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => Math.Pow((c.CustomerID == "ALFKI") ? 2.0 : 2.0, 3.0));
            AssertValue(1.0, zero);
            AssertValue(2.0, one);
            AssertValue(4.0, two);
            AssertValue(8.0, three);
        }

        [TestMethod]
        public virtual void TestMathRoundDefault()
        {
            var four = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => Math.Round((c.CustomerID == "ALFKI") ? 3.4 : 3.4));
            var six = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => Math.Round((c.CustomerID == "ALFKI") ? 3.6 : 3.6));
            AssertValue(3.0, four);
            AssertValue(4.0, six);
        }

        [TestMethod]
#if Access || SQLite
           [NUnit.Framework.Ignore] 
#endif
        public virtual void TestMathFloor()
        {
            // The difference between floor and truncate is how negatives are handled.  Floor drops the decimals and moves the
            // value to the more negative, so Floor(-3.4) is -4.0 and Floor(3.4) is 3.0.
            var four = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => Math.Floor((c.CustomerID == "ALFKI" ? 3.4 : 3.4)));
            var six = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => Math.Floor((c.CustomerID == "ALFKI" ? 3.6 : 3.6)));
            var nfour = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => Math.Floor((c.CustomerID == "ALFKI" ? -3.4 : -3.4)));
            AssertValue(Math.Floor(3.4), four);
            AssertValue(Math.Floor(3.6), six);
            AssertValue(Math.Floor(-3.4), nfour);
        }

        [TestMethod]
#if Access || SQLite
           [NUnit.Framework.Ignore] 
#endif
        public virtual void TestDecimalFloor()
        {
            var four = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => decimal.Floor((c.CustomerID == "ALFKI" ? 3.4m : 3.4m)));
            var six = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => decimal.Floor((c.CustomerID == "ALFKI" ? 3.6m : 3.6m)));
            var nfour = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => decimal.Floor((c.CustomerID == "ALFKI" ? -3.4m : -3.4m)));
            AssertValue(decimal.Floor(3.4m), four);
            AssertValue(decimal.Floor(3.6m), six);
            AssertValue(decimal.Floor(-3.4m), nfour);
        }

        [TestMethod]
#if SQLite
        [NUnit.Framework.Ignore]
#endif
        public virtual void TestMathTruncate()
        {
            // The difference between floor and truncate is how negatives are handled.  Truncate drops the decimals, 
            // therefore a truncated negative often has a more positive value than non-truncated (never has a less positive),
            // so Truncate(-3.4) is -3.0 and Truncate(3.4) is 3.0.
            var four = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => Math.Truncate((c.CustomerID == "ALFKI") ? 3.4 : 3.4));
            var six = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => Math.Truncate((c.CustomerID == "ALFKI") ? 3.6 : 3.6));
            var neg4 = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => Math.Truncate((c.CustomerID == "ALFKI") ? -3.4 : -3.4));
            AssertValue(Math.Truncate(3.4), four);
            AssertValue(Math.Truncate(3.6), six);
            AssertValue(Math.Truncate(-3.4), neg4);
        }

        [TestMethod]
        public virtual void TestStringCompareTo()
        {
            var lt = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => c.City.CompareTo("Seattle"));
            var gt = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => c.City.CompareTo("Aaa"));
            var eq = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => c.City.CompareTo("Berlin"));
            AssertValue(-1, lt);
            AssertValue(1, gt);
            AssertValue(0, eq);
        }

        [TestMethod]
        public virtual void TestStringCompareToLT()
        {
            var cmpLT = db.Customers.Where(c => c.CustomerID == "ALFKI").SingleOrDefault(c => c.City.CompareTo("Seattle") < 0);
            var cmpEQ = db.Customers.Where(c => c.CustomerID == "ALFKI").SingleOrDefault(c => c.City.CompareTo("Berlin") < 0);
            Assert.AreNotEqual(null, cmpLT);
            AssertValue(null, cmpEQ);
        }

        [TestMethod]
        public virtual void TestStringCompareToLE()
        {
            var cmpLE = db.Customers.Where(c => c.CustomerID == "ALFKI").SingleOrDefault(c => c.City.CompareTo("Seattle") <= 0);
            var cmpEQ = db.Customers.Where(c => c.CustomerID == "ALFKI").SingleOrDefault(c => c.City.CompareTo("Berlin") <= 0);
            var cmpGT = db.Customers.Where(c => c.CustomerID == "ALFKI").SingleOrDefault(c => c.City.CompareTo("Aaa") <= 0);
            Assert.AreNotEqual(null, cmpLE);
            Assert.AreNotEqual(null, cmpEQ);
            AssertValue(null, cmpGT);
        }

        [TestMethod]
        public virtual void TestStringCompareToGT()
        {
            var cmpLT = db.Customers.Where(c => c.CustomerID == "ALFKI").SingleOrDefault(c => c.City.CompareTo("Aaa") > 0);
            var cmpEQ = db.Customers.Where(c => c.CustomerID == "ALFKI").SingleOrDefault(c => c.City.CompareTo("Berlin") > 0);
            Assert.AreNotEqual(null, cmpLT);
            AssertValue(null, cmpEQ);
        }

        [TestMethod]
        public virtual void TestStringCompareToGE()
        {
            var cmpLE = db.Customers.Where(c => c.CustomerID == "ALFKI").SingleOrDefault(c => c.City.CompareTo("Seattle") >= 0);
            var cmpEQ = db.Customers.Where(c => c.CustomerID == "ALFKI").SingleOrDefault(c => c.City.CompareTo("Berlin") >= 0);
            var cmpGT = db.Customers.Where(c => c.CustomerID == "ALFKI").SingleOrDefault(c => c.City.CompareTo("Aaa") >= 0);
            AssertValue(null, cmpLE);
            Assert.AreNotEqual(null, cmpEQ);
            Assert.AreNotEqual(null, cmpGT);
        }

        [TestMethod]
        public virtual void TestStringCompareToEQ()
        {
            var cmpLE = db.Customers.Where(c => c.CustomerID == "ALFKI").SingleOrDefault(c => c.City.CompareTo("Seattle") == 0);
            var cmpEQ = db.Customers.Where(c => c.CustomerID == "ALFKI").SingleOrDefault(c => c.City.CompareTo("Berlin") == 0);
            var cmpGT = db.Customers.Where(c => c.CustomerID == "ALFKI").SingleOrDefault(c => c.City.CompareTo("Aaa") == 0);
            AssertValue(null, cmpLE);
            Assert.AreNotEqual(null, cmpEQ);
            AssertValue(null, cmpGT);
        }

        [TestMethod]
        public virtual void TestStringCompareToNE()
        {
            var cmpLE = db.Customers.Where(c => c.CustomerID == "ALFKI").SingleOrDefault(c => c.City.CompareTo("Seattle") != 0);
            var cmpEQ = db.Customers.Where(c => c.CustomerID == "ALFKI").SingleOrDefault(c => c.City.CompareTo("Berlin") != 0);
            var cmpGT = db.Customers.Where(c => c.CustomerID == "ALFKI").SingleOrDefault(c => c.City.CompareTo("Aaa") != 0);
            Assert.AreNotEqual(null, cmpLE);
            AssertValue(null, cmpEQ);
            Assert.AreNotEqual(null, cmpGT);
        }

        [TestMethod]
        public virtual void TestStringCompare()
        {
            var lt = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => string.Compare(c.City, "Seattle"));
            //var gt = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => string.Compare(c.City, "Aaa"));
            //var eq = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => string.Compare(c.City, "Berlin"));
            AssertValue(-1, lt);
            //AssertValue(1, gt);
            //AssertValue(0, eq);
        }

        [TestMethod]
        public virtual void TestStringCompareLT()
        {
            var cmpLT = db.Customers.Where(c => c.CustomerID == "ALFKI").SingleOrDefault(c => string.Compare(c.City, "Seattle") < 0);
            var cmpEQ = db.Customers.Where(c => c.CustomerID == "ALFKI").SingleOrDefault(c => string.Compare(c.City, "Berlin") < 0);
            Assert.AreNotEqual(null, cmpLT);
            AssertValue(null, cmpEQ);
        }

        [TestMethod]
        public virtual void TestStringCompareLE()
        {
            var cmpLE = db.Customers.Where(c => c.CustomerID == "ALFKI").SingleOrDefault(c => string.Compare(c.City, "Seattle") <= 0);
            var cmpEQ = db.Customers.Where(c => c.CustomerID == "ALFKI").SingleOrDefault(c => string.Compare(c.City, "Berlin") <= 0);
            var cmpGT = db.Customers.Where(c => c.CustomerID == "ALFKI").SingleOrDefault(c => string.Compare(c.City, "Aaa") <= 0);
            Assert.AreNotEqual(null, cmpLE);
            Assert.AreNotEqual(null, cmpEQ);
            AssertValue(null, cmpGT);
        }

        [TestMethod]
        public virtual void TestStringCompareGT()
        {
            var cmpLT = db.Customers.Where(c => c.CustomerID == "ALFKI").SingleOrDefault(c => string.Compare(c.City, "Aaa") > 0);
            var cmpEQ = db.Customers.Where(c => c.CustomerID == "ALFKI").SingleOrDefault(c => string.Compare(c.City, "Berlin") > 0);
            Assert.AreNotEqual(null, cmpLT);
            AssertValue(null, cmpEQ);
        }

        [TestMethod]
        public virtual void TestStringCompareGE()
        {
            var cmpLE = db.Customers.Where(c => c.CustomerID == "ALFKI").SingleOrDefault(c => string.Compare(c.City, "Seattle") >= 0);
            var cmpEQ = db.Customers.Where(c => c.CustomerID == "ALFKI").SingleOrDefault(c => string.Compare(c.City, "Berlin") >= 0);
            var cmpGT = db.Customers.Where(c => c.CustomerID == "ALFKI").SingleOrDefault(c => string.Compare(c.City, "Aaa") >= 0);
            AssertValue(null, cmpLE);
            Assert.AreNotEqual(null, cmpEQ);
            Assert.AreNotEqual(null, cmpGT);
        }

        [TestMethod]
        public virtual void TestStringCompareEQ()
        {
            var cmpLE = db.Customers.Where(c => c.CustomerID == "ALFKI").SingleOrDefault(c => string.Compare(c.City, "Seattle") == 0);
            var cmpEQ = db.Customers.Where(c => c.CustomerID == "ALFKI").SingleOrDefault(c => string.Compare(c.City, "Berlin") == 0);
            var cmpGT = db.Customers.Where(c => c.CustomerID == "ALFKI").SingleOrDefault(c => string.Compare(c.City, "Aaa") == 0);
            AssertValue(null, cmpLE);
            Assert.AreNotEqual(null, cmpEQ);
            AssertValue(null, cmpGT);
        }

        [TestMethod]
        public virtual void TestStringCompareNE()
        {
            var cmpLE = db.Customers.Where(c => c.CustomerID == "ALFKI").SingleOrDefault(c => string.Compare(c.City, "Seattle") != 0);
            var cmpEQ = db.Customers.Where(c => c.CustomerID == "ALFKI").SingleOrDefault(c => string.Compare(c.City, "Berlin") != 0);
            var cmpGT = db.Customers.Where(c => c.CustomerID == "ALFKI").SingleOrDefault(c => string.Compare(c.City, "Aaa") != 0);
            Assert.AreNotEqual(null, cmpLE);
            AssertValue(null, cmpEQ);
            Assert.AreNotEqual(null, cmpGT);
        }

        [TestMethod]
        public virtual void TestIntCompareTo()
        {
            // prove that x.CompareTo(y) works for types other than string
            var eq = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => (c.CustomerID == "ALFKI" ? 10 : 10).CompareTo(10));
            var gt = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => (c.CustomerID == "ALFKI" ? 10 : 10).CompareTo(9));
            var lt = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => (c.CustomerID == "ALFKI" ? 10 : 10).CompareTo(11));
            AssertValue(0, eq);
            AssertValue(1, gt);
            AssertValue(-1, lt);
        }

        [TestMethod]
        public virtual void TestDecimalCompare()
        {
            // prove that type.Compare(x,y) works with decimal
            var eq = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => decimal.Compare((c.CustomerID == "ALFKI" ? 10m : 10m), 10m));
            var gt = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => decimal.Compare((c.CustomerID == "ALFKI" ? 10m : 10m), 9m));
            var lt = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => decimal.Compare((c.CustomerID == "ALFKI" ? 10m : 10m), 11m));
            AssertValue(0, eq);
            AssertValue(1, gt);
            AssertValue(-1, lt);
        }

        [TestMethod]
        public virtual void TestDecimalAdd()
        {
            var onetwo = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => decimal.Add((c.CustomerID == "ALFKI" ? 1m : 1m), 2m));
            AssertValue(3m, onetwo);
        }

        [TestMethod]
        public virtual void TestDecimalSubtract()
        {
            var onetwo = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => decimal.Subtract((c.CustomerID == "ALFKI" ? 1m : 1m), 2m));
            AssertValue(-1m, onetwo);
        }

        [TestMethod]
        public virtual void TestDecimalMultiply()
        {
            var onetwo = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => decimal.Multiply((c.CustomerID == "ALFKI" ? 1m : 1m), 2m));
            AssertValue(2m, onetwo);
        }

        [TestMethod]
        public virtual void TestDecimalDivide()
        {
            var onetwo = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => decimal.Divide((c.CustomerID == "ALFKI" ? 1.0m : 1.0m), 2.0m));
            AssertValue(0.5m, onetwo);
        }

        [TestMethod]
        public virtual void TestDecimalNegate()
        {
            var one = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => decimal.Negate((c.CustomerID == "ALFKI" ? 1m : 1m)));
            AssertValue(-1m, one);
        }

        [TestMethod]
        public virtual void TestDecimalRoundDefault()
        {
            var four = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => decimal.Round((c.CustomerID == "ALFKI" ? 3.4m : 3.4m)));
            var six = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => decimal.Round((c.CustomerID == "ALFKI" ? 3.5m : 3.5m)));
            AssertValue(3.0m, four);
            AssertValue(4.0m, six);
        }

        [TestMethod]
#if SQLite
           [NUnit.Framework.Ignore] 
#endif
        public virtual void TestDecimalTruncate()
        {
            // The difference between floor and truncate is how negatives are handled.  Truncate drops the decimals, 
            // therefore a truncated negative often has a more positive value than non-truncated (never has a less positive),
            // so Truncate(-3.4) is -3.0 and Truncate(3.4) is 3.0.
            var four = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => decimal.Truncate((c.CustomerID == "ALFKI") ? 3.4m : 3.4m));
            var six = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => Math.Truncate((c.CustomerID == "ALFKI") ? 3.6m : 3.6m));
            var neg4 = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => Math.Truncate((c.CustomerID == "ALFKI") ? -3.4m : -3.4m));
            AssertValue(decimal.Truncate(3.4m), four);
            AssertValue(decimal.Truncate(3.6m), six);
            AssertValue(decimal.Truncate(-3.4m), neg4);
        }

        [TestMethod]
        public virtual void TestDecimalLT()
        {
            // prove that decimals are treated normally with respect to normal comparison operators
            var alfki = db.Customers.SingleOrDefault(c => c.CustomerID == "ALFKI" && (c.CustomerID == "ALFKI" ? 1.0m : 3.0m) < 2.0m);
            Assert.AreNotEqual(null, alfki);
        }

        [TestMethod]
        public virtual void TestIntLessThan()
        {
            var alfki = db.Customers.SingleOrDefault(c => c.CustomerID == "ALFKI" && (c.CustomerID == "ALFKI" ? 1 : 3) < 2);
            var alfkiN = db.Customers.SingleOrDefault(c => c.CustomerID == "ALFKI" && (c.CustomerID == "ALFKI" ? 3 : 1) < 2);
            Assert.AreNotEqual(null, alfki);
            AssertValue(null, alfkiN);
        }

        [TestMethod]
        public virtual void TestIntLessThanOrEqual()
        {
            var alfki = db.Customers.SingleOrDefault(c => c.CustomerID == "ALFKI" && (c.CustomerID == "ALFKI" ? 1 : 3) <= 2);
            var alfki2 = db.Customers.SingleOrDefault(c => c.CustomerID == "ALFKI" && (c.CustomerID == "ALFKI" ? 2 : 3) <= 2);
            var alfkiN = db.Customers.SingleOrDefault(c => c.CustomerID == "ALFKI" && (c.CustomerID == "ALFKI" ? 3 : 1) <= 2);
            Assert.AreNotEqual(null, alfki);
            Assert.AreNotEqual(null, alfki2);
            AssertValue(null, alfkiN);
        }

        [TestMethod]
        public virtual void TestIntGreaterThan()
        {
            var alfki = db.Customers.SingleOrDefault(c => c.CustomerID == "ALFKI" && (c.CustomerID == "ALFKI" ? 3 : 1) > 2);
            var alfkiN = db.Customers.SingleOrDefault(c => c.CustomerID == "ALFKI" && (c.CustomerID == "ALFKI" ? 1 : 3) > 2);
            Assert.AreNotEqual(null, alfki);
            AssertValue(null, alfkiN);
        }

        [TestMethod]
        public virtual void TestIntGreaterThanOrEqual()
        {
            var alfki = db.Customers.Single(c => c.CustomerID == "ALFKI" && (c.CustomerID == "ALFKI" ? 3 : 1) >= 2);
            var alfki2 = db.Customers.Single(c => c.CustomerID == "ALFKI" && (c.CustomerID == "ALFKI" ? 3 : 2) >= 2);
            var alfkiN = db.Customers.SingleOrDefault(c => c.CustomerID == "ALFKI" && (c.CustomerID == "ALFKI" ? 1 : 3) > 2);
            Assert.AreNotEqual(null, alfki);
            Assert.AreNotEqual(null, alfki2);
            AssertValue(null, alfkiN);
        }

        [TestMethod]
        public virtual void TestIntEqual()
        {
            var alfki = db.Customers.SingleOrDefault(c => c.CustomerID == "ALFKI" && (c.CustomerID == "ALFKI" ? 1 : 1) == 1);
            var alfkiN = db.Customers.SingleOrDefault(c => c.CustomerID == "ALFKI" && (c.CustomerID == "ALFKI" ? 1 : 1) == 2);
            Assert.AreNotEqual(null, alfki);
            AssertValue(null, alfkiN);
        }

        [TestMethod]
        public virtual void TestIntNotEqual()
        {
            var alfki = db.Customers.SingleOrDefault(c => c.CustomerID == "ALFKI" && (c.CustomerID == "ALFKI" ? 2 : 2) != 1);
            var alfkiN = db.Customers.SingleOrDefault(c => c.CustomerID == "ALFKI" && (c.CustomerID == "ALFKI" ? 2 : 2) != 2);
            Assert.AreNotEqual(null, alfki);
            AssertValue(null, alfkiN);
        }

        [TestMethod]
        public virtual void TestIntAdd()
        {
            var three = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => ((c.CustomerID == "ALFKI") ? 1 : 1) + 2);
            AssertValue(3, three);
        }

        [TestMethod]
        public virtual void TestIntSubtract()
        {
            var negone = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => ((c.CustomerID == "ALFKI") ? 1 : 1) - 2);
            AssertValue(-1, negone);
        }

        [TestMethod]
        public virtual void TestIntMultiply()
        {
            var six = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => ((c.CustomerID == "ALFKI") ? 2 : 2) * 3);
            AssertValue(6, six);
        }

        [TestMethod]
        public virtual void TestIntDivide()
        {
            var one = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => ((c.CustomerID == "ALFKI") ? 3 : 3) / 2);
            AssertValue(1, one);
        }

        [TestMethod]
        public virtual void TestIntModulo()
        {
            var three = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => ((c.CustomerID == "ALFKI") ? 7 : 7) % 4);
            AssertValue(3, three);
        }

        [TestMethod]
        public virtual void TestIntLeftShift()
        {
            var eight = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => ((c.CustomerID == "ALFKI") ? 1 : 1) << 3);
            AssertValue(8, eight);
        }

        [TestMethod]
        public virtual void TestIntRightShift()
        {
            var eight = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => ((c.CustomerID == "ALFKI") ? 32 : 32) >> 2);
            AssertValue(8, eight);
        }

        [TestMethod]
        public virtual void TestIntBitwiseAnd()
        {
            var band = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => ((c.CustomerID == "ALFKI") ? 6 : 6) & 3);
            AssertValue(2, band);
        }

        [TestMethod]
        public virtual void TestIntBitwiseOr()
        {
            var eleven = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => ((c.CustomerID == "ALFKI") ? 10 : 10) | 3);
            AssertValue(11, eleven);
        }

        [TestMethod]
        public virtual void TestIntBitwiseExclusiveOr()
        {
            var zero = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => ((c.CustomerID == "ALFKI") ? 1 : 1) ^ 1);
            AssertValue(0, zero);
        }

        [TestMethod]
        public virtual void TestIntBitwiseNot()
        {
            var bneg = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => ~((c.CustomerID == "ALFKI") ? -1 : -1));
            AssertValue(~-1, bneg);
        }

        [TestMethod]
        public virtual void TestIntNegate()
        {
            var neg = db.Customers.Where(c => c.CustomerID == "ALFKI").Sum(c => -((c.CustomerID == "ALFKI") ? 1 : 1));
            AssertValue(-1, neg);
        }

        [TestMethod]
        public virtual void TestAnd()
        {
            var custs = db.Customers.Where(c => c.Country == "USA" && c.City.StartsWith("A")).Select(c => c.City).ToList();
            AssertValue(2, custs.Count);
            Assert.IsTrue(custs.All(c => c.StartsWith("A")));
        }

        [TestMethod]
        public virtual void TestOr()
        {
            var custs = db.Customers.Where(c => c.Country == "USA" || c.City.StartsWith("A")).Select(c => c.City).ToList();
            AssertValue(14, custs.Count);
        }

        [TestMethod]
        public virtual void TestNot()
        {
            var custs = db.Customers.Where(c => !(c.Country == "USA")).Select(c => c.Country).ToList();
            AssertValue(78, custs.Count);
        }

        [TestMethod]
        public virtual void TestEqualLiteralNull()
        {
            var q = db.Customers.Select(c => c.CustomerID == "ALFKI" ? null : c.CustomerID).Where(x => x == null);
            var n = q.Count();
            AssertValue(1, n);
        }

        [TestMethod]
        public virtual void TestEqualLiteralNullReversed()
        {
            var q = db.Customers.Select(c => c.CustomerID == "ALFKI" ? null : c.CustomerID).Where(x => null == x);
            var n = q.Count();
            AssertValue(1, n);
        }

        [TestMethod]
        public virtual void TestNotEqualLiteralNull()
        {
            var q = db.Customers.Select(c => c.CustomerID == "ALFKI" ? null : c.CustomerID).Where(x => x != null);
            var n = q.Count();
            AssertValue(90, n);
        }

        [TestMethod]
        public virtual void TestNotEqualLiteralNullReversed()
        {
            var q = db.Customers.Select(c => c.CustomerID == "ALFKI" ? null : c.CustomerID).Where(x => null != x);
            var n = q.Count();
            AssertValue(90, n);
        }

        [TestMethod]
        public virtual void TestConditionalResultsArePredicates()
        {
            bool value = db.Orders.Where(c => c.CustomerID == "ALFKI").Max(c => (c.CustomerID == "ALFKI" ? string.Compare(c.CustomerID, "POTATO") < 0 : string.Compare(c.CustomerID, "POTATO") > 0));
            Assert.IsTrue(value);
        }

        [TestMethod]
        public virtual void TestSelectManyJoined()
        {
            var cods =
                (from c in db.Customers
                 from o in db.Orders.Where(o => o.CustomerID == c.CustomerID)
                 select new { c.ContactName, o.OrderDate }).ToList();
            AssertValue(830, cods.Count);
        }

        [TestMethod]
        public virtual void TestSelectManyJoinedDefaultIfEmpty()
        {
            var cods = (
                from c in db.Customers
                from o in db.Orders.Where(o => o.CustomerID == c.CustomerID).DefaultIfEmpty()
                select new { c.ContactName, o.OrderDate }
                ).ToList();
            AssertValue(832, cods.Count);
        }

        [TestMethod]
        public virtual void TestSelectWhereAssociation()
        {
            var ords = (
                from o in db.Orders
                where o.Customer.City == "Seattle"
                select o
                ).ToList();
            AssertValue(14, ords.Count);
        }

        [TestMethod]
        public virtual void TestSelectWhereAssociationTwice()
        {
            var n = db.Orders.Where(c => c.CustomerID == "WHITC").Count();
            var ords = (
                from o in db.Orders
                where o.Customer.Country == "USA" && o.Customer.City == "Seattle"
                select o
                ).ToList();
            AssertValue(n, ords.Count);
        }

        [TestMethod]
        public virtual void TestSelectAssociation()
        {
            var custs = (
                from o in db.Orders
                where o.CustomerID == "ALFKI"
                select o.Customer
                ).ToList();
            AssertValue(6, custs.Count);
            Assert.IsTrue(custs.All(c => c.CustomerID == "ALFKI"));
        }

        [TestMethod]
        public virtual void TestSelectAssociations()
        {
            var doubleCusts = (
                from o in db.Orders
                where o.CustomerID == "ALFKI"
                select new { A = o.Customer, B = o.Customer }
                ).ToList();

            AssertValue(6, doubleCusts.Count);
            Assert.IsTrue(doubleCusts.All(c => c.A.CustomerID == "ALFKI" && c.B.CustomerID == "ALFKI"));
        }

        [TestMethod]
        public virtual void TestSelectOrderIncludeCustomer()
        {
            var order = db.Orders.Include(c => c.Customer).FirstOrDefault();
            Assert.IsNotNull(order);
            Assert.IsNotNull(order.Customer);
        }

        [TestMethod]
        public virtual void TestSelectAssociationsWhereAssociations()
        {
            var stuff = (
                from o in db.Orders
                where o.Customer.Country == "USA"
                where o.Customer.City != "Seattle"
                select new { A = o.Customer, B = o.Customer }
                ).ToList();
            AssertValue(108, stuff.Count);
        }

        [TestMethod]
        public virtual void TestCustomersIncludeOrders()
        {
            var custs = db.Customers.Include(c=>c.Orders).Where(c => c.CustomerID == "ALFKI").ToList();
            AssertValue(1, custs.Count);
            Assert.AreNotEqual(null, custs[0].Orders);
            AssertValue(6, custs[0].Orders.Count);
        }

        [TestMethod]
        public virtual void TestCustomersIncludeOrdersAndDetails()
        {
            var custs = db.Customers
                .Include(c=>c.Orders)
                .IncludeWith<Order>(o=>o.Details)
                .Where(c => c.CustomerID == "ALFKI")
                .ToList();
            AssertValue(1, custs.Count);
            Assert.AreNotEqual(null, custs[0].Orders);
            AssertValue(6, custs[0].Orders.Count);
            Assert.IsTrue(custs[0].Orders.Any(o => o.OrderID == 10643));
            Assert.AreNotEqual(null, custs[0].Orders.Single(o => o.OrderID == 10643).Details);
            AssertValue(3, custs[0].Orders.Single(o => o.OrderID == 10643).Details.Count());
        }


        [TestMethod]
        public virtual void TestCustomersIncludeOrdersWhere()
        {
            var custs = db.Customers
                .Include(c=>c.Orders.Where(o=>(o.OrderID & 1) == 0))
                .Where(c => c.CustomerID == "ALFKI")
                .ToList();
            AssertValue(1, custs.Count);
            Assert.AreNotEqual(null, custs[0].Orders);
            AssertValue(3, custs[0].Orders.Count);
        }

        [TestMethod]
        public virtual void TestCustomersIncludeOrdersDeferred()
        {
            var custs = db
                .Customers
                .Include(c=>c.Orders)
                .Where(c => c.CustomerID == "ALFKI")
                .ToList();
            AssertValue(1, custs.Count);
            Assert.AreNotEqual(null, custs[0].Orders);
            AssertValue(6, custs[0].Orders.Count);
        }

        //[TestMethod]
        //public virtual void TestCustomersAssociateOrders()
        //{
        //    var custs = db
        //        .Customers
        //        .Associate(c=>c.Orders.Where(o => (o.OrderID & 1) == 0))
        //        .Where(c => c.CustomerID == "ALFKI")
        //        .Select(c => new { CustomerID = c.CustomerID, FilteredOrdersCount = c.Orders.Count() })
        //        .ToList();
        //    AssertValue(1, custs.Count);
        //    AssertValue(3, custs[0].FilteredOrdersCount);
        //}

        //[TestMethod]
        //public virtual void TestCustomersIncludeThenAssociateOrders()
        //{
        //    var custs = db
        //        .Customers
        //        .Include(c=>c.Orders)
        //        .Associate(c => c.Orders.Where(o => (o.OrderID & 1) == 0))
        //        .Where(c => c.CustomerID == "ALFKI")
        //        .ToList();
        //    AssertValue(1, custs.Count);
        //    Assert.AreNotEqual(null, custs[0].Orders);
        //    AssertValue(3, custs[0].Orders.Count);
        //}

        //[TestMethod]
        //public virtual void TestCustomersAssociateThenIncludeOrders()
        //{
        //    var custs = db
        //       .Customers
        //       .Associate(c => c.Orders.Where(o => (o.OrderID & 1) == 0))
        //       .Include(c => c.Orders)
        //       .Where(c => c.CustomerID == "ALFKI")
        //       .ToList();
        //    AssertValue(1, custs.Count);
        //    Assert.AreNotEqual(null, custs[0].Orders);
        //    AssertValue(3, custs[0].Orders.Count);
        //}

        [TestMethod]
        public virtual void TestOrdersIncludeDetailsWithGroupBy()
        {
            var list = db
                .Orders
                .Include(o=>o.Details)
                .Where(o => o.CustomerID == "ALFKI")
                .GroupBy(o => o.CustomerID)
                .ToList();
            AssertValue(1, list.Count);
            var grp = list[0].ToList();
            AssertValue(6, grp.Count);
            var o10643 = grp.SingleOrDefault(o => o.OrderID == 10643);
            Assert.AreNotEqual(null, o10643);
            AssertValue(3, o10643.Details.Count());
        }



        [TestMethod]
        public virtual void TestOrdersIncludeDetailsWithFirst()
        {
            var q = from o in db.Orders.Include(o=>o.Details)
                    where o.OrderID == 10248
                    select o;

            Order so = q.Single();
            AssertValue(3, so.Details.Count());
            Order fo = q.First();
            AssertValue(3, fo.Details.Count());
        }

        [TestMethod]
#if Access
        [NUnit.Framework.Ignore]  // Access: can't handle scalar-subqueries referencing outer scope aliases?
#endif
        public virtual void TestBigQueryWithOrderingGroupingAndNestedGroupCounts()
        {
            var query = db.Customers
                          .OrderBy(c => c.City)
                          .Take(10)
                          .GroupBy(c => c.City)
                          .OrderBy(g => g.Key)
                          .Select(g => new { Key = g.Key, ItemCount = g.Count(), HasSubGroups = false, Items = g });

            var results = query.ToList();
        }
    }
}
