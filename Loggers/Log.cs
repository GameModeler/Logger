using DataBase.Database.Utils;
using Logger.Interfaces;
using Logger.Utils;
using System;
using System.Threading;

namespace Logger.Loggers
{
    /// <summary>
    /// A log
    /// </summary>
    [Persistent]
    public class Log : ILog
    {
        /// Add an id ?
        public int Id { get; set; }

        private static int nextId;

        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Timestamp
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Logger's name
        /// </summary>
        public string LoggerName { get; set;  }

        /// <summary>
        /// Exception
        /// </summary>
        public String Exception { get; set; }

        /// <summary>
        /// Thread's id
        /// </summary>
        public int ThreadId { get; set; }

        /// <summary>
        /// logger's class
        /// </summary>
        public string Clazz { get; set; }

        /// <summary>
        /// Log's level
        /// </summary>
        public Level Level { get; set; }

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

            Timestamp = DateTime.Now;
            ThreadId = Thread.CurrentThread.ManagedThreadId; // ?

            if(e != null)
            {
                Exception = e.StackTrace;
            }
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Log() {}
    }
}
