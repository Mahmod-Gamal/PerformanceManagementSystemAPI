namespace PerformanceManagementSystem.Domain.Entities
{
    public class Duration : BaseEntity
    {
        public string Name { get; set; }
        public DateOnly Start {  get; set; }
        public DateOnly End { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
