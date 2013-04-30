using System;
using System.Linq;
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestMethod = NUnit.Framework.TestAttribute;

namespace NLite.Data.Test.LinqToSql.Count_Sun_Min_Max_Avg
{
    [TestClass]
    public class SumTest : DLinqConnection
    {
        //简单形式
        [TestMethod]
        public void Test1()
        {
            using (var db = dbConfiguration.CreateDbContext())
            {
                var item = db.Set<Orders>().Select(p => p.ShipVia).Sum();
                Console.WriteLine(item);
            }
        }
        //映射形式
        [TestMethod]
        public void Test2()
        {
            using (var db = dbConfiguration.CreateDbContext())
            {
                var item = db.Set<Orders>().Sum(p => p.ShipVia);
                Console.WriteLine(item);
            }
        }
        //带条件的映射形式
        [TestMethod]
        public void Test3()
        {
            using (var db = dbConfiguration.CreateDbContext())
            {
                var item = db.Set<Orders>().Where(p => p.ShipCountry == "UK").Sum(p => p.ShipVia);
                Console.WriteLine(item);
            }
        }
    }
}
