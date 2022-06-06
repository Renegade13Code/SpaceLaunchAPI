namespace SpaceLaunchAPI.Models.DTO
{
    public class CapsuleDTO
    {
        public string CapsuleId { get; set; }
        public string Serial { get; set; }
        public string Status { get; set; }
        public int ReuseCount { get; set; }
        public int WaterLandings { get; set; }
        public int LandLandings { get; set; }
        public string LaunchId { get; set; }
    }
}
