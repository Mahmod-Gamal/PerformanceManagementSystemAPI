using Microsoft.EntityFrameworkCore;
using PerformanceManagementSystem.Application.Interfaces.Persistence;
using PerformanceManagementSystem.Domain.Entities;
using System.Drawing;

namespace PerformanceManagementSystem.Infrastructure.Persistence.Repositories
{
    public class DurationRepository(PerformanceManagementDbContext context) : BaseRepository<Duration>(context),IDurationRepository
    {
        public async Task<bool> NameExists(string Name)
            => await context.Durations.AnyAsync(x => x.Name == Name);
        public async Task<bool> NameExists(int ID,string Name)
            => await context.Durations.Where(x=>x.ID != ID).AnyAsync(x => x.Name == Name);
    }
}
