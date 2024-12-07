using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Entidades.Modelos
{
    public class Persona
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Int64 Id { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime? FechaDefuncion { get; set; }
        public string Celular { get; set; }

    }
}
