using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelo.Interfaces;

namespace EjemploInyeccionDependencias.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly IProducto _producto;
        
        public ProductosController(IProducto producto)
        {
            _producto = producto;
            _producto.ObtenerDescuentoProducto();
        }

        [HttpGet]
        [Route("ObtenerProductos")]
        public IActionResult Get()
        {
            return Ok(_producto);
        }
    }
}
