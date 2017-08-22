namespace Logger.Layout
{
    using System.Windows; // Window, RoutedEventArgs, IInputElement, DependencyObject

    /// <summary>
    /// Custom Message box example
    /// </summary>
    public partial class MessageBoxCustom : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageBoxCustom"/> class.
        /// </summary>
        public MessageBoxCustom()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello, world!");
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Bye, world!");
        }
    }
}
