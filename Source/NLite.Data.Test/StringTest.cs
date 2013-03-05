using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestInitialize = NUnit.Framework.SetUpAttribute;
using TestMethod = NUnit.Framework.TestAttribute;
using NLite.Data.Test.Primitive.Model;
using NLite.Data.Test.Primitive;
using System.Linq.Expressions;
using System.Data.SqlClient;
using NLite.Data;

namespace NLite.Data.Test
{
    /// <summary>
    /// StringTest 的摘要说明
    /// </summary>
    [TestClass]
    public class StringTest : TestBase<UserInfo>
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

            var q = Table
              .Where(where)
              .Select(p => new { Id = p.userID, p.userName });

            var actual = q
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

        //[TestMethod]
        //public virtual void get_Chars()
        //{
        //    Excute("vance", p => p.descript[0]=='v');
        //}

        [TestMethod]
        public virtual void Concat()
        {
            var str = "vance";
            var expected = string.Concat(str, "info");
            Excute("vance", p => string.Concat(p.descript, "info") == expected);
            expected = string.Concat(str, "in", "fo");
            Excute("vance", p => string.Concat(p.descript, "in", "fo") == expected);
            expected = string.Concat(str, "i", "n", "fo");
            Excute("vance", p => string.Concat(p.descript, "i", "n", "fo") == expected);
            expected = string.Concat(str, str);
            Excute("vance", p => string.Concat(p.descript, p.descript) == expected);

            expected = string.Concat(str, 'i', 'n', "fo");
            Excute("vance", p => string.Concat(p.descript, 'i', 'n', "fo") == expected);
            expected = string.Concat(str, 1);
            Excute("vance", p => string.Concat(p.descript, 1) == expected);
            expected = string.Concat(str, true);
            Excute("vance", p => string.Concat(p.descript, true) == expected);
            expected = string.Concat(str, 1, true);
            Excute("vance", p => string.Concat(p.descript, 1, true) == expected);
            str = "ance";
            expected = string.Concat("v", str);
            Excute("ance", p => string.Concat("v", p.descript) ==expected);
            expected = string.Concat("v",str,1);
            Excute("ance", p => string.Concat("v", p.descript, 1) == expected);
            expected = string.Concat("v",str,1,false);
            Excute("ance", p => string.Concat("v", p.descript, 1, false) == expected);

            expected = "v" + str;
            Excute("ance", p => "v" + p.descript == expected);
            expected = "v" + str + 1;
            Excute("ance", p => "v" + p.descript + 1 == expected);
            expected = "v" + str + 1 + false;
            Excute("ance", p => "v" + p.descript + 1 + false == expected);
            str = "v";
            expected = str + "ance";
            Excute("v", p => p.descript + "ance" == expected);
            expected = str + "ance" + "Info";
            Excute("v", p => p.descript + "ance" + "Info" == expected);
            expected = str + "anc" + "e";
            Excute("v", p => p.descript + "anc" + 'e' == expected);
            str = "vance";
            expected = str + 1;
            Excute("vance", p => p.descript + 1 == expected);
            expected = str + true;
            Excute("vance", p => p.descript + true == expected);
            expected = str + 1 + true;
            Excute("vance", p => p.descript + 1 + true == expected);

            IEnumerable<string> items = new string[] { "1", "0", "1" }.AsEnumerable();
            expected = string.Concat(items) + str;
            Excute("vance", p => string.Concat(items) + p.descript == expected);
        }

        [TestMethod]
        public virtual void Contains()
        {
            Excute("jjkkdd", p => p.descript.Contains("jk"));
            Excute("vance", p => p.descript.Contains('v'));

            Excute("jk", p => "jjkkdd".Contains(p.descript));
            Excute("v", p => "vance".Contains(p.descript));
        }

