using Logger.Interfaces;
using Logger.Layout;
using Logger.Loggers;
using Logger.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Notifications;

namespace Logger.Appenders
{
    /// <summary>
    /// Display logs into Toast
    /// </summary>
    public class ToastAppender : IAppender
    {
        private const string DEFAULT_TOAST_NAME = "GM_TOAST_APPENDER";

        /// <summary>
        /// Appender's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Appender's layout
        /// </summary>
        public string Layout {get; set;}

        /// <summary>
        /// Toast layout
        /// </summary>
        public ToastLayout ToastLayout { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"></param>
        public ToastAppender(string name)
        {
            ToastLayout = new ToastLayout();
            Name = name == null ? DEFAULT_TOAST_NAME : name;
        }

        /// <summary>
        /// Appends the log
        /// </summary>
        /// <param name="log"></param>
        public void DoAppend(Log log)
        {
            ToastLayout.ToastXml.BuildXmlTemplate(ToastLayout.Elements, log);

            var toast = new ToastNotification(ToastLayout.ToastXml);
            ToastNotificationManager.CreateToastNotifier(Name).Show(toast);
        }
    }
}
