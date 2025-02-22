namespace PerformanceManagementSystem.Application.DTOs
{
    public class DepartmentDtoResponse
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ForeignDto Status { get; set; }
        public ForeignDto Manager { get; set; }
        public ForeignDto Creator { get; set; }
        public ForeignDto Modifier { get; set; }
        public List<ForeignDto> Competencies { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }

}
