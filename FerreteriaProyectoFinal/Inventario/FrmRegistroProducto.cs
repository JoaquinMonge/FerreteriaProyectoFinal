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
using Modelos.Inventario;
using Modelos.Interfaces.Inventario;

namespace FerreteriaProyectoFinal.Inventario
{
    public partial class FrmRegistroProducto : Form
    {
        InventarioBs inventario=new InventarioBs();
        
        public FrmRegistroProducto()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            InventarioModel model = new InventarioModel();
            model.nombre = txtNombreProd.Text;
            model.descripcion = txtDesc.Text;
            model.precio = Convert.ToInt32(txtPrecio.Text);
            model.existencias = Convert.ToInt32(txtExistencias.Text);

            IInventario inventario = new InventarioBs();

           bool registrado= inventario.RegistrarProducto(model);

            if (registrado)
            {
                MessageBox.Show("El producto se ha registrado correctamente");
                this.Close();
                FrmInventario Paginainventario = new FrmInventario();
                Paginainventario.Show();
            }
            else
            {
                MessageBox.Show("Error al insertar producto");
            }

        }
    }
}
