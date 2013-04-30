using System;
using System.Linq;
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestMethod = NUnit.Framework.TestAttribute;

namespace NLite.Data.Test.LinqToSql.Count_Sun_Min_Max_Avg
{
    [TestClass]
    public class CountTest : DLinqConnection
    {
        //简单形式
        [TestMethod]
        public void Test1()
        {
            using (var db = dbConfiguration.CreateDbContext())
            {
                var item = db.Set<Customers>().Count();
                Console.WriteLine(item);
            }
        }
        //带条件形式
        [TestMethod]
        public void Test2()
        {
            using (var db = dbConfiguration.CreateDbContext())
            {
                var item = db.Set<Customers>().Where(p => p.CompanyName.Length >= 10).Count();
                Console.WriteLine(item);
            }
        }
        //LongCount简单形式
        [TestMethod]
        public void Test3()
        {
            using (var db = dbConfiguration.CreateDbContext())
            {
                var item = db.Set<Customers>().LongCount();
                Console.WriteLine(item);
            }
        }
        //LongCount带条件形式
        [TestMethod]
        public void Test4()
        {
            using (var db = dbConfiguration.CreateDbContext())
            {
                var item = db.Set<Customers>().Where(p => p.CompanyName.Length >= 10).LongCount();
                Console.WriteLine(item);
            }
        }
    }
}
