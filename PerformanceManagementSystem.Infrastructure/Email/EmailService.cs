﻿using Microsoft.Extensions.Options;
using System.Net.Mail;
using System.Net;
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
            this.SendEmail(new List<String> { toEmail }, subject, body);
        }

        public void SendEmail(List<string> toEmails, string subject, string body)
        {
            using (var smtpClient = new SmtpClient(_smtpSettings.Server, _smtpSettings.Port))
            {
                smtpClient.Credentials = new NetworkCredential(_smtpSettings.Username, _smtpSettings.Password);
                smtpClient.EnableSsl = _smtpSettings.EnableSsl;

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_smtpSettings.Username, "DEFI"), // Alias name
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true // Set to true if the body contains HTML
                }; 
                
                foreach (var email in toEmails)
                {
                    mailMessage.To.Add(email);
                }

                smtpClient.Send(mailMessage);
            }
        }

    }
}

