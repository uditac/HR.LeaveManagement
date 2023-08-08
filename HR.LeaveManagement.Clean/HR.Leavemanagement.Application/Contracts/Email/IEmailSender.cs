using HR.Leavemanagement.Application.Models.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Leavemanagement.Application.Contracts.Email;

public interface IEmailSender
{
    Task<bool> EmailSender(EmailMessage email);
}
