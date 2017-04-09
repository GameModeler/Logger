using Logger.Interfaces;
using System;
using Logger.Loggers;
using Logger.Utils;
using DataBase.Json;
using DataBase.Yaml;
using DataBase.Xml;
using DataBase.Csv;
using DataBase.Binary;
using DataBase.Character;
using Logger.Appenders.FileAppenderFAPI.Interfaces;
using Logger.Appenders.FileAppenderFAPI;

namespace Logger.Appenders
{
    /// <summary>
    /// File Appender
    /// </summary>
    public class FileAppender : IAppender
    {

        private readonly FileAppenderFApi fileAppender;

        /// <summary>
        /// Layout
        /// </summary>
        public string Layout { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string AppenderName { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Appender File Path
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// File type
        /// </summary>
        public FileAppenderType Type { get; set; }

        private const string DEFAULT_FILE_APPENDER_NAME = "GM_FILE_APPENDER";
        private const string DEFAULT_FILE_PATH = @"C:\Users\";
        private const string DEFAULT_FILE_NAME = "gm_logger";
        private const FileAppenderType DEFAULT_FILE_TYPE = FileAppenderType.TEXT;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="name"></param>
        public FileAppender(string name)
        {
            Layout = LogPatternConstants.DEFAULT_PATTERN;
            AppenderName = String.IsNullOrEmpty(name) ? DEFAULT_FILE_APPENDER_NAME : name;
            Name = DEFAULT_FILE_NAME;
            Path = DEFAULT_FILE_PATH;
            Type = DEFAULT_FILE_TYPE;

            fileAppender = new FileAppenderFApi(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public FileAppender FilePath(string path)
        {
            Path = path;
            return this;
        }

        /// <summary>
        /// Appends the log
        /// </summary>
        /// <param name="log"></param>
        public void DoAppend(Log log)
        {
            writeInTypeFile(log);
        }

        private void writeInTypeFile(Log log)
        {
            switch(Type)
            {
                case FileAppenderType.JSON:

                    JsonManager.WriteToJsonFile<Log>(Path, Name, log);
                    break;

                case FileAppenderType.YAML:

                    YamlManager.WriteToYamlFile<Log>(Path, Name, log);
                    break;

                case FileAppenderType.XML:
                    XmlManager.WriteToXmlFile<Log>(Path, Name, log);
                    break;

                case FileAppenderType.CSV:

                    CsvManager.WriteToCsvFile<Log>(Path, Name, log);
                    break;

                case FileAppenderType.BINARY:

                    BinaryManager.WriteToBinaryFile<Log>(Path, Name, log);
                    break;

                case FileAppenderType.CHARACTER:
                    CharacterManager.WriteToCharacterFile<Log>(Path, Name, log);
                    break;

                case FileAppenderType.TEXT:
                default:

                    WriteToTxtFile(log);
                    break;
            }
        }

        private void WriteToTxtFile(Log log)
        {
            string toLog = LogPatterns.Reformate(Layout, log);
            string completPath = String.Format("{0}{1}{2}", Path, Name, ".txt");

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(completPath, true))
            {
                file.WriteLine(toLog);
            }
        }

        /// <summary>
        /// Initialize the File Appender fluent API
        /// </summary>
        public FileAppenderFApi Set
        {
            get { return fileAppender; }
        }
    }
}
