using HR.Leavemanagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;


namespace HR.LeaveManagement.Persistence.DatabaseContext.Repositories;

public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
{
    public LeaveTypeRepository(HRDatabaseContext context) : base(context)
    {
        
    }

    public async Task<bool> IsLeaveTypeUnique(string name)
    {
       
        return true;
       
    }
}
