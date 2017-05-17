using Logger.Interfaces;
using Logger.Layout;
using Logger.Loggers;
using Logger.Utils;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logger.Appenders
{
    /// <summary>
    /// Display a log into a MessageBox
    /// </summary>
    public class MessageBoxAppender : IAppender
    {
        private const string DEFAULT_MESSAGE_BOX_NAME = "GM_MESSAGE_BOX_APPENDER";

        /// <summary>
        /// Appender's type
        /// </summary>
        public AppenderType AppenderType { get; }

        /// <summary>
        /// Appender layout
        /// </summary>
        public string Layout { get; set; }

        /// <summary>
        /// Message box 
        /// </summary>
        public ModalBox Box { get; set; }

        /// <summary>
        /// Appender's name
        /// </summary>
        public string AppenderName { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"></param>
        public MessageBoxAppender(string name)
        {
            Layout = LogPatternConstants.DEFAULT_PATTERN;
            Box = new ModalBox();
            AppenderName = String.IsNullOrEmpty(name) ? DEFAULT_MESSAGE_BOX_NAME : name;
        }

        /// <summary>
        /// Appends the log
        /// </summary>
        /// <param name="log"></param>
        public void DoAppend(Log log)
        {
            string toCaption = LogPatterns.Reformate(Box.Caption, log);
            string toLog = LogPatterns.Reformate(Layout, log);
            DisplayBox(Box, toCaption, toLog);
        }

        /// <summary>
        /// Appends the log asynchronously
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
        public async Task DoAppendAsync(Log log)
        {
            await Task.Run(() => {

                string toCaption = LogPatterns.Reformate(Box.Caption, log);
                string toLog = LogPatterns.Reformate(Layout, log);
                DisplayBox(Box, toCaption, toLog);
            });
        }

        private DialogResult DisplayBox(ModalBox box, string capt, string logMsg)
        {
            DialogResult result = 0;
            if (box.HasIcon)
            {
                result = MessageBox.Show(logMsg, capt, Box.Buttons, Box.Icon);

            } else
            {
                result = MessageBox.Show(logMsg, capt, Box.Buttons);
            }

            foreach (var pair in Box.ButtonAction)
            {
                if (result == pair.Key)
                {
                    pair.Value();
                }
            }

            return result;
        }
    }
}
