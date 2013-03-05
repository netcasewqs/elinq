using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NLite.Data.Test.Model.Northwind;
using System.Data.Common;
using System.Data;

namespace NLite.Data.Test.Core
{
    [TestFixture]
    public class ConfiguarationTest
    {
        //1. 配置连接字符串
        [Test]
        public void ConnectionConfigureTest()
        {
            var connectionStringName = "Northwind";
            var cfg = DbConfiguration
                .Configure(connectionStringName)//ConnectionStringName by config file
                ;

            Assert.AreEqual(connectionStringName, cfg.Name);
            Assert.IsNotNull(cfg.ConnectionString);//数据库连接字符串
            Assert.IsNotNull(cfg.DbProviderName);//
            Assert.IsNotNull(cfg.DbProviderFactory);//DbProviderFactory
            Assert.IsNotNull(cfg.Dialect);//数据库方言

            var db = cfg.CreateDbContext();
            Assert.IsNotNull(db);
            Assert.IsNotNull(db.Connection);
            Assert.IsFalse(db.Connection.State == System.Data.ConnectionState.Open);
        }

        [Test]
        public void Configure2()
        {
            var setting = System.Configuration.ConfigurationManager.ConnectionStrings["Northwind"];
            var cfg = DbConfiguration.Configure(setting.ConnectionString, setting.ProviderName);

            //Assert.AreEqual(setting.ConnectionString, cfg.Name);
            Assert.IsNotNull(cfg.ConnectionString);//数据库连接字符串
            Assert.IsNotNull(cfg.DbProviderName);//
            Assert.IsNotNull(cfg.DbProviderFactory);//DbProviderFactory
            Assert.IsNotNull(cfg.Dialect);//数据库方言

            var db = cfg.CreateDbContext();
            Assert.IsNotNull(db);
            Assert.IsNotNull(db.Connection);
            Assert.IsFalse(db.Connection.State == System.Data.ConnectionState.Open);

        }


        [Test]
        public void Configure3()
        {
            var setting = System.Configuration.ConfigurationManager.ConnectionStrings["Northwind"];
            var factory = DbProviderFactories.GetFactory(setting.ProviderName);
            var conn = factory.CreateConnection();
            conn.ConnectionString = setting.ConnectionString;
            var cfg = DbConfiguration.Configure(conn);

            Assert.AreEqual(setting.ConnectionString, cfg.ConnectionString);
            Assert.IsNotNull(cfg.ConnectionString);//数据库连接字符串
            Assert.IsNotNull(cfg.DbProviderName);//
            Assert.IsNotNull(cfg.DbProviderFactory);//DbProviderFactory
            Assert.IsNotNull(cfg.Dialect);//数据库方言

            var db = cfg.CreateDbContext();
            Assert.IsNotNull(db);
            Assert.IsNotNull(db.Connection);
            Assert.IsFalse(db.Connection.State == System.Data.ConnectionState.Open);
            //Assert.AreEqual(db.Connection, conn);

            conn.Open();

            db.Dispose();
            db = null;


            Assert.IsTrue(conn.State == System.Data.ConnectionState.Open);

            conn.Close();

        }

        //2. 注册OR映射并获取DbSet
        [Test]
        public void MappingTest()
        {
            var db = DbConfiguration
                           .Configure("Northwind")
                           .AddClass<Customer>()
                           .CreateDbContext();
           
            var customers = db.Set<Customer>();
            Assert.IsNotNull(customers);
        }

        //2.1 不注册OR映射并获取DbSet，那么将抛出异常
        [Test]
        [ExpectedException(typeof(MappingException))]
        public void NoMappingTest()
        {
            DbConfiguration.Items.Clear();

            var db = DbConfiguration
                          .Configure("Northwind")
                          //不映射.AddClass<Customer>();
                          .CreateDbContext();
            
            var customers = db.Set<Customer>();//报异常：ORMappingException
           
        }

        //3. 设置日志，方便开发测试
        [Test]
        public void SetSQLLog()
        {
            var db = DbConfiguration
                           .Configure("Northwind")
                           .AddClass<Customer>()
                           .SetSqlLogger(() => new SqlLog(Console.Out))
                           .CreateDbContext();

            var customers = db.Set<Customer>();
            var c = customers.FirstOrDefault();
            c.Dump();
        }
    }
}
