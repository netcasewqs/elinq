using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestInitialize = NUnit.Framework.SetUpAttribute;
using TestMethod = NUnit.Framework.TestAttribute;

namespace NLite.Data.Test.LinqToSql.Exists_In_Any_All_Contains
{
    [TestClass]
    public class AllTest:DLinqConnection
    {
        [TestMethod]
        public void test1()
        {
            using (var db = dbConfiguration.CreateDbContext())
            {
                var item = from c in db.Set<Customers>()
                           where c.Orders.All(o=>o.ShipCity==c.City)
                           select c;
                foreach (var it in item)
                {
                    Console.WriteLine(it.Region);
                }
            }
        }
    }
}
