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
                .Include(x => x.DepartmentCompetencies).ThenInclude(x=>x.Competency)
                .FirstOrDefaultAsync(x => x.ID == ID);
        
        public async Task<IEnumerable<Department>> GetDepartmentsWithDetails() =>
            await context.Departments
                .Include(x => x.Status).Include(x => x.Manager)
                .Include(x => x.Creator).Include(x => x.Modifier)
                .ToListAsync();

        public async Task<bool> NameExists(string Name)
            => await context.Departments.AnyAsync(x => x.Name == Name);
        public async Task<bool> NameExists(int ID, string Name)
            => await context.Departments.Where(x => x.ID != ID).AnyAsync(x => x.Name == Name);

        public async Task<bool> Exists(int ID)
            => await context.Departments.AnyAsync(x => x.ID == ID);
        public async Task AddDepartmentCompetencies(int DepartmentID,IEnumerable<int> competencies)
        {
            await context.DepartmentCompetencies.AddRangeAsync(competencies.Select(CompetencyID=>new DepartmentCompetency()
            {
                DepartmentID = DepartmentID,
                CompetencyID = CompetencyID
            } ));
        }
        public async Task CleareDepartmentCompetencies(int DepartmentID)
        {
            await context.DepartmentCompetencies
                .Where(dc=>dc.DepartmentID == DepartmentID)
                .ExecuteDeleteAsync();
        }
    }
}
