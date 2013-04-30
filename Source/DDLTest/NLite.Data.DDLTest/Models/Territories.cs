using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace ELinq.DDLTest.Models
{
    [Table(Name = "dbo2.Territories")]
    public class Territories
    {
        [Column(DbType = "NVarChar(20) NOT NULL", CanBeNull = false, IsPrimaryKey = true)]
        public string TerritoryID { get; set; }

        [Column(DbType = "NChar(50) NOT NULL", CanBeNull = false)]
        public string TerritoryDescription { get; set; }

        [Column(Storage = "_RegionID", DbType = "Int NOT NULL")]
        public int RegionID { get; set; }

        [Association(Name = "Territories_EmployeeTerritories", ThisKey = "TerritoryID", OtherKey = "TerritoryID")]
        public EntitySet<EmployeeTerritories> EmployeeTerritories { get; set; }

        [Association(Name = "Territories_Region", ThisKey = "RegionID", OtherKey = "RegionID")]
        public EntityRef<Region> Region { get; set; }
    }
}
