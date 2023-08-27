using FluentValidation;
using HR.Leavemanagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Leavemanagement.Application.Features.LeaveType.Commands.CreateLeaveType;

public class CreateLeaveTypeCommandValidator : AbstractValidator<CreateLeaveTypeCommand>
{
    private ILeaveTypeRepository _leaveTypeRepository;
    public CreateLeaveTypeCommandValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is Required")
            .NotNull()
            .MaximumLength(70).WithMessage("{PropertyName} should not be more than 70 characaters");

        RuleFor(p => p.DefaultDays)
             .LessThan(100).WithMessage("{PropertyName} cannot be greater than 100")
             .GreaterThan(1).WithMessage("{PropertyName} cannot be lesser than 1");

        RuleFor(p => p)
            .MustAsync(LeaveTypeNameUnique)
            .WithMessage("Leave Type already exists");

        _leaveTypeRepository = leaveTypeRepository;
    }

    private async Task<bool> LeaveTypeNameUnique(CreateLeaveTypeCommand command, CancellationToken cancellationToken)
    {
        var a = await _leaveTypeRepository.IsLeaveTypeUnique(command.Name);
        return a;
    }
}