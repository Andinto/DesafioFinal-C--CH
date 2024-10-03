using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionData
{
    public class ProductoVendidoData
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;

        public static ProductoVendido ObtenerProductoVendido(int id)
        {
            ProductoVendido productoVendido = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT id, idProducto, stock, idVenta FROM ProductoVendido WHERE id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    productoVendido = new ProductoVendido
                    {
                        id = Convert.ToInt32(reader["id"]),
                        idProducto = Convert.ToInt32(reader["idProducto"]),
                        stock = Convert.ToInt32(reader["stock"]),
                        idVenta = Convert.ToInt32(reader["idVenta"])
                    };
                }
            }
            return productoVendido;
        }

        public static List<ProductoVendido> ListarProductosVendidos()
        {
            List<ProductoVendido> lista = new List<ProductoVendido>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT id, idProducto, stock, idVenta FROM ProductoVendido";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ProductoVendido productoVendido = new ProductoVendido
                    {
                        id = Convert.ToInt32(reader["id"]),
                        idProducto = Convert.ToInt32(reader["idProducto"]),
                        stock = Convert.ToInt32(reader["stock"]),
                        idVenta = Convert.ToInt32(reader["idVenta"])
                    };
                    lista.Add(productoVendido);
                }
            }
            return lista;
        }

        public static void CrearProductoVendido(ProductoVendido productoVendido)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO ProductosVendidos (idProducto, stock, idVenta) VALUES (@idProducto, @stock, @idVenta)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idProducto", productoVendido.idProducto);
                command.Parameters.AddWithValue("@stock", productoVendido.stock);
                command.Parameters.AddWithValue("@idVenta", productoVendido.idVenta);
                command.ExecuteNonQuery();
            }
        }

        public static void ModificarProductoVendido(ProductoVendido productoVendido)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE ProductosVendidos SET idProducto = @idProducto, stock = @stock, idVenta = @idVenta WHERE id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", productoVendido.id);
                command.Parameters.AddWithValue("@idProducto", productoVendido.idProducto);
                command.Parameters.AddWithValue("@stock", productoVendido.stock);
                command.Parameters.AddWithValue("@idVenta", productoVendido.idVenta);
                command.ExecuteNonQuery();
            }
        }

        public static void EliminarProductoVendido(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM ProductosVendidos WHERE id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }
    }
}
