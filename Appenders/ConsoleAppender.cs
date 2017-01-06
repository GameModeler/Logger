using GMLogger.Interfaces;
using GMLogger.Loggers;
using GMLogger.Utils;
using System;

namespace GMLogger.Appenders
{
    /// <summary>
    /// To display log into the console
    /// </summary>
    public class ConsoleAppender : IAppender
    {
        public string Name { get; set; }

        private const string DEFAULT_CONSOLE_NAME = "GM_CONSOLE_APPENDER";

        public string Layout { get; set ;}
    
        public ConsoleAppender(string name)
        {
            Layout = LogPatternConstants.DEFAULT_PATTERN;
            Name = name == null ? DEFAULT_CONSOLE_NAME : name;
        }

        public void DoAppend(Log log)
        {
            string toLog = LogPatterns.Reformate(Layout, log);
            Console.ForegroundColor = log.Level.GetColor();
            Console.WriteLine(toLog);
            //Console.ResetColor();
            ResetConsole();
        }

        private void ResetConsole()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
