using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceManagementSystem.Application.DTOs
{
    public class DepartmentDtoResponse
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public StatusDto Status { get; set; }
        public UserDto Manager { get; set; }
        public UserDto Creator { get; set; }
        public UserDto Modifier { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }

}
