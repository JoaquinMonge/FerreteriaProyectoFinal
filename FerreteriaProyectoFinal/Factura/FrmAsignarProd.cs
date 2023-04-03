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
using Modelos.Ventas;

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
            int idCliente = Convert.ToInt32( cliente.Cedula);

            foreach (InventarioModel producto in asignarProductos)
            {
                // Crear un nuevo objeto VentasModel con los valores del producto asignado y el ID del cliente
                VentasModel ventaModel = new VentasModel
                {
                    ID = idCliente,
                    IdProducto = producto.codigoProducto,
                    PrecioTotal = producto.precio,
                    Cantidad = producto.cantidad,
                };

                ventas.RegistrarVenta(ventaModel);

                int existenciasActualizada = producto.existencias - producto.cantidad;
                inv.ActualizarStock(producto.codigoProducto, existenciasActualizada);

                

            }
            
                MessageBox.Show("Producto(s) asignados correctamente");
            
        }
    }
}