        [TestMethod]
        public virtual void EndsWith()
        {

            Excute("vance", p => p.descript.EndsWith("ce"));
            Excute("vance", p => p.descript.EndsWith("ce", StringComparison.Ordinal));
            Excute("vance", p => p.descript.EndsWith("ce", StringComparison.CurrentCulture));
            Excute("vance", p => p.descript.EndsWith("ce", StringComparison.InvariantCulture));
#if    !SQLite
#if !MySQL && !Access
            Excute("vance", p => !p.descript.EndsWith("CE", StringComparison.Ordinal));
            Excute("vance", p => !p.descript.EndsWith("CE", StringComparison.CurrentCulture));
            Excute("vance", p => !p.descript.EndsWith("CE", StringComparison.InvariantCulture));
#endif

            Excute("vance", p => p.descript.EndsWith("CE", StringComparison.CurrentCultureIgnoreCase));
            Excute("vance", p => p.descript.EndsWith("CE", StringComparison.InvariantCultureIgnoreCase));
            Excute("vance", p => p.descript.EndsWith("CE", StringComparison.OrdinalIgnoreCase));
#if !Access && !MySQL
            Excute("vance", p => !p.descript.EndsWith("CE", false, System.Globalization.CultureInfo.CurrentCulture));
            Excute("vance", p => !p.descript.EndsWith("CE", false, System.Globalization.CultureInfo.CurrentUICulture));
            Excute("vance", p => !p.descript.EndsWith("CE", false, System.Globalization.CultureInfo.InstalledUICulture));
            Excute("vance", p => !p.descript.EndsWith("CE", false, System.Globalization.CultureInfo.InvariantCulture));

            Excute("CE", p => !"vance".EndsWith(p.descript, StringComparison.Ordinal));
            Excute("CE", p => !"vance".EndsWith(p.descript, StringComparison.CurrentCulture));
            Excute("CE", p => !"vance".EndsWith(p.descript, StringComparison.InvariantCulture));
#endif
            Excute("CE", p => "vance".EndsWith(p.descript, StringComparison.CurrentCultureIgnoreCase));
            Excute("CE", p => "vance".EndsWith(p.descript, StringComparison.InvariantCultureIgnoreCase));
            Excute("CE", p => "vance".EndsWith(p.descript, StringComparison.OrdinalIgnoreCase));

#if !Access &&!MySQL
            Excute("CE", p => !"vance".EndsWith(p.descript, false, System.Globalization.CultureInfo.CurrentCulture));
            Excute("CE", p => !"vance".EndsWith(p.descript, false, System.Globalization.CultureInfo.CurrentUICulture));
            Excute("CE", p => !"vance".EndsWith(p.descript, false, System.Globalization.CultureInfo.InstalledUICulture));
            Excute("CE", p => !"vance".EndsWith(p.descript, false, System.Globalization.CultureInfo.InvariantCulture));
#endif

#endif
            Excute("vance", p => p.descript.EndsWith("ce", StringComparison.CurrentCultureIgnoreCase));
            Excute("vance", p => p.descript.EndsWith("ce", StringComparison.InvariantCultureIgnoreCase));
            Excute("vance", p => p.descript.EndsWith("ce", StringComparison.OrdinalIgnoreCase));

            Excute("vance", p => p.descript.EndsWith("ce", true, System.Globalization.CultureInfo.CurrentCulture));
            Excute("vance", p => p.descript.EndsWith("ce", true, System.Globalization.CultureInfo.CurrentUICulture));
            Excute("vance", p => p.descript.EndsWith("ce", true, System.Globalization.CultureInfo.InstalledUICulture));
            Excute("vance", p => p.descript.EndsWith("ce", true, System.Globalization.CultureInfo.InvariantCulture));

            Excute("vance", p => p.descript.EndsWith("CE", true, System.Globalization.CultureInfo.CurrentCulture));
            Excute("vance", p => p.descript.EndsWith("CE", true, System.Globalization.CultureInfo.CurrentUICulture));
            Excute("vance", p => p.descript.EndsWith("CE", true, System.Globalization.CultureInfo.InstalledUICulture));
            Excute("vance", p => p.descript.EndsWith("CE", true, System.Globalization.CultureInfo.InvariantCulture));

            Excute("vance", p => p.descript.EndsWith("ce", false, System.Globalization.CultureInfo.CurrentCulture));
            Excute("vance", p => p.descript.EndsWith("ce", false, System.Globalization.CultureInfo.CurrentUICulture));
            Excute("vance", p => p.descript.EndsWith("ce", false, System.Globalization.CultureInfo.InstalledUICulture));
            Excute("vance", p => p.descript.EndsWith("ce", false, System.Globalization.CultureInfo.InvariantCulture));


            Excute("ce", p => "vance".EndsWith(p.descript));


            Excute("ce", p => "vance".EndsWith(p.descript, StringComparison.Ordinal));
            Excute("ce", p => "vance".EndsWith(p.descript, StringComparison.CurrentCulture));
            Excute("ce", p => "vance".EndsWith(p.descript, StringComparison.InvariantCulture));


            Excute("ce", p => "vance".EndsWith(p.descript, StringComparison.CurrentCultureIgnoreCase));
            Excute("ce", p => "vance".EndsWith(p.descript, StringComparison.InvariantCultureIgnoreCase));
            Excute("ce", p => "vance".EndsWith(p.descript, StringComparison.OrdinalIgnoreCase));

            Excute("ce", p => "vance".EndsWith(p.descript, true, System.Globalization.CultureInfo.CurrentCulture));
            Excute("ce", p => "vance".EndsWith(p.descript, true, System.Globalization.CultureInfo.CurrentUICulture));
            Excute("ce", p => "vance".EndsWith(p.descript, true, System.Globalization.CultureInfo.InstalledUICulture));
            Excute("ce", p => "vance".EndsWith(p.descript, true, System.Globalization.CultureInfo.InvariantCulture));

            Excute("CE", p => "vance".EndsWith(p.descript, true, System.Globalization.CultureInfo.CurrentCulture));
            Excute("CE", p => "vance".EndsWith(p.descript, true, System.Globalization.CultureInfo.CurrentUICulture));
            Excute("CE", p => "vance".EndsWith(p.descript, true, System.Globalization.CultureInfo.InstalledUICulture));
            Excute("CE", p => "vance".EndsWith(p.descript, true, System.Globalization.CultureInfo.InvariantCulture));

            Excute("ce", p => "vance".EndsWith(p.descript, false, System.Globalization.CultureInfo.CurrentCulture));
            Excute("ce", p => "vance".EndsWith(p.descript, false, System.Globalization.CultureInfo.CurrentUICulture));
            Excute("ce", p => "vance".EndsWith(p.descript, false, System.Globalization.CultureInfo.InstalledUICulture));
            Excute("ce", p => "vance".EndsWith(p.descript, false, System.Globalization.CultureInfo.InvariantCulture));


        }
        [TestMethod]
        public virtual void IndexOf()
        {
            var str = "vance";
            var expected = str.IndexOf('n');
            Excute("vance", p => p.descript.IndexOf('n') == expected);

            expected = str.IndexOf("nc");
            Excute("vance", p => p.descript.IndexOf("nc") == expected);
            expected = str.IndexOf("nc", 1);
            Excute("vance", p => p.descript.IndexOf("nc", 1) == expected);
            expected = str.IndexOf('n', 1);
            Excute("vance", p => p.descript.IndexOf('n', 1) == expected);
            expected = str.IndexOf('t');
            Excute("vance", p => p.descript.IndexOf('t') ==expected);
            expected = str.IndexOf("dddddd");
            Excute("vance", p => p.descript.IndexOf("dddddd") ==expected);
            expected = str.IndexOf('t', 0);
            Excute("vance", p => p.descript.IndexOf('t', 0)==expected);
            expected = str.IndexOf('t', 5);
            Excute("vance", p => p.descript.IndexOf('t', 5) ==expected);
            expected = str.IndexOf("dddddd",0);
            Excute("vance", p => p.descript.IndexOf("dddddd", 0) ==expected);
            expected = str.IndexOf("dddddd",5);
            Excute("vance", p => p.descript.IndexOf("dddddd", 5) ==expected);
            expected = str.IndexOf("nc",0);
            Excute("vance", p => p.descript.IndexOf("nc", 0) == expected);
            expected = str.IndexOf("nc", 3);
            Excute("vance", p => p.descript.IndexOf("nc", 3)==expected);
            expected = str.IndexOf("nc",4);
            Excute("vance", p => p.descript.IndexOf("nc", 4) ==expected);
            expected = str.IndexOf("nc",5);
            Excute("vance", p => p.descript.IndexOf("nc", 5) ==expected);
            expected = str.IndexOf('n', 0);
            Excute("vance", p => p.descript.IndexOf('n', 0) == expected);
            expected = str.IndexOf('n', 3);
            Excute("vance", p => p.descript.IndexOf('n', 3) ==expected);
            expected = str.IndexOf('n', 4);
            Excute("vance", p => p.descript.IndexOf('n', 4) ==expected);
            expected = str.IndexOf('n', 5);
            Excute("vance", p => p.descript.IndexOf('n', 5) ==expected);

            expected = "vance".IndexOf("n");
            Excute("n", p => "vance".IndexOf(p.descript) == expected);
            expected = "vance".IndexOf("nc");
            Excute("nc", p => "vance".IndexOf(p.descript) == expected);
            expected = "vance".IndexOf("nc",2);
            Excute("nc", p => "vance".IndexOf(p.descript, 1) == expected);
            expected = "vance".IndexOf("n", 2);
            Excute("n", p => "vance".IndexOf(p.descript, 2) == expected);

            expected = "vance".IndexOf("t");
            Excute("t", p => "vance".IndexOf(p.descript)==expected);
            expected = "vance".IndexOf("dddddd");
            Excute("dddddd", p => "vance".IndexOf(p.descript)==expected);
            expected = "vance".IndexOf("t",0);
            Excute("t", p => "vance".IndexOf(p.descript, 0) ==expected);
            expected = "vance".IndexOf("t", 5);
            Excute("t", p => "vance".IndexOf(p.descript, 5) ==expected);
            expected = "vance".IndexOf("dddddd",0);
            Excute("dddddd", p => "vance".IndexOf(p.descript, 0) ==expected);
            expected = "vance".IndexOf("dddddd", 5);
            Excute("dddddd", p => "vance".IndexOf(p.descript, 5) ==expected);
            expected = "vance".IndexOf("nc", 0);
            Excute("nc", p => "vance".IndexOf(p.descript, 0) == expected);
            expected = "vance".IndexOf("nc", 3);
            Excute("nc", p => "vance".IndexOf(p.descript, 3) ==expected);
            expected = "vance".IndexOf("nc", 4);
            Excute("nc", p => "vance".IndexOf(p.descript, 4) ==expected);
            expected = "vance".IndexOf("nc", 5);
            Excute("nc", p => "vance".IndexOf(p.descript, 5) ==expected);
            expected = "vance".IndexOf("n", 0);
            Excute("n", p => "vance".IndexOf(p.descript, 0) == expected);
            expected = "vance".IndexOf("n", 3);
            Excute("n", p => "vance".IndexOf(p.descript, 3) ==expected);
            expected = "vance".IndexOf("n", 4);
            Excute("n", p => "vance".IndexOf(p.descript, 4) ==expected);
            expected = "vance".IndexOf("n", 5);
            Excute("n", p => "vance".IndexOf(p.descript, 5) ==expected);

            expected = "vance".IndexOf("nc",0,StringComparison.Ordinal);
            Excute("nc", p => "vance".IndexOf(p.descript, 0, StringComparison.Ordinal) == expected);
            expected = "vance".IndexOf("nc", 5, StringComparison.Ordinal);
            Excute("nc", p => "vance".IndexOf(p.descript, 5, StringComparison.Ordinal) ==expected);
            expected = "vance".IndexOf("NC", 5, StringComparison.Ordinal);
            Excute("NC", p => "vance".IndexOf(p.descript, 5, StringComparison.Ordinal) ==expected);
            expected = "VANCE".IndexOf("NC", 0, StringComparison.Ordinal);
            Excute("NC", p => "VANCE".IndexOf(p.descript, 0, StringComparison.Ordinal) == expected);
            expected = "VANCE".IndexOf("NC", 5, StringComparison.Ordinal);
            Excute("NC", p => "VANCE".IndexOf(p.descript, 5, StringComparison.Ordinal) ==expected);
            expected = "VANCE".IndexOf("nc", 5, StringComparison.Ordinal);
            Excute("nc", p => "VANCE".IndexOf(p.descript, 5, StringComparison.Ordinal) ==expected);

            expected = "vance".IndexOf("nc", 0, StringComparison.CurrentCulture);
            Excute("nc", p => "vance".IndexOf(p.descript, 0, StringComparison.CurrentCulture) == expected);
            expected = "vance".IndexOf("nc", 5, StringComparison.CurrentCulture);
            Excute("nc", p => "vance".IndexOf(p.descript, 5, StringComparison.CurrentCulture) ==expected);
            expected = "vance".IndexOf("NC", 5, StringComparison.CurrentCulture);
            Excute("NC", p => "vance".IndexOf(p.descript, 5, StringComparison.CurrentCulture) ==expected);
            expected = "VANCE".IndexOf("NC", 0, StringComparison.CurrentCulture);
            Excute("NC", p => "VANCE".IndexOf(p.descript, 0, StringComparison.CurrentCulture) == expected);
            expected = "VANCE".IndexOf("NC", 5, StringComparison.CurrentCulture);
            Excute("NC", p => "VANCE".IndexOf(p.descript, 5, StringComparison.CurrentCulture) ==expected);
            expected = "VANCE".IndexOf("nc", 5, StringComparison.CurrentCulture);
            Excute("nc", p => "VANCE".IndexOf(p.descript, 5, StringComparison.CurrentCulture) ==expected);

            expected = "vance".IndexOf("nc", 0, StringComparison.InvariantCulture);
            Excute("nc", p => "vance".IndexOf(p.descript, 0, StringComparison.InvariantCulture) == expected);
            expected = "vance".IndexOf("nc", 5, StringComparison.InvariantCulture);
            Excute("nc", p => "vance".IndexOf(p.descript, 5, StringComparison.InvariantCulture) ==expected);
            expected = "vance".IndexOf("NC", 5, StringComparison.InvariantCulture);
            Excute("NC", p => "vance".IndexOf(p.descript, 5, StringComparison.InvariantCulture) ==expected);
            expected = "VANCE".IndexOf("NC", 0, StringComparison.InvariantCulture);
            Excute("NC", p => "VANCE".IndexOf(p.descript, 0, StringComparison.InvariantCulture) == expected);
            expected = "VANCE".IndexOf("NC", 5, StringComparison.InvariantCulture);
            Excute("NC", p => "VANCE".IndexOf(p.descript, 5, StringComparison.InvariantCulture) ==expected);
            expected = "VANCE".IndexOf("nc", 5, StringComparison.InvariantCulture);
            Excute("nc", p => "VANCE".IndexOf(p.descript, 5, StringComparison.InvariantCulture) ==expected);
#if SqlServer
            expected = "vance".IndexOf("NC", 0, StringComparison.Ordinal);
            Excute("NC", p => "vance".IndexOf(p.descript, 0, StringComparison.Ordinal) == expected);
            expected = "VANCE".IndexOf("nc", 0, StringComparison.Ordinal);
            Excute("nc", p => "VANCE".IndexOf(p.descript, 0, StringComparison.Ordinal) == expected);
            expected = "vance".IndexOf("NC", 0, StringComparison.CurrentCulture);
            Excute("NC", p => "vance".IndexOf(p.descript, 0, StringComparison.CurrentCulture) == expected);
            expected = "VANCE".IndexOf("nc", 0, StringComparison.CurrentCulture);
            Excute("nc", p => "VANCE".IndexOf(p.descript, 0, StringComparison.CurrentCulture) == expected);
            expected = "vance".IndexOf("NC", 0, StringComparison.CurrentCulture);
            Excute("NC", p => "vance".IndexOf(p.descript, 0, StringComparison.InvariantCulture) == expected);
            expected = "VANCE".IndexOf("nc", 0, StringComparison.CurrentCulture);
            Excute("nc", p => "VANCE".IndexOf(p.descript, 0, StringComparison.InvariantCulture) == expected);
#endif
            expected = "vance".IndexOf("nc", 0, StringComparison.CurrentCultureIgnoreCase);
            Excute("nc", p => "vance".IndexOf(p.descript, 0, StringComparison.CurrentCultureIgnoreCase) == expected);
            expected = "vance".IndexOf("nc", 5, StringComparison.CurrentCultureIgnoreCase);
            Excute("nc", p => "vance".IndexOf(p.descript, 5, StringComparison.CurrentCultureIgnoreCase) ==expected);
            expected = "vance".IndexOf("NC", 0, StringComparison.CurrentCultureIgnoreCase);
            Excute("NC", p => "vance".IndexOf(p.descript, 0, StringComparison.CurrentCultureIgnoreCase) == expected);
            expected = "vance".IndexOf("NC", 5, StringComparison.CurrentCultureIgnoreCase);
            Excute("NC", p => "vance".IndexOf(p.descript, 5, StringComparison.CurrentCultureIgnoreCase) ==expected);
            expected = "VANCE".IndexOf("NC", 0, StringComparison.CurrentCultureIgnoreCase);
            Excute("NC", p => "VANCE".IndexOf(p.descript, 0, StringComparison.CurrentCultureIgnoreCase) == expected);
            expected = "VANCE".IndexOf("NC", 5, StringComparison.CurrentCultureIgnoreCase);
            Excute("NC", p => "VANCE".IndexOf(p.descript, 5, StringComparison.CurrentCultureIgnoreCase) ==expected);
            expected = "VANCE".IndexOf("nc", 0, StringComparison.CurrentCultureIgnoreCase);
            Excute("nc", p => "VANCE".IndexOf(p.descript, 0, StringComparison.CurrentCultureIgnoreCase) == expected);
            expected = "VANCE".IndexOf("nc", 5, StringComparison.CurrentCultureIgnoreCase);
            Excute("nc", p => "VANCE".IndexOf(p.descript, 5, StringComparison.CurrentCultureIgnoreCase) ==expected);

            expected = "vance".IndexOf("nc", 0, StringComparison.InvariantCultureIgnoreCase);
            Excute("nc", p => "vance".IndexOf(p.descript, 0, StringComparison.InvariantCultureIgnoreCase) == expected);
            expected = "vance".IndexOf("nc", 5, StringComparison.InvariantCultureIgnoreCase);
            Excute("nc", p => "vance".IndexOf(p.descript, 5, StringComparison.InvariantCultureIgnoreCase) == expected);
            expected = "vance".IndexOf("NC", 0, StringComparison.InvariantCultureIgnoreCase);
            Excute("NC", p => "vance".IndexOf(p.descript, 0, StringComparison.InvariantCultureIgnoreCase) == expected);
            expected = "vance".IndexOf("NC", 5, StringComparison.InvariantCultureIgnoreCase);
            Excute("NC", p => "vance".IndexOf(p.descript, 5, StringComparison.InvariantCultureIgnoreCase) == expected);
            expected = "VANCE".IndexOf("NC", 0, StringComparison.InvariantCultureIgnoreCase);
            Excute("NC", p => "VANCE".IndexOf(p.descript, 0, StringComparison.InvariantCultureIgnoreCase) == expected);
            expected = "VANCE".IndexOf("NC", 5, StringComparison.InvariantCultureIgnoreCase);
            Excute("NC", p => "VANCE".IndexOf(p.descript, 5, StringComparison.InvariantCultureIgnoreCase) == expected);
            expected = "VANCE".IndexOf("nc", 0, StringComparison.InvariantCultureIgnoreCase);
            Excute("nc", p => "VANCE".IndexOf(p.descript, 0, StringComparison.InvariantCultureIgnoreCase) == expected);
            expected = "VANCE".IndexOf("nc", 5, StringComparison.InvariantCultureIgnoreCase);
            Excute("nc", p => "VANCE".IndexOf(p.descript, 5, StringComparison.InvariantCultureIgnoreCase) == expected);

            expected = "vance".IndexOf("nc", 0, StringComparison.OrdinalIgnoreCase);
            Excute("nc", p => "vance".IndexOf(p.descript, 0, StringComparison.OrdinalIgnoreCase) == expected);
            expected = "vance".IndexOf("nc", 5, StringComparison.OrdinalIgnoreCase);
            Excute("nc", p => "vance".IndexOf(p.descript, 5, StringComparison.OrdinalIgnoreCase) == expected);
            expected = "vance".IndexOf("NC", 0, StringComparison.OrdinalIgnoreCase);
            Excute("NC", p => "vance".IndexOf(p.descript, 0, StringComparison.OrdinalIgnoreCase) == expected);
            expected = "vance".IndexOf("NC", 5, StringComparison.OrdinalIgnoreCase);
            Excute("NC", p => "vance".IndexOf(p.descript, 5, StringComparison.OrdinalIgnoreCase) == expected);
            expected = "VANCE".IndexOf("NC", 0, StringComparison.OrdinalIgnoreCase);
            Excute("NC", p => "VANCE".IndexOf(p.descript, 0, StringComparison.OrdinalIgnoreCase) == expected);
            expected = "VANCE".IndexOf("NC", 5, StringComparison.OrdinalIgnoreCase);
            Excute("NC", p => "VANCE".IndexOf(p.descript, 5, StringComparison.OrdinalIgnoreCase) == expected);
            expected = "VANCE".IndexOf("nc", 0, StringComparison.OrdinalIgnoreCase);
            Excute("nc", p => "VANCE".IndexOf(p.descript, 0, StringComparison.OrdinalIgnoreCase) == expected);
            expected = "VANCE".IndexOf("nc", 5, StringComparison.OrdinalIgnoreCase);
            Excute("nc", p => "VANCE".IndexOf(p.descript, 5, StringComparison.OrdinalIgnoreCase) == expected);



            //Console.WriteLine("vance".IndexOf("n"));
            //Console.WriteLine("vance".IndexOf("n",0));
            //Console.WriteLine("vance".IndexOf("n", 1));
            //Console.WriteLine("vance".IndexOf("n", 1,2));
            //Console.WriteLine("vance".IndexOf("n", 1, 1));

            //Console.WriteLine("vance".IndexOf("", 3));
            //Console.WriteLine("vance".IndexOf(' ', 3));
            //Console.WriteLine("vance".IndexOf(default(char), 3));

            Console.WriteLine("vance".Substring(1,1));
           
            //Excute("n", p => "vance".IndexOf(p.descript, 1, 1) == -1);

            //Console.WriteLine("vance".IndexOf("", 6));
        }

