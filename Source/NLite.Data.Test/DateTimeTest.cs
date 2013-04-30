using System;
using System.Data.Linq.SqlClient;
using System.Linq;
using NLite.Data.Common;
using NLite.Data.Test.Model.Northwind;
using NUnit.Framework;
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestInitialize = NUnit.Framework.SetUpAttribute;
using TestMethod = NUnit.Framework.TestAttribute;
namespace NLite.Data.Test
{
    /// <summary>
    /// DateTimeTest 的摘要说明
    /// </summary>
    [TestClass]
    public class DateTimeTest : TestBase
    {
        protected Northwind db;

        protected virtual string ConnectionStringName
        {
            get { return "Northwind"; }
        }

        [TestInitialize]
        public void Initialize()
        {
            db = new Northwind();
            //DbConfiguration.InitializeDLinq<System.Data.Linq.ModifiedMemberInfo>();
        }

        [TearDown]
        public void TearDown()
        {
            db.Dispose();
        }

        [TestMethod]
        //#if SQLite || MySql
        //           [Microsoft.VisualStudio.TestTools.UnitTesting.Ignore]   // SQLite: no equivalent function
        //                  // MySql: returns datetime as binary after combination of MAX and CONVERT
        //#endif
        public virtual void TestDateTimeConstructYMD()
        {
            var dt = db.Customers.Where(c => c.CustomerID == "ALFKI").Max(c => new DateTime((c.CustomerID == "ALFKI") ? 1997 : 1997, 7, 4));
            AssertValue(1997, dt.Year);
            AssertValue(7, dt.Month);
            AssertValue(4, dt.Day);
            AssertValue(0, dt.Hour);
            AssertValue(0, dt.Minute);
            AssertValue(0, dt.Second);
        }

        [TestMethod]
        //#if SQLite || MySql
        //         [Microsoft.VisualStudio.TestTools.UnitTesting.Ignore]   // SQLite: no equivalent function
        //                  // MySql: returns datetime as binary after combination of MAX and CONVERT
        //#endif
        public virtual void TestDateTimeConstructYMDHMS()
        {
            var dt = db.Customers.Where(c => c.CustomerID == "ALFKI").Max(c => new DateTime((c.CustomerID == "ALFKI") ? 1997 : 1997, 7, 4, 3, 5, 6));
            AssertValue(1997, dt.Year);
            AssertValue(7, dt.Month);
            AssertValue(4, dt.Day);
            AssertValue(3, dt.Hour);
            AssertValue(5, dt.Minute);
            AssertValue(6, dt.Second);
        }

        [TestMethod]
        public virtual void TestDateTimeDay()
        {
            var v = db.Orders.Where(o => o.OrderDate == new DateTime(1997, 8, 25)).Take(1).Max(o => o.OrderDate.Day);
            //var v = db.Orders.FirstOrDefault(o => o.OrderID == 10644);
            //AssertValue(25, v.OrderDate.Day);
            AssertValue(25, v);
        }

        [TestMethod]
        public virtual void TestDateTimeDay1()
        {
            var v = db.Orders.Where(o => o.OrderDate == new DateTime(1997, 8, 25)).Take(1).Max(o => SqlFunctions.DatePart(DateParts.Day, o.OrderDate));
            //var v = db.Orders.FirstOrDefault(o => o.OrderID == 10644);
            //AssertValue(25, v.OrderDate.Day);
            AssertValue(25, v);
        }

        [TestMethod]
        public virtual void TestDateTimeMonth()
        {
            var v = db.Orders.Where(o => o.OrderDate == new DateTime(1997, 8, 25)).Take(1).Max(o => o.OrderDate.Month);
            AssertValue(8, v);
        }

        [TestMethod]
        public virtual void TestDateTimeMonth1()
        {
            var v = db.Orders.Where(o => o.OrderDate == new DateTime(1997, 8, 25)).Take(1).Max(o => SqlFunctions.DatePart(DateParts.Month, o.OrderDate));
            AssertValue(8, v);
        }

        [TestMethod]
        public virtual void TestDateTimeYear()
        {
            var v = db.Orders.Where(o => o.OrderDate == new DateTime(1997, 8, 25)).Take(1).Max(o => o.OrderDate.Year);
            AssertValue(1997, v);
        }

        [TestMethod]
        public virtual void TestDateTimeYear1()
        {
            var v = db.Orders.Where(o => o.OrderDate == new DateTime(1997, 8, 25)).Take(1).Max(o => SqlFunctions.DatePart(DateParts.Year, o.OrderDate));
            AssertValue(1997, v);
        }

        [TestMethod]
        public virtual void TestDateTimeHour()
        {
            var hour = db.Customers.Where(c => c.CustomerID == "ALFKI").Max(c => new DateTime((c.CustomerID == "ALFKI") ? 1997 : 1997, 7, 4, 3, 5, 6).Hour);
            AssertValue(3, hour);
        }

        [TestMethod]
        public virtual void TestDateTimeHour1()
        {
            var hour = db.Customers.Where(c => c.CustomerID == "ALFKI").Max(c => SqlFunctions.DatePart(DateParts.Hour, new DateTime((c.CustomerID == "ALFKI") ? 1997 : 1997, 7, 4, 3, 5, 6)));
            AssertValue(3, hour);
        }

        [TestMethod]
        public virtual void TestDateTimeMinute()
        {
            var minute = db.Customers.Where(c => c.CustomerID == "ALFKI").Max(c => new DateTime((c.CustomerID == "ALFKI") ? 1997 : 1997, 7, 4, 3, 5, 6).Minute);
            AssertValue(5, minute);
        }

        [TestMethod]
        public virtual void TestDateTimeMinute1()
        {
            var minute = db.Customers.Where(c => c.CustomerID == "ALFKI").Max(c => SqlFunctions.DatePart(DateParts.Minute, new DateTime((c.CustomerID == "ALFKI") ? 1997 : 1997, 7, 4, 3, 5, 6)));
            AssertValue(5, minute);
        }

        [TestMethod]
        public virtual void TestDateTimeSecond()
        {
            var second = db.Customers.Where(c => c.CustomerID == "ALFKI").Max(c => new DateTime((c.CustomerID == "ALFKI") ? 1997 : 1997, 7, 4, 3, 5, 6).Second);
            AssertValue(6, second);
        }

        [TestMethod]
        public virtual void TestDateTimeSecond1()
        {
            var second = db.Customers.Where(c => c.CustomerID == "ALFKI").Max(c => SqlFunctions.DatePart(DateParts.Second, new DateTime((c.CustomerID == "ALFKI") ? 1997 : 1997, 7, 4, 3, 5, 6)));
            AssertValue(6, second);
        }

