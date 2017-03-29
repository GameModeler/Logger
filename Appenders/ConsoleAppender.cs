using Logger.Interfaces;
using Logger.Loggers;
using Logger.Utils;
using System;

namespace Logger.Appenders
{
    /// <summary>
    /// To display log into the console
    /// </summary>
    public class ConsoleAppender : IAppender
    {
        /// <summary>
        /// Name of the appender
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Default name of the appender
        /// </summary>
        private const string DEFAULT_CONSOLE_NAME = "GM_CONSOLE_APPENDER";

        /// <summary>
        /// Layout of the appender
        /// </summary>
        public string Layout { get; set ;}
    
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">
        /// Name of the appender
        /// </param>
        public ConsoleAppender(string name)
        {
            Layout = LogPatternConstants.DEFAULT_PATTERN;
            Name = name == null ? DEFAULT_CONSOLE_NAME : name;
        }

        /// <summary>
        /// Append the log
        /// </summary>
        /// <param name="log"></param>
        public void DoAppend(Log log)
        {
            string toLog = LogPatterns.Reformate(Layout, log);
            Console.ForegroundColor = log.Level.GetColor();
            Console.WriteLine(toLog);
            ResetConsole();
        }

        /// <summary>
        /// Reset console parameters
        /// </summary>
        private void ResetConsole()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
