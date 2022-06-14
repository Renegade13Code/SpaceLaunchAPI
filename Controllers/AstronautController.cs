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
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var request = WebRequest.Create("http://api.open-notify.org/astros.json");
            request.Method = "Get";
            using var webResponse = request.GetResponse();
            using var webStream = webResponse.GetResponseStream();
            using var reader = new StreamReader(webStream);
            var data = reader.ReadToEnd();
            return Ok(data);
        }
        #region private methods

        #endregion
    }
}