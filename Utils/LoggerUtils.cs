using GMLogger.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace GMLogger.Utils
{
    /// <summary>
    /// Util class for the logger
    /// </summary>
    public static class LoggerUtils
    {
        /// <summary>
        /// Check if a name string matches a logger's name
        /// </summary>
        /// <param name="list"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool IsALoggerName(this List<ILogger> list, string name)
        { 
            return list.Any(li => li.Name == name);
        }

        /// <summary>
        /// Check if a name string matches an appender's name
        /// </summary>
        /// <param name="list"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool IsAnAppenderName(this SynchronizedCollection<IAppender> list, string name)
        {
            return list.Any(li => li.Name == name);
        }
    }
}
