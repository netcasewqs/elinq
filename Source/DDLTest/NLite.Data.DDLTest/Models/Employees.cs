using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace ELinq.DDLTest.Models
{
    [Table(Name = "dbo2.Employees")]
    public class Employees
    {
        [Column(AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int EmployeeID { get; set; }

        [Column(DbType = "NVarChar(20) NOT NULL", CanBeNull = false)]
        public string LastName { get; set; }

        [Column(DbType = "NVarChar(10) NOT NULL", CanBeNull = false)]
        public string FirstName { get; set; }

        [Column(DbType = "NVarChar(30)")]
        public string Title { get; set; }

        [Column(DbType = "NVarChar(25)")]
        public string TitleOfCourtesy { get; set; }

        [Column(DbType = "DateTime")]
        public System.Nullable<System.DateTime> BirthDate { get; set; }

        [Column(DbType = "DateTime")]
        public System.Nullable<System.DateTime> HireDate { get; set; }

        [Column(DbType = "NVarChar(60)")]
        public string Address { get; set; }

        [Column(DbType = "NVarChar(15)")]
        public string City { get; set; }

        [Column(DbType = "NVarChar(15)")]
        public string Region { get; set; }

        [Column(DbType = "NVarChar(10)")]
        public string PostalCode { get; set; }

        [Column(DbType = "NVarChar(15)")]
        public string Country { get; set; }

        [Column(DbType = "NVarChar(24)")]
        public string HomePhone { get; set; }

        [Column(DbType = "NVarChar(4)")]
        public string Extension { get; set; }

        [Column(DbType = "Image", UpdateCheck = UpdateCheck.Never)]
        public System.Data.Linq.Binary Photo { get; set; }

        [Column(DbType = "NText", UpdateCheck = UpdateCheck.Never)]
        public string Notes { get; set; }

        [Column(DbType = "Int")]
        public System.Nullable<int> ReportsTo { get; set; }

        [Column(DbType = "NVarChar(255)")]
        public string PhotoPath { get; set; }

        [Association(Name = "Employees_Orders",ThisKey = "EmployeeID", OtherKey = "EmployeeID")]
        public EntitySet<Orders> Orders { get; set; }

        [Association(Name = "Employees_Employees", ThisKey = "EmployeeID", OtherKey = "ReportsTo")]
        public EntitySet<Employees> Employees2 { get; set; }

        [Association(Name = "Employees_EmployeeTerritories", ThisKey = "EmployeeID", OtherKey = "EmployeeID")]
        public EntitySet<EmployeeTerritories> EmployeeTerritories { get; set; }

        [Association(Name = "Employees_Employees", ThisKey = "ReportsTo", OtherKey = "EmployeeID", IsForeignKey = true)]
        public Employees Employees1 { get; set; }
	
    }
}
