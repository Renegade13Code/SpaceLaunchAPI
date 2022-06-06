using System.ComponentModel.DataAnnotations;

namespace SpaceLaunchAPI.Models.Domain
{
    public class Capsule
    {
        [Key]
        public string CapsuleId { get; set; }
        public string Serial { get; set; }
        public string Status { get; set; }
        public int ReuseCount { get; set; }
        public int WaterLandings { get; set; }
        public int LandLandings { get; set; }
        public string LaunchId { get; set; }

        //Navigational properties
        public Launch LaunchModel { get; set; }

    }
}
