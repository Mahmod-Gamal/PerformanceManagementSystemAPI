using Newtonsoft.Json;

namespace PerformanceManagementSystem.Api.Utils
{
    public class ErrorDetails
    {
        public int Status { get; set; }
        public string? Type { get; set; }
        public string? Title { get; set; }
        public string? TraceId { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
