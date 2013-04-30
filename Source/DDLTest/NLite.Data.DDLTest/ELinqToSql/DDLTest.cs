using System;
using System.Linq;
using ELinq.DDLTest.ElinqToSql.Models;
using NLite.Data;
using NLite.Reflection;
using NUnit.Framework;

namespace ELinq.DDLTest.ElinqToSql
{
    [TestFixture]
    public class DDLTest
    {
        public DbConfiguration dbConfiguration;
        public DDLTest()
        {
            const string connectionStringName = "ELinq";
            //DbConfiguration.InitializeDLinq<System.Data.Linq.Binary>();

            if (!DbConfiguration.Items.TryGetValue(connectionStringName, out dbConfiguration))
            {
                dbConfiguration = DbConfiguration.Configure(connectionStringName)
                        .SetSqlLogger(() => new SqlLog(Console.Out))
                        .AddFromAssemblyOf<ELinq.DDLTest.ElinqToSql.Models.Customers>(t => t.HasAttribute<TableAttribute>(false));
            }

        }


        [Test]
        public void AutoCreateDatabase()
        {
            using (var db = dbConfiguration.CreateDbContext())
            {
                var items = db.Set<Customers>().ToArray();
            }

            using (var db = dbConfiguration.CreateDbContext())
            {
                var items = db.Set<Customers>().ToArray();
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
