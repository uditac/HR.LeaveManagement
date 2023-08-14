using AutoMapper;
using HR.Leavemanagement.Application.Contracts.Persistence;
using HR.Leavemanagement.Application.Exceptions;
using MediatR;


namespace HR.Leavemanagement.Application.Features.LeaveAllocation.Commands.DeleteLeaveAllocation;

public class DeleteAllocationCommandHandler : IRequestHandler<DeletelLeaveAllocationCommand,Unit>
{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    private readonly IMapper _mapper;
    public DeleteAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository,IMapper mapper)
    {
        _leaveAllocationRepository = leaveAllocationRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(DeletelLeaveAllocationCommand request, CancellationToken cancellationToken)
    {
        var leaveAllocation = await _leaveAllocationRepository.GetByIdAsync(request.Id);

        if(leaveAllocation == null)
        {
            throw new NotFoundException(nameof(leaveAllocation),request.Id);
        }

        await _leaveAllocationRepository.DeleteAsync(leaveAllocation);
        return Unit.Value;
    }
}
