namespace PerformanceManagementSystem.Application.DTOs
{
    public class UserDtoResponse
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public ForeignDto Type { get; set; }
        public ForeignDto Department { get; set; }
        public ForeignDto Status { get; set; }
        public ForeignDto MidYearDuration { get; set; }
        public ForeignDto EndYearDuration { get; set; }
        public DateTime CreatedAt { get; set; }
        public ForeignDto Creator { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public ForeignDto Modifier { get; set; }
    }
}
