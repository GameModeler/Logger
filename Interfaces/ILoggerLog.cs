using Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Loggers
{
    /// <summary>
    /// Logger's methods
    /// Inspired from org.slf4j.Logger interface.
    /// </summary>
    public interface ILoggerLog : ILoggerLogAsync, ILoggerLogSync
    {
        /// <summary>
        /// True if debug level is enabled
        /// </summary>
        /// <returns></returns>
        bool isDebugEnabled();

        /// <summary>
        /// True if error level is enabled
        /// </summary>
        /// <returns></returns>                    
        bool isErrorEnabled();

        /// <summary>
        /// True if info level is enabled
        /// </summary>
        /// <returns></returns>
        bool isInfoEnabled();

        /// <summary>
        /// True if trace level is enabled
        /// </summary>
        /// <returns></returns>
        bool isTraceEnabled();

        /// <summary>
        /// True if warn level is enabled
        /// </summary>
        /// <returns></returns>
        bool isWarnEnabled();
    }
}
