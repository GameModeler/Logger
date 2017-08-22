// <copyright file="Logger.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Logger.Loggers
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Appenders;
    using Interfaces;
    using Utils;

    /// <summary>
    /// A Logger.
    /// </summary>
    public class Logger : ILogger
    {
        private const Level DEFAULT_LEVEL = Level.INFO;

        private static int nextId;

        /// <summary>
        /// Initializes a new instance of the <see cref="Logger"/> class.
        /// Private constructor.
        /// Use LoggerFactory to get a new instance of a logger. 
        /// </summary>
        /// <param name="name">Name of the loggr</param>
        /// <param name="level">Level</param>
        /// <param name="loggerManager">Logger manager</param>
        public Logger(string name, Level level, LoggerManager loggerManager)
        {
            this.Id = Interlocked.Increment(ref nextId);
            this.LoggerManager = loggerManager;
            this.AppenderManager = new AppenderManager(this);
            this.Name = name;
            this.Level = level;
        }

        /// <summary>
        /// Gets or sets parent logger
        /// </summary>
        public string Parent { get; set; }

        /// <summary>
        /// Gets logger's Id
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Gets or sets the name of this logger.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the assigned levelInt of this logger.
        /// Can be null.
        /// If null, a level is inherited from a parent.
        /// </summary>
        public Level Level { get; set; }

        /// <summary>
        /// Gets the logger Manager
        /// </summary>
        public LoggerManager LoggerManager { get; }

        /// <summary>
        /// Gets list of appenders.
        /// </summary>
        public AppenderManager AppenderManager { get; }

        /// <summary>
        /// Add an appender from AppenderType.
        /// </summary>
        /// <param name="appenderType">Type of the appender</param>
        /// <param name="appenderName">Name of the appender</param>
        /// <returns>IAppender</returns>
        public IAppender AddAppender(AppenderType appenderType, string appenderName = null)
        {
            return this.AppenderManager.AddAppender(appenderType, appenderName);
        }

        /// <summary>
        /// Add an appender from AppenderType.
        /// </summary>
        /// <param name="appenderType">Type of the appender</param>
        /// <param name="type">Type</param>
        /// <param name="appenderName">Name of the appender</param>
        /// <returns>IAppender</returns>
        public IAppender AddAppender(AppenderType appenderType, Type type, string appenderName = null)
        {
            return this.AppenderManager.AddAppender(appenderType, type, appenderName);
        }


        /// <summary>
        /// Add an appender from a custom IAppender implementation.
        /// </summary>
        /// <param name="clazz">Class of the appender</param>
        /// <param name="appenderName">Name of the appender</param>
        /// <returns>IAppender</returns>
        public IAppender AddAppender(Type clazz, string appenderName = "")
        {
            return this.AppenderManager.AddAppender(clazz, appenderName);
        }

        /// <summary>
        /// Reset the logger appanders
        /// </summary>
        public void Reset()
        {
            this.AppenderManager.AppenderList.Clear();
            this.Level = DEFAULT_LEVEL;
        }

        /// <summary>
        /// Remove appender from its name
        /// </summary>
        /// <param name="name">Name of the appender to remove</param>
        public void RemoveAppender(string name)
        {
            this.AppenderManager.Detach(name);
        }

        /// <summary>
        /// Remove all appenders from the given type
        /// </summary>
        /// <param name="appenderType">Type of appender to remove</param>
        public void RemoveAppender(AppenderType appenderType)
        {
            this.AppenderManager.Detach(appenderType);
        }

        /// <summary>
        /// Remove appender
        /// </summary>
        /// <param name="appender">Appender</param>
        public void RemoveAppender(IAppender appender)
        {
            this.AppenderManager.Detach(appender);
        }

        /// <summary>
        /// Call the appender from the logger
        /// </summary>
        /// <param name="log">Log</param>
        public void CallAppenders(Log log)
        {
            foreach (IAppender appender in this.AppenderManager.AppenderList)
            {
                // Dispay the log for each appender of the logger
                appender.DoAppend(log);
            }
        }

        /// <summary>
        /// Call the appender from the logger
        /// </summary>
        /// <param name="log">Log</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task CallAppendersAsync(Log log)
        {
            foreach (IAppender appender in this.AppenderManager.AppenderList)
            {
                // Dispay the log for each appender of the logger
                await appender.DoAppendAsync(log);
            }
        }

        /// <summary>
        /// Log a log with a message
        /// </summary>
        /// <param name="msg">Message</param>
        public void Log(string msg)
        {
            Log log = this.LoggerManager.MakeLog(this, msg, Level.LOG, null);
            this.CallAppenders(log);

        }

        /// <summary>
        /// Log a log with message and exception
        /// </summary>
        /// <param name="msg">Message</param>
        /// <param name="e">Exception</param>
        public void Log(string msg, Exception e)
        {
            Log log = this.LoggerManager.MakeLog(this, msg, Level.LOG, e);
            this.CallAppenders(log);
        }


        /// <summary>
        /// Log a log error with message
        /// </summary>
        /// <param name="msg">Message</param>
        public void Error(string msg)
        {
            if (this.Level <= Level.ERROR)
            {
                Log log = this.LoggerManager.MakeLog(this, msg, Level.ERROR, null);
                this.CallAppenders(log);
            }
        }


        /// <summary>
        /// Log a log error with message and exception
        /// </summary>
        /// <param name="msg">Message</param>
        /// <param name="e">Exception</param>
        public void Error(string msg, Exception e)
        {
            if (this.Level <= Level.ERROR)
            {
                Log log = this.LoggerManager.MakeLog(this, msg, Level.ERROR, e);
                this.CallAppenders(log);
            }
        }

        /// <summary>
        /// Log a log info with message
        /// </summary>
        /// <param name="msg">Message</param>
        public void Info(string msg)
        {
            if (this.Level <= Level.INFO)
            {
                Log log = this.LoggerManager.MakeLog(this, msg, Level.INFO, null);
                this.CallAppenders(log);
            }
        }

        /// <summary>
        /// Log a log info with message and exception
        /// </summary>
        /// <param name="msg">Message</param>
        /// <param name="e">Exception</param>
        public void Info(string msg, Exception e)
        {
            if (this.Level <= Level.INFO)
            {
                Log log = this.LoggerManager.MakeLog(this, msg, Level.INFO, e);
                this.CallAppenders(log);
            }
        }


        /// <summary>
        /// Log a warn log with message
        /// </summary>
        /// <param name="msg">Message</param>
        public void Warn(string msg)
        {
            if (this.Level <= Level.WARN)
            {
                Log log = this.LoggerManager.MakeLog(this, msg, Level.WARN, null);
                this.CallAppenders(log);
            }
        }

        /// <summary>
        /// Log a warn log with message and exception
        /// </summary>
        /// <param name="msg">Message</param>
        /// <param name="e">Exception</param>
        public void Warn(string msg, Exception e)
        {
            if (this.Level <= Level.WARN)
            {
                Log log = this.LoggerManager.MakeLog(this, msg, Level.WARN, e);
                this.CallAppenders(log);
            }
        }

        /// <summary>
        /// Log a log debug with message
        /// </summary>
        /// <param name="msg">Message</param>
        public void Debug(string msg)
        {
            if (this.Level <= Level.DEBUG)
            {
                Log log = this.LoggerManager.MakeLog(this, msg, Level.DEBUG, null);
                this.CallAppenders(log);
            }
        }

        /// <summary>
        /// Log a log debug with message and exception
        /// </summary>
        /// <param name="msg">Message</param>
        /// <param name="e">Exception</param>
        public void Debug(string msg, Exception e)
        {
            if (this.Level <= Level.DEBUG)
            {
                Log log = this.LoggerManager.MakeLog(this, msg, Level.DEBUG, e);
                this.CallAppenders(log);
            }
        }


        /// <summary>
        /// Log a log trace with message
        /// </summary>
        /// <param name="msg">Message</param>
        public void Trace(string msg)
        {
            if (Level <= Level.TRACE)
            {
                Log log = LoggerManager.MakeLog(this, msg, Level.TRACE, null);
                CallAppenders(log);
            }
        }

        /// <summary>
        /// Log a log trace with message and exception
        /// </summary>
        /// <param name="msg">Message</param>
        /// <param name="e">Exception</param>
        public void Trace(string msg, Exception e)
        {
            if (Level <= Level.TRACE)
            {
                Log log = LoggerManager.MakeLog(this, msg, Level.TRACE, e);
                CallAppenders(log);
            }
        }

        /// <summary>
        /// Return true if Debug level is enabled
        /// </summary>
        /// <returns>bool</returns>
        public bool isDebugEnabled()
        {
            return this.Level == Level.DEBUG;
        }

        /// <summary>
        /// Return true if Error level is enabled
        /// </summary>
        /// <returns>bool</returns>
        public bool isErrorEnabled()
        {
            return this.Level == Level.ERROR;
        }

        /// <summary>
        /// Return true if Info level is enabled
        /// </summary>
        /// <returns>bool</returns>
        public bool isInfoEnabled()
        {
            return this.Level == Level.INFO;
        }

        /// <summary>
        /// Return true if Trace level is enabled
        /// </summary>
        /// <returns>bool</returns>
        public bool isTraceEnabled()
        {
            return this.Level == Level.TRACE;
        }

        /// <summary>
        /// Return true if Warn level is enabled
        /// </summary>
        /// <returns>bool</returns>
        public bool isWarnEnabled()
        {
            return this.Level == Level.WARN;
        }

        /// <summary>
        /// Make a deep copy of the logger
        /// </summary>
        /// <returns>ILogger</returns>
        public ILogger DeepCopy()
        {
            ILogger copyLogger = (Logger)this.MemberwiseClone();
            return copyLogger;
        }

        /// <summary>
        /// Log a log with a message asynchronously
        /// </summary>
        /// <param name="msg">Message</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task LogAsync(string msg)
        {
            Log log = LoggerManager.MakeLog(this, msg, Level.LOG, null);
            await CallAppendersAsync(log);

        }

        /// <summary>
        /// Log a log with message and exception asynchronously
        /// </summary>
        /// <param name="msg">Message</param>
        /// <param name="e">Exception</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task LogAsync(string msg, Exception e)
        {
            Log log = LoggerManager.MakeLog(this, msg, Level.LOG, e);
            await CallAppendersAsync(log);
        }

        /// <summary>
        /// Log a log error with message asynchronously
        /// </summary>
        /// <param name="msg">Message</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task ErrorAsync(string msg)
        {
            if (Level <= Level.ERROR)
            {
                Log log = LoggerManager.MakeLog(this, msg, Level.ERROR, null);
                await CallAppendersAsync(log);
            }
        }


        /// <summary>
        /// Log a log error with message and exception asynchronously
        /// </summary>
        /// <param name="msg">Message</param>
        /// <param name="e">Exception</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task ErrorAsync(string msg, Exception e)
        {
            if (Level <= Level.ERROR)
            {
                Log log = LoggerManager.MakeLog(this, msg, Level.ERROR, e);
                await CallAppendersAsync(log);
            }
        }

        /// <summary>
        /// Log a log info with message asynchronously
        /// </summary>
        /// <param name="msg">Message</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task InfoAsync(string msg)
        {
            if (Level <= Level.INFO)
            {
                Log log = LoggerManager.MakeLog(this, msg, Level.INFO, null);
                await CallAppendersAsync(log);
            }
        }

        /// <summary>
        /// Log a log info with message and asynchronously
        /// </summary>
        /// <param name="msg">Message</param>
        /// <param name="e">Exception</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task InfoAsync(string msg, Exception e)
        {
            if (Level <= Level.INFO)
            {
                Log log = LoggerManager.MakeLog(this, msg, Level.INFO, e);
               await CallAppendersAsync(log);
            }
        }


        /// <summary>
        /// Log a warn log with message asynchronously
        /// </summary>
        /// <param name="msg">Message</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task WarnAsync(string msg)
        {
            if (Level <= Level.WARN)
            {
                Log log = LoggerManager.MakeLog(this, msg, Level.WARN, null);
                await CallAppendersAsync(log);
            }
        }

        /// <summary>
        /// Log a warn log with message and exception asynchronously
        /// </summary>
        /// <param name="msg">Message</param>
        /// <param name="e">Exception</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task WarnAsync(string msg, Exception e)
        {
            if (Level <= Level.WARN)
            {
                Log log = LoggerManager.MakeLog(this, msg, Level.WARN, e);
                await CallAppendersAsync(log);
            }
        }

        /// <summary>
        /// Log a log debug with message asynchronously
        /// </summary>
        /// <param name="msg">Message</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task DebugAsync(string msg)
        {
            if (Level <= Level.DEBUG)
            {
                Log log = LoggerManager.MakeLog(this, msg, Level.DEBUG, null);
                await CallAppendersAsync(log);
            }
        }

        /// <summary>
        /// Log a log debug with message and exception asynchronously
        /// </summary>
        /// <param name="msg">Message</param>
        /// <param name="e">Exception</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task DebugAsync(string msg, Exception e)
        {
            if (Level <= Level.DEBUG)
            {
                Log log = LoggerManager.MakeLog(this, msg, Level.DEBUG, e);
                await CallAppendersAsync(log);
            }
        }


        /// <summary>
        /// Log a log trace with message asynchronously
        /// </summary>
        /// <param name="msg">Message</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task TraceAsync(string msg)
        {
            if (Level <= Level.TRACE)
            {
                Log log = LoggerManager.MakeLog(this, msg, Level.TRACE, null);
                await CallAppendersAsync(log);
            }
        }

        /// <summary>
        /// Log a log trace with message and exception asynchronously
        /// </summary>
        /// <param name="msg">Message</param>
        /// <param name="e">Exception</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task TraceAsync(string msg, Exception e)
        {
            if (Level <= Level.TRACE)
            {
                Log log = LoggerManager.MakeLog(this, msg, Level.TRACE, e);
                await CallAppendersAsync(log);
            }
        }
    }
}
