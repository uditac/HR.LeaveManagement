using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.Leavemanagement.Application.Features.LeaveRequest.Shared;
using MediatR;

namespace HR.Leavemanagement.Application.Features.LeaveRequest.Commands.ChangeLeaveRequestApproval;

public class ChangeLeaveRequestApprovalCommand : BaseLeaveRequest, IRequest<Unit>
{
    public int Id { get; set; }

    public bool Approved { get; set; }
}
