namespace PerformanceManagementSystem.Domain.Entities
{
    public class Duration : BaseEntity
    {
        public string Name { get; set; }
        public DateTime Start {  get; set; }
        public DateTime End { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
