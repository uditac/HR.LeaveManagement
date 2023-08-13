﻿using HR.Leavemanagement.Application.Features.Queries.GetAllLeaveTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Leavemanagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocations;

public class LeaveAllocationDto
{
    public int id { get; set; }
    public int NumberOfDays { get; set; }

    public LeaveTypeDto LeaveType { get; set; }

    public int LeaveTypeId { get; set; }

    public int Period { get; set; }
}
