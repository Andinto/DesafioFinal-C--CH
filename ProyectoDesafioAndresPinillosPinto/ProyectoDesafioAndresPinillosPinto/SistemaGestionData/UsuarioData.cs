using ProyectoDesafioAndresPinillosPinto.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace ProyectoDesafioAndresPinillosPinto.BaseDatos
{
    public class UsuarioData
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;

        public static Usuario ObtenerUsuario(int id)
        {
            Usuario usuario = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT id, nombre, apellido, nombreUsuario, contraseña, mail FROM Usuarios WHERE id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    usuario = new Usuario
                    {
                        id = Convert.ToInt32(reader["id"]),
                        nombre = reader["nombre"].ToString(),
                        apellido = reader["apellido"].ToString(),
                        nombreUsuario = reader["nombreUsuario"].ToString(),
                        contraseña = reader["contraseña"].ToString(),
                        mail = reader["mail"].ToString()
                    };
                }
            }
            return usuario;
        }

        public static List<Usuario> ListarUsuarios()
        {
            List<Usuario> lista = new List<Usuario>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT id, nombre, apellido, nombreUsuario, contraseña, mail FROM Usuarios";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Usuario usuario = new Usuario
                    {
                        id = Convert.ToInt32(reader["id"]),
                        nombre = reader["nombre"].ToString(),
                        apellido = reader["apellido"].ToString(),
                        nombreUsuario = reader["nombreUsuario"].ToString(),
                        contraseña = reader["contraseña"].ToString(),
                        mail = reader["mail"].ToString()
                    };
                    lista.Add(usuario);
                }
            }
            return lista;
        }

        public static void CrearUsuario(Usuario usuario)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Usuarios (nombre, apellido, nombreUsuario, contraseña, mail) VALUES (@nombre, @apellido, @nombreUsuario, @contraseña, @mail)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nombre", usuario.nombre);
                command.Parameters.AddWithValue("@Apellido", usuario.apellido);
                command.Parameters.AddWithValue("@NombreUsuario", usuario.nombreUsuario);
                command.Parameters.AddWithValue("@Contraseña", usuario.contraseña);
                command.Parameters.AddWithValue("@Mail", usuario.mail);
                command.ExecuteNonQuery();
            }
        }

        public static void ModificarUsuario(Usuario usuario)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Usuarios SET nombre = @nombre, apellido = @apellido, nombreUsuario = @nombreUsuario, contraseña = @contraseña, mail = @mail WHERE id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", (usuario.id));
                command.Parameters.AddWithValue("@nombre", usuario.nombre);
                command.Parameters.AddWithValue("@apellido", usuario.apellido);
                command.Parameters.AddWithValue("@nombreUsuario", usuario.nombreUsuario);
                command.Parameters.AddWithValue("@contraseña", usuario.contraseña);
                command.Parameters.AddWithValue("@mail", usuario.mail);
                command.ExecuteNonQuery();
            }
        }

        public static void EliminarUsuario(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Usuarios WHERE id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }
    }
}
