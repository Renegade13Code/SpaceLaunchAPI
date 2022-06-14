using System.Net;
using System.Net.Mail;
using SpaceLaunchAPI.Repository;

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
            Console.WriteLine("sending email");
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("myemail@gmail.com");
                message.To.Add(new MailAddress(Email));
                message.Subject = "Test";
                message.IsBodyHtml = false; //to make message body as html  
                message.Body = "This is and email notifying you of the space launch in one hour";
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("FromMailAddress", "password");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            } catch
            {
                Console.WriteLine("Couldn't send email for");
            }
        }
    }
}