using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos.Factura;
using Modelos.Interfaces.Ventas;
using System.Data;
using Modelos.Clientes;
using Modelos.Inventario;


namespace BaseDatos.VentasBD
{

    public class ConexionVentas
    {

        ConexionBD conexion = new ConexionBD();
        public bool RegistrarProducto(FacturaModel model,string id)
        {
            conexion.Open();
            int total = model.Precio * model.Cantidad;
           
            string consulta = "INSERT INTO factura (idFactura,idCliente, idProducto, precioUnitario, cantidadProducto,estado,precioTotal) VALUES (@idFactura,@idcliente, @idproducto, @precioUnitario, @cantidadproducto,@estado,@precioTotal)";

            MySqlCommand cmd = new MySqlCommand(consulta, conexion.GetConexion());

            cmd.Parameters.AddWithValue("@idcliente", model.Cedula);
            cmd.Parameters.AddWithValue("@idproducto", model.Codigo);
            cmd.Parameters.AddWithValue("@precioUnitario", model.Precio);
            cmd.Parameters.AddWithValue("@cantidadproducto", model.Cantidad);
            cmd.Parameters.AddWithValue("@estado", "pendiente");
            cmd.Parameters.AddWithValue("@precioTotal", total);
            cmd.Parameters.AddWithValue("@idFactura", id);


            cmd.ExecuteNonQuery();

            conexion.Close();

            return true;

        }


        public DataTable ConsultaVentas(int cedula)
        {
            string consulta = "SELECT * FROM factura WHERE idCliente = @idCliente  AND estado = 'pendiente'";

            MySqlCommand cmd = new MySqlCommand(consulta, conexion.GetConexion());

            cmd.Parameters.AddWithValue("@idCliente", cedula);

            DataTable tabla = new DataTable();

            MySqlDataAdapter data = new MySqlDataAdapter(cmd);

            data.Fill(tabla);

            conexion.Close();

            return tabla;



        }

        public DataTable ConsultaEstado(string estado)
        {

            if (estado != null)
            {
                string consulta = "SELECT * FROM factura WHERE estado=@estado";

                MySqlCommand cmd = new MySqlCommand(consulta, conexion.GetConexion());

                cmd.Parameters.AddWithValue("@estado", estado);

                DataTable tabla = new DataTable();

                MySqlDataAdapter data = new MySqlDataAdapter(cmd);

                data.Fill(tabla);

                return tabla;


            }
            else
            {
                string consulta = "SELECT * FROM factura";

                MySqlCommand cmd = new MySqlCommand(consulta, conexion.GetConexion());

                DataTable tabla = new DataTable();

                MySqlDataAdapter data = new MySqlDataAdapter(cmd);

                data.Fill(tabla);

                return tabla;

            }


        }

        public List<FacturaModel> ObtenerFacturas()
        {
            List<FacturaModel> facturas = new List<FacturaModel>();

            string consulta = "SELECT factura.*, inventario.nombre, clientes.nombre AS nombreCliente FROM factura JOIN inventario ON factura.idProducto = inventario.codigoProducto JOIN clientes ON factura.idCliente = clientes.cedula";

            MySqlCommand comando = new MySqlCommand(consulta, conexion.GetConexion());

                conexion.Open();
                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())

                {

                FacturaModel factura = new FacturaModel()
                {
                    Id = reader["idFactura"].ToString(),
                    Cedula = reader["idCliente"].ToString(),
                    Cliente = reader["nombreCliente"].ToString(),
                    Codigo = (int)reader["idProducto"],
                    Producto = reader["nombre"].ToString(),
                    Cantidad = (int)reader["cantidadProducto"],
                    Precio = (int)reader["precioUnitario"],
                    PrecioTotal = (int)reader["cantidadProducto"] * (int)reader["precioUnitario"],
                    Estado = reader["estado"].ToString(),
                    };

                    facturas.Add(factura);
                }

                reader.Close();
            

            return facturas;
        }

