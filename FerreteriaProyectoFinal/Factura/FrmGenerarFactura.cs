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
using Logica.Inventario;

namespace FerreteriaProyectoFinal.Factura
{
    public partial class FrmGenerarFactura : Form
    {
            VentasBs ventas = new VentasBs();

        public FrmGenerarFactura()
        {
            InitializeComponent();






        }

        public  void MostrarDatosFactura()
        {
            dgvGenerarFactura.DataSource = ventas.ObtenerFacturas();
            dgvGenerarFactura.Columns["Id"].Visible = false;
            dgvGenerarFactura.Columns["Cliente"].Visible = false;
            dgvGenerarFactura.Columns["Fecha"].Visible = false;
            dgvGenerarFactura.Columns["Estado"].Visible = false;
            dgvGenerarFactura.Columns["Cedula"].Visible = false;

            dgvGenerarFactura.Columns["Codigo"].DisplayIndex = 0;
            dgvGenerarFactura.Columns["Producto"].DisplayIndex = 1;
            dgvGenerarFactura.Columns["Cantidad"].DisplayIndex = 2;
            dgvGenerarFactura.Columns["Precio"].DisplayIndex = 3;



            decimal total = 0;
            foreach (DataGridViewRow row in dgvGenerarFactura.Rows)
            {
                decimal valor = Convert.ToDecimal(row.Cells["PrecioTotal"].Value);
                total += valor;
            }
            txtTotal.Text = total.ToString();
        }

       
    }
}
