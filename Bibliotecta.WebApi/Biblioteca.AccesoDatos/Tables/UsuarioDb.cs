using Biblioteca.AccesoDatos.Interfaces;
using Biblioteca.Entidades.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.AccesoDatos.Tables
{
    public class UsuarioDb
    {
        private SqlConnection connection;
        public UsuarioDb(IDatabaseService bibliotecaRepo) {
            connection = bibliotecaRepo.GetSqlConnection();
        }

        public List<Usuario> ObtenerUsuarios()
        {
            List<Usuario> lstUsuarios = new List<Usuario>();
            using (connection)
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Conexión abierta correctamente.");
                    using (SqlCommand command = new SqlCommand("ObtenerUsuarios", connection))
                    {
                        command.CommandType =System.Data.CommandType.StoredProcedure;
                        using (SqlDataReader reader = command.ExecuteReader()) {
                            while (reader.Read()) {
                                var user = new Usuario()
                                {
                                    Id = Convert.ToInt32(reader["ID"]),
                                    Nombre = reader["Nombre"].ToString(),
                                    Apellido = reader["Apellido"].ToString(),
                                    Celular = Convert.ToDouble(reader["Celular"].ToString()),
                                    Password = reader["Password"].ToString(),
                                    UsuarioValue = reader["Usuario"].ToString()
                                };

                                lstUsuarios.Add(user);
                            }
                        }
                    }
                }
                catch (Exception ex) {
                    connection.Close();
                    connection.Dispose();

                    throw new Exception($"Error en la base de datos: {ex.Message} - {ex.InnerException}");
                }
            }

            connection.Close();
            connection.Dispose();

            return lstUsuarios;
        }

    }
}
