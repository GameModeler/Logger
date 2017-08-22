// <copyright file="LoggerManager.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Logger.Loggers
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using Utils;

    /// <summary>
    /// Logger manager
    /// </summary>
    public class LoggerManager : LoggerManagerBase
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="LoggerManager"/> class.
        /// </summary>
        public LoggerManager()
        {
            this.Loggers = new List<ILogger>();
        }

        /// <summary>
        /// Gets list of loggers
        /// </summary>
        public List<ILogger> Loggers { get; }

        /// <summary>
        /// Get a logger from its name.
        /// Return null if any logger found with this name.
        /// </summary>
        /// <param name="name">Logger name</param>
        /// <returns>ILogger</returns>
        public ILogger GetLogger(string name)
        {
            return this.Loggers.Find(logger => logger.Name == name);
        }

        /// <summary>
        /// Create a ROOT logger from the class in parameter.
        /// The class must implement ILogger interface.
        /// </summary>
        /// <param name="name">Logger name</param>
        /// <param name="level">Level</param>
        /// <param name="clazz">Class</param>
        /// <returns>ILogger</returns>
        public override ILogger CreateLogger(string name = "GM_LOGGER", Level level = Level.INFO, Type clazz = null) {

            ILogger logger = null;

            if (!this.Loggers.IsALoggerName(name))
            {
                if (clazz == null)
                {
                    logger = new Logger(name, level, this);
                }
                else if (clazz is ILogger)
                {
                    logger = (ILogger)Activator.CreateInstance(clazz, name, this);
                }

                this.Loggers.Add(logger);
            }

            return logger;
        }

        /// <summary>
        /// Duplicate an existing logger.
        /// Return null if the source logger doesn't exist.
        /// </summary>
        /// <param name="name">Logger name</param>
        /// <returns>ILogger</returns>
        public override ILogger DuplicateLogger(string name)
        {
            ILogger srcLogger = this.Loggers.Find(logger => logger.Name == name);

            if (srcLogger != null)
            {
                // On regarde si des loggers on déjà été copiés à partir de ce logger
                int nbCopy = this.Loggers.FindAll(log => log.Parent == srcLogger.Name).Count;

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
        /// <param name="name">Logger's name</param>
        /// <returns>true if success, false otherwise</returns>
        public bool Delete(string name)
        {
            ILogger logger = this.Loggers.Find(log => log.Name == name);
            return this.Loggers.Remove(logger);
        }

        /// <summary>
        /// Create a new Log
        /// </summary>
        /// <param name="logger">The logger</param>
        /// <param name="msg">the message</param>
        /// <param name="logAlerte">The level</param>
        /// <param name="e">The exception</param>
        /// <returns>Log</returns>
        public Log MakeLog(ILogger logger, string msg, Level logAlerte, Exception e = null)
        {
            return new Log(logger, msg, logAlerte, e);
        }
    }
}
