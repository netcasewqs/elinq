using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace ELinq.DDLTest.Models
{
    [TableAttribute(Name = "dbo2.[Order Details]")]
    public class Order_Details
    {
        [Column(DbType = "Int NOT NULL", IsPrimaryKey = true)]
        public int OrderID { get; set; }

        [Column(DbType = "Int NOT NULL", IsPrimaryKey = true)]
        public int ProductID { get; set; }

        [Column(DbType = "Money NOT NULL")]
        public decimal UnitPrice { get; set; }

        [Column(DbType = "SmallInt NOT NULL")]
        public short Quantity { get; set; }

        [Column(DbType = "Real NOT NULL")]
        public float Discount { get; set; }

        [Association(Name = "Orders_Order_Details", ThisKey = "OrderID", OtherKey = "OrderID", IsForeignKey = true)]
        public EntityRef<Orders> Orders { get; set; }

        [Association(Name = "Products_Order_Details", ThisKey = "ProductID", OtherKey = "ProductID", IsForeignKey = true)]
        public EntityRef<Products> Products
        {
            get;
            set;
        }
    }
}
