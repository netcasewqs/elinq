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
using NLite.Data.Test;
using NLite.Data.Test.Model;

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
            var data = -51;
            var expected = Math.Abs(data);
            Db.Set<MathModel>().Delete(p => true);
            Db.Set<MathModel>().Insert(new MathModel { a = 51, b = -51, c = 51.15, d = 51.15M });
            var actual = Db.Set<MathModel>().Select(p => Math.Abs(p.b)).FirstOrDefault();
            Assert.AreEqual(expected, actual);

            var item = Db.Set<MathModel>().Where(p => Math.Abs(p.b) == expected).FirstOrDefault();
            Assert.IsNotNull(item);
            Db.Set<MathModel>().Delete(p => true);
        }
        [TestMethod]
        public void Sign()
        {
            var data = -51;
            var expected = Math.Sign(data);
            Db.Set<MathModel>().Delete(p => true);
            Db.Set<MathModel>().Insert(new MathModel { a = 51, b = -51, c = 51.15, d = 51.15M });

            var actual = Db.Set<MathModel>().Select(p => Math.Sign(p.b)).FirstOrDefault();
            Assert.AreEqual(expected, actual);

            var item = Db.Set<MathModel>().Where(p => Math.Sign(p.b) == expected).FirstOrDefault();
            Assert.IsNotNull(item);

            Db.Set<MathModel>().Delete(p => true);
        }
        [TestMethod]
        public void Ceiling()
        {
            double data = 51.15;
            var expected = Math.Ceiling(data);
            Db.Set<MathModel>().Delete(p => true);
            Db.Set<MathModel>().Insert(new MathModel { a = 51, b = -51, c = 51.25, d = 51.15M });

            var actual = Db.Set<MathModel>().Select(p => Math.Ceiling(p.c)).FirstOrDefault();
            Assert.AreEqual(expected, actual);

            var item = Db.Set<MathModel>().Where(p => Math.Ceiling(p.c) == expected).FirstOrDefault();
            Assert.IsNotNull(item);

            Db.Set<MathModel>().Delete(p => true);
        }
        [TestMethod]
        public void Floor()
        {
            var data = 51.15;
            var expected = Math.Floor(data);
            Db.Set<MathModel>().Delete(p => true);
            Db.Set<MathModel>().Insert(new MathModel { a = 51, b = -51, c = 51.15, d = 51.15M });
            var actual = Db.Set<MathModel>().Select(p => Math.Floor(p.c)).FirstOrDefault();
            Assert.AreEqual(expected, actual);

            var item = Db.Set<MathModel>().Where(p => Math.Floor(p.c) == expected).FirstOrDefault();
            Assert.IsNotNull(item);
            Db.Set<MathModel>().Delete(p => true);
        }
        [TestMethod]
        public void Round()
        {
            double data = 51.15;
            var expected = Math.Round(data);
            Db.Set<MathModel>().Delete(p => true);
            Db.Set<MathModel>().Insert(new MathModel { a = 51, b = -51, c = 51.15, d = 51.15M });
            var actual = Db.Set<MathModel>().Select(p => Math.Round(p.c)).FirstOrDefault();
            Assert.AreEqual(expected, actual);

            var item = Db.Set<MathModel>().Where(p => Math.Round(p.c) == expected).FirstOrDefault();
            Assert.IsNotNull(item);
            Db.Set<MathModel>().Delete(p => true);
        }
        [TestMethod]
        //#if Access||SqlServer
        //        [ExpectedException(typeof(QueryException))]
        //        //access数据库中Acos函数表达式中未定义 WHERE ((acos(t0.c)=0))
        //            //SqlServer:无效的浮点数操作
        //#endif       
        public void Acos()
        {
            var data = 1;
            var expected = Math.Acos(data);
            Db.Set<MathModel>().Delete(p => true);
            Db.Set<MathModel>().Insert(new MathModel { a = 51, b = 1, c = 51.15, d = 51.15M });
            var actual = Db.Set<MathModel>().Select(p => Math.Acos(p.b)).FirstOrDefault();
            Assert.AreEqual(expected, actual);

            var item = Db.Set<MathModel>().Where(p => Math.Round(Math.Acos(p.b), 5) == Math.Round(expected, 5)).FirstOrDefault();
            Assert.IsNotNull(item);
            Db.Set<MathModel>().Delete(p => true);
        }
        [TestMethod]
        //#if Access||SqlServer
        //        [ExpectedException(typeof(QueryException))]
        //            //access数据库中Asin函数表达式中未定义  WHERE ((asin(t0.c)=0))
        //        //SqlServer:出现无效的浮点操作
        //#endif        
        public void Asin()
        {
            var data = -1;
            var expected = Math.Asin(data);
            Db.Set<MathModel>().Delete(p => true);
            Db.Set<MathModel>().Insert(new MathModel { a = 51, b = -1, c = 51.15, d = 51.15M });
            var actual = Db.Set<MathModel>().Select(p => Math.Asin(p.b)).FirstOrDefault();
            Assert.AreEqual(expected, actual);

            var item = Db.Set<MathModel>().Where(p => Math.Round(Math.Asin(p.b), 5) == Math.Round(expected, 5)).FirstOrDefault();
            Assert.IsNotNull(item);
            Db.Set<MathModel>().Delete(p => true);
        }
        [TestMethod]
        public void Atan()
        {
            var data = 1;
            var expected = Math.Atan(data);
            Db.Set<MathModel>().Delete(p => true);
            Db.Set<MathModel>().Insert(new MathModel { a = 51, b = 1, c = 51.15, d = 51.15M });
            var actual = Db.Set<MathModel>().Select(p => Math.Atan(p.b)).FirstOrDefault();
            Assert.AreEqual(expected, actual);

            var item = Db.Set<MathModel>().Where(p => Math.Round(Math.Atan(p.b), 5) == Math.Round(expected, 5)).FirstOrDefault();
            Assert.IsNotNull(item);
            Db.Set<MathModel>().Delete(p => true);
        }
        [TestMethod]
        public void Sin()
        {
            var data = -51;
            var expected = Math.Sin(data);
            Db.Set<MathModel>().Delete(p => true);
            Db.Set<MathModel>().Insert(new MathModel { a = 51, b = -51, c = 51.15, d = 51.15M });
            var actual = Db.Set<MathModel>().Select(p => Math.Sin(p.b)).FirstOrDefault();
            Assert.AreEqual(expected, actual);

            var item = Db.Set<MathModel>().Where(p => Math.Round(Math.Sin(p.b), 5) == Math.Round(expected, 5)).FirstOrDefault();
            Assert.IsNotNull(item);
            Db.Set<MathModel>().Delete(p => true);
        }
        [TestMethod]
        public void Cos()
        {
            var data = -51;
            var expected = Math.Cos(data);
            Db.Set<MathModel>().Delete(p => true);
            Db.Set<MathModel>().Insert(new MathModel { a = 51, b = -51, c = 51.15, d = 51.15M });
            var actual = Db.Set<MathModel>().Select(p => Math.Cos(p.b)).FirstOrDefault();
            Assert.AreEqual(expected, actual);

            var item = Db.Set<MathModel>().Where(p => Math.Round(Math.Cos(p.b), 5) == Math.Round(expected, 5)).FirstOrDefault();
            Assert.IsNotNull(item);
            Db.Set<MathModel>().Delete(p => true);
        }
        [TestMethod]

        //#if SqlCE||SqlServer||MySQL
        //        //SqlServer:COSH' 不是可以识别的 内置函数名称。
        //        [ExpectedException(typeof(QueryException))]
        //#endif
        public void Cosh()
        {
            var data = -51;
            var expected = Math.Cosh(data);
            Db.Set<MathModel>().Delete(p => true);
            Db.Set<MathModel>().Insert(new MathModel { a = 51, b = -51, c = 51.15, d = 51.15M });
            var actual = Db.Set<MathModel>().Select(p => Math.Cosh(p.b)).FirstOrDefault();
            Assert.AreEqual(expected, actual);

            var item = Db.Set<MathModel>().Where(p => Math.Cosh(p.b) == expected).FirstOrDefault();
            Assert.IsNotNull(item);
            Db.Set<MathModel>().Delete(p => true);
        }
        [TestMethod]
        //#if SqlCE||SqlServer
        //        [ExpectedException(typeof(NotSupportedException))]
        //#endif
        public void Sinh()
        {
            var data = -51;
            var expected = Math.Sinh(data);
            Db.Set<MathModel>().Delete(p => true);
            Db.Set<MathModel>().Insert(new MathModel { a = 51, b = -51, c = 51.15, d = 51.15M });
            var actual = Db.Set<MathModel>().Select(p => Math.Sinh(p.b)).FirstOrDefault();
            Assert.AreEqual(expected, actual);

            var item = Db.Set<MathModel>().Where(p => Math.Sinh(p.b) == expected).FirstOrDefault();
            Assert.IsNotNull(item);
            Db.Set<MathModel>().Delete(p => true);
        }
        [TestMethod]
        public void Exp()
        {
            var data = -1;
            var expected = Math.Exp(data);
            Db.Set<MathModel>().Delete(p => true);
            Db.Set<MathModel>().Insert(new MathModel { a = 51, b = -1, c = 51.15, d = 51.15M });
            var actual = Db.Set<MathModel>().Select(p => Math.Exp(p.b)).FirstOrDefault();
            Assert.AreEqual(expected, actual);

            var item = Db.Set<MathModel>().Where(p => Math.Round(Math.Exp(p.b), 5) == Math.Round(expected, 5)).FirstOrDefault();
            Assert.IsNotNull(item);
            Db.Set<MathModel>().Delete(p => true);
        }

        [TestMethod]
        public void Log()
        {
            var data = 1;
            var expected = Math.Log(data);
            Db.Set<MathModel>().Delete(p => true);
            Db.Set<MathModel>().Insert(new MathModel { a = 51, b = 1, c = 51.15, d = 51.15M });
            var actual = Db.Set<MathModel>().Select(p => Math.Log(p.b)).FirstOrDefault();
            Assert.AreEqual(expected, actual);

            var item = Db.Set<MathModel>().Where(p => Math.Log(p.b) == expected).FirstOrDefault();
            Assert.IsNotNull(item);
            Db.Set<MathModel>().Delete(p => true);
        }
        [TestMethod]
        public void Log10()
        {
            var data = 10;
            var expected = Math.Log10(data);
            Db.Set<MathModel>().Delete(p => true);
            Db.Set<MathModel>().Insert(new MathModel { a = 51, b = 10, c = 51.15, d = 51.15M });
            var actual = Db.Set<MathModel>().Select(p => Math.Log10(p.b)).FirstOrDefault();
            Assert.AreEqual(expected, actual);

            var item = Db.Set<MathModel>().Where(p => Math.Log10(p.b) == expected).FirstOrDefault();
            Assert.IsNotNull(item);
            Db.Set<MathModel>().Delete(p => true);
        }
        [TestMethod]
        public void Power()
        {
            var data = 2;
            var expected = Math.Pow(1.2, data);
            Db.Set<MathModel>().Delete(p => true);
            Db.Set<MathModel>().Insert(new MathModel { a = 51, b = 2, c = 51.15, d = 51.15M });
            var actual = Db.Set<MathModel>().Select(p => Math.Pow(1.2, p.b)).FirstOrDefault();
            Assert.AreEqual(expected, actual);

            var item = Db.Set<MathModel>().Where(p => Math.Round(Math.Pow(1.2, p.b), 1) == Math.Round(expected, 1)).FirstOrDefault();
            Assert.IsNotNull(item);
            Db.Set<MathModel>().Delete(p => true);
        }
        [TestMethod]
        //#if SQLite
        //        [ExpectedException(typeof(NotSupportedException))]
        //#endif
        public void Truncate()
        {
            double data = 51.15;
            var expected = Math.Truncate(data);
            Db.Set<MathModel>().Delete(p => true);
            Db.Set<MathModel>().Insert(new MathModel { a = 51, b = -51, c = 51.15, d = 51.15M });
            var actual = Db.Set<MathModel>().Select(p => Math.Truncate(p.c)).FirstOrDefault();
            Assert.AreEqual(expected, actual);

            var item = Db.Set<MathModel>().Where(p => Math.Truncate(p.c) == expected).FirstOrDefault();
            Assert.IsNotNull(item);
            Db.Set<MathModel>().Delete(p => true);
        }
        [TestMethod]
        public void Sqrt()
        {
            var data = 64;
            var expected = Math.Sqrt(data);
            Db.Set<MathModel>().Delete(p => true);
            Db.Set<MathModel>().Insert(new MathModel { a = 51, b = 64, c = 51.15, d = 51.15M });
            var actual = Db.Set<MathModel>().Select(p => Math.Sqrt(p.b)).FirstOrDefault();
            Assert.AreEqual(expected, actual);

            var item = Db.Set<MathModel>().Where(p => Math.Sqrt(p.b) == expected).FirstOrDefault();
            Assert.IsNotNull(item);
            Db.Set<MathModel>().Delete(p => true);
        }
        [TestMethod]
        public void Tan()
        {
            var data = -51;
            var expected = Math.Tan(data);
            Db.Set<MathModel>().Delete(p => true);
            Db.Set<MathModel>().Insert(new MathModel { a = 51, b = -51, c = 51.15, d = 51.15M });
            var actual = Db.Set<MathModel>().Select(p => Math.Tan(p.b)).FirstOrDefault();
            Assert.AreEqual(expected, actual);

            var item = Db.Set<MathModel>().Where(p => Math.Round(Math.Tan(p.b), 5) == Math.Round(expected, 5)).FirstOrDefault();
            Assert.IsNotNull(item);
            Db.Set<MathModel>().Delete(p => true);
        }
        [TestMethod]
        //#if Access||MySQL
        //[ExpectedException(typeof(QueryException))]
        //#endif
        //#if SqlCE || SqlServer
        //        [ExpectedException(typeof(NotSupportedException))]
        //#endif
        public void Tanh()
        {
            var data = 1;
            var expected = Math.Tanh(data);
            Db.Set<MathModel>().Delete(p => true);
            Db.Set<MathModel>().Insert(new MathModel { a = 51, b = 1, c = 51.15, d = 51.15M });
            var actual = Db.Set<MathModel>().Select(p => Math.Tanh(p.b)).FirstOrDefault();
            Assert.AreEqual(expected, actual);

            var item = Db.Set<MathModel>().Where(p => Math.Round(Math.Tanh(p.b), 5) == Math.Round(expected, 5)).FirstOrDefault();
            Assert.IsNotNull(item);
            Db.Set<MathModel>().Delete(p => true);
        }
        [TestMethod]
        //#if Access
        //        [ExpectedException(typeof(QueryException))]
        //#endif
        public void Atan2()
        {
            var data = 1;
            var expected = Math.Atan2(2, data);
            Db.Set<MathModel>().Delete(p => true);
            Db.Set<MathModel>().Insert(new MathModel { a = 51, b = 1, c = 51.15, d = 51.15M });
            var actual = Db.Set<MathModel>().Select(p => Math.Atan2(2, p.b)).FirstOrDefault();
            Assert.AreEqual(expected, actual);

            var item = Db.Set<MathModel>().Where(p => Math.Round(Math.Atan2(2, p.b), 5) == Math.Round(expected, 5)).FirstOrDefault();
            Assert.IsNotNull(item);
            Db.Set<MathModel>().Delete(p => true);
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
