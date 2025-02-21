namespace PerformanceManagementSystem.Domain.Entities
{
    public class Duration : BaseEntity
    {
        public string Name { get; set; }
        public DateOnly Start {  get; set; }
        public DateOnly End { get; set; }
        public ICollection<User> EndYearUsers { get; set; }
        public ICollection<User> MidYearUsers { get; set; }
        public bool IsPrimary  { get; set; }
    }
}
