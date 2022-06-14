using Microsoft.AspNetCore.Mvc;
using SpaceLaunchAPI.Models.Domain;
using SpaceLaunchAPI.Models.DTO;
using SpaceLaunchAPI.Repository;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace SpaceLaunchAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AstronautController : ControllerBase
    {
        private readonly IAstronautRepository astronautRepo;
        public AstronautController(IAstronautRepository astronautRepo)
        {
            this.astronautRepo = astronautRepo;
            //this.url = "http://api.open-notify.org/astros.json";
        }
        // GET: api/<PayloadController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var request = WebRequest.Create("http://api.open-notify.org/astros.json");
            request.Method = "Get";
            using var webResponse = request.GetResponse();
            using var webStream = webResponse.GetResponseStream();

            using var reader = new StreamReader(webStream);
            var data = reader.ReadToEnd();
            //var astronauts = await astronautRepo.GetAllAsync();
            Console.WriteLine(data);
            return Ok(data);
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