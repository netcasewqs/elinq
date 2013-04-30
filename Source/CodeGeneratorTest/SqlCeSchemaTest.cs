using System;
using NLite.Data;
using NUnit.Framework;

namespace CodeGeneratorTest
{
    [TestFixture]
    public class SqlCeSchemaTest
    {
        public DbConfiguration dbConfiguration;
        public SqlCeSchemaTest()
        {
            const string connectionStringName = "SqlCELinq";
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
