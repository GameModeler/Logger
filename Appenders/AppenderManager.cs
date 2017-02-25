using GMLogger.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using GMLogger.Utils;
using Logger.Appenders;

namespace GMLogger.Appenders
{
    public class AppenderManager : IAppenderManager
    {
       
        /// <summary>
        /// List of appenders.
        /// </summary>
        private SynchronizedCollection<IAppender> appenderList;

        private ILogger Logger { get; }


        public AppenderManager(ILogger logger)
        {
            Logger = logger;
            appenderList = new SynchronizedCollection<IAppender>();
        }

        /// <summary>
        /// Add an appender to the list of appenders.
        /// </summary>
        /// <param name="appender"></param>
        public IAppender AddAppender(IAppender appender)
        {
            if (appender != null)
            {
                appenderList.Add(appender);
            }

            return appender;
        }

        /// <summary>
        /// Detach an appender from the list of appenders.
        /// </summary>
        /// <param name="appender"></param>
        public void DetachAppender(IAppender appender)
        {
            appenderList.Remove(appender);
        }

        /// <summary>
        /// Detach an appender from the list of appender from its name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IAppender DetachAppender(string name) {

            IAppender appender = appenderList.Where(app => app.Name == name).SingleOrDefault();
            DetachAppender(appender);

            return appender;
        }

        /// <summary>
        /// Create and add an appender to the list of appenders
        /// if not exists yet.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public IAppender AddAppender(AppenderType type, string name = null)
        {
            if (!AppenderList.IsAnAppenderName(name))
            {
                // Create a new appender
                IAppender appender = CreateAppender(type, name);
                AddAppender(appender);

                return appender;

            } else
            {
                return null;
            }
        }

        public IAppender AddAppender(AppenderType type, Type clazz, string name = null)
        {
            if (!AppenderList.IsAnAppenderName(name))
            {
                // Create a new appender
                IAppender appender = CreateAppender(type, clazz, name);
                AddAppender(appender);

                return appender;
            }
            else
            {
                return null;
            }
        }

        public IAppender AddAppender(Type clazz, string name = "")
        {
            IAppender appender = null;

            if (!AppenderList.IsAnAppenderName(name)) {

                if (clazz is IAppender)
                {
                    appender = (IAppender) Activator.CreateInstance(clazz, name);
                    AddAppender(appender);               
                } 
            } 
            return appender;
        }

        /// <summary>
        /// Get the list of appenders.
        /// </summary>
        public SynchronizedCollection<IAppender> AppenderList
        {
            get
            {
                return appenderList;
            }
        }

        /// <summary>
        /// Create a new appender from its type.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public IAppender CreateAppender(AppenderType type, string name)
        {
            switch(type)
            {
                case AppenderType.CONSOLE:
                    return new ConsoleAppender(name);
                case AppenderType.MESSAGE_BOX:
                    return new MessageBoxAppender(name);
                case AppenderType.TOAST:
                    return new ToastAppender(name);
                case AppenderType.DATABASE:
                    return new DataBaseAppender(name);
                case AppenderType.FILE:
                    return new FileAppender(name);
                default:
                    return new ConsoleAppender(name);
            }
        }

        /// <summary>
        /// Create a new appender from its type.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public IAppender CreateAppender(AppenderType type, Type clazz, string name)
        {
            switch (type)
            {

                case AppenderType.MESSAGE_BOX_CUSTOM:

                    var d1 = typeof(MessageBoxCustomAppender<>);
                    var makeme = d1.MakeGenericType(clazz);

                    return (IAppender) Activator.CreateInstance(makeme, name);

                default:
                    return new ConsoleAppender(name);
            }
        }
    }
}
