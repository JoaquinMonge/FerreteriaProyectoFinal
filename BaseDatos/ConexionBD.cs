using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace BaseDatos
{

    public class ConexionBD
    {
        MySqlConnection conexion = new MySqlConnection("Server=localhost; Database=bdingsoft; uid=root;Pwd=2901;");


        public void Open()
        {
            
                conexion.Open();
            
        }

        public void Close()
        {
            conexion.Close();
        }

        public MySqlConnection GetConexion()
        {
            return conexion;
        }

    }
}
