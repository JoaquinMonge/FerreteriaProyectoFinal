using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseDatos.VentasBD;
using Modelos.Ventas;
using Modelos.Interfaces.Ventas;

namespace Logica.Ventas
{
    
    public class VentasBs
    {
        private ConexionVentas ventas = new ConexionVentas();
        public bool RegistrarVenta(VentasModel model)
        {

            return ventas.RegistrarProducto(model);
        }

    }
}
