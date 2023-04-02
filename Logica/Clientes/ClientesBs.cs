using Modelos.Clientes;
using Modelos.Interfaces.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BaseDatos.ClientesBD;


namespace Logica.Clientes

{
    public class ClientesBs : IClientes
    {
        private ConexionClientes cn = new ConexionClientes();
        public DataTable ConsultaDT()
        {
            return cn.ConsultaClientes();
        }
        public bool ActualizarCliente(ClienteModel model)
        {
            throw new NotImplementedException();
        }

        public bool BuscarCliente(string nombre)
        {
            throw new NotImplementedException();
        }

        public bool CrearCliente(ClienteModel model)
        {
            throw new NotImplementedException();
        }

        public bool EliminarCliente(ClienteModel model)
        {
            throw new NotImplementedException();
        }
    }
}
