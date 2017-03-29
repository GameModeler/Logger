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

        /// <summary>
        /// Icon
        /// </summary>
        public MessageBoxIcon Icon { get; set; }

        /// <summary>
        /// Buttons
        /// </summary>
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

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="icon"></param>
        public ModalBox(string caption, MessageBoxIcon icon)
        {
            Caption = caption;
            Icon = icon;
            Buttons = MessageBoxButtons.OKCancel;
            hasIcon = true;
        }

        /// <summary>
        /// Construcctor
        /// </summary>
        /// <param name="caption"></param>
        public ModalBox(string caption)
        {
            Caption = caption;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public ModalBox()
        {
            Caption = LogElements.LOGGER_NAME.GetStringValue();
        }

        /// <summary>
        /// Checks if has icon
        /// </summary>
        public bool HasIcon
        {
            get
            {
                return hasIcon;
            }
        }

        /// <summary>
        /// Set an action to a button
        /// </summary>
        /// <param name="buttonName"></param>
        /// <param name="doAction"></param>
        public void setAction(DialogResult buttonName, Action doAction)
        {
            buttonsActions.Add(buttonName, doAction);
        }

        /// <summary>
        /// Dictionnary of buttons and their actions
        /// </summary>
        public Dictionary<DialogResult, Action> ButtonAction
        {
            get {
                return buttonsActions;
            }
        }
    }
}
