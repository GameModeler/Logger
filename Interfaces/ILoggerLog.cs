using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Loggers
{
    /// <summary>
    /// Logger's methods
    /// Inspired from org.slf4j.Logger interface.
    /// </summary>
    public interface ILoggerLog
    {
        void Log(string msg);
        void Log(string msg, Exception e);
        //void Log(string format, params object[] arguments);

        void Error(string msg);
        void Error(string msg, Exception e);
        //void Error(string format, params object[] arguments);

        void Info(string msg);
        void Info(string msg, Exception e);
        //void Info(string format, params object[] arguments);

        void Warn(string msg);
        void Warn(string msg, Exception e);
        //void Warn(string format, params object[] arguments);

        void Debug(string msg);
        void Debug(string msg, Exception e);
        //void Debug(string format, params object[] arguments);

        void Trace(string msg);
        void Trace(string msg, Exception e);
        //void Trace(string format, params object[] arguments);

        bool isDebugEnabled();
                  
        bool isErrorEnabled();

        bool isInfoEnabled();

        bool isTraceEnabled();

        bool isWarnEnabled();
    }
}
