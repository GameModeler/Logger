using GMLogger.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMLogger.Layout
{
    /// <summary>
    /// Elements of a logger
    /// </summary>
    public enum LogElements
    {
        /// <summary>
        /// log's timestamp
        /// </summary>
        [StringValue("TIMESTAMP")]
        TIMESTAMP = 0,
        /// <summary>
        /// log level
        /// </summary>
        [StringValue("LEVEL")]
        LEVEL = 1,
        /// <summary>
        /// log's logger's name
        /// </summary>
        [StringValue("LOGGER_NAME")]
        LOGGER_NAME = 2,
        /// <summary>
        /// log's message
        /// </summary>
        [StringValue("MESSAGE")]
        MESSAGE = 3,
        /// <summary>
        /// exception
        /// </summary>
        [StringValue("EXCEPTION")]
        EXCEPTION = 4
    }
}
