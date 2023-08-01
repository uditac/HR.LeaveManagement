using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Leavemanagement.Application.Features.Queries.GetAllLeaveTypes;

// Difference between classes and records is that a record is immutable, once you define it, pretty much nothing can be changed

//public record GetLeaveTypesQuery : IRequest<List<LeaveTypeDto>>;


public record GetLeaveTypesQuery : IRequest<List<LeaveTypeDto>>;

