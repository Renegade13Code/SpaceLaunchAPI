using Microsoft.AspNetCore.Mvc;
using SpaceLaunchAPI.Data;
using SpaceLaunchAPI.Models.Domain;
using SpaceLaunchAPI.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SpaceLaunchAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaunchpadController : ControllerBase
    {
        private readonly ILaunchpadRepository launchpadRepo;

        public LaunchpadController(ILaunchpadRepository launchpadRepo)
        {
            this.launchpadRepo = launchpadRepo;
        }
        // GET: api/<LaunchpadController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var launchpad = await launchpadRepo.GetAllAsync();
            return Ok(launchpad);
        }

        // GET api/<LaunchpadController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var foundLp = await launchpadRepo.GetByIdAsync(id);
            if(foundLp == null)
            {
                return Ok("Not found");
            }
            return Ok(foundLp);
        }

        // POST api/<LaunchpadController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LaunchPad launchPad)
        {
            var newLp = await launchpadRepo.AddAsync(launchPad);
            return Ok(newLp);
        }

        // PUT api/<LaunchpadController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] LaunchPad launchPad)
        {
            var newLp = await launchpadRepo.UpdateAsync(id, launchPad);
            if (newLp == null)
            {
                return Ok("Not found");
            }
            return Ok(newLp);
        }

        // DELETE api/<LaunchpadController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var foundLp = await launchpadRepo.DeleteAsync(id);
            if (foundLp == null)
            {
                return Ok("Not found");
            }
            return Ok(foundLp);
        }
    }
}
