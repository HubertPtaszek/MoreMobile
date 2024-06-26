﻿using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Mail;

namespace MoreMobile.Application.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;

        public EmailSender(ILogger<EmailSender> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            var emailConfig = _configuration.GetSection("EmailSettings").Get<EmailSettings>() ?? throw new Exception("Null");

            var client = new SmtpClient(emailConfig.Host, emailConfig.Port)
            {
                Credentials = new NetworkCredential(emailConfig.Email, emailConfig.Password),
                EnableSsl = emailConfig.EnableSSL
            };

            var body = "<h2>More Mobile</h2><br/>";
            body += message;

            await client.SendMailAsync(
            new MailMessage(emailConfig.Email, toEmail, subject, body) { IsBodyHtml = true }
            );
        }
    }
}