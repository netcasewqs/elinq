using System;
using System.Data.Common;
using NUnit.Framework;
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestCleanup = NUnit.Framework.TearDownAttribute;
using TestInitialize = NUnit.Framework.SetUpAttribute;

namespace NLite.Data.Test
{
    [TestClass]
    public class TestBase
    {

        protected static void AssertEqual(string expected, string actual)
        {
            Assert.AreEqual(expected, actual);
        }

        protected static void AssertTrue(bool truth, string message)
        {
            Assert.IsTrue(truth, message);
        }

        protected static void AssertValue(object expected, object actual)
        {
            Assert.AreEqual(expected, actual);
        }

        protected static void AssertValue(double expected, double actual, double epsilon)
        {
            Assert.IsTrue(actual >= expected - epsilon && actual <= expected + epsilon);
        }

        protected static void AssertNotValue(object notExpected, object actual)
        {
            Assert.AreNotEqual(notExpected, actual);
        }

        protected static void AssertTrue(bool value)
        {
            Assert.IsTrue(value);
        }

        protected static void AssertFalse(bool value)
        {
            Assert.IsFalse(value);
        }
    }
    [TestClass]
    public class TestBase<T> : TestBase where T : class,new()
    {
        protected IDbContext Db;
        protected IDbSet<T> Table;

        protected virtual string ConnectionStringName
        {
            get { return "g_jia"; }
        }

        [TestInitialize]
        public virtual void Init()
        {
            CreateDbContext();
            Table = Db.Set<T>();
            OnInit();
        }

        protected virtual void CreateDbContext()
        {
            if (DbConfiguration.Items.ContainsKey(ConnectionStringName))
                Db = DbConfiguration.Items[ConnectionStringName].CreateDbContext();
            else
                Db = DbConfiguration.Configure(ConnectionStringName).SetSqlLogger(() => new SqlLog(Console.Out)).AddClass<T>().CreateDbContext();
        }

        protected void CreateFirebirdContext()
        {
            var item = System.Configuration.ConfigurationManager.ConnectionStrings[ConnectionStringName];
            if (item == null)
                throw new ArgumentException("Invalid connection configure for :" + ConnectionStringName);


            if (string.IsNullOrEmpty(item.ProviderName))
                throw new ArgumentNullException("connectionString.ProviderName");
            var ConnectionString = item.ConnectionString;
            if (string.IsNullOrEmpty(ConnectionString))
                throw new ArgumentNullException("ConnectionString");

            var providerName = item.ProviderName;
            if (providerName.IsNullOrEmpty())
                throw new ArgumentException(item.ProviderName + " Provider name not exists or invalid for" + ConnectionStringName);

            var factory = DbProviderFactories.GetFactory(providerName);
            var conn = factory.CreateConnection();
            conn.ConnectionString = item.ConnectionString;

            var sb = factory.CreateConnectionStringBuilder();
            sb.ConnectionString = conn.ConnectionString;
            var dbFile = AppDomain.CurrentDomain.BaseDirectory + "\\" + sb["Initial Catalog"] as string;
            sb.Add("Initial Catalog", dbFile);

            conn.ConnectionString = sb.ConnectionString;

            //Db = new DbContext(conn);
        }

        protected virtual void OnInit()
        { }

        [TestCleanup]
        public virtual void Clearup()
        {
            Db.Dispose();
        }
    }
}
