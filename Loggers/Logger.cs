using Logger.Appenders;
using Logger.Interfaces;
using Logger.Utils;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Logger.Loggers
{
    /// <summary>
    /// A Logger.
    /// </summary>
    public class Logger : ILogger
    { 
     
        private const string DEFAULT_NAME = "GM_LOGGER";
        private const Level DEFAULT_LEVEL = Level.TRACE;

        private static int nextId;

        /// <summary>
        /// Parent logger
        /// </summary>
        public string Parent { get; set; }

        /// <summary>
        /// Logger's Id
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// The name of this logger.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The assigned levelInt of this logger.
        /// Can be null.
		/// If null, a level is inherited from a parent.
        /// </summary>
        public Level Level { get; set; }

        /// <summary>
        /// The logger Manager
        /// </summary>
        public LoggerManager LoggerManager { get; }

        /// <summary>
        /// List of appenders.
        /// </summary>
        public AppenderManager AppenderManager { get; }

        #region Constructor

        /// <summary>
        /// Private constructor.
        /// Use LoggerFactory to get a new instance of a logger.
        /// </summary>
        public Logger(string name, Level level, LoggerManager loggerManager)
        {
            Id = Interlocked.Increment(ref nextId);
            LoggerManager = loggerManager;
            AppenderManager = new AppenderManager(this);
            Name = DEFAULT_NAME.Equals(name) ? DEFAULT_NAME : name;
            Level = DEFAULT_LEVEL;
        }

        #endregion

        /// <summary>
        /// Add an appender from AppenderType.
        /// </summary>
        public IAppender AddAppender(AppenderType appenderType, string appenderName = null)
        {
            return AppenderManager.AddAppender(appenderType, appenderName);
        }

        /// <summary>
        /// Add an appender from AppenderType.
        /// </summary>
        public IAppender AddAppender(AppenderType appenderType, Type type, string appenderName = null)
        {
            return AppenderManager.AddAppender(appenderType, type, appenderName);
        }

        /// <summary>
        /// Add an appender from a custom IAppender implementation.
        /// </summary>		l
        public IAppender AddAppender(Type clazz, string appenderName = "")
        {
            return AppenderManager.AddAppender(clazz, appenderName);
        }

        /// <summary>
        /// Reset the logger appanders
        /// </summary>
        public void Reset()
        {
            AppenderManager.AppenderList.Clear();
            Level = DEFAULT_LEVEL;           
        }

        /// <summary>
        /// Remove appender from its name
        /// </summary>
        /// <param name="name"></param>
        public void RemoveAppender(string name)
        {
            AppenderManager.Detach(name);
        }

        /// <summary>
        /// Remove all appenders from the given type
        /// </summary>
        /// <param name="appenderType"></param>
        public void RemoveAppender(AppenderType appenderType)
        {
            AppenderManager.Detach(appenderType);
        }

        /// <summary>
        /// Remove appender
        /// </summary>
        /// <param name="appender"></param>
        public void RemoveAppender(IAppender appender)
        {
            AppenderManager.Detach(appender);
        }

        /// <summary>
        /// Call the appender from the logger
        /// </summary>
        /// <param name="log"></param>
        public void CallAppenders(Log log)
        {
            foreach(IAppender appender in AppenderManager.AppenderList)
            {
                // Dispay the log for each appender of the logger
                //appender.DoAppend(log);
                appender.DoAppend(log);
            }
        }

        /// <summary>
        /// Call the appender from the logger
        /// </summary>
        /// <param name="log"></param>
        public async Task CallAppendersAsync(Log log)
        {
            foreach (IAppender appender in AppenderManager.AppenderList)
            {
                // Dispay the log for each appender of the logger
                //appender.DoAppend(log);
                await appender.DoAppendAsync(log);
            }
        }

        #region ILog methods

        /// <summary>
        /// Log a log with a message
        /// </summary>
        /// <param name="msg"></param>
        public void Log(string msg)
        {
            Log log = LoggerManager.MakeLog(this, msg, Level.LOG, null);
            CallAppenders(log);

        }

        /// <summary>
        /// Log a log with message and exception
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="e"></param>
        public void Log(string msg, Exception e)
        {
            Log log = LoggerManager.MakeLog(this, msg, Level.LOG, e);
            CallAppenders(log);
        }


        /// <summary>
        /// Log a log error with message
        /// </summary>
        /// <param name="msg"></param>
        public void Error(string msg)
        {
            if(Level <= Level.ERROR)
            {
                Log log = LoggerManager.MakeLog(this, msg, Level.ERROR, null);
                CallAppenders(log);
            } 
        }


        /// <summary>
        /// Log a log error with message and exception
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="e"></param>
        public void Error(string msg, Exception e)
        {
            if (Level <= Level.ERROR)
            {
                Log log = LoggerManager.MakeLog(this, msg, Level.ERROR, e);
                CallAppenders(log);
            }
        }

        /// <summary>
        /// Log a log info with message
        /// </summary>
        /// <param name="msg"></param>
        public void Info(string msg)
        {
            if (Level <= Level.INFO)
            {
                Log log = LoggerManager.MakeLog(this, msg, Level.INFO, null);
                CallAppenders(log);
            }
        }

        /// <summary>
        /// Log a log info with message and exception
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="e"></param>
        public void Info(string msg, Exception e)
        {
            if (Level <= Level.INFO)
            {
                Log log = LoggerManager.MakeLog(this, msg, Level.INFO, e);
                CallAppenders(log);
            }             
        }


        /// <summary>
        /// Log a warn log with message
        /// </summary>
        /// <param name="msg"></param>
        public void Warn(string msg)
        {
            if(Level <= Level.WARN)
            {
                Log log = LoggerManager.MakeLog(this, msg, Level.WARN, null);
                CallAppenders(log);
            }           
        }

        /// <summary>
        /// Log a warn log with message and exception
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="e"></param>
        public void Warn(string msg, Exception e)
        {
            if(Level <= Level.WARN)
            {
                Log log = LoggerManager.MakeLog(this, msg, Level.WARN, e);
                CallAppenders(log);
            }          
        }

        /// <summary>
        /// Log a log debug with message
        /// </summary>
        /// <param name="msg"></param>
        public void Debug(string msg)
        {
            if(Level <= Level.DEBUG)
            {
                Log log = LoggerManager.MakeLog(this, msg, Level.DEBUG, null);
                CallAppenders(log);
            }
        }

        /// <summary>
        /// Log a log debug with message and exception
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="e"></param>
        public void Debug(string msg, Exception e)
        {
            if(Level <= Level.DEBUG)
            {
                Log log = LoggerManager.MakeLog(this, msg, Level.DEBUG, e);
                CallAppenders(log);
            }         
        }


        /// <summary>
        /// Log a log trace with message
        /// </summary>
        /// <param name="msg"></param>
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
        /// <param name="msg"></param>
        /// <param name="e"></param>
        public void Trace(string msg, Exception e)
        {
            if (Level <= Level.TRACE)
            {
                Log log = LoggerManager.MakeLog(this, msg, Level.TRACE, e);
                CallAppenders(log);
            }
        }

        /// <summary>
        /// To be implemented
        /// </summary>
        /// <returns></returns>
        public bool isDebugEnabled()
        {
            return this.Level == Level.DEBUG;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool isErrorEnabled()
        {
            return this.Level == Level.ERROR;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool isInfoEnabled()
        {
            return this.Level == Level.INFO;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool isTraceEnabled()
        {
            return this.Level == Level.TRACE;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool isWarnEnabled()
        {
            return this.Level == Level.WARN;
        }

        #endregion


        /// <summary>
        /// Make a deep copy of the logger
        /// </summary>
        /// <returns></returns>
        public ILogger DeepCopy()
        {
            ILogger copyLogger = (Logger)this.MemberwiseClone();
            return copyLogger;
        }


        #region async methods

        /// <summary>
        /// Log a log with a message asynchronously
        /// </summary>
        /// <param name="msg"></param>
        public async Task LogAsync(string msg)
        {
            Log log = LoggerManager.MakeLog(this, msg, Level.LOG, null);
            await CallAppendersAsync(log);

        }

        /// <summary>
        /// Log a log with message and exception asynchronously
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="e"></param>
        public async Task LogAsync(string msg, Exception e)
        {
            Log log = LoggerManager.MakeLog(this, msg, Level.LOG, e);
            await CallAppendersAsync(log);
        }


        /// <summary>
        /// Log a log error with message asynchronously
        /// </summary>
        /// <param name="msg"></param>
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
        /// <param name="msg"></param>
        /// <param name="e"></param>
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
        /// <param name="msg"></param>
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
        /// <param name="msg"></param>
        /// <param name="e"></param>
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
        /// <param name="msg"></param>
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
        /// <param name="msg"></param>
        /// <param name="e"></param>
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
        /// <param name="msg"></param>
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
        /// <param name="msg"></param>
        /// <param name="e"></param>
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
        /// <param name="msg"></param>
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
        /// <param name="msg"></param>
        /// <param name="e"></param>
        public async Task TraceAsync(string msg, Exception e)
        {
            if (Level <= Level.TRACE)
            {
                Log log = LoggerManager.MakeLog(this, msg, Level.TRACE, e);
                await CallAppendersAsync(log);
            }
        }

        #endregion
    }
}
