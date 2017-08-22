// <copyright file="DataBaseAppender.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Logger.Appenders
{
    using System.Threading.Tasks;
    using DataBase.Database.DbContexts.Interfaces;
    using DataBase.Database.DbSettings;
    using DataBase.Database.DbSettings.Interfaces;
    using Interfaces;
    using Loggers;
    using Utils;

    /// <summary>
    /// Display the log into a database
    /// A DataBaseAppender matches one and only one data base.
    /// </summary>
    public class DataBaseAppender : IAppender
    {
        private const string DEFAULT_DATABASE_NAME = "GM_DB_LOGGER";

        /// <summary>
        /// Universal context
        /// </summary>
        private IUniversalContext dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataBaseAppender"/> class.
        /// </summary>
        /// <param name="name">Name of the appender</param>
        public DataBaseAppender(string name)
        {
            this.AppenderName = string.IsNullOrEmpty(name) ? DEFAULT_DATABASE_NAME : name;
        }

        /// <summary>
        /// Gets appender's type
        /// </summary>
        public AppenderType AppenderType { get; }

        /// <summary>
        /// Gets or sets appender name
        /// </summary>
        public string AppenderName { get; set; }

        /// <summary>
        /// Gets or sets log layout
        /// </summary>
        public string Layout { get; set; }

        /// <summary>
        /// Attach a database to the appender
        /// </summary>
        /// <param name="settings">The database settings</param>
        public void AttachDB(IDbSettings settings)
        {
            this.dbContext = DatabaseFactory.CreateContext(settings);
        }

        /// <summary>
        /// Appends the log
        /// </summary>
        /// <param name="log">The log</param>
        public void DoAppend(ILog log)
        {
            this.dbContext.Entity<Log>().Insert(log as Log);
        }

        /// <summary>
        /// Appends the log asynchronously
        /// </summary>
        /// <param name="log">The log</param>
        /// <returns><see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task DoAppendAsync(ILog log)
        {
            await Task.Run(() => this.dbContext.Entity<Log>().InsertAsync(log as Log));
        }
    }
}