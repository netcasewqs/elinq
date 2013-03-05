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
    //简单形式
    public class WhereTest1 : DLinqConnection
    {
        [TestMethod]
        public void Test1()
        {
            using (var db = dbConfiguration.CreateDbContext())
            {
                var item = db.Set<Customers>().Where(p=>p.City=="London");
                Console.WriteLine(item.Count());
            }
        }
        [TestMethod]
        public void Test2()
        {
            using (var db = dbConfiguration.CreateDbContext())
            {
                var item = db.Set<Customers>().Select(p=>p).Where(p => p.City == "London");
                Console.WriteLine(item.Count());
            }
        }
        [TestMethod]
        public void Test3()
        {
            using (var db = dbConfiguration.CreateDbContext())
            {
                var item = db.Set<Customers>().Select(p=>p.City).Where(p => p == "London");
                Console.WriteLine(item.FirstOrDefault().ToString());
            }
        }
        [TestMethod]
        public void Test4()
        {
            using (var db = dbConfiguration.CreateDbContext())
            {
                var item = db.Set<Customers>().Select(p => p).Where(p => p.City == null);
                Console.WriteLine(item.Count());
            }
        }
    }
}
