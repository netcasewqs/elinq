using System.Collections.Generic;
using NLite.Data;

namespace ELinq.DDLTest.ElinqToSql.Models
{

    [Table(Name = "dbo2.Products")]
    public class Products
    {
        [Id(IsDbGenerated = true, SequenceName = "S_Products")]
        public int ProductID { get; set; }

        [Column(Length = 40, IsNullable = false)]
        public string ProductName { get; set; }

        [Column]
        public System.Nullable<int> SupplierID { get; set; }

        [Column]
        public System.Nullable<int> CategoryID { get; set; }

        [Column(Length = 20)]
        public string QuantityPerUnit { get; set; }

        [Column]
        public System.Nullable<decimal> UnitPrice { get; set; }

        [Column]
        public System.Nullable<short> UnitsInStock { get; set; }

        [Column]
        public System.Nullable<short> UnitsOnOrder { get; set; }

        [Column]
        public System.Nullable<short> ReorderLevel { get; set; }
        [Column(IsNullable = false)]
        public bool Discontinued { get; set; }

        [OneToMany(ThisKey = "ProductID", OtherKey = "ProductID")]
        public List<Order_Details> Order_Details { get; set; }

        [ManyToOne(ThisKey = "SupplierID", OtherKey = "SupplierID")]
        public Suppliers Suppliers { get; set; }

        [ManyToOne(ThisKey = "CategoryID", OtherKey = "CategoryID")]
        public Categories Categories { get; set; }
    }
}
