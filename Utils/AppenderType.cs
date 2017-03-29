using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Utils
{
    /// <summary>
    /// Types of appenders
    /// </summary>
    public enum AppenderType
    {
        NONE,
        CONSOLE,
        MESSAGE_BOX,
        MESSAGE_BOX_CUSTOM,
        CURRENT_FOLDER,
        TEMP_FOLDER,
        TOAST,
        DATABASE,
        FILE
    }
}
