using GMLogger.DataBase.Interfaces;
using GMLogger.DataBase.Utils;
using Microsoft.EntityFrameworkCore.Storage;
using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GMLogger.DataBase.Database
{
    public class DbEntityManager<TEntity> : DbContext, IDbEntityManager<DbSettings>, ICrudMethods<TEntity> where TEntity : class
    {
        public DbSet<TEntity> DbSetT { get; set; }

        private IDbSettings settings;

        private ProviderType provid;

        #region Constructors
        /// <summary>
        /// Create a database with a given provider and settings
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="provider"></param>
        public DbEntityManager(IDbSettings settings, ProviderType provider) : base(ConnectionStringBuilder.BuildConnectionString(provider, settings))
        { 
            InitDb(settings);
            provid = provider;
        }

        /// <summary>
        /// Create a database with a given provider
        /// Used default settings
        /// </summary>
        /// <param name="provider"></param>
        public DbEntityManager(ProviderType provider) : base(ConnectionStringBuilder.BuildConnectionString(provider))
        {
            provid = provider;
            InitDb();
            
        }

        /// <summary>
        /// Create a database with a given settings
        /// </summary>
        /// <param name="settings"></param>
        public DbEntityManager(IDbSettings settings) : base(ConnectionStringBuilder.BuildConnectionString(DatabaseManager.Instance.Provider, settings))
        {
            provid = DatabaseManager.Instance.Provider;
            InitDb(settings);
            
        }

        /// <summary>
        /// Default constructor
        /// Use default provider if any provider is provided
        /// Use default settings
        /// </summary>
        public DbEntityManager() : base(ConnectionStringBuilder.BuildConnectionString(DatabaseManager.Instance.Provider))
        {
            provid = DatabaseManager.Instance.Provider;
            InitDb();
            
        }

        #endregion

        /// <summary>
        /// Create the database if not exists already
        /// Add the database into the list of databases
        /// Set the settings information of the database
        /// </summary>
        /// <param name="dbSettings"></param>
        /// <returns></returns>
        public bool InitDb(IDbSettings dbSettings = null)
        {
            var resultInitDb = false;

          
            try { 
                resultInitDb = Database.CreateIfNotExists();
             
            } catch (InvalidOperationException sqlException)
            {
                Console.WriteLine(sqlException);
                //Log (une base de donnee local existe deja)
            }

            if (resultInitDb)
            {
                //Ajouter un log informant que la base a bien été crée
                SetSettings(dbSettings);
                DatabaseManager.Instance.Databases.Add(Database.Connection.Database, Settings);
            }
            else
            {
                if (DatabaseManager.Instance.GetDatabase(Database.Connection.Database) == null)
                {
                    SetSettings(dbSettings);
                    DatabaseManager.Instance.Databases.Add(Database.Connection.Database, Settings);
                }
                //Ajouter log indiquant que la base existe déjà
            }

            if(dbSettings == null)
            {
                DatabaseManager.Instance.NbDefaultDb += 1;
            }

            return resultInitDb;
        }

        /// <summary>
        /// Set the database information
        /// </summary>
        /// <param name="dbSettings"></param>
        public void SetSettings(IDbSettings dbSettings)
        {
            if (dbSettings != null)
            {
                settings = dbSettings;

            } else
            {
                //if no dbSettings is provided, default IDbSetting class is used
                settings = new DbSettings(Database.Connection.Database, DatabaseManager.Instance.Provider);
            }

            settings.ConnectionString = Database.Connection.ConnectionString;
        }

        /// <summary>
        /// Get the information of the database
        /// </summary>
        public IDbSettings Settings
        {
            get
            {
                return settings;
            }
        }

        #region SQL methods
        public async Task<TEntity> Insert(TEntity item)
        {
            try
            {
                this.DbSetT.Add(item);
                await this.SaveChangesAsync();

            } catch(SqlException sqlException)
            {
                MessageBox.Show(sqlException.Message);
            }
            
            return item;
        }

        public async Task<IEnumerable<TEntity>> Insert(IEnumerable<TEntity> items)
        {
            foreach (var item in items)
            {
                this.DbSetT.Add(item);
            }
            await this.SaveChangesAsync();
            return items;
        }

        public async Task<TEntity> Update(TEntity item)
        {
            await Task.Factory.StartNew(() =>
            {
                this.Entry<TEntity>(item).State = EntityState.Modified;
            });
            await this.SaveChangesAsync();
            return item;
        }

        public async Task<IEnumerable<TEntity>> Update(IEnumerable<TEntity> items)
        {
            await Task.Factory.StartNew(() =>
            {
                foreach (var item in items)
                {
                    this.Entry<TEntity>(item).State = EntityState.Modified;
                }
            });
            await this.SaveChangesAsync();
            return items;
        }

        public async Task<TEntity> Get(Int32 id)
        {
            return await this.DbSetT.FindAsync(id) as TEntity;
        }

        public async Task<IEnumerable<TEntity>> Get()
        {
            DbSet<TEntity> temp = default(DbSet<TEntity>);
            List<TEntity> result = new List<TEntity>();
            await Task.Factory.StartNew(() =>
            {
                temp = base.Set<TEntity>();
            });
            result.AddRange(temp);
            return result;
        }

        public async Task<Int32> Delete(TEntity item)
        {
            await Task.Factory.StartNew(() =>
            {
                this.DbSetT.Attach(item);
                this.DbSetT.Remove(item);
            });
            return await this.SaveChangesAsync();
        }

        public async Task<Int32> Delete(IEnumerable<TEntity> items)
        {
            await Task.Factory.StartNew(() =>
            {
                this.DbSetT.Attach((items as List<TEntity>)[0]);
                this.DbSetT.RemoveRange(items);
            });
            var res = await this.SaveChangesAsync();
            return res;
        }

        //public async Task<IEnumerable<TEntity>> CustomQuery(Criteria criteria)
        //{
        //    return await this.DbSetT.SqlQuery(criteria.MySQLCompute()).ToListAsync();
        //}
        #endregion

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    if (provid == ProviderType.SQLite)
        //    {
        //        try
        //        {
                    
        //            var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<DbEntityManager<TEntity>>(modelBuilder);
        //            System.Data.Entity.Database.SetInitializer(sqliteConnectionInitializer);
        //        } catch (Exception e)
        //        {
        //            Console.WriteLine(e);
        //        }
                
        //    }
        //}
    }
}
