using System;
using NLite.Data;
using NUnit.Framework;

namespace CodeGeneratorTest
{
    [TestFixture]
    public class SqlServerSchema
    {
        public DbConfiguration dbConfiguration;
        public SqlServerSchema()
        {
            const string connectionStringName = "Northwind";
            //DbConfiguration.InitializeDLinq<System.Data.Linq.Binary>();

            if (!DbConfiguration.Items.TryGetValue(connectionStringName, out dbConfiguration))
            {
                dbConfiguration = DbConfiguration.Configure(connectionStringName)
                        .SetSqlLogger(() => new SqlLog(Console.Out))
                        ;
            }


        }

        [Test]
        public void Test()
        {
            var schema = dbConfiguration.Schema;
            Assert.IsNotNull(schema);
        }

    }
}
