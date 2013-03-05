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
    public class ContainTest:DLinqConnection
    {
        [TestMethod]
        public void test1()
        {
            string[] customerID_Set = new string[] {
               "AROUT","BOLID","FISSA"};
            using (var db = dbConfiguration.CreateDbContext())
            {
                var item = from o in db.Set<Orders>()
                           where customerID_Set.Contains(o.CustomerID)
                           select o;
                foreach (var it in item)
                {
                    Console.WriteLine(it.CustomerID);
                }
            }
        }
        [TestMethod]
        public void test2()
        {
            //string[] customerID_Set = new string[] {
            //   "AROUT","BOLID","FISSA"};
            using (var db = dbConfiguration.CreateDbContext())
            {
                var item = from o in db.Set<Orders>()
                           where !(new string[]{"AROUT","BOLID","FISSA"})
                           .Contains(o.CustomerID)
                           select o;
                foreach (var it in item)
                {
                    Console.WriteLine(it.CustomerID);
                }
            }
        }
        //包含一个对象
        //TODO:Bug-- Not support 'NLite.Data.Test.LinqToSql.Orders' for sql type.
        [TestMethod]
        public void test3()
        {
            using (var db = dbConfiguration.CreateDbContext())
            {
                var order = (from o in db.Set<Orders>()
                             where o.OrderID == 10248
                             select o).First();
                var item = from c in db.Set<Customers>()
                           where c.Orders.Any(p=>p.OrderID == order.OrderID)
                           select c;
                foreach (var it in item)//
                {
                    Console.WriteLine(it);
                }
            }
            //using (var db = new DataClasses1DataContext())
            //{
            //    db.Log = Console.Out;
            //    var order = (from o in db.Orders
            //                 where o.OrderID == 10248
            //                 select o).First();
            //    var item = from c in db.Customers
            //               where c.Orders.Contains(order)
            //               select c;
            //    foreach (var it in item)//
            //    {
            //        Console.WriteLine(it);
            //    }
            //}
        }
        [TestMethod]
        public void test4()
        {
            string[] cities = new string[] {
               "Seattle","London","Vancouver","Paris"};
            using (var db = dbConfiguration.CreateDbContext())
            {
                var item = from o in db.Set<Customers>()
                           where cities.Contains(o.City)
                           select o;
                foreach (var it in item)
                {
                    Console.WriteLine(it.CompanyName+" --- "+it.City);
                }
            }
        }
    }
}
