using Microsoft.EntityFrameworkCore;
using PerformanceManagementSystem.Application.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceManagementSystem.Infrastructure.Persistence.Repositories
{

    public class UnitOfWork(PerformanceManagementDbContext context) : IUnitOfWork
    {
        private IUserRepository _userRepository;
        private IDurationRepository _durationRepository;
        private IDepartmentRepository _departmentRepository;
        private ICompetencyRepository _competencyRepository;
        public IUserRepository UserRepository => _userRepository ??= new UserRepository(context);
        public IDurationRepository DurationRepository => _durationRepository ??= new DurationRepository(context);
        public IDepartmentRepository DepartmentRepository => _departmentRepository ??= new DepartmentRepository(context);
        public ICompetencyRepository CompetencyRepository => _competencyRepository ??= new CompetencyRepository(context);
        public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
            => await context.SaveChangesAsync(cancellationToken);
         public void Dispose()
           => context.Dispose();
    }

}