        [TestMethod]
        public virtual void TestDateTimeTimeOfDay()
        {
            //var time = DateTime.Now.TimeOfDay;
            //Console.WriteLine(time);
            var second = db.Orders.Where(p => p.OrderID == 10449).Select(p => p.OrderDate.TimeOfDay).First();
            //AssertValue(6, second);
            Console.WriteLine(second);
        }



        [TestMethod]
        public virtual void TestDateTimeDate()
        {
            var time = DateTime.Now.Date;
            Console.WriteLine(time);
            var second = db.Orders.Where(p => p.OrderID == 10449).Select(p => p.OrderDate.Date).First();
            Console.WriteLine(second);
        }

        //[TestMethod]
        //public virtual void TestDateTimeDate1()
        //{
        //    var time = DateTime.Now.Date;
        //    Console.WriteLine(time);
        //    var second = db.Orders.Where(p => p.OrderID == 10449).Select(p => SqlFunctions.DatePart(DateParts.Date,p.OrderDate)).First();
        //    Console.WriteLine(second);
        //}

        [TestMethod]
        public virtual void TestDateTimeToDay()
        {
            var time = DateTime.Today;
            Console.WriteLine(time);
            var second = db.Orders.Where(p => p.OrderID == 10449).Select(p => p.OrderDate.Date).First();
            Console.WriteLine(second);
        }
#if Access || MySql || SqlServer || Oracle || Sqlite
        [TestMethod]
        public virtual void TestDateTimeDayOfWeek()
        {
            var dow = db.Orders.Where(o => o.OrderDate == new DateTime(1997, 8, 25)).Take(1).Max(o => o.OrderDate.DayOfWeek);
            AssertValue(DayOfWeek.Monday, dow);
        }

        [TestMethod]
        public virtual void TestDateTimeDayOfWeek1()
        {
            var dow = (DayOfWeek)db.Orders.Where(o => o.OrderDate == new DateTime(1997, 8, 25)).Take(1).Max(o => SqlFunctions.DatePart(DateParts.DayOfWeek,o.OrderDate));
            AssertValue(DayOfWeek.Monday, dow);
        }
#endif
        [TestMethod]
        public virtual void TestDateTimeDayOfYear()
        {
            var actual = db.Orders.Where(o => o.OrderDate == new DateTime(1997, 1, 1)).Take(1).Max(o => o.OrderDate.DayOfYear);
            AssertValue(1, actual);
            actual = db.Orders.Where(o => o.OrderDate == new DateTime(1997, 8, 25)).Take(1).Max(o => o.OrderDate.DayOfYear);
            AssertValue(new DateTime(1997, 8, 25).DayOfYear, actual);
        }

        [TestMethod]
        public virtual void TestDateTimeDayOfYear1()
        {
            var actual = db.Orders.Where(o => o.OrderDate == new DateTime(1997, 1, 1)).Take(1).Max(o => SqlFunctions.DatePart(DateParts.DayOfYear, o.OrderDate));
            AssertValue(1, actual);
            actual = db.Orders.Where(o => o.OrderDate == new DateTime(1997, 8, 25)).Take(1).Max(o => SqlFunctions.DatePart(DateParts.DayOfYear, o.OrderDate));
            AssertValue(new DateTime(1997, 8, 25).DayOfYear, actual);
        }

        [TestMethod]
        public virtual void TestDateTimeQuarter()
        {
            var actual = db.Orders.Where(o => o.OrderDate == new DateTime(1997, 1, 24)).Take(1).Max(o => SqlFunctions.DatePart(DateParts.Quarter, o.OrderDate));
            Console.WriteLine(actual);//0 ?? 1
            actual = db.Orders.Where(o => o.OrderDate == new DateTime(1997, 2, 24)).Take(1).Max(o => SqlFunctions.DatePart(DateParts.Quarter, o.OrderDate));
            Console.WriteLine(actual);//
            actual = db.Orders.Where(o => o.OrderDate == new DateTime(1997, 3, 24)).Take(1).Max(o => SqlFunctions.DatePart(DateParts.Quarter, o.OrderDate));
            Console.WriteLine(actual);//
            actual = db.Orders.Where(o => o.OrderDate == new DateTime(1997, 4, 24)).Take(1).Max(o => SqlFunctions.DatePart(DateParts.Quarter, o.OrderDate));
            Console.WriteLine(actual);//2
            actual = db.Orders.Where(o => o.OrderDate == new DateTime(1997, 7, 24)).Take(1).Max(o => SqlFunctions.DatePart(DateParts.Quarter, o.OrderDate));
            Console.WriteLine(actual);//3
            actual = db.Orders.Where(o => o.OrderDate == new DateTime(1997, 11, 24)).Take(1).Max(o => SqlFunctions.DatePart(DateParts.Quarter, o.OrderDate));
            Console.WriteLine(actual);//4
            actual = db.Orders.Where(o => o.OrderDate == new DateTime(1997, 12, 24)).Take(1).Max(o => SqlFunctions.DatePart(DateParts.Quarter, o.OrderDate));
            Console.WriteLine(actual);//4
        }

        [TestMethod]
        public virtual void TestDateTimeAddYears()
        {
            var od = db.Orders.FirstOrDefault(o => o.OrderDate == new DateTime(1997, 8, 25) && o.OrderDate.AddYears(2).Year == 1999);
            Assert.AreNotEqual(null, od);
        }

        [TestMethod]
        public virtual void TestDateTimeAddYears2()
        {
            var od = db.Orders.FirstOrDefault(o => o.OrderDate == new DateTime(1997, 8, 25) && (o.OrderDate.Year + 2) == 1999);
            Assert.AreNotEqual(null, od);
        }

        [TestMethod]
        public virtual void TestDateTimeAddMonths()
        {
            var od = db.Orders.FirstOrDefault(o => o.OrderDate == new DateTime(1997, 8, 25) && o.OrderDate.AddMonths(2).Month == 10);
            Assert.AreNotEqual(null, od);
        }

        [TestMethod]
        public virtual void TestDateTimeAddMonths2()
        {
            var od = db.Orders.FirstOrDefault(o => o.OrderDate == new DateTime(1997, 8, 25) && (o.OrderDate.Month + 2) == 10);
            Assert.AreNotEqual(null, od);
        }

        [TestMethod]
        public virtual void TestDateTimeAddDays()
        {
            double a = 2.0;
            var od = db.Orders.FirstOrDefault(o => o.OrderDate == new DateTime(1997, 8, 25) && o.OrderDate.AddDays(2).Day == 27);
            Assert.AreNotEqual(null, od);
        }

        [TestMethod]
        public virtual void TestDateTimeAddDays2()
        {
            var od = db.Orders.FirstOrDefault(o => o.OrderDate == new DateTime(1997, 8, 25) && (o.OrderDate.Day + 2) == 27);
            Assert.AreNotEqual(null, od);
        }


