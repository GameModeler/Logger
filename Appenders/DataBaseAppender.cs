using DataBase.Database;
using DataBase.Database.DbSettings.Interface;
using Logger.Interfaces;
using Logger.Loggers;
using System;

namespace Logger.Appenders
{
    /// <summary>
    /// Display the log into a database
    /// A DataBaseAppender matches one and only one data base.
    /// </summary>
    public class DataBaseAppender : IAppender
    {
        private const string DEFAULT_DATABASE_NAME = "GM_DB_LOGGER";

        /// <summary>
        /// Appender name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Log layout
        /// </summary>
        public string Layout { get; set; }

        /// <summary>
        /// Database Manager
        /// </summary>
        private DbManager dbManager = DbManager.Instance;

        private GlobalContext<Log> dbContext;


        /// <summary>
        /// Database Name
        /// </summary>
        public string DbName { get; set; }

        // public IDbSettings Settings { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"></param>
        public DataBaseAppender(string name)
        {

            dbContext = dbManager.ContextFactory<Log>();
            Name = name == null ? DEFAULT_DATABASE_NAME : name;
        }

        /// <summary>
        /// Attach a database to the appender
        /// </summary>
        /// <param name="settings"></param>
        public void AttachDB(IDbSettings settings)
        {
            dbContext.Context(settings);
        }

        /// <summary>
        /// Appends the log
        /// </summary>
        /// <param name="log"></param>
        public async void DoAppend(Log log)
        {
            await dbContext.InsertAsync(log);

            throw new NotImplementedException();
        }
    }
}

