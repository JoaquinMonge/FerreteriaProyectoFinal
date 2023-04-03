using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseDatos.VentasBD;
using Modelos.Ventas;
using Modelos.Interfaces.Ventas;
using System.Data;
using Modelos.Inventario;

namespace Logica.Ventas
{
    
    public class VentasBs
    {
        private ConexionVentas ventas = new ConexionVentas();
        public bool RegistrarVenta(VentasModel model)
        {

            return ventas.RegistrarProducto(model);
        }

        public DataTable ConsultaDT()
        {
            return ventas.ConsultaVentas();
        }
       public  List<VentasModel> ObtenerFacturas()
        {
            return ventas.ObtenerFacturas();    
        }




    }
}