        [TestMethod]
        public virtual void TestDateTimeAddHours()
        {
            var od = db.Orders.FirstOrDefault(o => o.OrderDate == new DateTime(1997, 8, 25) && o.OrderDate.AddHours(3).Hour == 3);
            Assert.AreNotEqual(null, od);
        }

        [TestMethod]
        public virtual void TestDateTimeAddHours2()
        {
            var od = db.Orders.FirstOrDefault(o => o.OrderDate == new DateTime(1997, 8, 25) && (o.OrderDate.Hour + 3) == 3);
            Assert.AreNotEqual(null, od);
        }

        [TestMethod]
        public virtual void TestDateTimeAddMinutes()
        {
            var od = db.Orders.FirstOrDefault(o => o.OrderDate == new DateTime(1997, 8, 25) && o.OrderDate.AddMinutes(5.3).Minute == 5);
            Assert.AreNotEqual(null, od);
        }

        [TestMethod]
        public virtual void TestDateTimeAddMinutes2()
        {
            var od = db.Orders.FirstOrDefault(o => o.OrderDate == new DateTime(1997, 8, 25) && (o.OrderDate.Minute + 5) == 5);
            Assert.AreNotEqual(null, od);
        }

        [TestMethod]
        public virtual void TestDateTimeAddSeconds()
        {
            var od = db.Orders.FirstOrDefault(o => o.OrderDate == new DateTime(1997, 8, 25) && o.OrderDate.AddSeconds(6).Second == 6);
            Assert.AreNotEqual(null, od);
        }

        [TestMethod]
        public virtual void TestDateTimeAddSeconds2()
        {
            var od = db.Orders.FirstOrDefault(o => o.OrderDate == new DateTime(1997, 8, 25) && (o.OrderDate.Second + 6) == 6);
            Assert.AreNotEqual(null, od);
        }

        [TestMethod]
        public virtual void TestDateTimeAddDate()
        {
            TimeSpan ts = new TimeSpan(2, 2, 2, 2);
            var od = db.Orders.FirstOrDefault(o => o.OrderDate == new DateTime(1997, 8, 25) && o.OrderDate.Add(ts) == new DateTime(1997, 8, 27, 2, 2, 2));
            Assert.AreNotEqual(null, od);
        }

        [TestMethod]
        public virtual void TestDateTimeSubtractDate()
        {
            TimeSpan ts = new TimeSpan(2, 2, 2, 2);
            var od = db.Orders.FirstOrDefault(o => o.OrderDate == new DateTime(1997, 8, 25) && (o.OrderDate.Subtract(ts)) == new DateTime(1997, 8, 22, 21, 57, 58));
            Assert.AreNotEqual(null, od);
        }
        [TestMethod]
        public virtual void TestDateTimeToDate3()
        {
            var od = db.Orders.FirstOrDefault(o => o.OrderDate == new DateTime(1997, 8, 25) && o.OrderDate == SqlFunctions.ToDate(1997, 8, 25).Value);
            Assert.AreNotEqual(null, od);
        }
        [TestMethod]
        public virtual void TestDateTimeToDate6()
        {
            var od = db.Orders.FirstOrDefault(o => o.OrderDate == new DateTime(1997, 8, 25) && o.OrderDate == SqlFunctions.ToDateTime(1997, 8, 25, 0, 0, 0).Value);
            Assert.AreNotEqual(null, od);
        }

        [TestMethod]
        public virtual void TestDateTimeDateDiffYear()
        {
            var actual = db.Orders.FirstOrDefault(o => o.OrderDate == new DateTime(1997, 8, 25) && SqlFunctions.DateDiff(DateParts.Year, o.OrderDate, new DateTime(1996, 7, 1)) == -1);
            Assert.AreNotEqual(null, actual);
        }

        [TestMethod]
        public virtual void TestDateTimeDateDiffMonth()
        {
            //DateTime aa = new DateTime(1997, 8, 25, 1, 2, 3, 102);
            //DateTime bb = new DateTime(1998, 9, 24, 4, 1, 1, 100);
            //Console.WriteLine((aa - bb).Hours);


            ////DateTime aa = new DateTime(1997, 8, 25, 1, 2, 3, 102);
            ////DateTime bb = new DateTime(1997, 8, 24, 1, 2, 3, 103);
            ////Console.WriteLine((aa - bb).Days);

            var actual = db.Orders.FirstOrDefault(o => o.OrderDate == new DateTime(1997, 8, 25) && SqlFunctions.DateDiff(DateParts.Month, o.OrderDate, new DateTime(1996, 1, 1)) == -19);
            Assert.AreNotEqual(null, actual);
        }

        [TestMethod]
        public virtual void TestDateTimeDateDiffDay()
        {
            var actual = db.Orders.FirstOrDefault(o => o.OrderDate == new DateTime(1997, 8, 25) && SqlFunctions.DateDiff(DateParts.Day, o.OrderDate, new DateTime(1996, 1, 1)) == -602);
            Assert.AreNotEqual(null, actual);
        }
        [TestMethod]
        public virtual void TestDateTimeDateDiffDay2()
        {
            var actual = db.Orders.FirstOrDefault(o => o.OrderDate == new DateTime(1997, 8, 25) && (o.OrderDate - new DateTime(1996, 1, 1)).Days == -602);
            Assert.AreNotEqual(null, actual);
        }

        [TestMethod]
        public virtual void TestDateTimeDateDiffHour()
        {
            var actual = db.Orders.FirstOrDefault(o => o.OrderDate == new DateTime(1997, 8, 25) && SqlFunctions.DateDiff(DateParts.Hour, o.OrderDate, new DateTime(1996, 1, 1)) == -14448);
            Assert.AreNotEqual(null, actual);
        }

        [TestMethod]
        public virtual void TestDateTimeDateDiffHour2()
        {
            var actual = db.Orders.FirstOrDefault(o => o.OrderDate == new DateTime(1997, 8, 25) && (o.OrderDate - new DateTime(1996, 1, 1)).Hours == -14448);
            Assert.AreNotEqual(null, actual);
        }

        [TestMethod]
        public virtual void TestDateTimeDateDiffMinute()
        {
            var actual = db.Orders.FirstOrDefault(o => o.OrderDate == new DateTime(1997, 8, 25) && SqlFunctions.DateDiff(DateParts.Minute, o.OrderDate, new DateTime(1996, 1, 1)) == -866880);
            Assert.AreNotEqual(null, actual);
        }

        [TestMethod]
        public virtual void TestDateTimeDateDiffMinute2()
        {
            var actual = db.Orders.FirstOrDefault(o => o.OrderDate == new DateTime(1997, 8, 25) && (o.OrderDate - new DateTime(1996, 1, 1)).Minutes == -866880);
            Assert.AreNotEqual(null, actual);
        }

