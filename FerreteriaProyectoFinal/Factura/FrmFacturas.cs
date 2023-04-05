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
using Modelos.Factura;
using Modelos.Clientes;
using Modelos.Inventario;
using Logica.Inventario;
using Logica.Clientes;

namespace FerreteriaProyectoFinal.Factura
{
    public partial class FrmFacturas : Form
    {
        VentasBs ventas = new VentasBs();
        public FrmFacturas()
        {
            InitializeComponent();
            

            
        }

        public void MostrarFacturas()
        {
            // Obtener todas las facturas desde la capa de datos
            List<FacturaModel> facturas = ventas.ObtenerFacturas();

            // Crear una lista de facturas con los nombres de cliente y producto
            List<FacturaModel> facturasMostradas = new List<FacturaModel>();
            foreach (FacturaModel factura in facturas)
            {
                ClientesBs clientesBs = new ClientesBs();
                InventarioBs inventarioBs = new InventarioBs();
                ClienteModel cliente = clientesBs.ObtenerClienteID(factura.Cedula);
                InventarioModel producto = inventarioBs.ObtenerProductoID(factura.Codigo);
                FacturaModel facturaMostrada = new FacturaModel
                {
                    Id = factura.Id,
                    Fecha = DateTime.Now,
                    Cedula = cliente.Cedula,
                    Cliente = cliente.Nombre,
                    Codigo = producto.codigoProducto,
                    Producto = producto.nombre,
                    Cantidad = factura.Cantidad,
                    Precio = producto.precio,
                    Estado= factura.Estado,
                    PrecioTotal = factura.Cantidad * factura.Precio
                };
                
                facturasMostradas.Add(facturaMostrada);
            }
            DataTable tablaFacturas = new DataTable();
            tablaFacturas.Columns.Add("Id", typeof(string));
            tablaFacturas.Columns.Add("Fecha", typeof(DateTime));
            tablaFacturas.Columns.Add("Cedula", typeof(string));
            tablaFacturas.Columns.Add("Cliente", typeof(string));
            tablaFacturas.Columns.Add("Codigo", typeof(string));
            tablaFacturas.Columns.Add("Producto", typeof(string));
            tablaFacturas.Columns.Add("Cantidad", typeof(int));
            tablaFacturas.Columns.Add("Precio", typeof(decimal));
            tablaFacturas.Columns.Add("Estado", typeof(string));
            tablaFacturas.Columns.Add("Precio Total", typeof(decimal));



            foreach (FacturaModel factura in facturasMostradas)
            {
                DataRow fila = tablaFacturas.NewRow();
                fila["Id"] = factura.Id;
                fila["Fecha"] = factura.Fecha;
                fila["Cedula"] = factura.Cedula;
                fila["Cliente"] = factura.Cliente;
                fila["Producto"] = factura.Producto;
                fila["Codigo"] = factura.Codigo;
                fila["Cantidad"] = factura.Cantidad;
                fila["Precio"] = factura.Precio;
                fila["Estado"] = factura.Estado;
                fila["Precio Total"] = factura.PrecioTotal;
                tablaFacturas.Rows.Add(fila);
            }

            // Asignar el DataTable al DataGridView
            dgvFacturas.DataSource = tablaFacturas;

            // Asignar la lista de facturas mostradas al DataGridView
            
            dgvFacturas.Columns[6].DisplayIndex = 3;

            

            // Recorrer las filas del DataGridView para calcular el valor de la columna "Cantidad x Total"
            foreach (DataGridViewRow row in dgvFacturas.Rows)
            {
                int cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                decimal total = Convert.ToDecimal(row.Cells["Precio"].Value);
                decimal cantidadTotal = cantidad * total;
                row.Cells["Precio Total"].Value = cantidadTotal;
            }
        }

