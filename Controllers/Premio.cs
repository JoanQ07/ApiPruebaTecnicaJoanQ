using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ruleta_api.Context;
using ruleta_api.Models;
using ruleta_api.Services;
using apiScProsoft.Models;
using ruleta_api.Dtos;

namespace ruleta_api.Controllers
{
    [Route("api/premio")]
    [ApiController]
    public class PremioController : ControllerBase
    {
        private readonly IPreemio _premioServices;

        public PremioController(IPreemio premioServices)
        {
            _premioServices = premioServices;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<long>>> GetResultado([FromQuery] string tipoApuesta, [FromQuery] long montoApostar)
        {
            return Ok(await _premioServices.GetPremio(tipoApuesta, montoApostar));
        }
    }
}
