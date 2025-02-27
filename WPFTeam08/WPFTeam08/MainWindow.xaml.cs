using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFTeam08
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // tijdelijke input
        string email = "thibault.lesecque@student.pxl.be";
        string password = "password123";

        public MainWindow()
        {
            InitializeComponent();
        }

        public void mnu_Menu_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            if (menuItem != null)
            {
                switch (menuItem.Name)
                {
                    case "mnu_Menu_Dashboard":
                        DashboardWindow dashboardWindow = new DashboardWindow();
                        dashboardWindow.Show();
                        break;
                    case "mnu_Menu_Clients":
                        ClientsWindow clientsWindow = new ClientsWindow();
                        clientsWindow.Show();
                        break;
                    case "mnu_Menu_Subscriptions":
                        SubscriptionsWindow subscriptionsWindow = new SubscriptionsWindow();
                        subscriptionsWindow.Show();
                        break;
                    case "mnu_Menu_Tasks":
                        TasksWindow tasksWindow = new TasksWindow();
                        tasksWindow.Show();
                        break;
                    default:
                        break;
                }
            }
        }

        public void loginButton_Click(object sender, RoutedEventArgs e)
        {
            Login();
        }

        public void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Login();
            }
        }

        private void Login()
        {
            if (LoginCheck())
            {
                mnu_Main.IsEnabled = true;
                loginStackPanel.IsEnabled = false;
            }
        }

        public bool LoginCheck()
        {
            if ((emailTextBox.Text == email) && (passwordPasswordBox.Password == password))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Foute inloggegevens!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                emailTextBox.Clear();
                passwordPasswordBox.Clear();
                return false;
            }
        }
    }
}