// <copyright file="FileAppender.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Logger.Appenders
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using DataBase.Binary;
    using DataBase.Character;
    using DataBase.Csv;
    using DataBase.Json;
    using DataBase.Xml;
    using DataBase.Yaml;
    using Logger.Appenders.FileAppenderFAPI;
    using Logger.Interfaces;
    using Logger.Loggers;
    using Logger.Utils;

    /// <summary>
    /// File Appender
    /// </summary>
    public class FileAppender : IAppender
    {

        private const string DEFAULT_FILE_APPENDER_NAME = "GM_FILE_APPENDER";
        private const string DEFAULT_FILE_PATH = @"C:\Users\";
        private const string DEFAULT_FILE_NAME = "gm_logger";
        private const FileAppenderType DEFAULT_FILE_TYPE = FileAppenderType.TEXT;

        private readonly FileAppenderFApi fileAppender;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileAppender"/> class.
        /// Constructeur
        /// </summary>
        /// <param name="name">Name of the appender</param>
        public FileAppender(string name)
        {
            this.Layout = LogPatternConstants.DEFAULT_PATTERN;
            this.AppenderName = string.IsNullOrEmpty(name) ? DEFAULT_FILE_APPENDER_NAME : name;
            this.Name = DEFAULT_FILE_NAME;
            this.Path = DEFAULT_FILE_PATH;
            this.Type = DEFAULT_FILE_TYPE;

            this.fileAppender = new FileAppenderFApi(this);
        }

        /// <summary>
        /// Gets appender's type
        /// </summary>
        public AppenderType AppenderType { get; }

        /// <summary>
        /// Gets or sets layout
        /// </summary>
        public string Layout { get; set; }

        /// <summary>
        /// Gets or sets name
        /// </summary>
        public string AppenderName { get; set; }

        /// <summary>
        /// Gets or sets name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets appender File Path
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets file type
        /// </summary>
        public FileAppenderType Type { get; set; }

        /// <summary>
        /// Gets File Appender fluent API
        /// </summary>
        public FileAppenderFApi Set
        {
            get { return this.fileAppender; }
        }

        /// <summary>
        /// Appends the log
        /// </summary>
        /// <param name="log">The Log</param>
        public void DoAppend(ILog log)
        {
            this.WriteInTypeFile(log as Log);
        }

        /// <summary>
        /// Appends the log asynchronously
        /// </summary>
        /// <param name="log">The log</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task DoAppendAsync(ILog log)
        {
            await Task.Run(() => this.WriteInTypeFile(log as Log));
        }

        private void WriteInTypeFile(Log log)
        {
            switch (this.Type)
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

                    this.WriteToTxtFile(log);
                    break;
            }
        }

        private void WriteToTxtFile(ILog log)
        {
            string toLog = LogPatterns.Reformate(this.Layout, log);
            string completPath = string.Format("{0}{1}{2}", this.Path, this.Name, ".txt");

            using (StreamWriter file = new StreamWriter(completPath, true))
            {
                file.WriteLine(toLog);
            }
        }
    }
}
