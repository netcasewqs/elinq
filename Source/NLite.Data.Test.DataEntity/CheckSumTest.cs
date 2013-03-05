using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestInitialize = NUnit.Framework.SetUpAttribute;
using TestMethod = NUnit.Framework.TestAttribute;
using System.Data.Objects;
using System.Data.Objects.SqlClient;

namespace NLite.Data.Test.DataEntity
{
    [TestClass]
    public class CheckSumTest
    {
        [TestMethod]
        public void test1()
        {
            Guid? guid1 = new Guid("4A83D44A-5612-4E78-89EE-08F894912C0A");
            Guid? guid2 = new Guid("4A83D44A-5612-4E78-89EE-08F894912C0A");
            Guid? guid3 = new Guid("4A83D44A-5612-4E78-89EE-08F894912C0A");
            using (var edm = new NorthwindEntities())
            {
               var cust1 =from c in edm.Customers
                          where SqlFunctions.Checksum(guid1,guid2,guid3)>=-1
                          select c;
               //WHERE (CHECKSUM(@p__linq__0, @p__linq__1, @p__linq__2)) >= -1
               cust1.TraceSql();
               Console.WriteLine();
            }
        }
        [TestMethod]
        public void test2()
        {
            var arr1 = BitConverter.GetBytes(123);
            var arr2 = arr1;
            using (var edm = new NorthwindEntities())
            {
                var cust1 = from e in edm.Employees
                            where SqlFunctions.Checksum(arr1, arr2, e.Photo) > 0
                            select e;
                //WHERE (CHECKSUM(@p__linq__0, @p__linq__1, [Extent1].[Photo])) >0
                cust1.TraceSql();
                Console.WriteLine();
            }
        }
        [TestMethod]
        public void test3()
        {
            var dt1 = DateTime.Now;
            using (var edm = new NorthwindEntities())
            {
                var cust1 = from e in edm.Employees
                            where SqlFunctions.Checksum(dt1, dt1, e.BirthDate) <= 524209
                            select e;
                //WHERE (CHECKSUM(@p__linq__0, @p__linq__1, [Extent1].[BirthDate])) <= 524209
                cust1.TraceSql();
                Console.WriteLine();
            }
        }
        [TestMethod]
        public void test4()
        {
            using (var edm = new NorthwindEntities())
            {
                var cust1 = from e in edm.Employees
                            where SqlFunctions.Checksum("zxm", "zxm", e.City) == -1555502783
                            select e;
                //WHERE -1555502783 = (CHECKSUM(N'zxm', N'zxm', [Extent1].[City]))
                cust1.TraceSql();
                Console.WriteLine(cust1.Count());
            }
        }
        [TestMethod]
        public void test5()
        {
            using (var edm = new NorthwindEntities())
            {
                var cust1 = from e in edm.Employees
                            where SqlFunctions.Checksum(e.City, e.City) == -1659895301
                            select e;
                //WHERE -1659895301 = (CHECKSUM([Extent1].[City], [Extent1].[City]))
                cust1.TraceSql();
                Console.WriteLine(cust1.Count());
            }
        }
        [TestMethod]
        public void test6()
        {
            using (var edm = new NorthwindEntities())
            {
                var cust1 = from e in edm.Order_Details
                            where SqlFunctions.Checksum(e.Discount, e.Discount) == -377487330
                            select e;
                //WHERE -377487330 = (CHECKSUM( CAST( [Extent1].[Discount] AS float),  CAST( [Extent1].[Discount] AS float)))
                cust1.TraceSql();
                Console.WriteLine(cust1.Count());
            }
        }
    }
}
