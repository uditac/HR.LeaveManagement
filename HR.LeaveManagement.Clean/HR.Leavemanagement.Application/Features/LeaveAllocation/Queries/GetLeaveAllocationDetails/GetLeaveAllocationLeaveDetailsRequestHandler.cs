using AutoMapper;
using HR.Leavemanagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Leavemanagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails;

public class GetLeaveAllocationLeaveDetailsRequestHandler : IRequestHandler<GetLeaveAllocationDetailQuery,
    LeaveAllocationDetailsDto>
{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    private readonly IMapper _mapper;
    public GetLeaveAllocationLeaveDetailsRequestHandler(ILeaveAllocationRepository leaveAllocationRepository,IMapper mapper)
    {
        _leaveAllocationRepository = leaveAllocationRepository;
        _mapper = mapper;
        
    }
    

    public Task<LeaveAllocationDetailsDto> Handle(GetLeaveAllocationDetailQuery request, CancellationToken cancellationToken)
    {
        var leaveAllocationDetails = _leaveAllocationRepository.GetLeaveAllocationWithDetails(request.Id);
        return _mapper.Map(leaveAllocationDetails);
    }
}

