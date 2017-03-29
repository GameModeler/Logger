using Logger.Interfaces;
using Logger.Utils;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;

namespace Logger.Loggers
{
    /// <summary>
    /// A log
    /// </summary>
    public class Log : ILog
    {
        /// Add an id ?
        public int Id { get; set; }

        private static int nextId;

        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// Timestamp
        /// </summary>
        public DateTime Timestamp { get; private set; }

        /// <summary>
        /// Logger's name
        /// </summary>
        public string LoggerName { get; private set;  }

        /// <summary>
        /// Exception
        /// </summary>
        public Exception Exception { get; private set; }

        /// <summary>
        /// Thread's id
        /// </summary>
        public int ThreadId { get; private set; }

        /// <summary>
        /// logger's class
        /// </summary>
        public string Clazz { get; private set; }

        /// <summary>
        /// Log's level
        /// </summary>
        public Level Level { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="msg"></param>
        /// <param name="logAlerte"></param>
        /// <param name="e"></param>
        public Log(ILogger logger, string msg, Level logAlerte, Exception e)
        {
            Id = Interlocked.Increment(ref nextId);

            LoggerName = logger.Name;
            Clazz = logger.GetType().FullName;
            Level = logAlerte;
            Message = msg;
            Exception = e;
            Timestamp = DateTime.Now;
            ThreadId = Thread.CurrentThread.ManagedThreadId; // ?

        }
    }
}
