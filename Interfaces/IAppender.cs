using Logger.Loggers;

namespace Logger.Interfaces
{
    public interface IAppender
    {
        /// <summary>
        /// Name of the appender
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Layout of the appender
        /// </summary>
        string Layout { get; set; }

        /// <summary>
        /// Append log
        /// </summary>
        /// <param name="log"></param>
        void DoAppend(Log log);

    }
}
