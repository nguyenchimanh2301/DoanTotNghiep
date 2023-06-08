using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Threading.Tasks;


namespace APIDoanV.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        [HttpPost]
        public ActionResult SendEmail(string to, string subject, string body)
        {
            try
            {
                string smtpServer = "smtp.gmail.com";
                int smtpPort = 587; // Cổng SMTP
                string smtpUsername = "nmanh23012001@gmail.com";
                string smtpPassword = "rnwmfjzwgsepypbg";

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(smtpUsername);
                mail.To.Add(to);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;

                SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort);
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                smtpClient.EnableSsl = true;
                smtpClient.Send(mail);

                return Ok(new { data = "OK" });
            }
            catch (Exception ex)
            {
                return Ok(new { data = "KO" });
            }
        }
    }
}
