using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using SistemaGestionEntities;
using System.Threading.Tasks;

namespace SistemaGestionData
{
    public class VentaData
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;

        public static Venta ObtenerVenta(int id)
        {
            Venta venta = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT id, comentarios, idUsuario FROM Usuarios WHERE id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    venta = new Venta
                    {
                        id = Convert.ToInt32(reader["id"]),
                        comentarios = reader["comentarios"].ToString(),
                        idUsuario = Convert.ToInt32(reader["idUsuario"])
                    };
                }
            }
            return venta;
        }

        public static List<Venta> ListarVentas()
        {
            List<Venta> lista = new List<Venta>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT id, comentarios, idUsuario FROM Venta";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Venta venta = new Venta
                    {
                        id = Convert.ToInt32(reader["id"]),
                        comentarios = reader["comentarios"].ToString(),
                        idUsuario = Convert.ToInt32(reader["idUsuario"])
                    };
                    lista.Add(venta);
                }
            }
            return lista;
        }

        public static void CrearVenta(Venta venta)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Ventas (comentarios, idUsuario) VALUES (@comentarios, @idUsuario)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@comentarios", venta.comentarios);
                command.Parameters.AddWithValue("@idUsuario", venta.idUsuario);
                command.ExecuteNonQuery();
            }
        }

        public static void ModificarVenta(Venta venta)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Ventas SET comentarios = @comentarios, idUsuario = @idUsuario WHERE id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", venta.id);
                command.Parameters.AddWithValue("@comentarios", venta.comentarios);
                command.Parameters.AddWithValue("@idUsuario", venta.idUsuario);
                command.ExecuteNonQuery();
            }
        }

        public static void EliminarVenta(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Ventas WHERE id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }
    }
}
