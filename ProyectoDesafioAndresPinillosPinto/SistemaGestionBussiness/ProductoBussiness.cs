using SistemaGestionData;
using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionBussiness
{
    public class ProductoBussiness
    {
        // Método para obtener un producto por su ID
        public Producto ObtenerProducto(int id)
        {
            return ProductoData.ObtenerProducto(id);
        }

        // Método para listar todos los productos
        public List<Producto> ListarProductos()
        {
            return ProductoData.ListarProductos();
        }

        // Método para crear un nuevo producto
        public void CrearProducto(Producto producto)
        {
            if (producto == null)
            {
                throw new ArgumentNullException("El producto no puede ser nulo.");
            }
            if (string.IsNullOrWhiteSpace(producto.descripcion))
            {
                throw new ArgumentException("La descripción del producto es obligatoria.");
            }
            if (producto.costo <= 0 || producto.precioVenta <= 0)
            {
                throw new ArgumentException("El costo y el precio de venta deben ser mayores que cero.");
            }
            ProductoData.CrearProducto(producto);
        }

        // Método para modificar un producto existente
        public void ModificarProducto(Producto producto)
        {
            if (producto == null)
            {
                throw new ArgumentNullException("El producto no puede ser nulo.");
            }
            if (producto.id <= 0)
            {
                throw new ArgumentException("El ID del producto es inválido.");
            }
            if (string.IsNullOrWhiteSpace(producto.descripcion))
            {
                throw new ArgumentException("La descripción del producto es obligatoria.");
            }
            if (producto.costo <= 0 || producto.precioVenta <= 0)
            {
                throw new ArgumentException("El costo y el precio de venta deben ser mayores que cero.");
            }
            ProductoData.ModificarProducto(producto);
        }

        // Método para eliminar un producto por su ID
        public void EliminarProducto(int id)
        {
            ProductoData.EliminarProducto(id);
        }
    }
}
