using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.Data.Linq;

namespace ELinq.DDLTest.Models
{
    [TableAttribute(Name = "dbo2.Customers")]
    public partial class Customers 
    {
        [ColumnAttribute(DbType = "NChar(5) NOT NULL", CanBeNull = false, IsPrimaryKey = true)]
        public string CustomerID { get; set; }

        [ColumnAttribute(DbType = "NVarChar(40) NOT NULL", CanBeNull = false)]
        public string CompanyName { get; set; }

        [ColumnAttribute(DbType = "NVarChar(30)")]
        public string ContactName { get; set; }

        [ColumnAttribute(DbType = "NVarChar(30)")]
        public string ContactTitle { get; set; }

        [ColumnAttribute(DbType = "NVarChar(60)")]
        public string Address { get; set; }
        [ColumnAttribute(DbType = "NVarChar(15)")]
        public string City { get; set; }

        [ColumnAttribute(DbType = "NVarChar(15)")]
        public string Region { get; set; }

        [ColumnAttribute(DbType = "NVarChar(10)")]
        public string PostalCode { get; set; }

        [ColumnAttribute(DbType = "NVarChar(15)")]
        public string Country { get; set; }

        [ColumnAttribute(DbType = "NVarChar(24)")]
        public string Phone { get; set; }

        [ColumnAttribute(DbType = "NVarChar(24)")]
        public string Fax { get; set; }

        [AssociationAttribute(ThisKey = "CustomerID", OtherKey = "CustomerID")]
        public EntitySet<Orders> Orders { get; set; }

       
    }
}
