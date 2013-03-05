using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLite.Data.Schema;
using System.Data;

namespace CodeGeneratorTest
{
    public class DatabaseSchema
    {
        public TableSchema[] Tables { get; internal set; }
        public TableSchema[] Views { get; internal set; }
    }

    public class TableSchema 
    {
        public bool IsView;

        private List<ColumnSchema> columns = new List<ColumnSchema>();
        private List<ForeignKeySchema> fks = new List<ForeignKeySchema>();

        public void AddColumn(ColumnSchema column)
        {
            columns.Add(column);
        }

        public void AddFK(ForeignKeySchema fk)
        {
            fks.Add(fk);
        }

        public string Schema { get; internal set; }
        public string TableName { get; internal set; }
        public ColumnSchema[] Columns { get { return columns.ToArray(); } }
        public ForeignKeySchema[] ForeignKeys { get { return fks.ToArray(); } }
    }

    public class ColumnSchema 
    {
        public string ColumnName { get; internal set; }
        public TableSchema Table { get; internal set; }
        public bool IsUniqule { get; internal set; }
        public bool IsPrimaryKey { get; internal set; }

        public bool IsComputed { get; internal set; }
        public bool IsGenerated { get; internal set; }
        public Type Type { get; set; }
        public DbType DbType { get; set; }

        public string Comment { get; set; }
    }

    public class ForeignKeySchema 
    {
        public string Name { get; internal set; }
        public TableSchema ThisTable { get; internal set; }
        public ColumnSchema ThisKey { get; internal set; }
        public TableSchema OtherTable { get; internal set; }
        public ColumnSchema OtherKey { get; internal set; }
    }
}
