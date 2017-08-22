namespace Logger.Appenders.FileAppenderFAPI.Interfaces
{
    using Utils;

    /// <summary>
    /// File Appender Fluent Api
    /// </summary>
    public interface IFileAppenderFApi
    {
        /// <summary>
        /// File type
        /// </summary>
        /// <param name="type">File Type</param>
        /// <returns>IFileAppenderFApi</returns>
        IFileAppenderFApi Type(FileAppenderType type);

        /// <summary>
        /// File name
        /// </summary>
        /// <param name="name">File Name</param>
        /// <returns>IFileAppenderFApi</returns>
        IFileAppenderFApi Name(string name);

        /// <summary>
        /// File path
        /// </summary>
        /// <param name="path">File Path</param>
        /// <returns>IFileAppenderFApi</returns>
        IFileAppenderFApi Path(string path);

    }
}
