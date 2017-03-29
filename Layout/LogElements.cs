﻿using Logger.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Layout
{
    /// <summary>
    /// Elements of a logger
    /// </summary>
    public enum LogElements
    {
        /// <summary>
        /// Timestamp
        /// </summary>
        [StringValue("TIMESTAMP")]
        TIMESTAMP = 0,

        /// <summary>
        /// Level
        /// </summary>
        [StringValue("LEVEL")]
        LEVEL = 1,

        /// <summary>
        /// Logger name
        /// </summary>
        [StringValue("LOGGER_NAME")]
        LOGGER_NAME = 2,

        /// <summary>
        /// Message
        /// </summary>
        [StringValue("MESSAGE")]
        MESSAGE = 3,

        /// <summary>
        /// Exception
        /// </summary>
        [StringValue("EXCEPTION")]
        EXCEPTION = 4
    }
}
