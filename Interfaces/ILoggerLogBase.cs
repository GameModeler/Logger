namespace Logger.Interfaces
{
    /// <summary>
    /// LoggerLog Base
    /// </summary>
    public interface ILoggerLogBase
    {

        /// <summary>
        /// True if debug level is enabled
        /// </summary>
        /// <returns></returns>
        bool isDebugEnabled();

        /// <summary>
        /// True if error level is enabled
        /// </summary>
        /// <returns></returns>                    
        bool isErrorEnabled();

        /// <summary>
        /// True if info level is enabled
        /// </summary>
        /// <returns></returns>
        bool isInfoEnabled();

        /// <summary>
        /// True if trace level is enabled
        /// </summary>
        /// <returns></returns>
        bool isTraceEnabled();

        /// <summary>
        /// True if warn level is enabled
        /// </summary>
        /// <returns></returns>
        bool isWarnEnabled();
    }
}