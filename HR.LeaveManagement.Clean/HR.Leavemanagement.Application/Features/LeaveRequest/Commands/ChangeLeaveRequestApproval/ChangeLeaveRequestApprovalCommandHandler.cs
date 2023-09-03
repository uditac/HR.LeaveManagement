using MediatR;
using AutoMapper;
using HR.Leavemanagement.Application.Contracts.Persistence;
using HR.Leavemanagement.Application.Contracts.Email;
using HR.Leavemanagement.Application.Exceptions;
using HR.Leavemanagement.Application.Models.Email;


namespace HR.Leavemanagement.Application.Features.LeaveRequest.Commands.ChangeLeaveRequestApproval;

public class ChangeLeaveRequestApprovalCommandHandler : IRequestHandler<ChangeLeaveRequestApprovalCommand,Unit>
{
    private readonly IMapper _mapper;
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly IEmailSender _emailSender;
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    public ChangeLeaveRequestApprovalCommandHandler(IMapper mapper,
        ILeaveRequestRepository leaveRequestRepository,
        ILeaveTypeRepository leaveTypeRepository,
        IEmailSender emailSender,
        ILeaveAllocationRepository leaveAllocationRepository)
    {
        _leaveRequestRepository = leaveRequestRepository;
        _emailSender = emailSender;
        _mapper = mapper;
        _leaveTypeRepository = leaveTypeRepository;
        this._leaveAllocationRepository = leaveAllocationRepository;
    }

    public async Task<Unit> Handle(ChangeLeaveRequestApprovalCommand request, CancellationToken cancellationToken)
    {
        var leaveRequest = await _leaveRequestRepository.GetByIdAsync(request.Id);
        if(leaveRequest is null)
        {
            throw new NotFoundException(nameof(leaveRequest),request.Id);
        }

      leaveRequest.Approved = request.Approved;
        await _leaveRequestRepository.UpdateAsync(leaveRequest);

        
        var email = new EmailMessage
        {
            To = string.Empty,
            Body = $"Your leave request from {request.StartDate} to {request.EndDate}" +
                   $"is updated",
            Subject = "Leave Request is updated"
        };

        await _emailSender.SendEmail(email);

        return Unit.Value;
    }
}
