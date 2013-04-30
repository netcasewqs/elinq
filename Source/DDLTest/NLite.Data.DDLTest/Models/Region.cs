using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace ELinq.DDLTest.Models
{
    [Table(Name = "dbo2.Region")]
    public partial class Region
    {
        [ColumnAttribute(DbType = "Int NOT NULL", CanBeNull = false, IsPrimaryKey = true)]
        public string RegionID { get; set; }

        [ColumnAttribute(DbType = "NChar(50) NOT NULL", CanBeNull = false)]
        public string RegionDescription { get; set; }

        [Association(Name = "Region_Territories", ThisKey = "RegionID", OtherKey = "RegionID")]
        public EntitySet<Territories> Territories { get; set; }
    }
}
