using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLite.Data;
using NLite.Data.Schema;
using NLite.Data.Schema.Loader;
using NUnit.Framework;

namespace CodeGeneratorTest
{
    [TestFixture]
    public class SqlServerSchema
    {
        public DbConfiguration dbConfiguration;
        public SqlServerSchema()
        {
            const string connectionStringName = "ELinq";
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
