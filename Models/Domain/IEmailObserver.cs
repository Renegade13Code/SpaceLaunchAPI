namespace SpaceLaunchAPI.Models.Domain;

public interface IEmailObserver
{
    string Email { get; set; }
    string LaunchId { get; set; }
    string Name { get; set; }
}