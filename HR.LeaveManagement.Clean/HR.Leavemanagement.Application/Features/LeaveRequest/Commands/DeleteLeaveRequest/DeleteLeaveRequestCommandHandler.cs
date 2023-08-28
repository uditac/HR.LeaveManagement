using AutoMapper;
using HR.Leavemanagement.Application.Contracts.Persistence;
using HR.Leavemanagement.Application.Exceptions;
using MediatR;


namespace HR.Leavemanagement.Application.Features.LeaveRequest.Commands.DeleteLeaveRequest;

public class DeleteLeaveRequestCommandHandler : IRequestHandler<DeleteLeaveRequestCommand>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly IMapper _mapper;
    public DeleteLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository,IMapper mapper)
    {
        _leaveRequestRepository = leaveRequestRepository;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(DeleteLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var leaveRequest = await _leaveRequestRepository.GetByIdAsync(request.Id);
        if (leaveRequest == null)
          throw new NotFoundException(nameof(leaveRequest), request.Id);
        await _leaveRequestRepository.DeleteAsync(leaveRequest);
        return Unit.Value;
        
    }

    Task IRequestHandler<DeleteLeaveRequestCommand>.Handle(DeleteLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
