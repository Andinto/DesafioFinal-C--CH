using SistemaGestionData;
using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionBussiness
{
    public class ProductoVendidosBussiness
    {
        // Método para obtener un producto vendido por su ID
        public ProductoVendido ObtenerProductoVendido(int id)
        {
            return ProductoVendidoData.ObtenerProductoVendido(id);
        }

        // Método para listar todos los productos vendidos
        public List<ProductoVendido> ListarProductosVendidos()
        {
            return ProductoVendidoData.ListarProductosVendidos();
        }

        // Método para crear un nuevo producto vendido
        public void CrearProductoVendido(ProductoVendido productoVendido)
        {
            if (productoVendido == null)
            {
                throw new ArgumentNullException("El producto vendido no puede ser nulo.");
            }
            if (productoVendido.stock <= 0)
            {
                throw new ArgumentException("El stock debe ser mayor que cero.");
            }
            ProductoVendidoData.CrearProductoVendido(productoVendido);
        }

        // Método para modificar un producto vendido existente
        public void ModificarProductoVendido(ProductoVendido productoVendido)
        {
            if (productoVendido == null)
            {
                throw new ArgumentNullException("El producto vendido no puede ser nulo.");
            }
            if (productoVendido.stock <= 0)
            {
                throw new ArgumentException("El stock debe ser mayor que cero.");
            }
            ProductoVendidoData.ModificarProductoVendido(productoVendido);
        }

        // Método para eliminar un producto vendido por su ID
        public void EliminarProductoVendido(int id)
        {
            ProductoVendidoData.EliminarProductoVendido(id);
        }
    }
}
