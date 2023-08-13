using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Leavemanagement.Application.Features.LeaveAllocation.Commands.CreateLeaveallocation;

public class CreateLeaveAllocationCommand : IRequest<Unit> //Imporatnt
{
    public int LeaveTypeId { get; set; }

}
