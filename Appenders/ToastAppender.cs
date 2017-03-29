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

        public string Name { get; set; }

        public string Layout {get; set;}

        public ToastLayout ToastLayout { get; set; }

        public ToastAppender(string name)
        {
            ToastLayout = new ToastLayout();
            Name = name == null ? DEFAULT_TOAST_NAME : name;
        }

        public void DoAppend(Log log)
        {
            ToastLayout.ToastXml.BuildXmlTemplate(ToastLayout.Elements, log);

            var toast = new ToastNotification(ToastLayout.ToastXml);
            ToastNotificationManager.CreateToastNotifier(Name).Show(toast);
        }
    }
}