        public bool EliminarFactura(int idProd, int cantidad)
        {
            conexion.Open();

            string consulta = "DELETE from factura WHERE idProducto=@idProd";

            MySqlCommand cmd = new MySqlCommand(consulta, conexion.GetConexion());

            cmd.Parameters.AddWithValue("@idProd", idProd);

            cmd.ExecuteNonQuery();


            // Actualizar el inventario
            string queryActualizarInventario = "UPDATE inventario SET existencias=existencias+@cantidad WHERE codigoProducto=@idProd";

            MySqlCommand cmdActualizarInventario = new MySqlCommand(queryActualizarInventario, conexion.GetConexion());

            cmdActualizarInventario.Parameters.AddWithValue("@idProd", idProd);
            cmdActualizarInventario.Parameters.AddWithValue("@cantidad", cantidad);

            cmdActualizarInventario.ExecuteNonQuery();

            conexion.Close();

            return true;
        }

        public bool EliminarFacturaCtdCero()
        {
            conexion.Open();

            string query = "DELETE from factura WHERE cantidadProducto = 0";

            MySqlCommand cmd = new MySqlCommand(query, conexion.GetConexion());

            cmd.ExecuteNonQuery();

            conexion.Close();

            return true;
        }

        public bool ActualizarFactura(FacturaModel model, int id,int ctd)
        {
            conexion.Open();
            string query = "UPDATE factura SET idCliente = @idCliente, idProducto =@idProducto, precioTotal = @precioTotal, estado = @estado, precioUnitario=@precioUnitario, cantidadProducto=@cantidad WHERE idProducto = @idProducto";

            MySqlCommand cmd = new MySqlCommand(query, conexion.GetConexion());

            cmd.Parameters.AddWithValue("@idCliente", model.Cedula);
            cmd.Parameters.AddWithValue("@idProducto", id);
            cmd.Parameters.AddWithValue("@precioTotal", model.PrecioTotal);
            cmd.Parameters.AddWithValue("@estado", model.Estado);
            cmd.Parameters.AddWithValue("@precioUnitario", model.Precio);
            cmd.Parameters.AddWithValue("@cantidad", model.Cantidad);

            // Obtener la cantidad de existencias del producto en la tabla de inventario
            string queryExistencias = "SELECT existencias FROM inventario WHERE codigoProducto = @codigoProducto";

            MySqlCommand cmdExistencias = new MySqlCommand(queryExistencias, conexion.GetConexion());

            cmdExistencias.Parameters.AddWithValue("@codigoProducto", id);

            int existencias = Convert.ToInt32(cmdExistencias.ExecuteScalar());

            // Validar que hay suficientes existencias en inventario para realizar la actualización de la factura
            if (model.Cantidad > existencias)
            {
                conexion.Close();
                return false;
            }

            
            ActualizarExistencias(id, ctd);

            cmd.ExecuteNonQuery();

            conexion.Close();

            return true;

  
        }

        public void ActualizarExistencias(int idProducto, int cantidad)
        {
            

            // Obtener las existencias actuales del producto
            string queryExistencias = "SELECT existencias FROM inventario WHERE codigoProducto = @codigoProducto";

            MySqlCommand cmdExistencias = new MySqlCommand(queryExistencias, conexion.GetConexion());

            cmdExistencias.Parameters.AddWithValue("@codigoProducto", idProducto);

            int existencias = Convert.ToInt32(cmdExistencias.ExecuteScalar());


            // Actualizar las existencias en la tabla de inventario
            string queryActualizarExistencias = "UPDATE inventario SET existencias = @existencias WHERE codigoProducto = @codigoProducto";

            MySqlCommand cmdActualizarExistencias = new MySqlCommand(queryActualizarExistencias, conexion.GetConexion());

            cmdActualizarExistencias.Parameters.AddWithValue("@existencias", existencias + cantidad);

            cmdActualizarExistencias.Parameters.AddWithValue("@codigoProducto", idProducto);

            cmdActualizarExistencias.ExecuteNonQuery();

        }

        public bool ActualizarEstado(string idFactura)
        {
            conexion.Open();

            string query = "UPDATE factura SET estado=@completado WHERE idFactura=@idFactura";

            MySqlCommand cmd = new MySqlCommand(query, conexion.GetConexion());

            cmd.Parameters.AddWithValue("@idFactura", idFactura);

            cmd.Parameters.AddWithValue("@completado", "completado");

            cmd.ExecuteNonQuery();

            conexion.Close();

            return true;
        }






    }
    }

