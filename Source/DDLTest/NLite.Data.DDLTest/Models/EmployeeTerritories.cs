using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace ELinq.DDLTest.Models
{
    [Table(Name = "dbo2.EmployeeTerritories")]
    public class EmployeeTerritories
    {
        [Column(DbType = "Int NOT NULL", IsPrimaryKey = true)]
        public int EmployeeID { get; set; }

        [Column(DbType = "NVarChar(20) NOT NULL", CanBeNull = false, IsPrimaryKey = true)]
        public string TerritoryID { get; set; }

        [Association(Name = "Employees_EmployeeTerritories", ThisKey = "EmployeeID", OtherKey = "EmployeeID", IsForeignKey = true)]
        public EntityRef<Employees> Employees { get; set; }

        [Association(Name = "Territories_EmployeeTerritories", ThisKey = "TerritoryID", OtherKey = "TerritoryID", IsForeignKey = true)]
        public EntityRef<Territories> Territories { get; set; }

    }
}
