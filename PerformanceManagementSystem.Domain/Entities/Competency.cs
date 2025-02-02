using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  PerformanceManagementSystem.Domain.Entities
{
    public class Competency : BaseEntity, IAuditable
    {
        public string Name { get; set; }
        public string Definition { get; set; }
        public int Level { get; set; }
        public string Description { get; set; }
        public int CompetenciesTypeID { get; set; }
        public CompetencyType CompetencyType { get; set; }
        public int StatusID { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public User Creator { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public int? ModifiedBy { get; set; }
        public User Modifier { get; set; }
        public ICollection<DepartmentCompetency> DepartmentCompetencies { get; set; }
        public ICollection<UserCompetency> UserCompetencies { get; set; }
    }
}
