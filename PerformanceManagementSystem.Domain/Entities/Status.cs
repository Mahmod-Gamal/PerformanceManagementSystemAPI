namespace  PerformanceManagementSystem.Domain.Entities
{
    public class Status : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Competency> Competencies { get; set; }
        public ICollection<Department> Departments { get; set; }
        public ICollection<User> Users { get; set; }

    }
}
