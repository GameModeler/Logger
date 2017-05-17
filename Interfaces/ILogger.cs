using Logger.Loggers;
using Logger.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Interfaces
{
    /// <summary>
    /// A logger
    /// </summary>
    public interface ILogger : ILoggerBase, ILoggerLog
    {

        /// Add an appender from AppenderType.
        /// </summary>
        IAppender AddAppender(AppenderType appenderType, string appenderName = null);

        /// <summary>
        /// Add an appender from AppenderType.
        /// </summary>
        IAppender AddAppender(AppenderType appenderType, Type type, string appenderName = null);

        /// <summary>
        /// Add an appender from a custom IAppender implementation.
        /// </summary>		l
        IAppender AddAppender(Type clazz, string appenderName = "");

        /// <summary>
        /// Reset the logger appanders
        /// </summary>
        void Reset();

        /// <summary>
        /// Remove appender from its name
        /// </summary>
        /// <param name="name"></param>
        void RemoveAppender(string name);

        /// <summary>
        /// Remove all appenders from the given type
        /// </summary>
        /// <param name="appenderType"></param>
        void RemoveAppender(AppenderType appenderType);

        /// <summary>
        /// Remove appender
        /// </summary>
        /// <param name="appender"></param>
        void RemoveAppender(IAppender appender);

        /// <summary>
        /// Call the appender from the logger
        /// </summary>
        /// <param name="log"></param>
        void CallAppenders(Log log);

        /// <summary>
        /// Call the appender from the logger
        /// </summary>
        /// <param name="log"></param>
        Task CallAppendersAsync(Log log);
    }
}
