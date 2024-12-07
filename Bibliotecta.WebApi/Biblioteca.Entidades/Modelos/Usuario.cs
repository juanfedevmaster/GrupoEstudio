using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Entidades.Modelos
{
    public class Usuario : Persona 
    {
        public string? CorreoElectronico { get; set; }
        public string? Password { get; set; }
        public int IdRol { get; set; }
    }
}
