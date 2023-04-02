using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos.Inventario;

namespace Modelos.Interfaces.Inventario
{
    public interface IInventario
    {
        bool RegistrarProducto(InventarioModel model);
        bool ActualizarProducto(InventarioModel model,int id);

        bool EliminarProducto(InventarioModel model);

        bool BuscarProducto(string id, string nombre, int precio);
    }
}
