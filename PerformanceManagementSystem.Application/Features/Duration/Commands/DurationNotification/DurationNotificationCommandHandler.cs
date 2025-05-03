using MediatR;
using Microsoft.AspNetCore.Http;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Features.Duration.Commands.DeleteDuration;
using PerformanceManagementSystem.Application.Interfaces.Email;
using PerformanceManagementSystem.Application.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceManagementSystem.Application.Features.Duration.Commands.DurationNotification
{
    public class DurationNotificationCommandHandler(IUnitOfWork unitOfWork,IEmailService emailService,IHttpContextAccessor contextAccessor) : IRequestHandler<DurationNotificationCommand, Result<AcknowledgmentDtoResponse>>
    {
        public async Task<Result<AcknowledgmentDtoResponse>> Handle(DurationNotificationCommand request, CancellationToken cancellationToken)
        {
            var duration = await unitOfWork.DurationRepository.GetDurationWithUsers(request.ID);
            if(duration is null) return Result<AcknowledgmentDtoResponse>.NotFound("Duration Not Found");
            var users = duration.DurationTypeID == 1 ? duration.SettingGoalsUsers
                : duration.DurationTypeID ==2 ? duration.MidYearUsers 
                : duration.EndYearUsers;
            
            // Filter Inactive Users
            var emails = users.Where(u=>u.StatusID == 1).Select(u => u.Email).ToList();
            // var emails = List<string>{"mahmomud.s.marwad@gmail.com"};
            string htmlBody = $@"
<html>
<body style='font-family: Arial, sans-serif; font-size: 14px; color: #333;'>
  <p>Dears,</p>

  <p>
     Kindly be informed that : {duration.DurationType.Name} Duration id opened from : {duration.Start} to {duration.End}
  </p>

  <p>Regards,<br>
  <strong>PerformanceManagementSystem</strong></p>
</body>
</html>";
            emailService.SendEmail(emails,"Duration Notification", htmlBody);
            return Result<AcknowledgmentDtoResponse>.Ok(new("Notification Sent"));
        }
    }
}
