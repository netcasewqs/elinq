using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace ELinq.DDLTest.Models
{

    [Table(Name = "dbo2.Products")]
    public class Products
    {
        [Column(AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int ProductID { get; set; }

        [Column(DbType = "NVarChar(40) NOT NULL", CanBeNull = false)]
        public string ProductName { get; set; }

        [Column(DbType = "Int")]
        public System.Nullable<int> SupplierID { get; set; }

        [Column(DbType = "Int")]
        public System.Nullable<int> CategoryID { get; set; }

        [Column(DbType = "NVarChar(20)")]
        public string QuantityPerUnit { get; set; }

        [Column(DbType = "Money")]
        public System.Nullable<decimal> UnitPrice { get; set; }

        [Column(DbType = "SmallInt")]
        public System.Nullable<short> UnitsInStock { get; set; }

        [Column(DbType = "SmallInt")]
        public System.Nullable<short> UnitsOnOrder { get; set; }

        [Column(DbType = "SmallInt")]
        public System.Nullable<short> ReorderLevel { get; set; }

        [Column(DbType = "Bit NOT NULL")]
        public bool Discontinued { get; set; }

        [Association(Name = "Products_Order_Details", ThisKey = "ProductID", OtherKey = "ProductID")]
        public EntitySet<Order_Details> Order_Details { get; set; }

        [Association(Name = "Suppliers_Products", Storage = "_Suppliers", ThisKey = "SupplierID", OtherKey = "SupplierID", IsForeignKey = true)]
        public EntityRef<Suppliers> Suppliers { get; set; }

        [Association(Name = "Products_Categories", ThisKey = "CategoryID", OtherKey = "CategoryID")]
        public EntityRef<Categories> Categories { get; set; }
    }
}
