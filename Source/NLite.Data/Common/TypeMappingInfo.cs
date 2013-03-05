using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace NLite.Data.Common
{
    class TypeMappingInfo
    {
        public Type CLRType;
        public DBType DbType;
        public string NativeType;
        public int ProviderDbType;
    }
}
