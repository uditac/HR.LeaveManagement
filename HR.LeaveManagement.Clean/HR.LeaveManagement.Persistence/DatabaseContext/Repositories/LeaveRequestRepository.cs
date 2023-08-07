

using HR.Leavemanagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Persistence.DatabaseContext;
using HR.LeaveManagement.Persistence.DatabaseContext.Repositories;

public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
{
    public LeaveRequestRepository(HRDatabaseContext context) :base(context)
    {
        
    }
}
