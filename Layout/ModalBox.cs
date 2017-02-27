using GMLogger.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GMLogger.Layout
{
    /// <summary>
    /// Represent a windows Message Box
    /// </summary>
    public class ModalBox
    {
        /// <summary>
        /// Message Box Text
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Message Box Caption
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        /// Message box Icon
        /// </summary>
        public MessageBoxIcon Icon { get; set; }

        /// <summary>
        /// Message Box Buttons
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
        /// Construcor
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
        /// Constructor
        /// </summary>
        public bool HasIcon
        {
            get
            {
                return hasIcon;
            }
        }

        /// <summary>
        /// Add action to the buttons
        /// </summary>
        /// <param name="buttonName"></param>
        /// <param name="doAction"></param>
        public void setAction(DialogResult buttonName, Action doAction)
        {
            buttonsActions.Add(buttonName, doAction);
        }

        /// <summary>
        /// Dictionnary of button associated with their actions
        /// </summary>
        public Dictionary<DialogResult, Action> ButtonAction
        {
            get {
                return buttonsActions;
            }
        }
    }
}
