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
    public class DeleteTest
    {
        static readonly DbConfiguration cfg = DbConfiguration
               .Configure("Northwind")
               .SetSqlLogger(() => new SqlLog(Console.Out))
               .AddClass<Customer>()
               .AddClass<Order>();

        [Test]
        public void DeleteByPO()
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
                var cusotmers = db.Set<Customer>();

                //4. 删除所有以“XX”开头的CustomerID记录
                cusotmers.Delete(p => p.CustomerID.StartsWith("XX"));

                //5. 执行PO插入
                cusotmers.Insert(c);
                //6. 删除PO对象
                cusotmers.Delete(c);
            }
        }

        [Test]
        public void DeleteByID_with_Anonymous_object()
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
                var cusotmers = db.Set<Customer>();

                //4. 删除所有以“XX”开头的CustomerID记录
                cusotmers.Delete(p => p.CustomerID.StartsWith("XX"));

                //5. 执行PO插入
                cusotmers.Insert(c);
                //6. 通过CustomerID 进行删除
                cusotmers.Delete(new { CustomerID = c.CustomerID });
            }
        }

        [Test]
        public void DeleteByID_with_Hashtable()
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
                var cusotmers = db.Set<Customer>();

                //4. 删除所有以“XX”开头的CustomerID记录
                cusotmers.Delete(p => p.CustomerID.StartsWith("XX"));

                //5. 执行PO插入
                cusotmers.Insert(c);
                //6. 通过CustomerID 进行删除
                var hashTable = new Hashtable();
                hashTable["customerId"] = c.CustomerID;

                cusotmers.Delete(hashTable);
            }
        }

        [Test]
        public void DeleteByID_with_Dictionary()
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
                var cusotmers = db.Set<Customer>();

                //4. 删除所有以“XX”开头的CustomerID记录
                cusotmers.Delete(p => p.CustomerID.StartsWith("XX"));

                //5. 执行PO插入
                cusotmers.Insert(c);
                //6. 通过CustomerID 进行删除
                var dict = new Dictionary<string, object>();
                dict["customerId"] = c.CustomerID;

                cusotmers.Delete(dict);
            }
        }


        [Test]
        public void DeleteByID_with_NameValueCollection()
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
                var cusotmers = db.Set<Customer>();

                //4. 删除所有以“XX”开头的CustomerID记录
                cusotmers.Delete(p => p.CustomerID.StartsWith("XX"));

                //5. 执行PO插入
                cusotmers.Insert(c);
                //6. 通过CustomerID 进行删除
                var dict = new NameValueCollection();
                dict["customerId"] = c.CustomerID;

                cusotmers.Delete(dict);
            }
        }

        [Test]
        public void DeleteByID_with_expression()
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
                var cusotmers = db.Set<Customer>();

                //4. 批量删除所有以“XX”开头的CustomerID记录
                cusotmers.Delete(p => p.CustomerID.StartsWith("XX"));

                //5. 执行PO插入
                cusotmers.Insert(c);
                //6. 通过CustomerID 进行删除
                cusotmers.Delete(m => m.CustomerID == c.CustomerID);
            }
        }

        //批量删除，通过Linq表达式-Like 
        [Test]
        public void BatchDelete_with_expression_like()
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

                //批量添加
                var results = customers.Batch(custs, (u, c) => u.Insert(c));

                //批量删除所有以“XX”开头的CustomerID记录
                customers.Delete(p => p.CustomerID.StartsWith("XX"));
            }
        }

        //批量删除，通过Linq表达式-In
        [Test]
        public void BatchDelete_with_expression_in()
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
                var expectedCount = customers.Count();

                //批量添加
                var results = customers.Batch(custs, (u, c) => u.Insert(c));

                var customerIds = custs.Select(c => c.CustomerID).ToArray();
                //批量删除通过In的方式
                customers.Delete(p => customerIds.Contains(p.CustomerID));

                var actualCount = customers.Count();
                Assert.AreEqual(expectedCount, actualCount);
            }
        }

        //批量删除，通过集合PO对象方式
        [Test]
        public void BatchDelete_with_Batch_POList()
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

                var expectedCount = customers.Count();

                //批量添加
                var results = customers.Batch(custs, (u, c) => u.Insert(c));

                var customerIds = custs.Select(c => c.CustomerID).ToArray();
                //批量删除通过In的方式
                customers.Batch(custs, (u, c) => u.Delete(c));

                var actualCount = customers.Count();
                Assert.AreEqual(expectedCount, actualCount);
            }
        }

    }
}
