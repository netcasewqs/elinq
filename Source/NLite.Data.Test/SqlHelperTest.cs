using System;
using NLite.Data.Test.Primitive.Model;
using NUnit.Framework;

namespace NLite.Data.Test
{
    [TestFixture]
    public class SqlHelperTest : TestBase<UserInfo>
    {
        protected override string ConnectionStringName
        {
            get
            {
                return "Northwind";
            }
        }

        [Test]
        public void ExecuteDataTable()
        {
            Db.DbHelper.ExecuteDataTable("select * from customers where customerid=@id", new { id = "ALFKI" }).WriteXml(Console.Out);
        }
    }
}
