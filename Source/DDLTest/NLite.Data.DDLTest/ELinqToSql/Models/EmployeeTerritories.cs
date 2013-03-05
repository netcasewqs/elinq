using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLite.Data;

namespace ELinq.DDLTest.ElinqToSql.Models
{
    [Table(Name = "dbo2.EmployeeTerritories")]
    public class EmployeeTerritories
    {
        [Id]
        public int EmployeeID { get; set; }

        [Id(Length=20)]
        public string TerritoryID { get; set; }

        [ManyToOne(ThisKey = "EmployeeID", OtherKey = "EmployeeID")]
        public Employees Employees { get; set; }

        [ManyToOne(ThisKey = "TerritoryID", OtherKey = "TerritoryID")]
        public Territories Territories { get; set; }

    }
}
