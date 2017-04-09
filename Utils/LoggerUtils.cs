using Logger.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Logger.Utils
{
    /// <summary>
    /// Logger Utils
    /// </summary>
    public static class LoggerUtils
    {
        /// <summary>
        /// Tests if a logger with the given name already exists
        /// </summary>
        /// <param name="list"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool IsALoggerName(this List<ILogger> list, string name)
        { 
            return list.Any(li => li.Name == name);
        }

        /// <summary>
        /// Tests if an appender with the given name already exixts
        /// </summary>
        /// <param name="list"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool IsAnAppenderName(this SynchronizedCollection<IAppender> list, string name)
        {
            return list.Any(li => li.AppenderName == name);
        }
    }
}
