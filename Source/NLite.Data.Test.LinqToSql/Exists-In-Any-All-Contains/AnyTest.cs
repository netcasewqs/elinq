using System;
using System.Linq;
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestMethod = NUnit.Framework.TestAttribute;

namespace NLite.Data.Test.LinqToSql.Exists_In_Any_All_Contains
{
    [TestClass]
    public class AnyTest : DLinqConnection
    {
        //简单形式
        [TestMethod]
        public void test1()
        {
            using (var db = dbConfiguration.CreateDbContext())
            {
                var item = from c in db.Set<Customers>()
                           where !c.Orders.Any()
                           select c;
                foreach (var it in item)
                {
                    Console.WriteLine(it.Region);
                }
            }
        }
        //带条件形式
        [TestMethod]
        public void test2()
        {
            using (var db = dbConfiguration.CreateDbContext())
            {
                var item = from c in db.Set<Customers>()
                           where c.Orders.Any(p => p.ShipVia == 0)
                           select c;
                foreach (var it in item)
                {
                    Console.WriteLine(it.CompanyName);
                }
            }
        }
    }
}
