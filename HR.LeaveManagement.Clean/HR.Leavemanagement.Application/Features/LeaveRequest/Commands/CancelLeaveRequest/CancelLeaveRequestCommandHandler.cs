using HR.Leavemanagement.Application.Contracts.Email;
using HR.Leavemanagement.Application.Contracts.Persistence;
using HR.Leavemanagement.Application.Exceptions;
using MediatR;
using HR.LeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.Leavemanagement.Application.Models.Email;

namespace HR.Leavemanagement.Application.Features.LeaveRequest.Commands.CancelLeaveRequest;

public class CancelLeaveRequestCommandHandler : IRequestHandler<CancelLeaveRequestCommand,Unit>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly IEmailSender _emailSender;

    public CancelLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, 
        IEmailSender emailSender)
    {
        _leaveRequestRepository = leaveRequestRepository;
        _emailSender = emailSender;
    }

    public async Task<Unit> Handle(CancelLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var leaveRequest = await _leaveRequestRepository.GetByIdAsync(request.Id);
        if(leaveRequest == null)
        {
            throw new NotFoundException(nameof(leaveRequest),request.Id);
        }

       leaveRequest.Cancelled = true;

        //Re-evaluate and re-allocate

        //send confirmation email

        var email = new EmailMessage
        {
            To = string.Empty,
            Body = $"Your leaves from {leaveRequest.StartDate:D} to {leaveRequest.EndDate:D}" +
                    $"has been cancelled succesfully",
            Subject = "Leave Request Cancelled"
        };

        await _emailSender.EmailSender(email);
        return Unit.Value;
    }
}
