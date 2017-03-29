using Logger.Interfaces;
using Logger.Utils;
using System;
using System.ComponentModel.DataAnnotations;
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

        public string Message { get; private set; }

        [NotMapped]
        public DateTime Timestamp { get; private set; }
        public string LoggerName { get; private set;  }

        [NotMapped]
        public Exception Exception { get; private set; }
        public int ThreadId { get; private set; }
        public string Clazz { get; private set; }

        [NotMapped]
        public Level Level { get; private set; }

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
