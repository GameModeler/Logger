namespace Logger.Appenders.FileAppenderFAPI
{
    using Interfaces;
    using Utils;

    /// <summary>
    /// File Appender Api
    /// </summary>
    public class FileAppenderFApi : IFileAppenderFApi
    {
        private readonly FileAppender file;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileAppenderFApi"/> class.
        /// </summary>
        /// <param name="fileFI">FileAppender</param>
        public FileAppenderFApi(FileAppender fileFI)
        {
            this.file = fileFI;
        }

        /// <inheritdoc/>
        public IFileAppenderFApi Name(string name)
        {
            this.file.Name = name;
            return this;
        }

        /// <inheritdoc/>
        public IFileAppenderFApi Type(FileAppenderType type)
        {
            this.file.Type = type;
            return this;
        }

        /// <inheritdoc/>
        public IFileAppenderFApi Path(string path)
        {
            this.file.Path = path;
            return this;
        }
    }
}