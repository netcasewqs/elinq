using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestInitialize = NUnit.Framework.SetUpAttribute;
using TestMethod = NUnit.Framework.TestAttribute;

namespace NLite.Data.Test.LinqToSql.Join
{
    [TestClass]
    public class JoinTest2 : DLinqConnection
    {
        //自连接
        [TestMethod]
        public void test1()
        {
            using (var db = dbConfiguration.CreateDbContext())
            {
                var item = db.Set<Employees>().Include(p => p.Employees1)
                    .Select(p => new { FirstName1 = p.FirstName, LastName1 = p.LastName, FirstName2 = p.Employees1.FirstName, LastName2 = p.Employees1.LastName });
                foreach (var it in item)
                {
                    Console.WriteLine(it.FirstName1 + " *** " + it.FirstName2);
                }
            }
        }
        //双向连接
        //三向连接
        //左外部连接
        //投影的Let赋值
        //组合键
        //可为null/不可为null的键关系

        [TestMethod]
        public void LetTest()
        {
            using (var db = dbConfiguration.CreateDbContext())
            {
                var q =
                        from c in db.Set<Customers>()
                        join o in db.Set<Orders>() on c.CustomerID
                        equals o.CustomerID into ords
                        let z = c.City + c.Country
                        from o in ords
                        select new
                        {
                            c.ContactName,
                            o.OrderID,
                            z
                        };

                foreach (var item in q)
                {
                    Console.WriteLine(item.ContactName + "\t" + item.OrderID + "\t" + item.z);
                }
            }
        }
    }
}
