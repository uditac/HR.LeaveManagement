using HR.Leavemanagement.Application.Features.Queries.GetAllLeaveTypes;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Domain.Common;
using HR.LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Shouldly;

namespace HR.LeaveManagement.Persistence.IntegrationTests
{
    public class HrDatabaseContextTests
    {
        private HRDatabaseContext _hrDataBaseContext;
        public HrDatabaseContextTests()
        {
            
            var dbOptions = new DbContextOptionsBuilder<HRDatabaseContext>()
                             .UseInMemoryDatabase(Guid.NewGuid().ToString()) // this takes a string db name, i am just using a random name
                             .Options;

            _hrDataBaseContext = new HRDatabaseContext(dbOptions);
        }
        [Fact]
        public void Save_SetDateCreatedValue()
        {
            // Arrange
            var leaveType = new LeaveType
            {
                Id = 1,
                DefaultDays = 10,
                Name = "Test Vacation"
            };

            //Act

            _hrDataBaseContext.LeaveTypes.AddAsync(leaveType);
            _hrDataBaseContext.SaveChangesAsync();

            //Assert

           leaveType.DateCreated.ShouldNotBeNull();
        }

        [Fact]
        public async void Save_SetDateModifiedDate()
        {
            var leaveType = new LeaveType
            {
                Id = 1,
                DefaultDays = 10,
                Name = "Test Vacation"
            };

           await _hrDataBaseContext.LeaveTypes.AddAsync(leaveType);
           await _hrDataBaseContext.SaveChangesAsync();

            leaveType.DateCreated.ShouldNotBeNull();
        }
    }
}