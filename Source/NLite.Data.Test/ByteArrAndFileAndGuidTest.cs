using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestInitialize = NUnit.Framework.SetUpAttribute;
using TestMethod = NUnit.Framework.TestAttribute;
using NLite.Data.Test.Primitive.Model;
using NLite.Collections;
using System.IO;
using System.Drawing;
using System.ComponentModel;

namespace NLite.Data.Test
{
    [TestClass]
    public class ByteArrAndFileAndGuidTest:TestBase<NullableTypeInfo>
    {
        protected override string ConnectionStringName
        {
            get
            {
                return "NumericDB";
            }
        }

        [TestMethod]
        public virtual void IntTest()
        {
            var arr = new int[] { 123, 0, -1, int.MaxValue, int.MinValue };
            for (int i = 0; i < arr.Length; i++)
            {
                Db.Set<NullableTypeInfo>().Insert(new NullableTypeInfo { Binary = BitConverter.GetBytes(arr[i]), Int32 = arr[i] });
                var item = Db.Set<NullableTypeInfo>().FirstOrDefault(p => p.Int32 == arr[i]);
                Assert.AreEqual(BitConverter.ToInt32(item.Binary, 0), arr[i]);
                Console.WriteLine(BitConverter.ToInt32(item.Binary, 0));
                

                var sql = Db.Set<NullableTypeInfo>().Select(p => p.Int32).Distinct().Count();//SELECT COUNT(*) FROM ( SELECT DISTINCT t1.Int32 FROM NullableTypes AS t1 ) AS t0
                Console.WriteLine("Int32总数，不含重复值："+sql);
                //TODO:BUG :count_big()
                var LongCount = Db.Set<NullableTypeInfo>().Select(p => p.Id).LongCount();//COUNT(*)
                Console.WriteLine("Id总量：" + LongCount);
                var Count = Db.Set<NullableTypeInfo>().Select(p => p.Id).Count();//COUNT(*)
                Console.WriteLine("Id个数：" + Count);
                var Sum = Db.Set<NullableTypeInfo>().Select(p => p.Id).Sum();// SUM(t0.Id)
                Console.WriteLine("Id总和：" + Sum);
                var AverageValue = Db.Set<NullableTypeInfo>().Select(p => p.Id).Average();//AVG(t0.Id)
                Console.WriteLine("Id平均值：" + AverageValue);
                var MinValue = Db.Set<NullableTypeInfo>().Select(p => p.Id).Min();//MIN(t0.Id)
                Console.WriteLine("Id最小值：" + MinValue);
                var MaxValue = Db.Set<NullableTypeInfo>().Select(p => p.Id).Max();//MAX(t0.Id)
                Console.WriteLine("Id最大值：" + MaxValue);

                var First = Db.Set<NullableTypeInfo>().First().Id;//SELECT TOP (1)* FROM NullableTypes AS t0
                Console.WriteLine("第一个ID" + First);
                //TODO:BUG
                var Last = Db.Set<NullableTypeInfo>().Last().Id;//SELECT TOP (1)* FROM NullableTypes AS t0
                Console.WriteLine("最后一个ID"+Last);

                //TODO:Join
                //Db.Set<NullableTypeInfo>().Select(p => p.Id > 5000).Join(Id,;

                var EscFirst = Db.Set<NullableTypeInfo>().OrderBy(p => p.Id).First().Id;//SELECT TOP (1) * FROM NullableTypes AS t0 ORDER BY t0.Id
                Console.WriteLine("Orderby升序Id第一个" + EscFirst);

                var EscLast = Db.Set<NullableTypeInfo>().OrderBy(p => p.Id).Last().Id;//SELECT TOP(1)*FROM NullableTypes AS t0 ORDER BY t0.Id DESC
                Console.WriteLine("Orderby升序Id最后一个"+EscLast);

                var DescFirst = Db.Set<NullableTypeInfo>().OrderByDescending(p => p.Id).First().Id;//SELECT TOP (1)* FROM NullableTypes AS t0 ORDER BY t0.Id DESC
                Console.WriteLine("Orderby降序Id第一个" + DescFirst);
                var DescLast = Db.Set<NullableTypeInfo>().OrderByDescending(p => p.Id).Last().Id;//SELECT TOP (1) * FROM NullableTypes AS t0 ORDER BY t0.Id
                Console.WriteLine("Orderby降序Id最后一个" +DescLast);

                //TODO:GroupBy，Having
                //Db.Set<NullableTypeInfo>().GroupBy(p => p.Id;

                var Exist = Db.Set<NullableTypeInfo>().Exists();
                Console.WriteLine("表中是否有记录：" + Exist);
                //TODO:In
                //Db.Set<NullableTypeInfo>().Select(p=>p.Id).In(

                var Any = Db.Set<NullableTypeInfo>().Select(p => p.Id < 6000).Any();//SELECT CASE WHEN (EXISTS( SELECT NULL  FROM NullableTypes AS t0 )) THEN 1 ELSE 0 END AS [value]
                Console.WriteLine("是否存在满足条件的值" + Any);

                var All = Db.Set<NullableTypeInfo>().All(p => p.Id > 5000 && p.Id < 6000);//SELECT CASE WHEN (NOT EXISTS( SELECT NULL  FROM NullableTypes AS t0 WHERE NOT ((t0.Id > 5000) AND (t0.Id < 6000)) )) THEN 1 ELSE 0 END AS [value]
                Console.WriteLine("是否全部满足条件" + All);

                var Contains = Db.Set<NullableTypeInfo>().Select(p => p.Id).Contains(57922);//SELECT CASE WHEN (57922 IN ( SELECT t0.Id FROM NullableTypes AS t0 )) THEN 1 ELSE 0 END AS [value]
                Console.WriteLine("指定列中是否存在指定的元素值" + Contains);

                //TODO:?Bottom
                Db.Set<NullableTypeInfo>().Take(2).Dump();//SELECT TOP (2)
                Db.Set<NullableTypeInfo>().Skip(2).OrderBy(p => p.Id).Dump();//select * from(select Row_number() over(order by t1.Id) as _rownumber,...from nullabletypes as t1) as t0 where (t0._rownumber >2) order by t0.Id
                
                Db.Set<NullableTypeInfo>().Delete(p => p.Int32 == arr[i]);
            }
            Db.Set<NullableTypeInfo>().Insert(new NullableTypeInfo { Binary=null, Int32 = 36 });
            var note = Db.Set<NullableTypeInfo>().FirstOrDefault(p => p.Int32 == 36);
            Assert.IsNotNull(note);
            Assert.IsNull(note.Binary);
            Db.Set<NullableTypeInfo>().Delete(p => p.Int32 == 36);

        }
        [TestMethod]
        public virtual void BytesTest()
        {
            var arr2 = new byte[,] { { 123, 23, 35, 8 }, { 0, 0, 0, 0 }, { 0, 34, byte.MinValue, byte.MaxValue } };
            for (int i = 0; i < 3; i++)
            {
                var arr1 = new byte[4];
                for (int j = 0; j < 4; j++)
                {
                    arr1[j] = arr2[i, j];
                }
                Db.Set<NullableTypeInfo>().Insert(new NullableTypeInfo { Binary = arr1, Int32 = 36 });
                var item = Db.Set<NullableTypeInfo>().FirstOrDefault(p => p.Int32 == 36);
                Assert.IsNotNull(item);
                Console.WriteLine(BitConverter.ToString(arr1));
                Console.WriteLine(BitConverter.ToString(item.Binary));//MySQL中，会在剩余位上补0
                Db.Set<NullableTypeInfo>().Delete(p => p.Int32 == 36);
            }
            byte[] a = null;
            Db.Set<NullableTypeInfo>().Insert(new NullableTypeInfo { Binary=a,Int32=36});
            var note = Db.Set<NullableTypeInfo>().FirstOrDefault(p => p.Int32 == 36);
            Assert.IsNotNull(note);
            Assert.IsNull(note.Binary);
            Db.Set<NullableTypeInfo>().Delete(p => p.Int32 == 36);
        }
#if SqlCE|| MySQL //sqlserverCE数据库中，设置Binary的长度为100，图片长度超出范围
                [ExpectedException(typeof(PersistenceException))]
#endif
        [TestMethod]
        public virtual void ImageTest()
        {
            int id = 1234;
            var expected = GetImageContent("460.jpg");
            //Console.WriteLine(expected.Length);//44606
            Db.Set<NullableTypeInfo>().Insert(new NullableTypeInfo {Binary=expected,Int32=id});
            var item = Db.Set<NullableTypeInfo>().FirstOrDefault(p => p.Int32 == id);
            SaveImage(item.Binary, "460-zxm.jpg");
            Db.Set<NullableTypeInfo>().Delete(p => p.Int32 == id);
        }

