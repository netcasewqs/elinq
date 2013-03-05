using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestInitialize = NUnit.Framework.SetUpAttribute;
using TestMethod = NUnit.Framework.TestAttribute;

namespace NLite.Data.Test.LinqToSql.Where
{
    [TestClass]
    //条件形式
    public class WhereTest2:DLinqConnection
    {
        [TestMethod]
        public void Test1()
        {
            using (var db = dbConfiguration.CreateDbContext())
            {
                var item = db.Set<Customers>().Where(p => p.City == "London" && p.Country == "UK");
                Console.WriteLine(item.Count());
            }
        }
        [TestMethod]
        public void Test4()
        {
            using (var db = dbConfiguration.CreateDbContext())
            {
                var item = db.Set<Customers>().Select(p=>p).Where(p => p.City == "London" && p.Country == "UK");
                Console.WriteLine(item.Count());
            }
        }
        [TestMethod]
        public void Test2()
        {
            using (var db = dbConfiguration.CreateDbContext())
            {
                var item = db.Set<Customers>().Where(p => p.City == "London" || p.Country == "UK");
                Console.WriteLine(item.Count());
            }
        }
        [TestMethod]
        public void Test5()
        {
            using (var db = dbConfiguration.CreateDbContext())
            {
                var item = db.Set<Customers>().Select(p => p).Where(p => p.City == "London" || p.Country == "UK");
                Console.WriteLine(item.Count());
            }
        }
        [TestMethod]
        public void Test3()
        {
            using (var db = dbConfiguration.CreateDbContext())
            {
                var item = db.Set<Customers>().Where(p => p.City != "London" );
                Console.WriteLine(item.Count());
            }
        }
        [TestMethod]
        public void Test6()
        {
            using (var db = dbConfiguration.CreateDbContext())
            {
                var item = db.Set<Customers>().Select(p => p).Where(p => p.City != "London");
                Console.WriteLine(item.Count());
            }
        }
        [TestMethod]
        public void Test7()
        {
            using (var db = dbConfiguration.CreateDbContext())
            {
                var item = db.Set<Customers>().Where(p => p.City != "London").Where(p=>p.Country=="UK");
                Console.WriteLine(item.Count());
            }
        }
        [TestMethod]
        public void Test8()
        {
            using (var db = dbConfiguration.CreateDbContext())
            {
                var item = db.Set<Customers>().Select(p=>p).Where(p => p.City != "London").Where(p => p.Country == "UK");
                Console.WriteLine(item.Count());
            }
        }
    }
}
