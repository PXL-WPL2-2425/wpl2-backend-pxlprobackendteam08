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
    /// Interaction logic for DeleteUserWindow.xaml
    /// </summary>
    public partial class DeleteUserWindow : Window
    {
        public DeleteUserWindow()
        {
            InitializeComponent();
        }

        private void deleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(userIDTextBox.Text))
            {
                MessageBoxResult result = MessageBox.Show("Ben je zeker dat je deze gebruiker wil verwijderen?", "Verwijderen", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    // verwijder gebruiker
                }
            }
            else
            {
                MessageBox.Show("User ID moet ingevuld zijn!");
            }
        }

        private void deleteUserWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }
    }
}
