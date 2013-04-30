using System;
using System.Linq;
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestMethod = NUnit.Framework.TestAttribute;

namespace NLite.Data.Test.LinqToSql.Top_Bottom_Paging_SqlMethods
{
    [TestClass]
    public class TakeTest1 : DLinqConnection
    {
        //Take
        [TestMethod]
        public void TakeTest()
        {
            using (var db = dbConfiguration.CreateDbContext())
            {
                var item = (from e in db.Set<Employees>()
                            orderby e.HireDate
                            select e)
                           .Take(5);
                foreach (var it in item)
                {
                    Console.WriteLine(it.Extension);
                }
            }
        }
        //Skip
        [TestMethod]
        public void SkipTest1()
        {
            using (var db = dbConfiguration.CreateDbContext())
            {
                var item = (from p in db.Set<Products>()
                            orderby p.UnitPrice descending
                            select p)
                           .Skip(5);
                foreach (var it in item)
                {
                    Console.WriteLine(it.ProductName);
                }
            }
        }
        [TestMethod]
        public void SkipTest2()
        {
            using (var db = dbConfiguration.CreateDbContext())
            {
                var item = (from p in db.Set<Products>()
                            orderby p.UnitPrice descending
                            select p)
                           .Skip(5)
                           .Take(10);
                foreach (var it in item)
                {
                    Console.WriteLine(it.ProductName);
                }
            }
        }
        //        //TakeWhile
        //        //TODO:Bug------ 调试断言失败 ----
        ////---- 断言短消息 ----
        ////column not in scope: A:2.C(UnitPrice)
        ////---- 断言长消息 ----
        //        [TestMethod]
        //        public void TakeWhileTest1()
        //        {
        //            using (var db = dbConfiguration.CreateDbContext())
        //            {
        //                var item = (from p in db.Set<Products>()
        //                            select p)
        //                           .TakeWhile(p=>p.UnitPrice>5);
        //                foreach (var it in item)
        //                {
        //                    Console.WriteLine(it.ProductName+" -- "+it.UnitPrice);
        //                }
        //            }
        //        }
        //        //SkipWhile
        //        //TODO:Bug------ 调试断言失败 ----
        ////---- 断言短消息 ----
        ////column not in scope: A:2.C(UnitPrice)
        ////---- 断言长消息 ----
        //        [TestMethod]
        //        public void SkipWhileTest1()
        //        {
        //            using (var db = dbConfiguration.CreateDbContext())
        //            {
        //                var item = (from p in db.Set<Products>()
        //                            select p)
        //                           .SkipWhile(p => p.UnitPrice > 5);
        //                foreach (var it in item)
        //                {
        //                    Console.WriteLine(it.ProductName + " -- " + it.UnitPrice);
        //                }
        //            }
        //        }
    }
}
