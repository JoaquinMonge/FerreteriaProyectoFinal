using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos.Usuarios;
using System.Data;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace BaseDatos.UsuariosBD
{
    public class ConexionUsuarios
    {
        ConexionBD conexion = new ConexionBD();
        public int idUsuario;



        public bool consultaLogin(UsuarioModel model)
        {
            int count;
            idUsuario = 0;
            conexion.Open();
            string Query1 = "SELECT COUNT(*) FROM persona WHERE usuario = @usuario AND contrasena = @contrasena";
            MySqlCommand cmd = new MySqlCommand(Query1, conexion.GetConexion());
            cmd.Parameters.AddWithValue("@usuario", model.Usuario);
            cmd.Parameters.AddWithValue("@contrasena", model.Contrasena);
            count = Convert.ToInt32(cmd.ExecuteScalar());

            if (count > 0)
            {
                string Query2 = "SELECT idPersona, nombre, apellido, cedula, telefono FROM persona WHERE usuario = @usuario AND contrasena = @contrasena";
                cmd = new MySqlCommand(Query2, conexion.GetConexion());
                cmd.Parameters.AddWithValue("@usuario", model.Usuario);
                cmd.Parameters.AddWithValue("@contrasena", model.Contrasena);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    model.ID = Convert.ToInt32(reader["idPersona"]);
                    model.Nombre = reader["nombre"].ToString();
                    model.Apellido = reader["apellido"].ToString();
                    model.Cedula = reader["cedula"].ToString();
                    model.Telefono = reader["telefono"].ToString();
                }
                reader.Close();
            }

            conexion.Close();

            return count > 0;
        }

        public bool CrearUsuario(UsuarioModel model)
        {
            conexion.Open();
            string query = "INSERT INTO persona (nombre, apellido, cedula,telefono,usuario,contrasena) VALUES (@nombre, @apellido, @cedula,@telefono,@usuario,@contrasena)";
            MySqlCommand cmd = new MySqlCommand(query, conexion.GetConexion());

            cmd.Parameters.AddWithValue("@nombre",model.Nombre);
            cmd.Parameters.AddWithValue("@apellido", model.Apellido);
            cmd.Parameters.AddWithValue("@cedula", model.Cedula);
            cmd.Parameters.AddWithValue("@telefono", model.Telefono);
            cmd.Parameters.AddWithValue("@usuario", model.Usuario);
            cmd.Parameters.AddWithValue("@contrasena", model.Contrasena);
            cmd.ExecuteNonQuery();
            conexion.Close();
            
            return true;
        }

        public UsuarioModel ObtenerDatos(int id)
        {
            UsuarioModel usuarioModel = new UsuarioModel();
            conexion.Open();

            string query = "SELECT usuario, nombre, cedula, apellido, telefono FROM persona WHERE idPersona = @id";
            MySqlCommand comando = new MySqlCommand(query, conexion.GetConexion());
            comando.Parameters.AddWithValue("@id", id);

            MySqlDataReader reader = comando.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    usuarioModel.Usuario = reader.GetString(0);
                    usuarioModel.Nombre = reader.GetString(1);
                    usuarioModel.Cedula = reader.GetString(2);
                    usuarioModel.Apellido = reader.GetString(3);
                    usuarioModel.Telefono = reader.GetString(4);
                    usuarioModel.ID = id;
                }
            }

            reader.Close();
            return usuarioModel;

        }

        public bool ActualizarUsuario(UsuarioModel model,int id)
        {
            
            conexion.Open();
            MySqlCommand comando = new MySqlCommand();
            comando.Connection = conexion.GetConexion();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "UPDATE persona SET nombre = @nombre, cedula = @cedula, apellido = @apellido, telefono = @telefono, usuario=@usuario, contrasena=@contrasena WHERE idPersona = @id";
            comando.Parameters.AddWithValue("@nombre", model.Nombre);
            comando.Parameters.AddWithValue("@cedula", model.Cedula);
            comando.Parameters.AddWithValue("@apellido", model.Apellido);
            comando.Parameters.AddWithValue("@telefono", model.Telefono);
            comando.Parameters.AddWithValue("@usuario", model.Usuario);
            comando.Parameters.AddWithValue("@contrasena", model.Contrasena);
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();


            conexion.Close();
            return true;
        }

        public bool EliminarUsuario(string usuario)
        {
            conexion.Open();

            string query = "DELETE from persona where usuario=@usuario";

            MySqlCommand comando = new MySqlCommand(query, conexion.GetConexion());
            comando.Parameters.AddWithValue("@usuario", usuario);
            comando.ExecuteNonQuery();


            conexion.Close();

            return true;
        }

        public int ObtenerIdUsuario(string nombreUsuario)
        {
            int idUsuario = 0;
            conexion.Open();
            string Query = "SELECT idPersona FROM persona WHERE usuario = @usuario";
            MySqlCommand cmd = new MySqlCommand(Query, conexion.GetConexion());
            cmd.Parameters.AddWithValue("@usuario", nombreUsuario);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                idUsuario = Convert.ToInt32(reader["idPersona"]);
            }
            reader.Close();
            conexion.Close();
            return idUsuario;
        }

        







    }
}