        [TestMethod]
        public virtual void TestDateTimeDateDiffSecond()
        {
            var actual = db.Orders.FirstOrDefault(o => o.OrderDate == new DateTime(1997, 8, 25) && SqlFunctions.DateDiff(DateParts.Second, o.OrderDate, new DateTime(1996, 1, 1)) == -52012800);
            Assert.AreNotEqual(null, actual);
        }

        [TestMethod]
        public virtual void TestDateTimeDateDiffSecond2()
        {
            var actual = db.Orders.FirstOrDefault(o => o.OrderDate == new DateTime(1997, 8, 25) && (o.OrderDate - new DateTime(1996, 1, 1)).Seconds == -52012800);
            Assert.AreNotEqual(null, actual);
        }
        //[TestMethod]
        //public virtual void TestDateTimeDatePartTimeOfDay()
        //{
        //    var actual = db.Orders.Where(o => o.OrderDate == new DateTime(1997, 8, 25) && o.OrderDate.TimeOfDay.Hours == 0).FirstOrDefault() ;
        //    Assert.AreNotEqual(null, actual);
        //}
        [TestMethod]
        public virtual void TestDateTimeDatePartDate()
        {
            var actual = db.Orders.Where(o => o.OrderDate == new DateTime(1997, 8, 25) &&
                                              o.OrderDate.Date.Year == 1997 &&
                                              o.OrderDate.Date.Month == 8 &&
                                              o.OrderDate.Date.Day == 25
                                         ).FirstOrDefault();
            Assert.AreNotEqual(null, actual);
        }
        //#if Oracle
        //        [TestMethod]
        //        public virtual void TestDateTimeDateDiffMillisecond() //TODO:Sqlite 选出的值为-51925180000   TODO:Sqlserver 值溢出
        //        {
        //            var actual = db.Orders.FirstOrDefault(o => o.OrderDate == new DateTime(1997, 8, 25) && (long)SqlFunctions.DateDiff(DateParts.Millisecond, o.OrderDate, new DateTime(1996, 1, 1, 12, 10, 10)) == -51968990000L);
        //            Assert.AreNotEqual(null, actual);
        //        }

        //        [TestMethod]
        //        public virtual void TestDateTimeDateDiffMillisecond2()
        //        {
        //            //DateTime aa = new DateTime(1997,12,23,12,15,56);
        //            //DateTime bb = new DateTime(1996,5,30,8,56,56);
        //            //Console.WriteLine((aa -bb).TotalDays);
        //            //Console.WriteLine((aa -bb ).TotalMilliseconds);
        //            var actual = db.Orders.FirstOrDefault(o => o.OrderDate == new DateTime(1997, 8, 25) && (long)(o.OrderDate - new DateTime(1996, 1, 1, 12, 10, 10)).TotalMilliseconds == -51968990000L);
        //            Assert.AreNotEqual(null, actual);
        //        }

        //        [TestMethod]
        //        public virtual void TestDateTimeDateDiffMicrosecond()
        //        {
        //            var actual = db.Orders.FirstOrDefault(o => o.OrderDate == new DateTime(1997, 8, 25) && (long)SqlFunctions.DateDiff(DateParts.Microsecond, o.OrderDate, new DateTime(1996, 1, 1, 12, 10, 10)) == -51968990000000L);
        //            Assert.AreNotEqual(null, actual);
        //        }

        //        [TestMethod]
        //        public virtual void TestDateTimeDateDiffNenosecond()
        //        {
        //            var actual = db.Orders.FirstOrDefault(o => o.OrderDate == new DateTime(1997, 8, 25) && (long)SqlFunctions.DateDiff(DateParts.Nanosecond, o.OrderDate, new DateTime(1996, 1, 1, 12, 10, 10)) == -51968990000000000L);
        //            Assert.AreNotEqual(null, actual);
        //        }

        //#endif


        [TestMethod]
        public virtual void TestDateTimeDateDiffWeek()
        {
            var actual = db.Orders.FirstOrDefault(o => o.OrderDate == new DateTime(1997, 8, 25) && SqlFunctions.DateDiff(DateParts.Week, o.OrderDate, new DateTime(1996, 1, 1, 1, 1, 1)) == -86);
            Console.WriteLine(actual);
            Assert.AreNotEqual(null, actual);
        }

        //。。。。。。。。。。。。。。。。。。。。。。。。。。。。。。。。。。。ADD

        [TestMethod]
        public virtual void TestDateTimeToday()
        {
            DateTime dt = DateTime.Now;
            var expected = dt.Date;
            //var actual = db.Orders.Select(o => SqlFunctions.Now().Date).FirstOrDefault();
            //Assert.AreEqual(expected, actual);

            //BUG Access 修改AccessDialect.Functions.cs下的ToDate3FunctionView函数 未修复
            //BUG MySql
            //BUG Sqlite
            var q = db.Orders.Where(o => DateTime.Now.Date == expected);
            var item = q.FirstOrDefault();
            Assert.IsNotNull(item);
        }

        [TestMethod]
        public virtual void TestDateTimeDatePartYearNew()
        {
            DateTime dt = new DateTime(1997, 8, 25);
            var expected = dt.Year;
            var actual = db.Orders.Select(o => o.OrderDate == dt && SqlFunctions.DatePart(DateParts.Year, o.OrderDate) == expected).FirstOrDefault();
            Assert.IsNotNull(actual);

            var item = db.Orders.Where(o => o.OrderDate == dt && SqlFunctions.DatePart(DateParts.Year, o.OrderDate) == expected).FirstOrDefault();
            Assert.IsNotNull(item);
        }

        [TestMethod]
        public virtual void TestDateTimeDatePartMonthNew()
        {
            DateTime dt = new DateTime(1997, 8, 25);
            var expected = dt.Month;
            var actual = db.Orders.Select(o => o.OrderDate == dt && SqlFunctions.DatePart(DateParts.Month, o.OrderDate) == expected).FirstOrDefault();
            Assert.IsNotNull(actual);

            var item = db.Orders.Where(o => o.OrderDate == dt && SqlFunctions.DatePart(DateParts.Month, o.OrderDate) == expected).FirstOrDefault();
            Assert.IsNotNull(item);
        }

        [TestMethod]
        public virtual void TestDateTimeDatePartDayNew()
        {
            DateTime dt = new DateTime(1997, 8, 25);
            var expected = dt.Day;
            var actual = db.Orders.Select(o => o.OrderDate == dt && SqlFunctions.DatePart(DateParts.Day, o.OrderDate) == expected).FirstOrDefault();
            Assert.IsNotNull(actual);

            var item = db.Orders.Where(o => o.OrderDate == dt && SqlFunctions.DatePart(DateParts.Day, o.OrderDate) == expected).FirstOrDefault();
            Assert.IsNotNull(item);
        }

