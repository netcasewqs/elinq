using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security;
using System.Runtime.Serialization;

namespace NLite.Data
{
    public class ProjectionException:DatabaseException
    {
        public ProjectionException() { }
      
        public ProjectionException(string message) { }
        [SecuritySafeCritical]
        protected ProjectionException(SerializationInfo info, StreamingContext context) { }
        public ProjectionException(string message, Exception innerException) { }
    }
}
