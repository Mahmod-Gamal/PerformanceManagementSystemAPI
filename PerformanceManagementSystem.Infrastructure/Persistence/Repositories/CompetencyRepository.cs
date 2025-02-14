using Microsoft.EntityFrameworkCore;
using PerformanceManagementSystem.Application.Interfaces.Persistence;
using PerformanceManagementSystem.Domain.Entities;

namespace PerformanceManagementSystem.Infrastructure.Persistence.Repositories
{
    public class CompetencyRepository(PerformanceManagementDbContext context) : BaseRepository<Competency>(context), ICompetencyRepository
    {
        public async Task<Competency> GetCompetencyWithDetails(int ID) =>
            await context.Competencies
                .Include(x => x.Status).Include(x => x.CompetencyType)
                .Include(x => x.Creator).Include(x => x.Modifier)
                .FirstOrDefaultAsync(x=>x.ID == ID);

        public async Task<IEnumerable<Competency>> GetCompetenciesWithDetails() =>
            await context.Competencies
                .Include(x => x.Status).Include(x => x.CompetencyType)
                .Include(x => x.Creator).Include(x => x.Modifier)
                .ToListAsync();
    }
}