        [TestMethod]
        public virtual void TestDateTimeDatePartHourNew()
        {
            DateTime dt = new DateTime(1997, 8, 25);
            var expected = dt.Hour;
            var actual = db.Orders.Select(o => o.OrderDate == dt && SqlFunctions.DatePart(DateParts.Hour, o.OrderDate) == expected).FirstOrDefault();
            Assert.IsNotNull(actual);

            var item = db.Orders.Where(o => o.OrderDate == dt && SqlFunctions.DatePart(DateParts.Hour, o.OrderDate) == expected).FirstOrDefault();
            Assert.IsNotNull(item);
        }

        [TestMethod]
        public virtual void TestDateTimeDatePartMinuteNew()
        {
            DateTime dt = new DateTime(1997, 8, 25);
            var expected = dt.Minute;
            var actual = db.Orders.Select(o => o.OrderDate == dt && SqlFunctions.DatePart(DateParts.Minute, o.OrderDate) == expected).FirstOrDefault();
            Assert.IsNotNull(actual);

            var item = db.Orders.Where(o => o.OrderDate == dt && SqlFunctions.DatePart(DateParts.Minute, o.OrderDate) == expected).FirstOrDefault();
            Assert.IsNotNull(item);
        }

        [TestMethod]
        public virtual void TestDateTimeDatePartSecondNew()
        {
            DateTime dt = new DateTime(1997, 8, 25);
            var expected = dt.Second;
            var actual = db.Orders.Select(o => o.OrderDate == dt && SqlFunctions.DatePart(DateParts.Second, o.OrderDate) == expected).FirstOrDefault();
            Assert.IsNotNull(actual);

            var item = db.Orders.Where(o => o.OrderDate == dt && SqlFunctions.DatePart(DateParts.Second, o.OrderDate) == expected).FirstOrDefault();
            Assert.IsNotNull(item);
        }
#if Access
        [ExpectedException(typeof(NotSupportedException))]
#endif
        //MySQL Oracle 'ff' BUG
        [TestMethod]
        public virtual void TestDateTimeDatePartMillisecondNew()
        {
            DateTime dt = new DateTime(1997, 8, 25);
            var expected = dt.Millisecond;
            var actual = db.Orders.Select(o => o.OrderDate == dt && SqlFunctions.DatePart(DateParts.Millisecond, o.OrderDate) == expected).FirstOrDefault();
            Assert.IsNotNull(actual);

            var item = db.Orders.Where(o => o.OrderDate == dt && SqlFunctions.DatePart(DateParts.Millisecond, o.OrderDate) == expected).FirstOrDefault();
            Assert.IsNotNull(item);
        }

        [TestMethod]
        public virtual void TestDateTimeDatePartDayOfYearNew()
        {
            DateTime dt = new DateTime(1997, 8, 25);
            var expected = dt.DayOfYear;
            var actual = db.Orders.Select(o => o.OrderDate == dt && SqlFunctions.DatePart(DateParts.DayOfYear, o.OrderDate) == expected).FirstOrDefault();
            Assert.IsNotNull(actual);

            var item = db.Orders.Where(o => o.OrderDate == dt && SqlFunctions.DatePart(DateParts.DayOfYear, o.OrderDate) == expected).FirstOrDefault();
            Assert.IsNotNull(item);
        }
#if SqlCE
        [ExpectedException(typeof(NotSupportedException))]
#endif
        [TestMethod]
        public virtual void TestDateTimeDatePartDayOfWeekNew()
        {
            DateTime dt = new DateTime(1997, 8, 25);
            var expected = (int)dt.DayOfWeek;
            var actual = db.Orders.Select(o => o.OrderDate == dt && SqlFunctions.DatePart(DateParts.DayOfWeek, o.OrderDate) == expected).FirstOrDefault();
            Assert.IsNotNull(actual);

            var item = db.Orders.Where(o => o.OrderDate == dt && SqlFunctions.DatePart(DateParts.DayOfWeek, o.OrderDate) == expected).FirstOrDefault();
            Assert.IsNotNull(item);
        }

        [TestMethod]
        public virtual void TestDateTimeDatePartQuarterNew()
        {
            DateTime dt = new DateTime(1997, 8, 25);
            var expected = dt.Month / 3 + 1;
            var actual = db.Orders.Select(o => o.OrderDate == dt && SqlFunctions.DatePart(DateParts.Quarter, o.OrderDate) == expected).FirstOrDefault();
            Assert.IsNotNull(actual);

            var item = db.Orders.Where(o => o.OrderDate == dt && SqlFunctions.DatePart(DateParts.Quarter, o.OrderDate) == expected).FirstOrDefault();
            Assert.IsNotNull(item);
        }


        [TestMethod]
        public virtual void TestDateTimeDateAddYearNew()
        {
            DateTime dt = new DateTime(1997, 8, 25);
            var expected = dt.Year + 3;
            var actual = db.Orders.Select(o => o.OrderDate == dt && SqlFunctions.DateAdd(DateParts.Year, o.OrderDate, 3).Value.Year == expected).FirstOrDefault();
            Assert.IsNotNull(actual);

            var item = db.Orders.Where(o => o.OrderDate == dt && SqlFunctions.DateAdd(DateParts.Year, o.OrderDate, 3).Value.Year == expected).FirstOrDefault();
            Assert.IsNotNull(item);
        }

        [TestMethod]
        public virtual void TestDateTimeDateAddMonthNew()
        {
            DateTime dt = new DateTime(1997, 8, 25);
            var expected = dt.Month + 1;
            var actual = db.Orders.Select(o => o.OrderDate == dt && SqlFunctions.DateAdd(DateParts.Month, o.OrderDate, 1).Value.Month == expected).FirstOrDefault();
            Assert.IsNotNull(actual);

            var item = db.Orders.Where(o => o.OrderDate == dt && SqlFunctions.DateAdd(DateParts.Month, o.OrderDate, 1).Value.Month == expected).FirstOrDefault();
            Assert.IsNotNull(item);
        }

        [TestMethod]
        public virtual void TestDateTimeDateAddDayNew()
        {
            DateTime dt = new DateTime(1997, 8, 25);
            var expected = dt.Day + 1;
            var actual = db.Orders.Select(o => o.OrderDate == dt && SqlFunctions.DateAdd(DateParts.Day, o.OrderDate, 1).Value.Day == expected).FirstOrDefault();
            Assert.IsNotNull(actual);

            var item = db.Orders.Where(o => o.OrderDate == dt && SqlFunctions.DateAdd(DateParts.Day, o.OrderDate, 1).Value.Day == expected).FirstOrDefault();
            Assert.IsNotNull(item);
        }

        [TestMethod]
        public virtual void TestDateTimeDateAddHourNew()
        {
            DateTime dt = new DateTime(1997, 8, 25);
            var expected = dt.Hour + 1;
            var actual = db.Orders.Select(o => o.OrderDate == dt && SqlFunctions.DateAdd(DateParts.Hour, o.OrderDate, 1).Value.Hour == expected).FirstOrDefault();
            Assert.IsNotNull(actual);

            var item = db.Orders.Where(o => o.OrderDate == dt && SqlFunctions.DateAdd(DateParts.Hour, o.OrderDate, 1).Value.Hour == expected).FirstOrDefault();
            Assert.IsNotNull(item);
        }

