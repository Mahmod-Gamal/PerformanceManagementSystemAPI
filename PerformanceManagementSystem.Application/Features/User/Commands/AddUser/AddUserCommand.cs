using MediatR;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Features.User.Commands.AddUser;

namespace PerformanceManagementSystem.Application.Features.User.Commands.AddUser
{
    public class AddUserCommand : IRequest<Result<UserDtoResponse>>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public int TypeID { get; set; }
        public int DepartmentID { get; set; }
        public int DurationID { get; set; }
    }
}
