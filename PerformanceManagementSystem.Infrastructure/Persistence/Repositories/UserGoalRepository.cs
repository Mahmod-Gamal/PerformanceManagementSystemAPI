using Microsoft.EntityFrameworkCore;
using PerformanceManagementSystem.Application.Interfaces.Persistence;
using PerformanceManagementSystem.Domain.Entities;
namespace PerformanceManagementSystem.Infrastructure.Persistence.Repositories
{
    public class UserGoalRepository(PerformanceManagementDbContext context) : BaseRepository<UserGoal>(context), IUserGoalRepository
    {
        public async Task<UserGoal> GetByUserID(int UserID, int Year, bool ByAdmin)
            => await context.UserGoals.Where(x => x.UserID == UserID && x.Year == Year && x.ByAdmin == ByAdmin)
            .Include(x => x.UserLearnings)
            .ThenInclude(x => x.UserTrainings)
            .Include(x => x.UserObjectives)
            .Include(x => x.UserCompetencies)
            .ThenInclude(uc => uc.Competency)
            .Include(x => x.User)
            .ThenInclude(x => x.MidYearDuration)
            .Include(x => x.User)
            .ThenInclude(x => x.EndYearDuration)
            .FirstOrDefaultAsync();

        public async Task<IEnumerable<UserGoal>> GetAllByUserID(int UserID)
            => await context.UserGoals.Where(x => x.UserID == UserID)
            .Include(x => x.UserLearnings)
            .ThenInclude(x => x.UserTrainings)
            .Include(x => x.UserObjectives)
            .Include(x => x.UserCompetencies)
            .ThenInclude(uc=>uc.Competency)
            .Include(x=>x.User)
            .ThenInclude(x=>x.MidYearDuration)
            .Include(x => x.User)
            .ThenInclude(x => x.EndYearDuration)
            .ToListAsync();
    }
}
