using PerformanceManagementSystem.Application.Interfaces.Persistence;
using PerformanceManagementSystem.Domain.Entities;

namespace PerformanceManagementSystem.Infrastructure.Persistence.Repositories
{
    public class DepartmentRepository(PerformanceManagementDbContext context) : BaseRepository<Department>(context), IDepartmentRepository
    {

    }
}
