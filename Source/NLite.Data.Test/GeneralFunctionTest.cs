using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLite.Data.Test.Primitive;
using NLite.Data.Test.Primitive.Model;
using NUnit.Framework;
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestInitialize = NUnit.Framework.SetUpAttribute;
using TestMethod = NUnit.Framework.TestAttribute;
using NLite.Collections;
using System.Linq.Expressions;
using System.Globalization;
using System.ComponentModel;

namespace NLite.Data.Test
{
    [TestClass]
    public class GeneralFunctionTest : TestBase<NullableTypeInfo>
    {
        protected override string ConnectionStringName
        {
            get
            {
                return "NumericDB";
            }
        }
        [TestMethod]
        public virtual void CompareString()
        { }
        [TestMethod]
        public virtual void Compare()
        {
        }
        [TestMethod]
        public virtual void CompareTo()
        {
            Db.Set<NullableTypeInfo>().Delete(p => true);
            Db.Set<NullableTypeInfo>().Insert(new NullableTypeInfo {String="OK!"});
            //WHERE (((CASE WHEN t0.[String] = @p0 THEN 0 WHEN t0.[String] < @p0 THEN -1 ELSE 1 END)=1))
            var item= Db.Set<NullableTypeInfo>().First(p=>p.String.CompareTo("OK")==1);
            Assert.IsNotNull(item);
            Console.WriteLine(item.String);
            Db.Set<NullableTypeInfo>().Delete(p => true);
        }
        [TestMethod]
        public virtual void Equals()
        {
            Db.Set<NullableTypeInfo>().Delete(p => true);
            Db.Set<NullableTypeInfo>().Insert(new NullableTypeInfo { String = "OK!", Int32 = 10395 });
            var item = Db.Set<NullableTypeInfo>().First(p=>object.Equals(p.String,"OK!")&&object.Equals(p.Int32,10395));
            Assert.IsNotNull(item);
            Assert.IsTrue(object.Equals(item.Int32,10395));
            Assert.IsTrue(object.Equals(item.String, "OK!"));
            Db.Set<NullableTypeInfo>().Delete(p => true);
        }
        [TestMethod]
        public virtual void ToSString()
        {
            Db.Set<NullableTypeInfo>().Delete(p => true);
            Db.Set<NullableTypeInfo>().Insert(new NullableTypeInfo { String = "OK!", Int32 = 10395 });
            var item = Db.Set<NullableTypeInfo>().First(p=>p.Int32.ToString()=="10395");
            Assert.IsNotNull(item);
            Assert.AreEqual(item.Int32.ToString(), "10395");
            Db.Set<NullableTypeInfo>().Delete(p => true);
        }
        [TestMethod]
        public virtual void CConvert()
        {
            Db.Set<NullableTypeInfo>().Delete(p => true);
            Db.Set<NullableTypeInfo>().Insert(new NullableTypeInfo { String = "10395", Int32 = 10395 });
            var item = Db.Set<NullableTypeInfo>().First(p=>Convert.ToInt32(p.String)==10395);
            Assert.IsNotNull(item);
            Assert.AreEqual(Convert.ToInt32("10395"),item.Int32);
            Db.Set<NullableTypeInfo>().Delete(p => true);
        }
        [TestMethod]
        public virtual void PParse()
        {
            Db.Set<NullableTypeInfo>().Delete(p => true);
            Db.Set<NullableTypeInfo>().Insert(new NullableTypeInfo { String = "10395", Int32 = 10395 });
            var item = Db.Set<NullableTypeInfo>().First(p=>int.Parse(p.String)==10395);
            Assert.IsNotNull(item);
            Assert.AreEqual(int.Parse("10395"), item.Int32);
            Db.Set<NullableTypeInfo>().Delete(p => true);
        }
        [TestMethod]
        //WHERE ((CAST(CAST(t0.[String] AS INT) AS INT)=10395))
        public virtual void Converter()
        {
            var converter = TypeDescriptor.GetConverter(typeof(string));
            Db.Set<NullableTypeInfo>().Delete(p => true);
            Db.Set<NullableTypeInfo>().Insert(new NullableTypeInfo { String = "10395", Int32 = 10395 });
            var item = Db.Set<NullableTypeInfo>().First(p => (Int32)converter.ConvertTo(p.String,typeof(Int32)) == 10395);
            Assert.IsNotNull(item);
            Assert.AreEqual(int.Parse("10395"), item.Int32);
            Db.Set<NullableTypeInfo>().Delete(p => true);
        }
        [TestMethod]
        //WHERE ((CAST(CAST(t0.[String] AS INT) AS INT)=10395))
        public virtual void ChangeType()
        {
            Db.Set<NullableTypeInfo>().Delete(p => true);
            Db.Set<NullableTypeInfo>().Insert(new NullableTypeInfo { String = "10395", Int32 = 10395 });
            var item = Db.Set<NullableTypeInfo>().First(p =>(Int32)Convert.ChangeType(p.String,typeof(Int32))==10395);
            Assert.IsNotNull(item);
            Assert.AreEqual(int.Parse("10395"), item.Int32);
            Db.Set<NullableTypeInfo>().Delete(p => true);
        }
    }
}


