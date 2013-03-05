using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NLite.Data.Driver
{
    class OracleDriver:AbstractDriver
    {

        public override char NamedPrefix
        {
            get { return ':'; }
        }

    }
}
