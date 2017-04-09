using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Utils
{
    /// <summary>
    /// File type extension
    /// </summary>
    public enum FileAppenderType
    {
        /// <summary>
        /// Json
        /// </summary>
        JSON,

        /// <summary>
        /// Yaml
        /// </summary>
        YAML,

        /// <summary>
        /// Xml
        /// </summary>
        XML,

        /// <summary>
        /// Binary
        /// </summary>
        BINARY,

        /// <summary>
        /// Csv
        /// </summary>
        CSV,

        /// <summary>
        /// Character
        /// </summary>
        CHARACTER,

        /// <summary>
        /// Text
        /// </summary>
        TEXT
    }
}
