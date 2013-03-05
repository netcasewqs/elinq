using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NLite.Data;
using System.Data;

namespace CodeGeneratorTest
{
    [TestFixture]
    class MySqlSchemaTest
    {
        public DbConfiguration dbConfiguration;
        public MySqlSchemaTest()
        {
            const string connectionStringName = "MySqlELinq";
            //DbConfiguration.InitializeDLinq<System.Data.Linq.Binary>();

            if (!DbConfiguration.Items.TryGetValue(connectionStringName, out dbConfiguration))
            {
                dbConfiguration = DbConfiguration.Configure(connectionStringName)
                        .SetSqlLogger(() => new SqlLog(Console.Out))
                        ;
            }

            DataTable tb = null;
            using ( var conn = dbConfiguration.DbProviderFactory.CreateConnection())
            {
                conn.ConnectionString = dbConfiguration.ConnectionString;
                conn.Open();
                tb = conn.GetSchema("DATATYPES", null);
            }

            
            tb.WriteXml(Console.Out);

            var items = tb.Rows.Cast<DataRow>().Select(p => p["TypeName"].ToString()).ToArray();
            foreach (DataRow item in tb.Rows)
                Console.WriteLine(string.Format("TypeName:{0},ProviderDbType:{1},DataType:{2}"
                    ,item["TypeName"]
                    ,item["ProviderDbType"]
                    ,item["DataType"]));

            
        }

        [Test]
        public void Test()
        {
            var schema = dbConfiguration.Schema;
            Assert.IsNotNull(schema);
        }

        string aa = @"TypeName:BLOB,ProviderDbType:252,DataType:System.Byte[]
TypeName:TINYBLOB,ProviderDbType:249,DataType:System.Byte[]
TypeName:MEDIUMBLOB,ProviderDbType:250,DataType:System.Byte[]
TypeName:LONGBLOB,ProviderDbType:251,DataType:System.Byte[]
TypeName:BINARY,ProviderDbType:600,DataType:System.Byte[]
TypeName:VARBINARY,ProviderDbType:601,DataType:System.Byte[]
TypeName:DATE,ProviderDbType:10,DataType:System.DateTime
TypeName:DATETIME,ProviderDbType:12,DataType:System.DateTime
TypeName:TIMESTAMP,ProviderDbType:7,DataType:System.DateTime
TypeName:TIME,ProviderDbType:11,DataType:System.TimeSpan
TypeName:CHAR,ProviderDbType:254,DataType:System.String
TypeName:NCHAR,ProviderDbType:254,DataType:System.String
TypeName:VARCHAR,ProviderDbType:253,DataType:System.String
TypeName:NVARCHAR,ProviderDbType:253,DataType:System.String
TypeName:SET,ProviderDbType:248,DataType:System.String
TypeName:ENUM,ProviderDbType:247,DataType:System.String
TypeName:TINYTEXT,ProviderDbType:749,DataType:System.String
TypeName:TEXT,ProviderDbType:752,DataType:System.String
TypeName:MEDIUMTEXT,ProviderDbType:750,DataType:System.String
TypeName:LONGTEXT,ProviderDbType:751,DataType:System.String
TypeName:DOUBLE,ProviderDbType:5,DataType:System.Double
TypeName:FLOAT,ProviderDbType:4,DataType:System.Single
TypeName:TINYINT,ProviderDbType:1,DataType:System.SByte
TypeName:SMALLINT,ProviderDbType:2,DataType:System.Int16
TypeName:INT,ProviderDbType:3,DataType:System.Int32
TypeName:YEAR,ProviderDbType:13,DataType:System.Int32
TypeName:MEDIUMINT,ProviderDbType:9,DataType:System.Int32
TypeName:BIGINT,ProviderDbType:8,DataType:System.Int64
TypeName:DECIMAL,ProviderDbType:246,DataType:System.Decimal
TypeName:TINY INT,ProviderDbType:501,DataType:System.Byte
TypeName:SMALLINT,ProviderDbType:502,DataType:System.UInt16
TypeName:MEDIUMINT,ProviderDbType:509,DataType:System.UInt32
TypeName:INT,ProviderDbType:503,DataType:System.UInt32
TypeName:BIGINT,ProviderDbType:508,DataType:System.UInt64";
    }
}
