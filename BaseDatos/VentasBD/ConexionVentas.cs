using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos.Ventas;
using System.Data;
using Modelos.Clientes;
using Modelos.Inventario;

namespace BaseDatos.VentasBD
{

    public class ConexionVentas
    {

        ConexionBD conexion = new ConexionBD();
        public bool RegistrarProducto(VentasModel model)
        {
            conexion.Open();
            int total = model.PrecioUnitario * model.Cantidad;
           
            string query = "INSERT INTO factura (idCliente, idProducto, precioUnitario, cantidadProducto,estado,precioTotal) VALUES (@idcliente, @idproducto, @precioUnitario, @cantidadproducto,@estado,@precioTotal)";
            MySqlCommand cmd = new MySqlCommand(query, conexion.GetConexion());
            cmd.Parameters.AddWithValue("@idcliente", model.ID);
            cmd.Parameters.AddWithValue("@idproducto", model.IdProducto);
            cmd.Parameters.AddWithValue("@precioUnitario", model.PrecioUnitario);
            cmd.Parameters.AddWithValue("@cantidadproducto", model.Cantidad);
            cmd.Parameters.AddWithValue("@estado", "pendiente");
            cmd.Parameters.AddWithValue("@precioTotal", total);


            cmd.ExecuteNonQuery();
            conexion.Close();
            return true;

        }


        public DataTable ConsultaVentas()
        {
            conexion.Open();
            string Query = "SELECT * FROM factura";
            MySqlCommand cmd = new MySqlCommand(Query, conexion.GetConexion());
            DataTable tabla = new DataTable();
            MySqlDataAdapter data = new MySqlDataAdapter(cmd);
            data.Fill(tabla);
            conexion.Close();
            return tabla;




        }

        public List<VentasModel> ObtenerFacturas()
        {
            List<VentasModel> facturas = new List<VentasModel>();


           
                string consulta = "SELECT * FROM factura";
                MySqlCommand comando = new MySqlCommand(consulta, conexion.GetConexion());

                conexion.Open();
                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                VentasModel factura = new VentasModel()
                {
                    ID = (int)reader["idFactura"],
                    IdCliente = reader["idCliente"].ToString(),
                    IdProducto = (int)reader["idProducto"],
                    Cantidad = (int)reader["cantidadProducto"],
                    PrecioUnitario = (int)reader["precioUnitario"],
                    PrecioTotal = (int)reader["cantidadProducto"] * (int)reader["precioUnitario"],
                    Estado = reader["estado"].ToString(),
                    };
                    facturas.Add(factura);
                }

                reader.Close();
            

            return facturas;
        }




    }
    }

