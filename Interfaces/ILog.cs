﻿using Logger.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Interfaces
{
    /// <summary>
    /// A log
    /// </summary>
    public interface ILog
    {
        /// <summary>
        /// Log's id
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Log's message
        /// </summary>
        string Message { get; }

        /// <summary>
        /// Log's timestamp
        /// </summary>
        DateTime Timestamp { get; }

        /// <summary>
        /// Logger's name
        /// </summary>
        string LoggerName { get; }

        /// <summary>
        /// Log level
        /// </summary>
        Level Level { get; }

        /// <summary>
        /// Log's exception stacktrace
        /// </summary>
        String Exception { get; }
    }
}
