using PerformanceManagementSystem.Application.Interfaces.Persistence;
using PerformanceManagementSystem.Domain.Entities;

namespace PerformanceManagementSystem.Infrastructure.Persistence.Repositories
{
    public class DurationRepository(PerformanceManagementDbContext context) : BaseRepository<Duration>(context),IDurationRepository
    {

    }
}
