using AutoMapper;
using HR.Leavemanagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using MediatR;



namespace HR.Leavemanagement.Application.Features.Commands.UpdateleaveType
{
    public class UpdateLeaveTypeCommandhandler : IRequestHandler<UpdateLeaveTypeCommand,Unit>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public UpdateLeaveTypeCommandhandler(IMapper mapper,ILeaveTypeRepository leaveTypeRepository)
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
            
        }

        public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            //Validate incoming data
            var validator = new UpdateLeaveTypeCommandValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request);
            //Convert to Domain Entity object
            var leaveTypeToUpdate = _mapper.Map<LeaveType>(request);



            // addd to db
            await _leaveTypeRepository.UpdateAsync(leaveTypeToUpdate);

            // retrun Unit value

            return Unit.Value;
        }

    }
}
