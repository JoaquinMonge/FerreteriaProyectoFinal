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
            string query = "SELECT COUNT(*) FROM clientes WHERE cedula = @cedula";
            MySqlCommand comando = new MySqlCommand(query, conexion.GetConexion());
            comando.Parameters.AddWithValue("@cedula", model.Cedula);
            conexion.Open();
            int count = Convert.ToInt32(comando.ExecuteScalar());
            conexion.Close();

            if (count > 0)
            {
                return false;
            }
            else
            {
                conexion.Open();
                string consulta = "INSERT INTO clientes (nombre, apellidos, cedula,telefono,correo) VALUES (@nombre, @apellidos, @cedula,@telefono,@correo)";
                MySqlCommand cmd = new MySqlCommand(consulta, conexion.GetConexion());

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
            string consulta = "UPDATE clientes SET nombre = @nombre, apellidos =@apellidos, telefono = @telefono, correo = @correo" + " WHERE cedula = @cedula";
            MySqlCommand cmd = new MySqlCommand(consulta, conexion.GetConexion());
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
            string consulta = "DELETE from clientes WHERE cedula=@cedula";
            MySqlCommand cmd = new MySqlCommand(consulta, conexion.GetConexion());
            cmd.Parameters.AddWithValue("@cedula", cedula);
            cmd.ExecuteNonQuery();
            conexion.Close();
            return true;
        }

        public ClienteModel ObtenerClientePorId(string cedula)
        {
            //se establece en null porque aún no se ha encontrado ningún cliente con la cédula proporcionada
            ClienteModel cliente = null;

            string consulta = "SELECT * FROM clientes WHERE cedula = @cedula";
            MySqlCommand cmd = new MySqlCommand(consulta, conexion.GetConexion());
            cmd.Parameters.AddWithValue("@cedula", cedula);

            conexion.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                //si se encontro un cliente con esa cedula, se crea un objeto ClienteModel con los datos obtenidos y se asigna a la variable cliente
                cliente = new ClienteModel()
                {
                    Cedula = reader["cedula"].ToString(),
                    Nombre = reader["nombre"].ToString(),
                    Apellidos = reader["apellidos"].ToString(),
                    Correo = reader["correo"].ToString(),
                    Telefono = reader["telefono"].ToString()
                };
            }

            reader.Close();
            conexion.Close();

            return cliente;
        }

    }
}
