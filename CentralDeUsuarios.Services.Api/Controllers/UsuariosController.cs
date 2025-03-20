using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace CentralDeUsuarios.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] Usuario usuario)
        {
            if (usuario == null)
                return BadRequest("Usuário inválido");
            if (usuario.Nome == "admin")
                return StatusCode(StatusCodes.Status403Forbidden, "Usuário não autorizado");
            return Ok(usuario);
        }
    }
}
