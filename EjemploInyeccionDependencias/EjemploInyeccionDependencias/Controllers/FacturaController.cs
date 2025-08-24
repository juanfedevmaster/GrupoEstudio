using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelo.Interfaces;

namespace EjemploInyeccionDependencias.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        public FacturaController(IProducto producto)
        {
        }
    }
}