        [TestMethod]
        public virtual void IsNullOrEmpty()
        {
            Excute("", p => p.descript.IsNullOrEmpty());
            Excute("vance", p => !p.descript.IsNullOrEmpty()); 
        }
#if MySQL ||Access||SqlCE||SqlServer||Oracle||SQLite
        [TestMethod]
        public virtual void IsNullOrWhiteSpace()
        {
            Excute("", p => string.IsNullOrWhiteSpace(p.descript));
            Excute("    ", p => string.IsNullOrWhiteSpace(p.descript));
            Excute("vance", p => !string.IsNullOrWhiteSpace(p.descript));//TODO
        }
#endif
#if !SqlCE
        [TestMethod]
        public virtual void LastIndexOf()
        {
            //string aa = "ancncevancevance";
            //Console.WriteLine(aa.LastIndexOf("nc", 4));
            //Excute("vancevance", p => p.descript.LastIndexOf('n') == 7);
            //Excute("vancevance", p => p.descript.LastIndexOf('t') != 7);
            var str = "vancevance";
            var expected = str.LastIndexOf('n',4);
#if !Oracle
            Excute("vancevance", p => p.descript.LastIndexOf('n', 4) == expected);
#endif
            expected = str.LastIndexOf('t', 6);
            Excute("vancevance", p => p.descript.LastIndexOf('t', 6) == expected);
            expected = str.LastIndexOf('n', 0);
            Excute("vancevance", p => p.descript.LastIndexOf('n', 0) == expected);
            expected = str.LastIndexOf('n', 9);
            Excute("vancevance", p => p.descript.LastIndexOf('n', 9) == expected);
            expected = str.LastIndexOf("n", 9);
            Excute("vancevance", p => p.descript.LastIndexOf("n", 9) == expected);
            //expected = str.LastIndexOf('n', 10);
            //Excute("vancevance", p => p.descript.LastIndexOf('n', 10) == expected);
            //expected = str.LastIndexOf('n', 15);
            //Excute("vancevance", p => p.descript.LastIndexOf('n', 15) == expected);

            expected = str.LastIndexOf("nc");
            Excute("vancevance", p => p.descript.LastIndexOf("nc") == expected);
            expected = str.LastIndexOf("nc", 4);
            Excute("vancevance", p => p.descript.LastIndexOf("nc", 4) == expected);
            expected = str.LastIndexOf("dddddd");
            Excute("vancevance", p => p.descript.LastIndexOf("dddddd") == expected);
            expected = str.LastIndexOf("dddddd", 6);
            Excute("vancevance", p => p.descript.LastIndexOf("dddddd", 6) == expected);
            expected = str.LastIndexOf("nc",0);
            Excute("vancevance", p => p.descript.LastIndexOf("nc", 0) == expected);
            expected = str.LastIndexOf("nc", 9);
            Excute("vancevance", p => p.descript.LastIndexOf("nc", 9) == expected);
            //expected = str.LastIndexOf("nc", 11);
            //Excute("vancevance", p => p.descript.LastIndexOf("nc", 11) == expected);
            //expected = str.LastIndexOf("nc", 15);
            //Excute("vancevance", p => p.descript.LastIndexOf("nc", 15) == expected);
            expected = str.LastIndexOf("n");
            Excute("n", p => "vancevance".LastIndexOf(p.descript) == expected);
            expected = str.LastIndexOf("nc");
            Excute("nc", p => "vancevance".LastIndexOf(p.descript) == expected);
            expected = str.LastIndexOf("n", 4);
            Excute("n", p => "vancevance".LastIndexOf(p.descript, 4) == expected);
            expected = str.LastIndexOf("nc", 4);
            Excute("nc", p => "vancevance".LastIndexOf(p.descript, 4) == expected);
            expected = str.LastIndexOf("t");
            Excute("t", p => "vancevance".LastIndexOf(p.descript) == expected);
            expected = str.LastIndexOf("dddddd");
            Excute("dddddd", p => "vancevance".LastIndexOf(p.descript) == expected);
            expected = str.LastIndexOf("t", 6);
            Excute("t", p => "vancevance".LastIndexOf(p.descript, 6) == expected);
            expected = str.LastIndexOf("dddddd", 6);
            Excute("dddddd", p => "vancevance".LastIndexOf(p.descript, 6) == expected);
            expected = str.LastIndexOf("nc", 0);
            Excute("nc", p => "vancevance".LastIndexOf(p.descript, 0) == expected);
            expected = str.LastIndexOf("nc", 9);
            Excute("nc", p => "vancevance".LastIndexOf(p.descript, 9) == expected);
            //expected = str.LastIndexOf("nc", 10);
            //Excute("nc", p => "vancevance".LastIndexOf(p.descript, 10) == expected);
            //expected = str.LastIndexOf("nc", 15);
            Excute("nc", p => "vancevance".LastIndexOf(p.descript, 15) == -1);
            expected = str.LastIndexOf("n", 0);
            Excute("n", p => "vancevance".LastIndexOf(p.descript, 0) == expected);
            expected = str.LastIndexOf("n", 6);
            Excute("n", p => "vancevance".LastIndexOf(p.descript, 6) == expected);
            //expected = str.LastIndexOf("n", 10);
            //Excute("n", p => "vancevance".LastIndexOf(p.descript, 10) == expected);
            //expected = str.LastIndexOf("n", 15);
            //Excute("n", p => "vancevance".LastIndexOf(p.descript, 15) == expected);
        }
#endif
        [TestMethod]
        public virtual void Length()
        {
            var str = "vance";
            var expected = str.Length;
            Excute("vance", p => p.descript.Length == expected);
           
#if Access || SQLite || MySQL || Oracle

            expected = "  ".Length;
            Excute("  ", p => p.descript.Length == expected);

#elif Access || SQLite || MySQL ||SqlServer|| SqlCE||Oracle

            expected = "".Length;
            Excute("", p => p.descript.Length ==expected);

#elif SqlServer|| SqlCE
            expected = "  ".Length;
            Excute("  ", p => p.descript.Length == expected);
#endif
        }
#if !SqlCE
        [TestMethod]
        public virtual void LeftOf()
        {
            var str = "vance";
            var expected = str.LeftOf('n');
            Excute("vance", p => p.descript.LeftOf('n') == expected);
            expected = str.LeftOf("nc");
            Excute("vance", p => p.descript.LeftOf("nc") == expected);
            expected = str.LeftOf("n");
            Excute("n", p => "vance".LeftOf(p.descript) == expected);
            expected = str.LeftOf("nc");
            Excute("nc", p => "vance".LeftOf(p.descript) == expected);
        }
#endif
#if !SqlCE
        [TestMethod]
        public virtual void RightOf()
        {
            var str = "vance";
            var expected = str.RightOf("an");
            Excute("vance", p => p.descript.RightOf("an") == expected);
            expected = "vancnne".RightOf('n');
            Excute("vancnne", p => p.descript.RightOf('n') == expected);
#if Oracle
            Excute("", p => p.descript.RightOf('n') == null);
            Excute("", p => p.descript.RightOf("") == null);
            Excute("", p => p.descript.RightOf("an") == null);
            Excute("vance", p => p.descript.RightOf("") == null);
#else
            //expected = str.RightOf("");
            Excute("vance", p => p.descript.RightOf("")!=null);
            //expected = "".RightOf('n');
            Excute("", p => p.descript.RightOf('n') == "");
            //expected = "".RightOf("");
            Excute("", p => p.descript.RightOf("") == "");
            //expected = "".RightOf("an");
            Excute("", p => p.descript.RightOf("an") == "");
#endif
            expected = str.RightOf("an");
            Excute("an", p => "vance".RightOf(p.descript) == expected);
            expected = "vancnne".RightOf("n");
            Excute("n", p => "vancnne".RightOf(p.descript) == expected);         
        }
#endif
        [TestMethod]
        public virtual void PadLeft()
        {
            var str = "vance";
            var expected = str.PadLeft(8);
            Excute("vance", p => p.descript.PadLeft(8) ==expected);
            expected = str.PadLeft(8,'*');
            Excute("vance", p => p.descript.PadLeft(8, '*') == expected);
#if Oracle
            Excute("", p => p.descript.PadLeft(8) == null);
            Excute("", p => p.descript.PadLeft(8, '*') == null);

#else
            expected = "".PadLeft(8);
            Excute("", p => p.descript.PadLeft(8) ==expected);
            expected = "".PadLeft(8, '*');
            Excute("", p => p.descript.PadLeft(8, '*') == expected);
#endif
        }

