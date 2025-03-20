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
using ClassLibTeam08.Business;
using ClassLibTeam08.Data;
using ClassLibrary08.Data.Framework;
using System.Net.Mail;
using System.Net;

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
            //InsertResult result = Users.Add(TxtFirst.Text, TxtLast.Text, TxtUserName.Text, TxtEmail.Text, TxtAdress.Text, TxtPassword.Text, TxtBirthday.Text, TxtPhone.Text);
        }

        private void SearchByID_Click(object sender, RoutedEventArgs e)
        {
            SelectResult selectResult = Users.GetUser(int.Parse(TXSearchID.Text));
            MessageBox.Show(selectResult.DataTable.Rows[0][1].ToString());
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteResult deleteResult = Users.DeleteUser(int.Parse(DeleteIeIdBox.Text));
        }

        private void BtChange_Click(object sender, RoutedEventArgs e)
        {
            UpdateResult updateResult = Users.UpdateUserData(int.Parse(TxtIDChange.Text) ,TxtFirstChange.Text, TxtLastChange.Text, TxtUserNameChange.Text, TxtEmail.Text, TxtAdress.Text, TxtPasswordChange.Text, TxtBirthdayChange.Text, TxtPhoneChange.Text);
        }
        private void SendNewPasswordEmail()
        {
            //var userResult = SelectByID(ID);


            string smtpServer = "smtp.gmail.com"; // SMTP-server 
            int port = 587;
            string fromEmail = "monohomepass@gmail.com";
            string fromPassword = "dndz vqer tfcm ierc"; // monohome app-wachtwoord!
            string toEmail = "Sergey.Skatchkov@gmail.com";

            try
            {
                using (SmtpClient smtp = new SmtpClient(smtpServer, port))
                {
                    smtp.Credentials = new NetworkCredential(fromEmail, fromPassword);
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.UseDefaultCredentials = false;

                    MailMessage mail = new MailMessage(fromEmail, toEmail)
                    {
                        Subject = "Test e-mail",
                        Body = "Dit is een testmail van monohoma pass verzonden via SMTP naar de klant.",
                        IsBodyHtml = false
                    };

                    smtp.Send(mail);
                    Console.WriteLine("E-mail verzonden!");
                }
            }
            catch (SmtpException smtpEx)
            {
                Console.WriteLine($"SMTP Fout bij verzenden van e-mail: {smtpEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fout bij verzenden van e-mail: {ex.Message}");
            }
        }
    }
}