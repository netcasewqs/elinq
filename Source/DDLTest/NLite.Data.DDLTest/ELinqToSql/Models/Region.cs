using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLite.Data;

namespace ELinq.DDLTest.ElinqToSql.Models
{
    [Table(Name = "dbo2.Region")]
    public partial class Region
    {
        [Id]
        public int RegionID { get; set; }

        [Column(Length = 50, IsNullable = false)]
        public string RegionDescription { get; set; }

        [OneToMany(ThisKey = "RegionID", OtherKey = "RegionID")]
        public List<Territories> Territories { get; set; }
    }
}
