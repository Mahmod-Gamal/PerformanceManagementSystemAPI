

namespace PerformanceManagementSystem.Application.Interfaces.Identity
{
    public interface IPasswordManager
    {
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        bool Verfiy(string password, byte[] passwordHash, byte[] passwordSalt);
    }
}
