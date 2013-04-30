using System;
using System.Linq;
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestMethod = NUnit.Framework.TestAttribute;

namespace NLite.Data.Test.LinqToSql.Top_Bottom_Paging_SqlMethods
{
    [TestClass]
    public class PagingTest : DLinqConnection
    {
        //索引
        [TestMethod]
        public void test1()
        {
            using (var db = dbConfiguration.CreateDbContext())
            {
                var item = (from c in db.Set<Customers>()
                            orderby c.ContactName
                            select c)
                           .Skip(50)
                           .Take(10);
                foreach (var it in item)
                {
                    Console.WriteLine(it.Region);
                }
            }
        }
        //按唯一键排序
        [TestMethod]
        public void test2()
        {
            using (var db = dbConfiguration.CreateDbContext())
            {
                var item = (from p in db.Set<Products>()
                            where p.ProductID > 50
                            orderby p.ProductID
                            select p)
                           .Take(10);
                foreach (var it in item)
                {
                    Console.WriteLine(it.ProductID);
                }
            }
        }
    }
}
