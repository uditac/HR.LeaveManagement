using FluentValidation;
using HR.Leavemanagement.Application.Contracts.Persistence;
using HR.Leavemanagement.Application.Features.LeaveRequest.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;


namespace HR.Leavemanagement.Application.Features.LeaveRequest.Commands.UpdateLeaveRequest;

public class UpdateLeaveRequestValidator : AbstractValidator<UpdateLeaveRequestCommand>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly ILeaveRequestRepository _leaveRequestRepository;

    public UpdateLeaveRequestValidator(ILeaveTypeRepository leaveTypeRepository,ILeaveRequestRepository leaveRequestRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;
        _leaveRequestRepository = leaveRequestRepository;

       Include(new BaseRequestValidator(_leaveTypeRepository));

        RuleFor(p => p.Id)
            .NotNull()
            .MustAsync(LeaveRequestMustExist)
            .WithMessage("{PropertyName} must be present");

    }

    private async Task<bool> LeaveRequestMustExist(int id, CancellationToken cancellationToken)
    {
        var leaveType = await _leaveRequestRepository.GetByIdAsync(id);
        return leaveType != null;
    }
}
