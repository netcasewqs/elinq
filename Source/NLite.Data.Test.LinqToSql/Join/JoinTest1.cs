using System;
using System.Linq;
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestMethod = NUnit.Framework.TestAttribute;

namespace NLite.Data.Test.LinqToSql.Join
{
    [TestClass]
    public class JoinTest1 : DLinqConnection
    {
        [TestMethod]
        public void test1()
        {
            using (var db = dbConfiguration.CreateDbContext())
            {
                var item = from c in db.Set<Customers>()
                           from o in c.Orders
                           where c.City == "London"
                           select new { o, o.Customers };
                foreach (var it in item)
                {
                    Console.WriteLine(it.Customers.CompanyName + " --- " + it.o.OrderDate);
                }
            }
        }
        [TestMethod]
        public void test2()
        {
            //using (var db = dbConfiguration.CreateDbContext())
            //{
            //    var item = from p in 
            //    foreach (var it in item)
            //    {
            //        Console.WriteLine(it.CompanyName + " *** " + it.OrderCount);
            //    }
            //}
        }

    }
}
