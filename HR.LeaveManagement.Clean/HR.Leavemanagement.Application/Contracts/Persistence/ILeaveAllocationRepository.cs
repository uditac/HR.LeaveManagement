using HR.LeaveManagement.Domain;

namespace HR.Leavemanagement.Application.Contracts.Persistence
{
    public interface ILeaveAllocationRepository: IGenericRepository<LeaveType>
    {
        Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id);  // onr record

        Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails(); // one list

        Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails(string userId);

        Task<bool> AllocationExists(string userId, int leaveTypeId, int period); // does employee with this id have vacation in 2023

        Task AddAllocations(List<LeaveAllocation> allocations); // it adds a list of allocation objects

        Task<LeaveAllocation> GetUserAllocations(string userId, int leaveTypeId);
        

    }



}