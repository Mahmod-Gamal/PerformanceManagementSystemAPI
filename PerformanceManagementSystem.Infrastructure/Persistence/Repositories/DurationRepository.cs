using PerformanceManagementSystem.Application.Interfaces.Persistence;
using PerformanceManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceManagementSystem.Infrastructure.Persistence.Repositories
{
    public class DurationRepository(PerformanceManagementDbContext context) : BaseRepository<Duration>(context),IDurationRepository
    {

    }
}
