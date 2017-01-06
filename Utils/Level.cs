using GMLogger.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMLogger.Utils
{
    public enum Level
    {
        [StringValue("TRACE")]
        TRACE,
        [StringValue("DEBUG")]
        DEBUG,
        [StringValue("INFO")]
        INFO ,
        [StringValue("WARN")]
        WARN ,
        [StringValue("ERROR")]
        ERROR,
        [StringValue("LOG")]
        LOG

    }

    static class LevelColol
    {

        public static ConsoleColor GetColor(this Level level)
        {
            switch (level)
            {
                case Level.LOG:
                    return ConsoleColor.Gray;
                case Level.TRACE:
                    return ConsoleColor.Yellow;
                case Level.DEBUG:
                    return ConsoleColor.DarkGreen;
                case Level.INFO:
                    return ConsoleColor.DarkCyan;
                case Level.WARN:
                    return ConsoleColor.DarkYellow;
                case Level.ERROR:
                    return ConsoleColor.DarkRed;
                default:
                    return ConsoleColor.Gray;
            }
        }
    }
}

