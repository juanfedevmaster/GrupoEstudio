using Biblioteca.AccesoDatos.Interfaces;
using Biblioteca.AccesoDatos.Tables;
using Biblioteca.Entidades.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bibliotecta.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        IDatabaseService _bibliotecaRepo;

        public UsuarioController(IDatabaseService bibliotecaRepo)
        {
            _bibliotecaRepo = bibliotecaRepo;
        }

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
        [Route("api/ObtenerInformacionUsuario")]
        // POST: Usuario/update
        public IActionResult ObtenerInformacionUsuario(string idUsuario)
        {
            return Ok();
        }

        [HttpGet]
        [Route("api/ObtenerInformacionDeTodosLosUsuario")]
        // POST: Usuario/update
        public IActionResult ObtenerInformacionUsuarios()
        {
            try
            {
                UsuarioDb usuarioDb = new UsuarioDb(_bibliotecaRepo);
                var lstUsuarios = usuarioDb.ObtenerUsuarios();
                return Ok(lstUsuarios);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
