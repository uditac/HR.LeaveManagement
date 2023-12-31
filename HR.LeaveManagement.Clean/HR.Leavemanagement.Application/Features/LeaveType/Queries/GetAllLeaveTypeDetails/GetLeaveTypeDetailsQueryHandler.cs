﻿using AutoMapper;
using HR.Leavemanagement.Application.Contracts.Persistence;
using HR.Leavemanagement.Application.Exceptions;
using HR.Leavemanagement.Application.Features.LeaveType.Queries.GetAllLeaveTypeDetails;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Leavemanagement.Application.Features.LeaveType.Queries.GetAllLeaveTypeDetails;

/*
 * We are using GetbyIdAsync , we handle the GetleaveTypeDeatilsQuery and we get the request object.
 */
public class GetLeaveTypeDetailsQueryHandler : IRequestHandler<GetLeaveTypeDetailsQuery, LeaveTypeDetailsDto>
{
    private readonly IMapper _mapper;
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    // private readonly IAppLogger<GetLeaveTypeDetailsQueryHandler> _logger;

    public GetLeaveTypeDetailsQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository
        //   ,IAppLogger<GetLeaveTypeDetailsQueryHandler> logger
        )
    {
        this._mapper = mapper;
        this._leaveTypeRepository = leaveTypeRepository;
        //   this._logger = logger;
    }

    public async Task<LeaveTypeDetailsDto> Handle(GetLeaveTypeDetailsQuery request, CancellationToken cancellationToken)
    {
        //Query the Database
        var leaveTypes = await _leaveTypeRepository.GetByIdAsync(request.Id);

        if (leaveTypes == null)
        {
            throw new NotFoundException(nameof(LeaveType), request.Id);
        }

        //convert the data into Dto object
        var data = _mapper.Map<LeaveTypeDetailsDto>(leaveTypes);

        // logs
        //   _logger.LogInformation("Leave Types retrieved succesfully");
        //return DTO object
        return data;
    }
}

