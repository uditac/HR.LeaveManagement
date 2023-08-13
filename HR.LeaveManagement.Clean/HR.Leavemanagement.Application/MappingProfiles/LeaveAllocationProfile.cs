using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HR.Leavemanagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails;
using HR.Leavemanagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocations;
using HR.LeaveManagement.Domain;

namespace HR.Leavemanagement.Application.MappingProfiles;

public class LeaveAllocationProfile :Profile
{
    public LeaveAllocationProfile()
    {
        CreateMap<LeaveAllocationDto,LeaveAllocation>().ReverseMap();
        CreateMap<LeaveAllocation, LeaveAllocationDetailsDto>();
      
    }
}
