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
        public bool ActualizarProducto(InventarioModel model,int id)
        {
            return cn.ActualizarProducto(model,id);
        }

        public bool BuscarProducto(string id, string nombre, int precio)
        {
            throw new NotImplementedException();
        }

        public bool EliminarProducto(int id)
        {
            return cn.EliminarProducto(id);
        }

        public bool RegistrarProducto(InventarioModel model)
        {
            return cn.RegistrarProducto(model);
        }

        public bool ActualizarStock(int codigo, int existencias)
        {
            return cn.ActualizarStock(codigo, existencias);
        }

        public InventarioModel ObtenerProductoID( int id)
        {
            return cn.ObtenerProductoPorId(id);
        }
    }
}
