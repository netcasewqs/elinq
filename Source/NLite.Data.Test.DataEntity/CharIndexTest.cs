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
    public class CharIndexTest
    {
        [TestMethod]
        public void test1()
        {
            var arr1 = BitConverter.GetBytes(123);
            using (var edm = new NorthwindEntities())
            {
                var cust1 =edm.Employees
                    .Where(e=>SqlFunctions.CharIndex(arr1,e.Photo,(long?)0)>(long?)-1);
                //WHERE ( CAST(CHARINDEX(@p__linq__0, [Extent1].[Photo], cast(0 as bigint)) AS bigint)) > -1
                cust1.TraceSql();
                Console.WriteLine(cust1.Count());
            }
        }
        [TestMethod]
        public void test2()
        {
            using (var edm = new NorthwindEntities())
            {
                var cust1 = edm.Customers
                    .Where(c => SqlFunctions.CharIndex("don",c.City,(long?)0) ==4);
                //WHERE 4 = ( CAST(CHARINDEX(N'don', [Extent1].[City], cast(0 as bigint)) AS bigint))
                cust1.TraceSql();
                Console.WriteLine(cust1.Count());

                //cust1 = edm.Customers
                //    .Where(c => c.City.IndexOf("don", 0) == 3);
                ////WHERE 4 = ( CAST(CHARINDEX(N'don', [Extent1].[City], cast(0 as bigint)) AS bigint))
                //cust1.TraceSql();
                //Console.WriteLine(cust1.Count());
            }
        }
        [TestMethod]
        public void test3()
        {
            var arr1 = BitConverter.GetBytes(123);
            using (var edm = new NorthwindEntities())
            {
                var cust1 = edm.Employees
                    .Where(c => SqlFunctions.CharIndex(arr1, c.Photo, (int?)0) > -1);
                //WHERE ( CAST(CHARINDEX(@p__linq__0, [Extent1].[Photo], 0) AS int)) > -1
                cust1.TraceSql();
                Console.WriteLine(cust1.Count());
            }
        }
        [TestMethod]
        public void test4()
        {
            using (var edm = new NorthwindEntities())
            {
                var cust1 = edm.Customers
                    .Where(c => SqlFunctions.CharIndex(c.City,"London", (int?)1)==1);
                //WHERE 1 = ( CAST(CHARINDEX([Extent1].[City], N'London', 1) AS int))
                cust1.TraceSql();
                Console.WriteLine(cust1.Count());

                //cust1 = edm.Customers
                 //   .Where(c =>c.City.IndexOf("London",0)==0);
                //WHERE 1 = ( CAST(CHARINDEX([Extent1].[City], N'London', 1) AS int))
                //cust1.TraceSql();
                //Console.WriteLine(cust1.Count());
            }
        }
        [TestMethod]
        public void test5()
        {
            var arr1 = BitConverter.GetBytes(123);
            using (var edm = new NorthwindEntities())
            {
                var cust1 = edm.Employees
                    .Where(c => SqlFunctions.CharIndex(arr1,c.Photo) >= -1);
                //WHERE ( CAST(CHARINDEX(@p__linq__0, [Extent1].[Photo]) AS int)) >= -1
                cust1.TraceSql();
                Console.WriteLine(cust1.Count());
            }
        }
        [TestMethod]
        public void test6()
        {
            using (var edm = new NorthwindEntities())
            {
                var cust1 = edm.Customers
                    .Where(c => SqlFunctions.CharIndex("Lond", c.City) ==1);
                Assert.IsNotNull(cust1);
                Console.WriteLine(cust1.Count());
                //WHERE 1 = ( CAST(CHARINDEX(N'Lond', [Extent1].[City]) AS int))
                cust1.TraceSql();

                cust1 = edm.Customers
                    .Where(c => c.City.IndexOf("Lond") ==0);
                //WHERE 0 = (( CAST(CHARINDEX(N'Lond', [Extent1].[City]) AS int)) - 1)
                cust1.TraceSql();
                Console.WriteLine(cust1.Count());

            }
        }
    }

    public static class EFTrace
    {
        public static void TraceSql(this IQueryable q)
        {
            var efQuery = q as ObjectQuery;
            if (efQuery != null)
                Console.WriteLine(efQuery.ToTraceString());
            else
            {
                var elinqQuery = q as IDbSet;
                if (elinqQuery != null)
                {
                    Console.WriteLine(elinqQuery.SqlText);
                }
                else
                    Console.WriteLine(q.Expression);
            }
        }
    }
}
