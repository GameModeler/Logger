namespace Logger.Loggers
{
    using System;
    using System.Threading;
    using DataBase.Database.Utils;
    using Interfaces;
    using Utils;

    /// <summary>
    /// A log
    /// </summary>
    [Persistent]
    public class Log : ILog
    {
        private static int nextId;

        /// <summary>
        /// Initializes a new instance of the <see cref="Log"/> class.
        /// </summary>
        /// <param name="logger">The logger</param>
        /// <param name="msg">The Message</param>
        /// <param name="logAlerte">Level</param>
        /// <param name="e">Exception</param>
        public Log(ILogger logger, string msg, Level logAlerte, Exception e)
        {
            this.Id = Interlocked.Increment(ref nextId);

            this.LoggerName = logger.Name;
            this.Clazz = logger.GetType().FullName;
            this.Level = logAlerte;
            this.Message = msg;

            this.Timestamp = DateTime.Now;
            this.ThreadId = Thread.CurrentThread.ManagedThreadId; // ?

            if (e != null)
            {
                this.Exception = e.StackTrace;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Log"/> class.
        /// </summary>
        public Log()
        {
        }

        /// <summary>
        /// Gets or sets id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets timestamp
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Gets or sets logger's name
        /// </summary>
        public string LoggerName { get; set;  }

        /// <summary>
        /// Gets or sets exception
        /// </summary>
        public string Exception { get; set; }

        /// <summary>
        /// Gets or sets thread's id
        /// </summary>
        public int ThreadId { get; set; }

        /// <summary>
        /// Gets or sets logger's class
        /// </summary>
        public string Clazz { get; set; }

        /// <summary>
        /// Gets or sets log's level
        /// </summary>
        public Level Level { get; set; }
    }
}
