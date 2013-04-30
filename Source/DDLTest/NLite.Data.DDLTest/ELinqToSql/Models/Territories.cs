using System.Collections.Generic;
using NLite.Data;

namespace ELinq.DDLTest.ElinqToSql.Models
{
    [Table(Name = "dbo2.Territories")]
    public class Territories
    {
        [Id(Length = 20)]
        public string TerritoryID { get; set; }

        [Column(DbType = DBType.NChar, Length = 50, IsNullable = false)]
        public string TerritoryDescription { get; set; }

        [Column(IsNullable = false)]
        public int RegionID { get; set; }

        [OneToMany(ThisKey = "TerritoryID", OtherKey = "TerritoryID")]
        public List<EmployeeTerritories> EmployeeTerritories { get; set; }

        [ManyToOne(ThisKey = "RegionID", OtherKey = "RegionID")]
        public Region Region { get; set; }
    }
}
