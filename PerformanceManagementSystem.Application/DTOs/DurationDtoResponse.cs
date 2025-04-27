namespace PerformanceManagementSystem.Application.DTOs
{
    public class DurationDtoResponse
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public DateOnly Start { get; set; }
        public DateOnly End { get; set; }
        public bool IsPrimary { get; set; }
    }
}
