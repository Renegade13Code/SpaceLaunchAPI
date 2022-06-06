namespace SpaceLaunchAPI.Models.DTO
{
    public class LaunchRequest
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string RocketId { get; set; }
        public string LaunchpadId { get; set; }
        public bool Success { get; set; }
        public string Failures { get; set; }
    }
}
