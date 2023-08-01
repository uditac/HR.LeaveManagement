using AutoMapper;
using HR.Leavemanagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Leavemanagement.Application.Features.Queries.GetAllLeaveTypes;


// inheritating from mediatr packadge
public class GetLeaveTypesQueryHandler : IRequestHandler<GetLeaveTypesQuery, List<LeaveTypeDto>>
{
    private readonly IMapper _mapper;
    private readonly ILeaveTypeRepository _leaveTypeRepository;


    // We need Imapper because we need to convert.
    // Since we need to query the database, we need our persistance layer, contracts (abstraction)
    public GetLeaveTypesQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
    {
        _mapper = mapper;
        _leaveTypeRepository = leaveTypeRepository;
    }
    public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypesQuery request, CancellationToken cancellationToken)
    {
        //Query the db

        var leaveTypes = await _leaveTypeRepository.GetAsync();

        //convert data objects to dto objects

        var data = _mapper.Map<List<LeaveTypeDto>>(leaveTypes);


        // return list of DTO object

        return data;
       
    }
}
