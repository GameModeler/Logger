using GMLogger.Interfaces;
using GMLogger.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMLogger.Loggers
{
    public abstract class LoggerManagerBase
    {
        public abstract ILogger CreateLogger(string name, Level level, Type clazz);

        public abstract ILogger DuplicateLogger(string name);
    }
}
