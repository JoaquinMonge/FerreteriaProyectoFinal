using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica.Inventario;

namespace FerreteriaProyectoFinal.Inventario
{
    public partial class FrmInventario : Form
    {
        InventarioBs inventario=new InventarioBs(); 
        public FrmInventario()
        {
            InitializeComponent();
            dgvInventario.DataSource = inventario.ConsultaDT();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmVentanaPrincipal home=new FrmVentanaPrincipal();
            home.Show();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmRegistroProducto producto=new FrmRegistroProducto(); 
            producto.Show();
        }
    }
}
