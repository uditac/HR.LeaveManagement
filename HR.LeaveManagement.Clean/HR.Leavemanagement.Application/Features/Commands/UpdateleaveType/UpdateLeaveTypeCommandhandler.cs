using AutoMapper;
using HR.Leavemanagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Leavemanagement.Application.Features.Commands.UpdateleaveType
{
    public class UpdateLeaveTypeCommandhandler : IRequestHandler<UpdateLeaveTypeCommand,Unit>
    {
        private readonly Mapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public UpdateLeaveTypeCommandhandler(Mapper mapper,ILeaveTypeRepository leaveTypeRepository)
        { 
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
            
        }

        public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            //Validate incoming data
            var leaveTypeToUpdate = _mapper.Map<LeaveType>(request);


            //Convert to Domain Entity object
            await _leaveTypeRepository.UpdateAsync(leaveTypeToUpdate);

            // retrun Unit value

            return Unit.Value;
        }

    }
}
