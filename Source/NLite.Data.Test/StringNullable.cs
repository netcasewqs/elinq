using System;
using System.Collections.Generic;
using NUnit.Framework;
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestInitialize = NUnit.Framework.SetUpAttribute;
using TestMethod = NUnit.Framework.TestAttribute;
using System.Linq;
using System.Text;
using NLite.Data.Test.Primitive.Model;
using NLite.Data.Test.Primitive;
using System.Linq.Expressions;
using System.Data.SqlClient;
using NLite.Data;
namespace NLite.Data.Test
{
    [TestClass]
    public class StringNullable : TestBase<UserInfo>
    {
        protected override string ConnectionStringName
        {
            get
            {
                return "StringTestDB";
            }
        }
        protected void Excute(string descript, Expression<Func<UserInfo, bool>> where)
        {
            Table.Delete(p => true);
            var expected = new UserInfo { userName = "vanceinfo", descript = descript, createTime = Convert.ToDateTime("2010-10-1") };
            Table.Insert(expected);

            var actual = Table
              .Where(where)
              .Select(p => new { Id = p.userID, p.userName })
              .FirstOrDefault();
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.userName, actual.userName);
            Table.Delete(p => true);
        }

        protected void ExcuteNull(string descript, Expression<Func<UserInfo, bool>> where)
        {
            Table.Delete(p => true);
            var expected = new UserInfo { userName = "vanceinfo", descript = descript, createTime = Convert.ToDateTime("2010-10-1") };
            Table.Insert(expected);

            var actual = Table
              .Where(where)
              .Select(p => new { Id = p.userID, p.userName })
              .FirstOrDefault();
            Assert.IsNull(actual);
            Table.Delete(p => true);
        }

        [TestMethod]
        public virtual void Concat()
        {
            Excute(null, p => string.Concat(p.descript, p.descript) == null);
            Excute(null, p => string.Concat(p.descript, null) == null);
            Excute(null, p => string.Concat(null, p.descript, null) == null);
            Excute(null, p => null + p.descript + null == null);
#if Oracle
            Excute("vance", p => string.Concat(p.descript, null) == "vance");
            Excute("vance", p => string.Concat(null, p.descript, null) == "vance");
            Excute("vance", p => p.descript + null == "vance");
            Excute("vance", p => null + p.descript + null == "vance");
#elif !SqlCE&&!SqlCE_SDK3_5
            ExcuteNull("vance", p => string.Concat(p.descript, null) == "vance");
            ExcuteNull("vance", p => string.Concat(null, p.descript, null) == "vance");
            ExcuteNull("vance", p => p.descript + null == "vance");
            ExcuteNull("vance", p => null + p.descript + null == "vance");
#endif
        }

        [TestMethod]
        public virtual void Contains()
        {
            ExcuteNull(null, p => p.descript.Contains("jk"));
#if Oracle
            Excute(null, p => "vance".Contains(p.descript));
#else
            ExcuteNull(null, p => "vance".Contains(p.descript));
#endif
            ExcuteNull("vance", p => p.descript.Contains(null));
            ExcuteNull(null, p => p.descript.Contains(null));

        }

