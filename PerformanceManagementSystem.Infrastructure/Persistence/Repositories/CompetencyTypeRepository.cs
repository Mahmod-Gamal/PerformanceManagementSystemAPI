using Microsoft.EntityFrameworkCore;
using PerformanceManagementSystem.Application.Interfaces.Persistence;
using PerformanceManagementSystem.Domain.Entities;

namespace PerformanceManagementSystem.Infrastructure.Persistence.Repositories
{
    public class CompetencyTypeRepository(PerformanceManagementDbContext context) : BaseRepository<CompetencyType>(context), ICompetencyTypeRepository
    {
        public async Task<IEnumerable<CompetencyType>> GetCompetencyTypes() =>
            await context.CompetencyTypes
                .ToListAsync();
    }
}
