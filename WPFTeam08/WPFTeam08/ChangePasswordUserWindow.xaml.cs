using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFTeam08
{
    /// <summary>
    /// Interaction logic for ChangePasswordUserWindow.xaml
    /// </summary>
    public partial class ChangePasswordUserWindow : Window
    {
        public ChangePasswordUserWindow()
        {
            InitializeComponent();
        }

        private void changePasswordButton_Click(object sender, RoutedEventArgs e)
        {
            if (checkEmpty())
            {

            }
            else
            {
                MessageBox.Show("Alle velden moeten ingevuld worden!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void changePasswordUserWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }

        private bool checkEmpty()
        {
            bool isNotEmpty = rootStackPanel.Children
                .OfType<TextBox>()
                .All(textbox => !string.IsNullOrWhiteSpace(textbox.Text));

            return isNotEmpty;
        }
    }
}
