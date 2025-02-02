using Microsoft.EntityFrameworkCore;
using PerformanceManagementSystem.Application.Interfaces.Persistence;
using PerformanceManagementSystem.Domain.Entities;

namespace PerformanceManagementSystem.Infrastructure.Persistence.Repositories
{
    public class UserRepository(PerformanceManagementDbContext context) : BaseRepository<User>(context), IUserRepository
    {
        public async Task<User> GetUser(string email)
            => await context.Users.Where(u => u.Email == email).FirstOrDefaultAsync();

    }
}

