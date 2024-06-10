using Microsoft.AspNetCore.Mvc;
using ruleta_api.Context;
using ruleta_api.Services;
using apiScProsoft.Models;
using ruleta_api.Models;

namespace ruleta_api.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuario _usuarioServices;

        public UsuariosController(IUsuario usuarioServices)
        {
            _usuarioServices = usuarioServices;
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Usuarios>>> SaveUsuario([FromBody] Usuarios usuarios)
        {
            return await _usuarioServices.SaveUsuario(usuarios);
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<Usuarios>>> GetUsuario([FromQuery] string nombre)
        {
            return await _usuarioServices.GetUsuario(nombre);
        }
    }
}
