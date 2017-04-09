using Logger.Interfaces;
using Logger.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Appenders.FileAppenderFAPI.Interfaces
{
    /// <summary>
    /// File Appender Fluent Api
    /// </summary>
    public interface IFileAppenderFApi
    {
        /// <summary>
        /// File type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        FileAppenderFApi Type(FileAppenderType type);

        /// <summary>
        /// File name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        FileAppenderFApi Name(string name);

        /// <summary>
        /// File path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        FileAppenderFApi Path(string path);

    }
}
