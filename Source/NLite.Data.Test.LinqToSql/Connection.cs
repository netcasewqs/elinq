using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestInitialize = NUnit.Framework.SetUpAttribute;
using TestMethod = NUnit.Framework.TestAttribute;
using NLite.Reflection;

namespace NLite.Data.Test.LinqToSql
{
    public class DLinqConnection
    {
        public DbConfiguration dbConfiguration;
        const string connectionStringName = "Northwind";
        public DLinqConnection()
        {
            const string connectionStringName = "Northwind";
            //DbConfiguration.InitializeDLinq<System.Data.Linq.Binary>();

            if (!DbConfiguration.Items.TryGetValue(connectionStringName, out dbConfiguration))
            {
                dbConfiguration = DbConfiguration.Configure(connectionStringName)
                        .SetSqlLogger(() => new SqlLog(Console.Out))
                        .AddFromAssemblyOf<NLite.Data.Test.LinqToSql.Customers>(p => p.HasAttribute<System.Data.Linq.Mapping.TableAttribute>(false));
            }
            var customerMapper = dbConfiguration.GetClass<Customers>();
            Assert.IsNotNull(customerMapper);
            var orderMapper = dbConfiguration.GetClass<Orders>();
            Assert.IsNotNull(orderMapper);
            var employeesMapper = dbConfiguration.GetClass<Employees>();
            Assert.IsNotNull(employeesMapper);
            var employeeTerritoriesMapper = dbConfiguration.GetClass<EmployeeTerritories>();
            Assert.IsNotNull(employeeTerritoriesMapper);
            var ProductsMapper = dbConfiguration.GetClass<Products>();
            Assert.IsNotNull(ProductsMapper);
            var SuppliersMapper = dbConfiguration.GetClass<Suppliers>();
            Assert.IsNotNull(SuppliersMapper);
            var TerritoriesMapper = dbConfiguration.GetClass<Territories>();
            Assert.IsNotNull(TerritoriesMapper);
        }
    }
}
