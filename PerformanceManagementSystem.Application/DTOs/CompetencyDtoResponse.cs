namespace PerformanceManagementSystem.Application.DTOs
{
    public class CompetencyDtoResponse
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Definition { get; set; }
        public int Level { get; set; }
        public CompetencyTypeDto Type { get; set; }
        public StatusDto Status { get; set; }
        public UserDto Creator { get; set; }
        public UserDto Modifier { get; set; }
    }
}
