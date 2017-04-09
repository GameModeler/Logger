using Logger.Utils;

namespace Logger.Appenders.FileAppenderFAPI
{
    /// <summary>
    /// File Appender Api
    /// </summary>
    public class FileAppenderFApi
    {
        private readonly FileAppender file;

        /// <summary>
        /// Constructor
        /// </summary>
        public FileAppenderFApi(FileAppender fileFI)
        {
            file = fileFI;
        }

        /// <summary>
        /// Sets file's name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public FileAppenderFApi Name(string name)
        {
            file.Name = name;
            return this;
        }

        /// <summary>
        /// Sets MySql Database's nama
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public FileAppenderFApi Type(FileAppenderType type)
        {
            file.Type = type;
            return this;
        }

        /// <summary>
        /// Sets MySql Database Password
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public FileAppenderFApi Path(string path)
        {
            file.Path = path;
            return this;
        }
    }
}


