using System.Net.Mail;

namespace Kickoff.Services.Definitions
{
    public interface ISMTPHelper
    {
        void SendMail(string receiver, string subject, string body, bool isBodyHtml);

        void SendMail(MailMessage message);
    }
}