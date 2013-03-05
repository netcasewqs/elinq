using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLite.Data.Mapping;
using NLite.Data;

namespace NLite.Data.Test.Model
{
    [Table(Name = "Users")]
    public class Users
    {
        [Id(Name = "ID")]
        public long Id;
        [Column]
        public string Name;
        [Column]
        public string Password;
        [Column]
        public long Age;
        [Column]
        public char Sex;
        [Column]
        public string SCode;
        [Column]
        public double Height;
        [Column]
        public decimal Weight;
        [Column]
        public Boolean IsFull;
        [Column]
        public DateTime CreateTime;

    }
}
