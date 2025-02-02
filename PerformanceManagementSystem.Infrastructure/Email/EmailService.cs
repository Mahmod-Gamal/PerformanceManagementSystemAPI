using Microsoft.Extensions.Options;
using PerformanceManagementSystem.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using PerformanceManagementSystem.Application.Interfaces.Email;

namespace PerformanceManagementSystem.Infrastructure.Email
{
    public class EmailService : IEmailService
    {

        private readonly SmtpSettings _smtpSettings;
        public EmailService(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;

        }

        public void SendEmail(string toEmail, string subject, string body)
        {
            using (var smtpClient = new SmtpClient(_smtpSettings.Server, _smtpSettings.Port))
            {
                smtpClient.Credentials = new NetworkCredential(_smtpSettings.Username, _smtpSettings.Password);
                smtpClient.EnableSsl = _smtpSettings.EnableSsl;

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_smtpSettings.Username),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true // Set to true if the body contains HTML
                };
                mailMessage.To.Add(toEmail);

                smtpClient.Send(mailMessage);
            }
        }
    }
}

