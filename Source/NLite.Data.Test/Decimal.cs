using System.Linq;
using NLite.Data.Test.Model;
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestMethod = NUnit.Framework.TestAttribute;

namespace NLite.Data.Test.Where
{
    [TestClass]
    public class Decimal : TestBase<MathModel>
    {
        protected override string ConnectionStringName
        {
            get
            {
                return "g_jia";
            }
        }
        //SELECT * FROM [MathTest] WHERE ((d+23.2546) = 46.5092)
        [TestMethod]
        public virtual void Add()
        {
            Db.Set<MathModel>().Where(p => decimal.Add(p.d, 23.2546M) == 46.5092M);

        }
        // SELECT * FROM [MathTest] WHERE ((d-23.2546) = 0)
        [TestMethod]
        public virtual void Subtract()
        {
            /*Db.Set<MathModel>().Where(p => decimal.Subtract(p.d+0M,23.2546M) == 0M).Dump();
            */
            Db.Set<MathModel>().Where<MathModel>(p => decimal.Subtract(p.d + 0M, 23.2546M) == 0M);

        }
        // SELECT * FROM [MathTest] WHERE ((d*0.1) = 2.32546)
        [TestMethod]
        public virtual void Multiply()
        {
            Db.Set<MathModel>().Where(p => decimal.Multiply(p.d, 0.1M) == 2.32546M);

        }
        // SELECT * FROM [MathTest] WHERE ((d/0.1) = 232.546)
        [TestMethod]
        public virtual void Divide()
        {
            Db.Set<MathModel>().Where(p => decimal.Divide(p.d, 0.1M) == 232.546M);


        }
        // SELECT * FROM [MathTest] WHERE (d mod 23.2546 = 0)
        [TestMethod]
        public virtual void Remainder()
        {
            Db.Set<MathModel>().Select(p => p).Where(p => decimal.Remainder(p.d, 23.2546M) == 0M);
            //item.Dump();

        }
        // SELECT * FROM [MathTest] WHERE (-d = -23.2546)
        [TestMethod]
        public virtual void Neget()
        {
            Db.Set<MathModel>().Where(p => decimal.Negate(p.d) == -23.2546M);

        }
        // SELECT * FROM [MathTest] WHERE (round(d) = 23)
        [TestMethod]
        public virtual void Ceiling()
        {
            Db.Set<MathModel>().Where(p => decimal.Ceiling(p.d) == 23);

        }

        // SELECT * FROM [MathTest] WHERE (Fix(d) = 23)
        [TestMethod]
        public virtual void Floor()
        {
            Db.Set<MathModel>().Where(p => decimal.Floor(p.d) == 23);

        }
        // SELECT * FROM [MathTest] WHERE (int(d) = 23)
        [TestMethod]
        public virtual void Truncate()
        {
            Db.Set<MathModel>().Where(p => decimal.Truncate(p.d) == 23);

        }
        // SELECT * FROM [MathTest] WHERE (ROUND(d) = 23)
        [TestMethod]
        public virtual void Round()
        {
            Db.Set<MathModel>().Where(p => decimal.Round(p.d) == 23);

        }
    }
}
