using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLite.Data.Test.Primitive.Model;

namespace NLite.Data.Test.Primitive
{
    public class TestConvertVoid
    {
        protected IConnection Connection;
        protected virtual string ConnectionStringName
        {
            get { return "mysqlTest"; }
        }
        public TestConvertVoid()
        {
            Connection = DriverManager.OpenConnection(ConnectionStringName);


        }
        ~TestConvertVoid()
        {
            Connection.Dispose();
        }

        #region   ToBoolean
        /// <summary>
        /// ToBoolean
        /// </summary>
        /// <param name="nColumn"></param>
        public void ToBoolean(string nColumn)
        {

            var converter = System.ComponentModel.TypeDescriptor.GetConverter(typeof(Boolean));
            switch (nColumn)
            {

                case "Boolean":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Boolean.HasValue && (Boolean)converter.ConvertFrom(p.Boolean) == true)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Boolean.HasValue && (Boolean)Convert.ChangeType(p.Boolean, typeof(Boolean)) == true)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Boolean.HasValue && Boolean.Parse(p.Boolean.ToString()) == true)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Byte":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Byte.HasValue && (Boolean)converter.ConvertFrom(p.Byte) == true)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Byte.HasValue && (Boolean)Convert.ChangeType(p.Byte, typeof(Boolean)) == true)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Byte.HasValue && Boolean.Parse(p.Byte.ToString()) == true)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Binary":
                    Connection.ExecuteReader<NullableTypeInfo>(p => (Boolean)converter.ConvertFrom(p.Binary) == true)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => (Boolean)Convert.ChangeType(p.Binary, typeof(Boolean)) == true)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => Boolean.Parse(p.Binary.ToString()) == true)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Char":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Char.HasValue && (Boolean)converter.ConvertFrom(p.Char) == true)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Char.HasValue && (Boolean)Convert.ChangeType(p.Char, typeof(Boolean)) == true)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Char.HasValue && Boolean.Parse(p.Char.ToString()) == true)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "DateTime":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.DateTime.HasValue && (Boolean)converter.ConvertFrom(p.DateTime) == true)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.DateTime.HasValue && (Boolean)Convert.ChangeType(p.DateTime, typeof(Boolean)) == true)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.DateTime.HasValue && Boolean.Parse(p.DateTime.ToString()) == true)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Decimal":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Decimal.HasValue && (Boolean)converter.ConvertFrom(p.Decimal) == true)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Decimal.HasValue && (Boolean)Convert.ChangeType(p.Decimal, typeof(Boolean)) == true)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Decimal.HasValue && Boolean.Parse(p.Decimal.ToString()) == true)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Double":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Double.HasValue && (Boolean)converter.ConvertFrom(p.Double) == true)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Double.HasValue && (Boolean)Convert.ChangeType(p.Double, typeof(Boolean)) == true)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Double.HasValue && Boolean.Parse(p.Double.ToString()) == true)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Int16":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int16.HasValue && (Boolean)converter.ConvertFrom(p.Int16) == true)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int16.HasValue && (Boolean)Convert.ChangeType(p.Int16, typeof(Boolean)) == true)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int16.HasValue && Boolean.Parse(p.Int16.ToString()) == true)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Int32":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int32.HasValue && (Boolean)converter.ConvertFrom(p.Int32) == true)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int32.HasValue && (Boolean)Convert.ChangeType(p.Int32, typeof(Boolean)) == true)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int32.HasValue && Boolean.Parse(p.Int32.ToString()) == true)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Int64":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int64.HasValue && (Boolean)converter.ConvertFrom(p.Int64) == true)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int64.HasValue && (Boolean)Convert.ChangeType(p.Int64, typeof(Boolean)) == true)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int64.HasValue && Boolean.Parse(p.Int64.ToString()) == true)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "SByte":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.SByte.HasValue && (Boolean)converter.ConvertFrom(p.SByte) == true)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.SByte.HasValue && (Boolean)Convert.ChangeType(p.SByte, typeof(Boolean)) == true)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.SByte.HasValue && Boolean.Parse(p.SByte.ToString()) == true)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Single":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Single.HasValue && (Boolean)converter.ConvertFrom(p.Single) == true)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Single.HasValue && (Boolean)Convert.ChangeType(p.Single, typeof(Boolean)) == true)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Single.HasValue && Boolean.Parse(p.Single.ToString()) == true)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "String":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.String.Length > 0 && (Boolean)converter.ConvertFrom(p.String) == true)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.String.Length > 0 && (Boolean)Convert.ChangeType(p.String, typeof(Boolean)) == true)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.String.Length > 0 && Boolean.Parse(p.String.ToString()) == true)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "UInt16":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt16.HasValue && (Boolean)converter.ConvertFrom(p.UInt16) == true)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt16.HasValue && (Boolean)Convert.ChangeType(p.UInt16, typeof(Boolean)) == true)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt16.HasValue && Boolean.Parse(p.UInt16.ToString()) == true)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "UInt32":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt32.HasValue && (Boolean)converter.ConvertFrom(p.UInt32) == true)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt32.HasValue && (Boolean)Convert.ChangeType(p.UInt32, typeof(Boolean)) == true)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt32.HasValue && Boolean.Parse(p.UInt32.ToString()) == true)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "UInt64":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt64.HasValue && (Boolean)converter.ConvertFrom(p.UInt64) == true)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt64.HasValue && (Boolean)Convert.ChangeType(p.UInt64, typeof(Boolean)) == true)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt64.HasValue && Boolean.Parse(p.UInt64.ToString()) == true)
                        .ToDataTable().WriteXml(Console.Out);
                    break;

            }
        }
        #endregion

        #region ToChar
        public void ToChar(string nColumn,char m)
        {
            var converter = System.ComponentModel.TypeDescriptor.GetConverter(typeof(Char));
            switch (nColumn)
            {
                case "Boolean":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Boolean.HasValue && (Char)converter.ConvertFrom(p.Boolean) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Boolean.HasValue && (Char)Convert.ChangeType(p.Boolean, typeof(Char)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Boolean.HasValue && Char.Parse(p.Boolean.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Byte":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Byte.HasValue && (Char)converter.ConvertFrom(p.Byte) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Byte.HasValue && (Char)Convert.ChangeType(p.Byte, typeof(Char)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Byte.HasValue && Char.Parse(p.Byte.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Binary":
                    Connection.ExecuteReader<NullableTypeInfo>(p => (Char)converter.ConvertFrom(p.Binary) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => (Char)Convert.ChangeType(p.Binary, typeof(Char)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => Char.Parse(p.Binary.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Char":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Char.HasValue && (Char)converter.ConvertFrom(p.Char) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Char.HasValue && (Char)Convert.ChangeType(p.Char, typeof(Char)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Char.HasValue && Char.Parse(p.Char.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "DateTime":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.DateTime.HasValue && (Char)converter.ConvertFrom(p.DateTime) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.DateTime.HasValue && (Char)Convert.ChangeType(p.DateTime, typeof(Char)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.DateTime.HasValue && Char.Parse(p.DateTime.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Decimal":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Decimal.HasValue && (Char)converter.ConvertFrom(p.Decimal) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Decimal.HasValue && (Char)Convert.ChangeType(p.Decimal, typeof(Char)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Decimal.HasValue && Char.Parse(p.Decimal.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Double":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Double.HasValue && (Char)converter.ConvertFrom(p.Double) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Double.HasValue && (Char)Convert.ChangeType(p.Double, typeof(Char)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Double.HasValue && Char.Parse(p.Double.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Int16":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int16.HasValue && (Char)converter.ConvertFrom(p.Int16) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int16.HasValue && (Char)Convert.ChangeType(p.Int16, typeof(Char)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int16.HasValue && Char.Parse(p.Int16.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Int32":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int32.HasValue && (Char)converter.ConvertFrom(p.Int32) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int32.HasValue && (Char)Convert.ChangeType(p.Int32, typeof(Char)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int32.HasValue && Char.Parse(p.Int32.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Int64":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int64.HasValue && (Char)converter.ConvertFrom(p.Int64) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int64.HasValue && (Char)Convert.ChangeType(p.Int64, typeof(Char)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int64.HasValue && Char.Parse(p.Int64.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "SByte":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.SByte.HasValue && (Char)converter.ConvertFrom(p.SByte) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.SByte.HasValue && (Char)Convert.ChangeType(p.SByte, typeof(Char)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.SByte.HasValue && Char.Parse(p.SByte.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Single":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Single.HasValue && (Char)converter.ConvertFrom(p.Single) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Single.HasValue && (Char)Convert.ChangeType(p.Single, typeof(Char)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Single.HasValue && Char.Parse(p.Single.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "String":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.String.Length > 0 && (Char)converter.ConvertFrom(p.String) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.String.Length > 0 && (Char)Convert.ChangeType(p.String, typeof(Char)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.String.Length > 0 && Char.Parse(p.String.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "UInt16":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt16.HasValue && (Char)converter.ConvertFrom(p.UInt16) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt16.HasValue && (Char)Convert.ChangeType(p.UInt16, typeof(Char)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt16.HasValue && Char.Parse(p.UInt16.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "UInt32":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt32.HasValue && (Char)converter.ConvertFrom(p.UInt32) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt32.HasValue && (Char)Convert.ChangeType(p.UInt32, typeof(Char)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt32.HasValue && Char.Parse(p.UInt32.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "UInt64":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt64.HasValue && (Char)converter.ConvertFrom(p.UInt64) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt64.HasValue && (Char)Convert.ChangeType(p.UInt64, typeof(Char)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt64.HasValue && Char.Parse(p.UInt64.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;

            }

        }
        #endregion

        #region ToSByte
        public void ToSByte(string nColumn,sbyte m)
        {
            var converter = System.ComponentModel.TypeDescriptor.GetConverter(typeof(SByte));
            switch (nColumn)
            {
                case "Boolean":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Boolean.HasValue && (SByte)converter.ConvertFrom(p.Boolean) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Boolean.HasValue && (SByte)Convert.ChangeType(p.Boolean, typeof(SByte)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Boolean.HasValue && SByte.Parse(p.Boolean.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Byte":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Byte.HasValue && (SByte)converter.ConvertFrom(p.Byte) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Byte.HasValue && (SByte)Convert.ChangeType(p.Byte, typeof(SByte)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Byte.HasValue && SByte.Parse(p.Byte.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Binary":
                    Connection.ExecuteReader<NullableTypeInfo>(p => (SByte)converter.ConvertFrom(p.Binary) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => (SByte)Convert.ChangeType(p.Binary, typeof(SByte)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => SByte.Parse(p.Binary.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Char":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Char.HasValue && (SByte)converter.ConvertFrom(p.Char) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Char.HasValue && (SByte)Convert.ChangeType(p.Char, typeof(SByte)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Char.HasValue && SByte.Parse(p.Char.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "DateTime":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.DateTime.HasValue && (SByte)converter.ConvertFrom(p.DateTime) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.DateTime.HasValue && (SByte)Convert.ChangeType(p.DateTime, typeof(SByte)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.DateTime.HasValue && SByte.Parse(p.DateTime.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Decimal":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Decimal.HasValue && (SByte)converter.ConvertFrom(p.Decimal) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Decimal.HasValue && (SByte)Convert.ChangeType(p.Decimal, typeof(SByte)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Decimal.HasValue && SByte.Parse(p.Decimal.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Double":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Double.HasValue && (SByte)converter.ConvertFrom(p.Double) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Double.HasValue && (SByte)Convert.ChangeType(p.Double, typeof(SByte)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Double.HasValue && SByte.Parse(p.Double.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Int16":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int16.HasValue && (SByte)converter.ConvertFrom(p.Int16) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int16.HasValue && (SByte)Convert.ChangeType(p.Int16, typeof(SByte)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int16.HasValue && SByte.Parse(p.Int16.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Int32":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int32.HasValue && (SByte)converter.ConvertFrom(p.Int32) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int32.HasValue && (SByte)Convert.ChangeType(p.Int32, typeof(SByte)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int32.HasValue && SByte.Parse(p.Int32.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Int64":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int64.HasValue && (SByte)converter.ConvertFrom(p.Int64) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int64.HasValue && (SByte)Convert.ChangeType(p.Int64, typeof(SByte)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int64.HasValue && SByte.Parse(p.Int64.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "SByte":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.SByte.HasValue && (SByte)converter.ConvertFrom(p.SByte) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.SByte.HasValue && (SByte)Convert.ChangeType(p.SByte, typeof(SByte)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.SByte.HasValue && SByte.Parse(p.SByte.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Single":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Single.HasValue && (SByte)converter.ConvertFrom(p.Single) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Single.HasValue && (SByte)Convert.ChangeType(p.Single, typeof(SByte)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Single.HasValue && SByte.Parse(p.Single.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "String":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.String.Length > 0 && (SByte)converter.ConvertFrom(p.String) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.String.Length > 0 && (SByte)Convert.ChangeType(p.String, typeof(SByte)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.String.Length > 0 && SByte.Parse(p.String.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "UInt16":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt16.HasValue && (SByte)converter.ConvertFrom(p.UInt16) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt16.HasValue && (SByte)Convert.ChangeType(p.UInt16, typeof(SByte)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt16.HasValue && SByte.Parse(p.UInt16.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "UInt32":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt32.HasValue && (SByte)converter.ConvertFrom(p.UInt32) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt32.HasValue && (SByte)Convert.ChangeType(p.UInt32, typeof(SByte)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt32.HasValue && SByte.Parse(p.UInt32.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "UInt64":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt64.HasValue && (SByte)converter.ConvertFrom(p.UInt64) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt64.HasValue && (SByte)Convert.ChangeType(p.UInt64, typeof(SByte)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt64.HasValue && SByte.Parse(p.UInt64.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;

            }

        }
        #endregion

        #region ToByte
        public void ToByte(string nColumn,byte m)
        {
            var converter = System.ComponentModel.TypeDescriptor.GetConverter(typeof(Byte));
            switch (nColumn)
            {
                case "Boolean":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Boolean.HasValue && (Byte)converter.ConvertFrom(p.Boolean) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Boolean.HasValue && (Byte)Convert.ChangeType(p.Boolean, typeof(Byte)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Boolean.HasValue && Byte.Parse(p.Boolean.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Byte":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Byte.HasValue && (Byte)converter.ConvertFrom(p.Byte) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Byte.HasValue && (Byte)Convert.ChangeType(p.Byte, typeof(Byte)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Byte.HasValue && Byte.Parse(p.Byte.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Binary":
                    Connection.ExecuteReader<NullableTypeInfo>(p => (Byte)converter.ConvertFrom(p.Binary) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => (Byte)Convert.ChangeType(p.Binary, typeof(Byte)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => Byte.Parse(p.Binary.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Char":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Char.HasValue && (Byte)converter.ConvertFrom(p.Char) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Char.HasValue && (Byte)Convert.ChangeType(p.Char, typeof(Byte)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Char.HasValue && Byte.Parse(p.Char.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "DateTime":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.DateTime.HasValue && (Byte)converter.ConvertFrom(p.DateTime) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.DateTime.HasValue && (Byte)Convert.ChangeType(p.DateTime, typeof(Byte)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.DateTime.HasValue && Byte.Parse(p.DateTime.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Decimal":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Decimal.HasValue && (Byte)converter.ConvertFrom(p.Decimal) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Decimal.HasValue && (Byte)Convert.ChangeType(p.Decimal, typeof(Byte)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Decimal.HasValue && Byte.Parse(p.Decimal.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Double":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Double.HasValue && (Byte)converter.ConvertFrom(p.Double) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Double.HasValue && (Byte)Convert.ChangeType(p.Double, typeof(Byte)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Double.HasValue && Byte.Parse(p.Double.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Int16":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int16.HasValue && (Byte)converter.ConvertFrom(p.Int16) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int16.HasValue && (Byte)Convert.ChangeType(p.Int16, typeof(Byte)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int16.HasValue && Byte.Parse(p.Int16.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Int32":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int32.HasValue && (Byte)converter.ConvertFrom(p.Int32) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int32.HasValue && (Byte)Convert.ChangeType(p.Int32, typeof(Byte)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int32.HasValue && Byte.Parse(p.Int32.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Int64":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int64.HasValue && (Byte)converter.ConvertFrom(p.Int64) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int64.HasValue && (Byte)Convert.ChangeType(p.Int64, typeof(Byte)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int64.HasValue && Byte.Parse(p.Int64.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "SByte":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.SByte.HasValue && (Byte)converter.ConvertFrom(p.SByte) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.SByte.HasValue && (Byte)Convert.ChangeType(p.SByte, typeof(Byte)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.SByte.HasValue && Byte.Parse(p.SByte.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Single":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Single.HasValue && (Byte)converter.ConvertFrom(p.Single) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Single.HasValue && (Byte)Convert.ChangeType(p.Single, typeof(Byte)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Single.HasValue && Byte.Parse(p.Single.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "String":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.String.Length > 0 && (Byte)converter.ConvertFrom(p.String) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.String.Length > 0 && (Byte)Convert.ChangeType(p.String, typeof(Byte)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.String.Length > 0 && Byte.Parse(p.String.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "UInt16":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt16.HasValue && (Byte)converter.ConvertFrom(p.UInt16) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt16.HasValue && (Byte)Convert.ChangeType(p.UInt16, typeof(Byte)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt16.HasValue && Byte.Parse(p.UInt16.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "UInt32":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt32.HasValue && (Byte)converter.ConvertFrom(p.UInt32) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt32.HasValue && (Byte)Convert.ChangeType(p.UInt32, typeof(Byte)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt32.HasValue && Byte.Parse(p.UInt32.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "UInt64":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt64.HasValue && (Byte)converter.ConvertFrom(p.UInt64) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt64.HasValue && (Byte)Convert.ChangeType(p.UInt64, typeof(Byte)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt64.HasValue && Byte.Parse(p.UInt64.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;

            }

        }
        #endregion

        #region  ToInt16
        public void ToInt16(string nColumn,Int16 m)
        {
            var converter = System.ComponentModel.TypeDescriptor.GetConverter(typeof(Int16));
            switch (nColumn)
            {
                case "Boolean":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Boolean.HasValue && (Int16)converter.ConvertFrom(p.Boolean) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Boolean.HasValue && (Int16)Convert.ChangeType(p.Boolean, typeof(Int16)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Boolean.HasValue && Int16.Parse(p.Boolean.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Byte":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Byte.HasValue && (Int16)converter.ConvertFrom(p.Byte) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Byte.HasValue && (Int16)Convert.ChangeType(p.Byte, typeof(Int16)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Byte.HasValue && Int16.Parse(p.Byte.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Binary":
                    Connection.ExecuteReader<NullableTypeInfo>(p => (Int16)converter.ConvertFrom(p.Binary) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => (Int16)Convert.ChangeType(p.Binary, typeof(Int16)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => Int16.Parse(p.Binary.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Char":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Char.HasValue && (Int16)converter.ConvertFrom(p.Char) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Char.HasValue && (Int16)Convert.ChangeType(p.Char, typeof(Int16)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Char.HasValue && Int16.Parse(p.Char.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "DateTime":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.DateTime.HasValue && (Int16)converter.ConvertFrom(p.DateTime) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.DateTime.HasValue && (Int16)Convert.ChangeType(p.DateTime, typeof(Int16)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.DateTime.HasValue && Int16.Parse(p.DateTime.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Decimal":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Decimal.HasValue && (Int16)converter.ConvertFrom(p.Decimal) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Decimal.HasValue && (Int16)Convert.ChangeType(p.Decimal, typeof(Int16)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Decimal.HasValue && Int16.Parse(p.Decimal.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Double":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Double.HasValue && (Int16)converter.ConvertFrom(p.Double) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Double.HasValue && (Int16)Convert.ChangeType(p.Double, typeof(Int16)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Double.HasValue && Int16.Parse(p.Double.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Int16":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int16.HasValue && (Int16)converter.ConvertFrom(p.Int16) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int16.HasValue && (Int16)Convert.ChangeType(p.Int16, typeof(Int16)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int16.HasValue && Int16.Parse(p.Int16.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Int32":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int32.HasValue && (Int16)converter.ConvertFrom(p.Int32) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int32.HasValue && (Int16)Convert.ChangeType(p.Int32, typeof(Int16)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int32.HasValue && Int16.Parse(p.Int32.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Int64":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int64.HasValue && (Int16)converter.ConvertFrom(p.Int64) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int64.HasValue && (Int16)Convert.ChangeType(p.Int64, typeof(Int16)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int64.HasValue && Int16.Parse(p.Int64.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "SByte":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.SByte.HasValue && (Int16)converter.ConvertFrom(p.SByte) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.SByte.HasValue && (Int16)Convert.ChangeType(p.SByte, typeof(Int16)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.SByte.HasValue && Int16.Parse(p.SByte.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Single":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Single.HasValue && (Int16)converter.ConvertFrom(p.Single) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Single.HasValue && (Int16)Convert.ChangeType(p.Single, typeof(Int16)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Single.HasValue && Int16.Parse(p.Single.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "String":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.String.Length > 0 && (Int16)converter.ConvertFrom(p.String) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.String.Length > 0 && (Int16)Convert.ChangeType(p.String, typeof(Int16)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.String.Length > 0 && Int16.Parse(p.String.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "UInt16":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt16.HasValue && (Int16)converter.ConvertFrom(p.UInt16) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt16.HasValue && (Int16)Convert.ChangeType(p.UInt16, typeof(Int16)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt16.HasValue && Int16.Parse(p.UInt16.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "UInt32":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt32.HasValue && (Int16)converter.ConvertFrom(p.UInt32) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt32.HasValue && (Int16)Convert.ChangeType(p.UInt32, typeof(Int16)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt32.HasValue && Int16.Parse(p.UInt32.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "UInt64":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt64.HasValue && (Int16)converter.ConvertFrom(p.UInt64) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt64.HasValue && (Int16)Convert.ChangeType(p.UInt64, typeof(Int16)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt64.HasValue && Int16.Parse(p.UInt64.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;

            }

        }
        #endregion

        #region  ToUInt16
        public void ToUInt16(string nColumn,UInt16 m)
        {
            var converter = System.ComponentModel.TypeDescriptor.GetConverter(typeof(UInt16));
            switch (nColumn)
            {
                case "Boolean":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Boolean.HasValue && (UInt16)converter.ConvertFrom(p.Boolean) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Boolean.HasValue && (UInt16)Convert.ChangeType(p.Boolean, typeof(UInt16)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Boolean.HasValue && UInt16.Parse(p.Boolean.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Byte":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Byte.HasValue && (UInt16)converter.ConvertFrom(p.Byte) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Byte.HasValue && (UInt16)Convert.ChangeType(p.Byte, typeof(UInt16)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Byte.HasValue && UInt16.Parse(p.Byte.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Binary":
                    Connection.ExecuteReader<NullableTypeInfo>(p => (UInt16)converter.ConvertFrom(p.Binary) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => (UInt16)Convert.ChangeType(p.Binary, typeof(UInt16)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => UInt16.Parse(p.Binary.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Char":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Char.HasValue && (UInt16)converter.ConvertFrom(p.Char) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Char.HasValue && (UInt16)Convert.ChangeType(p.Char, typeof(UInt16)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Char.HasValue && UInt16.Parse(p.Char.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "DateTime":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.DateTime.HasValue && (UInt16)converter.ConvertFrom(p.DateTime) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.DateTime.HasValue && (UInt16)Convert.ChangeType(p.DateTime, typeof(UInt16)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.DateTime.HasValue && UInt16.Parse(p.DateTime.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Decimal":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Decimal.HasValue && (UInt16)converter.ConvertFrom(p.Decimal) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Decimal.HasValue && (UInt16)Convert.ChangeType(p.Decimal, typeof(UInt16)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Decimal.HasValue && UInt16.Parse(p.Decimal.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Double":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Double.HasValue && (UInt16)converter.ConvertFrom(p.Double) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Double.HasValue && (UInt16)Convert.ChangeType(p.Double, typeof(UInt16)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Double.HasValue && UInt16.Parse(p.Double.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Int16":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int16.HasValue && (UInt16)converter.ConvertFrom(p.Int16) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int16.HasValue && (UInt16)Convert.ChangeType(p.Int16, typeof(UInt16)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int16.HasValue && UInt16.Parse(p.Int16.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Int32":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int32.HasValue && (UInt16)converter.ConvertFrom(p.Int32) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int32.HasValue && (UInt16)Convert.ChangeType(p.Int32, typeof(UInt16)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int32.HasValue && UInt16.Parse(p.Int32.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Int64":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int64.HasValue && (UInt16)converter.ConvertFrom(p.Int64) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int64.HasValue && (UInt16)Convert.ChangeType(p.Int64, typeof(UInt16)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int64.HasValue && UInt16.Parse(p.Int64.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "SByte":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.SByte.HasValue && (UInt16)converter.ConvertFrom(p.SByte) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.SByte.HasValue && (UInt16)Convert.ChangeType(p.SByte, typeof(UInt16)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.SByte.HasValue && UInt16.Parse(p.SByte.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Single":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Single.HasValue && (UInt16)converter.ConvertFrom(p.Single) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Single.HasValue && (UInt16)Convert.ChangeType(p.Single, typeof(UInt16)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Single.HasValue && UInt16.Parse(p.Single.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "String":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.String.Length > 0 && (UInt16)converter.ConvertFrom(p.String) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.String.Length > 0 && (UInt16)Convert.ChangeType(p.String, typeof(UInt16)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.String.Length > 0 && UInt16.Parse(p.String.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "UInt16":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt16.HasValue && (UInt16)converter.ConvertFrom(p.UInt16) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt16.HasValue && (UInt16)Convert.ChangeType(p.UInt16, typeof(UInt16)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt16.HasValue && UInt16.Parse(p.UInt16.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "UInt32":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt32.HasValue && (UInt16)converter.ConvertFrom(p.UInt32) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt32.HasValue && (UInt16)Convert.ChangeType(p.UInt32, typeof(UInt16)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt32.HasValue && UInt16.Parse(p.UInt32.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "UInt64":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt64.HasValue && (UInt16)converter.ConvertFrom(p.UInt64) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt64.HasValue && (UInt16)Convert.ChangeType(p.UInt64, typeof(UInt16)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt64.HasValue && UInt16.Parse(p.UInt64.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;

            }

        }
        #endregion

        #region  ToInt32
        public void ToInt32(string nColumn,Int32 m)
        {
            var converter = System.ComponentModel.TypeDescriptor.GetConverter(typeof(Int32));
            switch (nColumn)
            {
                case "Boolean":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Boolean.HasValue && (Int32)converter.ConvertFrom(p.Boolean) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Boolean.HasValue && (Int32)Convert.ChangeType(p.Boolean, typeof(Int32)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Boolean.HasValue && Int32.Parse(p.Boolean.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Byte":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Byte.HasValue && (Int32)converter.ConvertFrom(p.Byte) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Byte.HasValue && (Int32)Convert.ChangeType(p.Byte, typeof(Int32)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Byte.HasValue && Int32.Parse(p.Byte.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Binary":
                    Connection.ExecuteReader<NullableTypeInfo>(p => (Int32)converter.ConvertFrom(p.Binary) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => (Int32)Convert.ChangeType(p.Binary, typeof(Int32)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => Int32.Parse(p.Binary.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Char":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Char.HasValue && (Int32)converter.ConvertFrom(p.Char) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Char.HasValue && (Int32)Convert.ChangeType(p.Char, typeof(Int32)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Char.HasValue && Int32.Parse(p.Char.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "DateTime":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.DateTime.HasValue && (Int32)converter.ConvertFrom(p.DateTime) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.DateTime.HasValue && (Int32)Convert.ChangeType(p.DateTime, typeof(Int32)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.DateTime.HasValue && Int32.Parse(p.DateTime.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Decimal":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Decimal.HasValue && (Int32)converter.ConvertFrom(p.Decimal) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Decimal.HasValue && (Int32)Convert.ChangeType(p.Decimal, typeof(Int32)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Decimal.HasValue && Int32.Parse(p.Decimal.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Double":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Double.HasValue && (Int32)converter.ConvertFrom(p.Double) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Double.HasValue && (Int32)Convert.ChangeType(p.Double, typeof(Int32)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Double.HasValue && Int32.Parse(p.Double.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Int16":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int16.HasValue && (Int32)converter.ConvertFrom(p.Int16) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int16.HasValue && (Int32)Convert.ChangeType(p.Int16, typeof(Int32)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int16.HasValue && Int32.Parse(p.Int16.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Int32":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int32.HasValue && (Int32)converter.ConvertFrom(p.Int32) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int32.HasValue && (Int32)Convert.ChangeType(p.Int32, typeof(Int32)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int32.HasValue && Int32.Parse(p.Int32.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Int64":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int64.HasValue && (Int32)converter.ConvertFrom(p.Int64) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int64.HasValue && (Int32)Convert.ChangeType(p.Int64, typeof(Int32)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int64.HasValue && Int32.Parse(p.Int64.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "SByte":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.SByte.HasValue && (Int32)converter.ConvertFrom(p.SByte) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.SByte.HasValue && (Int32)Convert.ChangeType(p.SByte, typeof(Int32)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.SByte.HasValue && Int32.Parse(p.SByte.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Single":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Single.HasValue && (Int32)converter.ConvertFrom(p.Single) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Single.HasValue && (Int32)Convert.ChangeType(p.Single, typeof(Int32)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Single.HasValue && Int32.Parse(p.Single.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "String":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.String.Length > 0 && (Int32)converter.ConvertFrom(p.String) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.String.Length > 0 && (Int32)Convert.ChangeType(p.String, typeof(Int32)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.String.Length > 0 && Int32.Parse(p.String.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "UInt16":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt16.HasValue && (Int32)converter.ConvertFrom(p.UInt16) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt16.HasValue && (Int32)Convert.ChangeType(p.UInt16, typeof(Int32)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt16.HasValue && Int32.Parse(p.UInt16.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "UInt32":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt32.HasValue && (Int32)converter.ConvertFrom(p.UInt32) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt32.HasValue && (Int32)Convert.ChangeType(p.UInt32, typeof(Int32)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt32.HasValue && Int32.Parse(p.UInt32.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "UInt64":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt64.HasValue && (Int32)converter.ConvertFrom(p.UInt64) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt64.HasValue && (Int32)Convert.ChangeType(p.UInt64, typeof(Int32)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt64.HasValue && Int32.Parse(p.UInt64.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;

            }

        }
        #endregion

        #region  ToUInt32
        public void ToUInt32(string nColumn,UInt32 m)
        {
            var converter = System.ComponentModel.TypeDescriptor.GetConverter(typeof(UInt32));
            switch (nColumn)
            {
                case "Boolean":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Boolean.HasValue && (UInt32)converter.ConvertFrom(p.Boolean) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Boolean.HasValue && (UInt32)Convert.ChangeType(p.Boolean, typeof(UInt32)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Boolean.HasValue && UInt32.Parse(p.Boolean.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Byte":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Byte.HasValue && (UInt32)converter.ConvertFrom(p.Byte) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Byte.HasValue && (UInt32)Convert.ChangeType(p.Byte, typeof(UInt32)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Byte.HasValue && UInt32.Parse(p.Byte.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Binary":
                    Connection.ExecuteReader<NullableTypeInfo>(p => (UInt32)converter.ConvertFrom(p.Binary) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => (UInt32)Convert.ChangeType(p.Binary, typeof(UInt32)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => UInt32.Parse(p.Binary.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Char":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Char.HasValue && (UInt32)converter.ConvertFrom(p.Char) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Char.HasValue && (UInt32)Convert.ChangeType(p.Char, typeof(UInt32)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Char.HasValue && UInt32.Parse(p.Char.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "DateTime":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.DateTime.HasValue && (UInt32)converter.ConvertFrom(p.DateTime) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.DateTime.HasValue && (UInt32)Convert.ChangeType(p.DateTime, typeof(UInt32)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.DateTime.HasValue && UInt32.Parse(p.DateTime.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Decimal":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Decimal.HasValue && (UInt32)converter.ConvertFrom(p.Decimal) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Decimal.HasValue && (UInt32)Convert.ChangeType(p.Decimal, typeof(UInt32)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Decimal.HasValue && UInt32.Parse(p.Decimal.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Double":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Double.HasValue && (UInt32)converter.ConvertFrom(p.Double) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Double.HasValue && (UInt32)Convert.ChangeType(p.Double, typeof(UInt32)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Double.HasValue && UInt32.Parse(p.Double.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Int16":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int16.HasValue && (UInt32)converter.ConvertFrom(p.Int16) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int16.HasValue && (UInt32)Convert.ChangeType(p.Int16, typeof(UInt32)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int16.HasValue && UInt32.Parse(p.Int16.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Int32":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int32.HasValue && (UInt32)converter.ConvertFrom(p.Int32) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int32.HasValue && (UInt32)Convert.ChangeType(p.Int32, typeof(UInt32)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int32.HasValue && UInt32.Parse(p.Int32.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Int64":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int64.HasValue && (UInt32)converter.ConvertFrom(p.Int64) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int64.HasValue && (UInt32)Convert.ChangeType(p.Int64, typeof(UInt32)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int64.HasValue && UInt32.Parse(p.Int64.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "SByte":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.SByte.HasValue && (UInt32)converter.ConvertFrom(p.SByte) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.SByte.HasValue && (UInt32)Convert.ChangeType(p.SByte, typeof(UInt32)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.SByte.HasValue && UInt32.Parse(p.SByte.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Single":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Single.HasValue && (UInt32)converter.ConvertFrom(p.Single) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Single.HasValue && (UInt32)Convert.ChangeType(p.Single, typeof(UInt32)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Single.HasValue && UInt32.Parse(p.Single.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "String":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.String.Length > 0 && (UInt32)converter.ConvertFrom(p.String) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.String.Length > 0 && (UInt32)Convert.ChangeType(p.String, typeof(UInt32)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.String.Length > 0 && UInt32.Parse(p.String.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "UInt16":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt16.HasValue && (UInt32)converter.ConvertFrom(p.UInt16) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt16.HasValue && (UInt32)Convert.ChangeType(p.UInt16, typeof(UInt32)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt16.HasValue && UInt32.Parse(p.UInt16.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "UInt32":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt32.HasValue && (UInt32)converter.ConvertFrom(p.UInt32) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt32.HasValue && (UInt32)Convert.ChangeType(p.UInt32, typeof(UInt32)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt32.HasValue && UInt32.Parse(p.UInt32.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "UInt64":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt64.HasValue && (UInt32)converter.ConvertFrom(p.UInt64) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt64.HasValue && (UInt32)Convert.ChangeType(p.UInt64, typeof(UInt32)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt64.HasValue && UInt32.Parse(p.UInt64.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;

            }

        }
        #endregion

        #region  ToInt64
        public void ToInt64(string nColumn,Int64 m)
        {
            var converter = System.ComponentModel.TypeDescriptor.GetConverter(typeof(Int64));
            switch (nColumn)
            {
                case "Boolean":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Boolean.HasValue && (Int64)converter.ConvertFrom(p.Boolean) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Boolean.HasValue && (Int64)Convert.ChangeType(p.Boolean, typeof(Int64)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Boolean.HasValue && Int64.Parse(p.Boolean.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Byte":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Byte.HasValue && (Int64)converter.ConvertFrom(p.Byte) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Byte.HasValue && (Int64)Convert.ChangeType(p.Byte, typeof(Int64)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Byte.HasValue && Int64.Parse(p.Byte.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Binary":
                    Connection.ExecuteReader<NullableTypeInfo>(p => (Int64)converter.ConvertFrom(p.Binary) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => (Int64)Convert.ChangeType(p.Binary, typeof(Int64)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => Int64.Parse(p.Binary.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Char":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Char.HasValue && (Int64)converter.ConvertFrom(p.Char) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Char.HasValue && (Int64)Convert.ChangeType(p.Char, typeof(Int64)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Char.HasValue && Int64.Parse(p.Char.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "DateTime":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.DateTime.HasValue && (Int64)converter.ConvertFrom(p.DateTime) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.DateTime.HasValue && (Int64)Convert.ChangeType(p.DateTime, typeof(Int64)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.DateTime.HasValue && Int64.Parse(p.DateTime.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Decimal":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Decimal.HasValue && (Int64)converter.ConvertFrom(p.Decimal) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Decimal.HasValue && (Int64)Convert.ChangeType(p.Decimal, typeof(Int64)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Decimal.HasValue && Int64.Parse(p.Decimal.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Double":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Double.HasValue && (Int64)converter.ConvertFrom(p.Double) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Double.HasValue && (Int64)Convert.ChangeType(p.Double, typeof(Int64)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Double.HasValue && Int64.Parse(p.Double.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Int16":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int16.HasValue && (Int64)converter.ConvertFrom(p.Int16) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int16.HasValue && (Int64)Convert.ChangeType(p.Int16, typeof(Int64)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int16.HasValue && Int64.Parse(p.Int16.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Int32":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int32.HasValue && (Int64)converter.ConvertFrom(p.Int32) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int32.HasValue && (Int64)Convert.ChangeType(p.Int32, typeof(Int64)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int32.HasValue && Int64.Parse(p.Int32.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Int64":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int64.HasValue && (Int64)converter.ConvertFrom(p.Int64) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int64.HasValue && (Int64)Convert.ChangeType(p.Int64, typeof(Int64)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int64.HasValue && Int64.Parse(p.Int64.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "SByte":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.SByte.HasValue && (Int64)converter.ConvertFrom(p.SByte) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.SByte.HasValue && (Int64)Convert.ChangeType(p.SByte, typeof(Int64)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.SByte.HasValue && Int64.Parse(p.SByte.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Single":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Single.HasValue && (Int64)converter.ConvertFrom(p.Single) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Single.HasValue && (Int64)Convert.ChangeType(p.Single, typeof(Int64)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Single.HasValue && Int64.Parse(p.Single.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "String":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.String.Length > 0 && (Int64)converter.ConvertFrom(p.String) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.String.Length > 0 && (Int64)Convert.ChangeType(p.String, typeof(Int64)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.String.Length > 0 && Int64.Parse(p.String.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "UInt16":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt16.HasValue && (Int64)converter.ConvertFrom(p.UInt16) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt16.HasValue && (Int64)Convert.ChangeType(p.UInt16, typeof(Int64)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt16.HasValue && Int64.Parse(p.UInt16.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "UInt32":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt32.HasValue && (Int64)converter.ConvertFrom(p.UInt32) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt32.HasValue && (Int64)Convert.ChangeType(p.UInt32, typeof(Int64)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt32.HasValue && Int64.Parse(p.UInt32.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "UInt64":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt64.HasValue && (Int64)converter.ConvertFrom(p.UInt64) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt64.HasValue && (Int64)Convert.ChangeType(p.UInt64, typeof(Int64)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt64.HasValue && Int64.Parse(p.UInt64.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;

            }

        }
        #endregion

        #region  ToUInt64
        public void ToUInt64(string nColumn,UInt64 m)
        {
            var converter = System.ComponentModel.TypeDescriptor.GetConverter(typeof(UInt64));
            switch (nColumn)
            {
                case "Boolean":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Boolean.HasValue && (UInt64)converter.ConvertFrom(p.Boolean) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Boolean.HasValue && (UInt64)Convert.ChangeType(p.Boolean, typeof(UInt64)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Boolean.HasValue && UInt64.Parse(p.Boolean.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Byte":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Byte.HasValue && (UInt64)converter.ConvertFrom(p.Byte) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Byte.HasValue && (UInt64)Convert.ChangeType(p.Byte, typeof(UInt64)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Byte.HasValue && UInt64.Parse(p.Byte.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Binary":
                    Connection.ExecuteReader<NullableTypeInfo>(p => (UInt64)converter.ConvertFrom(p.Binary) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => (UInt64)Convert.ChangeType(p.Binary, typeof(UInt64)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => UInt64.Parse(p.Binary.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Char":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Char.HasValue && (UInt64)converter.ConvertFrom(p.Char) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Char.HasValue && (UInt64)Convert.ChangeType(p.Char, typeof(UInt64)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Char.HasValue && UInt64.Parse(p.Char.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "DateTime":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.DateTime.HasValue && (UInt64)converter.ConvertFrom(p.DateTime) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.DateTime.HasValue && (UInt64)Convert.ChangeType(p.DateTime, typeof(UInt64)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.DateTime.HasValue && UInt64.Parse(p.DateTime.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Decimal":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Decimal.HasValue && (UInt64)converter.ConvertFrom(p.Decimal) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Decimal.HasValue && (UInt64)Convert.ChangeType(p.Decimal, typeof(UInt64)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Decimal.HasValue && UInt64.Parse(p.Decimal.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Double":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Double.HasValue && (UInt64)converter.ConvertFrom(p.Double) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Double.HasValue && (UInt64)Convert.ChangeType(p.Double, typeof(UInt64)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Double.HasValue && UInt64.Parse(p.Double.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Int16":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int16.HasValue && (UInt64)converter.ConvertFrom(p.Int16) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int16.HasValue && (UInt64)Convert.ChangeType(p.Int16, typeof(UInt64)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int16.HasValue && UInt64.Parse(p.Int16.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Int32":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int32.HasValue && (UInt64)converter.ConvertFrom(p.Int32) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int32.HasValue && (UInt64)Convert.ChangeType(p.Int32, typeof(UInt64)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int32.HasValue && UInt64.Parse(p.Int32.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Int64":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int64.HasValue && (UInt64)converter.ConvertFrom(p.Int64) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int64.HasValue && (UInt64)Convert.ChangeType(p.Int64, typeof(UInt64)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int64.HasValue && UInt64.Parse(p.Int64.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "SByte":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.SByte.HasValue && (UInt64)converter.ConvertFrom(p.SByte) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.SByte.HasValue && (UInt64)Convert.ChangeType(p.SByte, typeof(UInt64)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.SByte.HasValue && UInt64.Parse(p.SByte.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Single":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Single.HasValue && (UInt64)converter.ConvertFrom(p.Single) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Single.HasValue && (UInt64)Convert.ChangeType(p.Single, typeof(UInt64)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Single.HasValue && UInt64.Parse(p.Single.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "String":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.String.Length > 0 && (UInt64)converter.ConvertFrom(p.String) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.String.Length > 0 && (UInt64)Convert.ChangeType(p.String, typeof(UInt64)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.String.Length > 0 && UInt64.Parse(p.String.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "UInt16":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt16.HasValue && (UInt64)converter.ConvertFrom(p.UInt16) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt16.HasValue && (UInt64)Convert.ChangeType(p.UInt16, typeof(UInt64)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt16.HasValue && UInt64.Parse(p.UInt16.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "UInt32":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt32.HasValue && (UInt64)converter.ConvertFrom(p.UInt32) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt32.HasValue && (UInt64)Convert.ChangeType(p.UInt32, typeof(UInt64)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt32.HasValue && UInt64.Parse(p.UInt32.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "UInt64":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt64.HasValue && (UInt64)converter.ConvertFrom(p.UInt64) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt64.HasValue && (UInt64)Convert.ChangeType(p.UInt64, typeof(UInt64)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt64.HasValue && UInt64.Parse(p.UInt64.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;

            }

        }
        #endregion

        #region  ToSingle
        public void ToSingle(string nColumn,Single m)
        {
            var converter = System.ComponentModel.TypeDescriptor.GetConverter(typeof(Single));
            switch (nColumn)
            {
                case "Boolean":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Boolean.HasValue && (Single)converter.ConvertFrom(p.Boolean) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Boolean.HasValue && (Single)Convert.ChangeType(p.Boolean, typeof(Single)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Boolean.HasValue && Single.Parse(p.Boolean.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Byte":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Byte.HasValue && (Single)converter.ConvertFrom(p.Byte) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Byte.HasValue && (Single)Convert.ChangeType(p.Byte, typeof(Single)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Byte.HasValue && Single.Parse(p.Byte.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Binary":
                    Connection.ExecuteReader<NullableTypeInfo>(p => (Single)converter.ConvertFrom(p.Binary) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => (Single)Convert.ChangeType(p.Binary, typeof(Single)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => Single.Parse(p.Binary.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Char":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Char.HasValue && (Single)converter.ConvertFrom(p.Char) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Char.HasValue && (Single)Convert.ChangeType(p.Char, typeof(Single)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Char.HasValue && Single.Parse(p.Char.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "DateTime":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.DateTime.HasValue && (Single)converter.ConvertFrom(p.DateTime) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.DateTime.HasValue && (Single)Convert.ChangeType(p.DateTime, typeof(Single)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.DateTime.HasValue && Single.Parse(p.DateTime.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Decimal":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Decimal.HasValue && (Single)converter.ConvertFrom(p.Decimal) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Decimal.HasValue && (Single)Convert.ChangeType(p.Decimal, typeof(Single)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Decimal.HasValue && Single.Parse(p.Decimal.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Double":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Double.HasValue && (Single)converter.ConvertFrom(p.Double) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Double.HasValue && (Single)Convert.ChangeType(p.Double, typeof(Single)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Double.HasValue && Single.Parse(p.Double.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Int16":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int16.HasValue && (Single)converter.ConvertFrom(p.Int16) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int16.HasValue && (Single)Convert.ChangeType(p.Int16, typeof(Single)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int16.HasValue && Single.Parse(p.Int16.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Int32":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int32.HasValue && (Single)converter.ConvertFrom(p.Int32) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int32.HasValue && (Single)Convert.ChangeType(p.Int32, typeof(Single)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int32.HasValue && Single.Parse(p.Int32.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Int64":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int64.HasValue && (Single)converter.ConvertFrom(p.Int64) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int64.HasValue && (Single)Convert.ChangeType(p.Int64, typeof(Single)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int64.HasValue && Single.Parse(p.Int64.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "SByte":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.SByte.HasValue && (Single)converter.ConvertFrom(p.SByte) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.SByte.HasValue && (Single)Convert.ChangeType(p.SByte, typeof(Single)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.SByte.HasValue && Single.Parse(p.SByte.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Single":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Single.HasValue && (Single)converter.ConvertFrom(p.Single) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Single.HasValue && (Single)Convert.ChangeType(p.Single, typeof(Single)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Single.HasValue && Single.Parse(p.Single.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "String":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.String.Length > 0 && (Single)converter.ConvertFrom(p.String) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.String.Length > 0 && (Single)Convert.ChangeType(p.String, typeof(Single)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.String.Length > 0 && Single.Parse(p.String.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "UInt16":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt16.HasValue && (Single)converter.ConvertFrom(p.UInt16) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt16.HasValue && (Single)Convert.ChangeType(p.UInt16, typeof(Single)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt16.HasValue && Single.Parse(p.UInt16.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "UInt32":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt32.HasValue && (Single)converter.ConvertFrom(p.UInt32) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt32.HasValue && (Single)Convert.ChangeType(p.UInt32, typeof(Single)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt32.HasValue && Single.Parse(p.UInt32.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "UInt64":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt64.HasValue && (Single)converter.ConvertFrom(p.UInt64) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt64.HasValue && (Single)Convert.ChangeType(p.UInt64, typeof(Single)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt64.HasValue && Single.Parse(p.UInt64.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;

            }

        }
        #endregion

        #region  ToDouble
        public void ToDouble(string nColumn,double m)
        {
            var converter = System.ComponentModel.TypeDescriptor.GetConverter(typeof(float));
            switch (nColumn)
            {
                case "Boolean":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Boolean.HasValue && (float)converter.ConvertFrom(p.Boolean) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Boolean.HasValue && (float)Convert.ChangeType(p.Boolean, typeof(float)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Boolean.HasValue && float.Parse(p.Boolean.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Byte":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Byte.HasValue && (float)converter.ConvertFrom(p.Byte) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Byte.HasValue && (float)Convert.ChangeType(p.Byte, typeof(float)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Byte.HasValue && float.Parse(p.Byte.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Binary":
                    Connection.ExecuteReader<NullableTypeInfo>(p => (float)converter.ConvertFrom(p.Binary) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => (float)Convert.ChangeType(p.Binary, typeof(float)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => float.Parse(p.Binary.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Char":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Char.HasValue && (float)converter.ConvertFrom(p.Char) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Char.HasValue && (float)Convert.ChangeType(p.Char, typeof(float)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Char.HasValue && float.Parse(p.Char.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "DateTime":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.DateTime.HasValue && (float)converter.ConvertFrom(p.DateTime) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.DateTime.HasValue && (float)Convert.ChangeType(p.DateTime, typeof(float)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.DateTime.HasValue && float.Parse(p.DateTime.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Decimal":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Decimal.HasValue && (float)converter.ConvertFrom(p.Decimal) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Decimal.HasValue && (float)Convert.ChangeType(p.Decimal, typeof(float)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Decimal.HasValue && float.Parse(p.Decimal.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Double":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Double.HasValue && (float)converter.ConvertFrom(p.Double) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Double.HasValue && (float)Convert.ChangeType(p.Double, typeof(float)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Double.HasValue && float.Parse(p.Double.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Int16":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int16.HasValue && (float)converter.ConvertFrom(p.Int16) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int16.HasValue && (float)Convert.ChangeType(p.Int16, typeof(float)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int16.HasValue && float.Parse(p.Int16.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Int32":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int32.HasValue && (float)converter.ConvertFrom(p.Int32) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int32.HasValue && (float)Convert.ChangeType(p.Int32, typeof(float)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int32.HasValue && float.Parse(p.Int32.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Int64":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int64.HasValue && (float)converter.ConvertFrom(p.Int64) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int64.HasValue && (float)Convert.ChangeType(p.Int64, typeof(float)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int64.HasValue && Double.Parse(p.Int64.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "SByte":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.SByte.HasValue && (float)converter.ConvertFrom(p.SByte) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.SByte.HasValue && (float)Convert.ChangeType(p.SByte, typeof(float)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.SByte.HasValue && float.Parse(p.SByte.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Single":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Single.HasValue && (float)converter.ConvertFrom(p.Single) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Single.HasValue && (float)Convert.ChangeType(p.Single, typeof(float)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Single.HasValue && float.Parse(p.Single.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "String":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.String.Length > 0 && (float)converter.ConvertFrom(p.String) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.String.Length > 0 && (float)Convert.ChangeType(p.String, typeof(float)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.String.Length > 0 && float.Parse(p.String.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "UInt16":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt16.HasValue && (float)converter.ConvertFrom(p.UInt16) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt16.HasValue && (float)Convert.ChangeType(p.UInt16, typeof(float)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt16.HasValue && float.Parse(p.UInt16.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "UInt32":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt32.HasValue && (float)converter.ConvertFrom(p.UInt32) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt32.HasValue && (float)Convert.ChangeType(p.UInt32, typeof(float)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt32.HasValue && float.Parse(p.UInt32.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "UInt64":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt64.HasValue && (float)converter.ConvertFrom(p.UInt64) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt64.HasValue && (float)Convert.ChangeType(p.UInt64, typeof(float)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt64.HasValue && float.Parse(p.UInt64.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;

            }

        }
        #endregion

        #region  ToDecimal
        public void ToDecimal(string nColumn,decimal m)
        {
            var converter = System.ComponentModel.TypeDescriptor.GetConverter(typeof(Decimal));
            switch (nColumn)
            {
                case "Boolean":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Boolean.HasValue && (Decimal)converter.ConvertFrom(p.Boolean) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Boolean.HasValue && (Decimal)Convert.ChangeType(p.Boolean, typeof(Decimal)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Boolean.HasValue && Decimal.Parse(p.Boolean.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Byte":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Byte.HasValue && (Decimal)converter.ConvertFrom(p.Byte) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Byte.HasValue && (Decimal)Convert.ChangeType(p.Byte, typeof(Decimal)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Byte.HasValue && Decimal.Parse(p.Byte.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Binary":
                    Connection.ExecuteReader<NullableTypeInfo>(p => (Decimal)converter.ConvertFrom(p.Binary) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => (Decimal)Convert.ChangeType(p.Binary, typeof(Decimal)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => Decimal.Parse(p.Binary.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Char":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Char.HasValue && (Decimal)converter.ConvertFrom(p.Char) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Char.HasValue && (Decimal)Convert.ChangeType(p.Char, typeof(Decimal)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Char.HasValue && Decimal.Parse(p.Char.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "DateTime":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.DateTime.HasValue && (Decimal)converter.ConvertFrom(p.DateTime) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.DateTime.HasValue && (Decimal)Convert.ChangeType(p.DateTime, typeof(Decimal)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.DateTime.HasValue && Decimal.Parse(p.DateTime.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Decimal":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Decimal.HasValue && (Decimal)converter.ConvertFrom(p.Decimal) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Decimal.HasValue && (Decimal)Convert.ChangeType(p.Decimal, typeof(Decimal)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Decimal.HasValue && Decimal.Parse(p.Decimal.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Double":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Double.HasValue && (Decimal)converter.ConvertFrom(p.Double) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Double.HasValue && (Decimal)Convert.ChangeType(p.Double, typeof(Decimal)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Double.HasValue && Decimal.Parse(p.Double.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Int16":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int16.HasValue && (Decimal)converter.ConvertFrom(p.Int16) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int16.HasValue && (Decimal)Convert.ChangeType(p.Int16, typeof(Decimal)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int16.HasValue && Decimal.Parse(p.Int16.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Int32":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int32.HasValue && (Decimal)converter.ConvertFrom(p.Int32) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int32.HasValue && (Decimal)Convert.ChangeType(p.Int32, typeof(Decimal)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int32.HasValue && Decimal.Parse(p.Int32.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Int64":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int64.HasValue && (Decimal)converter.ConvertFrom(p.Int64) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int64.HasValue && (Decimal)Convert.ChangeType(p.Int64, typeof(Decimal)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int64.HasValue && Decimal.Parse(p.Int64.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "SByte":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.SByte.HasValue && (Decimal)converter.ConvertFrom(p.SByte) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.SByte.HasValue && (Decimal)Convert.ChangeType(p.SByte, typeof(Decimal)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.SByte.HasValue && Decimal.Parse(p.SByte.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Single":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Single.HasValue && (Decimal)converter.ConvertFrom(p.Single) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Single.HasValue && (Decimal)Convert.ChangeType(p.Single, typeof(Decimal)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Single.HasValue && Decimal.Parse(p.Single.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "String":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.String.Length > 0 && (Decimal)converter.ConvertFrom(p.String) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.String.Length > 0 && (Decimal)Convert.ChangeType(p.String, typeof(Decimal)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.String.Length > 0 && Decimal.Parse(p.String.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "UInt16":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt16.HasValue && (Decimal)converter.ConvertFrom(p.UInt16) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt16.HasValue && (Decimal)Convert.ChangeType(p.UInt16, typeof(Decimal)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt16.HasValue && Decimal.Parse(p.UInt16.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "UInt32":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt32.HasValue && (Decimal)converter.ConvertFrom(p.UInt32) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt32.HasValue && (Decimal)Convert.ChangeType(p.UInt32, typeof(Decimal)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt32.HasValue && Decimal.Parse(p.UInt32.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "UInt64":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt64.HasValue && (Decimal)converter.ConvertFrom(p.UInt64) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt64.HasValue && (Decimal)Convert.ChangeType(p.UInt64, typeof(Decimal)) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt64.HasValue && Decimal.Parse(p.UInt64.ToString()) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;

            }

        }
        #endregion

        #region  ToDateTime
        public void ToDateTime(string nColumn,DateTime m)
        {
            var converter = System.ComponentModel.TypeDescriptor.GetConverter(typeof(DateTime));
            Connection.ExecuteReader<NullableTypeInfo>(p => p.String.Length > 0 && (DateTime)converter.ConvertFrom(p.String) > (DateTime)converter.ConvertTo(m, typeof(DateTime)))
                        .ToDataTable().WriteXml(Console.Out);

            Connection.ExecuteReader<NullableTypeInfo>(p => p.String.Length > 0 && (DateTime)Convert.ChangeType(p.String, typeof(DateTime)) > (DateTime)converter.ConvertTo(m, typeof(DateTime)))
                .ToDataTable().WriteXml(Console.Out);

            Connection.ExecuteReader<NullableTypeInfo>(p => p.String.Length > 0 && DateTime.Parse(p.String.ToString()) > (DateTime)converter.ConvertTo(m, typeof(DateTime)))
                .ToDataTable().WriteXml(Console.Out);
        }
        #endregion

        #region  ToString
        public void ToString(string nColumn,string m)
        {
            var converter = System.ComponentModel.TypeDescriptor.GetConverter(typeof(String));
            switch (nColumn)
            {
                case "Boolean":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Boolean.HasValue && (String)converter.ConvertFrom(p.Boolean) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Boolean.HasValue && (String)Convert.ChangeType(p.Boolean, typeof(String)) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Byte":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Byte.HasValue && (String)converter.ConvertFrom(p.Byte) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Byte.HasValue && (String)Convert.ChangeType(p.Byte, typeof(String)) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Binary":
                    Connection.ExecuteReader<NullableTypeInfo>(p => (String)converter.ConvertFrom(p.Binary) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => (String)Convert.ChangeType(p.Binary, typeof(String)) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Char":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Char.HasValue && (String)converter.ConvertFrom(p.Char) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Char.HasValue && (String)Convert.ChangeType(p.Char, typeof(String)) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "DateTime":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.DateTime.HasValue && (String)converter.ConvertFrom(p.DateTime) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.DateTime.HasValue && (String)Convert.ChangeType(p.DateTime, typeof(String)) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Decimal":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Decimal.HasValue && (String)converter.ConvertFrom(p.Decimal) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Decimal.HasValue && (String)Convert.ChangeType(p.Decimal, typeof(String)) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Double":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Double.HasValue && (String)converter.ConvertFrom(p.Double) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Double.HasValue && (String)Convert.ChangeType(p.Double, typeof(String)) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Int16":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int16.HasValue && (String)converter.ConvertFrom(p.Int16) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int16.HasValue && (String)Convert.ChangeType(p.Int16, typeof(String)) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Int32":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int32.HasValue && (String)converter.ConvertFrom(p.Int32) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int32.HasValue && (String)Convert.ChangeType(p.Int32, typeof(String)) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Int64":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int64.HasValue && (String)converter.ConvertFrom(p.Int64) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Int64.HasValue && (String)Convert.ChangeType(p.Int64, typeof(String)) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "SByte":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Byte.HasValue && (String)converter.ConvertFrom(p.Byte) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Byte.HasValue && (String)Convert.ChangeType(p.Byte, typeof(String)) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "Single":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Single.HasValue && (String)converter.ConvertFrom(p.Single) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.Single.HasValue && (String)Convert.ChangeType(p.Single, typeof(String)) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "String":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.String.Length > 0 && (String)converter.ConvertFrom(p.String) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.String.Length > 0 && (String)Convert.ChangeType(p.String, typeof(String)) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "UInt16":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt16.HasValue && (String)converter.ConvertFrom(p.UInt16) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt16.HasValue && (String)Convert.ChangeType(p.UInt16, typeof(String)) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "UInt32":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt32.HasValue && (String)converter.ConvertFrom(p.UInt32) == m)
                         .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt32.HasValue && (String)Convert.ChangeType(p.UInt32, typeof(String)) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;
                case "UInt64":
                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt64.HasValue && (String)converter.ConvertFrom(p.UInt64) == m)
                        .ToDataTable().WriteXml(Console.Out);

                    Connection.ExecuteReader<NullableTypeInfo>(p => p.UInt64.HasValue && (String)Convert.ChangeType(p.UInt64, typeof(String)) == m)
                        .ToDataTable().WriteXml(Console.Out);
                    break;

            }

        }
        #endregion



    }
}
