using System;
using System.Linq;
using NLite.Data.Test.Primitive.Model;
using NUnit.Framework;
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestMethod = NUnit.Framework.TestAttribute;

namespace NLite.Data.Test.Where
{
    [TestClass]

    public class GuidTest : TestBase<NullableTypeInfo>
    {
        /// <summary>
        /// GUID,，对应数据库中类型：SQLSERVER：uniqueidentifier.我们使用：[uniqueidentifier]
        ///                          SQLServerCE:uniqueidentifier.[uniqueidentifier]
        ///                          Access:数字-同步复制ID。[文本]
        ///                          SQLite:。[varchar(100)]
        ///                          MySQL:无。[varchar(100)]
        /// </summary>
        protected override string ConnectionStringName
        {
            get
            {
                return "NumericDB";
            }
        }
        Guid? guid = new Guid("4A83D44A-5612-4E78-89EE-08F894912C0A");
        internal virtual void GuidTestMethod()
        {
            Db.Set<NullableTypeInfo>().Delete(p => p.Int32 == 123);
            Db.Set<NullableTypeInfo>().Insert(new NullableTypeInfo { Guid = guid, Int32 = 123 });
        }
        internal virtual void GuidDelete()
        {
            Db.Set<NullableTypeInfo>().Delete(p => p.Int32 == 123);
        }
        [TestMethod]
        public virtual void Equal()
        {
            GuidTestMethod();
            var item = Table.First(p => p.Guid == guid && p.Int32 == 123);//t0.Guid = @p0
            Assert.IsNotNull(item);
            GuidDelete();
        }
        [TestMethod]
        public virtual void A_Equals_B()
        {
            GuidTestMethod();
            var item = Db.Set<NullableTypeInfo>().First(p => p.Guid.Equals(guid) && p.Int32 == 123);//(t0.Guid=@p0)
            Assert.IsNotNull(item);
            GuidDelete();
        }
        [TestMethod]
        public virtual void B_Equals_A()
        {
            GuidTestMethod();
            var item = Db.Set<NullableTypeInfo>().First(p => guid.Equals(p.Guid) && p.Int32 == 123);//(t0.Guid=@p0)
            Assert.IsNotNull(item);
            GuidDelete();
        }
        [TestMethod]
        public virtual void Object_Equals()
        {
            GuidTestMethod();
            var item = Db.Set<NullableTypeInfo>().First(p => object.Equals(p.Guid, guid) && p.Int32 == 123);//(t0.Guid=@p0)
            Assert.IsNotNull(item);
            GuidDelete();
        }
        [TestMethod]
        public virtual void Guid_Equals()
        {
            GuidTestMethod();
            var item = Db.Set<NullableTypeInfo>().First(p => Guid.Equals(p.Guid, guid) && p.Int32 == 123);//(t0.Guid=@p0)
            Assert.IsNotNull(item);
            GuidDelete();
        }


        [TestMethod]
        public virtual void IsNotNull()
        {
            GuidTestMethod();
            //SqlServer，SqlCE，Access，SQlite,MySQL:(NOT (t0.Guid IS NULL)).OK,正确！
            var item = Db.Set<NullableTypeInfo>().First(p => p.Guid.HasValue && p.Int32 == 123);
            Assert.IsNotNull(item);
            GuidDelete();
        }
        [TestMethod]
        public virtual void IsNull()
        {
            GuidTestMethod();
            //SQLServer，SqlCE，Access，Sqlite,MySQL:NOT ((NOT (t0.Guid IS NULL)).OK,正确！
            var item = Db.Set<NullableTypeInfo>().FirstOrDefault(p => !p.Guid.HasValue && p.Int32 == 123);
            Assert.IsNull(item);
            GuidDelete();
        }
        [TestMethod]

        public virtual void Null()
        {
            Guid? a = null;
            Db.Set<NullableTypeInfo>().Delete(p => p.Int32 == 123);
            Db.Set<NullableTypeInfo>().Insert(new NullableTypeInfo { Guid = a, Int32 = 123 });
            var item = Db.Set<NullableTypeInfo>().FirstOrDefault(p => p.Guid == a && p.Int32 == 123);//(t0.Guid IS NULL)
            Assert.IsNotNull(item);
            item = Db.Set<NullableTypeInfo>().FirstOrDefault(p => p.Guid.Equals(a) && p.Int32 == 123);//(t0.Guid IS NULL)
            Assert.IsNotNull(item);

            item = Db.Set<NullableTypeInfo>().FirstOrDefault(p => a.Equals(p.Guid) && p.Int32 == 123);//(CAST(t0.Guid AS UNIQUEIDENTIFIER) IS NULL)
            Assert.IsNotNull(item);
            item = Db.Set<NullableTypeInfo>().FirstOrDefault(p => object.Equals(p.Guid, a) && p.Int32 == 123);//(CAST(t0.Guid AS UNIQUEIDENTIFIER) IS NULL)
            Assert.IsNotNull(item);
            item = Db.Set<NullableTypeInfo>().FirstOrDefault(p => Guid.Equals(p.Guid, a) && p.Int32 == 123);//(CAST(t0.Guid AS UNIQUEIDENTIFIER) IS NULL)
            Assert.IsNotNull(item);

            //SQlServer，SqlCE，Access，Sqlite,MySQL:(NOT (t0.Guid IS NULL)).OK,正确！
            item = Db.Set<NullableTypeInfo>().FirstOrDefault(p => p.Guid.HasValue && p.Int32 == 123);
            Assert.IsNull(item);
            //SqlServer，SqlCE，Access，Sqlite,MySQL:NOT ((NOT (t0.Guid IS NULL)).OK,正确！
            item = Db.Set<NullableTypeInfo>().FirstOrDefault(p => !p.Guid.HasValue && p.Int32 == 123);
            Assert.IsNotNull(item);

            GuidDelete();
        }
    }
}
