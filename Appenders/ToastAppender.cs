// <copyright file="ToastAppender.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Logger.Appenders
{
    using System;
    using System.Threading.Tasks;
    using Logger.Interfaces;
    using Logger.Layout;
    using Logger.Loggers;
    using Logger.Utils;
    using Windows.UI.Notifications;

    /// <summary>
    /// Display logs into Toast
    /// </summary>
    public class ToastAppender : IAppender
    {
        private const string DEFAULT_TOAST_NAME = "GM_TOAST_APPENDER";

        /// <summary>
        /// Initializes a new instance of the <see cref="ToastAppender"/> class.
        /// </summary>
        /// <param name="name">Name of the appender</param>
        public ToastAppender(string name)
        {
            this.ToastLayout = new ToastLayout();
            this.AppenderName = string.IsNullOrEmpty(name) ? DEFAULT_TOAST_NAME : name;
        }

        /// <summary>
        /// Gets appender's type
        /// </summary>
        public AppenderType AppenderType { get; }

        /// <summary>
        /// Gets or sets appender's name
        /// </summary>
        public string AppenderName { get; set; }

        /// <summary>
        /// Gets or sets appender's layout
        /// </summary>
        public string Layout {get; set; }

        /// <summary>
        /// Gets or sets toast layout
        /// </summary>
        public ToastLayout ToastLayout { get; set; }

        /// <summary>
        /// Appends the log
        /// </summary>
        /// <param name="log">The log</param>
        public void DoAppend(ILog log)
        {
            // Construction du toast
           this.ToastLayout.ToastXml.BuildXmlTemplate(this.ToastLayout.Elements, log);
           var toast = new ToastNotification(this.ToastLayout.ToastXml);
           ToastNotificationManager.CreateToastNotifier(this.AppenderName).Show(toast);
        }

        /// <summary>
        /// Appends the log asynchronously
        /// </summary>
        /// <param name="log">The log</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task DoAppendAsync(ILog log)
        {
            await Task.Run(() => {
                this.ToastLayout.ToastXml.BuildXmlTemplate(this.ToastLayout.Elements, log);
                var toast = new ToastNotification(this.ToastLayout.ToastXml);
                ToastNotificationManager.CreateToastNotifier(this.AppenderName).Show(toast);
            });
        }
    }
}
