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
    public class LaunchController : ControllerBase
    {
        private readonly ILaunchRepository launchRepo;

        private readonly IBuilderLaunches _builderLaunch;

        public LaunchController(ILaunchRepository launchRepo, IBuilderLaunches builderLaunches)
        {
            this.launchRepo = launchRepo;
            this._builderLaunch = builderLaunches;
        }
        // GET: api/<LaaunchController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var LaunchesDomain = await launchRepo.GetAllAsync();
            var LaunchesDTO = LaunchesDomain.Select(x => LaunchDomainToDTO(x));
            return Ok(LaunchesDTO);
        }

        // GET api/<LaaunchController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var launchDomain = await launchRepo.GetByIdAsync(id);
            if(launchDomain == null)
            {
                return NotFound($"Launch with id {id} not found");
            }

            var LaunchDTO = LaunchDomainToDTO(launchDomain);
            return Ok(LaunchDTO);
        }

        // POST api/<LaaunchController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LaunchRequest addLaunchRequest)
        {
            //DO validation check here on ids passed in
            var LaunchDomain = CreateLaunch(addLaunchRequest);

            LaunchDomain = await launchRepo.AddAsync(LaunchDomain);
            var LaunchDTO = LaunchDomainToDTO(LaunchDomain);
            return CreatedAtAction(nameof(Get), new {id = LaunchDTO.LaunchId}, LaunchDTO);
        }

        // PUT api/<LaaunchController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] LaunchRequest updateLaunchRequest)
        {
            var launchDomian = new Launch()
            {
                Name = updateLaunchRequest.Name,
                Date = updateLaunchRequest.Date,
                RocketId = updateLaunchRequest.RocketId,
                LaunchpadId = updateLaunchRequest.LaunchpadId,
                Success = updateLaunchRequest.Success,
                Failures = updateLaunchRequest.Failures
            };

            launchDomian = await launchRepo.UpdateAsync(id, launchDomian);
            if(launchDomian == null)
            {
                return BadRequest("Either the Launch does not exist or data provided does not match scheme");
            }

            var launchDTO = LaunchDomainToDTO(launchDomian);
            return Ok(launchDTO);

        }

        // DELETE api/<LaaunchController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var launchDomain = await launchRepo.DeleteAsync(id);
            if (launchDomain == null)
            {
                return NotFound($"Launch with id {id} not found");
            }

            var LaunchDTO = LaunchDomainToDTO(launchDomain);
            return Ok(LaunchDTO);
        }

        #region private methods
        private LaunchDTO LaunchDomainToDTO(Launch launch)
        {
            var launchDTO = new LaunchDTO()
            {
                LaunchId = launch.LaunchId,
                Name = launch.Name,
                Date = launch.Date,
                RocketId = launch.RocketId,
                LaunchpadId = launch.LaunchpadId,
                Success = launch.Success,
                Failures = launch.Failures,
            };

            if(launch.RocketModel != null)
            {
                launchDTO.RocketType = launch.RocketModel.Name;

            }

            if(launch.LaunchPadModel != null)
            {
                launchDTO.LaunchPad = launch.LaunchPadModel.FullName;
            }
            
            if(launch.Payloads != null)
            {
                launchDTO.Payloads = launch.Payloads
                    .Select(x => PayloadDomainToDTO(x))
                    .ToList();
            }

            if(launch.Capsules != null)
            {
                launchDTO.Capsules = launch.Capsules
                    .Select(x => CapsuleDomainToDTO(x))
                    .ToList();
            }
            
            return launchDTO;
        }

        private Launch CreateLaunch(LaunchRequest addLaunchRequest)
        {
            _builderLaunch.setLaunchName(addLaunchRequest.Name);
            _builderLaunch.setLaunchDate(addLaunchRequest.Date);
            _builderLaunch.setRocketId(addLaunchRequest.RocketId);
            _builderLaunch.setLaunchPadId(addLaunchRequest.LaunchpadId);
            _builderLaunch.setSuccess(addLaunchRequest.Success);
            _builderLaunch.setFailure(addLaunchRequest.Failures);

            Console.WriteLine("checki here mate", _builderLaunch.getLaunch());

            return _builderLaunch.getLaunch();
        }

        private string PayloadDomainToDTO(Payload payload)
        {
            //var payloadDTO = new PayloadDTO()
            //{
            //    PayloadId = payload.PayloadId,
            //    Name = payload.Name,
            //    Type = payload.Type,
            //    Reused = payload.Reused,
            //    Manufacturers = payload.Manufacturers,
            //    MassKg = payload.MassKg,
            //    MassLb = payload.MassLb,
            //    Orbit = payload.Orbit,
            //    ReferenceSystem = payload.ReferenceSystem,
            //    Regime = payload.Regime,
            //    LaunchId = payload.LaunchId
            //};

            var payloadDTO = $"{{PayloadId:{payload.PayloadId}, Name: {payload.Name}}}";

            return payloadDTO;
        }

        private string CapsuleDomainToDTO(Capsule capsule)
        {
            //var capsuleDTO = new CapsuleDTO()
            //{
            //    CapsuleId = capsule.CapsuleId,
            //    Serial = capsule.Serial,
            //    Status = capsule.Status,
            //    ReuseCount = capsule.ReuseCount,
            //    WaterLandings = capsule.WaterLandings,
            //    LandLandings = capsule.LandLandings,
            //    LaunchId = capsule.LaunchId
            //};

            var capsuleDTO = $"{{CapsuleId:{capsule.CapsuleId}, Name: {capsule.Serial}}}";

            return capsuleDTO;
        }
        #endregion
    }
}
