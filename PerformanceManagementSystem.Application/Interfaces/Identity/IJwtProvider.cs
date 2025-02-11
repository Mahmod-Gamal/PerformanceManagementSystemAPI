using PerformanceManagementSystem.Domain.Entities;
using PerformanceManagementSystem.Application.DTOs;

namespace PerformanceManagementSystem.Application.Interfaces.Identity
{
    public interface IJwtProvider
    {
        double DurationInDays { get; }
        string GenerateToken(User user);
        UserClaims GetUserClaims();
    }
}
