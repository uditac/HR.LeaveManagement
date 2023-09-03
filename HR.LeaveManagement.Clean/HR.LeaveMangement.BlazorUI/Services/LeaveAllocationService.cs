using HR.LeaveMangement.BlazorUI.Contracts;
using HR.LeaveMangement.BlazorUI.Services.Base;

namespace HR.LeaveMangement.BlazorUI.Services;

public class LeaveAllocationService : BaseHttpService, ILeaveAllocationService
{
    public LeaveAllocationService(IClient client) : base(client)
    {
    }
}
