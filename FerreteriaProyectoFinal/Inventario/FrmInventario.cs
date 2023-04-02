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

        private void dgvInventario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvInventario_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvInventario.Rows.Count)
            {
                // Obtener los valores de la fila seleccionada
                int id = Convert.ToInt32(dgvInventario.Rows[e.RowIndex].Cells["codigoProducto"].Value);
                string nombre = dgvInventario.Rows[e.RowIndex].Cells["nombre"].Value.ToString();
                string desc = dgvInventario.Rows[e.RowIndex].Cells["descripcion"].Value.ToString();
                int precio = Convert.ToInt32(dgvInventario.Rows[e.RowIndex].Cells["precio"].Value);
                int existencias = Convert.ToInt32(dgvInventario.Rows[e.RowIndex].Cells["existencias"].Value);

                Inventario.FrmEditarInventario editar = new FrmEditarInventario();
               
                editar.txtNombre.Text = nombre;
                editar.txtDesc.Text = desc;
                editar.txtPrecio.Text = precio.ToString();
                editar.txtExistencias.Text = existencias.ToString();
                editar.txtID.Text = id.ToString();
                editar.Show();
                this.Close();
            }
        }
    }
}
