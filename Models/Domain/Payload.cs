using System.ComponentModel.DataAnnotations;

namespace SpaceLaunchAPI.Models.Domain
{
    public class Payload
    {
        //payload_id,name,type,reused,manufacturers,mass_kg,mass_lb,orbit,reference_system,regime,launch_id
        [Key]
        public string PayloadId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool Reused { get; set; }
        public string Manufacturers { get; set; }
        public double? MassKg { get; set; }
        public double? MassLb { get; set; }
        public string Orbit { get; set; }
        public string ReferenceSystem { get; set; }
        public string Regime { get; set; }
        public string LaunchId { get; set; }

        //Navigation Properties
        public Launch LaunchModel { get; set; }
    }
}
