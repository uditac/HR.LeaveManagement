using AutoMapper;
using HR.Leavemanagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using HR.Leavemanagement.Application.Exceptions;
using HR.Leavemanagement.Application.Features.LeaveAllocation.Commands;
using HR.Leavemanagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocations;
using MediatR;


namespace HR.Leavemanagement.Application.Features.LeaveAllocation.Commands.CreateLeaveallocation;

public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public CreateLeaveAllocationCommandHandler(IMapper mapper, 
        ILeaveAllocationRepository leaveAllocationRepository,
        ILeaveTypeRepository leaveTypeRepository)
    {
        _mapper = mapper;
        _leaveAllocationRepository = leaveAllocationRepository;
        _leaveTypeRepository = leaveTypeRepository;
    }
    public async Task<Unit> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateLeaveallocationCommandValidator(_leaveTypeRepository);
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Any())
            throw new Exceptions.BadRequestException("Invalid leave Allocation Request", validationResult);

        var leaveType = await _leaveTypeRepository.GetByIdAsync(request.LeaveTypeId);

        var leaveAllocation = _mapper.Map<HR.LeaveManagement.Domain.LeaveAllocation>(request);
   //     await _leaveAllocationRepository.CreateAsync(leaveAllocation.ToString);
        return Unit.Value;

    }
}
