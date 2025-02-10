

namespace PerformanceManagementSystem.Application.Interfaces.Identity
{
    public interface IPasswordManager
    {
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        bool Verfiy(string password, byte[] passwordHash, byte[] passwordSalt);
        string GenerateRandomOTP();
        (string username, string OTP) DecodeOTT(string OTT);
        string EncodeOTT(string username, string OTP);
    }
}
