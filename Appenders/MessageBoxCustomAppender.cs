// <copyright file="MessageBoxCustomAppender.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Logger.Appenders
{
    using System.Reflection;
    using System.Threading.Tasks;
    using Logger.Interfaces;
    using Utils;

    /// <summary>
    /// Display logs into a custom message box
    /// </summary>
    /// <typeparam name="T">Type of the custom box appender</typeparam>
    public class MessageBoxCustomAppender<T> : IAppender
        where T : new()
    {

        private const string DEFAULT_MESSAGE_BOX_CUSTOM_NAME = "GM_MESSAGE_BOX_CUSTOM_APPENDER";

        private T obj;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageBoxCustomAppender{T}"/> class.
        /// Constructor
        /// </summary>
        /// <param name="name">Name of the appender</param>
        public MessageBoxCustomAppender(string name)
        {
            this.AppenderName = string.IsNullOrEmpty(name) ? DEFAULT_MESSAGE_BOX_CUSTOM_NAME : name;
        }

        /// <summary>
        /// Gets appender's type
        /// </summary>
        public AppenderType AppenderType { get; }

        /// <summary>
        /// Gets or sets appender's layout
        /// </summary>
        public string Layout { get; set; }

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
            this.obj = new T();

            MethodInfo showDMethod = this.obj.GetType().GetMethod("ShowDialog");
            showDMethod.Invoke(this.obj, null);
        }

        /// <summary>
        /// Appends the log asynchronously
        /// </summary>
        /// <param name="log">The log</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task DoAppendAsync(ILog log)
        {
            this.obj = new T();

            await Task.Run(() => {
                MethodInfo showDMethod = this.obj.GetType().GetMethod("ShowDialog");
                showDMethod.Invoke(this.obj, null);
            });
        }
    }
}
