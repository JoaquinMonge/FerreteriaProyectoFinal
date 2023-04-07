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
    public partial class FrmRegistrarUsuario : Form
    {
        public FrmRegistrarUsuario()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            UsuarioModel model = new UsuarioModel();

            model.Nombre = txtNombreUsu.Text;
            model.Apellido = txtApellido.Text;
            model.Cedula=txtCedula.Text;
            model.Telefono = txtTelefono.Text;
            model.Usuario = txtUsuario.Text;
            model.Contrasena = txtPwd.Text;

            IUsuarios usuario = new UsuarioBs();

            if (txtPwd.Text == txtConfirmPwd.Text)
            {
                bool registrado = usuario.CrearUsuario(model);

                if (registrado)
                {
                    MessageBox.Show("El usuario fue registrado con exito");

                    this.Close();

                    FrmLogin login = new FrmLogin();

                    login.Show();
                }
                else
                {
                    MessageBox.Show("El usuario ya existe, intentelo de nuevo.");

                }
            }
            else
            {
                MessageBox.Show("Las contraseñas no coinciden");
            }

            

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FrmLogin login = new FrmLogin();

            login.Show();

            this.Close();
        }
    }
}
