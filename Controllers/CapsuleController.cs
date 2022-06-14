using Microsoft.AspNetCore.Mvc;
using SpaceLaunchAPI.Buidler;
using SpaceLaunchAPI.Builder;
using SpaceLaunchAPI.Models.Domain;
using SpaceLaunchAPI.Models.DTO;
using SpaceLaunchAPI.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SpaceLaunchAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CapsuleController : ControllerBase
    {
        private readonly ICapsuleRepository capsuleRepository;

        public CapsuleController(ICapsuleRepository capsuleRepository)
        {
            this.capsuleRepository = capsuleRepository;
            
        }

        // GET: api/<CapsuleController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var capsules = await capsuleRepository.GetAllCapsules();
            var capsuleDTO = capsules.Select(x => CapsuleDomainToDTO(x));
            return Ok(capsules);
        }

        // GET api/<CapsuleController>/capsuleStatus/active
        [HttpGet("/capsuleStatus/{capsuleStatus}")]
        public async Task<IActionResult> GetStatus(string capsuleStatus)
        {
            var capsuleResult = await capsuleRepository.GetCapsuleStatus(capsuleStatus);
            if(capsuleResult == null)
            {
                return NotFound($"No capsules are {capsuleStatus}");
            }

            var CapsuleDTO = capsuleResult.Select(x => CapsuleDomainToDTO(x));
            return Ok(CapsuleDTO);
        }

        // POST api/<CapsuleController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CapsuleRequest capsule)
        {
            //DO validation check here on ids passed in
            var CapsuleDomain = new Capsule()
            {
                Serial = capsule.Serial,
                Status = capsule.Status,
                ReuseCount = capsule.ReuseCount,
                WaterLandings = capsule.WaterLandings,
                LandLandings = capsule.LandLandings,
                LaunchId = capsule.LaunchId
            };

            CapsuleDomain = await capsuleRepository.AddAsync(CapsuleDomain);
            var CapsuleDTO = CapsuleDomainToDTO(CapsuleDomain);
            return CreatedAtAction(nameof(Get), new { id = CapsuleDTO.CapsuleId }, CapsuleDTO);
        }

        // PUT api/<CapsuleController>/70
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] CapsuleRequest capsule)
        {
            var capsuleDomain = new Capsule()
            {
                Serial = capsule.Serial,
                Status = capsule.Status,
                ReuseCount = capsule.ReuseCount,
                WaterLandings = capsule.WaterLandings,
                LandLandings = capsule.LandLandings,
                LaunchId =capsule.LaunchId

            };

            capsuleDomain = await capsuleRepository.UpdateAsync(id, capsuleDomain);
            if (capsuleDomain == null)
            {
                return BadRequest("Either the capsule does not exist or data provided does not match scheme");
            }

            var capsuleDTO = CapsuleDomainToDTO(capsuleDomain);
            return Ok(capsuleDTO);

        }

        // DELETE api/<CapsuleController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var capsuleDomain = await capsuleRepository.DeleteAsync(id);
            if (capsuleDomain == null)
            {
                return NotFound($"Capsule with id {id} not found");
            }

            var capsuleDTO = CapsuleDomainToDTO(capsuleDomain);
            return Ok(capsuleDTO);
        }


        #region private methods

        private CapsuleDTO CapsuleDomainToDTO(Capsule capsule)
        {
            var capsuleDTO = new CapsuleDTO()
            {
                CapsuleId = capsule.CapsuleId,
                Serial = capsule.Serial,
                Status = capsule.Status,
                ReuseCount = capsule.ReuseCount,
                WaterLandings = capsule.WaterLandings,
                LandLandings = capsule.LandLandings,
                LaunchId = capsule.LaunchId
            };

            return capsuleDTO;
        }
        #endregion
    }
}
