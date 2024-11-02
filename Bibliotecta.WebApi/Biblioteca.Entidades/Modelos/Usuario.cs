using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Entidades.Modelos
{
    public class Usuario : Persona 
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public double? Celular { get; set; }
        public string? UsuarioValue { get; set; }
        public string? Password { get; set; }
    }
}
