using System.Collections.Generic;
using NLite.Data;

namespace ELinq.DDLTest.ElinqToSql.Models
{
    [Table(Name = "dbo2.Shippers")]
    public partial class Shippers
    {
        [Id]
        public int ShipperID { get; set; }

        [Column(Length = 40, IsNullable = false)]
        public string CompanyName { get; set; }

        [Column(Length = 24)]
        public string Phone { get; set; }

        [OneToMany(ThisKey = "ShipperID", OtherKey = "ShipVia")]
        public List<Orders> Orders { get; set; }
    }
}
