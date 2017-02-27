using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMLogger.Loggers
{
    /// <summary>
    /// Logger's methods
    /// Inspired from org.slf4j.Logger interface.
    /// </summary>
    public interface ILoggerLog
    {
        /// <summary>
        /// To log with a log level
        /// </summary>
        /// <param name="msg"></param>
        void Log(string msg);

        /// <summary>
        /// To log with a log level
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="e"></param>
        void Log(string msg, Exception e);

        /// <summary>
        /// To log with an error level
        /// </summary>
        /// <param name="msg"></param>
        void Error(string msg);
        void Error(string msg, Exception e);

        /// <summary>
        /// To log with an Info level
        /// </summary>
        /// <param name="msg"></param>
        void Info(string msg);

        /// <summary>
        /// To log with a Info level
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="e"></param>
        void Info(string msg, Exception e);

        /// <summary>
        /// To log with a warm level
        /// </summary>
        /// <param name="msg"></param>
        void Warn(string msg);

        /// <summary>
        /// To log with a Warn level
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="e"></param>
        void Warn(string msg, Exception e);

        /// <summary>
        /// To log with a debug level
        /// </summary>
        /// <param name="msg"></param>
        void Debug(string msg);
        
        /// <summary>
        /// To log with a debug level
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="e"></param>
        void Debug(string msg, Exception e);

        /// <summary>
        /// To log with a Trace level
        /// </summary>
        /// <param name="msg"></param>
        void Trace(string msg);

        /// <summary>
        /// To log with a Trace level
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="e"></param>
        void Trace(string msg, Exception e);

        /// <summary>
        /// True if debug level is enable
        /// </summary>
        /// <returns></returns>
        bool isDebugEnabled();
        
        /// <summary>
        /// True if Error level is enable
        /// </summary>
        /// <returns></returns>                     
        bool isErrorEnabled();

        /// <summary>
        /// True if Info level is enable
        /// </summary>
        /// <returns></returns>
        bool isInfoEnabled();

        /// <summary>
        /// True if trace level is enable
        /// </summary>
        /// <returns></returns>
        bool isTraceEnabled();

        /// <summary>
        /// True if warn level is enable
        /// </summary>
        /// <returns></returns>
        bool isWarnEnabled();
    }
}
