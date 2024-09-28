using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Entidades.Modelos
{
    public class Persona
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Id { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public bool SexoNacimiento { get; set; }
        public DateTime? FechaDefuncion { get; set; }

    }
}
