using Logger.Interfaces;
using Logger.Layout;
using Logger.Loggers;
using Logger.Utils;
using System;
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
        /// Appender's type
        /// </summary>
        public AppenderType AppenderType { get; }

        /// <summary>
        /// Appender's name
        /// </summary>
        public string AppenderName { get; set; }

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
            AppenderName = String.IsNullOrEmpty(name) ? DEFAULT_TOAST_NAME : name;
        }

        /// <summary>
        /// Appends the log
        /// </summary>
        /// <param name="log"></param>
        public void DoAppend(Log log)
        {
            // Construction du toast
           ToastLayout.ToastXml.BuildXmlTemplate(ToastLayout.Elements, log);      
            
            var toast = new ToastNotification(ToastLayout.ToastXml);
            ToastNotificationManager.CreateToastNotifier(AppenderName).Show(toast);
        }

        /// <summary>
        /// Appends the log asynchronously
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
        public async Task DoAppendAsync(Log log)
        {
            await Task.Run(() => {
                ToastLayout.ToastXml.BuildXmlTemplate(ToastLayout.Elements, log);
                var toast = new ToastNotification(ToastLayout.ToastXml);
                ToastNotificationManager.CreateToastNotifier(AppenderName).Show(toast);
            });
        }
    }
}
