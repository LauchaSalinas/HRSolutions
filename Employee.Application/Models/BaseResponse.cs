namespace HRSolutions.Application.Models
{
    public abstract class BaseResponse
    { 
        public required StatusResponse Status { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public List<string>? Errors { get; set; }
    }
}
