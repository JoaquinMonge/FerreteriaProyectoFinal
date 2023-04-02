using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica.Clientes;


namespace FerreteriaProyectoFinal.Clientes
{
    public partial class FrmClientes : Form
    {
        ClientesBs clientes = new ClientesBs();
        public FrmClientes()
        {
            InitializeComponent();
            dgvInventario.DataSource = clientes.ConsultaDT();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmVentanaPrincipal home = new FrmVentanaPrincipal();
            home.Show();
        }
    }
}
