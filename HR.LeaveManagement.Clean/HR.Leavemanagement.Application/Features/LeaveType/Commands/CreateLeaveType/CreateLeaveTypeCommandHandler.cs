using AutoMapper;
using HR.Leavemanagement.Application.Contracts.Persistence;
using HR.Leavemanagement.Application.Exceptions;
using HR.Leavemanagement.Application.Features.LeaveType.Commands.CreateLeaveType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Leavemanagement.Application.Features.LeaveType.Commands.CreateLeaveType;


public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
{
    private readonly IMapper _mapper;
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public CreateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
    {
        _mapper = mapper;
        _leaveTypeRepository = leaveTypeRepository;

    }
    public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        // Validate incoming data
        var validator = new CreateLeaveTypeCommandValidator(_leaveTypeRepository);
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Any())
        {
            throw new BadRequestException("Invalid leave Type", validationResult);
        }

        // if valid then we convert to Domain Entity Object
        var leaveTypeToCreate = _mapper.Map<HR.LeaveManagement.Domain.LeaveType>(request);
        // Add to database
        await _leaveTypeRepository.CreateAsync(leaveTypeToCreate);
        //recturn record id

        return leaveTypeToCreate.Id;
    }

}

