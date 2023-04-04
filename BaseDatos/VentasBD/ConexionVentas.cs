﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos.Ventas;
using Modelos.Interfaces.Ventas;
using System.Data;
using Modelos.Clientes;
using Modelos.Inventario;

namespace BaseDatos.VentasBD
{

    public class ConexionVentas
    {

        ConexionBD conexion = new ConexionBD();
        public bool RegistrarProducto(VentasModel model,string id)
        {
            conexion.Open();
            int total = model.PrecioUnitario * model.Cantidad;
           
            string query = "INSERT INTO factura (idFactura,idCliente, idProducto, precioUnitario, cantidadProducto,estado,precioTotal) VALUES (@idFactura,@idcliente, @idproducto, @precioUnitario, @cantidadproducto,@estado,@precioTotal)";
            MySqlCommand cmd = new MySqlCommand(query, conexion.GetConexion());
            cmd.Parameters.AddWithValue("@idcliente", model.ID);
            cmd.Parameters.AddWithValue("@idproducto", model.IdProducto);
            cmd.Parameters.AddWithValue("@precioUnitario", model.PrecioUnitario);
            cmd.Parameters.AddWithValue("@cantidadproducto", model.Cantidad);
            cmd.Parameters.AddWithValue("@estado", "pendiente");
            cmd.Parameters.AddWithValue("@precioTotal", total);
            cmd.Parameters.AddWithValue("@idFactura", id);



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
                    ID = reader["idFactura"].ToString(),
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

        public bool EliminarFactura(string cedula)
        {
            conexion.Open();
            string query = "DELETE from factura WHERE idCliente=@cedula";
            MySqlCommand cmd = new MySqlCommand(query, conexion.GetConexion());
            cmd.Parameters.AddWithValue("@cedula", cedula);
            cmd.ExecuteNonQuery();
            conexion.Close();
            return true;
        }

        public bool ActualizarFactura(FacturaModel model, int id)
        {
            conexion.Open();
            string query = "UPDATE factura SET idCliente = @idCliente, idProducto =@idProducto, precioTotal = @precioTotal, estado = @estado, precioUnitario=@precioUnitario, cantidadProducto=@cantidad WHERE idProducto = @idProducto";

            MySqlCommand cmd = new MySqlCommand(query, conexion.GetConexion());
            cmd.Parameters.AddWithValue("@idCliente", model.Cedula);
            cmd.Parameters.AddWithValue("@idProducto", id);
            cmd.Parameters.AddWithValue("@precioTotal", model.PrecioTotal);
            cmd.Parameters.AddWithValue("@estado", model.Estado);
            cmd.Parameters.AddWithValue("@precioUnitario", model.Total);
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

            //Restar la cantidad del modelo de factura a las existencias obtenidas en la consulta
            int cantidadActualizada = existencias - model.Cantidad;

            // Actualizar la cantidad de existencias en la tabla de inventario
            string queryActualizarExistencias = "UPDATE inventario SET existencias = @existencias WHERE codigoProducto = @codigoProducto";
            MySqlCommand cmdActualizarExistencias = new MySqlCommand(queryActualizarExistencias, conexion.GetConexion());
            cmdActualizarExistencias.Parameters.AddWithValue("@existencias", cantidadActualizada);
            cmdActualizarExistencias.Parameters.AddWithValue("@codigoProducto", id);
            cmdActualizarExistencias.ExecuteNonQuery();




            cmd.ExecuteNonQuery();
            conexion.Close();
            return true;




                

            
        }






    }
    }

