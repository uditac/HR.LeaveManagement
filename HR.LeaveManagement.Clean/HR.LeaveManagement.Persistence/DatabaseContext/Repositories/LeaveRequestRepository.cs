
using HR.Leavemanagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Persistence.DatabaseContext;
using HR.LeaveManagement.Persistence.DatabaseContext.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repositories;
public class LeaveRequestRepository : GenericRepository<LeaveRequest>,ILeaveRequestRepository
{
    public LeaveRequestRepository(HRDatabaseContext context) :base(context)
    {
        
    }

    public Task CreateAsync(LeaveType entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(LeaveType entity)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<LeaveType>> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails()
    {
       var leaveRequests = await _context.LeaveRequests  // This context comes from the context of generic repo
            .Include(q => q.LeaveType)  // when you ´have foreign keys relation, include allows the inner join statement to happen , please see the leave request class
            .ToListAsync();

        return leaveRequests;
                          
    }

    public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
    {
        var leaveRequests = await _context.LeaveRequests
                                .Include(q => q.LeaveType)
                                .FirstOrDefaultAsync(q => q.Id == id);

        return leaveRequests;
                                
    }

    public async Task<List<LeaveRequest>> GetLeaveRequestWithDetails(string userId)
    {
        var leaveRequests = await _context.LeaveRequests.Where(q => q.RequestingEmployeeId == userId)
            .Include(q => q.LeaveType)
            .ToListAsync();
        return leaveRequests;

        throw new NotImplementedException();
    }

    public Task UpdateAsync(LeaveType entity)
    {
        throw new NotImplementedException();
    }

  
}
