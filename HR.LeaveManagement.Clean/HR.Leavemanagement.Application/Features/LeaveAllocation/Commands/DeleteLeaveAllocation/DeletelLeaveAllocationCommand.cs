using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Leavemanagement.Application.Features.LeaveAllocation.Commands.DeleteLeaveAllocation;

public class DeletelLeaveAllocationCommand : IRequest
{
    public int Id { get; set; }
}
