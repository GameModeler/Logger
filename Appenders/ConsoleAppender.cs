namespace Logger.Appenders
{
    using System;
    using System.Threading.Tasks;
    using Logger.Interfaces;
    using Logger.Loggers;
    using Logger.Utils;

    /// <summary>
    /// To display log into the console
    /// </summary>
    public class ConsoleAppender : IAppender
    {
        /// <summary>
        /// Default name of the appender
        /// </summary>
        private const string DEFAULT_CONSOLE_NAME = "GM_CONSOLE_APPENDER";

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleAppender"/> class.
        /// Constructor
        /// </summary>
        /// <param name="name">
        /// Name of the appender
        /// </param>
        public ConsoleAppender(string name)
        {
            this.Layout = LogPatternConstants.DEFAULT_PATTERN;
            this.AppenderName = string.IsNullOrEmpty(name) ? DEFAULT_CONSOLE_NAME : name;
        }

        /// <summary>
        /// Gets appender's type
        /// </summary>
        public AppenderType AppenderType { get; }

        /// <summary>
        /// Gets or sets name of the appender
        /// </summary>
        public string AppenderName { get; set; }

        /// <summary>
        /// Gets or sets layout of the appender
        /// </summary>
        public string Layout { get; set; }

        /// <summary>
        /// Appends the log
        /// </summary>
        /// <param name="log">The log</param>
        public void DoAppend(ILog log)
        {
            string toLog = LogPatterns.Reformate(this.Layout, log);
            Console.ForegroundColor = log.Level.GetColor();
            Console.WriteLine(toLog);
            this.ResetConsole();
        }

        /// <summary>
        /// Appends the log asynchronously
        /// </summary>
        /// <param name="log">The log</param>
        /// <returns><see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task DoAppendAsync(ILog log)
        {
            await Task.Run(() => {

                string toLog = LogPatterns.Reformate(Layout, log);
                Console.ForegroundColor = log.Level.GetColor();
                Console.WriteLine(toLog);
                this.ResetConsole();
            });
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
