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
        [StringValue("TIMESTAMP")]
        TIMESTAMP = 0,
        [StringValue("LEVEL")]
        LEVEL = 1,
        [StringValue("LOGGER_NAME")]
        LOGGER_NAME = 2,
        [StringValue("MESSAGE")]
        MESSAGE = 3,
        [StringValue("EXCEPTION")]
        EXCEPTION = 4
    }
}
