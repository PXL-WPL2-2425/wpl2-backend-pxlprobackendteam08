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
    /// Interaction logic for UpdateUserWindow.xaml
    /// </summary>
    public partial class UpdateUserWindow : Window
    {
        public UpdateUserWindow()
        {
            InitializeComponent();
        }

        private void updateUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (checkEmpty())
            {

            }
            else
            {
                MessageBox.Show("Alle velden moeten ingevuld worden!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void checkUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(userIDTextBox.Text))
            {

            }
            else
            {
                MessageBox.Show("Er moet een geldige user ID ingevuld worden!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void updateUserWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }

        private bool checkEmpty()
        {
            bool isNotEmpty = rootGrid.Children
                .OfType<StackPanel>()
                .SelectMany(stackpanel => stackpanel.Children.OfType<TextBox>())
                .All(textbox => !string.IsNullOrWhiteSpace(textbox.Text));

            return isNotEmpty;
        }
    }
}
