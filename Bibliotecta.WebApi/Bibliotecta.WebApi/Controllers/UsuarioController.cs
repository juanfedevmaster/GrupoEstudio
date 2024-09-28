using Biblioteca.Entidades.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bibliotecta.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        [HttpPost]
        [Route("api/CrearUser")]
        // POST: Usuario/create
        public IActionResult Crear([FromBody] Usuario usuario)
        {
            return Ok();
        }

        [HttpPost]
        [Route("api/ActualizarPersona")]
        // POST: Usuario/update
        public IActionResult Actualizar([FromBody] Persona usuario)
        {
            return Ok();
        }
    }
}
