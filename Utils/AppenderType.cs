namespace Logger.Utils
{
    /// <summary>
    /// Types of appenders
    /// </summary>
    public enum AppenderType
    {
        /// <summary>
        /// None
        /// </summary>
        NONE,

        /// <summary>
        /// Console appender
        /// </summary>
        CONSOLE,

        /// <summary>
        /// Message box appender
        /// </summary>
        MESSAGE_BOX,

        /// <summary>
        /// Custom message box appender
        /// </summary>
        MESSAGE_BOX_CUSTOM,
        
        /// <summary>
        /// Toast appender
        /// </summary>
        TOAST,

        /// <summary>
        /// Database appender
        /// </summary>
        DATABASE,

        /// <summary>
        /// File appender
        /// </summary>
        FILE
    }
}
