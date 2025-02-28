using Microsoft.EntityFrameworkCore;
using PerformanceManagementSystem.Application.Interfaces.Persistence;
using System;
namespace PerformanceManagementSystem.Infrastructure.Persistence.Repositories
{

    public class UnitOfWork(PerformanceManagementDbContext context) : IUnitOfWork
    {
        private IUserRepository _userRepository;
        private IUserGoalRepository _userGoalRepository;
        private IDurationRepository _durationRepository;
        private IDepartmentRepository _departmentRepository;
        private IStatusRepository _statusRepository;
        private ICompetencyRepository _competencyRepository;
        private ICompetencyTypeRepository _competencyTypeRepository;
        public IUserRepository UserRepository => _userRepository ??= new UserRepository(context);
        public IUserGoalRepository UserGoalRepository => _userGoalRepository ??= new UserGoalRepository(context);
        public IDurationRepository DurationRepository => _durationRepository ??= new DurationRepository(context);
        public IDepartmentRepository DepartmentRepository => _departmentRepository ??= new DepartmentRepository(context);
        public IStatusRepository StatusRepository => _statusRepository ??= new StatusRepository(context);
        public ICompetencyRepository CompetencyRepository => _competencyRepository ??= new CompetencyRepository(context);
        public ICompetencyTypeRepository CompetencyTypeRepository => _competencyTypeRepository ??= new CompetencyTypeRepository(context);
        public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
            => await context.SaveChangesAsync(cancellationToken);
         public void Dispose()
           => context.Dispose();
    }

}
