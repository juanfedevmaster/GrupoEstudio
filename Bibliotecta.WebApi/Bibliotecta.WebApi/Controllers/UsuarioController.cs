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

        [HttpPut]
        [Route("api/ActualizarPersona")]
        // POST: Usuario/update
        public IActionResult Actualizar([FromBody] Persona usuario)
        {
            return Ok();
        }

        [HttpPut]
        [Route("api/ActualizarPassword")]
        // POST: Usuario/update
        public IActionResult ActualizarPassword([FromBody] Usuario usuario)
        {
            return Ok();
        }

        [HttpDelete]
        [Route("api/EliminarUsuario")]
        // POST: Usuario/update
        public IActionResult EliminarUsuario(string idUsuario)
        {
            return Ok();
        }

        [HttpGet]
        [Route("api/OptenerInformacionUsuario")]
        // POST: Usuario/update
        public IActionResult OptenerInformacionUsuario(string idUsuario)
        {
            return Ok();
        }
    }
}
