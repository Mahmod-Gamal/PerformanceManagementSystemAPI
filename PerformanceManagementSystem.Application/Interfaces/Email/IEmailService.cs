
namespace PerformanceManagementSystem.Application.Interfaces.Email
{
    public interface IEmailService
    {
        void SendEmail(string toEmail, string subject, string body);
        void SendEmail(List<string> toEmails, string subject, string body);
    }
}
