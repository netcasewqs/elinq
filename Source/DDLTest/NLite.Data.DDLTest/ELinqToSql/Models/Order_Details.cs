using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLite.Data;

namespace ELinq.DDLTest.ElinqToSql.Models
{
    [TableAttribute(Name = "dbo2.[Order Details]")]
    public class Order_Details
    {
        [Id]
        public int OrderID { get; set; }

        [Id]
        public int ProductID { get; set; }

        [Column(IsNullable=false)]
        public decimal UnitPrice { get; set; }

        [Column(IsNullable = false)]
        public short Quantity { get; set; }

        [Column(IsNullable = false)]
        public float Discount { get; set; }

        [ManyToOne(ThisKey = "OrderID", OtherKey = "OrderID")]
        public Orders Orders { get; set; }

        [ManyToOne(ThisKey = "ProductID", OtherKey = "ProductID")]
        public Products Products
        {
            get;
            set;
        }
    }
}
