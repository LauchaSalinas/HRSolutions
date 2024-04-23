namespace WeatherForecastTest
{
    public class WeatherForecastRequest
    {
        public int take { get; set; } = 50;
        public int skip { get; set; } = 0;
        public string EmployeeName { get; set; } = string.Empty;
    }

    public class EmployeeCreateResponse
    {
        public DateTime CreationDate { get; set; }
        
    }


}
