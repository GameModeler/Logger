using GMLogger.Interfaces;
using GMLogger.Loggers;
using System;

namespace Logger.Appenders
{
    /// <summary>
    /// Display the log into a database
    /// A DataBaseAppender matches one and only one data base.
    /// </summary>
    public class DataBaseAppender : IAppender
    {
        //private const string DEFAULT_DATABASE_NAME = "GM_DB_LOGGER";
        //public string Name { get; set; }

        //public string Layout { get; set; }

        //public GmDbManager<Log> Database { get; private set; }

        //public string DbName { get; set; }

        //public IDbSettings Settings { get; set; }

        //public DataBaseAppender(string name)
        //{
        //    Name = name == null ? DEFAULT_DATABASE_NAME : name;
        //}

        //    /// <summary>
        //    /// Create a DataBase Appender with a data base settings and a provider
        //    /// </summary>
        //    /// <param name="dbSetting"></param>
        //    /// <param name="provider"></param>
        //    public DataBaseAppender(IDbSettings dbSettings, ProviderType provider, Type type = null)
        //    {
        //        logType = type == null ? type = typeof(Log) : type;

        //        //logType = this.GetType().GetTypeInfo().GenericTypeArguments[0];

        //        DatabaseManager.Instance.SetProvider(provider);

        //        /// Create db with the dbSettings if not already yet
        //        //Database = new DbEntityManager<>(dbSettings);
        //        Type genericListType = typeof(DbEntityManager<>);
        //        Type specificListType = genericListType.MakeGenericType(logType);
        //        Database = Activator.CreateInstance(specificListType, dbSettings);
        //    }

        /// <summary>
        /// Create a DataBase Appender with a data base name and a provider
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="provider"></param>
        //public DataBaseAppender(string dbName, ProviderType provider, Type type = null)
        //{
        //    //logType = type == null ? type = typeof(Log) : type;
        //    logType = this.GetType().GetTypeInfo().GenericTypeArguments[0];

        //    DatabaseManager.Instance.SetProvider(provider);
        //    IDbSettings dbSettings = new DbSettings(dbName);

        //    /// Create db with the dbSettings if not already yet
        //    Database = new DbEntityManager<ILog>(dbSettings);

        //}

        /// <summary>
        /// Create a DataBase Appender with a provider 
        /// </summary>
        /// <param name="provider"></param>
        //public DataBaseAppender(ProviderType provider, Type type = null)
        //{
        //    //logType = type == null ? type = typeof(Log) : type;
        //    logType = this.GetType().GetTypeInfo().GenericTypeArguments[0];

        //    DatabaseManager.Instance.SetProvider(provider);

        //    /// Create db with the dbSettings if not already yet
        //    Database = new DbEntityManager<ILog>();

        //}


        //public void DoAppenderDB<T>(ILog log)
        //{

        //    DatabaseManager.Instance.SetProvider(Provider);
        //    IDbSettings dbSettings = new DbSettings(DbName);

        //    //Type genericListType = typeof(DbEntityManager<>);
        //    //Type specificListType = genericListType.MakeGenericType(logType);
        //    //Database = Activator.CreateInstance(specificListType, dbSettings);
        //    DbEntityManager<ILog> db2 = new DbEntityManager<ILog>(dbSettings);

        //    db2.Insert(log);
        //}


        //public void setDataBase<T>(IDbSettings dbSettings, ProviderType provider, T type) where T : ILog
        //{
        //    logType = type.GetType();



        //    /// Create db with the dbSettings if not already yet
        //    Type genericListType = typeof(DbEntityManager<>);
        //    Type specificListType = genericListType.MakeGenericType(logType);
        //    Database = Activator.CreateInstance(specificListType, dbSettings);
        //}

        //public void setDataBase<T>(string dbName, ProviderType provider, T type) where T : ILog
        //{

        //    logType = type.GetType();

        //    DatabaseManager.Instance.SetProvider(provider);
        //    IDbSettings dbSettings = new DbSettings(dbName);

        //    /// Create db with the dbSettings if not already yet
        //    //Database = new DbEntityManager<>(dbSettings);
        //    Type genericListType = typeof(DbEntityManager<>);
        //    Type specificListType = genericListType.MakeGenericType(logType);
        //    Database = Activator.CreateInstance(specificListType, dbSettings);
        //}

        //public void setDataBase(ProviderType provider, Type type = null)
        //{
        //    //if(type is ILog)
        //    //{
        //        logType = type == null ? type = typeof(Log) : type;

        //        DatabaseManager.Instance.SetProvider(provider);

        //        /// Create db with the dbSettings if not already yet
        //        Type genericListType = typeof(DbEntityManager<>);
        //        Type specificListType = genericListType.MakeGenericType(logType);


        //    try
        //    {
        //        Database = Activator.CreateInstance(specificListType);
        //    }
        //    catch (TargetInvocationException e)
        //    {
        //        throw e.InnerException;
        //    }

        //    //}
        //}

        //public void setDataBase<T>(T type) where T : ILog
        //{
        //    logType = type.GetType();
        //    DatabaseManager.Instance.SetProvider(provider);

        //    /// Create db with the dbSettings if not already yet
        //    Type genericListType = typeof(DbEntityManager<>);
        //    Type specificListType = genericListType.MakeGenericType(logType);
        //    Database = Activator.CreateInstance(specificListType);
        //}

        //public async void DoAppend(Log log)
        //{ 
        //    await Database.Insert(log);
        //}


        //public void AttachDB(IDbSettings dbsettings, ProviderType provider)
        //{
        //    DatabaseManager.Instance.SetProvider(provider);
        //    Database = new DbEntityManager<Log>(dbsettings);
        //}

        //public void AttachDB(IDbSettings dbsettings)
        //{
        //    Database = new DbEntityManager<Log>(dbsettings);
        //}
        public string Layout
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public string Name
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public void DoAppend(Log log)
        {
            throw new NotImplementedException();
        }
    }
}

