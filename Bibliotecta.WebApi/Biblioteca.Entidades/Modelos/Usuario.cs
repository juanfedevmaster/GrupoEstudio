using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Entidades.Modelos
{
    public class Usuario : Persona 
    {
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
    }
}
