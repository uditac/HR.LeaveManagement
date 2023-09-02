﻿using HR.Leavemanagement.Application.Features.LeaveRequest.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Leavemanagement.Application.Features.LeaveRequest.Commands.CancelLeaveRequest;

public class CancelLeaveRequestCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
