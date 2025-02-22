namespace  PerformanceManagementSystem.Domain.Entities
{
    public class Department : BaseEntity, IAuditable
    {
        public string Name { get; set; }
        public int? ManagerId { get; set; }
        public User Manager { get; set; }
        public int StatusID { get; set; }
        public Status Status { get; set; }

        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public User Creator { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public int? ModifiedBy { get; set; }
        public User Modifier { get; set; }


        public ICollection<DepartmentCompetency> DepartmentCompetencies { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
