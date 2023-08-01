using HR.LeaveManagement.Domain;

namespace HR.Leavemanagement.Application.Contracts.Persistence
{
    public interface ILeaveRequestRepository<T> : IGenericRepository<LeaveType>
    {

    }


}