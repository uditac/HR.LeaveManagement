using AutoMapper;
using HR.Leavemanagement.Application.Contracts.Persistence;
using HR.Leavemanagement.Application.Exceptions;
using HR.LeaveManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Leavemanagement.Application.Features.Commands.DeleteLeaveType
{
    public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand,Unit>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public DeleteLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<Unit>  Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            //retrive domain entity object
            var leaveTypeeToDelete = await _leaveTypeRepository.GetByIdAsync(id: request.Id);
            if (leaveTypeeToDelete == null)
            {
                throw new NotFoundException(nameof(LeaveType),request.Id);
            }
            await _leaveTypeRepository.DeleteAsync(leaveTypeeToDelete);

            return Unit.Value;
        }
    }
}