        [TestMethod]
        public virtual void TestDateTimeDateAddMinuteNew()
        {
            DateTime dt = new DateTime(1997, 8, 25);
            var expected = dt.Minute + 1;
            var actual = db.Orders.Select(o => o.OrderDate == dt && SqlFunctions.DateAdd(DateParts.Minute, o.OrderDate, 1).Value.Minute == expected).FirstOrDefault();
            Assert.IsNotNull(actual);

            var item = db.Orders.Where(o => o.OrderDate == dt && SqlFunctions.DateAdd(DateParts.Minute, o.OrderDate, 1).Value.Minute == expected).FirstOrDefault();
            Assert.IsNotNull(item);
        }

        [TestMethod]
        public virtual void TestDateTimeDateAddSecondNew()
        {
            DateTime dt = new DateTime(1997, 8, 25);
            var expected = dt.Second + 1;
            var actual = db.Orders.Select(o => o.OrderDate == dt && SqlFunctions.DateAdd(DateParts.Second, o.OrderDate, 1).Value.Second == expected).FirstOrDefault();
            Assert.IsNotNull(actual);

            var item = db.Orders.Where(o => o.OrderDate == dt && SqlFunctions.DateAdd(DateParts.Second, o.OrderDate, 1).Value.Second == expected).FirstOrDefault();
            Assert.IsNotNull(item);
        }

        //Not Support
        //[TestMethod]
        //public virtual void TestDateTimeDateAddMillisecondNew()
        //{
        //    DateTime dt = new DateTime(2013, 1, 8, 12, 59, 56);
        //    var expected = dt.Millisecond + 1;
        //    var actual = db.Orders.Select(o => SqlFunctions.DateAdd(DateParts.Millisecond, dt, 1).Value.Millisecond).FirstOrDefault();
        //    Assert.AreEqual(expected, actual);

        //    var item = db.Orders.Where(o => SqlFunctions.DateAdd(DateParts.Millisecond, dt, 1).Value.Millisecond == expected).FirstOrDefault();
        //    Assert.IsNotNull(item);
        //}

        [TestMethod]
        public virtual void TestDateTimeToDateTimeNew()
        {
            DateTime dt = new DateTime(1997, 8, 25, 0, 0, 0);
            var actual = db.Orders.Select(o => o.OrderDate == dt && SqlFunctions.ToDateTime(1997, 8, 25, 0, 0, 0) == o.OrderDate).FirstOrDefault();
            Assert.IsNotNull(actual);

            var item = db.Orders.Where(o => o.OrderDate == dt && SqlFunctions.ToDateTime(1997, 8, 25, 0, 0, 0) == o.OrderDate).FirstOrDefault();
            Assert.IsNotNull(item);
        }

        [TestMethod]
        public virtual void TestDateTimeToDateNew()
        {
            DateTime dt = new DateTime(1997, 8, 25);
            var actual = db.Orders.Select(o => o.OrderDate == dt && SqlFunctions.ToDate(1997, 8, 25) == o.OrderDate.Date).FirstOrDefault();
            Assert.IsNotNull(actual);

            var item = db.Orders.Where(o => o.OrderDate == dt && SqlFunctions.ToDate(1997, 8, 25) == o.OrderDate.Date).FirstOrDefault();
            Assert.IsNotNull(item);
        }


        [TestMethod]
        public virtual void TestDateTimeDateDiffYearNew()
        {
            DateTime dt = new DateTime(1997, 8, 25);
            DateTime dt1 = new DateTime(1996, 9, 15);
            var expected = dt.Year - dt1.Year;

            var actual = db.Orders.Select(o => o.OrderDate == dt && SqlFunctions.DateDiff(DateParts.Year, o.OrderDate, dt1) == expected).FirstOrDefault();
            Assert.IsNotNull(actual);

            var item = db.Orders.Where(o => o.OrderDate == dt && SqlFunctions.DateDiff(DateParts.Year, dt1, o.OrderDate) == expected).FirstOrDefault();
            Assert.IsNotNull(item);
        }

        [TestMethod]
        public virtual void TestDateTimeDateDiffMonthNew()
        {
            DateTime dt = new DateTime(1997, 8, 25);
            DateTime dt1 = new DateTime(1996, 1, 15);
            var actual = db.Orders.Select(o => o.OrderDate == dt && SqlFunctions.DateDiff(DateParts.Month, o.OrderDate, dt1) == 19).FirstOrDefault();
            Assert.IsNotNull(actual);

            var item = db.Orders.Where(o => o.OrderDate == dt && SqlFunctions.DateDiff(DateParts.Month, dt1, o.OrderDate) == 19).FirstOrDefault();
            Assert.IsNotNull(item);
        }

        [TestMethod]
        public virtual void TestDateTimeDateDiffDayNew()
        {
            DateTime dt = new DateTime(1997, 8, 25);
            DateTime dt1 = new DateTime(1996, 1, 15);
            var expected = (dt - dt1).Days;
            var actual = db.Orders.Select(o => o.OrderDate == dt && SqlFunctions.DateDiff(DateParts.Day, o.OrderDate, dt1) == expected).FirstOrDefault();
            Assert.IsNotNull(actual);

            var item = db.Orders.Where(o => o.OrderDate == dt && SqlFunctions.DateDiff(DateParts.Day, dt1, o.OrderDate) == expected).FirstOrDefault();
            Assert.IsNotNull(item);
        }

        [TestMethod]
        public virtual void TestDateTimeDateDiffHourNew()
        {
            DateTime dt = new DateTime(1997, 8, 25, 0, 0, 0);
            DateTime dt1 = new DateTime(1996, 1, 15, 10, 20, 30);
            var expected = (dt - dt1).Hours;
            var actual = db.Orders.Select(o => o.OrderDate == dt && SqlFunctions.DateDiff(DateParts.Hour, o.OrderDate, dt1) == expected).FirstOrDefault();
            Assert.IsNotNull(actual);
            var expected1 = (dt - dt1).TotalHours;
#if SQLite || Oracle
            var item = db.Orders.Where(o => o.OrderDate == dt && SqlMethods.DateDiffHour(dt1, o.OrderDate) == (int)expected1).FirstOrDefault();
            Assert.IsNotNull(item);
#else
            var item = db.Orders.Where(o => o.OrderDate == dt && SqlFunctions.DateDiff(DateParts.Hour, dt1, o.OrderDate) - 1 == (int)expected1).FirstOrDefault();
            Assert.IsNotNull(item);
#endif
        }



