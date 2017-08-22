namespace Logger.Layout
{
    using System.Collections.Generic;
    using Utils;
    using Windows.Data.Xml.Dom;
    using Windows.UI.Notifications;

    /// <summary>
    /// Represent a toast
    /// </summary>
    public class ToastLayout
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ToastLayout"/> class.
        /// Constructor
        /// </summary>
        /// <param name="elem1">Line 1</param>
        /// <param name="elem2">Line 2</param>
        /// <param name="elem3">line 3</param>
        public ToastLayout(string elem1, string elem2, string elem3)
        {
            this.Elements = new List<string>();

            this.Elements.Add(elem1);
            this.Elements.Add(elem2);
            this.Elements.Add(elem3);

            this.Template = ToastTemplateType.ToastImageAndText04;
            this.ToastXml = ToastNotificationManager.GetTemplateContent(this.Template);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToastLayout"/> class.
        /// Constructor
        /// </summary>
        /// <param name="elem1">Line 1</param>
        /// <param name="elem2">line 2</param>
        public ToastLayout(string elem1, string elem2)
        {
            this.Elements = new List<string>();

            this.Elements.Add(elem1);
            this.Elements.Add(elem2);

            this.Template = ToastTemplateType.ToastImageAndText04;
            this.ToastXml = ToastNotificationManager.GetTemplateContent(this.Template);


        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToastLayout"/> class.
        /// </summary>
        /// <param name="caption">Caption</param>
        public ToastLayout(string caption)
        {
            this.Elements = new List<string>();

            this.Elements.Add(caption);

            this.Template = ToastTemplateType.ToastImageAndText04;
            this.ToastXml = ToastNotificationManager.GetTemplateContent(this.Template);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToastLayout"/> class.
        /// Constructor
        /// </summary>
        public ToastLayout()
        {
            this.Elements = new List<string>();
            this.Elements.Add(LogElements.LOGGER_NAME.StrRef());
            this.Elements.Add(LogElements.MESSAGE.StrRef());
            this.Template = ToastTemplateType.ToastImageAndText04;
            this.ToastXml = ToastNotificationManager.GetTemplateContent(this.Template);
        }

        /// <summary>
        /// Gets toast's template
        /// </summary>
        public ToastTemplateType Template { get; }

        /// <summary>
        /// Gets toast xml
        /// </summary>
        public XmlDocument ToastXml { get; }

        /// <summary>
        /// Gets toast's caption
        /// </summary>
        public string Caption { get; }

        // public List<LogElements> Elements { get; }

        /// <summary>
        /// Gets list of the toast's elements
        /// </summary>
        public List<string> Elements { get; }
    }
}