using Logger.Interfaces;
using System;
using System.Collections.Generic;
using Logger.Utils;

namespace Logger.Loggers
{
    /// <summary>
    /// Logger manager
    /// </summary>
    public class LoggerManager : LoggerManagerBase
    {
        /// <summary>
        /// List of loggers
        /// </summary>
        public List<ILogger> Loggers { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        public LoggerManager()
        {
            Loggers = new List<ILogger>();
        }

        /// <summary>
        /// Get a logger from its name.
        /// Return null if any logger found with this name.
        /// </summary>	
        public ILogger GetLogger(string name)
        {
            return Loggers.Find(logger => logger.Name == name);
        }

        /// <summary>
        /// Create a ROOT logger from the class in parameter.
        /// The class must implement ILogger interface.
        /// </summary>
        public override ILogger CreateLogger(string name = "GM_LOGGER", Level level = Level.DEBUG, Type clazz = null) {

            ILogger logger = null;

            if (!Loggers.IsALoggerName(name))
            {             
                if (clazz == null)
                {
                    logger = new Logger(name, level, this);              
                }
                else if (clazz is ILogger)
                {
                    logger = (ILogger)Activator.CreateInstance(clazz, name, this);               
                }

                Loggers.Add(logger);
            } 
            return logger; 
        }

        /// <summary>
        /// Duplicate an existing logger.
        /// Return null if the source logger doesn't exist.
        /// </summary>
        public override ILogger DuplicateLogger(string name)
        { 
            ILogger srcLogger = Loggers.Find(logger => logger.Name == name);

            if (srcLogger != null)
            {
                // On regarde si des loggers on déjà été copiés à partir de ce logger
                int nbCopy = Loggers.FindAll(log => log.Parent == srcLogger.Name).Count;

                ILogger copyLogger = srcLogger.DeepCopy();
                copyLogger.Name = copyLogger.Name + "_" + (nbCopy + 1);
                copyLogger.Parent = srcLogger.Name;
                return copyLogger;
            }
            else
            {
                return null;
            }                 
        }

        /// <summary>
        /// Delete a logger from the list of loggers
        /// </summary>
        /// <param name="name"></param>
        /// <returns>true if success, false otherwise</returns>
        public bool Delete(string name)
        {
            ILogger logger = Loggers.Find(log => log.Name == name);
            return Loggers.Remove(logger);
        }

        /// <summary>
        /// Create a new Log
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="msg"></param>
        /// <param name="logAlerte"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public Log MakeLog(ILogger logger, string msg, Level logAlerte, Exception e = null)
        {
            return new Log(logger, msg, logAlerte, e);
        }
    }
}
