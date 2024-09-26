using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using ProyectoDesafioAndresPinillosPinto.Entidades;

namespace ProyectoDesafioAndresPinillosPinto.BaseDatos
{
    public class ProductoData
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;

        public static Producto ObtenerProducto(int id)
        {
            Producto producto = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT id, descripcion, costo, precioVenta, stock, idUsuario FROM Usuarios WHERE id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    producto = new Producto
                    {
                        id = Convert.ToInt32(reader["id"]),
                        descripcion = reader["descripcion"].ToString(),
                        costo = Convert.ToDecimal(reader["costo"]),
                        precioVenta = Convert.ToDecimal(reader["precioVenta"]),
                        stock = Convert.ToInt32(reader["stock"]),
                        idUsuario = Convert.ToInt32(reader["idUsuario"])
                    };
                }
            }
            return producto;
        }

        public static List<Producto> ListarProductos()
        {
            List<Producto> lista = new List<Producto>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT id, descripcion, costo, precioVenta, stock, idUsuario FROM Producto";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Producto producto = new Producto
                    {
                        id = Convert.ToInt32(reader["id"]),
                        descripcion = reader["descripcion"].ToString(),
                        costo = Convert.ToDecimal(reader["costo"]),
                        precioVenta = Convert.ToDecimal(reader["precioVenta"]),
                        stock = Convert.ToInt32(reader["stock"]),
                        idUsuario = Convert.ToInt32(reader["idUsuario"])
                    };
                    lista.Add(producto);
                }
            }
            return lista;
        }

        public static void CrearProducto(Producto producto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Productos (descripcion, costo, precioVenta, stock, idUsuario) VALUES (@descripcion, @costo, @precioVenta, @stock, @idUsuario)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@descripcion", producto.descripcion);
                command.Parameters.AddWithValue("@costo", producto.costo);
                command.Parameters.AddWithValue("@precioVenta", producto.precioVenta);
                command.Parameters.AddWithValue("@stock", producto.stock);
                command.Parameters.AddWithValue("@idUsuario", producto.idUsuario);
                command.ExecuteNonQuery();
            }
        }

        public static void ModificarProducto(Producto producto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Productos SET descripcion = @descripcion, costo = @costo, precioVenta = @precioVenta, stock = @stock, idUsuario = @idUsuario WHERE id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", producto.id);
                command.Parameters.AddWithValue("@descripcion", producto.descripcion);
                command.Parameters.AddWithValue("@costo", producto.costo);
                command.Parameters.AddWithValue("@precioVenta", producto.precioVenta);
                command.Parameters.AddWithValue("@stock", producto.stock);
                command.Parameters.AddWithValue("@idUsuario", producto.idUsuario);
                command.ExecuteNonQuery();
            }
        }

        public static void EliminarProducto(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Productos WHERE id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }
    }
}
