using SpaceLaunchAPI.Models.Domain;

namespace SpaceLaunchAPI.Models.DTO
{
    public class LaunchDTO
    {
        public string LaunchId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string RocketId { get; set; }
        public string LaunchpadId { get; set; }
        public bool Success { get; set; }
        public string Failures { get; set; }

        //Linked properties
        public String RocketType { get; set; }
        public String LaunchPad { get; set; }
        //Check that payloads can be linked
        public List<String> Payloads { get; set; }
        public List<String> Capsules { get; set; }
    }
}
