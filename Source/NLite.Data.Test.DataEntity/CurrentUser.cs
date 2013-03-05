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
    public class CurrentUser
    {
        [TestMethod]
        public void CurrentUserTest()//查看当前用户
        {
            using (var edm = new NorthwindEntities())
            {
                var a = from c in edm.Customers
                        select new{user=SqlFunctions.CurrentUser()};
                Console.WriteLine(a.FirstOrDefault().user);//dbo
                //CURRENT_USER AS [C2]
                a.TraceSql();
            }
        }
        [TestMethod]
        public void CurrentTimeTest()//返回系统时间
        {
            using (var edm = new NorthwindEntities())
            {
                var a = from c in edm.Customers
                        select new { time = SqlFunctions.CurrentTimestamp() };
                Console.WriteLine(a.FirstOrDefault().time);//2013/1/22 14:09:13
                //CURRENT_TIMESTAMP AS [C2]
                a.TraceSql();
            }
        }
        [TestMethod]
        public void DataLengthTest()//返回用于表示任意表达式的字节数。
        {
            using (var edm = new NorthwindEntities())
            {
                var cust1 = from e in edm.Order_Details
                            select SqlFunctions.DataLength("zxm");
                // CAST(DATALENGTH(N'zxm') AS int) AS [C1]
                cust1.TraceSql();
                Console.WriteLine(cust1.First().Value);//6
            }
        }
        [TestMethod]
        public void DateAddTest()//向指定的日期添加间隔，以此返回新的日期值。
        {
            using (var edm = new NorthwindEntities())
            {
                var cust1 = from e in edm.Order_Details
                            select SqlFunctions.DateAdd("Year",1,DateTime.Now);
                //DATEADD(Year, cast(1 as float(53)), SysDateTime()) AS [C1]
                cust1.TraceSql();
                Console.WriteLine(cust1.First().Value);//2014/1/22 14:08:32
            }
        }
        [TestMethod]
        public void DateDiffTest1()//返回所指定开始日期和结束日期之间的指定 datepart 边界的计数。
        {
            using (var edm = new NorthwindEntities())
            {
                var cust1 = from e in edm.Order_Details
                            select SqlFunctions.DateDiff("Day",new DateTime(2012,12,24),DateTime.Now);
                //DATEDIFF(Day, convert(datetime2, '2012-12-24 00:00:00.0000000', 121), SysDateTime()) AS [C1]
                cust1.TraceSql();
                Console.WriteLine(cust1.First().Value);//29
            }
        }
        [TestMethod]
        public void DateDiffTest2()//返回所指定开始日期和结束日期之间的指定 datepart 边界的计数。
        {
            using (var edm = new NorthwindEntities())
            {
                var cust1 = from e in edm.Order_Details
                            select SqlFunctions.DateDiff("Month", new DateTime(2012, 12, 24), DateTime.Now);
                //DATEDIFF(Month, convert(datetime2, '2012-12-24 00:00:00.0000000', 121), SysDateTime()) AS [C1]
                cust1.TraceSql();
                Console.WriteLine(cust1.First().Value);//1
            }
        }
        [TestMethod]
        public void DateDiffTest3()//返回所指定开始日期和结束日期之间的指定 datepart 边界的计数。
        {
            using (var edm = new NorthwindEntities())
            {
                var cust1 = from e in edm.Order_Details
                            select SqlFunctions.DateDiff("Day", "2012-12-24","2013-1-19");
                //DATEDIFF(Day, N'2012-12-24', N'2013-1-19') AS [C1]
                cust1.TraceSql();
                Console.WriteLine(cust1.First().Value);//26
            }
        }
        [TestMethod]
        public void DateNameTest()//返回一个字符串，该字符串表示指定日期的指定 datepart。
        {
            using (var edm = new NorthwindEntities())
            {
                var cust1 = from e in edm.Order_Details
                            select SqlFunctions.DateName("Year",DateTime.Now);
                //DATENAME(Year, SysDateTime()) AS [C1]
                cust1.TraceSql();
                Console.WriteLine(cust1.First());//2013
            }
        }
        [TestMethod]
        public void DatePartTest()//返回表示指定日期的指定日期部分的整数。
        {
            using (var edm = new NorthwindEntities())
            {
                var cust1 = from e in edm.Order_Details
                            select SqlFunctions.DatePart("Year", DateTime.Now);
                //DATEPART(Year, SysDateTime()) AS [C1]
                cust1.TraceSql();
                Console.WriteLine(cust1.First());//2013
            }
        }
        [TestMethod]
        public void DegreesTest()//为以弧度指定的角返回对应的以度数表示的角。
        {
            using (var edm = new NorthwindEntities())
            {
                var cust1 = from e in edm.Order_Details
                            select SqlFunctions.Degrees(3.1415926);
                //DEGREES(cast(3.1415926 as float(53))) AS [C1]
                cust1.TraceSql();
                Console.WriteLine(cust1.First());//179.999996929531
            }
        }
        [TestMethod]
        public void DifferenceTest()//返回指示两个字符表达式的 SOUNDEX 值之差的整数值。
        {
            using (var edm = new NorthwindEntities())
            {
                var cust1 = from e in edm.Order_Details
                            //select SqlFunctions.Difference("zxm","zxm");
                            select SqlFunctions.Difference("1234", "123");
                //DIFFERENCE(N'zxm', N'zxm') AS [C1]
                //DIFFERENCE(N'1234', N'123') AS [C1]
                cust1.TraceSql();
                Console.WriteLine(cust1.First());//4
            }
        }
        [TestMethod]
        public void ExpTest()//返回所指定浮点表达式的指数值。
        {
            using (var edm = new NorthwindEntities())
            {
                var cust1 = from e in edm.Order_Details
                            select SqlFunctions.Exp(1M);
                //EXP(1) AS [C1]
                cust1.TraceSql();
                Console.WriteLine(cust1.First());//2.71828182845905
            }
        }
        [TestMethod]
        public void HostNameTest()//返回工作站名称。
        {
            using (var edm = new NorthwindEntities())
            {
                var cust1 = from e in edm.Order_Details
                            select SqlFunctions.HostName();
                //HOST_NAME() AS [C1]
                cust1.TraceSql();
                Console.WriteLine(cust1.First());//ZXM-PC
            }
        }
        [TestMethod]
        public void IsDateTest()//指示输入值是否为有效的日期或时间。
        {
            using (var edm = new NorthwindEntities())
            {
                var cust1 = from e in edm.Order_Details
                            select SqlFunctions.IsDate("2012-03-45");
                //ISDATE(N'2012-03-45') AS [C1]
                cust1.TraceSql();
                Console.WriteLine(cust1.First());//0
            }
        }
        [TestMethod]
        public void IsNumericTest()//指示输入值是否为有效的数值类型。
        {
            using (var edm = new NorthwindEntities())
            {
                var cust1 = from e in edm.Order_Details
                            select SqlFunctions.IsNumeric("2012-03-45");
                //ISNUMERIC(N'2012-03-45') AS [C1]
                cust1.TraceSql();
                Console.WriteLine(cust1.First());//0
            }
        }
        [TestMethod]
        public void NCharTest()//根据 Unicode 标准的定义，返回具有所指定整数代码的 Unicode 字符。
        {
            using (var edm = new NorthwindEntities())
            {
                var cust1 = from e in edm.Order_Details
                            select SqlFunctions.NChar(98);
                //NCHAR(98) AS [C1]
                cust1.TraceSql();
                Console.WriteLine(cust1.First());//98
            }
        }
        [TestMethod]
        public void PatIndexTest()//返回模式在指定表达式中首次出现的起始位置；如果未找到模式，则为零。适用于所有有效的文本和字符数据类型。
        {
            using (var edm = new NorthwindEntities())
            {
                var cust1 = from p in edm.Products
                            select SqlFunctions.PatIndex("xx-xx",p.ProductName);
                // CAST(PATINDEX(N'xx-xx', [Extent1].[ProductName]) AS int) AS [C1]
                cust1.TraceSql();
                Console.WriteLine(cust1.First());//0
            }
        }
        [TestMethod]
        public void PiTest()//返回 pi 的常量值。
        {
            using (var edm = new NorthwindEntities())
            {
                var cust1 = from p in edm.Products
                            select SqlFunctions.Pi();
                // PI() AS [C1]
                cust1.TraceSql();
                Console.WriteLine(cust1.First());//3.14159265358979
            }
        }
        [TestMethod]
        public void QuoteNameTest1()//返回一个 Unicode 字符串，其中添加有分隔符，以使输入字符串成为有效的 Microsoft SQL Server 分隔标识符。
        {
            using (var edm = new NorthwindEntities())
            {
                var cust1 = from p in edm.Products
                            select SqlFunctions.QuoteName("LinqToEntity");
                //QUOTENAME(N'LinqToEntity') AS [C1]
                cust1.TraceSql();
                Console.WriteLine(cust1.First());//[LinqToEntity]
            }
        }
        [TestMethod]
        public void QuoteNameTest2()//返回一个 Unicode 字符串，其中添加有分隔符，以使输入字符串成为有效的 Microsoft SQL Server 分隔标识符。
        {
            using (var edm = new NorthwindEntities())
            {
                var cust1 = from p in edm.Products
                            select SqlFunctions.QuoteName("LinqToEntity","'");
                //QUOTENAME(N'LinqToEntity', N'''') AS [C1]
                cust1.TraceSql();
                Console.WriteLine(cust1.First());//'LinqToEntity'
            }
        }
        [TestMethod]
        public void RadiansTest()//为以度数指定的角返回对应的弧度度量值。
        {
            using (var edm = new NorthwindEntities())
            {
                var cust1 = from p in edm.Products
                            select SqlFunctions.Radians(180);
                //RADIANS(180) AS [C1]
                cust1.TraceSql();
                Console.WriteLine(cust1.First());//3
            }
        }
        [TestMethod]
        public void RandTest1()//返回一个 0 到 1（均不含）之间的伪随机浮点值,有固定参数时返回值相同
        {
            using (var edm = new NorthwindEntities())
            {
                var cust1 = from p in edm.Products
                            select SqlFunctions.Rand(180);
                //RAND(180) AS [C1]
                cust1.TraceSql();
                Console.WriteLine(cust1.First());//0.716927295068141
            }
        }
        [TestMethod]
        public void RandTest2()//返回一个 0 到 1（均不含）之间的伪随机浮点值。
        {
            using (var edm = new NorthwindEntities())
            {
                var cust1 = from p in edm.Products
                            select SqlFunctions.Rand();
                //RAND(180) AS [C1]
                cust1.TraceSql();
                Console.WriteLine(cust1.First());
            }
        }
        [TestMethod]
        public void ReplicateTest()//将一个字符串值重复指定的次数。
        {
            using (var edm = new NorthwindEntities())
            {
                var cust1 = from p in edm.Products
                            select SqlFunctions.Replicate("Elinq",3);
                //REPLICATE(N'Elinq', 3) AS [C1]
                cust1.TraceSql();
                Console.WriteLine(cust1.First());//ElinqElinqElinq
            }
        }
        [TestMethod]
        public void SoundCodeTest()//将字母数字字符串转换为由四个字符组成的 (SOUNDEX) 代码，以便查找发音相似的字词或名称。
        {
            using (var edm = new NorthwindEntities())
            {
                var cust1 = from p in edm.Products
                            select new{str1=SqlFunctions.SoundCode("too"),str2=SqlFunctions.SoundCode("two")};
                //SOUNDEX(N'too') AS [C2],  SOUNDEX(N'two') AS [C3]
                cust1.TraceSql();
                Console.WriteLine(cust1.First());//{ str1 = T000, str2 = T000 }
            }
        }
        [TestMethod]
        public void SpaceTest()//返回由重复空格组成的字符串。
        {
            using (var edm = new NorthwindEntities())
            {
                var cust1 = from p in edm.Products
                            select new{newStr="EL"+SqlFunctions.Space(2)+"inq"};
                //N'EL' + SPACE(2) + N'inq' AS [C2]
                cust1.TraceSql();
                Console.WriteLine(cust1.First().newStr);//EL  inq
            }
        }
        [TestMethod]
        public void SquareTest()//返回所指定数字的平方。
        {
            using (var edm = new NorthwindEntities())
            {
                var cust1 = from p in edm.Products
                            select SqlFunctions.Square(1.2);
                //SQUARE(cast(1.2 as float(53))) AS [C1]
                cust1.TraceSql();
                Console.WriteLine(cust1.First());//1.44
            }
        }
        [TestMethod]
        public void SquareRootTest()//返回指定数字的平方根。
        {
            using (var edm = new NorthwindEntities())
            {
                var cust1 = from p in edm.Products
                            select SqlFunctions.SquareRoot(2.25);
                //SQRT(cast(2.25 as float(53))) AS [C1]
                cust1.TraceSql();
                Console.WriteLine(cust1.First());//1.5
            }
        }
        [TestMethod]
        public void StringConvertTest1()//返回转换自数值数据的字符数据。
        {
            using (var edm = new NorthwindEntities())
            {
                var cust1 = from p in edm.Products
                            select SqlFunctions.StringConvert(2.25);
                //SQRT(cast(2.25 as float(53))) AS [C1]
                cust1.TraceSql();
                Console.WriteLine("*" + cust1.First() + "*");//*         2*
            }
        }
        [TestMethod]
        public void StringConvertTest2()//返回指定长度的转换自数值数据的字符数据。
        {
            using (var edm = new NorthwindEntities())
            {
                var cust1 = from p in edm.Products
                            select SqlFunctions.StringConvert(2.25,3);
                //SQRT(cast(2.25 as float(53)),3) AS [C1]
                cust1.TraceSql();
                Console.WriteLine("*" + cust1.First() + "*");//*  2*
            }
        }
        [TestMethod]
        public void StringConvertTest3()//返回指定长度和带小数点及之后长度的转换自数值数据的字符数据。
        {
            using (var edm = new NorthwindEntities())
            {
                var cust1 = from p in edm.Products
                            select SqlFunctions.StringConvert(2.25, 4,2);
                //SQRT(cast(2.25 as float(53)),4,3) AS [C1]
                cust1.TraceSql();
                Console.WriteLine("*" + cust1.First() + "*");//*2.25*
            }
        }
        [TestMethod]
        //将一个字符串插入另一个字符串。这会从目标字符串中的起始位置开始，删除指定长度的字符，然后在目标字符串中的起始位置处，插入第二个字符串。
        public void StuffTest()
        {
            using (var edm = new NorthwindEntities())
            {
                var cust1 = from p in edm.Products
                            select SqlFunctions.Stuff("ELinq", 1, 2, "NLite.Data");
                //STUFF(N'ELinq', 1, 2, N'NLite.Data') AS [C1]
                cust1.TraceSql();
                Console.WriteLine(cust1.First());//NLite.Datainq
            }
        }
        [TestMethod]
        //根据 Unicode 标准的定义，返回输入表达式中第一个字符的整数值。
        public void UnicodeTest()
        {
            using (var edm = new NorthwindEntities())
            {
                var cust1 = from p in edm.Products
                            select SqlFunctions.Unicode("ELinq");
                //UNICODE(N'ELinq') AS [C1]
                cust1.TraceSql();
                Console.WriteLine(cust1.First());//69
            }
        }
        [TestMethod]
        //返回与所指定标识号相对应的数据库用户名。
        public void UserNameTest1()
        {
            using (var edm = new NorthwindEntities())
            {
                var cust1 = from p in edm.Products
                            select SqlFunctions.UserName();
                //USER_NAME() AS [C1]
                cust1.TraceSql();
                Console.WriteLine(cust1.First());//dbo
            }
        }
        [TestMethod]
        //返回与所指定标识号相对应的数据库用户名。
        public void UserNameTest2()
        {
            using (var edm = new NorthwindEntities())
            {
                var cust1 = from p in edm.Products
                            select SqlFunctions.UserName(2);
                //USER_NAME(2) AS [C1]
                cust1.TraceSql();
                Console.WriteLine(cust1.First());//guest
            }
        }
    }
}
