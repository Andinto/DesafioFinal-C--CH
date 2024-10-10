using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussiness;
using SistemaGestionEntities;

namespace SistemaGestionUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioBusiness _usuarioBusiness;

        public UsuarioController()
        {
            _usuarioBusiness = new UsuarioBusiness();
        }

        // GET: api/Usuario
        [HttpGet]
        public ActionResult<List<Usuario>> GetUsuarios()
        {
            try
            {
                var usuarios = _usuarioBusiness.ListarUsuarios();
                return Ok(usuarios);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/Usuario/{id}
        [HttpGet("{id}")]
        public ActionResult<Usuario> GetUsuario(int id)
        {
            try
            {
                var usuario = _usuarioBusiness.ObtenerUsuario(id);
                if (usuario == null)
                {
                    return NotFound($"Usuario con ID {id} no encontrado.");
                }
                return Ok(usuario);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/Usuario
        [HttpPost]
        public ActionResult CreateUsuario([FromBody] Usuario usuario)
        {
            try
            {
                _usuarioBusiness.CrearUsuario(usuario);
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

        // PUT: api/Usuario/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateUsuario(int id, [FromBody] Usuario usuario)
        {
            try
            {
                var usuarioExistente = _usuarioBusiness.ObtenerUsuario(id);
                if (usuarioExistente == null)
                {
                    return NotFound($"Usuario con ID {id} no encontrado.");
                }

                // Asegurarse de que el ID del usuario a actualizar coincida con el de la solicitud
                usuario.id = id;
                _usuarioBusiness.ModificarUsuario(usuario);
                return Ok("Usuario actualizado exitosamente.");
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