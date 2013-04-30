using System;
namespace NLite.Data.Test.Model
{
    [Table(Name = "DateTimeTest")]
    public class DateTimeModel
    {
        [Id(Name = "ID")]
        public int Id;
        [Column(Name = "DateTime")]
        public DateTime DateTime;
    }
}
