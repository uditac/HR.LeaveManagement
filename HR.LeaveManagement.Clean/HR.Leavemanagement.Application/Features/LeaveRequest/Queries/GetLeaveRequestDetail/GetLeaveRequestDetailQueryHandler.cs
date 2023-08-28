using AutoMapper;
using HR.Leavemanagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Leavemanagement.Application.Features.LeaveRequest.Queries.GetLeaveRequestDetail;

public class GetLeaveRequestDetailQueryHandler : IRequestHandler<GetLeaveRequestDetailQuery,
    LeaveRequestDetailDto>
{
    public ILeaveRequestRepository _leaveRequestRepository;
    public IMapper _mapper;

    public GetLeaveRequestDetailQueryHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
    {
        _leaveRequestRepository = leaveRequestRepository;
        _mapper = mapper;
    }
    public async Task<LeaveRequestDetailDto> Handle(GetLeaveRequestDetailQuery request, CancellationToken cancellationToken)
    {
        var leaveRequest = _mapper.Map<LeaveRequestDetailDto>(await
            _leaveRequestRepository.GetLeaveRequestWithDetails(request.Id));

        // add additional employee details as needed

        return leaveRequest;    
    }
}

