using System;
using System.Linq;
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestMethod = NUnit.Framework.TestAttribute;

namespace NLite.Data.Test.LinqToSql
{
    [TestClass]
    public class SelectTest1 : DLinqConnection
    {
        //简单用法
        [TestMethod]
        public void Test1()
        {
            using (var db = dbConfiguration.CreateDbContext())
            {
                var item = db.Set<Customers>().Select(p => p.Country);
                foreach (var it in item)
                {
                    Console.WriteLine(it.ToString());
                }
            }
        }
        //匿名类型形式
        [TestMethod]
        public void Test2()
        {
            using (var db = dbConfiguration.CreateDbContext())
            {
                var item = db.Set<Customers>().Select(p => new { p.Country, p.CompanyName });
                foreach (var it in item)
                {
                    Console.WriteLine(it.CompanyName + " In " + it.Country);
                }
            }
        }
        [TestMethod]
        public void Test3()
        {
            using (var db = dbConfiguration.CreateDbContext())
            {
                var item = db.Set<Customers>().Select(p => new { CountyName = p.Country, CompanyNames = p.CompanyName + " In " + p.Country });
                foreach (var it in item)
                {
                    Console.WriteLine(it.CompanyNames);
                }
            }
        }
        [TestMethod]
        public void Test4()
        {
            using (var db = dbConfiguration.CreateDbContext())
            {
                var item = db.Set<Customers>().Select(p => new { CompanyNames = p.CompanyName + " In " + p.Country, p.Country });
                foreach (var it in item)
                {
                    Console.WriteLine(it.CompanyNames);
                    Console.WriteLine(it.Country);
                }
            }
        }
    }
}