        [TestMethod]
        public virtual void EndsWith()
        {
            //ExcuteNull("vance", p => !p.descript.EndsWith(null));
            ExcuteNull(null, p => !p.descript.EndsWith("ce"));
            ExcuteNull(null, p => p.descript.EndsWith(null));
            ExcuteNull("vance", p => p.descript.EndsWith(null));
#if Access || SQLite || MySQL || SqlServer || SqlCE
            ExcuteNull(null, p => "vance".EndsWith(p.descript));
            ExcuteNull(null, p => "vance".EndsWith(p.descript, StringComparison.Ordinal));
            ExcuteNull(null, p => "vance".EndsWith(p.descript, StringComparison.CurrentCulture));
            ExcuteNull(null, p => "vance".EndsWith(p.descript, StringComparison.InvariantCulture));

            ExcuteNull(null, p => "vance".EndsWith(p.descript, StringComparison.CurrentCultureIgnoreCase));
            ExcuteNull(null, p => "vance".EndsWith(p.descript, StringComparison.InvariantCultureIgnoreCase));
            ExcuteNull(null, p => "vance".EndsWith(p.descript, StringComparison.OrdinalIgnoreCase));

            ExcuteNull(null, p => "vance".EndsWith(p.descript, true, System.Globalization.CultureInfo.CurrentCulture));
            ExcuteNull(null, p => "vance".EndsWith(p.descript, true, System.Globalization.CultureInfo.CurrentUICulture));
            ExcuteNull(null, p => "vance".EndsWith(p.descript, true, System.Globalization.CultureInfo.InstalledUICulture));
            ExcuteNull(null, p => "vance".EndsWith(p.descript, true, System.Globalization.CultureInfo.InvariantCulture));
            

            ExcuteNull(null, p => "vance".EndsWith(p.descript, false, System.Globalization.CultureInfo.CurrentCulture));
            ExcuteNull(null, p => "vance".EndsWith(p.descript, false, System.Globalization.CultureInfo.CurrentUICulture));
            ExcuteNull(null, p => "vance".EndsWith(p.descript, false, System.Globalization.CultureInfo.InstalledUICulture));
            ExcuteNull(null, p => "vance".EndsWith(p.descript, false, System.Globalization.CultureInfo.InvariantCulture));
#elif Oracle
            Excute(null, p => "vance".EndsWith(p.descript));
            Excute(null, p => "vance".EndsWith(p.descript, StringComparison.Ordinal));
            Excute(null, p => "vance".EndsWith(p.descript, StringComparison.CurrentCulture));
            Excute(null, p => "vance".EndsWith(p.descript, StringComparison.InvariantCulture));

            Excute(null, p => "vance".EndsWith(p.descript, StringComparison.CurrentCultureIgnoreCase));
            Excute(null, p => "vance".EndsWith(p.descript, StringComparison.InvariantCultureIgnoreCase));
            Excute(null, p => "vance".EndsWith(p.descript, StringComparison.OrdinalIgnoreCase));

            Excute(null, p => "vance".EndsWith(p.descript, true, System.Globalization.CultureInfo.CurrentCulture));
            Excute(null, p => "vance".EndsWith(p.descript, true, System.Globalization.CultureInfo.CurrentUICulture));
            Excute(null, p => "vance".EndsWith(p.descript, true, System.Globalization.CultureInfo.InstalledUICulture));
            Excute(null, p => "vance".EndsWith(p.descript, true, System.Globalization.CultureInfo.InvariantCulture));



            Excute(null, p => "vance".EndsWith(p.descript, false, System.Globalization.CultureInfo.CurrentCulture));
            Excute(null, p => "vance".EndsWith(p.descript, false, System.Globalization.CultureInfo.CurrentUICulture));
            Excute(null, p => "vance".EndsWith(p.descript, false, System.Globalization.CultureInfo.InstalledUICulture));
            Excute(null, p => "vance".EndsWith(p.descript, false, System.Globalization.CultureInfo.InvariantCulture));
#endif
        }
        [TestMethod]
        public virtual void IndexOf()
        {
            ExcuteNull(null, p => p.descript.IndexOf('n') != 2);
            ExcuteNull(null, p => p.descript.IndexOf('n', 1) != 2);
            ExcuteNull(null, p => p.descript.IndexOf("nc") != 2);
            ExcuteNull(null, p => p.descript.IndexOf("nc", 1) != 2);
#if Access || SQLite || MySQL || SqlServer || Oracle
            ExcuteNull("vance", p => p.descript.IndexOf(null) != 2);
            ExcuteNull("vance", p => p.descript.IndexOf(null, 1) != 2);
            ExcuteNull(null, p => p.descript.IndexOf(null) != 2);
            ExcuteNull(null, p => p.descript.IndexOf(null, 1) != 2);

#if Access || SQLite || SqlServer || Oracle
            Excute(null, p => p.descript.IndexOf('n') == null);
            Excute(null, p => p.descript.IndexOf('n', 1) == null);
            Excute(null, p => p.descript.IndexOf("nc") == null);
            Excute(null, p => p.descript.IndexOf("nc", 1) == null);
            Excute("vance", p => p.descript.IndexOf(null) == null);
            Excute("vance", p => p.descript.IndexOf(null, 1) == null);
            Excute(null, p => p.descript.IndexOf(null) == null);
            Excute(null, p => p.descript.IndexOf(null, 1) == null);

            Excute("vance", p => p.descript.IndexOf(null) == null);
            Excute("vance", p => p.descript.IndexOf(null, 0) == null);
            Excute("vance", p => p.descript.IndexOf(null, 3) == null);
            Excute("vance", p => p.descript.IndexOf(null, 4) == null);
            Excute("vance", p => p.descript.IndexOf(null, 5) == null);

            Excute(null, p => "vance".IndexOf(p.descript) == null);
            Excute(null, p => "vance".IndexOf(p.descript, 1) == null);
            Excute(null, p => "vance".IndexOf(p.descript, 0) == null);
            Excute(null, p => "vance".IndexOf(p.descript, 3) == null);
            Excute(null, p => "vance".IndexOf(p.descript, 4) == null);
            Excute(null, p => "vance".IndexOf(p.descript, 5) == null);

#endif

            ExcuteNull("vance", p => p.descript.IndexOf(null) != 2);
            ExcuteNull("vance", p => p.descript.IndexOf(null, 0) != 2);
            ExcuteNull("vance", p => p.descript.IndexOf(null, 3) != 2);
            ExcuteNull("vance", p => p.descript.IndexOf(null, 4) != 2);
            ExcuteNull("vance", p => p.descript.IndexOf(null, 5) != 2);

            ExcuteNull(null, p => "vance".IndexOf(p.descript) != 2);
            ExcuteNull(null, p => "vance".IndexOf(p.descript, 1) != 2);
            ExcuteNull(null, p => "vance".IndexOf(p.descript, 0) != 2);
            ExcuteNull(null, p => "vance".IndexOf(p.descript, 5) != 2);
            ExcuteNull(null, p => "vance".IndexOf(p.descript, 3) != 2);
            ExcuteNull(null, p => "vance".IndexOf(p.descript, 4) != 2);
            
#endif
        }

