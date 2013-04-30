using System;
using System.Linq;
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestMethod = NUnit.Framework.TestAttribute;

namespace NLite.Data.Test.LinqToSql.OrderBy
{
    [TestClass]
    public class OrderByTest1 : DLinqConnection
    {
        [TestMethod]
        public void Test1()
        {
            using (var db = dbConfiguration.CreateDbContext())
            {
                var item = db.Set<Orders>().OrderBy(p => p.OrderDate).Select(p => p);
                foreach (var it in item)
                {
                    Console.WriteLine(it);
                }
            }
        }
    }
}
