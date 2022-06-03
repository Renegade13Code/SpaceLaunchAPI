using Microsoft.AspNetCore.Mvc;
using SpaceLaunchAPI.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SpaceLaunchAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RocketController : ControllerBase
    {
        private readonly SpaceLaunchDbContext dbContext;

        public RocketController(SpaceLaunchDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // GET: api/<RocketController>
        [HttpGet]
        public IActionResult Get()
        {
            var rockets = dbContext.Rockets.ToList();
            return Ok(rockets);
            //return new string[] { "value1", "value2" };
        }

        // GET api/<RocketController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RocketController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RocketController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RocketController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}