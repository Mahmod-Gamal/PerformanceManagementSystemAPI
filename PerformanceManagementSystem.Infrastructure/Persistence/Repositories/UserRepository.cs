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

    }
}

