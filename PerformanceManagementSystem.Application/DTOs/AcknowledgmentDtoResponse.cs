namespace PerformanceManagementSystem.Application.DTOs
{
    public class AcknowledgmentDtoResponse
    {
        public string Message { get; set; }
        public AcknowledgmentDtoResponse(string Message)
        {
            this.Message = Message;

        }
        // To be deleted!!
        public AcknowledgmentDtoResponse()
        {
            this.Message = "";

        }
    }
}
