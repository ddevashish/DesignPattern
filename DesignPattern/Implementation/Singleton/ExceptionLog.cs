using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DesignPattern.Implementation.Singleton
{
    public sealed class ExceptionLog
    {
        private ExceptionLog() { }

        private static ExceptionLog _instance = null;
        private static string logFilePath = string.Empty;
        private readonly static object obj = new object();

        public static ExceptionLog getInstance
        {
            get
            {
                if (_instance == null)
                {
                    lock (obj)
                    {
                        _instance = new ExceptionLog();
                    }
                }
                return _instance;
            }
        }

        public void LogExceptionMessage(string message)
        {
            Log log = Log.getInstance;
            log.LogMessage(message, true);
        }
    }

    public class ExceptionLogTest
    {
        public void LogExceptionMessageTest(string message)
        {
            ExceptionLog exceptionLog = ExceptionLog.getInstance;
            exceptionLog.LogExceptionMessage(message);
        }
    }
}
