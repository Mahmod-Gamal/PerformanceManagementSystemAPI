using Microsoft.EntityFrameworkCore;
using PerformanceManagementSystem.Application.Interfaces.Persistence;
using PerformanceManagementSystem.Domain.Entities;
namespace PerformanceManagementSystem.Infrastructure.Persistence.Repositories
{
    public class UserGoalRepository(PerformanceManagementDbContext context) : BaseRepository<UserGoal>(context), IUserGoalRepository
    {
        public async Task<UserGoal> GetByUserID(int UserID, int Year)
            => await context.UserGoals.Where(x => x.UserID == UserID && x.Year == Year)
            .Include(x => x.UserLearningAndDevelopmentPlans)
            .Include(x => x.UserObjectives)
            .Include(x => x.UserTrainingAndDevelopmentSections).FirstOrDefaultAsync();

        public async Task<IEnumerable<UserGoal>> GetAllByUserID(int UserID)
            => await context.UserGoals.Where(x => x.UserID == UserID)
            .Include(x => x.UserLearningAndDevelopmentPlans)
            .Include(x => x.UserObjectives)
            .Include(x => x.UserTrainingAndDevelopmentSections)
            .ToListAsync();
    }
}
