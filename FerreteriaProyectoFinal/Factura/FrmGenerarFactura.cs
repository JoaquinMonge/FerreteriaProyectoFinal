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

        private void dgvGenerarFactura_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FrmEditarFactura editar = new FrmEditarFactura();
            editar.Show();


            if (e.RowIndex >= 0 && e.RowIndex < dgvGenerarFactura.Rows.Count)
            {
                // Obtener los valores de la fila seleccionada
            string cedula = dgvGenerarFactura.Rows[e.RowIndex].Cells["idCliente"].Value.ToString();        
            string total = dgvGenerarFactura.Rows[e.RowIndex].Cells["precioUnitario"].Value.ToString();
            string precioTotal = dgvGenerarFactura.Rows[e.RowIndex].Cells["precioTotal"].Value.ToString();
            string cantidad = dgvGenerarFactura.Rows[e.RowIndex].Cells["cantidadProducto"].Value.ToString();
            string IDProd = dgvGenerarFactura.Rows[e.RowIndex].Cells["idProducto"].Value.ToString();
                string IDFactura = dgvGenerarFactura.Rows[e.RowIndex].Cells["idFactura"].Value.ToString();
                string estado= dgvGenerarFactura.Rows[e.RowIndex].Cells["estado"].Value.ToString();


            editar.txtEstao.Text = estado;
            editar.txtCedula.Text = cedula;
            editar.txtCantActual.Text=cantidad;
            editar.txtIdProd.Text = IDFactura;
            editar.txtPrecioTot.Text = precioTotal;
            editar.txtPrecioUnit.Text = total;
            editar.txtIdProducto.Text = IDProd;


            editar.Show();
            this.Close();
            }
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            string idFactura = txtIdFactura.Text;
            bool cambioEstado = ventas.ActualizarEstado(idFactura);
            if (cambioEstado)
            {
                MessageBox.Show("Pago realizado con exito");
                
                Clientes.FrmClientes cliente = new Clientes.FrmClientes();
                cliente.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Ocurrio un error");
            }

        }
    }
}
