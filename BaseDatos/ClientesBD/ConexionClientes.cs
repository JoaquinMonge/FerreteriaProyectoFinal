using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using Modelos.Clientes;



namespace BaseDatos.ClientesBD
{
    public class ConexionClientes
    {
        ConexionBD conexion = new ConexionBD();

        public DataTable ConsultaClientes()
        {
            conexion.Open();
            string Query = "SELECT * FROM clientes";
            MySqlCommand cmd = new MySqlCommand(Query, conexion.GetConexion());
            DataTable tabla= new DataTable();                   
            MySqlDataAdapter data= new MySqlDataAdapter(cmd);
            data.Fill(tabla);
            conexion.Close();
            return tabla;   

        }

    }
}
