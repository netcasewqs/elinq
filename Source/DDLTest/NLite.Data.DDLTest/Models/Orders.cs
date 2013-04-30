using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace ELinq.DDLTest.Models
{
    [Table(Name = "dbo2.Orders")]
    public class Orders
    {
        [Column(AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int OrderID { get; set; }

        [Column(DbType = "NChar(5)")]
        public string CustomerID { get; set; }

        [Column(DbType = "Int")]
        public System.Nullable<int> EmployeeID { get; set; }

        [Column(DbType = "DateTime")]
        public System.Nullable<System.DateTime> OrderDate { get; set; }

        [Column(DbType = "DateTime")]
        public System.Nullable<System.DateTime> RequiredDate { get; set; }

        [Column(DbType = "DateTime")]
        public System.Nullable<System.DateTime> ShippedDate { get; set; }

        [Column(DbType = "Int")]
        public System.Nullable<int> ShipVia { get; set; }

        [Column(DbType = "Money")]
        public System.Nullable<decimal> Freight { get; set; }

        [Column(DbType = "NVarChar(40)")]
        public string ShipName { get; set; }

        [Column(DbType = "NVarChar(60)")]
        public string ShipAddress { get; set; }

        [Column(DbType = "NVarChar(15)")]
        public string ShipCity { get; set; }

        [Column(DbType = "NVarChar(15)")]
        public string ShipRegion { get; set; }

        [Column(DbType = "NVarChar(10)")]
        public string ShipPostalCode { get; set; }

        [Column(DbType = "NVarChar(15)")]
        public string ShipCountry { get; set; }

        [Association(Name = "Orders_Order_Details", ThisKey = "OrderID", OtherKey = "OrderID")]
        public EntitySet<Order_Details> Order_Details { get; set; }

        [Association(Name = "Customers_Orders", ThisKey = "CustomerID", OtherKey = "CustomerID", IsForeignKey = true)]
        public EntityRef<Customers> Customers { get; set; }

        [Association(Name = "Employees_Orders", ThisKey = "EmployeeID", OtherKey = "EmployeeID", IsForeignKey = true)]
        public EntityRef<Employees> Employees
        {
            get;
            set;
        }

        [Association(Name = "Shippers_Orders", ThisKey = "ShipVia", OtherKey = "ShipperID", IsForeignKey = true)]
        public EntityRef<Shippers> Shippers { get; set; }
    }
}
