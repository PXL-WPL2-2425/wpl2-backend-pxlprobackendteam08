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
    /// Interaction logic for ClientsWindow.xaml
    /// </summary>
    public partial class ClientsWindow : Window
    {
        public ClientsWindow()
        {
            InitializeComponent();
        }

        private void addUserButton_Click(object sender, RoutedEventArgs e)
        {
            AddUserWindow addUserWindow = new AddUserWindow();
            addUserWindow.ShowDialog();
        }

        private void updateUserButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateUserWindow updateUserWindow = new UpdateUserWindow();
            updateUserWindow.ShowDialog();
        }

        private void changeUserPasswordButton_Click(object sender, RoutedEventArgs e)
        {
            ChangePasswordUserWindow changePasswordWindow = new ChangePasswordUserWindow();
            changePasswordWindow.ShowDialog();
        }
    }
}
