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
    [TestFixture]
    public class SQLiteDDLTest
    {
        public DbConfiguration dbConfiguration;
        public SQLiteDDLTest()
        {
            const string connectionStringName = "ELinq";
            //DbConfiguration.InitializeDLinq<System.Data.Linq.Binary>();

            if (!DbConfiguration.Items.TryGetValue(connectionStringName, out dbConfiguration))
            {
                dbConfiguration = DbConfiguration.ConfigureSQLite(@"Northwind.sl")
                        .SetSqlLogger(() => new SqlLog(Console.Out))
                        .AddFromAssemblyOf<ELinq.DDLTest.ElinqToSql.Models.EmployeeTerritories>(t => t.HasAttribute<TableAttribute>(false));
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
