using Biblioteca.AccesoDatos.Interfaces;
using Biblioteca.Entidades.Modelos;
using System.Data.SqlClient;

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
                    using (SqlCommand command = new SqlCommand("CrearUsuario", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        // Ejemplo de Parametros en ADO.NET
                        //command.Parameters.Add(new SqlParameter("@identificacion",System.Data.SqlDbType.Int).Value = usuario.Nombre);
                        //command.Parameters.Add(new SqlParameter("@nombre", System.Data.SqlDbType.NVarChar,50).Value = usuario.Nombre);

                        command.Parameters.AddWithValue("@identificacion", usuario.Id);
                        command.Parameters.AddWithValue("@nombre", usuario.Nombre);
                        command.Parameters.AddWithValue("@apellido", usuario.Apellido);
                        command.Parameters.AddWithValue("@celular", usuario.Celular);
                        command.Parameters.AddWithValue("@fechaNacimiento", usuario.FechaNacimiento);
                        command.Parameters.AddWithValue("@fechaDefuncion", usuario.FechaDefuncion);
                        command.Parameters.AddWithValue("@correoElectronico", usuario.CorreoElectronico);
                        command.Parameters.AddWithValue("@password", usuario.Password);
                        command.Parameters.AddWithValue("@IdRol", usuario.IdRol);

                        var rowsAffected = command.ExecuteNonQuery();

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
                                    CorreoElectronico = reader["Usuario"].ToString()
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

                        command.Parameters.AddWithValue("@correoElectronico", nombreUsuario);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                usuario = new Usuario()
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    CorreoElectronico = reader["CorreoElectronico"].ToString(),
                                    Password = reader["Password"].ToString(),
                                    Celular = reader["Celular"].ToString(),
                                    IdRol = Convert.ToInt32(reader["IdRol"].ToString())
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

            return usuario;
        }

    }
}
