using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using NLite.Data.Test.Model.Northwind;
using NUnit.Framework;

namespace NLite.Data.Test.Core
{
    [TestFixture]
    public class InsertTest
    {
        static readonly DbConfiguration cfg = DbConfiguration
                .Configure("Northwind")
                .SetSqlLogger(() => new SqlLog(Console.Out))
                .AddClass<Customer>(e =>
                    {
                        //e.TableName("Customers");
                        e.Id(p => p.CustomerID);
                        e.Column(p => p.CompanyName);
                    })
                .AddClass<Order>();


        //标准PO对象插入
        [Test]
        public void PO()
        {
            //1. 创建PO对象
            Customer c = new Customer
            {
                CustomerID = "XX1",
                CompanyName = "Company1",
                ContactName = "Contact1",
                City = "Seattle",
                Country = "USA"
            };

            //2. 创建DbContext 对象
            using (var db = cfg.CreateDbContext())
            {
                //3. 创建DbSet对象
                var q = db.Set<Customer>();

                //4. 删除所有以“XX”开头的CustomerID记录
                q.Delete(p => p.CustomerID.StartsWith("XX"));

                //5. 执行PO插入
                q.Insert(c);

                //6. 从数据库中查找指定CustomerID 的PO对象
                var c2 = q.Get(c.CustomerID);
                Assert.IsNotNull(c2);
                Assert.AreNotSame(c, c2);

                Assert.AreEqual(c.CustomerID, c2.CustomerID);
                Assert.AreEqual(c.CompanyName, c2.CompanyName);
                Assert.AreEqual(c.ContactName, c2.ContactName);
                Assert.AreEqual(c.City, c2.City);
                Assert.AreEqual(c.Country, c2.Country);


                q.Delete(c);
            }
        }

        //匿名对象插入
        [Test]
        public void Anonymous()
        {
            //1. 创建匿名对象
            var c = new
            {
                CustomerID = "XX1",
                CompanyName = "Company1",
                ContactName = "Contact1",
                City = "Seattle",
                Country = "USA"
            };

            //2. 创建DbContext 对象
            using (var db = cfg.CreateDbContext())
            {
                //3. 创建DbSet对象
                var cusotmers = db.Set<Customer>();

                //4. 删除所有以“XX”开头的CustomerID记录
                cusotmers.Delete(p => p.CustomerID.StartsWith("XX"));

                //5. 执行匿名对象插入
                cusotmers.Insert(c);

                //6. 从数据库中查找指定CustomerID 的PO对象
                var c2 = cusotmers.Get(c.CustomerID);
                Assert.IsNotNull(c2);

                Assert.AreEqual(c.CustomerID, c2.CustomerID);
                Assert.AreEqual(c.CompanyName, c2.CompanyName);
                Assert.AreEqual(c.ContactName, c2.ContactName);
                Assert.AreEqual(c.City, c2.City);
                Assert.AreEqual(c.Country, c2.Country);


                cusotmers.Delete(c);
            }
        }

        //Dictionary对象插入
        [Test]
        public void Hashtable()
        {
            //1. 创建匿名对象
            var c = new Hashtable();
            c["CustomerID"] = "XX1";
            c["CompanyName"] = "Company1";
            c["ContactName"] = "Contact1";
            c["City"] = "Seattle";
            c["Country"] = "USA";

            //2. 创建DbContext 对象
            using (var db = cfg.CreateDbContext())
            {
                //3. 创建DbSet对象
                var cusotmers = db.Set<Customer>();

                //4. 删除所有以“XX”开头的CustomerID记录
                cusotmers.Delete(p => p.CustomerID.StartsWith("XX"));

                //5. 执行匿名对象插入
                cusotmers.Insert(c);

                //6. 从数据库中查找指定CustomerID 的PO对象
                var c2 = cusotmers.Get(c["CustomerID"]);
                Assert.IsNotNull(c2);

                Assert.AreEqual(c["CustomerID"], c2.CustomerID);
                Assert.AreEqual(c["CompanyName"], c2.CompanyName);
                Assert.AreEqual(c["ContactName"], c2.ContactName);
                Assert.AreEqual(c["City"], c2.City);
                Assert.AreEqual(c["Country"], c2.Country);


                cusotmers.Delete(c);
            }
        }

