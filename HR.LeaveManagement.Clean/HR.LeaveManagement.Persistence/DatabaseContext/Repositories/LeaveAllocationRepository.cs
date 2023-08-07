using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Persistence.DatabaseContext.Repositories;

public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
{
    public LeaveAllocationRepository(HRDatabaseContext context) : base(context)
    {

    }


}