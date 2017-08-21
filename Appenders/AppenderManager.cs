// <copyright file="AppenderManager.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Logger.Appenders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Logger.Interfaces;
    using Logger.Utils;

    /// <summary>
    /// Appender Manager
    /// </summary>
    public class AppenderManager : IAppenderManager
    {
        /// <summary>
        /// List of appenders.
        /// </summary>
        private readonly SynchronizedCollection<IAppender> appenderList;

        /// <summary>
        /// Initializes a new instance of the <see cref="AppenderManager"/> class.
        /// </summary>
        /// <param name="logger">The logger</param>
        public AppenderManager(ILogger logger)
        {
            this.Logger = logger;
            this.appenderList = new SynchronizedCollection<IAppender>();
        }

        /// <summary>
        /// Gets get the list of appenders.
        /// </summary>
        public SynchronizedCollection<IAppender> AppenderList
        {
            get
            {
                return this.appenderList;
            }
        }

        private ILogger Logger { get; }

        /// <summary>
        /// Add an appender to the list of appenders.
        /// </summary>
        /// <param name="appender">The appender</param>
        /// <returns>IAppender</returns>
        public IAppender AddAppender(IAppender appender)
        {
            if (appender != null)
            {
                this.appenderList.Add(appender);
            }

            return appender;
        }

        /// <summary>
        /// Detach an appender from the list of appenders.
        /// </summary>
        /// <param name="appender">The appender</param>
        public void Detach(IAppender appender)
        {
            this.appenderList.Remove(appender);
        }

        /// <summary>
        /// Detach all appender from a type
        /// </summary>
        /// <param name="type">The appender type</param>
        public void Detach(AppenderType type)
        {
            List<IAppender> appenders = this.appenderList.ToList<IAppender>();
            appenders.RemoveAll(app => app.AppenderType == type);

        }

        /// <summary>
        /// Detach an appender from the list of appender from its name.
        /// </summary>
        /// <param name="name">The appender name</param>
        public void Detach(string name) {

            IAppender appender = this.appenderList.SingleOrDefault(app => app.AppenderName == name);
            this.Detach(appender);
        }

        /// <summary>
        /// Create and add an appender to the list of appenders
        /// if not exists yet.
        /// </summary>
        /// <param name="name">The name of the appender</param>
        /// <param name="type">The type of the appender</param>
        /// <returns>IAppender</returns>
        public IAppender AddAppender(AppenderType type, string name = null)
        {
            if (!this.AppenderList.IsAnAppenderName(name))
            {
                // Create a new appender
                IAppender appender = this.CreateAppender(type, name);
                this.AddAppender(appender);

                return appender;

            } else
            {
                return null;
            }
        }

        /// <summary>
        /// Add an appender to the logger
        /// </summary>
        /// <param name="type">The appender type</param>
        /// <param name="clazz">The appender class</param>
        /// <param name="name">The name of the appender</param>
        /// <returns>IAppender</returns>
        public IAppender AddAppender(AppenderType type, Type clazz, string name = null)
        {
            if (!this.AppenderList.IsAnAppenderName(name))
            {
                // Create a new appender
                IAppender appender = this.CreateAppender(type, clazz, name);
                this.AddAppender(appender);

                return appender;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Add an appender to the logger
        /// </summary>
        /// <param name="clazz">The appender class</param>
        /// <param name="name">The appender name</param>
        /// <returns>IAppender</returns>
        public IAppender AddAppender(Type clazz, string name = "")
        {
            IAppender appender = null;

            if (!this.AppenderList.IsAnAppenderName(name) && clazz is IAppender)
            {
                appender = Activator.CreateInstance(clazz, name) as IAppender;
                this.AddAppender(appender);

            }

            return appender;
        }

        /// <summary>
        /// Create a new appender from its type.
        /// </summary>
        /// <param name="type">The appender type</param>
        /// <param name="name">Tha appender name</param>
        /// <returns>IAppender</returns>
        public IAppender CreateAppender(AppenderType type, string name)
        {
            switch (type)
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
        /// <param name="type">The appender type</param>
        /// <param name="clazz">Class of the appender</param>
        /// <param name="name">Name of the appender</param>
        /// <returns>IAppender</returns>
        public IAppender CreateAppender(AppenderType type, Type clazz, string name)
        {
            switch (type)
            {
                case AppenderType.MESSAGE_BOX_CUSTOM:

                    var d1 = typeof(MessageBoxCustomAppender<>);
                    var makeme = d1.MakeGenericType(clazz);

                    return Activator.CreateInstance(makeme, name) as IAppender;

                default:
                    return new ConsoleAppender(name);
            }
        }
    }
}
