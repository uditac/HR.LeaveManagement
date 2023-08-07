using HR.LeaveManagement.Domain.Common;

namespace HR.Leavemanagement.Application.Contracts.Persistence;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
   Task<T> GetByIdAsync(int id);

    Task<IReadOnlyList<T>> GetAsync(int id);
        
}