        [TestMethod]
        public virtual void TestDateTimeDateDiffMinuteNew()
        {
            DateTime dt = new DateTime(1997, 8, 25, 0, 0, 0);
            DateTime dt1 = new DateTime(1996, 1, 15, 10, 20, 30);
            var expected = (dt - dt1).Minutes;
            var actual = db.Orders.Select(o => o.OrderDate == dt && SqlFunctions.DateDiff(DateParts.Minute, o.OrderDate, dt1) == expected).FirstOrDefault();
            Assert.IsNotNull(actual);
            var expected1 = (dt - dt1).TotalMinutes;


#if SQLite || Oracle
            var item = db.Orders.Where(o => o.OrderDate == dt && SqlMethods.DateDiffMinute(dt1, o.OrderDate) == (int)expected1).FirstOrDefault();
            Assert.IsNotNull(item);
#else
            var item = db.Orders.Where(o => o.OrderDate == dt && SqlFunctions.DateDiff(DateParts.Minute, dt1, o.OrderDate) - 1 == (int)expected1).FirstOrDefault();
            Assert.IsNotNull(item);
#endif
        }

        [TestMethod]
        public virtual void TestDateTimeDateDiffSecondNew()
        {
            DateTime dt = new DateTime(1997, 8, 25, 0, 0, 0);
            DateTime dt1 = new DateTime(1996, 1, 15, 10, 20, 30);
            var expected = (dt - dt1).Seconds;
            var actual = db.Orders.Select(o => o.OrderDate == dt && SqlFunctions.DateDiff(DateParts.Second, o.OrderDate, dt1) == expected).FirstOrDefault();
            Assert.IsNotNull(actual);
            var expected1 = (dt - dt1).TotalSeconds;


#if Oracle
            var item = db.Orders.Where(o => o.OrderDate == dt && SqlMethods.DateDiffSecond(dt1, o.OrderDate)+1 == (int)expected1).FirstOrDefault();
            Assert.IsNotNull(item);
#else
            var item = db.Orders.Where(o => o.OrderDate == dt && SqlFunctions.DateDiff(DateParts.Second, dt1, o.OrderDate) == (int)expected1).FirstOrDefault();
            Assert.IsNotNull(item);
#endif
        }

        [TestMethod]
        public virtual void TestDateTimeDateDiffMillisecondNew()
        {
            DateTime dt = new DateTime(1997, 8, 25, 0, 0, 0);
            DateTime dt1 = new DateTime(1996, 1, 15, 10, 20, 30);
            var expected = (dt - dt1).Milliseconds;
            var actual = db.Orders.Select(o => o.OrderDate == dt && SqlFunctions.DateDiff(DateParts.Millisecond, o.OrderDate, dt1) == expected).FirstOrDefault();
            Assert.IsNotNull(actual);

            //溢出
            //var expected1 = (dt - dt1).TotalMilliseconds;
            //var item = db.Orders.Where(o => o.OrderDate == dt && SqlMethods.DateDiffMillisecond(dt1, o.OrderDate) == (int)expected1).FirstOrDefault();
            //Assert.IsNotNull(item);
        }

        //..........................................................................................NEW

        [TestMethod]
        public virtual void DateTimeNow()
        {
            DateTime dt = new DateTime(1997, 8, 25);


            var actual = db.Orders.Where(o => o.OrderDate == dt && SqlFunctions.Between(DateTime.Now, o.OrderDate, new DateTime(2015, 10, 10))).FirstOrDefault();
            Assert.IsNotNull(actual);


        }

        [TestMethod]
        public virtual void DateDiffYear()
        {
            DateTime dt = new DateTime(1997, 8, 25);
            DateTime dt1 = new DateTime(1996, 9, 15);
            var expected = dt.Year - dt1.Year;

            var actual = db.Orders.Select(o => o.OrderDate == dt && SqlMethods.DateDiffYear(o.OrderDate, dt1) == expected).FirstOrDefault();
            Assert.IsNotNull(actual);

            var item = db.Orders.Where(o => o.OrderDate == dt && SqlMethods.DateDiffYear(dt1, o.OrderDate) == expected).FirstOrDefault();
            Assert.IsNotNull(item);
        }

        [TestMethod]
        public virtual void DateDiffMonth()
        {
            DateTime dt = new DateTime(1997, 8, 25);
            DateTime dt1 = new DateTime(1996, 1, 15);
            var actual = db.Orders.Select(o => o.OrderDate == dt && SqlMethods.DateDiffMonth(o.OrderDate, dt1) == 19).FirstOrDefault();
            Assert.IsNotNull(actual);

            var item = db.Orders.Where(o => o.OrderDate == dt && SqlMethods.DateDiffMonth(dt1, o.OrderDate) == 19).FirstOrDefault();
            Assert.IsNotNull(item);
        }

        [TestMethod]
        public virtual void DateDiffDay()
        {
            DateTime dt = new DateTime(1997, 8, 25);
            DateTime dt1 = new DateTime(1996, 1, 15);
            var expected = (dt - dt1).Days;
            var actual = db.Orders.Select(o => o.OrderDate == dt && SqlMethods.DateDiffDay(o.OrderDate, dt1) == expected).FirstOrDefault();
            Assert.IsNotNull(actual);

            var item = db.Orders.Where(o => o.OrderDate == dt && SqlMethods.DateDiffDay(dt1, o.OrderDate) == expected).FirstOrDefault();
            Assert.IsNotNull(item);
        }

        [TestMethod]
        public virtual void DateDiffHour()
        {
            DateTime dt = new DateTime(1997, 8, 25, 0, 0, 0);
            DateTime dt1 = new DateTime(1996, 1, 15, 10, 20, 30);
            var expected = (dt - dt1).Hours;
            var actual = db.Orders.Select(o => o.OrderDate == dt && SqlMethods.DateDiffHour(o.OrderDate, dt1) == expected).FirstOrDefault();
            Assert.IsNotNull(actual);
            var expected1 = (dt - dt1).TotalHours;
#if SQLite || Oracle
            var item = db.Orders.Where(o => o.OrderDate == dt && SqlMethods.DateDiffHour(dt1, o.OrderDate) == (int)expected1).FirstOrDefault();
            Assert.IsNotNull(item);
#else
            var item = db.Orders.Where(o => o.OrderDate == dt && SqlMethods.DateDiffHour(dt1, o.OrderDate) - 1 == (int)expected1).FirstOrDefault();
            Assert.IsNotNull(item);
#endif
        }



