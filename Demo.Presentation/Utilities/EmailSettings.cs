using System.Net;
using System.Net.Mail;

namespace Demo.Presentation.Utilities
{
    public static class EmailSettings
    {
        public static void SendEmail(Email email)
        {
            // Sending Email
            var Client = new SmtpClient("smtp.gmail.com", 587);
            Client.EnableSsl = true;
            Client.Credentials = new NetworkCredential("mohmmeadkhalef22@gmail.com", "hpaxycxpxgzxfcun");
             Client.Send("mohmmeadkhalef@gmail.com", email.To, email.Subject,email.Body);




        }
    }
}
