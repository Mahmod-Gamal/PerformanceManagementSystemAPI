using Microsoft.EntityFrameworkCore;
using PerformanceManagementSystem.Application.Interfaces.Persistence;
using PerformanceManagementSystem.Domain.Entities;

namespace PerformanceManagementSystem.Infrastructure.Persistence.Repositories
{
    public class DepartmentRepository(PerformanceManagementDbContext context) : BaseRepository<Department>(context), IDepartmentRepository
    {

        public async Task<Department> GetDepartmentWithDetails(int ID) =>
            await context.Departments
                .Include(x => x.Status).Include(x => x.Manager)
                .Include(x => x.Creator).Include(x => x.Modifier)
                .FirstOrDefaultAsync(x => x.ID == ID);
        
        public async Task<IEnumerable<Department>> GetDepartmentsWithDetails() =>
            await context.Departments
                .Include(x => x.Status).Include(x => x.Manager)
                .Include(x => x.Creator).Include(x => x.Modifier)
                .ToListAsync();
    }
}
