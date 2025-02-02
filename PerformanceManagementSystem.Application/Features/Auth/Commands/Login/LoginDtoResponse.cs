using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceManagementSystem.Application.Features.Auth.Commands.Login
{
    public class LoginDtoResponse
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
        public bool ShouldChangePassword { get; set; }
        public int UserTypeId { get; set; }
        public string UserType { get; set; }
    }
}