        [TestMethod]
        public virtual void IsNullOrEmpty()
        {
            Excute(null, p => p.descript.IsNullOrEmpty());
        }
#if SDK4
        [TestMethod]
        public virtual void IsNullOrWhiteSpace()
        {
            Excute(null, p => string.IsNullOrWhiteSpace(p.descript));
        }
#endif
#if Access || SQLite || MySQL || SqlServer 
        [TestMethod]
        public virtual void LastIndexOf()
        {
#if  SQLite || MySQL || SqlServer 
            ExcuteNull(null, p => p.descript.LastIndexOf('n') != -1);
            ExcuteNull(null, p => p.descript.LastIndexOf('n', 9) != -1);
            ExcuteNull(null, p => p.descript.LastIndexOf("nc") != -1);
            ExcuteNull(null, p => p.descript.LastIndexOf("nc", 9) != -1);
            ExcuteNull(null, p => p.descript.LastIndexOf(null) != -1);
            ExcuteNull(null, p => p.descript.LastIndexOf(null, 1) != -1);

            Excute(null, p => p.descript.LastIndexOf('n') == null);
            Excute(null, p => p.descript.LastIndexOf('n', 9) == null);
            Excute(null, p => p.descript.LastIndexOf("nc") == null);
            Excute(null, p => p.descript.LastIndexOf("nc", 9) == null);
            Excute(null, p => p.descript.LastIndexOf(null) == null);
            Excute(null, p => p.descript.LastIndexOf(null, 1) == null);

            ExcuteNull("vancevance", p => p.descript.LastIndexOf(null) != -1);
            ExcuteNull("vancevance", p => p.descript.LastIndexOf(null, 6) != -1);
            ExcuteNull("vancevance", p => p.descript.LastIndexOf(null, 0) != -1);
            ExcuteNull("vancevance", p => p.descript.LastIndexOf(null, 9) != -1);
            ExcuteNull("vancevance", p => p.descript.LastIndexOf(null, 10) != -1);
            ExcuteNull("vancevance", p => p.descript.LastIndexOf(null, 15) != -1);

            Excute("vancevance", p => p.descript.LastIndexOf(null) == null);
            Excute("vancevance", p => p.descript.LastIndexOf(null, 6) == null);
            Excute("vancevance", p => p.descript.LastIndexOf(null, 0) == null);
            Excute("vancevance", p => p.descript.LastIndexOf(null, 9) == null);
            Excute("vancevance", p => p.descript.LastIndexOf(null, 10) == -1);
            Excute("vancevance", p => p.descript.LastIndexOf(null, 15) == -1);

            ExcuteNull(null, p => "vancevance".LastIndexOf(p.descript) != -1);
            ExcuteNull(null, p => "vancevance".LastIndexOf(p.descript, 4) != -1);
            ExcuteNull(null, p => "vancevance".LastIndexOf(p.descript, 6) != -1);
            ExcuteNull(null, p => "vancevance".LastIndexOf(p.descript, 0) != -1);
            ExcuteNull(null, p => "vancevance".LastIndexOf(p.descript, 9) != -1);
            ExcuteNull(null, p => "vancevance".LastIndexOf(p.descript, 10) != -1);
            ExcuteNull(null, p => "vancevance".LastIndexOf(p.descript, 15) != -1);

            Excute(null, p => "vancevance".LastIndexOf(p.descript) == null);
            Excute(null, p => "vancevance".LastIndexOf(p.descript, 4) == null);
            Excute(null, p => "vancevance".LastIndexOf(p.descript, 6) == null);
            Excute(null, p => "vancevance".LastIndexOf(p.descript, 0) == null);
            Excute(null, p => "vancevance".LastIndexOf(p.descript, 9) == null);
            Excute(null, p => "vancevance".LastIndexOf(p.descript, 10) == -1);
            Excute(null, p => "vancevance".LastIndexOf(p.descript, 15) == -1);
#endif
        }
#endif
        [TestMethod]
        public virtual void Length()
        {
            ExcuteNull(null, p => p.descript.Length == 5);
        }
#if Access || SQLite || MySQL || SqlServer || Oracle
        [TestMethod]
        public virtual void Left()
        {
            
#if  SQLite || MySQL || SqlServer ||Oracle
            ExcuteNull(null, p => p.descript.LeftOf('n') != "va");
            ExcuteNull(null, p => p.descript.LeftOf("nc") != "va");
            ExcuteNull(null, p => p.descript != null && p.descript.LeftOf('n') != "va");
#if  SQLite || SqlServer || Oracle
            ExcuteNull(null, p => "vance".LeftOf(p.descript) != "va");
            ExcuteNull("vance", p => p.descript.LeftOf(null) != "va");
#else
            Excute(null, p => "vance".LeftOf(p.descript) != "va");
            Excute("vance", p => p.descript.LeftOf(null) != "va");
#endif
            ExcuteNull(null, p => p.descript.LeftOf(null) != "va");
            ExcuteNull("vance", p => p.descript.LeftOf(null) == "va");
#endif



        }
#endif
#if Access || SQLite || MySQL || SqlServer || Oracle
        [TestMethod]
        public virtual void Right()
        {
            //public  string RightOf(char value, int n);
            // public  string RightOf(string value, int n);
           

#if  SQLite || MySQL || SqlServer || Oracle
            ExcuteNull(null, p => p.descript.RightOf("an") != "ce");
            ExcuteNull("vance", p => p.descript.RightOf(null) == "ce");
#if  SQLite || SqlServer || Oracle
            ExcuteNull("vance", p => p.descript.RightOf(null) != "cnne");

            ExcuteNull(null, p => "vance".RightOf(p.descript) != "ce");
            ExcuteNull(null, p => "vancnne".RightOf(p.descript) != "cnne");
            
#else
            Excute(null, p => "vance".RightOf(p.descript) != "ce");
            Excute(null, p => "vancnne".RightOf(p.descript) != "cnne");
            Excute("vance", p => p.descript.RightOf(null) != "cnne");
#endif
            ExcuteNull(null, p => p.descript.RightOf('n') != "cnne");
            ExcuteNull(null, p => p.descript.RightOf(null) != "cnne");
#endif
        }
#endif
        [TestMethod]
        public virtual void PadLeft()
        {
#if SQLite || MySQL || SqlServer || SqlCE || Oracle
            ExcuteNull(null, p => p.descript.PadLeft(8) == "        ");
            ExcuteNull(null, p => p.descript.PadLeft(8, '*') == "********");
            Excute(null, p => p.descript.PadLeft(8) == null);
            Excute(null, p => p.descript.PadLeft(8, '*') == null);
#endif
        }

