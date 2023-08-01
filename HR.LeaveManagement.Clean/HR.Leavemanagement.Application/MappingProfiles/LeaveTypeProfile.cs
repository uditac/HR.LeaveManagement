using AutoMapper;
using HR.Leavemanagement.Application.Features.Queries.GetAllLeaveTypes;
using HR.LeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Leavemanagement.Application.MappingProfiles;

/* This serves as a configuration which converts from typeA to typeB, we used automapper for
 * this which usually converts between complex types, but we will be doing it in simple types. 
 */

/* https://www.linkedin.com/pulse/difference-between-entity-dto-what-use-instead-omar-ismail/
 * diffrence between dto and entity
 */
 
public class LeaveTypeProfile : Profile
{
    public LeaveTypeProfile()
    {
        CreateMap<LeaveTypeDto,LeaveType>().ReverseMap();  //Mapping conf between type a to type b and reverse map, dto to domin entity and back

            
    }
}
