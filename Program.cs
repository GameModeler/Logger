using Logger.Appenders;
using Logger.Interfaces;
using Logger.Layout;
using Logger.Loggers;
using Logger.Utils;
using System;
using System.Windows.Forms;
using DataBase.Database.DbSettings;
using DataBase.Database.DbSettings.DbClasses;

namespace Logger
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            ////////////// DATABASE ////////////////////

            //// 1. Set the Database information 
            //DbSettings settingdb1 = new DbSettings();
            //settingdb1.DatabaseName = "db1";
            //settingdb1.Server = "localhost";
            //settingdb1.UserId = "root";


            ////// 2. Choose the provider
            ////DatabaseManager.Instance.SetProvider(ProviderType.SQLite);
            //DbEntityManager<Car> parking = new DbEntityManager<Car>(settingdb1, ProviderType.MySQL);

            //////3. Create a new Entity to manage the entity interaction with the database
            ////DbEntityManager<Car> parking = new DbEntityManager<Car>(settingdb1);

            //List<Car> cars = new List<Car>();

            //cars.Add(new Car { Manufacturer = "Nissan", Model = "370Z", Year = 2012 });
            //cars.Add(new Car { Manufacturer = "Ford", Model = "Mustang", Year = 2013 });
            //cars.Add(new Car { Manufacturer = "Chevrolet", Model = "Camaro", Year = 2012 });
            //cars.Add(new Car { Manufacturer = "Dodge", Model = "Charger", Year = 2013 });

            //parking.Insert(cars);

            //DbEntityManager<Car> parking2 = new DbEntityManager<Car>(DatabaseManager.Instance.GetDatabase("db1"));

            //parking2.Insert(cars);

            //Car car1 = parking.Get(1).Result;

            //DbEntityManager<Car> parking4 = new DbEntityManager<Car>();

            //Dictionary<string, IDbSettings> listeDb = DatabaseManager.Instance.databases;

            //List<Cat> cats = new List<Cat>();

            //cats.Add(new Cat { Name = "Minou", Color = "Blanc", Year = 2012 });
            //cats.Add(new Cat { Name = "Felix", Color = "Noir", Year = 2013 });

            //DbEntityManager<Cat> catHouse = new DbEntityManager<Cat>(settingdb1);

            //catHouse.Insert(cats);

            ////////////// LOGGER ////////////////////


            /************ CONSOLE *******************/

            // 1. Get a LoggerManager
            LoggerManager loggerManager = new LoggerManager();

            //// 2. Create a new Logger
            Loggers.Logger myLogger = (Loggers.Logger)loggerManager.CreateLogger();

            ////3. Log
            myLogger.Log("Hello World !");

            /************ CONSOLE with custom log pattern *******************/

            ////////////// TESTS 1 ////////////////////

            Loggers.Logger myLogger2 = (Loggers.Logger)loggerManager.CreateLogger("testLogger");

            string myPattern = LogElements.LOGGER_NAME.StrRef() + " / " + LogElements.MESSAGE.StrRef() + " / " + LogElements.TIMESTAMP.StrRef();

            ConsoleAppender myConsoleApp = (ConsoleAppender)myLogger2.AddAppender(AppenderType.CONSOLE);

            myConsoleApp.Layout = myPattern;

            myLogger2.Error("Salut les gens ;)");

            ////////////// TESTS 2 ////////////////////

            /************ Not log if log level lower than logger level *******************/

            Loggers.Logger myLogger3 = (Loggers.Logger)loggerManager.CreateLogger("testLogger3");
            myLogger3.Level = Level.ERROR;

            myLogger3.Trace("Un nouveau log"); // doesn't log

            ////////////// TESTS 3 ////////////////////

            /************ Duplicate Log **************/

            Loggers.Logger myLogger4 = (Loggers.Logger)loggerManager.CreateLogger("testLogger4");
            myLogger4.Level = Level.DEBUG;

            myLogger4.Warn("Un warn log");

            Loggers.Logger myLogger4_2 = (Loggers.Logger)loggerManager.DuplicateLogger("testLogger4");

            myLogger4_2.Warn("Un warn log dupliqué");


            //string myLogger4Name = myLogger4.Name;
            //string myLogger4Parent = myLogger4.Parent;
            //Console.WriteLine(myLogger4Name);
            //Console.WriteLine("Parent : " + myLogger4Parent);

            //string myLogger4_2Name = myLogger4_2.Name;
            //string myLogger4_2Parent = myLogger4_2.Parent;
            //Console.WriteLine(myLogger4_2Name);
            //Console.WriteLine("Parent : " + myLogger4_2Parent);

            ////////////// TESTS 5 ////////////////////

            /************ MESSAGE BOX **************/

            Loggers.Logger myLogger5 = (Loggers.Logger)loggerManager.CreateLogger("testLogger5");

            MessageBoxAppender myConsoleApp5 = (MessageBoxAppender)myLogger5.AddAppender(AppenderType.MESSAGE_BOX);

            ModalBox myBox = new ModalBox(LogElements.LOGGER_NAME.StrRef());

            myConsoleApp5.Box = myBox;

            myLogger5.Warn("Bonjour !");

            ////////////// TESTS 6 ////////////////////

            /************ MESSAGE BOX **************/

            Loggers.Logger myLogger6 = (Loggers.Logger)loggerManager.CreateLogger("testLogger6");

            MessageBoxAppender myConsoleApp6 = (MessageBoxAppender)myLogger6.AddAppender(AppenderType.MESSAGE_BOX);

            string captionPattern = LogElements.TIMESTAMP.StrRef() + " - " + LogElements.LEVEL.StrRef();

            ModalBox myBox2 = new ModalBox(captionPattern, MessageBoxIcon.Error);
            myBox2.Buttons = MessageBoxButtons.OKCancel;
            myBox2.setAction(DialogResult.OK, () => Console.WriteLine("Anne"));



            myConsoleApp6.Box = myBox2;

            //myLogger6.Error("Bonjour !");
            //myLogger6.Trace("Bonjour Trace !");
            //myLogger6.Debug("Bonjour Debug !");
            //myLogger6.Info("Bonjour info !");
            //myLogger6.Warn("Bonjour warn !");


            ////////////// TESTS 7 ////////////////////

            /************ TOAST **************/

            ToastAppender mytoastApp6 = (ToastAppender)myLogger6.AddAppender(AppenderType.TOAST);

            string ligne1 = LogElements.TIMESTAMP.StrRef("T") + " - " + LogElements.LOGGER_NAME.StrRef();
            string ligne2 = LogElements.MESSAGE.StrRef();

            ToastLayout toastLay = new ToastLayout(ligne1, ligne2);

            mytoastApp6.ToastLayout = toastLay;

            myLogger6.Error("Bonjour Bonjour!");

            ////////////// TESTS 8 ////////////////////

            /************ DATABASE **************/

            // Database information

            MySqlDatabase dbSettings = DatabaseFactory.MySqlDb.Set
                                                      .DatabaseName("logDb")
                                                      .Server("localhost")
                                                      .UserId("root").ToMySqlDatabase;

            // Create a logger
            Loggers.Logger myLog = (Loggers.Logger)loggerManager.CreateLogger("myLog");

            // Create a database Appender (correspond à une base de donnée)
            DataBaseAppender myDbApp = (DataBaseAppender)myLog.AddAppender(AppenderType.DATABASE);
            myDbApp.AttachDB(dbSettings);

            myLog.Error("Game Modeler !");

            ////////////// TESTS 8 ////////////////////

            /************ MESSAGE_BOX_CUSTOM with Xaml file **************/

            // Create a logger
            Loggers.Logger myLogger7 = (Loggers.Logger)loggerManager.CreateLogger("testLogger7");
            // Create a database Appender (correspond à une base de donnée)

            IAppender myMBCApp = myLogger7.AddAppender(AppenderType.MESSAGE_BOX_CUSTOM, typeof(MessageBoxCustom));

            myLogger7.Error("Game Modeler !");

            myLogger7.Error("Game Modeler 2!");

            ////////////// TESTS 9 ////////////////////

            /************ FILE APPENDER **************/

            IAppender myFileApp = myLogger7.AddAppender(AppenderType.FILE);
            myLogger7.Error("test du logger");
        }
    }
}
