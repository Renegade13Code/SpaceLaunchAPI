using System.ComponentModel.DataAnnotations;

namespace SpaceLaunchAPI.Models.Domain
{
    public class Astronaut
    {
        //payload_id,name,type,reused,manufacturers,mass_kg,mass_lb,orbit,reference_system,regime,launch_id
        [Key]
        public string AstronautId { get; set; }
        public string Name { get; set; }
        public string Craft { get; set; }
    }
}