        //Dictionary对象插入
        [Test]
        public void GenericDictionary()
        {
            //1. 创建匿名对象
            var c = new Dictionary<string, object>();
            c["CustomerID"] = "XX1";
            c["CompanyName"] = "Company1";
            c["ContactName"] = "Contact1";
            c["City"] = "Seattle";
            c["Country"] = "USA";

            //2. 创建DbContext 对象
            using (var db = cfg.CreateDbContext())
            {
                //3. 创建DbSet对象
                var cusotmers = db.Set<Customer>();

                //4. 删除所有以“XX”开头的CustomerID记录
                cusotmers.Delete(p => p.CustomerID.StartsWith("XX"));

                //5. 执行匿名对象插入
                cusotmers.Insert(c);

                //6. 从数据库中查找指定CustomerID 的PO对象
                var c2 = cusotmers.Get(c["CustomerID"]);
                Assert.IsNotNull(c2);

                Assert.AreEqual(c["CustomerID"], c2.CustomerID);
                Assert.AreEqual(c["CompanyName"], c2.CompanyName);
                Assert.AreEqual(c["ContactName"], c2.ContactName);
                Assert.AreEqual(c["City"], c2.City);
                Assert.AreEqual(c["Country"], c2.Country);


                cusotmers.Delete(c);
            }
        }

        //Dictionary对象插入
        [Test]
        public void NameValueCollection()
        {
            //1. 创建匿名对象
            var c = new NameValueCollection();
            c["CustomerID"] = "XX1";
            c["CompanyName"] = "Company1";
            c["ContactName"] = "Contact1";
            c["City"] = "Seattle";
            c["Country"] = "USA";

            //2. 创建DbContext 对象
            using (var db = cfg.CreateDbContext())
            {
                //3. 创建DbSet对象
                var cusotmers = db.Set<Customer>();

                //4. 删除所有以“XX”开头的CustomerID记录
                cusotmers.Delete(p => p.CustomerID.StartsWith("XX"));

                //5. 执行匿名对象插入
                cusotmers.Insert(c);

                //6. 从数据库中查找指定CustomerID 的PO对象
                var c2 = cusotmers.Get(c["CustomerID"]);
                Assert.IsNotNull(c2);

                Assert.AreEqual(c["CustomerID"], c2.CustomerID);
                Assert.AreEqual(c["CompanyName"], c2.CompanyName);
                Assert.AreEqual(c["ContactName"], c2.ContactName);
                Assert.AreEqual(c["City"], c2.City);
                Assert.AreEqual(c["Country"], c2.Country);


                cusotmers.Delete(c);
            }
        }

        //主键是自动增一的实体插入（Oracle数据表通过序列和触发器的方式，约定的Oracle序列必须是全局的，序列名称是：NEXTID
        public void InsertWithPrimaryKey_IsDbGenerated()
        {
            //1. 创建PO对象
            Customer c = new Customer
            {
                CustomerID = "XX1",
                CompanyName = "Company1",
                ContactName = "Contact1",
                City = "Seattle",
                Country = "USA"
            };

            var order = new Order
            {
                CustomerID = c.CustomerID,
                OrderDate = DateTime.Now,
            };

            //2. 创建DbContext 对象
            using (var db = cfg.CreateDbContext())
            {
                //3. 创建DbSet对象
                var cusotmers = db.Set<Customer>();
                var orders = db.Set<Order>();

                //4. 删除所有以“XX”开头的CustomerID记录
                orders.Delete(p => p.CustomerID.StartsWith("XX"));
                cusotmers.Delete(p => p.CustomerID.StartsWith("XX"));

                //在订单插入前，OrderId= 0
                Assert.IsTrue(order.OrderID == 0);

                //5. 执行PO插入
                cusotmers.Insert(c);
                orders.Insert(order);

                //在订单插入前，OrderId> 0
                Assert.IsTrue(order.OrderID > 0);

                orders.Delete(order);
                cusotmers.Delete(c);
            }
        }

        //批量插入集合
        public void BatchInsert()
        {
            int n = 10;
            var custs = Enumerable.Range(1, n).Select(
                i => new
                {
                    CustomerID = "XX" + i,
                    CompanyName = "Company" + i,
                    ContactName = "Contact" + i,
                    City = "Seattle",
                    Country = "USA"
                });
            using (var db = cfg.CreateDbContext())
            {
                var customers = db.Set<Customer>();

                //批量删除所有以“XX”开头的CustomerID记录
                customers.Delete(p => p.CustomerID.StartsWith("XX"));

                //批量添加
                var results = customers.Batch(custs, (u, c) => u.Insert(c));

                //测试每个实体添加后的状态都是1（1表示成功，0 表示失败）
                foreach (var r in results)
                    Assert.AreEqual(1, r);

                var customerIds = custs.Select(c => c.CustomerID).ToArray();
                //批量删除通过In的方式
                customers.Delete(p => customerIds.Contains(p.CustomerID));
            }
        }

    }
}
