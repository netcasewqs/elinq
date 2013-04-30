using NUnit.Framework;

namespace NLite.Data.Test.Cnblogs
{
    [TestFixture]
    public class IndexTest
    {
        [Table(Name = "tbIndex")]
        class Index
        {
            public int Id;
        }

        [Test]
        public void TestEntityModelMapping()
        {
            var dbConfiguration = DbConfiguration.Configure("Northwind").AddClass<Index>();

            var mapping = dbConfiguration.GetClass<Index>();

            Assert.AreEqual("tbIndex", mapping.TableName);
        }
    }
}
