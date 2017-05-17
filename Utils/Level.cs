using System;

namespace Logger.Utils
{
    /// <summary>
    /// Levels
    /// </summary>
    public enum Level
    {
        /// <summary>
        /// Trace level
        /// </summary>
        [StringValue("TRACE")]
        TRACE,

        /// <summary>
        /// Debug level
        /// </summary>
        [StringValue("DEBUG")]
        DEBUG,

        /// <summary>
        /// Info level
        /// </summary>
        [StringValue("INFO")]
        INFO ,

        /// <summary>
        /// Warn level
        /// </summary>
        [StringValue("WARN")]
        WARN ,

        /// <summary>
        /// Error level
        /// </summary>
        [StringValue("ERROR")]
        ERROR,

        /// <summary>
        /// Log level
        /// </summary>
        [StringValue("LOG")]
        LOG

    }

    static class LevelColor
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

