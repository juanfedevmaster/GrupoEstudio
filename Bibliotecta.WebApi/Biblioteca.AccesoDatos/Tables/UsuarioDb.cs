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
        public UsuarioDb(IDatabaseService bibliotecaRepo)
        {
            connection = bibliotecaRepo.GetSqlConnection();
        }

        public bool CrearUsuario(Usuario usuario)
        {
            using (connection)
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Conexión abierta correctamente.");
                    using (SqlCommand command = new SqlCommand("CreacionUsuario", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@apellido", usuario.Apellido);
                        command.Parameters.AddWithValue("@nombre", usuario.Nombre);
                        command.Parameters.AddWithValue("@celular", usuario.Celular);
                        command.Parameters.AddWithValue("@usuario", usuario.UsuarioValue);
                        command.Parameters.AddWithValue("@password", usuario.Password);

                        int rowsAffected = command.ExecuteNonQuery();

                        return rowsAffected > 0 ? true : false;
                    }
                }
                catch (Exception ex)
                {
                    connection.Close();
                    connection.Dispose();

                    throw new Exception($"Error en la base de datos: {ex.Message} - {ex.InnerException}");
                }
            }
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
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var user = new Usuario()
                                {
                                    Id = Convert.ToInt32(reader["ID"]),
                                    Nombre = reader["Nombre"].ToString(),
                                    Apellido = reader["Apellido"].ToString(),
                                    Celular = reader["Celular"].ToString(),
                                    Password = reader["Password"].ToString(),
                                    UsuarioValue = reader["Usuario"].ToString()
                                };

                                lstUsuarios.Add(user);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    connection.Close();
                    connection.Dispose();

                    throw new Exception($"Error en la base de datos: {ex.Message} - {ex.InnerException}");
                }
            }

            connection.Close();
            connection.Dispose();

            return lstUsuarios;
        }

        public Usuario ObtenerUsuario(string nombreUsuario)
        {
            Usuario usuario = null;
            using (connection)
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Conexión abierta correctamente.");
                    using (SqlCommand command = new SqlCommand("ObtenerUsuario", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                usuario = new Usuario()
                                {
                                    Id = Convert.ToInt32(reader["ID"]),
                                    Nombre = reader["Nombre"].ToString(),
                                    Apellido = reader["Apellido"].ToString(),
                                    Celular = reader["Celular"].ToString(),
                                    Password = reader["Password"].ToString(),
                                    UsuarioValue = reader["Usuario"].ToString()
                                };
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    connection.Close();
                    connection.Dispose();

                    throw new Exception($"Error en la base de datos: {ex.Message} - {ex.InnerException}");
                }
            }

            connection.Close();
            connection.Dispose();

            return usuario;
        }

    }
}