        [TestMethod]
        public virtual void DateDiffMinute()
        {
            DateTime dt = new DateTime(1997, 8, 25, 0, 0, 0);
            DateTime dt1 = new DateTime(1996, 1, 15, 10, 20, 30);
            var expected = (dt - dt1).Minutes;
            var actual = db.Orders.Select(o => o.OrderDate == dt && SqlMethods.DateDiffMinute(o.OrderDate, dt1) == expected).FirstOrDefault();
            Assert.IsNotNull(actual);
            var expected1 = (dt - dt1).TotalMinutes;


#if SQLite || Oracle
            var item = db.Orders.Where(o => o.OrderDate == dt && SqlMethods.DateDiffMinute(dt1, o.OrderDate) == (int)expected1).FirstOrDefault();
            Assert.IsNotNull(item);
#else
            var item = db.Orders.Where(o => o.OrderDate == dt && SqlMethods.DateDiffMinute(dt1, o.OrderDate) - 1 == (int)expected1).FirstOrDefault();
            Assert.IsNotNull(item);
#endif
        }

        [TestMethod]
        public virtual void DateDiffSecond()
        {
            DateTime dt = new DateTime(1997, 8, 25, 0, 0, 0);
            DateTime dt1 = new DateTime(1996, 1, 15, 10, 20, 30);
            var expected = (dt - dt1).Seconds;
            var actual = db.Orders.Select(o => o.OrderDate == dt && SqlMethods.DateDiffSecond(o.OrderDate, dt1) == expected).FirstOrDefault();
            Assert.IsNotNull(actual);
            var expected1 = (dt - dt1).TotalSeconds;


#if Oracle
            var item = db.Orders.Where(o => o.OrderDate == dt && SqlMethods.DateDiffSecond(dt1, o.OrderDate)+1 == (int)expected1).FirstOrDefault();
            Assert.IsNotNull(item);
#else
            var item = db.Orders.Where(o => o.OrderDate == dt && SqlMethods.DateDiffSecond(dt1, o.OrderDate) == (int)expected1).FirstOrDefault();
            Assert.IsNotNull(item);
#endif
        }

        [TestMethod]
        public virtual void DateDiffMillisecond()
        {
            DateTime dt = new DateTime(1997, 8, 25, 0, 0, 0);
            DateTime dt1 = new DateTime(1996, 1, 15, 10, 20, 30);
            var expected = (dt - dt1).Milliseconds;
            var actual = db.Orders.Select(o => o.OrderDate == dt && SqlMethods.DateDiffMillisecond(o.OrderDate, dt1) == expected).FirstOrDefault();
            Assert.IsNotNull(actual);

            //溢出
            //var expected1 = (dt - dt1).TotalMilliseconds;
            //var item = db.Orders.Where(o => o.OrderDate == dt && SqlMethods.DateDiffMillisecond(dt1, o.OrderDate) == (int)expected1).FirstOrDefault();
            //Assert.IsNotNull(item);
        }

        [TestMethod]
        public void Test()
        {
            var start = DateTime.Parse("1997-08-25 00:00:00");
            var end = DateTime.Parse("1996-01-15 10:20:30");

            var offset = start - end;
            Console.WriteLine(offset.TotalHours);
        }

        [TestMethod]
        public virtual void DateDiffYearNullable()
        {
            DateTime dt = new DateTime(1997, 8, 25);
            var actual = db.Orders.Select(o => o.OrderDate == dt && SqlMethods.DateDiffYear(o.OrderDate, null) == null).FirstOrDefault();
            Assert.IsNotNull(actual);

            var item = db.Orders.Where(o => o.OrderDate == dt && SqlMethods.DateDiffYear(null, o.OrderDate) == null).FirstOrDefault();
            Assert.IsNotNull(item);
        }

        [TestMethod]
        public virtual void DateDiffMonthNullable()
        {
            DateTime dt = new DateTime(1997, 8, 25);
            var actual = db.Orders.Select(o => o.OrderDate == dt && SqlMethods.DateDiffMonth(o.OrderDate, null) == null).FirstOrDefault();
            Assert.IsNotNull(actual);

            var item = db.Orders.Where(o => o.OrderDate == dt && SqlMethods.DateDiffMonth(null, o.OrderDate) == null).FirstOrDefault();
            Assert.IsNotNull(item);
        }

        [TestMethod]
        public virtual void DateDiffDayNullable()
        {
            DateTime dt = new DateTime(1997, 8, 25);
            var actual = db.Orders.Select(o => o.OrderDate == dt && SqlMethods.DateDiffDay(o.OrderDate, null) == null).FirstOrDefault();
            Assert.IsNotNull(actual);

            var item = db.Orders.Where(o => o.OrderDate == dt && SqlMethods.DateDiffDay(null, o.OrderDate) == null).FirstOrDefault();
            Assert.IsNotNull(item);
        }
#if ! Oracle
        [TestMethod]
        public virtual void DateDiffHourNullable()
        {
            DateTime dt = new DateTime(1997, 8, 25, 0, 0, 0);
            var actual = db.Orders.Select(o => o.OrderDate == dt && SqlMethods.DateDiffHour(o.OrderDate, null) == null).FirstOrDefault();
            Assert.IsNotNull(actual);

            var item = db.Orders.Where(o => o.OrderDate == dt && SqlMethods.DateDiffHour(null, o.OrderDate) - 1 == null).FirstOrDefault();
            Assert.IsNotNull(item);
        }

        [TestMethod]
        public virtual void DateDiffMinuteNullable()
        {
            DateTime dt = new DateTime(1997, 8, 25, 0, 0, 0);
            var actual = db.Orders.Select(o => o.OrderDate == dt && SqlMethods.DateDiffMinute(o.OrderDate, null) == null).FirstOrDefault();
            Assert.IsNotNull(actual);

            var item = db.Orders.Where(o => o.OrderDate == dt && SqlMethods.DateDiffMinute(null, o.OrderDate) - 1 == null).FirstOrDefault();
            Assert.IsNotNull(item);
        }

        [TestMethod]
        public virtual void DateDiffSecondNullable()
        {
            DateTime dt = new DateTime(1997, 8, 25, 0, 0, 0);
            var actual = db.Orders.Select(o => o.OrderDate == dt && SqlMethods.DateDiffSecond(o.OrderDate, null) == null).FirstOrDefault();
            Assert.IsNotNull(actual);

            var item = db.Orders.Where(o => o.OrderDate == dt && SqlMethods.DateDiffSecond(null, o.OrderDate) == null).FirstOrDefault();
            Assert.IsNotNull(item);
        }
#endif
#if Access || MySQL || SqlCE || Oracle
        [ExpectedException(typeof(NotSupportedException))]
#endif
        [TestMethod]
        public virtual void DateDiffMillisecondNullable()
        {
            DateTime dt = new DateTime(1997, 8, 25, 0, 0, 0);
            var actual = db.Orders.Select(o => o.OrderDate == dt && SqlMethods.DateDiffMillisecond(o.OrderDate, null) == null).FirstOrDefault();
            Assert.IsNotNull(actual);

            var item = db.Orders.Where(o => o.OrderDate == dt && SqlMethods.DateDiffMillisecond(null, o.OrderDate) == null).FirstOrDefault();
            Assert.IsNotNull(item);
        }

    }

}
