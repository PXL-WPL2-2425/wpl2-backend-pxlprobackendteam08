using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Utils;

namespace ClassLibrary1.Data
{
    public class MimeMailWrapper
    {
        string _password = "dndz vqer tfcm ierc";
        string _monoHomemail = "monohomepass@gmail.com";
        BodyBuilder _bodyBuilder = new BodyBuilder();



        public void SendEmail(string emailAdress, string subject, BodyBuilder bodyBuilder)
        {
            _bodyBuilder = bodyBuilder;

            var email = new MimeMessage();
            email.From.Add(new MailboxAddress("MonoHome", "monohomepass@gmail.com"));
            email.To.Add(new MailboxAddress("reciever", emailAdress));
            email.Subject = subject;

            AddEndOfEmail();
            email.Body = bodyBuilder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                client.Authenticate(_monoHomemail, _password);
                client.Send(email);
                client.Disconnect(true);
            }
        }

        void AddEndOfEmail()
        {
            Uri imageLink = new Uri("Assets\\MonoHomeLabel.png", UriKind.Relative);
            var image = _bodyBuilder.LinkedResources.Add("C:\\Users\\Gebruiker\\Source\\Repos\\wpl2-backend-pxlprobackendteam08DEBUG\\WPFTeam08\\WebApiTeam08\\Assets\\MonoHomeLabel.png");
            image.ContentId = MimeUtils.GenerateMessageId();

            string uriTest = imageLink.ToString();

            _bodyBuilder.HtmlBody += string.Format(@"<center><img src=""cid:{0}""></center>", image.ContentId);
        }




    }
}



