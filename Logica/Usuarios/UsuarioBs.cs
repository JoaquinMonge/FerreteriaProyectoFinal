using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos.Interfaces.Usuarios;
using Modelos.Usuarios;
using BaseDatos.UsuariosBD;

namespace Logica.Usuarios
{
    public class UsuarioBs : IUsuarios
    {

        private ConexionUsuarios conexionUsuarios = new ConexionUsuarios();
        public bool ActualizarUsuario(UsuarioModel model,int id)
        {
            return conexionUsuarios.ActualizarUsuario(model,id);
        }

        public bool consultaLogin(UsuarioModel model)
        {

            return conexionUsuarios.consultaLogin( model);

        }

        public bool CrearUsuario(UsuarioModel model)
        {
            return conexionUsuarios.CrearUsuario(model);
        }

        public bool EliminarUsuario(string usuario)
        {
            return conexionUsuarios.EliminarUsuario(usuario);
        }

        public UsuarioModel ObtenerDatosUsuario(int id)
        {
            return conexionUsuarios.ObtenerDatos(id);
        }
        public int ObtenerIdUsuario(string nombreUsuario)
        {
            UsuarioBs usuarioBs = new UsuarioBs();
            return conexionUsuarios.ObtenerIdUsuario(nombreUsuario);
        }
    }
}
