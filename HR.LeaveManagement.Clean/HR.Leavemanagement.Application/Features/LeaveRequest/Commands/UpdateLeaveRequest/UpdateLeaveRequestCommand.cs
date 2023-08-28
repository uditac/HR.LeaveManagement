using MediatR;


namespace HR.Leavemanagement.Application.Features.LeaveRequest.Commands.UpdateLeaveRequest;

public class UpdateLeaveRequestCommand :IRequest<Unit>
{
    public int Id { get; set; }

    public string RequestComments { get; set; } = string.Empty;

    public bool Cancelled { get; set; }
}
