using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestInitialize = NUnit.Framework.SetUpAttribute;
using TestMethod = NUnit.Framework.TestAttribute;
using NLite.Data;
using NLite.Data.Test.Primitive.Model;
using NLite.Data.Test.Access.Model;
using NLite.Data.Test;

namespace NLite.Data.Test.Where
{
    /// <summary>
    /// MathTest 的摘要说明
    /// </summary>
    [TestClass]
    public class MathTest : TestBase<MathModel>
    {
        protected override string ConnectionStringName
        {
            get
            {
                return "g_jia";
            }
        }
        [TestMethod]
        public void Abs()
        {
            //SELECT ID,a,b,c,d FROM [MathTest] WHERE (ABS(a) = 12)
            var aa = Db.Set<MathModel>().FirstOrDefault(p=>Math.Abs(p.a)==12);
            aa.Dump();
        }
        [TestMethod]
        public void Sign()
        {
            //SELECT ID,a,b,c,d FROM [MathTest] WHERE(sgn(a) = -1)

            var aa = Db.Set<MathModel>().FirstOrDefault(p => Math.Sign(p.a) == -1);
            aa.Dump();
        }
        [TestMethod]
        public void Ceiling()
        {
            //SELECT * FROM [MathTest] WHERE (round(c) = 125)
            var aa = Db.Set<MathModel>().FirstOrDefault(p => Math.Ceiling(p.c) == 125);
            aa.Dump();
        }
        [TestMethod]
        public void Floor()
        {
            //SELECT ID,a,b,c,d FROM [MathTest] WHERE(Fix(c) = 1254)
            var aa = Db.Set<MathModel>().FirstOrDefault(p => Math.Floor(p.c) == 1254);
            aa.Dump();
        }
        [TestMethod]
        public void Round()
        {
            //SELECT ID,a,b,c,d FROM [MathTest] WHERE (ROUND(c, 1) = 125.30)
            var aa = Db.Set<MathModel>().FirstOrDefault(p => Math.Round(p.c, 1) == 125.30);
            aa.Dump();
        }
        [TestMethod]
#if Access||SqlServer
        [ExpectedException(typeof(QueryException))]
        //access数据库中Acos函数表达式中未定义 WHERE ((acos(t0.c)=0))
            //SqlServer:无效的浮点数操作
#endif       
        public void Acos()
        {
            var aa = Db.Set<MathModel>().FirstOrDefault(p => Math.Acos(p.c) == 0);
            aa.Dump();
        }
        [TestMethod]
#if Access||SqlServer
        [ExpectedException(typeof(QueryException))]
            //access数据库中Asin函数表达式中未定义  WHERE ((asin(t0.c)=0))
        //SqlServer:出现无效的浮点操作
#endif        
        public void Asin()
        {
            var aa = Db.Set<MathModel>().FirstOrDefault(p => Math.Asin(p.c) == 0);
            aa.Dump();
        }
        [TestMethod]
        public void Atan()
        {
            //SELECT ID,a,b,c,d FROM [MathTest] WHERE(atn(c) = 0.7853981633974483)
            var aa = Db.Set<MathModel>().FirstOrDefault(p => Math.Atan(p.c) == 0.7853981633974483);
            aa.Dump();
        }
        [TestMethod]
        public void Sin()
        {
            //SELECT ID,a,b,c,d FROM [MathTest] WHERE(SIN(c) = 0.8414709848078965)
            var aa = Db.Set<MathModel>().FirstOrDefault(p => Math.Sin(p.c) == 0.8414709848078965);
            aa.Dump();
        }
        [TestMethod]
        public void Cos()
        {
            //SELECT ID,a,b,c,d FROM [MathTest] WHERE (COS(c) = 0.54030230586814)
            var aa = Db.Set<MathModel>().FirstOrDefault(p => Math.Cos(p.c) == 0.5403023058681398);
            aa.Dump();
        }
        [TestMethod]
#if Access
        [ExpectedException(typeof(QueryException))]
#endif
#if SqlCE||SqlServer||MySQL
        //SqlServer:COSH' 不是可以识别的 内置函数名称。
        [ExpectedException(typeof(QueryException))]
#endif
        public void Cosh()
        {
            var aa = Db.Set<MathModel>().FirstOrDefault(p => Math.Cosh(p.c) == 0.5403023058681398);
            aa.Dump();
        }
        [TestMethod]
#if SqlCE||SqlServer
        [ExpectedException(typeof(NotSupportedException))]
#endif
#if Access||MySQL
        [ExpectedException(typeof(QueryException))]
#endif
        public void Sinh()
        {
            var aa = Db.Set<MathModel>().FirstOrDefault(p => Math.Sinh(p.c) == 0.5403023058681398);
            aa.Dump();
        }
        [TestMethod]
        public void Exp()
        {
            //SELECT ID,a,b,c,d FROM [MathTest] WHERE ((exp(c) >= 2.71828182845905) AND (c <= 1))
            var aa = Db.Set<MathModel>().FirstOrDefault(p => Math.Exp(p.c) >= 2.718281828459045 && p.c <= 1);
            aa.Dump();
        }

