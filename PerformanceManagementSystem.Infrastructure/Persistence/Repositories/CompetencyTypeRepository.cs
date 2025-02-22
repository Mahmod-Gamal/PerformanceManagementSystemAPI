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

        public async Task<bool> NameExists(string Name)
            => await context.CompetencyTypes.AnyAsync(x => x.Name == Name);
        public async Task<bool> NameExists(int ID, string Name)
            => await context.CompetencyTypes.Where(x => x.ID != ID).AnyAsync(x => x.Name == Name);
        public async Task<bool> Exists(int ID)
            => await context.CompetencyTypes.AnyAsync(x => x.ID == ID);
    }
}
