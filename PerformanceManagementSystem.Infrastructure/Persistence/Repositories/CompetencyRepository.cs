using PerformanceManagementSystem.Application.Interfaces.Persistence;
using PerformanceManagementSystem.Domain.Entities;

namespace PerformanceManagementSystem.Infrastructure.Persistence.Repositories
{
    public class CompetencyRepository(PerformanceManagementDbContext context) : BaseRepository<Competency>(context), ICompetencyRepository
    {

    }
}
