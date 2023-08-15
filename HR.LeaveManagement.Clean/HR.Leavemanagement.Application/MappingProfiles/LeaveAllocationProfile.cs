
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
