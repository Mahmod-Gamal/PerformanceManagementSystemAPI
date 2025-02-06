using MediatR;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceManagementSystem.Application.Features.User.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<Result<UserDtoResponse>>
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public int TypeID { get; set; }
        public int DepartmentID { get; set; }
        public int StatusID { get; set; }
        public int DurationID { get; set; }
    }
}
