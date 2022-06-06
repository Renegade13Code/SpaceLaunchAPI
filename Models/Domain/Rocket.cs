using System.ComponentModel.DataAnnotations;

namespace SpaceLaunchAPI.Models.Domain
{
    public class Rocket
    {
        [Key]
        public string RocketId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool IsActive { get; set; }
        public string Country { get; set; }
        public string Company { get; set; }
        public double HeightMt { get; set; }
        public double HeightFt { get; set; }
        public double DiameterMt { get; set; }
        public double DiameterFt { get; set; }
        public double MassKg { get; set; }
        public double MassLb { get; set; }
        public int Stages { get; set; }
        public int Boosters { get; set; }
        public double CostPerLaunch { get; set; }

        [MaxLength(512)]
        public string Engines { get; set; }
    }
}
