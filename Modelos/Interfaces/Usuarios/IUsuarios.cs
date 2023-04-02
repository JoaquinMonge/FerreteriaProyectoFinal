using Modelos.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Interfaces.Usuarios
{
    public interface IUsuarios
    {
        bool CrearUsuario(UsuarioModel model);
        bool ActualizarUsuario(UsuarioModel model,int ID);

        bool EliminarUsuario(string usuario);

        
        bool consultaLogin(UsuarioModel model);
    }
}
