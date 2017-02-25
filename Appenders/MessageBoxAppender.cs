using GMLogger.Interfaces;
using GMLogger.Layout;
using GMLogger.Loggers;
using GMLogger.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public string Layout { get; set; }

        public ModalBox Box { get; set; }

        public string Name { get; set; }

        public MessageBoxAppender(string name)
        {
            Layout = LogPatternConstants.DEFAULT_PATTERN;
            Box = new ModalBox();
            Name = name == null ? DEFAULT_MESSAGE_BOX_NAME : name;
        }

        /// <summary>
        /// Append the log
        /// </summary>
        /// <param name="log"></param>
        public void DoAppend(Log log)
        {
            string toCaption = LogPatterns.Reformate(Box.Caption, log);
            string toLog = LogPatterns.Reformate(Layout, log);
            DisplayBox(Box, toCaption, toLog);
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
