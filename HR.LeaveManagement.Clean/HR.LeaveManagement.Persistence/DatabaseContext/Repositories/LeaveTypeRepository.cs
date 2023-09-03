using HR.Leavemanagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.DatabaseContext.Repositories;

public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
{
    protected readonly HRDatabaseContext _context;
    public LeaveTypeRepository(HRDatabaseContext context) : base(context)
    {
        this._context = context;
    }

    public async Task CreateAsync(LeaveType entity)
    {
     //   entity.CreatedBy = "Employee";
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();

    }
    public async Task<bool> IsLeaveTypeUnique(string name)
    {
       
        return await _context.LeaveTypes.AnyAsync(t => t.Name == name) == false;
       
    }
}
