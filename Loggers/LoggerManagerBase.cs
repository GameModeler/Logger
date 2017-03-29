using Logger.Interfaces;
using Logger.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Loggers
{
    public abstract class LoggerManagerBase
    {
        public abstract ILogger CreateLogger(string name, Level level, Type clazz);

        public abstract ILogger DuplicateLogger(string name);
    }
}
