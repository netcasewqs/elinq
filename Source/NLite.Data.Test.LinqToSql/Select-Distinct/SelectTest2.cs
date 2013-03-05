using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestInitialize = NUnit.Framework.SetUpAttribute;
using TestMethod = NUnit.Framework.TestAttribute;

namespace NLite.Data.Test.LinqToSql.Select_Distinct
{
   
    [TestClass]
    public class SelectTest2:DLinqConnection
    {
        //条件形式
        [TestMethod]
        public void Test1()
        {
            using (var db = dbConfiguration.CreateDbContext())
            {
                var item = db.Set<Customers>().Select(p => new { p.CompanyName,Touch =p.Fax==null?"电话"+p.Phone:"传真"+p.Fax});
                foreach (var it in item)
                {
                    Console.WriteLine(it.Touch);
                }
            }
        }
        //指定类型形式
        [TestMethod]
        public void Test2()
        {
            using (var db = dbConfiguration.CreateDbContext())
            {
                var item = db.Set<Customers>().Select(p => new Name { FirstName = p.Country, SecondName=p.CompanyName});
                foreach (var it in item)
                {
                    Console.WriteLine(it.FirstName+" : "+it.SecondName);
                }
            }
        }
        //筛选形式
        [TestMethod]
        public void Test3()
        {
            using (var db = dbConfiguration.CreateDbContext())
            {
                var item = db.Set<Customers>().Where(p=>p.City=="London").Select(p=>p.CompanyName);
                foreach (var it in item)
                {
                    Console.WriteLine(it);
                }
            }
        }
        //shaped形式(整型类型)
        [TestMethod]
        public void Test4()
        {
            using (var db = dbConfiguration.CreateDbContext())
            {
                var item = db.Set<Customers>().Select(p => new { p.CustomerID, CompanyInfo = new { p.CompanyName, p.City, p.Country }, ContactInfo = new {p.ContactName,p.ContactTitle} });
                foreach (var it in item)
                {
                    Console.WriteLine(it.ContactInfo);
                }
            }
        }
        //TODO:Bug:嵌套类型  error: 无法绑定由多个部分组成的标识符 "ut1.CustomerID"。
        [TestMethod]
        public void Test5()
        {
            using (var db = dbConfiguration.CreateDbContext())
            {
                var item = db.Set<Customers>()//.Include(p => p.Orders)
                    .Select(p => new
                    {
                        p.CustomerID,
                        p.CompanyName,
                        OrderCount = p.Orders.Where(s => s.ShipCountry == "UK")//.Select(s => s.ShipCity).Count()
                    });

                foreach (var it in item)
                {
                    Console.WriteLine(it.OrderCount);
                }
            }

            using (var db = new DataClasses1DataContext())
            {
                db.Log = Console.Out;
                var item = db.Customers//.Include(p => p.Orders)
                    .Select(p => new
                    {
                       // p.CustomerID,
                        p.CompanyName,
                        OrderCount = p.Orders.Where(s => s.ShipCountry == "UK")//.Select(s => s.ShipCity).Count()
                    });

                foreach (var it in item)
                {
                    Console.WriteLine(it.OrderCount);
                }
            }
        }
        //本地方法调用形式(LocalMethodCall)
        [TestMethod]
        public void Test6()
        {
            using (var db = dbConfiguration.CreateDbContext())
            {
                var item = db.Set<Customers>().Where(p => p.Fax != null).Select(p => new { p.CompanyName,p.Phone,Internation =p.Phone.Replace("-","")});
                foreach (var it in item)
                {
                    Console.WriteLine(it.Internation);
                }
            }
        }
        //Distinct形式
        [TestMethod]
        public void Test7()
        {
            using (var db = dbConfiguration.CreateDbContext())
            {
                var item = db.Set<Customers>().Select(p=>p.Country).Distinct();
                foreach (var it in item)
                {
                    Console.WriteLine(it);
                }
            }
        }
        //Distinct形式
        [TestMethod]
        public void Test8()
        {
            using (var db = dbConfiguration.CreateDbContext())
            {
                var item = db.Set<Customers>().Select(p => p.Country).Distinct().Count();
                var item2 = db.Set<Customers>().Select(p => p.Country).Count();
                Console.WriteLine(item+"////"+item2);
            }
        }
    }

    public class Name
    {
        public string FirstName;
        public string SecondName;
    }
}
