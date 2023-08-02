using AutoMapper;
using HR.Leavemanagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Leavemanagement.Application.Features.Queries.GetLeaveTypeDetails;

/*
 * We are using GetbyIdAsync , we handle the GetleaveTypeDeatilsQuery and we get the request object.
 */
public class GetLeaveTypeDetailsQueryHandler : IRequestHandler<GetLeaveTypeDetailsQuery,LeaveTypeDetailsDto>
{
    private readonly IMapper _mapper;
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public GetLeaveTypeDetailsQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
    {
        _mapper = mapper;
        _leaveTypeRepository = leaveTypeRepository;
    }

    public async Task<LeaveTypeDetailsDto> Handle(GetLeaveTypeDetailsQuery request, CancellationToken cancellationToken)
    {
        //Query the Database
        var leaveTypes = await _leaveTypeRepository.GetByIdAsync(request.Id);

        //convert the data into Dto object
         var data = _mapper.Map<LeaveTypeDetailsDto>(leaveTypes);

        //return DTO object
        return data;
    }
}
