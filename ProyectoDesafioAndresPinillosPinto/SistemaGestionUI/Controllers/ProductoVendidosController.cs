using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussiness;
using SistemaGestionEntities;

namespace SistemaGestionUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoVendidos : ControllerBase
    {
        private readonly ProductoBusiness _productoBusiness;

        public ProductoVendidos()
        {
            _productoBusiness = new ProductoBusiness();
        }

        // GET: api/Producto
        [HttpGet]
        public ActionResult<List<Producto>> GetProducto()
        {
            try
            {
                var producto = _productoBusiness.ListarProductoVendidos();
                return Ok(productoVendidos);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/ProductoVendidos/{id}
        [HttpGet("{id}")]
        public ActionResult<Producto> GetProducto(int id)
        {
            try
            {
                var producto = _ProductoBusiness.ObtenerProducto(id);
                if (producto == null)
                {
                    return NotFound($"ProductoVendidos con ID {id} no encontrado.");
                }
                return Ok(producto);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/Producto
        [HttpPost]
        public ActionResult CreateProducto([FromBody] Producto producto)
        {
            try
            {
                _productoBusiness.CrearProducto(producto);
                return Ok("Usuario creado exitosamente.");
            }
            catch (System.ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: api/producto/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateProducto(int id, [FromBody] Producto producto)
        {
            try
            {
                var productoExistente = _productoBusiness.ObtenerProductoVendidos(id);
                if (productoExistente == null)
                {
                    return NotFound($"producto con ID {id} no encontrado.");
                }

                // Asegurarse de que el ID del usuario a actualizar coincida con el de la solicitud
                producto.id = id;
                _ProductoVendidosBusiness.ModificarProducto(producto);
                return Ok("ProductoVendidos actualizado exitosamente.");
            }
            catch (System.ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: api/Usuario/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteUsuario(int id)
        {
            try
            {
                var usuarioExistente = _usuarioBusiness.ObtenerUsuario(id);
                if (usuarioExistente == null)
                {
                    return NotFound($"Usuario con ID {id} no encontrado.");
                }

                _usuarioBusiness.EliminarUsuario(id);
                return Ok("Usuario eliminado exitosamente.");
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}