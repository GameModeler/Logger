using GMLogger.DataBase.Interfaces;
using GMLogger.DataBase.Utils;
using MySql.Data.Entity;
using System.Data.Entity;
using System.Reflection;

namespace GMLogger.DataBase.Database
{
    /// <summary>
    /// Build the database connection string
    /// </summary>
    public static class ConnectionStringBuilder
    {
        public static string BuildConnectionString(ProviderType provider, IDbSettings settings = null)
        {
            DbConfig dbConfig = new DbConfig();

            switch (provider)
            {
                case ProviderType.MySQL:
                    if (settings == null || DataBaseUtils.IsAllNullOrEmpty(settings)) //database settings is empty
                    { 
                        settings = new DbSettings(dbConfig.GetDefaultDbName(DatabaseManager.Instance.NbDefaultDb) , provider);                       
                    }
                    dbConfig.ConfigPorvider(provider);
                    break;
                default:
                    if (settings == null || DataBaseUtils.IsAllNullOrEmpty(settings))
                    {
                        settings = new DbSettings(dbConfig.GetDefaultDbName(DatabaseManager.Instance.NbDefaultDb), provider);
                    }
                    break;
            }
            return dbConfig.ProviderConnectionString(provider, settings);
        }
    }
}
