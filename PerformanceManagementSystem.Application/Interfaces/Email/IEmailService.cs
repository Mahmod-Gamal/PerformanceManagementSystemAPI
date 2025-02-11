namespace PerformanceManagementSystem.Application.Interfaces.Email
{
    public interface IEmailService
    {
        void SendEmail(string toEmail, string subject, string body);
    }
}
