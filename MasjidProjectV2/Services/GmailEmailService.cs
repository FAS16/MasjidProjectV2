using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace MasjidProjectV2.Clients
{
    public class GmailEmailService : SmtpClient
    {

        // Gmail user-name
        public string UserName { get; set; }

        public GmailEmailService() :
            base(ConfigurationManager.AppSettings["GmailHost"], Int32.Parse(ConfigurationManager.AppSettings["GmailPort"]))
        {
            //Get values from web.config file:
            this.UserName = ConfigurationManager.AppSettings["GmailUserName"];
            this.EnableSsl = Boolean.Parse(ConfigurationManager.AppSettings["GmailSsl"]);
            this.UseDefaultCredentials = false;
            this.Credentials = new System.Net.NetworkCredential(this.UserName, ConfigurationManager.AppSettings["GmailPassword"]);
        }

        public async Task SendEmailAsync(string recipientEmail, string subject, string body)
        {
            MailMessage email = new MailMessage(new MailAddress("noreply@masjid.com", "(do not reply)"),
                new MailAddress(recipientEmail));

            email.Subject = subject;
            email.Body = body;

            email.IsBodyHtml = true;

            using (var mailClient = this)
            {
                //In order to use the original from email address, uncomment this line:
                //                email.From = new MailAddress(mailClient.UserName, "(do not reply)");

                await mailClient.SendMailAsync(email);
            }
        }
    }
}