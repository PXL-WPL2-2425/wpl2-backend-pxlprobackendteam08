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
using ClassLibTeam08.Data.Framework;
using ClassLibTeam08.Business.Entities;
using ClassLibTeam08.Data;

namespace WPFTeam08
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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

        private void ChangePassword_button_click(object sender, RoutedEventArgs e)
        {
            UpdateResult updateResult = Users.ChangePassWord(int.Parse(TxtID.Text), TxtnewPassword.Text);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            InsertResult result = Users.Add(TxtFirst.Text, TxtLast.Text, TxtUserName.Text, TxtEmail.Text, TxtAdress.Text, TxtPassword.Text, TxtBirthday.Text, TxtPhone.Text);
        }

        private void SearchByID_Click(object sender, RoutedEventArgs e)
        {
            SelectResult selectResult = Users.GetUser(int.Parse(TXSearchID.Text));
            MessageBox.Show(selectResult.DataTable.Rows[0][1].ToString());
        }
    }
}