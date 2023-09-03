using HR.LeaveMangement.BlazorUI.Contracts;
using HR.LeaveMangement.BlazorUI.Services.Base;

namespace HR.LeaveMangement.BlazorUI.Services;

public class LeaveRequestService : BaseHttpService, ILeaveRequestService
{
    public LeaveRequestService(IClient client) : base(client)
    {
    }
}