        [TestMethod]
        public void Log()
        {
            //SELECT ID,a,b,c,d FROM [MathTest] WHERE ((LOG(c) = 0))
            var bb = Db.Set<MathModel>().FirstOrDefault(p => Math.Log(p.c) == 0);

            bb.Dump();
        }
        [TestMethod]
        public void Log10()
        {
            //WHERE (("log10(t0.c)"=0))
            var bb = Db.Set<MathModel>().FirstOrDefault(p => Math.Log10(p.c) == 0);
            bb.Dump();
        }
        [TestMethod]
        public void Power()
        {
            var aa = Db.Set<MathModel>().FirstOrDefault(p => Math.Pow(p.c, 2) == 1);
            aa.Dump();
        }
        [TestMethod]
#if SQLite
        [ExpectedException(typeof(NotSupportedException))]
#endif
        public void Truncate()
        {
            //SELECT ID,a,b,c,d FROM [MathTest] WHERE (int(c) = 125)
            var aa = Db.Set<MathModel>().FirstOrDefault(p => Math.Truncate(p.c) == 125);
            aa.Dump();
        }
        [TestMethod]
        public void Sqrt()
        {
            //SELECT ID,a,b,c,d FROM [MathTest] WHERE (sqr(c) = 1)
            var aa = Db.Set<MathModel>().FirstOrDefault(p => Math.Sqrt(p.c) == 1);
            aa.Dump();
        }
        [TestMethod]
        public void Tan()
        {
            //SELECT ID,a,b,c,d FROM [MathTest] WHERE (tan(c) = 1.5574077246549)
            var bb = Db.Set<MathModel>().FirstOrDefault(p => Math.Tan(p.c) == 1.5574077246549023);
            bb.Dump();
        }
        [TestMethod]
#if Access||MySQL
        [ExpectedException(typeof(QueryException))]
#endif
#if SqlCE || SqlServer
        [ExpectedException(typeof(NotSupportedException))]
#endif
        public void Tanh()
        {
            //WHERE (("tanh(t0.c)"=0.761594155955765))
            var bb = Db.Set<MathModel>().FirstOrDefault(p => Math.Tanh(p.c) == 0.7615941559557648);
            bb.Dump();
        }
        [TestMethod]
#if Access
        [ExpectedException(typeof(QueryException))]
#endif
        public void Atan2()
        {
            //WHERE (("atan2(t0.c,1)"=0.785398163397448))
            var aa = Db.Set<MathModel>().FirstOrDefault(p => Math.Atan2(p.c, 1) == 0.7853981633974483);
            aa.Dump();
        }
        [TestMethod]
        public void Random()
        {
        }
        [TestMethod]
        public void Mod()
        {
        }
    }
}
