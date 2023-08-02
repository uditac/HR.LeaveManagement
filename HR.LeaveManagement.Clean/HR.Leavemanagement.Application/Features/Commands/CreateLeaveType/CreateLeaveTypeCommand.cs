using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Leavemanagement.Application.Features.Commands.CreateLeaveType
{
    // we are returning the id of the record that was created
    public class CreateLeaveTypeCommand :IRequest<int>
    {
        public string Name { get; set; } = string.Empty;

        public int DefaultDays { get; set; }

    }
}
