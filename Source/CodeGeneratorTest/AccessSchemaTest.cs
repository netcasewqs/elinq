using System;
using NLite.Data;
using NUnit.Framework;

namespace CodeGeneratorTest
{

    [TestFixture]
    class AccessSchemaTest
    {
        public DbConfiguration dbConfiguration;
        public AccessSchemaTest()
        {
            const string connectionStringName = "AccessELinq";
            //DbConfiguration.InitializeDLinq<System.Data.Linq.Binary>();

            if (!DbConfiguration.Items.TryGetValue(connectionStringName, out dbConfiguration))
            {
                dbConfiguration = DbConfiguration.Configure(connectionStringName)
                        .SetSqlLogger(() => new SqlLog(Console.Out))
                        ;
            }

            //DataTable tb = null;
            //using (var conn = dbConfiguration.Factory.CreateConnection())
            //{
            //    conn.ConnectionString = dbConfiguration.ConnectionString;
            //    conn.Open();
            //    tb = conn.GetSchema("DATATYPES", null);
            //}


            //tb.WriteXml(Console.Out);

            //var items = tb.Rows.Cast<DataRow>().Select(p => p["TypeName"].ToString()).ToArray();
            //foreach (DataRow item in tb.Rows)
            //    Console.WriteLine(string.Format("TypeName:{0},ProviderDbType:{1},DataType:{2}"
            //        , item["TypeName"]
            //        , item["ProviderDbType"]
            //        , item["DataType"]));


        }

        [Test]
        public void Test()
        {
            var schema = dbConfiguration.Schema;
            Assert.IsNotNull(schema);
        }
    }
}
