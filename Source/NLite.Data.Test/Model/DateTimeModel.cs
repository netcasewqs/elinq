using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLite.Data.Mapping;
using NLite.Data;
namespace NLite.Data.Test.Model
{
    [Table(Name="DateTimeTest")]
    public class DateTimeModel
    {
        [Id(Name="ID")]
        public int Id;
        [Column(Name="DateTime")]
        public DateTime DateTime;
    }
}
