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
using Modelos.Usuarios;
using Logica.Ventas;

namespace FerreteriaProyectoFinal
{
    public partial class FrmLogin : Form
    {
        VentasBs ventas = new VentasBs();
        public FrmLogin()
        {
            InitializeComponent();

            ventas.EliminarFacturaCtdCero();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            UsuarioModel model = new UsuarioModel();

            model.Usuario = txtUsuario.Text;
            model.Contrasena = txtPwd.Text;


            UsuarioBs usuarioBs = new UsuarioBs();
            if (usuarioBs.consultaLogin(model))
            {

                
                MessageBox.Show("El usuario ha sido encontrado");

                this.Hide();

                FrmVentanaPrincipal inicio=new FrmVentanaPrincipal();

                inicio.txtUsuario.Text = txtUsuario.Text;

                inicio.Show();


            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.");

            }
        }

        private void lblRegistrarse_Click(object sender, EventArgs e)
        {
            Usuario.FrmRegistrarUsuario registrar=new Usuario.FrmRegistrarUsuario();   
            
            registrar.Show();

            this.Hide();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
