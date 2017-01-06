using GMLogger.Utils;
using System;
using System.Collections.Generic;

namespace GMLogger.Interfaces
{
    public interface IAppenderManager
    {
        SynchronizedCollection<IAppender> AppenderList { get; }

        void AddAppender(IAppender appender);

        IAppender AddAppender(AppenderType type, string name);

        IAppender AddAppender(Type clazz, string name);

        void DetachAppender(IAppender appedner);

        IAppender CreateAppender(AppenderType type, string name);
    }
}
