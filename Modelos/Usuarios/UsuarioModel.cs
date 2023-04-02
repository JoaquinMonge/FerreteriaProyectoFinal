using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Usuarios
{
    public class UsuarioModel
    {

        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public string Usuario { get; set; }

        

        public string Contrasena { get; set; }
        public string Telefono { get; set; }

        public string Cedula { get; set; }

    }
}
