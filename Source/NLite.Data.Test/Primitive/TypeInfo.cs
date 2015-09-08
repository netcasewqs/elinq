using System;
using System.ComponentModel;

namespace NLite.Data.Test.Primitive.Model
{
    [Table(Name = "child")]
    public class UserInfo
    {
        [Id(Name = "userId", IsDbGenerated = true)]
        public int userID;
        //[Column(Name = "userName")]
        public string userName;
        [Column(Name = "descript")]
        public string descript;
        //[Column(Name = "createTime")]
        public DateTime createTime;
    }

    [Table(Name = "NullableTypes")]
    public class NullableTypeInfo
    {
        [Id(Name = "Id", IsDbGenerated = true)]
        public int Id;
        //[Column]
        public bool? Boolean;
        //[Column]
        public byte? Byte;
        //[Column]
        public byte[] Binary;
        //[Column]
        public char? Char;
        //[Column]
        public DateTime? DateTime;
        //[Column]
        public Decimal? Decimal;
        //[Column]
        public Double? Double;
        //[Column]
        public Guid? Guid;
        //[Column]
        public Int16? Int16;
        //[Column]
        public Int32? Int32;
        //[Column]
        public Int64? Int64;
        //[Column]
        public SByte? SByte;
        // [Column]
        public Single? Single;
        // [Column]
        public String String;
        //[Column]
        public UInt16? UInt16;
        //[Column]
        public UInt32? UInt32;
        //[Column]
        public UInt64? UInt64;
    }

    [Table(Name = "TypeInfos")]
    public class TypeInfo
    {
        [Id(Name = "Id", IsDbGenerated = true)]
        public int Id;
        //[Column]
        public bool Boolean;
      
    }

    [Flags]
    public enum roles : int
    {
        [Description("学生")]
        Student = 1,
        [Description("教师")]
        Teacher = 2,
        [Description("管理员")]
        Administrator = 4,
        [Description("服务人员")]
        Server = 8
    };
    [Table(Name = "NullableTypes")]
    public class EnumClass
    {
        [Id(Name = "Id", IsDbGenerated = true)]
        public int Id;
        // [Column(Name="Int32")]
        public roles? Int32;
        // [Column]
        public String String;
    }

}

