using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLite.Data;
using System.Data;

namespace ELinq.DDLTest.ElinqToSql.Models
{
    [Table(Name = "dbo2.Orders")]
    public class Orders
    {
        [Id(IsDbGenerated = true, SequenceName = "S_Orders")]
        public int OrderID { get; set; }

        [Column(DbType = DBType.NChar, Length = 5)]
        public string CustomerID { get; set; }

        [Column]
        public System.Nullable<int> EmployeeID { get; set; }


        [Column]
        public System.Nullable<System.DateTime> OrderDate { get; set; }

        [Column]
        public System.Nullable<System.DateTime> RequiredDate { get; set; }

        [Column]
        public System.Nullable<System.DateTime> ShippedDate { get; set; }

        [Column]
        public System.Nullable<int> ShipVia { get; set; }

        [Column]
        public System.Nullable<decimal> Freight { get; set; }

        [Column(Length = 40)]
        public string ShipName { get; set; }

        [Column(Length = 60)]
        public string ShipAddress { get; set; }

        [Column(Length = 15)]
        public string ShipCity { get; set; }

        [Column(Length = 15)]
        public string ShipRegion { get; set; }

        [Column(Length = 10)]
        public string ShipPostalCode { get; set; }

        [Column(Length = 15)]
        public string ShipCountry { get; set; }

        [OneToMany(ThisKey = "OrderID", OtherKey = "OrderID")]
        public IList<Order_Details> Order_Details { get; set; }

        [ManyToOne(ThisKey = "CustomerID", OtherKey = "CustomerID")]
        public Customers Customers { get; set; }

        [ManyToOne(ThisKey = "EmployeeID", OtherKey = "EmployeeID")]
        public Employees Employees
        {
            get;
            set;
        }

        [ManyToOne(ThisKey = "ShipVia", OtherKey = "ShipperID")]
        public Shippers Shippers { get; set; }
    }
}
