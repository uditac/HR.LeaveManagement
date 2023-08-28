using AutoMapper;
using HR.Leavemanagement.Application.Contracts.Email;
using HR.Leavemanagement.Application.Contracts.Persistence;
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

    public UpdateLeaveRequestCommandHandler(ILeaveTypeRepository leaveTypeRepository,
                                            ILeaveRequestRepository leaveRequestRepository,
                                            IMapper mapper,
                                            IEmailSender emailSender)
    {
        _leaveTypeRepository = leaveTypeRepository;
        _leaveRequestRepository = leaveRequestRepository;
        _mapper = mapper;
        this._emailSender = emailSender;
        
    }
    public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var leaveRequest = await _leaveRequestRepository.GetByIdAsync(request.Id);
        return Unit.Value;
    }
}
