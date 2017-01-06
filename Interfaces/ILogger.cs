using GMLogger.Loggers;
using GMLogger.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMLogger.Interfaces
{
    public interface ILogger
    {
        int Id { get; }
        string Name { get; set; }
        LoggerManager LoggerManager { get; }
        Level Level { get; set; }
        string Parent { get; set; }
        ILogger DeepCopy();
    }
}
