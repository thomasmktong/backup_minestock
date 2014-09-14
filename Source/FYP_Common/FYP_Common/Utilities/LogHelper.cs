using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FYP_Common
{
    public class LogHelper
    {
        // class level
        private static Dictionary<Type, LogHelper> loggers = new Dictionary<Type, LogHelper>();

        public static LogHelper NewLogger(Type type, String logPath)
        {
            LogHelper logHelper = null;

            if (loggers.TryGetValue(type, out logHelper))
            {
                loggers.Remove(type);
                logHelper.sw.Close();
            }

            try
            {
                logHelper = new LogHelper();
                logHelper.sw = new StreamWriter(logPath + "\\" + type.Name + "_" + String.Format("{0:yyyyMMddHHmmss}", DateTime.Now) + ".log");
                logHelper.Log("LOGGER: Logger instance for " + type.FullName + " initiated\n\n");

                loggers.Add(type, logHelper);
            }
            catch (Exception ex)
            {
                // do nothing
            }

            return logHelper;
        }

        public static LogHelper GetLogger(Type type)
        {
            LogHelper logHelper;

            if (loggers.TryGetValue(type, out logHelper))
            {
                return logHelper;
            }
            else
            {
                return null;
            }
        }

        // object level
        private StreamWriter sw;

        public void Log(string message)
        {
            if (message.Contains("\n")) sw.WriteLine();
            sw.WriteLine(message);
            sw.Flush();
        }

        public void FullLog(string msg, string level)
        {
            sw.WriteLine("[" + level + "] " + DateTime.Now.ToString());
            sw.WriteLine(msg);
            sw.WriteLine();
        }
    }
}
