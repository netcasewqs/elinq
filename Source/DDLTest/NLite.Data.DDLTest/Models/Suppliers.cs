using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace ELinq.DDLTest.Models
{
    [Table(Name = "dbo2.Suppliers")]
    public class Suppliers
    {
        [Column(AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int SupplierID { get; set; }

        [Column(DbType = "NVarChar(40) NOT NULL", CanBeNull = false)]
        public string CompanyName { get; set; }

        [Column(DbType = "NVarChar(30)")]
        public string ContactName { get; set; }

        [Column(DbType = "NVarChar(30)")]
        public string ContactTitle { get; set; }

        [Column(DbType = "NVarChar(60)")]
        public string Address { get; set; }

        [Column(DbType = "NVarChar(15)")]
        public string City { get; set; }

        [Column(DbType = "NVarChar(15)")]
        public string Region { get; set; }

        [Column(DbType = "NVarChar(10)")]
        public string PostalCode { get; set; }

        [Column(DbType = "NVarChar(15)")]
        public string Country { get; set; }

        [Column(DbType = "NVarChar(24)")]
        public string Phone { get; set; }

        [Column(DbType = "NVarChar(24)")]
        public string Fax { get; set; }

        [Column(DbType = "NText", UpdateCheck = UpdateCheck.Never)]
        public string HomePage { get; set; }

        [Association(Name = "Suppliers_Products", ThisKey = "SupplierID", OtherKey = "SupplierID")]
        public EntitySet<Products> Products { get; set; }
    }
}
