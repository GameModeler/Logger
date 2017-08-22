// <copyright file="MessageBoxAppender.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Logger.Appenders
{
    using System;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Logger.Interfaces;
    using Logger.Layout;
    using Logger.Loggers;
    using Logger.Utils;

    /// <summary>
    /// Display a log into a MessageBox
    /// </summary>
    public class MessageBoxAppender : IAppender
    {
        private const string DEFAULT_MESSAGE_BOX_NAME = "GM_MESSAGE_BOX_APPENDER";

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageBoxAppender"/> class.
        /// </summary>
        /// <param name="name">Name of the appender</param>
        public MessageBoxAppender(string name)
        {
            this.Layout = LogPatternConstants.DEFAULT_PATTERN;
            this.Box = new ModalBox();
            this.AppenderName = string.IsNullOrEmpty(name) ? DEFAULT_MESSAGE_BOX_NAME : name;
        }

        /// <summary>
        /// Gets appender's type
        /// </summary>
        public AppenderType AppenderType { get; }

        /// <summary>
        /// Gets or sets appender layout
        /// </summary>
        public string Layout { get; set; }

        /// <summary>
        /// Gets or sets message box 
        /// </summary>
        public ModalBox Box { get; set; }

        /// <summary>
        /// Gets or sets appender's name
        /// </summary>
        public string AppenderName { get; set; }

        /// <summary>
        /// Appends the log
        /// </summary>
        /// <param name="log">The log</param>
        public void DoAppend(ILog log)
        {
            string toCaption = LogPatterns.Reformate(this.Box.Caption, log);
            string toLog = LogPatterns.Reformate(this.Layout, log);
            this.DisplayBox(this.Box, toCaption, toLog);
        }

        /// <summary>
        /// Appends the log asynchronously
        /// </summary>
        /// <param name="log">The log</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task DoAppendAsync(ILog log)
        {
            await Task.Run(() => {

                string toCaption = LogPatterns.Reformate(this.Box.Caption, log);
                string toLog = LogPatterns.Reformate(this.Layout, log);
                this.DisplayBox(this.Box, toCaption, toLog);
            });
        }

        private void DisplayBox(ModalBox box, string capt, string logMsg)
        {
            DialogResult result = 0;
            if (box.HasIcon)
            {
                result = MessageBox.Show(logMsg, capt, this.Box.Buttons, this.Box.Icon);

            } else
            {
                result = MessageBox.Show(logMsg, capt, this.Box.Buttons);
            }

            foreach (var pair in this.Box.ButtonActions)
            {
                if (result == pair.Key)
                {
                    pair.Value();
                }
            }
        }
    }
}
