using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modelos.Clientes;
using Logica.Inventario;
using Modelos.Inventario;
using Logica.Ventas;
using Modelos.Factura;
using Logica.Clientes;

namespace FerreteriaProyectoFinal.Factura
{
    public partial class FrmAsignarProd : Form
    {
       
        InventarioBs inv = new InventarioBs();
       VentasBs ventas = new VentasBs();    
        
        private ClienteModel cliente;
        public FrmAsignarProd(ClienteModel cliente)
        {
            InitializeComponent();
            dgvProductos.DataSource = inv.ConsultaDT();

           
            this.cliente = cliente;
        }

        private void FrmAsignarProd_Load(object sender, EventArgs e)
        {

        }



        private void btnAsignar_Click(object sender, EventArgs e)
        {
            List<InventarioModel> asignarProductos = new List<InventarioModel>();

          
            //Con esto se recorren las filas del DGV para agregar los productos seleccionados a la lista del cliente
            foreach (DataGridViewRow row in dgvProductos.Rows)
            {
                if (row.Cells["Asignar"].Value != null && (bool)row.Cells["Asignar"].Value == true)
                {
                    //Se obtiene la cantidad que digito el vendedor
                    int cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);

                    //Se obtiene la cantidad de stock del DGV
                    int stock = Convert.ToInt32(row.Cells["existencias"].Value);


                    if (cantidad > stock)
                    {
                        MessageBox.Show($"La cantidad ingresada ({row.Cells["cantidad"].Value}) para el producto {row.Cells["nombre"].Value} es mayor a la cantidad en stock  ({row.Cells["existencias"].Value}).");
                        return;
                    }

                    // Crear un nuevo objeto InventarioModel con los valores de la fila del DataGridView
                    InventarioModel producto = new InventarioModel
                    {
                        codigoProducto = Convert.ToInt32(row.Cells["codigoProducto"].Value),
                        nombre = row.Cells["nombre"].Value.ToString(),
                        precio = Convert.ToInt32(row.Cells["precio"].Value),
                        existencias = Convert.ToInt32(row.Cells["existencias"].Value),
                        descripcion = row.Cells["descripcion"].Value.ToString(),
                        cantidad = cantidad

                    };
                    asignarProductos.Add(producto);
                }
            }

            // Insertar los productos asignados en la base de datos
            // Recuperar el cliente seleccionado en el formulario anterior y su respectivo ID
            string idCliente =  cliente.Cedula;

            foreach (InventarioModel producto in asignarProductos)
            {
                // Crear un nuevo objeto VentasModel con los valores del producto asignado y el ID del cliente
                FacturaModel facturaModel = new FacturaModel
                {
                    Cedula = idCliente,
                    Codigo = producto.codigoProducto,
                    Precio = producto.precio,
                    Cantidad = producto.cantidad,
                   
                };

                // Crear un objeto de la clase Random
                Random rnd = new Random();

                // Generar un número aleatorio de tipo entero
                int id = rnd.Next(1000, 9999);

                // Convertir el número en una cadena de caracteres con formato "FA-xxxx"
                string idFactura = "ID-" + id.ToString();

                ventas.RegistrarVenta(facturaModel, idFactura);

                int existenciasActualizada = producto.existencias - producto.cantidad;
                inv.ActualizarStock(producto.codigoProducto, existenciasActualizada);

                

            }
            
                MessageBox.Show("Producto(s) asignados correctamente");
            
        }

        private void btnConfirmarCompra_Click(object sender, EventArgs e)
        {
            FrmGenerarFactura frm = new FrmGenerarFactura();
            ClientesBs clientes = new ClientesBs();
            ClienteModel cliente = clientes.ObtenerClienteID(txtCedula.Text);

            




            //validar que tenga articulos

            DataTable facturas;

            facturas = ventas.ConsultaDT(Convert.ToInt32( txtCedula.Text));

            if(facturas.Rows.Count> 0)
            {
                frm.txtNombre.Text = cliente.Nombre;
                frm.txtApellido.Text = cliente.Apellidos;
                frm.txtTelefono.Text = cliente.Telefono;
                frm.txtCorreo.Text = cliente.Correo;
                frm.txtCedula.Text = cliente.Cedula;
                frm.txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

                frm.Show();
                frm.dgvGenerarFactura.DataSource = ventas.ConsultaDT(Convert.ToInt32(txtCedula.Text));

                frm.dgvGenerarFactura.Columns["idProducto"].HeaderText = "ID Producto";
                frm.dgvGenerarFactura.Columns["precioTotal"].HeaderText = "Precio Total";
                frm.dgvGenerarFactura.Columns["cantidadProducto"].HeaderText = "Cantidad";
                frm.dgvGenerarFactura.Columns["precioUnitario"].HeaderText = "Precio";


                frm.dgvGenerarFactura.Columns["id"].Visible = false;
                frm.dgvGenerarFactura.Columns["idFactura"].Visible = false;
                frm.dgvGenerarFactura.Columns["idCliente"].Visible = false;
                frm.dgvGenerarFactura.Columns["estado"].Visible = false;

                frm.dgvGenerarFactura.Columns["idProducto"].DisplayIndex = 0;

                decimal sumatoriaPrecioTotal = 0;
                foreach (DataGridViewRow row in frm.dgvGenerarFactura.Rows)
                {
                    decimal precioTotal = Convert.ToDecimal(row.Cells["precioTotal"].Value);
                    sumatoriaPrecioTotal += precioTotal;
                }

                // Mostrar la sumatoria en un TextBox
                frm.txtTotal.Text = "₡" + sumatoriaPrecioTotal.ToString();

                DataGridViewRow idFact = frm.dgvGenerarFactura.Rows[0];
                string idFactura = idFact.Cells["idFactura"].Value.ToString();
                frm.txtIdFactura.Text = idFactura.ToString();
                foreach (DataGridViewRow row in frm.dgvGenerarFactura.Rows)
                {
                    int idProducto = Convert.ToInt32(row.Cells["idProducto"].Value);
                    InventarioModel producto = inv.ObtenerProductoID(idProducto);

                    if (producto != null)
                    {
                        row.Cells["Producto"].Value = producto.nombre;
                    }

                }
            }
            else
            {
                MessageBox.Show("El cliente no tiene productos asignados. No se pudo generar la factura.");
            }







           
        }
    }
}
