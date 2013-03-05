using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLite.Data.Mapping;
using NLite.Data;
namespace NLite.Data.Test.Model
{
    [Table(Name="MathTest")]
    public class MathModel
    {
        [Id(Name = "ID",IsDbGenerated=true)]
        public int ID;
        [Column(Name="a")]
        public int a;
        [Column(Name = "b")]
        public int b;
        [Column(Name = "c")]
        public double c;
        [Column(Name = "d")]
        public decimal d;
    }
}
