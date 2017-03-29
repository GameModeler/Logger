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
    public interface ILoggerLog
    {
        /// <summary>
        /// Log a log with log level
        /// </summary>
        /// <param name="msg"></param>
        void Log(string msg);

        /// <summary>
        /// Log a log with log level
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="e"></param>
        void Log(string msg, Exception e);

        /// <summary>
        /// Logs a log with error level
        /// </summary>
        /// <param name="msg"></param>
        void Error(string msg);

        /// <summary>
        /// Logs a log with error level
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="e"></param>
        void Error(string msg, Exception e);

        /// <summary>
        /// Logs a log with info level
        /// </summary>
        /// <param name="msg"></param>
        void Info(string msg);

        /// <summary>
        /// Logs a log with info level
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="e"></param>
        void Info(string msg, Exception e);

        /// <summary>
        /// Logs a log with warn level
        /// </summary>
        /// <param name="msg"></param>
        void Warn(string msg);

        /// <summary>
        /// Logs a log with warn level
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="e"></param>
        void Warn(string msg, Exception e);

        /// <summary>
        /// Logs a log with debug level
        /// </summary>
        /// <param name="msg"></param>
        void Debug(string msg);

        /// <summary>
        /// Logs a log with debug level
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="e"></param>
        void Debug(string msg, Exception e);

        /// <summary>
        /// Logs a log with trace level
        /// </summary>
        /// <param name="msg"></param>
        void Trace(string msg);

        /// <summary>
        /// Logs a log with trace level
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="e"></param>
        void Trace(string msg, Exception e);

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
