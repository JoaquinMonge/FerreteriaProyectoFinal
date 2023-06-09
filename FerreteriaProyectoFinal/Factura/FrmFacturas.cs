﻿using System;
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
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnTodos_Click(object sender, EventArgs e)
        {
           dgvFacturas.DataSource= ventas.ConsultaEstado(null);


        }

        private void btnPendientes_Click(object sender, EventArgs e)
        {
            dgvFacturas.DataSource = ventas.ConsultaEstado("pendiente");

        }

        private void btnCompletados_Click(object sender, EventArgs e)
        {
            dgvFacturas.DataSource = ventas.ConsultaEstado("completado");

        }
    }
}
