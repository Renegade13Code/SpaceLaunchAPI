using System.ComponentModel.DataAnnotations;

namespace SpaceLaunchAPI.Models.Domain
{
    public class Launch
    {
        [Key]
        public string LaunchId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string RocketId { get; set; }
        public string LaunchpadId { get; set; }
        public bool Success { get; set; }
        public string Failures { get; set; }

        //Navigation properties
        public Rocket RocketModel { get; set; }
        public LaunchPad LaunchPadModel { get; set; }
        //Check that payloads can be linked
        public List<Payload> Payloads { get; set; }
        public List<Capsule> Capsules { get; set; }

    }
}
