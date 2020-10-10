using Kickoff.Services.Definitions;
using System.Net.Mail;

namespace Kickoff.Services.Implementations
{
    public class SMTPHelper : ISMTPHelper
    {
        public void SendMail(string receiver, string subject, string body, bool isBodyHtml)
        {
            using (var mailMsg = new MailMessage())
            {
                mailMsg.To.Add(new MailAddress(receiver));
                mailMsg.Subject = subject;
                mailMsg.Body = body;
                mailMsg.IsBodyHtml = isBodyHtml;

                SendMail(mailMsg);
            }
        }

        public void SendMail(MailMessage message)
        {
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.Send(message);
            }
        }
    }
}