        [TestMethod]
        public virtual void PadRight()
        {
#if SQLite || MySQL || SqlServer || SqlCE || Oracle
            ExcuteNull(null, p => p.descript.PadRight(8) == "        ");
            ExcuteNull(null, p => p.descript.PadRight(8, '*') == "********");
            Excute(null, p => p.descript.PadRight(8) == null);
            Excute(null, p => p.descript.PadRight(8, '*') == null);
#endif
        }

        [TestMethod]
        public virtual void Remove()
        {
#if SQLite || MySQL || SqlServer || SqlCE || Oracle
            ExcuteNull(null, p => p.descript.Remove(1) != "v");
            ExcuteNull(null, p => p.descript.Remove(1, 3) != "ve");

            Excute(null, p => p.descript.Remove(1) == null);
            Excute(null, p => p.descript.Remove(1, 3) == null);
#endif
        }

        [TestMethod]
        public virtual void Replace()
        {
#if SQLite || MySQL || SqlServer || SqlCE || Oracle
            ExcuteNull("vancecc", p => p.descript.Replace(null, "dd") != "vancecc");

            ExcuteNull(null, p => p.descript.Replace('c', 'a') != "vanaeaa");
            ExcuteNull(null, p => p.descript.Replace("cc", "dd") != "vancedd");
            ExcuteNull(null, p => p.descript.Replace('c', 'a') != "vanaeaa");
            ExcuteNull(null, p => p.descript.Replace("cc", null) != "vancedd");
            ExcuteNull(null, p => p.descript.Replace(null, "dd") != "vancedd");
            ExcuteNull(null, p => p.descript.Replace(null, null) != "vancedd");


            Excute(null, p => p.descript.Replace('c', 'a') == null);
            Excute(null, p => p.descript.Replace("cc", "dd") == null);
            Excute(null, p => p.descript.Replace('c', 'a') == null);
            Excute(null, p => p.descript.Replace("cc", null) == null);
            Excute(null, p => p.descript.Replace(null, "dd") == null);
            Excute(null, p => p.descript.Replace(null, null) == null);
#if Oracle
            Excute("vancecc", p => p.descript.Replace("cc", null) == "vance");
            Excute("vancecc", p => p.descript.Replace(null, "dd") == "vancecc");
            
            Excute(null, p => "vancecc".Replace(p.descript, "dd") == "vancecc");
            Excute(null, p => "vancecc".Replace("cc", p.descript) == "vance");
            Excute(null, p => "vancecc".Replace(p.descript, null) == "vancecc");
            Excute(null, p => "vancecc".Replace(null, p.descript) == "vancecc");
            
#else
            ExcuteNull("vancecc", p => p.descript.Replace("cc", null) != "vancedd");
            Excute("vancecc", p => p.descript.Replace(null, "dd") == null);
            Excute("vancecc", p => p.descript.Replace("cc", null) == null);
            ExcuteNull(null, p => "vancecc".Replace(p.descript, "dd") != "vancedd");
            ExcuteNull(null, p => "vancecc".Replace("cc", p.descript) != "vancedd");
            ExcuteNull(null, p => "vancecc".Replace(p.descript, null) != "vancedd");
            ExcuteNull(null, p => "vancecc".Replace(null, p.descript) != "vancedd");

            Excute(null, p => "vancecc".Replace(p.descript, "dd") == null);
            Excute(null, p => "vancecc".Replace("cc", p.descript) == null);
            Excute(null, p => "vancecc".Replace(p.descript, null) == null);
            Excute(null, p => "vancecc".Replace(null, p.descript) == null);
#endif
#endif
        }

