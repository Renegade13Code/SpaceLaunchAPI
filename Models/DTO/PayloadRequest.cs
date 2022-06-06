namespace SpaceLaunchAPI.Models.DTO
{
    public class PayloadRequest
    {
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
    }
}
