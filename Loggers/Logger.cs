using Logger.Appenders;
using Logger.Interfaces;
using Logger.Utils;
using Logger.Appenders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Logger.Loggers
{
    /// <summary>
    /// A Logger.
    /// </summary>
    public class Logger : ILogger, ILoggerLog
    {
     
        const string DEFAULT_NAME = "GM_LOGGER";
        const Level DEFAULT_LEVEL = Level.TRACE;

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
            AppenderManager.AddAppender(AppenderType.CONSOLE);
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

        private void SetDefaultLogger()
        {
            /// DEFAULT LOGGER SETTING ///
            Level = DEFAULT_LEVEL;
            Name = DEFAULT_NAME;
            AppenderManager.AddAppender(AppenderType.CONSOLE);
        }

        /// <summary>
        /// Reset the logger appanders
        /// </summary>
        public void Reset()
        {
            SetDefaultLogger();
            AppenderManager.AppenderList.Clear();
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool isErrorEnabled()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool isInfoEnabled()
        {
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool isTraceEnabled()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool isWarnEnabled()
        {
            throw new NotImplementedException();
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
    }
}
