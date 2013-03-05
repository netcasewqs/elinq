using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NLite.Data;
using NLite.Reflection;
using ELinq.DDLTest.ElinqToSql.Models;

namespace ELinq.DDLTest.ElinqToSql
{
    public class OracleDDLTest
    {
        public DbConfiguration dbConfiguration;
        public OracleDDLTest()
        {
            const string connectionStringName = "OracleELinq";
            //DbConfiguration.InitializeDLinq<System.Data.Linq.Binary>();

            if (!DbConfiguration.Items.TryGetValue(connectionStringName, out dbConfiguration))
            {
                dbConfiguration = DbConfiguration.Configure(connectionStringName)
                    //dbConfiguration = DbConfiguration.Configure(connectionStringName)
                        .SetSqlLogger(() => new SqlLog(Console.Out))
                        .AddFromAssemblyOf<ELinq.DDLTest.ElinqToSql.Models.EmployeeTerritories>(t => t.HasAttribute<TableAttribute>(false));
            }

        }

        [Test]
        public void DatabaseExists()
        {

            var DatabaseExists = dbConfiguration.DatabaseExists();
            Assert.IsTrue(DatabaseExists);
        }

        [Test]
        public void CreateDatabase()
        {
            dbConfiguration.CreateDatabase();
        }


        [Test]
        public void DeleteDatabase()
        {
            dbConfiguration.DeleteDatabase();
        }
    }
}
