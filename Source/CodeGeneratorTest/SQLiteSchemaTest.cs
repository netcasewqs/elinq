using System;
using System.Data;
using System.Linq;
using NLite.Data;
using NUnit.Framework;

namespace CodeGeneratorTest
{
    [TestFixture]
    public class SqlLiteSchemaTest
    {
        public DbConfiguration dbConfiguration;
        public SqlLiteSchemaTest()
        {
            const string connectionStringName = "SQLiteELinq";
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

            var cc = aa;
        }

        string aa = @"
TypeName:int,ProviderDbType:11,DataType:System.Int32
TypeName:real,ProviderDbType:15,DataType:System.Single
TypeName:float,ProviderDbType:8,DataType:System.Double
TypeName:double,ProviderDbType:8,DataType:System.Double

TypeName:money,ProviderDbType:7,DataType:System.Decimal
TypeName:currency,ProviderDbType:7,DataType:System.Decimal

TypeName:decimal,ProviderDbType:7,DataType:System.Decimal
TypeName:numeric,ProviderDbType:7,DataType:System.Decimal
TypeName:bit,ProviderDbType:3,DataType:System.Boolean
TypeName:yesno,ProviderDbType:3,DataType:System.Boolean
TypeName:logical,ProviderDbType:3,DataType:System.Boolean
TypeName:bool,ProviderDbType:3,DataType:System.Boolean
TypeName:boolean,ProviderDbType:3,DataType:System.Boolean
TypeName:tinyint,ProviderDbType:2,DataType:System.Byte

TypeName:integer,ProviderDbType:12,DataType:System.Int64
TypeName:counter,ProviderDbType:12,DataType:System.Int64
TypeName:autoincrement,ProviderDbType:12,DataType:System.Int64
TypeName:identity,ProviderDbType:12,DataType:System.Int64
TypeName:long,ProviderDbType:12,DataType:System.Int64
TypeName:bigint,ProviderDbType:12,DataType:System.Int64

TypeName:binary,ProviderDbType:1,DataType:System.Byte[]
TypeName:varbinary,ProviderDbType:1,DataType:System.Byte[]
TypeName:blob,ProviderDbType:1,DataType:System.Byte[]
TypeName:image,ProviderDbType:1,DataType:System.Byte[]
TypeName:general,ProviderDbType:1,DataType:System.Byte[]
TypeName:oleobject,ProviderDbType:1,DataType:System.Byte[]
TypeName:varchar,ProviderDbType:16,DataType:System.String
TypeName:nvarchar,ProviderDbType:16,DataType:System.String

TypeName:memo,ProviderDbType:16,DataType:System.String
TypeName:longtext,ProviderDbType:16,DataType:System.String
TypeName:note,ProviderDbType:16,DataType:System.String
TypeName:text,ProviderDbType:16,DataType:System.String
TypeName:ntext,ProviderDbType:16,DataType:System.String
TypeName:string,ProviderDbType:16,DataType:System.String
TypeName:char,ProviderDbType:16,DataType:System.String
TypeName:nchar,ProviderDbType:16,DataType:System.String

TypeName:datetime,ProviderDbType:6,DataType:System.DateTime
TypeName:smalldate,ProviderDbType:6,DataType:System.DateTime
TypeName:timestamp,ProviderDbType:6,DataType:System.DateTime
TypeName:date,ProviderDbType:6,DataType:System.DateTime
TypeName:time,ProviderDbType:6,DataType:System.DateTime
TypeName:uniqueidentifier,ProviderDbType:4,DataType:System.Guid
TypeName:guid,ProviderDbType:4,DataType:System.Guid
";
    }
}
