using Biblioteca.AccesoDatos.Interfaces;
using Biblioteca.Entidades.Infraestructura.Options;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;

namespace Biblioteca.AccesoDatos
{
    public class BibliotecaRepo : IDatabaseService, IDisposable
    {
        //private const string connection = "Server=JUANFE;Database=Biblioteca;User Id=sa;Password=admin;TrustServerCertificate=True;";
        
        private SqlConnection sqlConnection;

        private readonly string _connectionString;

        public BibliotecaRepo(IOptions<DatabaseOptions> options) {
            _connectionString = options.Value.ConnectionString;
        }        

        public void Dispose()
        {
            this.sqlConnection?.Dispose();
        }

        public SqlConnection GetSqlConnection()
        {
            this.sqlConnection = new SqlConnection(_connectionString);
            return sqlConnection;
        }
    }
}
