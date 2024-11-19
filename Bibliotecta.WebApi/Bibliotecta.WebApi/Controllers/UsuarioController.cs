using Biblioteca.AccesoDatos.Interfaces;
using Biblioteca.AccesoDatos.Tables;
using Biblioteca.Entidades.Infraestructura.Options;
using Biblioteca.Entidades.Modelos;
using Bibliotecta.Negocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

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
        [Route("api/CrearUsuario")]
        // POST: Usuario/create
        public IActionResult Crear([FromBody] Usuario usuario)
        {
            var usuarioServicio = new UsuarioServicio(_bibliotecaRepo);
            usuarioServicio.CrearServicio(usuario);
            return Ok(usuarioServicio);
        }

        [HttpPut]
        [Route("api/ActualizarUsuario")]
        // POST: Usuario/update
        public IActionResult Actualizar([FromBody] Usuario usuario)
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
        public IActionResult ObtenerInformacionUsuario(string nombreUsuario)
        {
            try
            {
                UsuarioDb usuarioDb = new UsuarioDb(_bibliotecaRepo);
                var usuario = usuarioDb.ObtenerUsuario(nombreUsuario);
                return Ok(new { mensaje = "El usuario se creo de forma correcta " });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = ex.Message });
            }
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
