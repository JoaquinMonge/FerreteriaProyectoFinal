using Modelos.Factura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Modelos.Interfaces.Ventas
{
    public interface IVentas
    {
        bool RegistrarVenta(FacturaModel model);
        bool ActualizarFactura(FacturaModel model,int id);
    }
}
