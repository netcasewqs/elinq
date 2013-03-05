using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLite.Data.Schema;

namespace NLite.Data.CodeGeneration
{
    public interface IMemberModel
    {
        string MemberName { get; }
        IColumnSchema Column { get; }
    }
}
