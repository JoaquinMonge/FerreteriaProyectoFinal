using Logica.Usuarios;
using Modelos.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace FerreteriaProyectoFinal.Usuario
{
    public partial class FrmEditarUsuario : Form
    {
       
        public FrmEditarUsuario()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            UsuarioModel modelo = new UsuarioModel();

            // Pasar el modelo existente con el ID al método ActualizarUsuario
            UsuarioBs usuarioBs = new UsuarioBs();

            string pwd = txtPwd.Text;
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

            if (txtPwd.Text == txtConfirmPwd.Text)
            {
                

              
                    FrmVentanaPrincipal home = new FrmVentanaPrincipal();
                    if (string.IsNullOrEmpty(txtNuevo.Text))
                    {
                        // Llenar el resto de los campos en el modelo
                        modelo.Usuario = txtUsuario.Text;
                        modelo.Nombre = txtNombreUsu.Text;
                        modelo.Cedula = txtCedula.Text;
                        modelo.Apellido = txtApellido.Text;
                        modelo.Telefono = txtTelefono.Text;
                        modelo.Contrasena = hashedPassword;
                    }
                    else
                    {
                        // Llenar el resto de los campos en el modelo
                        modelo.Usuario = txtNuevo.Text;
                        modelo.Nombre = txtNombreUsu.Text;
                        modelo.Cedula = txtCedula.Text;
                        modelo.Apellido = txtApellido.Text;
                        modelo.Telefono = txtTelefono.Text;
                        modelo.Contrasena = hashedPassword;
                    }

                int idUsuario = usuarioBs.ObtenerIdUsuario(txtUsuario.Text);

                usuarioBs.ActualizarUsuario(modelo, idUsuario);


                MessageBox.Show("Usuario editado con éxito");


            }
            else
            {
                MessageBox.Show("Las contraseñas no coinciden");
            }

            


         
                
    

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FrmVentanaPrincipal home = new FrmVentanaPrincipal();
            if (string.IsNullOrEmpty(txtNuevo.Text))
            {
                home.txtUsuario.Text = txtUsuario.Text;
            }
            else
            {
                home.txtUsuario.Text = txtNuevo.Text;
            }
            
                home.Show();
                this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            FrmEliminarUIsuario eliminar=new FrmEliminarUIsuario();

            eliminar.txtUsuario.Text=txtUsuario.Text;

            eliminar.Show();

            this.Close();
            
        }
    }
}
