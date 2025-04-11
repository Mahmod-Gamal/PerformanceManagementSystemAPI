using PerformanceManagementSystem.Domain.Entities;
using PerformanceManagementSystem.Infrastructure.Persistence.Repositories;

namespace PerformanceManagementSystem.Application.Interfaces.Persistence
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<bool> Exists(int ID);
        Task<bool> Exists(int ID, int TypeID);
        Task<IEnumerable<User>> GetManagedUsersByManagerID(int ID);
        Task<User> GetUser(string emailOrUsername);
        Task<User> GetUserByEmail(string email);
        Task<IEnumerable<User>> GetUsersWithDetails();
        Task<User> GetUserWithDetails(int ID);
        Task<bool> UsernameExists(string Username);
        Task<bool> UsernameExists(int ID, string Username);
    }
}
