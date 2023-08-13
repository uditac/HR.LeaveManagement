using MediatR;
using HR.Leavemanagement.Application.Contracts.Persistence;
using HR.Leavemanagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace HR.Leavemanagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocations;

public class GetLeaveAllocaationListHandler : IRequestHandler<GetLeaveAllocationListQuery, List<LeaveAllocationDto>>
{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    private readonly IMapper _mapper;

    public GetLeaveAllocaationListHandler(ILeaveAllocationRepository leaveAllocationRepository,IMapper mapper)
    {
        _leaveAllocationRepository = leaveAllocationRepository;
        _mapper = mapper;
    }
    public async Task<List<LeaveAllocationDto>> Handle(GetLeaveAllocationListQuery request, CancellationToken cancellationToken)
    {
        var leaveAllocations = await _leaveAllocationRepository.GetLeaveAllocationWithDetails();
        var allocations = _mapper.Map<List<LeaveAllocationDto>>(leaveAllocations);

        return allocations;
    }
}
