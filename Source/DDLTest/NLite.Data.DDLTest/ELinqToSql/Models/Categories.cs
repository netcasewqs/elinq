using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLite.Data;

namespace ELinq.DDLTest.ElinqToSql.Models
{
    [TableAttribute(Name = "dbo2.Categories")]
    public partial class Categories
    {
        [Id]
        public int CategoryID { get; set; }

        [Column(IsNullable=false,Length=15)]
        public string CategoryName { get; set; }

        [Column(DbType=DBType.NText)]
        public string Description { get; set; }

        [Column(DbType=DBType.Image)]
        public byte[] Picture { get; set; }

        [OneToMany(ThisKey = "CategoryID", OtherKey = "CategoryID")]
        public List<Products> Products { get; set; }
    }
}
