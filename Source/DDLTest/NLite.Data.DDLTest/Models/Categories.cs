using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace ELinq.DDLTest.Models
{
    [TableAttribute(Name = "dbo2.Categories")]
    public partial class Categories
    {
        [ColumnAttribute(DbType = "Int NOT NULL", CanBeNull = false, IsPrimaryKey = true)]
        public int CategoryID { get; set; }

        [ColumnAttribute(DbType = "NVarChar(15) NOT NULL", CanBeNull = false)]
        public string CategoryName { get; set; }

        [ColumnAttribute(DbType = "NText(16)")]
        public string Description { get; set; }

        [ColumnAttribute(DbType = "Image(16)")]
        public Binary Picture { get; set; }

        [Association(Name = "Categories_Products", ThisKey = "CategoryID", OtherKey = "CategoryID")]
        public EntitySet<Products> Products { get; set; }
    }
}
