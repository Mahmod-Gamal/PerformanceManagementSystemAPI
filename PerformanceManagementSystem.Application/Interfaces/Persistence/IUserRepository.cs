using PerformanceManagementSystem.Domain.Entities;
using PerformanceManagementSystem.Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceManagementSystem.Application.Interfaces.Persistence
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetUser(string emailOrUsername);
        Task<User> GetUserByEmail(string email);
    }
}
