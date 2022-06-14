using Microsoft.AspNetCore.Mvc;
using SpaceLaunchAPI.Data;
using SpaceLaunchAPI.Models.Domain;
using SpaceLaunchAPI.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SpaceLaunchAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RocketController : ControllerBase
    {
        private readonly IRocketRepository rocketRepo;

        public RocketController(IRocketRepository rocketRepo)
        {
            this.rocketRepo = rocketRepo;
        }
        // GET: api/<RocketController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var rockets = await rocketRepo.GetAllAsync();
            return Ok(rockets);
            //return new string[] { "value1", "value2" };
        }

        // GET api/<RocketController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var rocket = await rocketRepo.GetByIdAsync(id);
            if (rocket == null)
            {
                return Ok("not found");
            }
            return Ok(rocket);
        }

        // GET api/<RocketController>/5
        [HttpGet("filter")]
        public async Task<IActionResult> Get(bool isActive)
        {
            var rocket = await rocketRepo.GetRocketStatus(isActive);
            if (rocket == null)
            {
                return Ok("not found");
            }
            return Ok(rocket);
        }

        // POST api/<RocketController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Rocket rocket)
        {
            var newRocket= await rocketRepo.AddAsync(rocket);
            return Ok(newRocket);
        }

        // PUT api/<RocketController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Rocket rocket)
        {
            var updatedRocket = await rocketRepo.UpdateAsync(id, rocket);
            if (updatedRocket == null)
            {
                return Ok("not found");
            }
            return Ok(updatedRocket);
        }

        // DELETE api/<RocketController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var deletedRocket = await rocketRepo.DeleteAsync(id);
            if (deletedRocket == null)
            {
                return Ok("not found");
            }
            return Ok(deletedRocket);
        }
    }
}
