using PerformanceManagementSystem.Domain.Entities;
using PerformanceManagementSystem.Infrastructure.Persistence.Repositories;

namespace PerformanceManagementSystem.Application.Interfaces.Persistence
{
    public interface IUserGoalRepository : IBaseRepository<UserGoal>
    {
        Task<IEnumerable<UserGoal>> GetAllByUserID(int UserID);
        Task<UserGoal> GetByUserID(int UserID, int Year);
    }
}
