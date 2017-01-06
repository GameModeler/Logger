using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMLogger.Utils
{
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
