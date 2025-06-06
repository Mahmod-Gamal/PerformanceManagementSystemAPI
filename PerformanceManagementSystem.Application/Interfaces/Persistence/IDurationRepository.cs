﻿using PerformanceManagementSystem.Domain.Entities;
using PerformanceManagementSystem.Infrastructure.Persistence.Repositories;

namespace PerformanceManagementSystem.Application.Interfaces.Persistence
{
    public interface IDurationRepository : IBaseRepository<Duration>
    {
        Task<bool> Exists(int ID);
        Task<DomainDuration> GetDurationWithUsers(int ID);
        Task<bool> IsPrimary(int ID);
        Task<bool> NameExists(string Name);
        Task<bool> NameExists(int ID, string Name);
        Task UpdateDependenciesToDefaults(int ID);
    }
}
