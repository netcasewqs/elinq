using System;
namespace NLite.Data.Test.Model
{
    [Table(Name = "child")]
    public class UserInfo
    {
        [Id(Name = "userID", IsDbGenerated = true)]
        public int userID;
        [Column(Name = "userName")]
        public string userName;
        [Column(Name = "descript")]
        public string descript;
        [Column(Name = "createTime")]
        public DateTime createTime;
    }
}
