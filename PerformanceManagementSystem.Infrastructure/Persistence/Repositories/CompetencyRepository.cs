using PerformanceManagementSystem.Application.Interfaces.Persistence;
using PerformanceManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceManagementSystem.Infrastructure.Persistence.Repositories
{
    public class CompetencyRepository(PerformanceManagementDbContext context) : BaseRepository<Competency>(context), ICompetencyRepository
    {

    }
}
