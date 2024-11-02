using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.AccesoDatos
{
    public class BibliotecaRepo
    {
        private const string connection = "Server=JUANFE;Database=Biblioteca;User Id=sa;Password=admin;TrustServerCertificate=True;";
        
        public BibliotecaRepo() { }

        public SqlConnection GetSqlConnection() { 
            return new SqlConnection(connection);
        }
    }
}
