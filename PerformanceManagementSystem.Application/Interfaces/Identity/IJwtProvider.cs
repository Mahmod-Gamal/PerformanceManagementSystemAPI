
using PerformanceManagementSystem.Domain.Entities;
using PerformanceManagementSystem.Infrastructure.Identity;

namespace PerformanceManagementSystem.Application.Interfaces.Identity
{
    public interface IJwtProvider
    {
        double DurationInDays { get; }
        string GenerateToken(User user);
        UserClaims GetUserClaims();
    }
}
