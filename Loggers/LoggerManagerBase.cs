using GMLogger.Interfaces;
using GMLogger.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMLogger.Loggers
{
    /// <summary>
    /// Logger Manager Base
    /// </summary>
    public abstract class LoggerManagerBase
    {
        /// <summary>
        /// Create a logger
        /// </summary>
        /// <param name="name"></param>
        /// <param name="level"></param>
        /// <param name="clazz"></param>
        /// <returns></returns>
        public abstract ILogger CreateLogger(string name, Level level, Type clazz);

        /// <summary>
        /// Duplicate a logger
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public abstract ILogger DuplicateLogger(string name);
    }
}
