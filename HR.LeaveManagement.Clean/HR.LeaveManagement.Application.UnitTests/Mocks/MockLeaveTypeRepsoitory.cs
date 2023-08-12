using HR.Leavemanagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using Moq;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.UnitTests.Mocks
{
    public class MockLeaveTypeRepsoitory
    {
        public static Mock<ILeaveTypeRepository> GetLeaveTypeMockLeaveTypeRepository()
        {
            var leaveTypes = new List<LeaveType>
            { new LeaveType
            {
                Id = 1,
                DefaultDays = 10,
                Name = "Vacation Test",
            },
            new LeaveType { Id = 2,
            DefaultDays = 1,
            Name="Sick test"},

            new LeaveType { Id = 3,
            DefaultDays = 180,
            Name="Maternity Test"}
            };

            var mockRepo = new Mock<ILeaveTypeRepository>();
          
            mockRepo.Setup(r => r.GetAsync()).ReturnsAsync(leaveTypes);
            mockRepo.Setup(r => r.CreateAsync(It.IsAny<LeaveType>()))
               .Returns((LeaveType leaveType) => //delegate function
               {
                   leaveTypes.Add(leaveType); // lambda expression, it means that during adding creating databse, if it gets to this point if there are three data in the db and it gets to here. it adds the fourth one to the db
                   return Task.CompletedTask;
               });
            return mockRepo;
        }
    }
}
