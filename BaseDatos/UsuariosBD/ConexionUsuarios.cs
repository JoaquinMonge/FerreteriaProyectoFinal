using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos.Usuarios;
using System.Data;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Security.Cryptography;

namespace BaseDatos.UsuariosBD
{
    public class ConexionUsuarios
    {
        ConexionBD conexion = new ConexionBD();
        public int idUsuario;

        private string HashedPwd(string password)
        {
            //SHA256 es una función hash criptografica que produce una salida de 256 bits de longitud
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Convertir la contraseña en un arreglo de bytes
                //Para obtener este arreglo de bytes, se utiliza el metodo GetBytes de la clase Encoding para convertir la contraseña en una secuencia de bytes utilizando el encoding UTF8.
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convertir los bytes en una cadena hexadecimal
                // Se utiliza un StringBuilder para crear una cadena vacía 
                //y luego se itera a traves de cada byte en la salida encriptada. Para cada byte, se convierte su valor en una cadena hexadecimal de dos digitos y se agrega al StringBuilder. Finalmente, se devuelve la cadena completa utilizando el método ToString del StringBuilder.
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    //El x2 en el metodo ToString utilizado en el bucle for significa que cada byte en la salida encriptada se convertira en una cadena de dos caracteres hexadecimales.
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public bool consultaLogin(UsuarioModel model)
        {
            int count;
            idUsuario = 0;
            conexion.Open();

            string hashedPassword = HashedPwd(model.Contrasena);
            string Query1 = "SELECT COUNT(*) FROM persona WHERE usuario = @usuario AND contrasena = @contrasena";
            MySqlCommand cmd = new MySqlCommand(Query1, conexion.GetConexion());
            cmd.Parameters.AddWithValue("@usuario", model.Usuario);
            cmd.Parameters.AddWithValue("@contrasena", hashedPassword);
            count = Convert.ToInt32(cmd.ExecuteScalar());

            if (count > 0)
            {
                string Query2 = "SELECT idPersona, nombre, apellido, cedula, telefono FROM persona WHERE usuario = @usuario AND contrasena = @contrasena";
                cmd = new MySqlCommand(Query2, conexion.GetConexion());
                cmd.Parameters.AddWithValue("@usuario", model.Usuario);
                cmd.Parameters.AddWithValue("@contrasena", hashedPassword);
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
            // Verificar si el usuario ya existe
            MySqlCommand comd = new MySqlCommand("SELECT COUNT(*) FROM persona WHERE usuario = @usuario", conexion.GetConexion());
            comd.Parameters.AddWithValue("@usuario", model.Usuario);
            conexion.Open();
            int count = Convert.ToInt32(comd.ExecuteScalar());
            conexion.Close();

            // Si el usuario ya existe, enviar un mensaje de error
            if (count > 0)
            {
               
                return false;
            }
            else
            {
                // rest of the code to hash the password and insert the user into the database



                string pwd = model.Contrasena;
                string hashedPassword = "";
                //documentacion microsoft SHA256 para encriptar
                using (SHA256 mySHA256 = SHA256.Create())
                {
                    //Obtener la cadena de bytes de la contraseña 
                    byte[] passwordBytes = Encoding.UTF8.GetBytes(pwd);

                    // Hashear la contraseña
                    byte[] hashedPasswordBytes = mySHA256.ComputeHash(passwordBytes);

                    // Convertir la cadena de bytes hasheada a una cadena de caracteres hexadecimal La cadena resultante de BitConverter.ToString(hashedPasswordBytes) tiene un guion ("-") entre cada par de caracteres hexadecimales, por ejemplo: "4A-69-6D-6D-79-2E-43-61-74-21". Sin embargo, algunos sistemas de almacenamiento de contraseñas pueden no admitir guiones en las contraseñas encriptadas, por lo que se eliminan con el método Replace para generar una cadena de caracteres hexadecimales sin guiones.
                    hashedPassword = BitConverter.ToString(hashedPasswordBytes).Replace("-", "");


                }

                conexion.Open();
                string query = "INSERT INTO persona (nombre, apellido, cedula,telefono,usuario,contrasena) VALUES (@nombre, @apellido, @cedula,@telefono,@usuario,@contrasena)";
                MySqlCommand cmd = new MySqlCommand(query, conexion.GetConexion());





                cmd.Parameters.AddWithValue("@nombre", model.Nombre);
                cmd.Parameters.AddWithValue("@apellido", model.Apellido);
                cmd.Parameters.AddWithValue("@cedula", model.Cedula);
                cmd.Parameters.AddWithValue("@telefono", model.Telefono);
                cmd.Parameters.AddWithValue("@usuario", model.Usuario);
                cmd.Parameters.AddWithValue("@contrasena", hashedPassword);
                cmd.ExecuteNonQuery();
                conexion.Close();

                return true;
            }

            
            
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
