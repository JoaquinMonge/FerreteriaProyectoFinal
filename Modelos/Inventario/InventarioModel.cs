using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Inventario
{
    public class InventarioModel
    {
        public int codigoProducto { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int precio { get; set; }
        public int existencias { get;set; }
        public int cantidad { get; set; }

    }
}
