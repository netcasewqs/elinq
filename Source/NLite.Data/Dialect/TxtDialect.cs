using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NLite.Data.Dialect
{
    class TxtDialect:AccessDialect
    {
        public override bool SupportDelete
        {
            get
            {
                return false;
            }
        }

        public override bool SupportUpdate
        {
            get
            {
                return false;
            }
        }
    }
}
