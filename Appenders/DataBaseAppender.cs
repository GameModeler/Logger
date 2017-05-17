using DataBase.Database;
using DataBase.Database.DbContexts;
using DataBase.Database.DbSettings.Interfaces;
using Logger.Interfaces;
using Logger.Loggers;
using Logger.Utils;
using System;
using System.Threading.Tasks;

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
        /// Appender's type
        /// </summary>
        public AppenderType AppenderType { get; }

        /// <summary>
        /// Appender name
        /// </summary>
        public string AppenderName { get; set; }

        /// <summary>
        /// Log layout
        /// </summary>
        public string Layout { get; set; }

        /// <summary>
        /// Database Manager
        /// </summary>
        private DbManager dbManager = DbManager.Instance;

        /// <summary>
        /// Universal context
        /// </summary>
        private  UniversalContext dbContext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"></param>
        public DataBaseAppender(string name)
        {

            //dbContext = dbManager.ContextFactory<Log>();
            AppenderName = String.IsNullOrEmpty(name) ? DEFAULT_DATABASE_NAME : name;
        }

        /// <summary>
        /// Attach a database to the appender
        /// </summary>
        /// <param name="settings"></param>
        public void AttachDB(IDbSettings settings)
        {
            dbContext = dbManager.CreateContext(settings);
            //dbContext.Context(settings);
        }

        /// <summary>
        /// Appends the log
        /// </summary>
        /// <param name="log"></param>
        public void DoAppend(Log log)
        {
            dbContext.Entity<Log>().Insert(log);

        }

        /// <summary>
        /// Appends the log asynchronously
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
        public async Task DoAppendAsync(Log log)
        {
            await Task.Run (() =>  dbContext.Entity<Log>().InsertAsync(log));
        }
    }
}

