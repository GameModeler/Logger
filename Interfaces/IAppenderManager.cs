// <copyright file="IAppenderManager.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Logger.Interfaces
{
    using System;
    using System.Collections.Generic;
    using Logger.Utils;

    /// <summary>
    /// Appender manager
    /// </summary>
    public interface IAppenderManager
    {
        /// <summary>
        /// Gets list of appenders
        /// </summary>
        SynchronizedCollection<IAppender> AppenderList { get; }

        /// <summary>
        /// Add an appender to the list of appenders
        /// </summary>
        /// <param name="appender">The appender</param>
        /// <returns>IAppender</returns>
        IAppender AddAppender(IAppender appender);

        /// <summary>
        /// Detach an appender from the list of appenders 
        /// </summary>
        /// <param name="appender">The appender</param>
        void Detach(IAppender appender);

        /// <summary>
        /// Create an appender
        /// </summary>
        /// <param name="type">The type of appender</param>
        /// <param name="name">The name of the appender</param>
        /// <returns>IAppender</returns>
        IAppender CreateAppender(AppenderType type, string name);
    }
}
