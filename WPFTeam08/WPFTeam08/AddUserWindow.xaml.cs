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
    /// Interaction logic for AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        public AddUserWindow()
        {
            InitializeComponent();
        }

        private void addUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (checkEmpty())
            {

            }
            else
            {
                MessageBox.Show("Alle velden moeten ingevuld worden!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void resetContentButton_Click(object sender, RoutedEventArgs e)
        {
            resetContent();
        }

        private void addUserWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }

        private void resetContent()
        {
            foreach (var textBox in rootGrid.Children.OfType<StackPanel>().SelectMany(sp => sp.Children.OfType<TextBox>()))
            {
                textBox.Text = string.Empty;
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
