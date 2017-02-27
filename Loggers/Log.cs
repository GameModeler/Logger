using GMLogger.Interfaces;
using GMLogger.Utils;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;

namespace GMLogger.Loggers
{
    /// <summary>
    /// A log
    /// </summary>
    public class Log : ILog
    {
        /// <summary>
        /// Log's Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Next Id to increment id for the next log
        /// </summary>
        private static int nextId;

        /// <summary>
        /// Log's message
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// Log's timestamp
        /// </summary>
        [NotMapped]
        public DateTime Timestamp { get; private set; }

        /// <summary>
        /// Log's logger's name
        /// </summary>
        public string LoggerName { get; private set;  }

        /// <summary>
        /// Log's Exception
        /// </summary>
        [NotMapped]
        public Exception Exception { get; private set; }

        /// <summary>
        /// Log's thread's id
        /// </summary>
        public int ThreadId { get; private set; }

        /// <summary>
        /// Log's clazz
        /// </summary>
        public string Clazz { get; private set; }

        /// <summary>
        /// Log's level
        /// </summary>
        [NotMapped]
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
