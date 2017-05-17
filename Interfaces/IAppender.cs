using Logger.Loggers;
using Logger.Utils;
using System.Threading.Tasks;

namespace Logger.Interfaces
{
    /// <summary>
    /// Appender interface
    /// </summary>
    public interface IAppender
    {
        /// <summary>
        /// Name of the appender
        /// </summary>
        string AppenderName { get; set; }

        /// <summary>
        /// Layout of the appender
        /// </summary>
        string Layout { get; set; }

        /// <summary>
        /// Append log
        /// </summary>
        /// <param name="log"></param>
        void DoAppend(Log log);

        /// <summary>
        /// Append log asynchronously
        /// </summary>
        /// <param name="log"></param>
        Task DoAppendAsync(Log log);

        /// <summary>
        /// Appender's type
        /// </summary>
        AppenderType AppenderType { get; }

    }
}
