// <copyright file="LoggerManagerBase.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Logger.Loggers
{
    using System;
    using Interfaces;
    using Utils;

    /// <summary>
    /// LoggerManagerBase
    /// </summary>
    public abstract class LoggerManagerBase
    {
        /// <summary>
        /// Create a logger
        /// </summary>
        /// <param name="name">Name of the logger</param>
        /// <param name="level">Level</param>
        /// <param name="clazz">Class</param>
        /// <returns>ILogger</returns>
        public abstract ILogger CreateLogger(string name, Level level, Type clazz);

        /// <summary>
        /// Duplicate a logger
        /// </summary>
        /// <param name="name">Name of the logger</param>
        /// <returns>ILogger</returns>
        public abstract ILogger DuplicateLogger(string name);
    }
}