        [TestMethod]
        public virtual void PadRight()
        {
            var str = "vance";
            var expected = str.PadRight(8);
            Excute("vance", p => p.descript.PadRight(8) == expected);
            expected = str.PadRight(8, '&');
            Excute("vance", p => p.descript.PadRight(8, '&') == expected);
#if Oracle
            Excute("", p => p.descript.PadRight(8) == null);
            Excute("", p => p.descript.PadRight(8, '*') == null);
#else
            expected = "".PadRight(8);
            Excute("", p => p.descript.PadRight(8) == expected);
            expected = "".PadRight(8, '*');
            Excute("", p => p.descript.PadRight(8, '*') ==expected);
#endif
        }

        [TestMethod]
        public virtual void Remove()
        {
            var str = "vance";
            var expected = str.Remove(0);
#if Oracle
            //TODO:Bug
            Excute("vance", p => p.descript.Remove(0) == null);
            //expected = str.Remove(5);
            ExcuteNull("vance", p => p.descript.Remove(5) == null);
            //expected = str.Remove(6,7);
            ExcuteNull("vance", p => p.descript.Remove(6, 7) == null);
#else
            expected = str.Remove(0);
            Excute("vance", p => p.descript.Remove(0) == expected);
            //expected = str.Remove(5);
            Excute("vance", p => p.descript.Remove(5) == null);
            //expected = str.Remove(6,7);
            Excute("vance", p => p.descript.Remove(6, 7) == null);
#endif
            expected = str.Remove(1);
            Excute("vance", p => p.descript.Remove(1) == expected);
            expected = str.Remove(1,3);
            Excute("vance", p => p.descript.Remove(1, 3) == expected);
            expected = str.Remove(4);
            Excute("vance", p => p.descript.Remove(4) == expected);

            expected = str.Remove(1,0);
            Excute("vance", p => p.descript.Remove(1, 0) == expected);
            expected = str.Remove(1,4);
            Excute("vance", p => p.descript.Remove(1, 4) == expected);
            //TODO:.net方法使用错误，翻译到数据库中：可以
            //expected = str.Remove(1,7);
            Excute("vance", p => p.descript.Remove(1, 7) == "v");
            
        }

