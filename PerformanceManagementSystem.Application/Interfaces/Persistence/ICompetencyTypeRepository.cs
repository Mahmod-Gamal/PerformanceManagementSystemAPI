using PerformanceManagementSystem.Infrastructure.Persistence.Repositories;
using PerformanceManagementSystem.Domain.Entities;

namespace PerformanceManagementSystem.Application.Interfaces.Persistence
{
    public interface ICompetencyTypeRepository : IBaseRepository<CompetencyType>
    {
        Task<IEnumerable<CompetencyType>> GetCompetencyTypes();
        Task<bool> NameExists(string Name);
        Task<bool> NameExists(int ID, string Name);
    }
}