        internal static byte[] GetImageContent(string file)
        {
            //file = AppDomain.CurrentDomain.BaseDirectory + "\\" + file;
            using(var image = Image.FromFile(file))
            using (var stream = new MemoryStream())
            {
                image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                return stream.ToArray();
            }
        }

        internal static void SaveImage(byte[] bytes,string file)
        {
            if (!file.IsNullOrEmpty())
            {
                File.Delete(file);
            }
            using (var stream = new MemoryStream(bytes))
            using (var image = Image.FromStream(stream))
                image.Save(file);
        }

        [TestMethod]
        public virtual void GuidTest()
        {
            Guid? guid = new Guid("4A83D44A-5612-4E78-89EE-08F894912C0A");
            //Guid? guidErr = new Guid("4A83D44A-5612-4E78-89EE-08F894912C0");
            var guidArr = new Guid?[]{guid,null/*,guidErr*/};
            for (int i = 0; i < guidArr.Length; i++)
            {
                Db.Set<NullableTypeInfo>().Insert(new NullableTypeInfo { Guid = guidArr[i], String = "zxmGuid" });
                var item = Db.Set<NullableTypeInfo>().FirstOrDefault(p => p.String == "zxmGuid");
                Assert.IsNotNull(item);
                Console.WriteLine(item.Guid);
                
                Db.Set<NullableTypeInfo>().Delete(p => p.String == "zxmGuid");
            }
        }
        [TestMethod]
        public virtual void FileTest()
        {
            string a = "zxmFile";
            var expected = GetFileContent("区别.txt");
            Db.Set<NullableTypeInfo>().Insert(new NullableTypeInfo { Binary=expected,String=a});
            var item = Db.Set<NullableTypeInfo>().FirstOrDefault(p => p.String == a);
            SaveFile(item.Binary, "different_zxm.txt");

            Db.Set<NullableTypeInfo>().Delete(p => p.String == a);
        }
        internal virtual byte[] GetFileContent(string file)
        {
            using (var text = File.OpenRead(file))
            using(var stream = new MemoryStream())
            {
                text.CopyTo(stream);
                return stream.ToArray();
            }
        }
        internal virtual void SaveFile(byte[] bytes, string fileName)
        {
            File.Delete(fileName);
            using (FileStream fs = new FileStream(fileName,FileMode.Append))
            {
                BinaryWriter bw = new BinaryWriter(fs);
                bw.Write(bytes);
                fs.Close();
            }
            
        }
    }
}
