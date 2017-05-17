using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Interfaces
{
    /// <summary>
    /// Async log methods
    /// </summary>
    public interface ILoggerLogAsync : ILoggerLogBase
    {

        /// <summary>
        /// Log a log with log level
        /// </summary>
        /// <param name="msg"></param>
        Task<bool> LogAsync(string msg);

        /// <summary>
        /// Log a log with log level
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="e"></param>
        Task<bool> LogAsync(string msg, Exception e);

        /// <summary>
        /// Logs a log with error level
        /// </summary>
        /// <param name="msg"></param>
        Task<bool> ErrorAsync(string msg);

        /// <summary>
        /// Logs a log with error level
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="e"></param>
        Task<bool> ErrorAsync(string msg, Exception e);

        /// <summary>
        /// Logs a log with info level
        /// </summary>
        /// <param name="msg"></param>
        Task<bool> InfoAsync(string msg);

        /// <summary>
        /// Logs a log with info level
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="e"></param>
        Task<bool> InfoAsync(string msg, Exception e);

        /// <summary>
        /// Logs a log with warn level
        /// </summary>
        /// <param name="msg"></param>
        Task<bool> WarnAsync(string msg);

        /// <summary>
        /// Logs a log with warn level
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="e"></param>
        Task<bool> WarnAsync(string msg, Exception e);

        /// <summary>
        /// Logs a log with debug level
        /// </summary>
        /// <param name="msg"></param>
        Task<bool> DebugAsync(string msg);

        /// <summary>
        /// Logs a log with debug level
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="e"></param>
        Task<bool> DebugAsync(string msg, Exception e);

        /// <summary>
        /// Logs a log with trace level
        /// </summary>
        /// <param name="msg"></param>
        Task<bool> TraceAsync(string msg);

        /// <summary>
        /// Logs a log with trace level
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="e"></param>
        Task<bool> TraceAsync(string msg, Exception e);
    }
}
