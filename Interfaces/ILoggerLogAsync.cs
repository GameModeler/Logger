﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Interfaces
{
    /// <summary>
    /// Async log methods
    /// </summary>
    public interface ILoggerLogAsync
    {

        /// <summary>
        /// Log a log with log level
        /// </summary>
        /// <param name="msg"></param>
        Task LogAsync(string msg);

        /// <summary>
        /// Log a log with log level
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="e"></param>
        Task LogAsync(string msg, Exception e);

        /// <summary>
        /// Logs a log with error level
        /// </summary>
        /// <param name="msg"></param>
        Task ErrorAsync(string msg);

        /// <summary>
        /// Logs a log with error level
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="e"></param>
        Task ErrorAsync(string msg, Exception e);

        /// <summary>
        /// Logs a log with info level
        /// </summary>
        /// <param name="msg"></param>
        Task InfoAsync(string msg);

        /// <summary>
        /// Logs a log with info level
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="e"></param>
        Task InfoAsync(string msg, Exception e);

        /// <summary>
        /// Logs a log with warn level
        /// </summary>
        /// <param name="msg"></param>
        Task WarnAsync(string msg);

        /// <summary>
        /// Logs a log with warn level
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="e"></param>
        Task WarnAsync(string msg, Exception e);

        /// <summary>
        /// Logs a log with debug level
        /// </summary>
        /// <param name="msg"></param>
        Task DebugAsync(string msg);

        /// <summary>
        /// Logs a log with debug level
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="e"></param>
        Task DebugAsync(string msg, Exception e);

        /// <summary>
        /// Logs a log with trace level
        /// </summary>
        /// <param name="msg"></param>
        Task TraceAsync(string msg);

        /// <summary>
        /// Logs a log with trace level
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="e"></param>
        Task TraceAsync(string msg, Exception e);
    }
}
