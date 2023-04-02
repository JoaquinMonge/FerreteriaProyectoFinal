using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica.Usuarios;
using Modelos.Interfaces.Usuarios;
using Modelos.Usuarios;


namespace FerreteriaProyectoFinal.Usuario
{
    public partial class FrmAutenticarParaEditar : Form
    {
        public FrmAutenticarParaEditar()
        {
            InitializeComponent();
           
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {

            UsuarioModel model = new UsuarioModel();

            model.Usuario = txtUsuario.Text;
            model.Contrasena = txtPwd.Text;
            UsuarioBs usuarioBs = new UsuarioBs();
            if (usuarioBs.consultaLogin(model))
            {
                MessageBox.Show("Contraseña correcta");
                this.Hide();
                FrmEditarUsuario editar = new FrmEditarUsuario();
                editar.Show();

                UsuarioModel usuario = usuarioBs.ObtenerDatosUsuario(model.ID);

                editar.txtNombreUsu.Text = usuario.Nombre;
                editar.txtCedula.Text = usuario.Cedula;
                editar.txtApellido.Text = usuario.Apellido;
                editar.txtTelefono.Text = usuario.Telefono;
                editar.txtUsuario.Text = usuario.Usuario;
            }
            else
            {
                MessageBox.Show("Contraseña incorrecta");

            }

           

        }

        private void FrmAutenticarParaEditar_Load(object sender, EventArgs e)
        {
            txtPwd.Focus();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FrmVentanaPrincipal home = new FrmVentanaPrincipal();
            home.txtUsuario.Text = txtUsuario.Text;
            
            home.Show();
            this.Close();
        }
    }
}
