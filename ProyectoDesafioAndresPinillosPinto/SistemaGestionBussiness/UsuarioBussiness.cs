using SistemaGestionData;
using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionBussiness
{
    public class UsuarioBusiness
    {
        // Método para obtener un usuario por su ID
        public Usuario ObtenerUsuario(int id)
        {
            //if (id <= 0)
            //{
            //    throw new ArgumentException("El ID debe ser mayor que cero.");
            //}
            return UsuarioData.ObtenerUsuario(id);
        }

        // Método para listar todos los usuarios
        public List<Usuario> ListarUsuarios()
        {
            return UsuarioData.ListarUsuarios();
        }

        // Método para crear un nuevo usuario
        public void CrearUsuario(Usuario usuario)
        {
            if (usuario == null)
            {
                throw new ArgumentNullException("El usuario no puede ser nulo.");
            }
            if (string.IsNullOrWhiteSpace(usuario.nombre))
            {
                throw new ArgumentException("El nombre es obligatorio.");
            }
            if (string.IsNullOrWhiteSpace(usuario.apellido))
            {
                throw new ArgumentException("El apellido es obligatorio.");
            }
            if (string.IsNullOrWhiteSpace(usuario.nombreUsuario))
            {
                throw new ArgumentException("El nombre de usuario es obligatorio.");
            }
            if (string.IsNullOrWhiteSpace(usuario.contraseña))
            {
                throw new ArgumentException("La contraseña es obligatoria.");
            }
            if (string.IsNullOrWhiteSpace(usuario.mail) || !usuario.mail.Contains("@"))
            {
                throw new ArgumentException("El correo electrónico es inválido.");
            }
            UsuarioData.CrearUsuario(usuario);
        }

        // Método para modificar un usuario existente
        public void ModificarUsuario(Usuario usuario)
        {
            if (usuario == null)
            {
                throw new ArgumentNullException("El usuario no puede ser nulo.");
            }
            UsuarioData.ModificarUsuario(usuario);
        }

        // Método para eliminar un usuario por su ID
        public void EliminarUsuario(int id)
        {
            UsuarioData.EliminarUsuario(id);
        }
    }

}
