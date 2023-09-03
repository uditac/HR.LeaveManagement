using HR.LeaveMangement.BlazorUI.Contracts;
using HR.LeaveMangement.BlazorUI.Services.Base;

namespace HR.LeaveMangement.BlazorUI.Services;

public class LeaveTypeService : BaseHttpService, ILeaveTypeService
{
    public LeaveTypeService(IClient client) : base(client)
    {
    }
}
