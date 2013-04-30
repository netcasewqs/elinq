using System;
using NLite.Data;
using NLite.Reflection;
using NUnit.Framework;

namespace ELinq.DDLTest.ElinqToSql
{
    [TestFixture]
    public class MySqlDDLTest
    {
        public DbConfiguration dbConfiguration;
        public MySqlDDLTest()
        {
            const string connectionStringName = "MySqlELinq";
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
