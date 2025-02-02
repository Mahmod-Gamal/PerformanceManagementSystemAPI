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
        Task<int> CommitAsync(CancellationToken cancellationToken = default);
    }
}
