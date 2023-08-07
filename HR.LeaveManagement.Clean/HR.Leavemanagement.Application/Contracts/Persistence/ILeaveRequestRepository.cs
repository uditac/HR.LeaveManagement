using HR.LeaveManagement.Domain;

namespace HR.Leavemanagement.Application.Contracts.Persistence
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveType>
    {
        Task<LeaveRequest> GetLeaveRequestWithDetails(int id); //if there are any bits of data that tp be included, like leave tyeps
        Task<List<LeaveRequest>> GetLeaveRequestsWithDetails(); // if there are many leave requets

        Task<List<LeaveRequest>> GetLeaveRequestWithDetails(string userId); // Mny requests of one user
    }


}