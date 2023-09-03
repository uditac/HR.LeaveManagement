using AutoMapper;
using HR.Leavemanagement.Application.Contracts.Email;
using HR.Leavemanagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using MediatR;
using HR.Leavemanagement.Application.Exceptions;
using HR.Leavemanagement.Application.Features.LeaveRequest.Commands.CreateLeaveRequest;
using HR.Leavemanagement.Application.Models.Email;
using System.Linq.Expressions;

namespace HR.Leavemanagement.Application.Features.LeaveRequest.Commands.CreateLeaveRequest;

public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand,Unit>
{
    private readonly IEmailSender _emailSender;
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly IMapper _mapper;
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public CreateLeaveRequestCommandHandler(IEmailSender emailSender,
                                          ILeaveRequestRepository leaveRequestRepository,
                                          ILeaveTypeRepository leaveTypeRepository,
                                          IMapper mapper)
    {
        _emailSender = emailSender;
        _leaveRequestRepository = leaveRequestRepository;
        _mapper = mapper;
        _leaveTypeRepository = leaveTypeRepository;
    }

    public async Task<Unit> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateLeaveRequestCommandValidator(_leaveTypeRepository);
        var validationResult = validator.ValidateAsync(request);

       
        //Create leave Request
        var leaveRequest = _mapper.Map<HR.LeaveManagement.Domain.LeaveRequest>(request);
        await _leaveRequestRepository.CreateAsync(leaveRequest);

    
        try
        {
            var email = new EmailMessage
            {
                To = string.Empty, //email from employee record
                Body = $"Your request from {request.StartDate} to {request.EndDate}" +
                       $"has been submitted succesfully.",
                Subject = "Leave request submitted"
            };
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
        return Unit.Value;
    }
       
    

}
