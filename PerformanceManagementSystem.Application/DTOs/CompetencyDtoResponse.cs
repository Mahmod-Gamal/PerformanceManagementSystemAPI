namespace PerformanceManagementSystem.Application.DTOs
{
    public class CompetencyDtoResponse
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Definition { get; set; }
        public int Level { get; set; }
        public ForeignDto Type { get; set; }
        public ForeignDto Status { get; set; }
        public ForeignDto Creator { get; set; }
        public ForeignDto Modifier { get; set; }
    }
}
