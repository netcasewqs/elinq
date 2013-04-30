using System;
using System.Linq;
using NLite.Data.Test.Primitive.Model;

using NUnit.Framework;
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestMethod = NUnit.Framework.TestAttribute;


namespace NLite.Data.Test.Where
{
    [TestClass]
    public class ByteArrayTest : TestBase<NullableTypeInfo>
    {
        protected override string ConnectionStringName
        {
            get
            {
                return "NumericDB";
            }
        }
        /// <summary>
        /// byte[] ,在SQLCE中，对应类型有：binary(n),varbinary(n),image.我们使用的类型[varbinary(100)]
        ///         在MySQL中，对应类型有：binary(n),varbinary(n),tinyblob,blob,mediumblob,longbob.我们使用的类型[longblob]
        ///         在SQLServer中，对应类型有：binary(n),image,varbinary(n).我们使用的类型[binary(max)]
        ///         在Access中，对应类型有：OLE对象。我们使用的类型[OLE对象]
        ///         在SQLite中，对应类型有：binary,blob,image.我们使用的类型[binary]
        /// 求长度，在sqlserver中的相应函数有：len（expression），返回字符数，不含尾随空格。参数为image类型时无效;
        ///                    datalength(expression),支持任何类型的表达式，表示该表达式的字节数。NULL 的 DATALENGTH 的结果是 NULL
        ///         在MySQL中，length(expression)，返回最大字节数
        ///                    bit_length(),返回二进制字符串的长度
        ///                    octext_length(),同length()
        ///         在SQLCE中，len(expression),返回字符数，包含尾随空格。不支持money,ntext,image类型
        ///                    datalength(expression),返回字节数，支持任何类型的表达式
        ///         在SQLite中，length(expression),返回字符数.
        ///         在Access中，len(expression),返回长整数，包含储存变量所需的字符串的字符数或字节数。null返回null
        ///                     UBound(array[,dimension]),返回长整形，值为指定的数组维的可用的最大下标
        /// </summary>
        [TestMethod]
        public virtual void Length()
        {
            var arr = new int[] { 123, 0, -1, int.MaxValue, int.MinValue };
            for (int i = 0; i < arr.Length; i++)
            {
                Db.Set<NullableTypeInfo>().Delete(p => p.Int32 == arr[i]);
                Db.Set<NullableTypeInfo>().Insert(new NullableTypeInfo { Binary = BitConverter.GetBytes(arr[i]), Int32 = arr[i] });
                var item = Db.Set<NullableTypeInfo>().First(p => p.Binary.Length >= 0 && p.Int32 == arr[i]);
                Assert.IsNotNull(item);
                Db.Set<NullableTypeInfo>().Delete(p => p.Int32 == arr[i]);
            }
        }
        //        [TestMethod]
        //#if SqlServer ||SqlCE||SQLite||MySQL||Access
        //        [ExpectedException(typeof(NotSupportedException))]
        //#endif
        //        public virtual void GetLength()
        //        {
        //            var arr = new int[] { 123, 0, -1, int.MinValue, int.MaxValue };
        //            for (int i = 0; i < arr.Length; i++)
        //            {
        //                Db.Set<NullableTypeInfo>().Delete(p => p.Int32 == arr[i]);
        //                Db.Set<NullableTypeInfo>().Insert(new NullableTypeInfo { Binary = BitConverter.GetBytes(arr[i]), Int32 = arr[i] });
        //                var item = Db.Set<NullableTypeInfo>().First(p => p.Binary.GetLength(0)== arr[i] && p.Int32 == arr[i]);
        //                Assert.IsNotNull(item);
        //                Db.Set<NullableTypeInfo>().Delete(p => p.Int32 == arr[i]);
        //            }
        //        }

        //        [TestMethod]
        //#if SqlServer ||SqlCE||SQLite||MySQL||Access
        //        [ExpectedException(typeof(NotSupportedException))]
        //#endif
        //        public virtual void GetLongLength()
        //        {
        //            var arr = new int[] { 123, 0, -1, int.MinValue, int.MaxValue };
        //            for (int i = 0; i < arr.Length; i++)
        //            {
        //                Db.Set<NullableTypeInfo>().Delete(p => p.Int32 == arr[i]);
        //                Db.Set<NullableTypeInfo>().Insert(new NullableTypeInfo { Binary = BitConverter.GetBytes(arr[i]), Int32 = arr[i] });
        //                var item = Db.Set<NullableTypeInfo>().First(p => p.Binary.GetLongLength(0)== arr[i] && p.Int32 == arr[i]);
        //                Assert.IsNotNull(item);
        //                Db.Set<NullableTypeInfo>().Delete(p => p.Int32 == arr[i]);
        //            }
        //        }

