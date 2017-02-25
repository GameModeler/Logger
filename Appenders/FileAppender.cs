using GMLogger.Interfaces;
using GMLogger.Loggers;
using GMLogger.Utils;

namespace GMLogger.Appenders
{
    /// <summary>
    /// Display logs into file
    /// </summary>
    public class FileAppender : IAppender
    {

        public string Name { get; set; }
        public string FilePath { get; set; }

        private const string DEFAULT_FILE_APPENDER_NAME = "GM_FILE_APPENDER";
        private const string DEFAULT_FILE_NAME = @"C:\Users\gm_logger.txt";

        public string Layout { get; set; }

        public FileAppender(string appenderName)
        {
            Layout = LogPatternConstants.DEFAULT_PATTERN;
            Name = appenderName == null ? DEFAULT_FILE_APPENDER_NAME : appenderName;
            FilePath = DEFAULT_FILE_NAME;
        }

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
