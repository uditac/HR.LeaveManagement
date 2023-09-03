using HR.Leavemanagement.Application.Models.Email;

namespace HR.Leavemanagement.Application.Contracts.Email;

public interface IEmailSender
{

    Task<bool> SendEmail(EmailMessage email);
}
