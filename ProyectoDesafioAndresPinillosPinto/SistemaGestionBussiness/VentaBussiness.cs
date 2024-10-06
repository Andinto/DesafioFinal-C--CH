using SistemaGestionData;
using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionBussiness
{
    public class VentaBusiness
    {
        // Método para obtener una venta por su ID
        public Venta ObtenerVenta(int id)
        {
            return VentaData.ObtenerVenta(id);
        }

        // Método para listar todas las ventas
        public List<Venta> ListarVentas()
        {
            return VentaData.ListarVentas();
        }

        // Método para crear una nueva venta
        public void CrearVenta(Venta venta)
        {
            if (venta == null)
            {
                throw new ArgumentNullException("La venta no puede ser nula.");
            }
            if (string.IsNullOrWhiteSpace(venta.comentarios))
            {
                throw new ArgumentException("Los comentarios de la venta son obligatorios.");
            }
            
            VentaData.CrearVenta(venta);
        }

        // Método para modificar una venta existente
        public void ModificarVenta(Venta venta)
        {
            if (venta == null)
            {
                throw new ArgumentNullException("La venta no puede ser nula.");
            }
            if (string.IsNullOrWhiteSpace(venta.comentarios))
            {
                throw new ArgumentException("Los comentarios de la venta son obligatorios.");
            }
           
            VentaData.ModificarVenta(venta);
        }

        // Método para eliminar una venta por su ID
        public void EliminarVenta(int id)
        {
            VentaData.EliminarVenta(id);
        }
    }

}
