using System;
using System.Linq;
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestMethod = NUnit.Framework.TestAttribute;

namespace NLite.Data.Test.LinqToSql.GroupBy_Having
{
    [TestClass]
    public class GroupByTest1 : DLinqConnection
    {
        //简单形式
        [TestMethod]
        public void Test1()
        {
            using (var db = dbConfiguration.CreateDbContext())
            {
                var item = from p in db.Set<Products>()
                           group p by p.CategoryID into g
                           select g;
                foreach (var it in item)
                {
                    Console.WriteLine(it.Key + " --- " + it.Count());
                }
            }
        }
        //select匿名类+计数
        [TestMethod]
        public void Test2()
        {
            using (var db = dbConfiguration.CreateDbContext())
            {
                var item = from p in db.Set<Products>()
                           group p by p.CategoryID into g
                           select new
                           {
                               CategoryID = g.Key,
                               g
                           };
                foreach (var it in item)
                {
                    Console.WriteLine(it.CategoryID + " --- " + it.g.Count());
                }
            }
        }
        //select组中最大值
        [TestMethod]
        public void Test3()
        {
            using (var db = dbConfiguration.CreateDbContext())
            {
                var item = from p in db.Set<Products>()
                           group p by p.CategoryID into g
                           select new
                           {
                               g.Key,
                               MaxPrice = g.Max(p => p.UnitPrice)
                           };
                foreach (var it in item)
                {
                    Console.WriteLine(it.Key + " --- " + it.MaxPrice);
                }
            }
        }
        //select组中最小值
        [TestMethod]
        public void Test4()
        {
            using (var db = dbConfiguration.CreateDbContext())
            {
                var item = from p in db.Set<Products>()
                           group p by p.CategoryID into g
                           select new
                           {
                               g.Key,
                               MinPrice = g.Min(p => p.UnitPrice)
                           };
                foreach (var it in item)
                {
                    Console.WriteLine(it.Key + " --- " + it.MinPrice);
                }
            }
        }
        //select组中平均值
        [TestMethod]
        public void Test5()
        {
            using (var db = dbConfiguration.CreateDbContext())
            {
                var item = from p in db.Set<Products>()
                           group p by p.CategoryID into g
                           select new
                           {
                               g.Key,
                               AveragePrice = g.Average(p => p.UnitPrice)
                           };
                foreach (var it in item)
                {
                    Console.WriteLine(it.Key + " --- " + it.AveragePrice);
                }
            }
        }
        //select组中求和
        [TestMethod]
        public void Test6()
        {
            using (var db = dbConfiguration.CreateDbContext())
            {
                var item = from p in db.Set<Products>()
                           group p by p.CategoryID into g
                           select new
                           {
                               g.Key,
                               TotalPrice = g.Sum(p => p.UnitPrice)
                           };
                foreach (var it in item)
                {
                    Console.WriteLine(it.Key + " --- " + it.TotalPrice);
                }
            }
        }
        //带条件计数
        //TODO:Bug--类型“System.Linq.Queryable”上没有与提供的类型参数和参数兼容的泛型方法“Where”。如果方法是非泛型的，则不应提供类型参数。
        [TestMethod]
        public void Test7()
        {
            using (var db = dbConfiguration.CreateDbContext())
            {
                var item = from p in db.Set<Products>()
                           group p by p.CategoryID into g
                           select new
                           {
                               g.Key,
                               NumProducts = g.Count(p => p.Discontinued)
                           };
                foreach (var it in item)
                {
                    Console.WriteLine(it.Key + " --- " + it.NumProducts);
                }
            }
        }
        //where限制
        [TestMethod]
        public void Test8()
        {
            using (var db = dbConfiguration.CreateDbContext())
            {
                var item = from p in db.Set<Products>()
                           group p by p.CategoryID into g
                           where g.Count() >= 10
                           select new
                           {
                               g.Key,
                               ProductCount = g.Count()
                           };
                foreach (var it in item)
                {
                    Console.WriteLine(it.Key + " --- " + it.ProductCount);
                }
            }
        }
        //多列
        [TestMethod]
        public void Test9()
        {
            using (var db = dbConfiguration.CreateDbContext())
            {
                var item = from p in db.Set<Products>()
                           group p by new
                           {
                               p.CategoryID,
                               p.SupplierID
                           }
                               into g
                               select new
                               {
                                   g.Key,
                                   g
                               };
                foreach (var it in item)
                {
                    Console.WriteLine(it.Key + " --- " + it.g);
                }
            }
        }
        //表达式
        [TestMethod]
        public void Test10()
        {
            using (var db = dbConfiguration.CreateDbContext())
            {
                var item = from p in db.Set<Products>()
                           group p by new
                           {
                               Criterion = p.UnitPrice > 10
                           } into g
                           select new
                           {
                               g.Key,
                               g
                           };
                foreach (var it in item)
                {
                    Console.WriteLine(it.Key + " --- " + it.g);
                }
            }
        }
    }
}
