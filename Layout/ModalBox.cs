namespace Logger.Layout
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using Utils;

    /// <summary>
    /// Represent a windows Message Box
    /// </summary>
    public class ModalBox
    {
        private Dictionary<DialogResult, Action> buttonsActions = new Dictionary<DialogResult, Action>();

        private bool hasIcon = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModalBox"/> class.
        /// </summary>
        /// <param name="caption">Caption</param>
        /// <param name="buttons">Buttons</param>
        /// <param name="icon">icon</param>
        public ModalBox(string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            this.Caption = caption;
            this.Buttons = buttons;
            this.Icon = icon;
            this.hasIcon = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModalBox"/> class.
        /// </summary>
        /// <param name="caption">Caption</param>
        /// <param name="buttons">Buttons</param>
        public ModalBox(string caption, MessageBoxButtons buttons)
        {
            this.Caption = caption;
            this.Buttons = buttons;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModalBox"/> class.
        /// Constructor
        /// </summary>
        /// <param name="caption">Caption</param>
        /// <param name="icon">Icon</param>
        public ModalBox(string caption, MessageBoxIcon icon)
        {
            this.Caption = caption;
            this.Icon = icon;
            this.Buttons = MessageBoxButtons.OKCancel;
            this.hasIcon = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModalBox"/> class.
        /// </summary>
        /// <param name="caption">Caption</param>
        public ModalBox(string caption)
        {
            this.Caption = caption;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModalBox"/> class.
        /// Constructor
        /// </summary>
        public ModalBox()
        {
            this.Caption = LogElements.LOGGER_NAME.GetStringValue();
        }

        /// <summary>
        /// Gets or sets text
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets caption
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        /// Gets or sets icon
        /// </summary>
        public MessageBoxIcon Icon { get; set; }

        /// <summary>
        /// Gets or sets buttons
        /// </summary>
        public MessageBoxButtons Buttons { get; set; }

        /// <summary>
        /// Gets a value indicating whether checks if has icon
        /// </summary>
        public bool HasIcon
        {
            get
            {
                return this.hasIcon;
            }
        }

        /// <summary>
        /// Gets dictionnary of buttons and their actions
        /// </summary>
        public Dictionary<DialogResult, Action> ButtonActions
        {
            get
            {
                return this.buttonsActions;
            }
        }

        /// <summary>
        /// Set an action to a button
        /// </summary>
        /// <param name="buttonName">Button type</param>
        /// <param name="doAction">The method to add</param>
        public void SetAction(DialogResult buttonName, Action doAction)
        {
            this.buttonsActions.Add(buttonName, doAction);
        }
    }
}
