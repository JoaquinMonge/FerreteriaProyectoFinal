using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos.Inventario;
using Modelos.Interfaces.Inventario;
using System.Data;
using BaseDatos.InventarioBD;

namespace Logica.Inventario
{
    public class InventarioBs : IInventario
    {
        private ConexionInventario cn=new ConexionInventario(); 
        public DataTable ConsultaDT()
        {
            return cn.ConsultaProductos();
        }
        public bool ActualizarUsuario(InventarioModel model)
        {
            return cn.RegistrarProducto(model);
        }

        public bool BuscarProducto(string id, string nombre, int precio)
        {
            throw new NotImplementedException();
        }

        public bool EliminarUsuario(InventarioModel model)
        {
            throw new NotImplementedException();
        }

        public bool RegistrarProducto(InventarioModel model)
        {
            return cn.RegistrarProducto(model);
        }
    }
}
