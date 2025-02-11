namespace PerformanceManagementSystem.Application.DTOs
{
    public class LoginDtoResponse
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
        public int UserTypeId { get; set; }
        public string UserType { get; set; }
    }
}
