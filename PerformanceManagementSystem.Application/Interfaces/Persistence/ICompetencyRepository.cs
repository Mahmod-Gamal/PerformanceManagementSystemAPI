using PerformanceManagementSystem.Domain.Entities;
using PerformanceManagementSystem.Infrastructure.Persistence.Repositories;

namespace PerformanceManagementSystem.Application.Interfaces.Persistence
{
    public interface ICompetencyRepository : IBaseRepository<Competency>
    {
        Task<bool> Exists(int ID);
        Task<IEnumerable<Competency>> GetBehavioralCompetencies();
        Task<IEnumerable<Competency>> GetCompetenciesByDepartment(int ID);
        Task<IEnumerable<Competency>> GetCompetenciesWithDetails();
        Task<Competency> GetCompetencyWithDetails(int ID);
        Task<bool> NameExists(string Name);
        Task<bool> NameExists(int ID, string Name);
    }
}
