using Microsoft.AspNetCore.Mvc;
using SpaceLaunchAPI.Models.Domain;
using SpaceLaunchAPI.Models.DTO;
using SpaceLaunchAPI.Repository;


namespace SpaceLaunchAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailNotificationController : Controller
    {
        private readonly IObserverRepository ObserverRepo;

        public EmailNotificationController(IObserverRepository ObserverRepo)
        {
            this.ObserverRepo = ObserverRepo;
        }
        // Post user name, email and desired launch id to be notified on
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ObserverRequest addLaunchObserver)
        {
            var EmailDomain = new EmailObserver()
            {
                Name = addLaunchObserver.Name,
                LaunchId = addLaunchObserver.LaunchId,
                Email = addLaunchObserver.Email
            };

            EmailDomain = await ObserverRepo.AddAsync(EmailDomain);
            return Ok(EmailDomain);
        }
    }
}
