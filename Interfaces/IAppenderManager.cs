using Logger.Utils;
using System;
using System.Collections.Generic;

namespace Logger.Interfaces
{
    /// <summary>
    /// Appender manager
    /// </summary>
    public interface IAppenderManager
    {
        /// <summary>
        /// List of appenders
        /// </summary>
        SynchronizedCollection<IAppender> AppenderList { get; }

        /// <summary>
        /// Add an appender to the list of appenders
        /// </summary>
        /// <param name="appender"></param>
        IAppender AddAppender(IAppender appender);

        /// <summary>
        /// Detach an appender from the list of appenders 
        /// </summary>
        /// <param name="appedner"></param>
        void Detach(IAppender appedner);

        /// <summary>
        /// Create an appender
        /// </summary>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        IAppender CreateAppender(AppenderType type, string name);
    }
}
