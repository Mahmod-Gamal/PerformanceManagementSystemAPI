using MediatR;
using PerformanceManagementSystem.Application.Common.Interfaces;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;

namespace PerformanceManagementSystem.Application.Features.User.Commands.UpdateUser
{
    public class UpdateUserCommand : ICommand<Result<UserDtoResponse>>
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public int DepartmentID { get; set; }
        public int StatusID { get; set; }
        public int DurationID { get; set; }

        public int UserTypeId { get; set; }
    }
}
