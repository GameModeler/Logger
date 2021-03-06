﻿using Logger.Loggers;
using Logger.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Interfaces
{
    /// <summary>
    /// Logger Base interface
    /// </summary>
    public interface ILoggerBase
    {
        /// <summary>
        /// Logger' id
        /// </summary>
        int Id { get; }

        /// <summary>
        /// Logger's name
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Logger's manager
        /// </summary>
        LoggerManager LoggerManager { get; }

        /// <summary>
        /// Logger's level
        /// </summary>
        Level Level { get; set; }

        /// <summary>
        /// Parent's logger
        /// </summary>
        string Parent { get; set; }

        /// <summary>
        /// Allow to duplicate a logger
        /// </summary>
        /// <returns></returns>
        ILogger DeepCopy();
    }
}
