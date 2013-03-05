using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestInitialize = NUnit.Framework.SetUpAttribute;
using TestMethod = NUnit.Framework.TestAttribute;

namespace NLite.Data.Test.LinqToSql.Concat_Union_Intersect_Except
{
    [TestClass]
    public class ConcatTest:DLinqConnection
    {
        //简单形式
        [TestMethod]
        public void ConcatTest1()
        {
            using (var db = dbConfiguration.CreateDbContext())
            {
                var item = (from c in db.Set<Customers>()
                            select c.Phone)
                           .Concat(
                           from c in db.Set<Customers>()
                           select c.Fax)
                           .Concat(
                           from e in db.Set<Employees>()
                           select e.HomePhone
                           );
                foreach (var it in item)
                {
                    Console.WriteLine(it);
                }
            }
        }
        //复合形式
        [TestMethod]
        public void ConcatTest2()
        {
            using (var db = dbConfiguration.CreateDbContext())
            {
                var item = (from c in db.Set<Customers>()
                            select new
                            {
                                Name = c.CompanyName
                                ,
                                c.Phone
                            }).Concat(
                           from e in db.Set<Employees>()
                           select new
                           {
                               Name= e.FirstName+" "+e.LastName,
                               Phone = e.HomePhone
                           });
                foreach (var it in item)
                {
                    Console.WriteLine(it.Name+" -- "+it.Phone);
                }
            }
        }
        //简单形式
        [TestMethod]
        public void UnionTest()
        {
            using (var db = dbConfiguration.CreateDbContext())
            {
                var item = (from c in db.Set<Customers>()
                            select c.Country)
                           .Union(
                           from e in db.Set<Employees>()
                           select e.Country
                           );
                foreach (var it in item)
                {
                    Console.WriteLine(it);
                }
            }
        }
        //简单形式
        [TestMethod]
        public void IntersectTest()
        {
            using (var db = dbConfiguration.CreateDbContext())
            {
                var item = (from c in db.Set<Customers>()
                            select c.Country)
                           .Intersect(
                           from e in db.Set<Employees>()
                           select e.Country
                           );
                foreach (var it in item)
                {
                    Console.WriteLine(it);
                }
            }
        }
        //简单形式
        [TestMethod]
        public void ExceptTest()
        {
            using (var db = dbConfiguration.CreateDbContext())
            {
                var item = (from c in db.Set<Customers>()
                            select c.Country)
                           .Except(
                           from e in db.Set<Employees>()
                           select e.Country
                           );
                foreach (var it in item)
                {
                    Console.WriteLine(it);
                }
            }
        }
    }
}
