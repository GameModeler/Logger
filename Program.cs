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

            ////////////// LOGGER ////////////////////


            /************ CONSOLE *******************/

            // 1. Get a LoggerManager
            LoggerManager loggerManager = new LoggerManager();

            //// 2. Create a new Logger
            ILogger myLogger = loggerManager.CreateLogger();

            ////3. Log
            myLogger.Log("Hello World !");

            /************ CONSOLE with custom log pattern *******************/

            ////////////// TESTS 1 ////////////////////

            ILogger myLogger2 = loggerManager.CreateLogger("testLogger");

            string myPattern = LogElements.LOGGER_NAME.StrRef() + " / " + LogElements.MESSAGE.StrRef() + " / " + LogElements.TIMESTAMP.StrRef();

            ConsoleAppender myConsoleApp = (ConsoleAppender)myLogger2.AddAppender(AppenderType.CONSOLE);

            myConsoleApp.Layout = myPattern;

            myLogger2.Error("Salut les gens ;)");

            ////////////// TESTS 2 ////////////////////

            /************ Not log if log level lower than logger level *******************/

            ILogger myLogger3 = loggerManager.CreateLogger("testLogger3");
            myLogger3.Level = Level.ERROR;

            myLogger3.Trace("Un nouveau log"); // doesn't log

            ////////////// TESTS 3 ////////////////////

            /************ Duplicate Log **************/

            ILogger myLogger4 = loggerManager.CreateLogger("testLogger4");
            myLogger4.Level = Level.DEBUG;

            myLogger4.Warn("Un warn log");

            ILogger myLogger4_2 = loggerManager.DuplicateLogger("testLogger4");

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

            ILogger myLogger5 = loggerManager.CreateLogger("testLogger5");

            MessageBoxAppender myConsoleApp5 = (MessageBoxAppender)myLogger5.AddAppender(AppenderType.MESSAGE_BOX);

            ModalBox myBox = new ModalBox(LogElements.LOGGER_NAME.StrRef());

            myConsoleApp5.Box = myBox;

            myLogger5.Warn("Bonjour !");

            ////////////// TESTS 6 ////////////////////

            /************ MESSAGE BOX **************/

            ILogger myLogger6 = loggerManager.CreateLogger("testLogger6");

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
            ILogger myLog = loggerManager.CreateLogger("myLog");

            // Create a database Appender (correspond à une base de donnée)
            DataBaseAppender myDbApp = (DataBaseAppender)myLog.AddAppender(AppenderType.DATABASE);
            myDbApp.AttachDB(dbSettings);

            myLog.Error("Game Modeler !");

            ////////////// TESTS 8 ////////////////////

            /************ MESSAGE_BOX_CUSTOM with Xaml file **************/

            // Create a logger
            ILogger myLogger7 = loggerManager.CreateLogger("testLogger7");
            // Create a database Appender (correspond à une base de donnée)

            IAppender myMBCApp = myLogger7.AddAppender(AppenderType.MESSAGE_BOX_CUSTOM, typeof(MessageBoxCustom));

            myLogger7.Error("Game Modeler !");

            myLogger7.Error("Game Modeler 2!");

            ////////////// TESTS 9 ////////////////////

            /************ FILE APPENDER **************/

            var myFileApp = (FileAppender)myLogger7.AddAppender(AppenderType.FILE);

            myFileApp.Set.Name("testLoggerXml")
                         .Path(@"C:\Users\")
                         .Type(FileAppenderType.TEXT);

            myLogger7.Error("test du logger");

            myLogger7.Info("deuxième log");
        }
    }
}
