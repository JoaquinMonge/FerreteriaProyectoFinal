using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Ventas
{
    public class VentasModel
    {
        public int ID{get; set;}
        public string IdCliente { get; set; }

        public int IdProducto { get; set; }

        public int PrecioTotal { get; set; }

        public int PrecioUnitario { get; set; }
        public int Cantidad { get; set; }
        public string Estado { get; set; }





    }
}
