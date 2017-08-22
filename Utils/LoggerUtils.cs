// <copyright file="LoggerUtils.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Logger.Utils
{
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;

    /// <summary>
    /// Logger Utils
    /// </summary>
    public static class LoggerUtils
    {
        /// <summary>
        /// Tests if a logger with the given name already exists
        /// </summary>
        /// <param name="list">ILogger list</param>
        /// <param name="name">Name of the logger to test</param>
        /// <returns>bool</returns>
        public static bool IsALoggerName(this List<ILogger> list, string name)
        {
            return list.Any(li => li.Name == name);
        }

        /// <summary>
        /// Tests if an appender with the given name already exixts
        /// </summary>
        /// <param name="list">List of appender</param>
        /// <param name="name">Name of the appender to test</param>
        /// <returns>bool</returns>
        public static bool IsAnAppenderName(this SynchronizedCollection<IAppender> list, string name)
        {
            return list.Any(li => li.AppenderName == name);
        }
    }
}