        private void FrmFacturas_Load(object sender, EventArgs e)
        {
            MostrarFacturas();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            //con esto se obtiene el datble asociado al dgv
            DataTable fact = (DataTable)dgvFacturas.DataSource;

            fact.DefaultView.RowFilter = String.Format("cedula LIKE '%{0}%'", txtBuscar.Text);
            decimal sumatoriaPrecioTotal = 0;
            foreach (DataGridViewRow row in dgvFacturas.Rows)
            {
                decimal precioTotal = Convert.ToDecimal(row.Cells["Precio Total"].Value);
                sumatoriaPrecioTotal += precioTotal;
            }

            // Mostrar la sumatoria en un TextBox
            txtToalPagar.Text = sumatoriaPrecioTotal.ToString();
            if (txtBuscar.Text.Length == 0)
            {
                txtToalPagar.Text = " ";
            }
            txtBuscar.Text = "";

            dgvFacturas.DataSource = fact;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            
            FrmVentanaPrincipal home = new FrmVentanaPrincipal();
            home.Show();
            this.Close();
        }

        private void dgvFacturas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dgvFacturas_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvFacturas.Rows.Count)
            {
                // Obtener los valores de la fila seleccionada
                string cedula = dgvFacturas.Rows[e.RowIndex].Cells["Cedula"].Value.ToString();
                string cliente = dgvFacturas.Rows[e.RowIndex].Cells["Cliente"].Value.ToString();
                string fecha = dgvFacturas.Rows[e.RowIndex].Cells["Fecha"].Value.ToString();
                string total = dgvFacturas.Rows[e.RowIndex].Cells["Precio"].Value.ToString();
                string precioTotal = dgvFacturas.Rows[e.RowIndex].Cells["Precio Total"].Value.ToString();
                string producto = dgvFacturas.Rows[e.RowIndex].Cells["Producto"].Value.ToString();
                string cantidad = dgvFacturas.Rows[e.RowIndex].Cells["Cantidad"].Value.ToString();
                string IDProd = dgvFacturas.Rows[e.RowIndex].Cells["Codigo"].Value.ToString();


                FrmEditarFactura editar = new FrmEditarFactura();


                editar.txtNombre.Text = cliente;
                editar.txtCantidad.Text = cantidad;
                editar.txtCedula.Text = cedula;
                editar.txtFecha.Text = fecha;
                editar.ttxtNombreProd.Text = producto;
                editar.txtPrecioTot.Text = precioTotal;
                editar.txtPrecioUnit.Text = total;
                editar.txtIdProducto.Text = IDProd;


                editar.Show();
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            FrmConfirmarFactura confirmar = new FrmConfirmarFactura();

            confirmar.dgvFacturaCliente.Columns.Add("ID", "ID");
            confirmar.dgvFacturaCliente.Columns.Add("Fecha", "Fecha");
            confirmar.dgvFacturaCliente.Columns.Add("Cedula", "Cedula");
            confirmar.dgvFacturaCliente.Columns.Add("Cliente", "Cliente");
            confirmar.dgvFacturaCliente.Columns.Add("Codigo", "Codigo");
            confirmar.dgvFacturaCliente.Columns.Add("Producto", "Producto");
            confirmar.dgvFacturaCliente.Columns.Add("Cantidad", "Cantidad");
            confirmar.dgvFacturaCliente.Columns.Add("Total", "Total");
            confirmar.dgvFacturaCliente.Columns.Add("Estado", "Estado");
            confirmar.dgvFacturaCliente.Columns.Add("Precio Total", "Precio Total");
            
            
            //id,cedula,nombre cliente fecha
            //dgv=producto, cantidad
            

            foreach (DataGridViewRow row in dgvFacturas.Rows)
            {
                // Crear una nueva fila en el segundo DataGridView
                DataGridViewRow nuevaFila = (DataGridViewRow)row.Clone();

                // Agregar las celdas de la fila original a la nueva fila
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    nuevaFila.Cells[i].Value = row.Cells[i].Value;
                }

                // Agregar la nueva fila al segundo DataGridView
                confirmar.dgvFacturaCliente.Rows.Add(nuevaFila);
            }
            confirmar.Show();
            this.Close();

        }
    }
}