        [TestMethod]
        public virtual void Replace()
        {
            var str = "vancecc";
            var expected = str.Replace('c', 'a');
            Excute("vancecc", p => p.descript.Replace('c', 'a') == expected);
            expected = str.Replace("cc", "dd");
            Excute("vancecc", p => p.descript.Replace("cc", "dd") == expected);
            Excute("cc", p => "vancecc".Replace(p.descript, "dd") == expected);
            Excute("dd", p => "vancecc".Replace("cc", p.descript) == expected);
        }

        [TestMethod]
        public virtual void StartsWith()
        {

            Excute("vance", p => p.descript.StartsWith("va"));
            Excute("va", p => "vance".StartsWith(p.descript));
        }
        [TestMethod]
        public virtual void Substring()
        {
            var str = "vance";
            var expected = str.Substring(2);
            Excute("vance", p => p.descript.Substring(2) == expected);
            expected = str.Substring(2,2);
            Excute("vance", p => p.descript.Substring(2, 2) == expected);
            expected = str.Substring(0);
            Excute("vance", p => p.descript.Substring(0) == expected);

            expected = str.Substring(0,2);
            Excute("vance", p => p.descript.Substring(0, 2) == expected);
#if Access || SQLite || MySQL || SqlServer || SqlCE
            //expected = str.Substring(6,2);
            Excute("vance", p => p.descript.Substring(6, 2) != null);
#elif Oracle
            //expected = str.Substring(6);
            Excute("vance", p => p.descript.Substring(6) == null);
            //expected = str.Substring(6,2);
            Excute("vance", p => p.descript.Substring(6, 2) == null);

#endif
            expected = str.Substring(1,4);
            Excute("vance", p => p.descript.Substring(1, 4) == expected);
            //TODO:.net索引超出长度，翻译到数据库中能拿到数据
            //expected = str.Substring(1,5);
            Excute("vance", p => p.descript.Substring(1, 5) == "ance");
        }

