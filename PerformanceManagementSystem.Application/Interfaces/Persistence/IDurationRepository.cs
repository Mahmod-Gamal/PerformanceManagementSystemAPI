using PerformanceManagementSystem.Domain.Entities;
using PerformanceManagementSystem.Infrastructure.Persistence.Repositories;

namespace PerformanceManagementSystem.Application.Interfaces.Persistence
{
    public interface IDurationRepository : IBaseRepository<Duration>
    {
        Task<bool> Exists(int ID);
        Task<bool> NameExists(string Name);
        Task<bool> NameExists(int ID, string Name);
    }
}
