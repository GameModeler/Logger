using GMLogger.Loggers;

namespace GMLogger.Interfaces
{
    public interface IAppender
    {
        string Name { get; set; }
        string Layout { get; set; }

        void DoAppend(Log log);

        //void DoAppenderDB( log) where T : ILog; 
    }
}