        [TestMethod]
        public virtual void StartsWith()
        {
            ExcuteNull(null, p => p.descript.StartsWith("va"));
            ExcuteNull(null, p => p.descript.StartsWith(null));
            ExcuteNull("vance", p => p.descript.StartsWith(null));
        }
        [TestMethod]
        public virtual void Substring()
        {
            Excute(null, p => p.descript.Substring(2) == null);
            ExcuteNull(null, p => p.descript.Substring(2) != "nce");
            Excute(null, p => p.descript.Substring(2, 2) == null);
            ExcuteNull(null, p => p.descript.Substring(2, 2) != "nc");
        }

        [TestMethod]
        public virtual void ToLower()
        {
            ExcuteNull(null, p => p.descript.ToLower() != "vance");
            Excute(null, p => p.descript.ToLower() == null);
        }
        [TestMethod]
        public virtual void ToUpper()
        {
            ExcuteNull(null, p => p.descript.ToUpper() != "VANCE");
            Excute(null, p => p.descript.ToUpper() == null);
        }
        [TestMethod]
        public virtual void Trim()
        {
            ExcuteNull(null, p => p.descript.Trim() != "vance");
            Excute(null, p => p.descript.Trim() == null);
        }
        [TestMethod]
        public virtual void TrimEnd()
        {
            ExcuteNull(null, p => p.descript.TrimEnd() != "vance");
            Excute(null, p => p.descript.TrimEnd() == null);
            ExcuteNull(null, p => p.descript.TrimEnd(' ') != "vance");
            Excute(null, p => p.descript.TrimEnd(' ') == null);
        }

