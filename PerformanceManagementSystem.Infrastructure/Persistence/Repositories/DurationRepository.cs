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
        public async Task<bool> Exists(int ID)
            => await context.Durations.AnyAsync(x => x.ID == ID);
        public async Task<bool> IsPrimary(int ID)
            => await context.Durations.Where(x => x.ID == ID).Select(x => x.IsPrimary).FirstAsync();

        public async Task<Duration> GetDurationWithUsers(int ID)
            => await context.Durations
            .Include(x=>x.DurationType)
            .Include(x=>x.SettingGoalsUsers)
            .Include(x=>x.MidYearUsers)
            .Include(x=>x.EndYearUsers)
            .FirstAsync(x=>x.ID == ID);

        
        public async Task UpdateDependenciesToDefaults(int ID)
        {
            context.Durations
                .Where(x => x.ID == ID)
                .SelectMany(x => x.SettingGoalsUsers)
                .ForEachAsync(x => x.SettingGoalsDurationID = 1);
            context.Durations
                .Where(x => x.ID == ID)
                .SelectMany(x => x.MidYearUsers)
                .ForEachAsync(x => x.MidYearDurationID = 2);
            context.Durations
                .Where(x => x.ID == ID)
                .SelectMany(x => x.EndYearUsers)
                .ForEachAsync(x => x.EndYearDurationID = 3);
        }
    }
}
