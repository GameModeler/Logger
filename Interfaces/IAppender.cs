// <copyright file="IAppender.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Logger.Interfaces
{
    using System.Threading.Tasks;
    using Logger.Loggers;
    using Logger.Utils;

    /// <summary>
    /// Appender interface
    /// </summary>
    public interface IAppender
    {
        /// <summary>
        /// Gets or sets name of the appender
        /// </summary>
        string AppenderName { get; set; }

        /// <summary>
        /// Gets or sets layout of the appender
        /// </summary>
        string Layout { get; set; }

        /// <summary>
        /// Gets appender's type
        /// </summary>
        AppenderType AppenderType { get; }

        /// <summary>
        /// Append log
        /// </summary>
        /// <param name="log">The log</param>
        void DoAppend(ILog log);

        /// <summary>
        /// Append log asynchronously
        /// </summary>
        /// <param name="log">The log</param>
        /// <returns><see cref="Task"/> representing the asynchronous operation.</returns>
        Task DoAppendAsync(ILog log);
    }
}
