﻿using HR.Leavemanagement.Application.Contracts.Email;
using HR.Leavemanagement.Application.Models.Email;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HR.LeaveManagement.Infrastructure.EmailService
{
    public class EmailSender : IEmailSender
    {
        public EmailSetings _emailSetings { get; }
        public EmailSender(IOptions<EmailSetings> emailSetings)  //Email settings 
        {
            _emailSetings = emailSetings.Value;
        }
     public async Task<bool> SendEmail(EmailMessage email)
        {
            var client = new SendGridClient(_emailSetings.ApiKey);
            var to = new SendGridClient(email.To);
            var from = new EmailAddress
            {
                Email = _emailSetings.FromAddress,
                Name = _emailSetings.FromName

            };

            var message = MailHelper.CreateSingleEmail(from,to, email.Body, email.Subject);
            var response = await client.SendEmailAsync(message);

            

            return response.IsSuccessStatusCode;
        }
    }
}