        [TestMethod]
        public virtual void ToLower()
        {
            var str = "VANCE";
            var expected = str.ToLower();
            Excute("VANCE", p => p.descript.ToLower() == expected);
#if Oracle
            //expected = "".ToLower();
            Excute("", p => p.descript.ToLower() == null);
#else
            expected = "".ToLower();
            Excute("", p => p.descript.ToLower() == expected);
#endif
            expected = " ".ToLower();
            Excute(" ", p => p.descript.ToLower() ==expected);
        }
        [TestMethod]
        public virtual void ToUpper()
        {
            var str = "vance";
            var expected = str.ToUpper();
            Excute("vance", p => p.descript.ToUpper() == expected);
#if Oracle
            //expected = "".ToUpper();
            Excute("", p => p.descript.ToUpper() == null);
#else
            expected = "".ToUpper();
            Excute("", p => p.descript.ToUpper() == expected);
#endif
        }
        [TestMethod]
        public virtual void Trim()
        {
            var str = "  vance  ";
            var expected = str.Trim();
            Excute(str, p => p.descript.Trim() ==expected);
#if Oracle
            //expected = "".Trim();
            Excute("", p => p.descript.Trim() ==null);
#else
            expected = "".Trim();
            Excute("", p => p.descript.Trim() == expected);
#endif
        }
        [TestMethod]
        public virtual void TrimEnd()
        {
            var str = "  vance  ";
            var expected = str.TrimEnd();
            Excute(str, p => p.descript.TrimEnd() == expected);
            expected = str.TrimEnd(' ');
            Excute(str, p => p.descript.TrimEnd(' ') == expected);
#if Oracle
            //expected = "".TrimEnd();
            Excute("", p => p.descript.TrimEnd() == null);
            //expected = str.TrimEnd(' ');
            Excute("", p => p.descript.TrimEnd(' ') == null);
#else
            expected = "".TrimEnd();
            Excute("", p => p.descript.TrimEnd() == expected);
            expected = "".TrimEnd(' ');
            Excute("", p => p.descript.TrimEnd(' ') == expected);
#endif
        }

