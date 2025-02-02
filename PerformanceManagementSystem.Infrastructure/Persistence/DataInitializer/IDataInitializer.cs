using PerformanceManagementSystem.Domain.Entities;

namespace PerformanceManagementSystem.Infrastructure.Persistence.DataInitializer
{
    public interface IDataInitializer
    {
        List<CompetencyType> CompetencyTypesSeed();
        List<Status> StatusesSeed();
        List<UserType> UserTypesSeed();
        List<User> UsersSeed();

    }
}
