using FluentValidation;
using HR.Leavemanagement.Application.Contracts.Persistence;

namespace HR.Leavemanagement.Application.Features.LeaveRequest.Shared
{
    public class BaseRequestValidator : AbstractValidator<BaseLeaveRequest>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public BaseRequestValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            RuleFor(p => p.StartDate)
                .LessThan((p => p.EndDate)).WithMessage("{PropertyName} must be before {ComparisonValue}");

            RuleFor(p => p.EndDate)
                .GreaterThan(p => p.StartDate).WithMessage("{PropertyName} must be greater than {ComparisonValue}");


        }

        private async Task<bool> LeaveTypeMustExist(int id,CancellationToken cancellationToken)
        {
            var leaveType = await _leaveTypeRepository.GetByIdAsync(id);
            return leaveType != null;
        }
    }
}
