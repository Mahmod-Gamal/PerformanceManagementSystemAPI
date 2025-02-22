using Microsoft.EntityFrameworkCore;
using PerformanceManagementSystem.Application.Interfaces.Persistence;
using PerformanceManagementSystem.Domain.Entities;

namespace PerformanceManagementSystem.Infrastructure.Persistence.Repositories
{
    public class StatusRepository(PerformanceManagementDbContext context) : BaseRepository<Status>(context), IStatusRepository
    {
        public async Task<bool> Exists(int ID)
            => await context.Statuses.AnyAsync(x => x.ID == ID);
        public async Task<bool> NameExists(string Name)
            => await context.Statuses.AnyAsync(x => x.Name == Name);
        public async Task<bool> NameExists(int ID, string Name)
            => await context.Statuses.Where(x => x.ID != ID).AnyAsync(x => x.Name == Name);
    }
}
