using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceManagementSystem.Application.Interfaces.Persistence
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IDurationRepository DurationRepository { get; }
        IDepartmentRepository DepartmentRepository { get; }
        ICompetencyRepository CompetencyRepository { get; }
        Task<int> CommitAsync(CancellationToken cancellationToken = default);
    }
}
