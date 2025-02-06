using PerformanceManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceManagementSystem.Application.DTOs
{
    public class UserDtoResponse
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public UserTypeDto Type { get; set; }
        public DepartmentDto Department { get; set; }
        public StatusDto Status { get; set; }
        public DurationDto Duration { get; set; }
        public DateTime CreatedAt { get; set; }
        public UserDto Creator { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public UserDto Modifier { get; set; }
    }
}
