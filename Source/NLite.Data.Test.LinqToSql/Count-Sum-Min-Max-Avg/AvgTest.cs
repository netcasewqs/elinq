using System;
using System.Linq;
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestMethod = NUnit.Framework.TestAttribute;


namespace NLite.Data.Test.LinqToSql.Count_Sun_Min_Max_Avg
{
    [TestClass]
    public class AvgTest : DLinqConnection
    {
        //简单形式
        [TestMethod]
        public void test1()
        {
            using (var db = dbConfiguration.CreateDbContext())
            {
                var item = db.Set<Orders>().Select(p => p.Freight).Average();
                Console.WriteLine(item);
            }
        }
        //映射形式
        [TestMethod]
        public void Test2()
        {
            using (var db = dbConfiguration.CreateDbContext())
            {
                var item = db.Set<Orders>().Average(p => p.Freight);
                Console.WriteLine(item);
            }
        }
        //带条件的映射形式
        [TestMethod]
        public void Test3()
        {
            using (var db = dbConfiguration.CreateDbContext())
            {
                var item = db.Set<Orders>().Where(p => p.ShipCountry == "UK").Average(p => p.Freight);
                Console.WriteLine(item);
            }
        }
    }
}
