namespace  PerformanceManagementSystem.Domain.Entities
{
    public interface IAuditable
    {
        public DateTime CreatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public User Creator { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public int? ModifiedBy { get; set; }
        public User Modifier { get; set; }
    }
}
