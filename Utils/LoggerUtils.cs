using GMLogger.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace GMLogger.Utils
{
    public static class LoggerUtils
    {
        public static bool IsALoggerName(this List<ILogger> list, string name)
        { 
            return list.Any(li => li.Name == name);
        }

        public static bool IsAnAppenderName(this SynchronizedCollection<IAppender> list, string name)
        {
            return list.Any(li => li.Name == name);
        }
    }
}
