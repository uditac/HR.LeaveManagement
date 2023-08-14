using MediatR;


namespace HR.Leavemanagement.Application.Features.Commands.UpdateleaveType
{
    public class UpdateLeaveTypeCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public int DefaultDays { get; set; }
    }
}
