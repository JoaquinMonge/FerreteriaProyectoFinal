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

        public bool CrearCliente(ClienteModel model)
        {
            MySqlCommand comd = new MySqlCommand("SELECT COUNT(*) FROM clientes WHERE cedula = @cedula", conexion.GetConexion());
            comd.Parameters.AddWithValue("@cedula", model.Cedula);
            conexion.Open();
            int count = Convert.ToInt32(comd.ExecuteScalar());
            conexion.Close();

            if (count > 0)
            {
                return false;
            }
            else
            {
                conexion.Open();
                string query = "INSERT INTO clientes (nombre, apellidos, cedula,telefono,correo) VALUES (@nombre, @apellidos, @cedula,@telefono,@correo)";
                MySqlCommand cmd = new MySqlCommand(query, conexion.GetConexion());


                cmd.Parameters.AddWithValue("@nombre", model.Nombre);
                cmd.Parameters.AddWithValue("@apellidos", model.Apellidos);
                cmd.Parameters.AddWithValue("@cedula", model.Cedula);
                cmd.Parameters.AddWithValue("@telefono", model.Telefono);
                cmd.Parameters.AddWithValue("@correo", model.Correo);
               
                cmd.ExecuteNonQuery();
                conexion.Close();

                return true;
            }
           
        }

       public bool ActualizarCliente(ClienteModel model,string cedula)
        {
            conexion.Open();
            string query = "UPDATE clientes SET nombre = @nombre, apellidos =@apellidos, telefono = @telefono, correo = @correo" + " WHERE cedula = @cedula";
            MySqlCommand cmd = new MySqlCommand(query, conexion.GetConexion());
            cmd.Parameters.AddWithValue("@nombre", model.Nombre);
            cmd.Parameters.AddWithValue("@apellidos", model.Apellidos);
            cmd.Parameters.AddWithValue("@telefono", model.Telefono);
            cmd.Parameters.AddWithValue("@correo", model.Correo);
            cmd.Parameters.AddWithValue("@cedula", cedula);


            cmd.ExecuteNonQuery();
            conexion.Close();
            return true;

            
        }

        public bool EliminarCliente(string cedula)
        {
            conexion.Open();
            string query = "DELETE from clientes WHERE cedula=@cedula";
            MySqlCommand cmd = new MySqlCommand(query, conexion.GetConexion());
            cmd.Parameters.AddWithValue("@cedula", cedula);
            cmd.ExecuteNonQuery();
            conexion.Close();
            return true;
        }

        public ClienteModel ObtenerClientePorId(string cedula)
        {
            ClienteModel cliente = null;


            string Query = "SELECT * FROM clientes WHERE cedula = @cedula";
            MySqlCommand cmd = new MySqlCommand(Query, conexion.GetConexion());
            cmd.Parameters.AddWithValue("@cedula", cedula);

            conexion.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                cliente = new ClienteModel()
                {
                    Cedula = reader["cedula"].ToString(),
                    Nombre = reader["nombre"].ToString(),
                    Correo = reader["correo"].ToString(),
                    Telefono = reader["telefono"].ToString()
                };
            }

            reader.Close();


            return cliente;
        }

    }
}
