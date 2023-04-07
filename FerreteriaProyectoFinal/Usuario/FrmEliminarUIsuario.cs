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

namespace FerreteriaProyectoFinal.Usuario
{
    public partial class FrmEliminarUIsuario : Form
    {
        public FrmEliminarUIsuario()
        {
            InitializeComponent();
        }

        private void btnSi_Click(object sender, EventArgs e)
        {
            UsuarioBs usuarioBs = new UsuarioBs();

            usuarioBs.EliminarUsuario(txtUsuario.Text);

            MessageBox.Show("Cuenta eliminada con exito");

            FrmLogin login = new FrmLogin();

            login.Show();

            this.Close();

        }
    }
}
