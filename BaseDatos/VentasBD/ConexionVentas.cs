using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos.Ventas;

namespace BaseDatos.VentasBD
{
    public class ConexionVentas
    {
        ConexionBD conexion = new ConexionBD();
        public bool RegistrarProducto(VentasModel model)
        {
            conexion.Open();
            string query = "INSERT INTO factura (idCliente, idProducto, precioTotal, cantidadProducto,estado) VALUES (@idcliente, @idproducto, @preciototal, @cantidadproducto,@estado)";
            MySqlCommand cmd = new MySqlCommand(query, conexion.GetConexion());
            cmd.Parameters.AddWithValue("@idcliente", model.ID);
            cmd.Parameters.AddWithValue("@idproducto", model.IdProducto);
            cmd.Parameters.AddWithValue("@preciototal", model.PrecioTotal);
            cmd.Parameters.AddWithValue("@cantidadproducto", model.Cantidad);
            cmd.Parameters.AddWithValue("@estado", "pendiente");

            cmd.ExecuteNonQuery();
            conexion.Close();
            return true;




        }
    }
}