        [TestMethod]
        public virtual void TrimStart()
        {
            var str = "  vance  ";
            var expected = str.TrimStart();
            Excute(str, p => p.descript.TrimStart() == expected);
            expected = str.TrimStart(' ');
            Excute(str, p => p.descript.TrimStart(' ') == expected);
#if Oracle
            //expected = "".TrimStart();
            Excute("", p => p.descript.TrimStart() == null);
            //expected = "".TrimStart(' ');
            Excute("", p => p.descript.TrimStart(' ') == null);
#else
            expected = "".TrimStart(' ');
            Excute("", p => p.descript.TrimStart(' ') == expected);
            expected = "".TrimStart();
            Excute("", p => p.descript.TrimStart() == expected);
#endif
        }

        [TestMethod]
        public virtual void Insert()
        {
            var str = "vance";
            var expected = str.Insert(4,"info");

            Excute(str, p => p.descript.Insert(4, "info") == expected);
            expected = str.Insert(0, "info");
            Excute("vance", p => p.descript.Insert(0, "info") == expected);
            //expected = str.Insert(6, "info");
            Excute("vance", p => p.descript.Insert(6, "info") == null);
            expected = str.Insert(4, "info");
            Excute("info", p => str.Insert(4, p.descript) == expected);
            expected = str.Insert(0, "info");
            Excute("info", p => str.Insert(0, p.descript) == expected);
            //expected = str.Insert(6, "info");
            Excute("info", p => str.Insert(6, p.descript) == null);

        }
#if !SqlCE
        [TestMethod]
        public virtual void Reverse()
        {
            var str = "vance";var str1 = "";
            var expected = str.Reverse().ToArray();
            for (int i = 0; i < expected.Count(); i++)
            {
                str1 += Convert.ToString(expected[i]);
            }
            Excute(str, p => p.descript.Reverse().ToString() == str1);
#if Access || SQLite || MySQL || SqlServer
            //expected = "".Reverse().ToString();
            Excute("", p => p.descript.Reverse().ToString() =="");
#elif Oracle
            Excute("", p => p.descript.Reverse().ToString() == null);
#endif
        }
#endif       
    }
}