        [TestMethod]
        public virtual void Equal()
        {
            var arr = new int[] { 123, 0, -1, int.MinValue, int.MaxValue };
            for (int i = 0; i < arr.Length; i++)
            {
                Db.Set<NullableTypeInfo>().Delete(p => p.Int32 == arr[i]);
                byte[] bytearr = BitConverter.GetBytes(arr[i]);
                Db.Set<NullableTypeInfo>().Insert(new NullableTypeInfo { Binary = bytearr, Int32 = arr[i] });
                var item = Db.Set<NullableTypeInfo>().First(p => p.Binary == bytearr && p.Int32 == arr[i]);
                Assert.IsNotNull(item);
                Db.Set<NullableTypeInfo>().Delete(p => p.Int32 == arr[i]);
            }
        }
        [TestMethod]
        public virtual void Equals()
        {
            var arr = new int[] { 123, 0, -1, int.MinValue, int.MaxValue };
            for (int i = 0; i < arr.Length; i++)
            {
                Db.Set<NullableTypeInfo>().Delete(p => p.Int32 == arr[i]);
                byte[] bytearr = BitConverter.GetBytes(arr[i]);
                Db.Set<NullableTypeInfo>().Insert(new NullableTypeInfo { Binary = bytearr, Int32 = arr[i] });
                var item = Db.Set<NullableTypeInfo>().First(p => p.Binary.Equals(bytearr) && p.Int32 == arr[i]);
                Assert.IsNotNull(item);
                Db.Set<NullableTypeInfo>().Delete(p => p.Int32 == arr[i]);
            }
        }
        [TestMethod]
        //[ExpectedException(typeof(QueryException))]//( IS NULL),sql语句错误，bytearr被当作null
        public virtual void object_Equals()
        {
            var arr = new int[] { 123, 0, -1, int.MinValue, int.MaxValue };
            for (int i = 0; i < arr.Length; i++)
            {
                Db.Set<NullableTypeInfo>().Delete(p => p.Int32 == arr[i]);
                byte[] bytearr = BitConverter.GetBytes(arr[i]);
                Db.Set<NullableTypeInfo>().Insert(new NullableTypeInfo { Binary = bytearr, Int32 = arr[i] });
                var item = Db.Set<NullableTypeInfo>().First(p => object.Equals(p.Binary, bytearr) && p.Int32 == arr[i]);
                Assert.IsNotNull(item);
                Db.Set<NullableTypeInfo>().Delete(p => p.Int32 == arr[i]);
            }
        }

