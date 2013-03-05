using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLite.Data;
using System.Data;

namespace ELinq.DDLTest.ElinqToSql.Models
{
    [Table(Name = "dbo2.Employees")]
    public class Employees
    {
        
        [Id(IsDbGenerated=true,SequenceName = "S_Employees")]
        public int EmployeeID { get; set; }

        [Column(Length = 20, IsNullable = false)]
        public string LastName { get; set; }

        [Column(Length = 10, IsNullable = false)]
        public string FirstName { get; set; }

        [Column(Length = 30)]
        public string Title { get; set; }

        [Column(Length = 20)]
        public string TitleOfCourtesy { get; set; }

        [Column]
        public System.Nullable<System.DateTime> BirthDate { get; set; }

        [Column]
        public System.Nullable<System.DateTime> HireDate { get; set; }
       
        [Column(Length = 60)]
        public string Address { get; set; }

        [Column(Length = 15)]
        public string City { get; set; }

        [Column(Length = 15)]
        public string Region { get; set; }

        [Column(Length = 10)]
        public string PostalCode { get; set; }

        [Column(Length = 15)]
        public string Country { get; set; }

        [Column(Length = 24)]
        public string HomePhone { get; set; }

        [Column(Length = 4)]
        public string Extension { get; set; }

        //[Column(DbType = DBType.Image)]
        public byte[] Photo { get; set; }

        [Column(DbType=DBType.NText)]
        public string Notes { get; set; }

        [Column]
        public System.Nullable<int> ReportsTo { get; set; }

        [Column(Length = 255)]
        public string PhotoPath { get; set; }

        [OneToMany(ThisKey = "EmployeeID", OtherKey = "EmployeeID")]
        public List<Orders> Orders { get; set; }

        [OneToMany(ThisKey = "EmployeeID", OtherKey = "ReportsTo")]
        public List<Employees> Employees2 { get; set; }

        [OneToMany(ThisKey = "EmployeeID", OtherKey = "EmployeeID")]
        public List<EmployeeTerritories> EmployeeTerritories { get; set; }

        [ManyToOne(ThisKey = "ReportsTo", OtherKey = "EmployeeID")]
        public Employees Employees1 { get; set; }
	
    }
}
