using HR.Leavemanagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.DatabaseContext.Repositories;

public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
{
    public LeaveAllocationRepository(HRDatabaseContext context) : base(context)
    {

    }

    public async Task AddAllocations(List<LeaveAllocation> allocations)
    {
        await _context.AddRangeAsync(allocations);
       
    }

    public async Task<bool> AllocationExists(string userId, int leaveTypeId, int period)
    {
       var IfAllocationExists = await _context.LeaveAllocations.AnyAsync(q => q.EmployeeId == userId
            && q.LeaveTypeId == leaveTypeId && q.Period == period);

        return IfAllocationExists;
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

    public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
    {
        var leaveAllocations = await _context.LeaveAllocations.Where(q => q.Id == id)
                                    .Include(q => q.LeaveType)
                                    .FirstAsync();
                                  
        return leaveAllocations;
    }

    public async Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails()
    {
        var leaveAllocations = await _context.LeaveAllocations
                                    .Include(q => q.LeaveType)
                                    .ToListAsync();

        return leaveAllocations;
    }

    public Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails(string userId)
    {
        throw new NotImplementedException();
    }

    public async Task<LeaveAllocation> GetUserAllocations(string userId, int leaveTypeId)
    {
        return await _context.LeaveAllocations.FirstOrDefaultAsync(q=> q.EmployeeId == userId
         && q.LeaveTypeId == leaveTypeId);
    }

    public Task UpdateAsync(LeaveType entity)
    {
        throw new NotImplementedException();
    }

    Task<IReadOnlyList<LeaveType>> IGenericRepository<LeaveType>.GetAsync()
    {
        throw new NotImplementedException();
    }

    Task<LeaveType> IGenericRepository<LeaveType>.GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}