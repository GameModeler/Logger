using Logger.Interfaces;
using Logger.Utils;
using System;

namespace Logger.Loggers
{
    public abstract class LoggerManagerBase
    {
        public abstract ILogger CreateLogger(string name, Level level, Type clazz);

        public abstract ILogger DuplicateLogger(string name);
    }
}
