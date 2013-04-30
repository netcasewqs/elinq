using System.Linq;
using NLite.Data.CodeGeneration;
using NUnit.Framework;

namespace NLite.Data.Test
{
    [TestFixture]
    public class NamingConversionTest
    {
        [Test]
        public void ManyToOne()
        {
            var cfg = DbConfiguration.ConfigureSqlServer("Data Source=.;Initial Catalog=northwind;Persist Security Info=True;User ID=sa;Password=");
            var schema = cfg.Schema;

            var order = schema.Tables.FirstOrDefault(p => p.TableName == "Orders");
            var customer = order.ForeignKeys.FirstOrDefault(p => p.OtherTable.TableName == "Customers");

            var s = NamingConversion.Default.ManyToOneName(customer);
            Assert.AreEqual("Customer", s);

            var shipper = order.ForeignKeys.FirstOrDefault(p => p.OtherTable.TableName == "Shippers");
            s = NamingConversion.Default.ManyToOneName(shipper);
            Assert.AreEqual("ShipVia1", s);
        }
    }
}
