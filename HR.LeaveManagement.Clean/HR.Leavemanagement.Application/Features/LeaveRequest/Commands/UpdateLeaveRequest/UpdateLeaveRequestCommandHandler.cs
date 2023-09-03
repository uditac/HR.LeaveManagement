using AutoMapper;
using HR.Leavemanagement.Application.Contracts.Email;
using HR.Leavemanagement.Application.Contracts.Logging;
using HR.Leavemanagement.Application.Contracts.Persistence;
using HR.Leavemanagement.Application.Exceptions;
using HR.Leavemanagement.Application.Models.Email;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Leavemanagement.Application.Features.LeaveRequest.Commands.UpdateLeaveRequest;

public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IEmailSender _emailSender;
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IAppLogger<UpdateLeaveRequestCommandHandler> _appLogger;

    public UpdateLeaveRequestCommandHandler(ILeaveTypeRepository leaveTypeRepository,
                                            ILeaveRequestRepository leaveRequestRepository,
                                            IMapper mapper,
                                            IEmailSender emailSender,
                                            IAppLogger<UpdateLeaveRequestCommandHandler> appLogger)
    {
        _leaveTypeRepository = leaveTypeRepository;
        _leaveRequestRepository = leaveRequestRepository;
        _mapper = mapper;
        this._emailSender = emailSender;
        _appLogger = appLogger;
        
    }
    public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var leaveRequest = await _leaveRequestRepository.GetByIdAsync(request.Id);

        if(leaveRequest is null)
           throw new NotFoundException(nameof(leaveRequest),request.Id);

       

        var validator = new UpdateLeaveRequestValidator(_leaveTypeRepository, _leaveRequestRepository);
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Any())
            throw new BadRequestException("Invalid Leave Request", validationResult);

        _mapper.Map(request, leaveRequest);
        await _leaveRequestRepository.UpdateAsync(leaveRequest);

        try
        {
            var email = new EmailMessage
            {
                To = string.Empty,
                Body = $"Your leave request for {request.StartDate} to {request.EndDate}" +
                 $"has been updated succesfully.",
                Subject = "Leave Request Updated"
            };

            await _emailSender.SendEmail(email);
        }
        catch
        (Exception ex)
        {
            _appLogger.LogInformation(ex.Message);

        }

        return Unit.Value;
    }
}
