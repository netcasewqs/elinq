using System;
using NLite.Data;
using NLite.Reflection;
using NUnit.Framework;

namespace ELinq.DDLTest
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
                        .AddFromAssemblyOf<ELinq.DDLTest.Models.Customers>(p => p.HasAttribute<System.Data.Linq.Mapping.TableAttribute>(false));
            }

        }

        [Test]
        public void DatabaseExists()
        {
            //var ddlBuilder = dbConfiguration.Dialect.CreateDDLBuilder();
            //var DatabaseExists = ddlBuilder.DatabaseExists(dbConfiguration);
            Assert.IsTrue(dbConfiguration.DatabaseExists());
        }

        [Test]
        public void DatabaseNotExists()
        {
            Assert.IsFalse(dbConfiguration.DatabaseExists());
        }


        [Test]
        public void CreateDatabase()
        {
            //var ddlBuilder = dbConfiguration.Dialect.CreateDDLBuilder();
            //ddlBuilder.CreateDatabase(dbConfiguration);
            dbConfiguration.CreateDatabase();
        }


        [Test]
        public void DeleteDatabase()
        {
            //var ddlBuilder = dbConfiguration.Dialect.CreateDDLBuilder();
            //ddlBuilder.DeleteDatabase(dbConfiguration);
            //var DatabaseExists = ddlBuilder.DatabaseExists(dbConfiguration);
            //Assert.IsFalse(DatabaseExists);
            dbConfiguration.DeleteDatabase();
        }

        [Test]
        public void CreateTable()
        {
            dbConfiguration.CreateTables();
        }
    }
}
