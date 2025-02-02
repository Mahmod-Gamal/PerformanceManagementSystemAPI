namespace PerformanceManagementSystem.Api.Utils
{
    public class ResponseTemplate
    {
        public int Status { get; set; }
        public string? Type { get; set; }
        public string? Title { get; set; }
        public string? TraceId { get; set; }
        public Errors? Errors { get; set; }
    }

    public class Errors
    {
        public string[]? AttribuiteName { get; set; }
        public string[]? AttribuiteName2 { get; set; }

    }
}
