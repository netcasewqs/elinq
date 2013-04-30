using System;
using System.Linq;
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestMethod = NUnit.Framework.TestAttribute;

namespace NLite.Data.Test.LinqToSql.Where
{
    [TestClass]
    //First()形式
    public class WhereTest3 : DLinqConnection
    {
        [TestMethod]
        public void FirstTest1()
        {
            using (var db = dbConfiguration.CreateDbContext())
            {
                var item = db.Set<Customers>().First();
                Console.WriteLine(item.Country);
            }
        }
        [TestMethod]
        public void FirstTest2()
        {
            using (var db = dbConfiguration.CreateDbContext())
            {
                var item = db.Set<Customers>().OrderBy(p => p.CustomerID).First();
                Console.WriteLine(item.Country);
            }
        }
        [TestMethod]
        public void FirstTest3()
        {
            using (var db = dbConfiguration.CreateDbContext())
            {
                var item = db.Set<Customers>().First(p => p.Country == "UK");
                Console.WriteLine(item.CompanyName);
            }
        }
        [TestMethod]
        public void FirstTest4()
        {
            using (var db = dbConfiguration.CreateDbContext())
            {
                var item = db.Set<Customers>().Include(p => p.Orders).First(p => p.Orders.Count() > 10);
                Console.WriteLine(item.Country);
            }
        }
    }
}
