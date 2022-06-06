using System.ComponentModel.DataAnnotations;

namespace SpaceLaunchAPI.Models.Domain
{
    public class LaunchPad
    {
        [Key]
        public string LaunchpadId { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Status { get; set; }
        public string Locality { get; set; }
        public string Region { get; set; }
        public string TimeZone { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
