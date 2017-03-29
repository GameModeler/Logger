using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows; // Window, RoutedEventArgs, IInputElement, DependencyObject
using System.Windows.Controls; // Validation
using System.Windows.Input; // Keyboard

namespace Logger.Layout
{
    /// <summary>
    /// 
    /// </summary>
    public partial class MessageBoxCustom : Window
    {

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
