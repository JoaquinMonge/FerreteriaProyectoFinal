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

            FrmVentanaPrincipal home = new FrmVentanaPrincipal();
            if (string.IsNullOrEmpty(txtNuevo.Text))
            {
                // Llenar el resto de los campos en el modelo
                modelo.Usuario = txtUsuario.Text;
                modelo.Nombre = txtNombreUsu.Text;
                modelo.Cedula = txtCedula.Text;
                modelo.Apellido = txtApellido.Text;
                modelo.Telefono = txtTelefono.Text;
                modelo.Contrasena = txtPwd.Text;
            }
            else
            {
                // Llenar el resto de los campos en el modelo
                modelo.Usuario = txtNuevo.Text;
                modelo.Nombre = txtNombreUsu.Text;
                modelo.Cedula = txtCedula.Text;
                modelo.Apellido = txtApellido.Text;
                modelo.Telefono = txtTelefono.Text;
                modelo.Contrasena = txtPwd.Text;
            }


            int idUsuario= usuarioBs.ObtenerIdUsuario(txtUsuario.Text);

            usuarioBs.ActualizarUsuario(modelo, idUsuario);


            MessageBox.Show("Usuario editado con éxito");
                
    

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