        [TestMethod]
        public virtual void TrimStart()
        {
            ExcuteNull(null, p => p.descript.TrimStart() != "vance");
            Excute(null, p => p.descript.TrimStart() == null);
            ExcuteNull(null, p => p.descript.TrimStart(' ') != "vance");
            Excute(null, p => p.descript.TrimStart(' ') == null);
        }

        [TestMethod]
        public virtual void Insert()
        {
#if Access || SQLite || MySQL || SqlServer 
            ExcuteNull(null, p => p.descript.Insert(4, null) != "vancinfoe");
            ExcuteNull("vance", p => p.descript.Insert(4, null) != "vance");
            Excute("vance", p => p.descript.Insert(4, null) == null);
#endif
            Excute(null, p => p.descript.Insert(4, null) == null);
#if Oracle
            ExcuteNull(null, p => p.descript.Insert(4, null) != "vancinfoe");
            ExcuteNull("vance", p => p.descript.Insert(4, null) != "vance");
            Excute("vance", p => p.descript.Insert(4, null) == "vance");
            ExcuteNull(null, p => "vance".Insert(4, p.descript) == null);
            ExcuteNull(null, p => "vance".Insert(0, p.descript) == null);
            Excute(null, p => "vance".Insert(4, p.descript) != null);
            Excute(null, p => "vance".Insert(0, p.descript) != null);
            
#else
            ExcuteNull(null, p => "vance".Insert(4, p.descript) != "vancinfoe");
            ExcuteNull(null, p => "vance".Insert(0, p.descript) != "infovance");
            ExcuteNull(null, p => "vance".Insert(6, p.descript) != "vancinfoe");
            Excute(null, p => "vance".Insert(4, p.descript) == null);
            Excute(null, p => "vance".Insert(0, p.descript) == null);
#endif

            Excute(null, p => "vance".Insert(6, p.descript) == null);
        }
#if Access || SQLite || MySQL || SqlServer || Oracle
        [TestMethod]
        public virtual void Reverse()
        {
#if SQLite || MySQL || SqlServer||Oracle
            ExcuteNull(null, p => p.descript.Reverse().ToString() != "ecnav");
            Excute(null, p => p.descript.Reverse().ToString() == null);
#endif
        }
#endif
    }
}
