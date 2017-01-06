using GMLogger.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMLogger.Interfaces
{
    public interface ILog
    {
        int Id { get; set; }

        string Message { get; }
        DateTime Timestamp { get; }
        string LoggerName { get; }
        Level Level { get; }
        Exception Exception { get; }
    }
}
