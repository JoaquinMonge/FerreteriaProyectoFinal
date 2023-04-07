using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using Modelos.Inventario;

namespace BaseDatos.InventarioBD
{
    public class ConexionInventario
    {
        ConexionBD conexion = new ConexionBD();

        public DataTable ConsultaProductos()
        {
            conexion.Open();

            string consulta = "SELECT * FROM inventario";
            MySqlCommand cmd = new MySqlCommand(consulta, conexion.GetConexion());
            DataTable tabla = new DataTable();
            MySqlDataAdapter data = new MySqlDataAdapter(cmd);
            data.Fill(tabla);

            conexion.Close();

            return tabla;

        }

        public bool RegistrarProducto(InventarioModel model)
        {
            conexion.Open();

            string consulta = "INSERT INTO inventario (codigoProducto, nombre, descripcion,precio,existencias) VALUES (@codigoProducto, @nombre, @descripcion,@precio,@existencias)";

            MySqlCommand cmd = new MySqlCommand(consulta, conexion.GetConexion());

            cmd.Parameters.AddWithValue("@codigoProducto", model.codigoProducto);
            cmd.Parameters.AddWithValue("@nombre", model.nombre);
            cmd.Parameters.AddWithValue("@descripcion", model.descripcion);
            cmd.Parameters.AddWithValue("@precio", model.precio);
            cmd.Parameters.AddWithValue("@existencias", model.existencias);

            cmd.ExecuteNonQuery();

            conexion.Close();

            return true;

        }

        public bool ActualizarProducto(InventarioModel model,int id)
        {
            conexion.Open();

            string consulta = "UPDATE inventario SET nombre = @nombre, descripcion =@descripcion, precio = @precio, existencias = @existencias"  + " WHERE codigoProducto = " + id;

            MySqlCommand cmd = new MySqlCommand(consulta, conexion.GetConexion());

            cmd.Parameters.AddWithValue("@codigoProducto", model.codigoProducto);
            cmd.Parameters.AddWithValue("@nombre", model.nombre);
            cmd.Parameters.AddWithValue("@descripcion", model.descripcion);
            cmd.Parameters.AddWithValue("@precio", model.precio);
            cmd.Parameters.AddWithValue("@existencias", model.existencias);

            cmd.ExecuteNonQuery();

            conexion.Close();

            return true;
        }

        public bool EliminarProducto(int id)
        {
            conexion.Open();

            string consulta = "DELETE from inventario where codigoProducto=@id";

            MySqlCommand comando = new MySqlCommand(consulta, conexion.GetConexion());
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();


            conexion.Close();

            return true;
        }

        public bool ActualizarStock(int codigoProducto, int existencias)
        {
            conexion.Open();

            string consulta = "UPDATE inventario SET existencias = @existencias WHERE codigoProducto = @codigoProducto";

            MySqlCommand cmd = new MySqlCommand(consulta, conexion.GetConexion());

            cmd.Parameters.AddWithValue("@existencias",existencias);
            cmd.Parameters.AddWithValue("@codigoProducto", codigoProducto);

            cmd.ExecuteNonQuery();

            conexion.Close();

            return true;
        }
        public InventarioModel ObtenerProductoPorId(int id)
        {
            InventarioModel inventario = null;

            string consulta = "SELECT * FROM inventario WHERE codigoProducto = @id";

            MySqlCommand cmd = new MySqlCommand(consulta, conexion.GetConexion());

            cmd.Parameters.AddWithValue("@id", id);

            conexion.Open();

            MySqlDataReader reader = cmd.ExecuteReader(); // aqui se almacena la consulta realizada a la base de datos

            if (reader.Read())
            {
                inventario = new InventarioModel()
                {
                    codigoProducto = (int)reader["codigoProducto"],
                    nombre = reader["nombre"].ToString(),
                    precio = (int)reader["precio"],
                    existencias = (int)reader["existencias"]
                };
            }

            reader.Close();

            conexion.Close();

            return inventario;

        }

    }
}
