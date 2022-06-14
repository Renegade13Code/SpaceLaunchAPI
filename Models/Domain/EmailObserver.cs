using System.ComponentModel.DataAnnotations;

namespace SpaceLaunchAPI.Models.Domain
{
    public class EmailObserver 
    {
        [Key]
        public string EmailId { get; set; }
        public string LaunchId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

    }
}
