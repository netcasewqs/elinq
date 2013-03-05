using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.Data.Linq;

namespace ELinq.DDLTest.Models
{
    [Table(Name = "dbo2.Shippers")]
    public partial class Shippers
    {
        [ColumnAttribute(DbType = "Int NOT NULL", CanBeNull = false, IsPrimaryKey = true)]
        public int ShipperID { get; set; }

        [ColumnAttribute(DbType = "NVarChar(40) NOT NULL", CanBeNull = false)]
        public string CompanyName { get; set; }

        [ColumnAttribute(DbType = "NVarChar(24)")]
        public string Phone { get; set; }

        [Association(Name = "Shippers_Orders", ThisKey = "ShipperID", OtherKey = "ShipVia")]
        public EntitySet<Orders> Orders { get; set; }
    }
}
