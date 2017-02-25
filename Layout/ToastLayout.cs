using GMLogger.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace GMLogger.Layout
{
    /// <summary>
    /// Represent a toast
    /// </summary>
    public class ToastLayout
    {
        public ToastTemplateType Template { get; }
        public XmlDocument ToastXml { get; }

        public string Caption { get; }

        //public List<LogElements> Elements { get; }

        public List<string> Elements { get; }

        public ToastLayout(string elem1, string elem2, string elem3)
        {
            Elements = new List<string>();

            Elements.Add(elem1);
            Elements.Add(elem2);
            Elements.Add(elem3);

            Template = ToastTemplateType.ToastImageAndText04;
            ToastXml = ToastNotificationManager.GetTemplateContent(Template);
        }

        public ToastLayout(string elem1, string elem2)
        {
            Elements = new List<string>();

            Elements.Add(elem1);
            Elements.Add(elem2);

            Template = ToastTemplateType.ToastImageAndText04;
            ToastXml = ToastNotificationManager.GetTemplateContent(Template);
        }

        public ToastLayout(string caption)
        {
            Elements = new List<string>();

            Elements.Add(caption);

            Template = ToastTemplateType.ToastImageAndText04;
            ToastXml = ToastNotificationManager.GetTemplateContent(Template);
        }

        public ToastLayout()
        {
            Elements = new List<string>();
            Elements.Add(LogElements.LOGGER_NAME.StrRef());
            Elements.Add(LogElements.MESSAGE.StrRef());
            Template = ToastTemplateType.ToastImageAndText04;
            ToastXml = ToastNotificationManager.GetTemplateContent(Template);
        }
    }
}


