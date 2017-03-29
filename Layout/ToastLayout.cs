using Logger.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace Logger.Layout
{
    /// <summary>
    /// Represent a toast
    /// </summary>
    public class ToastLayout
    {
        /// <summary>
        /// Toast's template
        /// </summary>
        public ToastTemplateType Template { get; }

        /// <summary>
        /// Toast xml
        /// </summary>
        public XmlDocument ToastXml { get; }

        /// <summary>
        /// Toast's caption
        /// </summary>
        public string Caption { get; }

        //public List<LogElements> Elements { get; }

        /// <summary>
        /// List of the toast's elements
        /// </summary>
        public List<string> Elements { get; }

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="elem1"></param>
        /// <param name="elem2"></param>
        /// <param name="elem3"></param>
        public ToastLayout(string elem1, string elem2, string elem3)
        {
            Elements = new List<string>();

            Elements.Add(elem1);
            Elements.Add(elem2);
            Elements.Add(elem3);

            Template = ToastTemplateType.ToastImageAndText04;
            ToastXml = ToastNotificationManager.GetTemplateContent(Template);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="elem1"></param>
        /// <param name="elem2"></param>
        public ToastLayout(string elem1, string elem2)
        {
            Elements = new List<string>();

            Elements.Add(elem1);
            Elements.Add(elem2);

            Template = ToastTemplateType.ToastImageAndText04;
            ToastXml = ToastNotificationManager.GetTemplateContent(Template);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="caption"></param>
        public ToastLayout(string caption)
        {
            Elements = new List<string>();

            Elements.Add(caption);

            Template = ToastTemplateType.ToastImageAndText04;
            ToastXml = ToastNotificationManager.GetTemplateContent(Template);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public ToastLayout()
        {
            Elements = new List<string>();
            Elements.Add(LogElements.LOGGER_NAME.StrRef());
            Elements.Add(LogElements.MESSAGE.StrRef());
            Template = ToastTemplateType.ToastImageAndText04;
            ToastXml = ToastNotificationManager.GetTemplateContent(Template);
        }

        #endregion
    }
}


