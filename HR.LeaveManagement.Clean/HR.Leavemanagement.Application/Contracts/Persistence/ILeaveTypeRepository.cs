using HR.LeaveManagement.Domain;

namespace HR.Leavemanagement.Application.Contracts.Persistence
{
    public interface ILeaveTypeRepository: IGenericRepository<LeaveType>
    {
        Task<bool> IsLeaveTypeUnique(string name);
       
    }


}