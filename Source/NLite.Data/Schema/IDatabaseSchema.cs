using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NLite.Data.Schema
{
    public interface IDatabaseSchema
    {
        ITableSchema[] Tables { get; }
        ITableSchema[] Views { get; }
    }
}
