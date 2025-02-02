
namespace PerformanceManagementSystem.Infrastructure.Identity
{
    public class UserClaims
    {
        public int Id { get; set; }
        public string UserType { get; set; }
        public string Username { get; set; }
        public bool AccessMode { get; set; }
    }
}
