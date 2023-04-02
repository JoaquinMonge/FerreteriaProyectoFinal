using Modelos.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Interfaces.Clientes
{
    public  interface IClientes
    {
        bool CrearCliente(ClienteModel model);
        bool ActualizarCliente(ClienteModel model);

        bool EliminarCliente(ClienteModel model);

        bool BuscarCliente(string nombre);

    }
}
