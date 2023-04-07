using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseDatos.VentasBD;
using Modelos.Factura;
using Modelos.Interfaces.Ventas;
using System.Data;
using Modelos.Inventario;

namespace Logica.Ventas
{
    
    public class VentasBs
    {
        private ConexionVentas ventas = new ConexionVentas();
        public bool RegistrarVenta(FacturaModel model,string id)
        {

            return ventas.RegistrarProducto(model,id);
        }

        public DataTable ConsultaDT(int cedula)
        {
            return ventas.ConsultaVentas(cedula);
        }
       public  List<FacturaModel> ObtenerFacturas()
        {
            return ventas.ObtenerFacturas();    
        }

        public bool EliminarFactura(int idProducto,int cantidad)
        {
            return ventas.EliminarFactura(idProducto,cantidad);
        }

        public bool EliminarFacturaCtdCero()
        {
            return ventas.EliminarFacturaCtdCero();
        }

        public bool ActualizarFactura(FacturaModel model,int id,int ctd)
        {
            return ventas.ActualizarFactura(model,id,ctd);
        }

        public bool ActualizarEstado(string idFactura)
        {
            return ventas.ActualizarEstado(idFactura);
        }

        public DataTable ConsultaEstado(string estado)
        {
            return ventas.ConsultaEstado(estado);
        }




    }
}
