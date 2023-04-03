using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica.Ventas;
using Modelos.Interfaces.Ventas;

namespace FerreteriaProyectoFinal.Factura
{
    public partial class FrmEditarFactura : Form
    {

        VentasBs ventas = new VentasBs();
        public FrmEditarFactura()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FrmFacturas facturas= new FrmFacturas();
            facturas.Show();
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Esta seguro que desea eliminarlo?", "Some Title", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                ventas.EliminarFactura(txtCedula.Text);
                MessageBox.Show("Eliminado con exito");
                FrmFacturas factura = new FrmFacturas();
                factura.Show();
                this.Close();
            }
            else if (dialogResult == DialogResult.No)
            {
                
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            FacturaModel modelo = new FacturaModel();
            modelo.Total = Convert.ToInt32( txtPrecioUnit.Text);
            modelo.Cedula = txtCedula.Text;
            modelo.Codigo = Convert.ToInt32(txtIdProducto.Text);
            modelo.PrecioTotal = Convert.ToInt32(txtPrecioTot.Text)* Convert.ToInt32(txtCantidad.Text) ;
            modelo.Estado = "pendiente";
            modelo.Cantidad = Convert.ToInt32(txtCantidad.Text);

            ventas.ActualizarFactura(modelo,Convert.ToInt32(txtIdProducto.Text));

            MessageBox.Show("Editado con exito");

            FrmFacturas fact =new FrmFacturas();
            fact.Show();
            this.Close();
        }
    }
}
