﻿using PerformanceManagementSystem.Domain.Entities;
using PerformanceManagementSystem.Infrastructure.Persistence.Repositories;

namespace PerformanceManagementSystem.Application.Interfaces.Persistence
{
    public interface IDepartmentRepository : IBaseRepository<Department>
    {
        Task<IEnumerable<Department>> GetDepartmentsWithDetails();
        Task<Department> GetDepartmentWithDetails(int ID);
        Task<bool> NameExists(string Name);
        Task<bool> NameExists(int ID, string Name);
    }
}
