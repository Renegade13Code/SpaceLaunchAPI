using Microsoft.AspNetCore.Mvc;
using SpaceLaunchAPI.Models.Domain;
using SpaceLaunchAPI.Models.DTO;
using SpaceLaunchAPI.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace SpaceLaunchAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayloadController : ControllerBase
    {
        private readonly IPayloadRepository payloadRepo;
        public PayloadController(IPayloadRepository payloadRepo)
        {
            this.payloadRepo = payloadRepo;
        }
        // GET: api/<PayloadController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var payloads = await payloadRepo.GetAllAsync();
            return Ok(payloads);
        }

        // GET api/<PayloadController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var foundPayload = await payloadRepo.GetByIdAsync(id);
            if(foundPayload == null)
            {
                return Ok("Not found");
            }

            return Ok(foundPayload);
        }

        // POST api/<PayloadController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PayloadRequest payloadRequest)
        {
            var payloadDomain = new Payload()
            {
                Name = payloadRequest.Name,
                Type = payloadRequest.Type,
                Reused = payloadRequest.Reused,
                Manufacturers = payloadRequest.Manufacturers,
                MassKg = payloadRequest.MassKg,
                MassLb = payloadRequest.MassLb,
                Orbit = payloadRequest.Orbit,
                ReferenceSystem = payloadRequest.ReferenceSystem,
                Regime = payloadRequest.Regime,
                LaunchId = payloadRequest.LaunchId,
            };
            var newPy = await payloadRepo.AddAsync(payloadDomain);
            return Ok(newPy);
        }

        // PUT api/<PayloadController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] PayloadRequest payloadRequest)
        {
            var newPy = new Payload()
            {
                Name=payloadRequest.Name,
                Type=payloadRequest.Type,
                Reused=payloadRequest.Reused,
                Manufacturers=payloadRequest.Manufacturers,
                MassKg=payloadRequest.MassKg,
                MassLb=payloadRequest.MassLb,
                Orbit=payloadRequest.Orbit,
                ReferenceSystem=payloadRequest.ReferenceSystem,
                Regime=payloadRequest.Regime,
                LaunchId=payloadRequest.LaunchId
            };

            newPy = await payloadRepo.UpdateAsync(id, newPy);
            if (newPy == null)
            {
                return Ok("Not found");
            }
            return Ok(newPy);
        }

        // DELETE api/<PayloadController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(String id)
        {
            var foundPy = await payloadRepo.DeleteAsync(id);
            if (foundPy == null)
            {
                return Ok("Not found");
            }
            return Ok(foundPy);
        }

        #region private methods

        //private PayloadDTO PayloadToDTOConverter(Payload payload)
        //{
        //    var payloadDTO = new PayloadDTO()
        //    {
        //        PayloadId = payload.PayloadId,
        //        Name = payload.Name,
        //        Type = payload.Type,
        //        Reused = payload.Reused,
        //        Manufacturers = payload.Manufacturers,
        //        MassKg = payload.MassKg,
        //        MassLb = payload.MassLb,
        //        Orbit = payload.Orbit,
        //        ReferenceSystem = payload.ReferenceSystem,
        //        Regime = payload.Regime,
        //        LaunchId = payload.LaunchId,
        //    };

        //    return payloadDTO;
        //}

        #endregion
    }
}
