using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLite.Data;
using System.Data;
using NLite.Data.Common;
using System.Data.Common;

namespace NLite.Data.Schema.Loader
{
    abstract class SchemaLoader:ISchemaLoader
    {
        public Dialect.Dialect Dialect { get; internal set; }

        protected abstract string AllColumnsSql { get; }
        protected abstract string AllConstraintsSql { get; }
        protected abstract string AllFKsSql { get; }

        internal class ColumnInfo
        {
            public string Schema;
            public string TableName;
            public bool IsView;
            public int Order;
            public string ColumnName;
            public string ColumnType;
            public int Length;
            public int Precision;
            public int Scale;
            public bool IsGenerated;
            public bool IsNullable;
            public string DefaultValue;
            public string Comment;

            public bool IsPrimaryKey;
            public bool IsUniqule;
            public bool IsCheck;

        }

        internal enum ConstraintType
        {
            PrimaryKey= 1,
            Uniqule = 2,
            Check = 3,
        }

        internal class ConstraintInfo
        {
            public string Schema;
            public string TableName;
            public string ColumnName;
            public string Name;
            public ConstraintType Type;
        }

        internal class ForeignKeyInfo
        {
            public string Name;

            public string ThisSchema;
            public string ThisTableName;
            public string ThisKey;

            public string OtherSchema;
            public string OtherTableName;
            public string OtherKey;

            public string Type;
        }

        protected virtual void InitConnection(DbConnection conn) { }

        public virtual IDatabaseSchema Load(DbConfiguration cfg)
        {
            var databaseSchema = new DatabaseSchema();
             
            ColumnInfo[] allColumns = null;
            ConstraintInfo[] allConstraints = null;
            ForeignKeyInfo[] allFks = null;
            using (var ctx = cfg.CreateDbContext())
            {
                InitConnection(ctx.Connection);
                using (var reader = ctx.DbHelper.ExecuteReader(AllColumnsSql))
                    allColumns = reader.ToList<ColumnInfo>().ToArray();
                using (var reader = ctx.DbHelper.ExecuteReader(AllConstraintsSql))
                    allConstraints = reader.ToList<ConstraintInfo>().ToArray();
                using (var reader = ctx.DbHelper.ExecuteReader(AllFKsSql))
                    allFks = reader.ToList<ForeignKeyInfo>().ToArray();
            }

            PopulateConstraints(allColumns, allConstraints);

            Dictionary<string, TableSchema> tables = new Dictionary<string, TableSchema>();
            PopulateTables(allColumns, tables);


            foreach (var item in allFks)
            {
                TableSchema thisTable = null;
                TableSchema otherTable = null;
                IColumnSchema thisKey = null;
                IColumnSchema otherKey = null;

                var key = string.Format("{0}.{1}", item.ThisSchema, item.ThisTableName);
                if (tables.TryGetValue(key, out thisTable))
                    thisKey = thisTable.AllColumns.FirstOrDefault(p => p.ColumnName == item.ThisKey);

                key = string.Format("{0}.{1}", item.OtherSchema, item.OtherTableName);
                if(tables.TryGetValue(key, out otherTable))
                    otherKey = otherTable.AllColumns.FirstOrDefault(p => p.ColumnName == item.OtherKey);

                thisTable.AddFK(new ForeignKeySchema
                { 
                    ThisTable = thisTable
                    , Name = item.Name
                    , ThisKey = thisKey
                    , OtherTable = otherTable
                    , OtherKey = otherKey });

            }

            databaseSchema.Tables = tables.Values.Where(p => !p.IsView).ToArray();
            databaseSchema.Views = tables.Values.Where(p => p.IsView).ToArray();

            return databaseSchema;
        }

        private void PopulateTables(ColumnInfo[] allColumns, Dictionary<string, TableSchema> tables)
        {
            foreach (var c in allColumns)
            {
                TableSchema table = null;
                var key = string.Format("{0}.{1}", c.Schema, c.TableName);

                if (!tables.TryGetValue(key, out table))
                {
                    table = new TableSchema { TableName = c.TableName, Schema = c.Schema,IsView = c.IsView };
                    tables[key] = table;
                }

                var column = ToColumn(c);
                table.AddColumn(column);
            }
        }

        private static void PopulateConstraints(ColumnInfo[] allColumns, ConstraintInfo[] allConstraints)
        {
            foreach (var c in allConstraints)
            {
                var column = allColumns.FirstOrDefault(p => p.Schema == c.Schema && p.TableName == c.TableName && c.ColumnName == p.ColumnName);
                if (column != null)
                {
                    switch (c.Type)
                    {
                        case ConstraintType.PrimaryKey:
                            column.IsPrimaryKey = true;
                            break;
                        case ConstraintType.Uniqule:
                            column.IsUniqule = true;
                            break;
                        case ConstraintType.Check:
                            column.IsCheck = true;
                            break;
                    }
                }
            }
        }

        protected virtual IColumnSchema ToColumn(SchemaLoader.ColumnInfo column)
        {
            var columnSchema = Mapper.Map<SchemaLoader.ColumnInfo, ColumnSchema>(column);
            //var columnSchema = new ColumnSchema();
            //columnSchema.IsGenerated = column.IsGenerated;
            //columnSchema.ColumnName = column.ColumnName;
            //columnSchema.IsPrimaryKey = column.IsPrimaryKey;
            //columnSchema.IsUniqule = column.IsUniqule;
            //columnSchema.Comment = column.Comment;


            var strColumnType = column.ColumnType;

            columnSchema.DbType = ParseDbType(strColumnType);
            columnSchema.Type = ParseType(columnSchema.DbType);


            return columnSchema;
        }

        protected virtual Dictionary<string, TypeMappingInfo> TypeMappings
        {
            get { return TypeMapping.SqlDbMap; }
        }

        protected virtual Type ParseType(DBType dbType)
        {
            return TypeMappings.Values.FirstOrDefault(p => p.DbType == dbType).CLRType;
        }

        protected virtual DBType ParseDbType(string strColumnType)
        {
            TypeMappingInfo item;
            if (TypeMappings.TryGetValue(strColumnType, out item))
                return item.DbType;
            throw new InvalidProgramException("ColumnType:'" + strColumnType + "' invalid!" );
        }
    }
}
