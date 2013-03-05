using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NLite.Data.Driver
{
    class SqlServer2000Driver:SqlServerDriver
    {
        public override bool AllowsMultipleOpenReaders
        {
            get
            {
                return false;
            }
        }

    }
}
