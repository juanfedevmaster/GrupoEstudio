using Biblioteca.AccesoDatos.Interfaces;
using System.Data.SqlClient;

namespace Biblioteca.AccesoDatos
{
    public class BibliotecaRepo : IDatabaseService, IDisposable
    {
        private const string connection = "Server=JUANFE;Database=Biblioteca;User Id=sa;Password=admin;TrustServerCertificate=True;";
        private SqlConnection sqlConnection;
        public BibliotecaRepo() { }

        public void Dispose()
        {
            this.sqlConnection?.Dispose();
        }

        public SqlConnection GetSqlConnection()
        {
            this.sqlConnection = new SqlConnection(connection);
            return sqlConnection;
        }
    }
}
