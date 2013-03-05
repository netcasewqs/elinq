using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestInitialize = NUnit.Framework.SetUpAttribute;
using TestMethod = NUnit.Framework.TestAttribute;
using NLite.Data.Test.Primitive.Model;
using System.Linq.Expressions;
using System.ComponentModel;

namespace NLite.Data.Test.TypeConvert
{
    public class GuidConvertTest:TestBase<NullableTypeInfo>
    {
        protected override string ConnectionStringName
        {
            get
            {
                return "NumericDB";
            }
        }

        public virtual void Execute(string fieldName, object value, Expression<Func<NullableTypeInfo, bool>> filter)
        {
            var identityFieldValue = "zxmlx";
            var expected = new NullableTypeInfo { String = identityFieldValue };
            var field = typeof(NullableTypeInfo).GetField(fieldName);
            Assert.IsNotNull(field);
            field
                .SetValue(expected, PrimitiveMapper.Map(value, field.FieldType));

            //if (base.Db.Dialect is NLite.Data.Dialect.SQLiteDialect)
            //{
            //    base.Db.Connection.BeginTransaction();
            //}
            Table.Delete(p => true);
            Table.Insert(expected);

            var actual = Table
                .Where(p => p.String == expected.String)
                .Where(filter)
                .Select(p => new { Id = p.Id, p.String })
                .FirstOrDefault();

            Assert.IsNotNull(actual);

            Table.Delete(p => true);
        }
        
        Guid guid = new Guid("4A83D44A-5612-4E78-89EE-08F894912C0A");
        
        [TestMethod]
        //[NUnit.Framework.Ignore]
        public virtual void ToSString()
        {
            //Execute("Guid", guid, p => p.Guid.ToString() == "{4a83d44a-5612-4e78-89ee-08f894912c0a}");
            Execute("Guid", guid, p => p.Guid.ToString() == "4a83d44a-5612-4e78-89ee-08f894912c0a");
            Execute("Guid", guid, p => p.Guid.ToString() == "4a83d44a-5612-4e78-89ee-08f894912c0a".ToLower());
        }
        [TestMethod]
        //Sqlite:不相等
        [NUnit.Framework.Ignore]
        public virtual void ToByteArray()
        {
            Execute("Guid", guid, p => Convert.ChangeType(p.Guid, typeof(byte[])) == Convert.ChangeType(guid, typeof(byte[])));
        }
#if SDK4
        [TestMethod]
        //Access:不相等
        //Oracle:不相等
        //Sqlite:不相等
        public virtual void StringToGuid()
        {
            Table.Delete(p => true);
            string s = "4A83D44A-5612-4E78-89EE-08F894912C0A";
            var insert =Table.Insert(new NullableTypeInfo { String = s, Guid = Guid.Parse(s) });
            Assert.IsNotNull(insert);
            var item = Table.FirstOrDefault(p => Guid.Parse(p.String) == p.Guid);
            Assert.IsNotNull(item);
            Table.Delete(p => true);
        }
#endif
    }
}
