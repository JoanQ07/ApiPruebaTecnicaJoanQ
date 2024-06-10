using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ruleta_api.Context;
using ruleta_api.Models;
using ruleta_api.Services;
using apiScProsoft.Models;
using ruleta_api.Dtos;

namespace ruleta_api.Controllers
{
    [Route("api/resultado")]
    [ApiController]
    public class ResultadoController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IResultado _resultadoServices;

        public ResultadoController(DataContext context, IResultado resultadoServices)
        {
            _resultadoServices = resultadoServices;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<Resultado>>> GetResultado()
        {
            return Ok(await _resultadoServices.GetResultado());
        }
    }
}
