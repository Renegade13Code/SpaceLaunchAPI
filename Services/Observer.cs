using System.Net;
using System.Net.Mail;
using SpaceLaunchAPI.Repository;
using EASendMail;

namespace SpaceLaunchAPI.Services
{
    public class Observer : IObserver
    {
        public string Email { get; set; }

        public Observer(string email, ISubject subject)
        {
            Email = email;
            subject.RegisterObserver(this);
        }

        public void Update()
        {
            Console.WriteLine("sending email "+ Email );
            try
            {
                SmtpMail oMail = new SmtpMail("TryIt");

                // Your gmail email address
                oMail.From = "launchspace200@gmail.com";
                // Set recipient email address
                oMail.To = Email;

                // Set email subject
                oMail.Subject = "Space Launch Reminder";
                // Set email body
                oMail.TextBody = "this is a test mail from launch reminder";

                // Gmail SMTP server address
                SmtpServer oServer = new SmtpServer("smtp.gmail.com");

                // Gmail user authentication
                // For example: your email is "gmailid@gmail.com", then the user should be the same
                oServer.User = "launchspace200@gmail.com";

                // Create app password in Google account
                // https://support.google.com/accounts/answer/185833?hl=en
                oServer.Password = "SpaceLaunchAPI";

                // Set 465 port
                oServer.Port = 587;

                // detect SSL/TLS automatically
                oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;

                Console.WriteLine("start to send email over SSL ...");

                EASendMail.SmtpClient oSmtp = new();
                oSmtp.SendMail(oServer, oMail);

                Console.WriteLine("email was sent successfully!");
            }
            catch (Exception ep)
            {
                Console.WriteLine("failed to send email with the following error:");
                Console.WriteLine(ep.Message);
            }
        }
    }
}
