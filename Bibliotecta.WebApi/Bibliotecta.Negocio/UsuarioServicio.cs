using Biblioteca.AccesoDatos.Interfaces;
using Biblioteca.AccesoDatos.Tables;
using Biblioteca.Entidades.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotecta.Negocio
{
    public class UsuarioServicio
    {

        private IDatabaseService _bibliotecaRepo;

        public UsuarioServicio(IDatabaseService databaseService) {
            _bibliotecaRepo = databaseService;
        }

        public bool CrearServicio(Usuario usuario) {
            UsuarioDb usuarioDb = new UsuarioDb(_bibliotecaRepo);

            if (usuarioDb.ObtenerUsuario(usuario.UsuarioValue) != null) {
                throw new Exception($"El usuario ya existe");
            }
            
            var exito = usuarioDb.CrearUsuario(usuario);
            return exito;
        }
    }
}
