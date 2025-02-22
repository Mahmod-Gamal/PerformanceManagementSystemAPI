using Microsoft.EntityFrameworkCore;
using PerformanceManagementSystem.Application.Interfaces.Persistence;
using PerformanceManagementSystem.Domain.Entities;

namespace PerformanceManagementSystem.Infrastructure.Persistence.Repositories
{
    public class UserRepository(PerformanceManagementDbContext context) : BaseRepository<User>(context), IUserRepository
    {
        public async Task<User> GetUser(string emailOrUsername)
            => await context.Users.Where(u => u.Email == emailOrUsername || u.UserName == emailOrUsername)
                                  .Include(u => u.UserType)
                                  .FirstOrDefaultAsync();
        public async Task<User> GetUserByEmail(string email)
            => await context.Users.Where(u => u.Email == email)
                                  .Include(u => u.UserType)
                                  .FirstOrDefaultAsync();

        public async Task<User> GetUserWithDetails(int ID) =>
           await context.Users
               .Include(x => x.Status)
               .Include(x => x.UserType)
               .Include(x=>x.Department)
               .Include(x=>x.MidYearDuration)
               .Include(x => x.EndYearDuration)
               .Include(x => x.Creator)
               .Include(x => x.Modifier)
               .FirstOrDefaultAsync(x => x.ID == ID);

        public async Task<IEnumerable<User>> GetUsersWithDetails() =>
            await context.Users
               .Include(x => x.Status)
               .Include(x => x.UserType)
               .Include(x => x.Department)
               .Include(x => x.MidYearDuration)
               .Include(x => x.EndYearDuration)
               .Include(x => x.Creator)
               .Include(x => x.Modifier)
               .ToListAsync();


        public async Task<bool> UsernameExists(string Username)
            => await context.Users.AnyAsync(x => x.UserName == Username);
        public async Task<bool> UsernameExists(int ID, string Username)
            => await context.Users.Where(x => x.ID != ID).AnyAsync(x => x.UserName == Username);

    }
}

