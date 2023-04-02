using Logica.Inventario;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modelos.Inventario;
using Modelos.Interfaces.Inventario;

namespace FerreteriaProyectoFinal.Inventario
{
    public partial class FrmEditarInventario : Form
    {
        InventarioBs inventario = new InventarioBs();
        FrmInventario inv = new FrmInventario();
        public FrmEditarInventario()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
         
            inv.Show();
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            InventarioModel modelo = new InventarioModel();
            modelo.nombre = txtNombre.Text;
            modelo.descripcion = txtDesc.Text;
            modelo.precio =Convert.ToInt32( txtPrecio.Text);
            modelo.existencias = Convert.ToInt32(txtExistencias.Text);
            inventario.ActualizarProducto(modelo,Convert.ToInt32(txtID.Text));
            MessageBox.Show("Producto editado con exito");
            this.Close();
            FrmInventario inv = new FrmInventario();
            inv.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id=Convert.ToInt32(txtID.Text);
            inventario.EliminarProducto(id);
            MessageBox.Show("Producto eliminado con exito");
            this.Close();
            inv.Show();
           
        }
    }
}