        //        [TestMethod]
        //#if SqlServer ||SqlCE||SQLite||MySQL||Access
        //        [ExpectedException(typeof(NotSupportedException))]
        //#endif
        //        public virtual void ConverterToInt32()
        //        {
        //            var arr = new int[] { 123, 0, -1, int.MinValue, int.MaxValue };
        //            for (int i = 0; i < arr.Length; i++)
        //            {
        //                Db.Set<NullableTypeInfo>().Delete(p => p.Int32 == arr[i]);
        //                Db.Set<NullableTypeInfo>().Insert(new NullableTypeInfo { Binary = BitConverter.GetBytes(arr[i]), Int32 = arr[i] });
        //                var item = Db.Set<NullableTypeInfo>().First(p =>BitConverter.ToInt32(p.Binary,1)==arr[i] && p.Int32 == arr[i]);
        //                Assert.IsNotNull(item);
        //                Db.Set<NullableTypeInfo>().Delete(p => p.Int32 == arr[i]);
        //            }
        //        }
        //        [TestMethod]
        //#if SqlServer ||SqlCE||SQLite||MySQL||Access
        //        [ExpectedException(typeof(NotSupportedException))]
        //#endif
        //        public virtual void ConverterToInt64()
        //        {
        //            var arr = new int[] { 123, 0, -1, int.MinValue, int.MaxValue };
        //            for (int i = 0; i < arr.Length; i++)
        //            {
        //                Db.Set<NullableTypeInfo>().Delete(p => p.Int32 == arr[i]);
        //                Db.Set<NullableTypeInfo>().Insert(new NullableTypeInfo { Binary = BitConverter.GetBytes(arr[i]), Int32 = arr[i] });
        //                var item = Db.Set<NullableTypeInfo>().First(p => BitConverter.ToInt64(p.Binary, 1) == arr[i] && p.Int32 == arr[i]);
        //                Assert.IsNotNull(item);
        //                Db.Set<NullableTypeInfo>().Delete(p => p.Int32 == arr[i]);
        //            }
        //        }
        //        [TestMethod]
        //#if SqlServer ||SqlCE||SQLite||MySQL||Access
        //        [ExpectedException(typeof(NotSupportedException))]
        //#endif
        //        public virtual void ConverterToInt16()
        //        {
        //            var arr = new int[] { 123, 0, -1, int.MinValue, int.MaxValue };
        //            for (int i = 0; i < arr.Length; i++)
        //            {
        //                Db.Set<NullableTypeInfo>().Delete(p => p.Int32 == arr[i]);
        //                Db.Set<NullableTypeInfo>().Insert(new NullableTypeInfo { Binary = BitConverter.GetBytes(arr[i]), Int32 = arr[i] });
        //                var item = Db.Set<NullableTypeInfo>().First(p => BitConverter.ToInt16(p.Binary, 1) == arr[i] && p.Int32 == arr[i]);
        //                Assert.IsNotNull(item);
        //                Db.Set<NullableTypeInfo>().Delete(p => p.Int32 == arr[i]);
        //            }
        //        }
        //        [TestMethod]
        //#if SqlServer ||SqlCE||SQLite||MySQL||Access
        //        [ExpectedException(typeof(NotSupportedException))]
        //#endif
        //        public virtual void GetLowerBound()
        //        {
        //            var arr = new int[] { 123, 0, -1, int.MinValue, int.MaxValue };
        //            for (int i = 0; i < arr.Length; i++)
        //            {
        //                Db.Set<NullableTypeInfo>().Delete(p => p.Int32 == arr[i]);
        //                Db.Set<NullableTypeInfo>().Insert( new NullableTypeInfo { Binary = BitConverter.GetBytes(arr[i]), Int32 = arr[i] });
        //                var item = Db.Set<NullableTypeInfo>().First(p =>p.Binary.GetLowerBound(0)== arr[i] && p.Int32 == arr[i]);
        //                Assert.IsNotNull(item);
        //                Db.Set<NullableTypeInfo>().Delete(p => p.Int32 == arr[i]);
        //            }
        //        }
        //        [TestMethod]
        //#if SqlServer ||SqlCE||SQLite||MySQL||Access
        //        [ExpectedException(typeof(NotSupportedException))]
        //#endif
        //        public virtual void GetString()
        //        {
        //            var arr = new int[] { 123, 0, -1, int.MinValue, int.MaxValue };
        //            for (int i = 0; i < arr.Length; i++)
        //            {
        //                Db.Set<NullableTypeInfo>().Delete(p => p.Int32 == arr[i]);
        //                Db.Set<NullableTypeInfo>().Insert(new NullableTypeInfo { Binary = BitConverter.GetBytes(arr[i]), Int32 = arr[i] });
        //                var item = Db.Set<NullableTypeInfo>().First(p => p.Binary.GetString() == arr[i].ToString() && p.Int32 == arr[i]);
        //                Assert.IsNotNull(item);
        //                Db.Set<NullableTypeInfo>().Delete(p => p.Int32 == arr[i]);
        //            }
        //        }
        //        [TestMethod]
        //#if SqlServer ||SqlCE||SQLite||MySQL||Access
        //        [ExpectedException(typeof(NotSupportedException))]
        //#endif
        //        public virtual void GetStringASCII()
        //        {
        //            var arr = new int[] { 123, 0, -1, int.MinValue, int.MaxValue };
        //            for (int i = 0; i < arr.Length; i++)
        //            {
        //                Db.Set<NullableTypeInfo>().Delete(p => p.Int32 == arr[i]);
        //                Db.Set<NullableTypeInfo>().Insert(new NullableTypeInfo { Binary = BitConverter.GetBytes(arr[i]), Int32 = arr[i] });
        //                var item = Db.Set<NullableTypeInfo>().First(p => p.Binary.GetStringASCII(1,0) == arr[i].ToString() && p.Int32 == arr[i]);
        //                Assert.IsNotNull(item);
        //                Db.Set<NullableTypeInfo>().Delete(p => p.Int32 == arr[i]);
        //            }
        //        }
        //        [TestMethod]
        //#if SqlServer ||SqlCE||SQLite||MySQL||Access
        //        [ExpectedException(typeof(NotSupportedException))]
        //#endif
        //        public virtual void GetStringUTF8()
        //        {
        //            var arr = new int[] { 123, 0, -1, int.MinValue, int.MaxValue };
        //            for (int i = 0; i < arr.Length; i++)
        //            {
        //                Db.Set<NullableTypeInfo>().Delete(p => p.Int32 == arr[i]);
        //                Db.Set<NullableTypeInfo>().Insert(new NullableTypeInfo { Binary = BitConverter.GetBytes(arr[i]), Int32 = arr[i] });
        //                var item = Db.Set<NullableTypeInfo>().First(p => p.Binary.GetStringUTF8() == arr[i].ToString() && p.Int32 == arr[i]);
        //                Assert.IsNotNull(item);
        //                Db.Set<NullableTypeInfo>().Delete(p => p.Int32 == arr[i]);
        //            }
        //        }
        //        [TestMethod]
        //#if SqlServer ||SqlCE||SQLite||MySQL||Access
        //        [ExpectedException(typeof(NotSupportedException))]
        //#endif
        //        public virtual void GetUpperBound()
        //        {
        //            var arr = new int[] { 123, 0, -1, int.MinValue, int.MaxValue };
        //            for (int i = 0; i < arr.Length; i++)
        //            {
        //                Db.Set<NullableTypeInfo>().Delete(p => p.Int32 == arr[i]);
        //                Db.Set<NullableTypeInfo>().Insert(new NullableTypeInfo { Binary = BitConverter.GetBytes(arr[i]), Int32 = arr[i] });
        //                var item = Db.Set<NullableTypeInfo>().First(p => p.Binary.GetUpperBound(1) == arr[i] && p.Int32 == arr[i]);
        //                Assert.IsNotNull(item);
        //                Db.Set<NullableTypeInfo>().Delete(p => p.Int32 == arr[i]);
        //            }
        //        }
        //        [TestMethod]
        //#if SqlServer ||SqlCE||SQLite||MySQL||Access
        //        [ExpectedException(typeof(NotSupportedException))]
        //#endif
        //        public virtual void GetValue()
        //        {
        //            var arr = new int[] { 123, 0, -1, int.MinValue, int.MaxValue };
        //            for (int i = 0; i < arr.Length; i++)
        //            {
        //                Db.Set<NullableTypeInfo>().Delete(p => p.Int32 == arr[i]);
        //                Db.Set<NullableTypeInfo>().Insert(new NullableTypeInfo { Binary = BitConverter.GetBytes(arr[i]), Int32 = arr[i] });
        //                var item = Db.Set<NullableTypeInfo>().First(p => (int)p.Binary.GetValue(1) == arr[i] && p.Int32 == arr[i]);
        //                Assert.IsNotNull(item);
        //                Db.Set<NullableTypeInfo>().Delete(p => p.Int32 == arr[i]);
        //            }
        //        }
        //        [TestMethod]
        //#if SqlServer ||SqlCE||SQLite||MySQL||Access
        //        [ExpectedException(typeof(NotSupportedException))]
        //#endif
        //        public virtual void IsFixedSize()
        //        {
        //            var arr = new int[] { 123, 0, -1, int.MinValue, int.MaxValue };
        //            for (int i = 0; i < arr.Length; i++)
        //            {
        //                Db.Set<NullableTypeInfo>().Delete(p => p.Int32 == arr[i]);
        //                Db.Set<NullableTypeInfo>().Insert(new NullableTypeInfo { Binary = BitConverter.GetBytes(arr[i]), Int32 = arr[i] });
        //                var item = Db.Set<NullableTypeInfo>().First(p => p.Binary.IsFixedSize==false && p.Int32 == arr[i]);
        //                Assert.IsNotNull(item);
        //                Db.Set<NullableTypeInfo>().Delete(p => p.Int32 == arr[i]);
        //            }
        //        }
        //        [TestMethod]
        //#if SqlServer ||SqlCE||SQLite||MySQL||Access
        //        [ExpectedException(typeof(NotSupportedException))]
        //#endif
        //        public virtual void IsReadOnly()
        //        {
        //            var arr = new int[] { 123, 0, -1, int.MinValue, int.MaxValue };
        //            for (int i = 0; i < arr.Length; i++)
        //            {
        //                Db.Set<NullableTypeInfo>().Delete(p => p.Int32 == arr[i]);
        //                Db.Set<NullableTypeInfo>().Insert(new NullableTypeInfo { Binary = BitConverter.GetBytes(arr[i]), Int32 = arr[i] });
        //                var item = Db.Set<NullableTypeInfo>().First(p => p.Binary.IsReadOnly == false && p.Int32 == arr[i]);
        //                Assert.IsNotNull(item);
        //                Db.Set<NullableTypeInfo>().Delete(p => p.Int32 == arr[i]);
        //            }
        //        }
        //        [TestMethod]
        //#if SqlServer ||SqlCE||SQLite||MySQL||Access
        //        [ExpectedException(typeof(NotSupportedException))]
        //#endif
        //        public virtual void Rank()
        //        {
        //            var arr = new int[] { 123, 0, -1, int.MinValue, int.MaxValue };
        //            for (int i = 0; i < arr.Length; i++)
        //            {
        //                Db.Set<NullableTypeInfo>().Delete(p => p.Int32 == arr[i]);
        //                Db.Set<NullableTypeInfo>().Insert(new NullableTypeInfo { Binary = BitConverter.GetBytes(arr[i]), Int32 = arr[i] });
        //                var item = Db.Set<NullableTypeInfo>().First(p => p.Binary.Rank == 1 && p.Int32 == arr[i]);
        //                Assert.IsNotNull(item);
        //                Db.Set<NullableTypeInfo>().Delete(p => p.Int32 == arr[i]);
        //            }
        //        }
        //        [TestMethod]
        //#if SqlServer ||SqlCE||SQLite||MySQL||Access
        //        [ExpectedException(typeof(NotSupportedException))]
        //#endif
        //        public virtual void BinarySearch()
        //        {
        //            var arr = new int[] { 123, 0, -1, int.MinValue, int.MaxValue };
        //            for (int i = 0; i < arr.Length; i++)
        //            {
        //                Db.Set<NullableTypeInfo>().Delete(p => p.Int32 == arr[i]);
        //                Db.Set<NullableTypeInfo>().Insert(new NullableTypeInfo { Binary = BitConverter.GetBytes(arr[i]), Int32 = arr[i] });
        //                var item = Db.Set<NullableTypeInfo>().First(p =>Array.BinarySearch( p.Binary,0)==2 && p.Int32 == arr[i]);
        //                Assert.IsNotNull(item);
        //                Db.Set<NullableTypeInfo>().Delete(p => p.Int32 == arr[i]);
        //            }
        //        }
        //        [TestMethod]
        //#if SqlServer ||SqlCE||SQLite||MySQL||Access
        //        [ExpectedException(typeof(NotSupportedException))]
        //#endif
        //        public virtual void IndexOf()
        //        {
        //            var arr = new int[] { 123, 0, -1, int.MinValue, int.MaxValue };
        //            for (int i = 0; i < arr.Length; i++)
        //            {
        //                Db.Set<NullableTypeInfo>().Delete(p => p.Int32 == arr[i]);
        //                Db.Set<NullableTypeInfo>().Insert(new NullableTypeInfo { Binary = BitConverter.GetBytes(arr[i]), Int32 = arr[i] });
        //                var item = Db.Set<NullableTypeInfo>().First(p => Array.IndexOf(p.Binary,0) ==2 && p.Int32 == arr[i]);
        //                Assert.IsNotNull(item);
        //                Db.Set<NullableTypeInfo>().Delete(p => p.Int32 == arr[i]);
        //            }
        //        }
        //        [TestMethod]
        //#if SqlServer ||SqlCE||SQLite||MySQL||Access
        //        [ExpectedException(typeof(NotSupportedException))]
        //#endif
        //        public virtual void LastIndexOf()
        //        {
        //            var arr = new int[] { 123, 0, -1, int.MinValue, int.MaxValue };
        //            for (int i = 0; i < arr.Length; i++)
        //            {
        //                Db.Set<NullableTypeInfo>().Delete(p => p.Int32 == arr[i]);
        //                Db.Set<NullableTypeInfo>().Insert(new NullableTypeInfo { Binary = BitConverter.GetBytes(arr[i]), Int32 = arr[i] });
        //                var item = Db.Set<NullableTypeInfo>().First(p => Array.LastIndexOf(p.Binary,0) == 3 && p.Int32 == arr[i]);
        //                Assert.IsNotNull(item);
        //                Db.Set<NullableTypeInfo>().Delete(p => p.Int32 == arr[i]);
        //            }
        //        }
    }
}
