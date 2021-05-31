using System;
using System.Text;
using System.IO;
using System.Configuration;

namespace DesignPattern.Implementation.Singleton
{
    public sealed class Log
    {
        private Log() { }

        private static Log _instance = null;
        private static string logFilePath = string.Empty;
        private static string exceptionLogFilePath = string.Empty;
        private readonly static object obj = new object();

        public static Log getInstance
        {
            get
            {
                if (_instance == null)
                {
                    lock (obj)
                    {
                        _instance = new Log();
                    }
                }
                return _instance;
            }
        }

        public void LogMessage(string message, bool isException = false)
        {
            logFilePath = ConfigurationManager.AppSettings["LogFilePath"].ToString();
            exceptionLogFilePath = ConfigurationManager.AppSettings["ExceptionLogFilePath"].ToString();
            string fileName = string.Format("{0}_{1}.log", isException? "Exception": "Log", DateTime.Now.ToShortDateString());
            string fullFileName = (isException ? exceptionLogFilePath : logFilePath) + "\\" + fileName;

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("----------------------------------------");
            stringBuilder.AppendLine(DateTime.Now.ToString());
            stringBuilder.AppendLine(message);

            using (StreamWriter writer = new StreamWriter(fullFileName, true))
            {
                writer.Write(stringBuilder.ToString());
                writer.Flush();
            }
        }
    }

    public class LogTest
    {
        public void LogMessageTest(string message)
        {
            Log log = Log.getInstance;
            log.LogMessage(message);
        }
    }
}
