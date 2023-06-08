/*using APIDoanV.Entities;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;


namespace APIDoanV.Controllers
{
    public class EmailService : IEmailService
    {
        
        private readonly IOptions<MailSettings> _mailSettings;

        public EmailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            var smtpClient = new SmtpClient
            {
                Host = _mailSettings.SmtpServer,
                Port = _mailSettings.SmtpPort,
                EnableSsl = true,
                Credentials = new NetworkCredential(_mailSettings.Username, _mailSettings.Password)
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_mailSettings.FromEmail),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            mailMessage.To.Add(toEmail);

            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}
*//* public async Task SendEmailAsync(string fromEmail, string toEmail, string subject, string body, string smtpServer, int smtpPort, string username, string password)
         {
             var message = new MimeMessage();
             message.From.Add(new MailboxAddress("", fromEmail));
             message.To.Add(new MailboxAddress("", toEmail));
             message.Subject = subject;

             var bodyBuilder = new BodyBuilder();
             bodyBuilder.HtmlBody = body;
             message.Body = bodyBuilder.ToMessageBody();

             using (var client = new SmtpClient())
             {
                 await client.ConnectAsync(smtpServer, smtpPort, SecureSocketOptions.Auto);
                 await client.AuthenticateAsync(username, password);
                 await client.SendAsync(message);
                 await client.DisconnectAsync(true);
             }
         }*/