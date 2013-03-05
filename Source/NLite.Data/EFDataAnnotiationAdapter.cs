using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using NLite.Reflection;

namespace NLite.Data
{
    class EFDataAnnotiationAdapter
    {
        internal const string StrNotMappedAttribute = "System.ComponentModel.DataAnnotations.NotMappedAttribute";
        internal const string StrTableAttribute = "System.ComponentModel.DataAnnotations.TableAttribute";
        internal const string StrColumnAttribute = "System.ComponentModel.DataAnnotations.ColumnAttribute";
        internal const string StrDatabaseGeneratedAttribute = "System.ComponentModel.DataAnnotations.DatabaseGeneratedAttribute";
        internal const string StrMaxLengthAttribute = "System.ComponentModel.DataAnnotations.MaxLengthAttribute";
        internal const string StrForeignKeyAttribute = "System.ComponentModel.DataAnnotations.ForeignKeyAttribute";
        internal const string StrAssemblyName = "EntityFramework";

        internal static Type NotMappedAttributeType;
        internal static Type TableAttributeType;
        internal static Type ColumndAttributeType;
        internal static Type DatabaseGeneratedAttributeType;
        internal static Type MaxLengthAttributeType;
        internal static Type ForeignKeyAttributeType;

        public TableAttribute Table;
        internal class TableAttribute
        {
            public Getter Schema;
            public Getter Name;
        }

        public ColumnAttribute Column;
        internal class ColumnAttribute
        {
            public Getter Name;
            public Getter TypeName;
        }

        public DatabaseGeneratedAttribute DatabaseGenerated;
        internal class DatabaseGeneratedAttribute
        {
            public Getter DatabaseGeneratedOption;
        }

        public ForeignKeyAttribute ForeignKey;
        internal class ForeignKeyAttribute
        {
            public Getter Name;
        }

        public MaxLengthAttribute MaxLength;
        internal class MaxLengthAttribute
        {
            public Getter Length;
        }

        public static EFDataAnnotiationAdapter Instance { get; private set; }
        public static void Init(Assembly asm)
        {
            var instance = new EFDataAnnotiationAdapter();
            Instance = instance;

            EFDataAnnotiationAdapter.NotMappedAttributeType = asm.GetType(EFDataAnnotiationAdapter.StrNotMappedAttribute);
            EFDataAnnotiationAdapter.TableAttributeType = asm.GetType(EFDataAnnotiationAdapter.StrTableAttribute);
            EFDataAnnotiationAdapter.ColumndAttributeType = asm.GetType(EFDataAnnotiationAdapter.StrColumnAttribute);
            EFDataAnnotiationAdapter.DatabaseGeneratedAttributeType = asm.GetType(EFDataAnnotiationAdapter.StrDatabaseGeneratedAttribute);
            EFDataAnnotiationAdapter.MaxLengthAttributeType = asm.GetType(EFDataAnnotiationAdapter.StrMaxLengthAttribute);
            EFDataAnnotiationAdapter.ForeignKeyAttributeType = asm.GetType(EFDataAnnotiationAdapter.StrForeignKeyAttribute);

            instance.Table = new TableAttribute();
            instance.Table.Schema = EFDataAnnotiationAdapter.TableAttributeType.GetProperty("Schema").GetGetter();
            instance.Table.Name = EFDataAnnotiationAdapter.TableAttributeType.GetProperty("Name").GetGetter();

            instance.Column = new ColumnAttribute();
            instance.Column.Name = EFDataAnnotiationAdapter.ColumndAttributeType.GetProperty("Name").GetGetter();
            instance.Column.TypeName = EFDataAnnotiationAdapter.ColumndAttributeType.GetProperty("TypeName").GetGetter();

            instance.DatabaseGenerated = new DatabaseGeneratedAttribute();
            instance.DatabaseGenerated.DatabaseGeneratedOption = EFDataAnnotiationAdapter.DatabaseGeneratedAttributeType.GetProperty("DatabaseGeneratedOption").GetGetter();

            instance.ForeignKey = new ForeignKeyAttribute();
            instance.ForeignKey.Name = EFDataAnnotiationAdapter.ForeignKeyAttributeType.GetProperty("Name").GetGetter();

            instance.MaxLength = new MaxLengthAttribute();
            instance.MaxLength.Length = EFDataAnnotiationAdapter.MaxLengthAttributeType.GetProperty("Length").GetGetter();
        }
    }
}
