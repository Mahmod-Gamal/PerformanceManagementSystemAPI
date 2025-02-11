using PerformanceManagementSystem.Domain.Entities;
using PerformanceManagementSystem.Infrastructure.Persistence.Repositories;

namespace PerformanceManagementSystem.Application.Interfaces.Persistence
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetUser(string emailOrUsername);
        Task<User> GetUserByEmail(string email);
    }
}
