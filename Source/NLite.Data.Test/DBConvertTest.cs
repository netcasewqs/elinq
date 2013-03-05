using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestInitialize = NUnit.Framework.SetUpAttribute;
using TestMethod = NUnit.Framework.TestAttribute;
using NLite.Collections;
using System.Linq.Expressions;
using System.Globalization;
using System.ComponentModel;
using NLite.Data.Test.Primitive.Model;
namespace NLite.Data.Test
{
    /// <summary>
    /// DBConvertTest 的摘要说明
    /// </summary>
    [TestClass]
    public class DBConvertTest : TestBase<NullableTypeInfo>
    {
        protected override string ConnectionStringName
        {
            get
            {
                return "NumericDB";
            }
        }

        [TestMethod]
        public virtual void CConvert()
        {
            Db.Set<NullableTypeInfo>().Delete(p => true);
            Db.Set<NullableTypeInfo>().Insert(new NullableTypeInfo { String = "10395", Int32 = 10395 });
            var item = Db.Set<NullableTypeInfo>().First(p => Convert.ToInt32(p.String) == 10395);
            Assert.IsNotNull(item);
            Assert.AreEqual(Convert.ToInt32("10395"), item.Int32);
            Db.Set<NullableTypeInfo>().Delete(p => true);
        }
    }
}
