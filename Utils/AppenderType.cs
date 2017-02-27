using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMLogger.Utils
{
    /// <summary>
    /// Types of appenders
    /// </summary>
    public enum AppenderType
    {

        /// <summary>
        /// Console type
        /// </summary>
        CONSOLE,

        /// <summary>
        /// Message box type
        /// </summary>
        MESSAGE_BOX,

        /// <summary>
        /// Custom message box type
        /// </summary>
        MESSAGE_BOX_CUSTOM,

        /// <summary>
        /// Toast type
        /// </summary>
        TOAST,

        /// <summary>
        /// Database type
        /// </summary>
        DATABASE,

        /// <summary>
        /// File type
        /// </summary>
        FILE
    }
}
