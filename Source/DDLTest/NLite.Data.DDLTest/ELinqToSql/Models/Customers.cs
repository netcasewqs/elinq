using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLite.Data;
using System.Data;

namespace ELinq.DDLTest.ElinqToSql.Models
{
    [Table(Name = "dbo2.Customers")]
    public partial class Customers 
    {
        [Id(DbType = DBType.NChar, Length=5)]
        public string CustomerID { get; set; }

        [Column(Length=40,IsNullable=false)]
        public string CompanyName { get; set; }

        [Column(Length=30)]
        public string ContactName { get; set; }

        [Column(Length = 30)]
        public string ContactTitle { get; set; }

        [Column(Length = 60)]
        public string Address { get; set; }
     
        [Column(Length = 15)]
        public string City { get; set; }

        [Column(Length = 15)]
        public string Region { get; set; }

        [Column(Length = 10)]
        public string PostalCode { get; set; }

        [Column(Length = 15)]
        public string Country { get; set; }

        [Column(Length = 24)]
        public string Phone { get; set; }

        [Column(Length = 24)]
        public string Fax { get; set; }

        [OneToMany(ThisKey = "CustomerID", OtherKey = "CustomerID")]
        public List<Orders> Orders { get; set; }

       
    }
}
