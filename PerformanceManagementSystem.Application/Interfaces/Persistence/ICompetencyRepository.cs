﻿using PerformanceManagementSystem.Domain.Entities;
using PerformanceManagementSystem.Infrastructure.Persistence.Repositories;

namespace PerformanceManagementSystem.Application.Interfaces.Persistence
{
    public interface ICompetencyRepository : IBaseRepository<Competency>
    {
        Task<IEnumerable<Competency>> GetCompetenciesWithDetails();
        Task<Competency> GetCompetencyWithDetails(int ID);
    }
}
