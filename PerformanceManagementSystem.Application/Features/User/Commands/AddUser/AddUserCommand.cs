using MediatR;
using PerformanceManagementSystem.Application.Common.Interfaces;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Domain.Entities;

namespace PerformanceManagementSystem.Application.Features.User.Commands.AddUser
{
    public class AddUserCommand : ICommand<Result<UserDtoResponse>>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public int DepartmentID { get; set; }
        public int MidYearDurationID { get; set; }
        public int EndYearDurationID { get; set; }
        public int UserTypeId { get; set; }
    }
}
