using System;
using System.Data;
using System.Linq;
using NLite.Data;
using NUnit.Framework;

namespace CodeGeneratorTest
{
    [TestFixture]
    class OracleSchemaTest
    {
        public DbConfiguration dbConfiguration;
        public OracleSchemaTest()
        {
            const string connectionStringName = "OracleELinq";
            //DbConfiguration.InitializeDLinq<System.Data.Linq.Binary>();

            if (!DbConfiguration.Items.TryGetValue(connectionStringName, out dbConfiguration))
            {
                dbConfiguration = DbConfiguration.Configure(connectionStringName)
                        .SetSqlLogger(() => new SqlLog(Console.Out))
                        ;
            }

            DataTable tb = null;
            using (var conn = dbConfiguration.DbProviderFactory.CreateConnection())
            {
                conn.ConnectionString = dbConfiguration.ConnectionString;
                conn.Open();
                tb = conn.GetSchema("DATATYPES", null);
            }


            tb.WriteXml(Console.Out);

            var items = tb.Rows.Cast<DataRow>().Select(p => p["TypeName"].ToString()).ToArray();
            foreach (DataRow item in tb.Rows)
                Console.WriteLine(string.Format("TypeName:{0},ProviderDbType:{1},DataType:{2}"
                    , item["TypeName"]
                    , item["ProviderDbType"]
                    , item["DataType"]));


        }

        [Test]
        public void Test()
        {
            var schema = dbConfiguration.Schema;
            Assert.IsNotNull(schema);
        }

        string aa = @"TypeName:BLOB,ProviderDbType:2,DataType:System.Byte[]
TypeName:CHAR,ProviderDbType:3,DataType:System.String
TypeName:CLOB,ProviderDbType:4,DataType:System.String
TypeName:DATE,ProviderDbType:6,DataType:System.DateTime
TypeName:FLOAT,ProviderDbType:29,DataType:System.Decimal
TypeName:INTERVAL DAY TO SECOND,ProviderDbType:7,DataType:System.TimeSpan
TypeName:INTERVAL YEAR TO MONTH,ProviderDbType:8,DataType:System.Int32
TypeName:LONG,ProviderDbType:10,DataType:System.String
TypeName:LONG RAW,ProviderDbType:9,DataType:System.Byte[]
TypeName:NCHAR,ProviderDbType:11,DataType:System.String
TypeName:NCLOB,ProviderDbType:12,DataType:System.String
TypeName:NUMBER,ProviderDbType:13,DataType:System.Decimal
TypeName:NVARCHAR2,ProviderDbType:14,DataType:System.String
TypeName:RAW,ProviderDbType:15,DataType:System.Byte[]
TypeName:ROWID,ProviderDbType:16,DataType:System.String
TypeName:TIMESTAMP,ProviderDbType:18,DataType:System.DateTime
TypeName:TIMESTAMP WITH LOCAL TIME ZONE,ProviderDbType:19,DataType:System.DateTime
TypeName:TIMESTAMP WITH TIME ZONE,ProviderDbType:20,DataType:System.DateTime
TypeName:VARCHAR2,ProviderDbType:22,DataType:System.String";
    }
}
