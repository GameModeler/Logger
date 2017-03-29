using Logger.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logger.Layout
{
    /// <summary>
    /// Represent a windows Message Box
    /// </summary>
    public class ModalBox
    {
        public string Text { get; set; }
        public string Caption { get; set; }

        public MessageBoxIcon Icon { get; set; }

        public MessageBoxButtons Buttons { get; set; }

        private Dictionary<DialogResult, Action> buttonsActions = new Dictionary<DialogResult, Action>();

        bool hasIcon = false;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="buttons"></param>
        /// <param name="icon"></param>
        public ModalBox(string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {            
            Caption = caption;
            Buttons = buttons;
            Icon = icon;
            hasIcon = true;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="buttons"></param>
        public ModalBox(string caption, MessageBoxButtons buttons)
        {
            Caption = caption;
            Buttons = buttons;
        }

        public ModalBox(string caption, MessageBoxIcon icon)
        {
            Caption = caption;
            Icon = icon;
            Buttons = MessageBoxButtons.OKCancel;
            hasIcon = true;
        }

        public ModalBox(string caption)
        {
            Caption = caption;
        }

        public ModalBox()
        {
            Caption = LogElements.LOGGER_NAME.GetStringValue();
        }

        public bool HasIcon
        {
            get
            {
                return hasIcon;
            }
        }

        public void setAction(DialogResult buttonName, Action doAction)
        {
            buttonsActions.Add(buttonName, doAction);
        }

        public Dictionary<DialogResult, Action> ButtonAction
        {
            get {
                return buttonsActions;
            }
        }
    }
}
