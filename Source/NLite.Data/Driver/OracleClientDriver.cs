using System;
using System.Data;
using System.Data.Common;
using NLite.Data.Common;

namespace NLite.Data.Driver
{
    class OracleClientDriver : OracleDriver
    {
        protected override void InitializeParameter(System.Data.IDbDataParameter p, NamedParameter parameter, object value)
        {

            p.ParameterName = parameter.Name;
            p.Value = value ?? DBNull.Value;
            var sqlType = parameter.SqlType;

            if (parameter.SqlType != null)
            {
                if (sqlType.Length > 0)
                    p.Size = sqlType.Length;
                if (sqlType.Precision > 0)
                    p.Precision = sqlType.Precision;
                if (sqlType.Scale > 0)
                    p.Scale = sqlType.Scale;
                if (sqlType.Required)
                    (p as DbParameter).IsNullable = false;

                switch (sqlType.DbType)
                {
                    case DBType.NChar:
                    case DBType.NVarChar:
                        {
                            var str = value as string;
                            if (string.IsNullOrEmpty(str))
                                p.Size = 2;
                            else
                                p.Size = str.Length * 2;
                            break;
                        }
                    case DBType.Char:
                    case DBType.VarChar:
                        {
                            var str = value as string;
                            if (string.IsNullOrEmpty(str))
                                p.Size = 1;
                            else
                                p.Size = str.Length * 1;
                            break;
                        }
                    case DBType.Guid:
                        parameter.sqlType = SqlType.Get(DBType.Binary, 16);
                        if (value is Guid)
                            p.Value = ((Guid)value).ToByteArray();
                        else if (value != null)
                            p.Value = (((Guid?)value).Value).ToByteArray();
                        break;
                    case DBType.Binary:
                    case DBType.Image:
                        if (value is Guid)
                        {
                            p.Value = ((Guid)value).ToByteArray();
                            parameter.sqlType = SqlType.Get(DBType.Binary, 16);
                        }
                        else if (value is Guid?)
                        {
                            p.Value = ((Guid?)value).Value.ToByteArray();
                            parameter.sqlType = SqlType.Get(DBType.Binary, 16);
                        }
                        break;
                }
            }
            ConvertDBTypeToNativeType(p, parameter.sqlType.DbType);
        }

        protected override void InitializeParameter(object item, DbParameter p, Type type)
        {
            var typeCode = Type.GetTypeCode(type);
            switch (typeCode)
            {
                case TypeCode.SByte:
                    p.DbType = DbType.Byte;
                    item = (byte)item;
                    break;
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.Int64:
                case TypeCode.UInt64:
                    p.DbType = DbType.Int32;
                    item = Convert.ToInt32(item);
                    break;
                default:
                    if (item is Guid)
                    {
                        p.DbType = DbType.Binary;
                        item = ((Guid)item).ToByteArray();
                    }
                    break;

            }
            p.Value = item;
        }


    }
}
