//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using NUnit.Framework;
//using TestClass = NUnit.Framework.TestFixtureAttribute;
//using TestInitialize = NUnit.Framework.SetUpAttribute;
//using TestMethod = NUnit.Framework.TestAttribute;
//using System.Data.Linq.SqlClient;

//namespace NLite.Data.Test.LinqToSql.Top_Bottom_Paging_SqlMethods
//{
//    [TestClass]
//    public class LikeTest:DLinqConnection
//    {
//        //Like
//        //TODO:Bug-- 索引超出了数组界限。
//        [TestMethod]
//        public void LikeTest1()
//        {
//            using (var db = dbConfiguration.CreateDbContext())
//            {
//                var item = from c in db.Set<Customers>()
//                           where SqlMethods.Like(c.CustomerID,"C%")
//                           select c;
//                foreach (var it in item)
//                {
//                    Console.WriteLine(it.CustomerID);
//                }
//            }
//        }
//        //TODO:Bug-- 索引超出了数组界限。
//        [TestMethod]
//        public void LikeTest2()
//        {
//            using (var db = dbConfiguration.CreateDbContext())
//            {
//                var item = from c in db.Set<Customers>()
//                           where SqlMethods.Like(c.CustomerID, "A_O_T")
//                           select c;
//                foreach (var it in item)
//                {
//                    Console.WriteLine(it.CustomerID);
//                }
//            }
//        }
//    }
//}
