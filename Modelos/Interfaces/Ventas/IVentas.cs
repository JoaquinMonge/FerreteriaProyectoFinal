using Modelos.Ventas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Modelos.Interfaces.Ventas
{
    public interface IVentas
    {
        bool RegistrarVenta(VentasModel model);
        bool ActualizarFactura(VentasModel model,int id);
    }
}
