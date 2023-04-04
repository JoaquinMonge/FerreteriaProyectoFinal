using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Factura
{
    public class FacturaModel
    {
        public string Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Cliente { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public int Codigo { get; set; }
        public int PrecioTotal { get; set; }
        public int Precio { get; set; }
        public string Cedula { get; set; }

        public string Estado { get; set; }
    }
}
