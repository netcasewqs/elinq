using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NLite.Data.Exceptions
{
    static class DbExceptionLogger
    {
        public const string DefaultExceptionMsg = "SQL Exception";

        public static void Error(this ISqlLog log, Exception ex)
        {
            Error(log, ex, null);
        }

        public static void Error(this ISqlLog log, Exception ex, string message)
        {
            message =  message ?? DefaultExceptionMsg;
            log.LogMessage(message);
            ex = ex.InnerException;

            while (ex != null)
            {
                log.LogMessage(ex.Message);
                ex = ex.InnerException;
            }

            log.LogMessage(Environment.NewLine);
        }

    }
}
