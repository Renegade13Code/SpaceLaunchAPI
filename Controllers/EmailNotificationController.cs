using Microsoft.AspNetCore.Mvc;
using SpaceLaunchAPI.Models.Domain;
using SpaceLaunchAPI.Models.DTO;
using SpaceLaunchAPI.Repository;
using SpaceLaunchAPI.Services;

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

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(string Id)
        {
            var Emails = await ObserverRepo.GetByIdAsync(Id);

            if (Emails == null)
            {
               return NotFound($"Emails with Launch id {Id} not found");
            }

            var listOfUsers = Emails.Select(x => x);
            Subject subject = new Subject(Id, DateTime.UtcNow);
            ISubject LaunchNotification = subject;

            Observer observer;

            foreach (var currentUser in listOfUsers)
            {
                observer = new Observer(currentUser.Email, LaunchNotification);
            }

            LaunchNotification.NotifyObserver();

            return Ok(listOfUsers);

            
        }
    }
}
