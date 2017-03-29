using Logger.Interfaces;
using Logger.Loggers;
using Logger.Utils;

namespace Logger.Appenders
{
    /// <summary>
    /// Display logs into file
    /// </summary>
    public class FileAppender : IAppender
    {
        /// <summary>
        /// Appender name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Appender File Path
        /// </summary>
        public string FilePath { get; set; }

        private const string DEFAULT_FILE_APPENDER_NAME = "GM_FILE_APPENDER";
        private const string DEFAULT_FILE_NAME = @"C:\Users\gm_logger.txt";

        /// <summary>
        /// Log layout
        /// </summary>
        public string Layout { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="appenderName"></param>
        public FileAppender(string appenderName)
        {
            Layout = LogPatternConstants.DEFAULT_PATTERN;
            Name = appenderName == null ? DEFAULT_FILE_APPENDER_NAME : appenderName;
            FilePath = DEFAULT_FILE_NAME;
        }

        /// <summary>
        /// Appends the log
        /// </summary>
        /// <param name="log"></param>
        public void DoAppend(Log log)
        {
            string toLog = LogPatterns.Reformate(Layout, log);

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(FilePath, true))
            {
                file.WriteLine(toLog);
            }
        }
    }
}
