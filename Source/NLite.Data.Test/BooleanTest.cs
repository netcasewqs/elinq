using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLite.Data.Test.Primitive.Model;
using NUnit.Framework;

namespace NLite.Data.Test
{
    public class NullableBooleanTest : TestBase<NullableTypeInfo>
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

        [Test]
        public void True()
        {
            var table = Db.Set<NullableTypeInfo>();

            table.Insert(new NullableTypeInfo { Boolean = true,String = "abc" });

            var c = table.Count(p => p.Boolean.Value);
            Assert.AreEqual(1, c);

            c = table.Count(p => p.Boolean.Value == true);
            Assert.AreEqual(1, c);

            table.Delete(p => true);
        }

        [Test]
        public void False()
        {
            var table = Db.Set<NullableTypeInfo>();

            table.Insert(new NullableTypeInfo { Boolean = false, String = "abc" });

            var c = table.Count(p => !p.Boolean.Value);
            Assert.AreEqual(1, c);

            c = table.Count(p => p.Boolean.Value == false);
            Assert.AreEqual(1, c);

            table.Delete(p => true);
        }
    }

    public class BooleanTest : TestBase<TypeInfo>
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
                return "BooleanDB";
            }
        }

        [Test]
        public void True()
        {
            var table = Db.Set<TypeInfo>();

            table.Insert(new TypeInfo { Boolean = true });

            var c = table.Count(p => p.Boolean);
            Assert.AreEqual(1, c);

            c = table.Count(p => p.Boolean == true);
            Assert.AreEqual(1, c);

            table.Delete(p => true);
        }

        [Test]
        public void False()
        {
            var table = Db.Set<TypeInfo>();

            table.Insert(new TypeInfo { Boolean = false });

            var c = table.Count(p => !p.Boolean);
            Assert.AreEqual(1, c);

            c = table.Count(p => p.Boolean == false);
            Assert.AreEqual(1, c);

            c = table.Count(p => p.Boolean != true);
            Assert.AreEqual(1, c);

            table.Delete(p => true);
        }
    }
}
